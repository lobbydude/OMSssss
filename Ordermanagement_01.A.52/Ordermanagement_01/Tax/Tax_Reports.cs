using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ClosedXML.Excel;

namespace Ordermanagement_01.Tax
{
    public partial class Tax_Reports : Form
     
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass db = new DropDownistBindClass();
        string Path1;
        Classes.Load_Progres form_loader = new Classes.Load_Progres();

        public Tax_Reports()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddChilds(string sKey)
        {
         
            //TreeNode parentnode;


           // Tree_View_Report.Nodes[0].Nodes.Add("User Production Report");
//
           // Tree_View_Report.ExpandAll();
        }

        private void Tax_Reports_Load(object sender, EventArgs e)
        {
            string sKeyTemp = "";
            txt_Fromdate.Value = DateTime.Now;
            txt_Todate.Value = DateTime.Now;
            this.WindowState = FormWindowState.Maximized;

            lbl_Client.Visible = false;
            lbl_SubClient.Visible = false;
            ddl_Client.Visible = false;
            ddl_Subclient.Visible = false;
            db.Bind_Client_Name_For_Tax_Violation(ddl_Client);

            //Tree_View_Report.Nodes.Clear();
            //sKeyTemp = "Reports";
            //// sKeyTemp = dt.Rows[i]["Company_Name"].ToString();
            //Tree_View_Report.Nodes.Add(sKeyTemp, sKeyTemp);
           // AddChilds(sKeyTemp);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            form_loader.Start_progres();
            if (Tree_View_Report.SelectedNode.Index != 2)
            {
                if (validate_My_Report() != false)
                {
                    Load_User_Production_Report();

                }
            }
            else {
                if (validate_My_Report() != false)
                {
                    Load_User_Code_Violation_Report();

                }

            }

           
        }
        private bool validate_My_Report()
        {
            TreeNode tn = Tree_View_Report.SelectedNode;
            if (tn == null)
            {
                



                MessageBox.Show("Select any one Report");
                return false;
            }
            else
            {

                return true;
            }

        }

        private void Load_User_Production_Report()
        {
            DateTime Fromdate = Convert.ToDateTime(txt_Fromdate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(txt_Todate.Text.ToString());


            DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;


            Hashtable ht_Status = new Hashtable();
            System.Data.DataTable dt_Status = new System.Data.DataTable();
            System.Data.DataTable dt_orders = new System.Data.DataTable();

            dt_Status.Rows.Clear();
            string From_Date = Fromdate.ToString("MM/dd/yyyy");
            string To_Date = Todate.ToString("MM/dd/yyyy");

            ht_Status.Clear();
            dt_Status.Clear();
            string Client, SubProcess;


            if (Tree_View_Report.SelectedNode.Text == "EXTERNAL PRODUCTION REPORT")
            {

                if (rbtn_Recived_Date.Checked == true)
                {
                    ht_Status.Add("@Trans", "SELECT_EXTERNAL");
                }
                else if (rbtn_Completed.Checked == true)

                {
                    ht_Status.Add("@Trans", "SELECT_EXTERNAL_BY_PRODUCTION_DATE_WISE");
                  
                }
            }
            else if (Tree_View_Report.SelectedNode.Text == "INTERNAL PRODUCTION REPORT")

            {

                if (rbtn_Recived_Date.Checked == true)
                {

                    ht_Status.Add("@Trans", "SELECT_INTERNAL");

                }
                else if (rbtn_Completed.Checked == true)
                {
                    ht_Status.Add("@Trans", "SELECT_INTERNAL_PRODCUTIONP_DATE_WISE");

                }
            }

                ht_Status.Add("@From_Date", From_Date);
                ht_Status.Add("@To_Date", To_Date);

                dt_Status = dataaccess.ExecuteSP("Sp_Tax_User_Production_Report", ht_Status);




                dt_orders.Clear();
                dt_orders = dt_Status;


                if (dt_orders.Rows.Count > 0)
            {


            //    Grd_OrderTime.Rows.Clear();
                //Grd_OrderTime.DataSource = null;
                Grd_OrderTime.Visible = true;

                Grd_OrderTime.DataSource = null;
                Grd_OrderTime.AutoGenerateColumns = false;

                Grd_OrderTime.ColumnCount = 16;
                //Grd_OrderTime.Rows.Add();
                Grd_OrderTime.Columns[0].Name = "Orderid";
                Grd_OrderTime.Columns[0].HeaderText = "Order Id";
                Grd_OrderTime.Columns[0].DataPropertyName = "Order_ID";
                Grd_OrderTime.Columns[0].Width = 50;
                Grd_OrderTime.Columns[0].Visible = false;



                Grd_OrderTime.Columns[1].Name = "Assigned_Date";
                Grd_OrderTime.Columns[1].HeaderText = "Assigned_Date";
                Grd_OrderTime.Columns[1].DataPropertyName = "Assigned_Date";
                Grd_OrderTime.Columns[1].Width = 140;

                Grd_OrderTime.Columns[2].Name = "Client_Order_Number";
                Grd_OrderTime.Columns[2].HeaderText = "Order No";
                Grd_OrderTime.Columns[2].DataPropertyName = "Client_Order_Number";
                Grd_OrderTime.Columns[2].Width = 120;

                Grd_OrderTime.Columns[3].Name = "Borrower_Name";
                Grd_OrderTime.Columns[3].HeaderText = "Name";
                Grd_OrderTime.Columns[3].DataPropertyName = "Borrower_Name";
                Grd_OrderTime.Columns[3].Width = 300;

                Grd_OrderTime.Columns[4].Name = "Address";
                Grd_OrderTime.Columns[4].HeaderText = "Address";
                Grd_OrderTime.Columns[4].DataPropertyName = "Address";
                Grd_OrderTime.Columns[4].Width = 300;

                Grd_OrderTime.Columns[5].Name = "APN";
                Grd_OrderTime.Columns[5].HeaderText = "Parcel ID";
                Grd_OrderTime.Columns[5].DataPropertyName = "APN";
                Grd_OrderTime.Columns[5].Width = 150;

                Grd_OrderTime.Columns[6].Name = "State";
                Grd_OrderTime.Columns[6].HeaderText = "State";
                Grd_OrderTime.Columns[6].DataPropertyName = "State";
                Grd_OrderTime.Columns[6].Width = 200;

                Grd_OrderTime.Columns[7].Name = "County";
                Grd_OrderTime.Columns[7].HeaderText = "County";
                Grd_OrderTime.Columns[7].DataPropertyName = "County";
                Grd_OrderTime.Columns[7].Width = 200;

                Grd_OrderTime.Columns[8].Name = "Tax_Status";
                Grd_OrderTime.Columns[8].HeaderText = "Status";
                Grd_OrderTime.Columns[8].DataPropertyName = "Tax_Status";
                Grd_OrderTime.Columns[8].Width = 150;

                Grd_OrderTime.Columns[9].Name = "Completed_Date";
                Grd_OrderTime.Columns[9].HeaderText = "Completed Date";
                Grd_OrderTime.Columns[9].DataPropertyName = "Completed_Date";
                Grd_OrderTime.Columns[9].Width = 150;

                Grd_OrderTime.Columns[10].Name = "Agent_User_Name";
                Grd_OrderTime.Columns[10].HeaderText = "Processor";
                Grd_OrderTime.Columns[10].DataPropertyName = "Agent_User_Name";
                Grd_OrderTime.Columns[10].Width = 150;

                Grd_OrderTime.Columns[11].Name = "Qucier_User_Name";
                Grd_OrderTime.Columns[11].HeaderText = "QC'er";
                Grd_OrderTime.Columns[11].DataPropertyName = "Qucier_User_Name";
                Grd_OrderTime.Columns[11].Width = 160;

                Grd_OrderTime.Columns[12].Name = "Agent_User_Comments";
                Grd_OrderTime.Columns[12].HeaderText = "Processor Comments";
                Grd_OrderTime.Columns[12].DataPropertyName = "Agent_User_Comments";
                Grd_OrderTime.Columns[12].Width = 160;

                Grd_OrderTime.Columns[13].Name = "Qucier_Comments";
                Grd_OrderTime.Columns[13].HeaderText = "QC'er Comments";
                Grd_OrderTime.Columns[13].DataPropertyName = "Qucier_Comments";
                Grd_OrderTime.Columns[13].Width = 160;


                Grd_OrderTime.Columns[14].Name = "Error_Status";
                Grd_OrderTime.Columns[14].HeaderText = "Error";
                Grd_OrderTime.Columns[14].DataPropertyName = "Error_Status";
                Grd_OrderTime.Columns[14].Width = 120;

                Grd_OrderTime.Columns[15].Name = "Error_Note";
                Grd_OrderTime.Columns[15].HeaderText = "Error Note";
                Grd_OrderTime.Columns[15].DataPropertyName = "Error_Note";
                Grd_OrderTime.Columns[15].Width = 120;

                Grd_OrderTime.DataSource = dt_Status;





            }
            else
            {
                Grd_OrderTime.Rows.Clear();
                Grd_OrderTime.Visible = false;
                Grd_OrderTime.DataSource = null;
                //Grd_OrderTime.EmptyDataText = "No Orders Added";
                //Grd_OrderTime.DataBind();

            }
        }

        private void Load_User_Code_Violation_Report()
        {

            if (ddl_Client.SelectedIndex > 0 && ddl_Subclient.SelectedIndex > 0)
            {

                Hashtable ht_Status = new Hashtable();
                System.Data.DataTable dt_Status = new System.Data.DataTable();
                System.Data.DataTable dt_orders = new System.Data.DataTable();

                dt_Status.Rows.Clear();


                ht_Status.Clear();
                dt_Status.Clear();
                string Client, SubProcess;



                ht_Status.Add("@Trans", "SELECT_SUB_CLIENT_WISE");
                ht_Status.Add("@Client", ddl_Client.SelectedValue.ToString());
                ht_Status.Add("@Sub_Client", ddl_Subclient.SelectedValue.ToString());

                dt_Status = dataaccess.ExecuteSP("Sp_Tax_Violation_Report", ht_Status);




                dt_orders.Clear();
                dt_orders = dt_Status;


                if (dt_orders.Rows.Count > 0)
                {


                    //    Grd_OrderTime.Rows.Clear();
                    //Grd_OrderTime.DataSource = null;
                    Grd_OrderTime.Visible = true;

                    Grd_OrderTime.DataSource = null;
                    Grd_OrderTime.AutoGenerateColumns = false;

                    Grd_OrderTime.ColumnCount = 19;
                    //Grd_OrderTime.Rows.Add();
                    Grd_OrderTime.Columns[0].Name = "Orderid";
                    Grd_OrderTime.Columns[0].HeaderText = "Order Id";
                    Grd_OrderTime.Columns[0].DataPropertyName = "Order_ID";
                    Grd_OrderTime.Columns[0].Width = 50;
                    Grd_OrderTime.Columns[0].Visible = false;



                    Grd_OrderTime.Columns[1].Name = "Borrower_Name2";
                    Grd_OrderTime.Columns[1].HeaderText = "Last Name";
                    Grd_OrderTime.Columns[1].DataPropertyName = "Borrower_Name2";
                    Grd_OrderTime.Columns[1].Width = 140;

                    Grd_OrderTime.Columns[2].Name = "First Name";
                    Grd_OrderTime.Columns[2].HeaderText = "First Name";
                    Grd_OrderTime.Columns[2].DataPropertyName = "Borrower_Name";
                    Grd_OrderTime.Columns[2].Width = 120;

                    Grd_OrderTime.Columns[3].Name = "Address";
                    Grd_OrderTime.Columns[3].HeaderText = "Address";
                    Grd_OrderTime.Columns[3].DataPropertyName = "Address";
                    Grd_OrderTime.Columns[3].Width = 200;

                    Grd_OrderTime.Columns[4].Name = "City";
                    Grd_OrderTime.Columns[4].HeaderText = "City";
                    Grd_OrderTime.Columns[4].DataPropertyName = "City";
                    Grd_OrderTime.Columns[4].Width = 150;

                    Grd_OrderTime.Columns[5].Name = "Abbreviation";
                    Grd_OrderTime.Columns[5].HeaderText = "State";
                    Grd_OrderTime.Columns[5].DataPropertyName = "Abbreviation";
                    Grd_OrderTime.Columns[5].Width = 100;

                    Grd_OrderTime.Columns[6].Name = "Tax_Violation_Status";
                    Grd_OrderTime.Columns[6].HeaderText = "Status";
                    Grd_OrderTime.Columns[6].DataPropertyName = "Tax_Violation_Status";
                    Grd_OrderTime.Columns[6].Width = 100;

                    Grd_OrderTime.Columns[7].Name = "Code_Compliance_Comments";
                    Grd_OrderTime.Columns[7].HeaderText = "Code Compliance Comments";
                    Grd_OrderTime.Columns[7].DataPropertyName = "Code_Compliance_Comments";
                    Grd_OrderTime.Columns[7].Width = 200;

                    Grd_OrderTime.Columns[8].Name = "Demolition_Status_Date";
                    Grd_OrderTime.Columns[8].HeaderText = "Demolition Status + Date";
                    Grd_OrderTime.Columns[8].DataPropertyName = "Demolition_Status_Date";
                    Grd_OrderTime.Columns[8].Width = 200;

                    Grd_OrderTime.Columns[9].Name = "Other_Comments";
                    Grd_OrderTime.Columns[9].HeaderText = "Other Comments";
                    Grd_OrderTime.Columns[9].DataPropertyName = "Other_Comments";
                    Grd_OrderTime.Columns[9].Width = 150;

                    Grd_OrderTime.Columns[10].Name = "Municipal_Search_Total";
                    Grd_OrderTime.Columns[10].HeaderText = "Municipal Search Total";
                    Grd_OrderTime.Columns[10].DataPropertyName = "Municipal_Search_Total";
                    Grd_OrderTime.Columns[10].Width = 200;

                    Grd_OrderTime.Columns[11].Name = "Scheduled_for_Tax_Sale";
                    Grd_OrderTime.Columns[11].HeaderText = "Scheduled for Tax Sale";
                    Grd_OrderTime.Columns[11].DataPropertyName = "Scheduled_for_Tax_Sale";
                    Grd_OrderTime.Columns[11].Width = 200;

                    Grd_OrderTime.Columns[12].Name = "Tax_Sale_Date";
                    Grd_OrderTime.Columns[12].HeaderText = "Tax Sale Date (if applicable)";
                    Grd_OrderTime.Columns[12].DataPropertyName = "Tax_Sale_Date";
                    Grd_OrderTime.Columns[12].Width = 160;

                    Grd_OrderTime.Columns[13].Name = "Redemption_Amt";
                    Grd_OrderTime.Columns[13].HeaderText = "Redemption Amt";
                    Grd_OrderTime.Columns[13].DataPropertyName = "Redemption_Amt";
                    Grd_OrderTime.Columns[13].Width = 160;


                    Grd_OrderTime.Columns[14].Name = "Last_Date_to_Redeem";
                    Grd_OrderTime.Columns[14].HeaderText = "Last Date to Redeem";
                    Grd_OrderTime.Columns[14].DataPropertyName = "Last_Date_to_Redeem";
                    Grd_OrderTime.Columns[14].Width = 150;

                    Grd_OrderTime.Columns[15].Name = "Total_Amount_of_Taxes_Paid_by_3rd_Party";
                    Grd_OrderTime.Columns[15].HeaderText = "Total Amount of Taxes Paid by 3rd Party";
                    Grd_OrderTime.Columns[15].DataPropertyName = "Total_Amount_of_Taxes_Paid_by_3rd_Party";
                    Grd_OrderTime.Columns[15].Width = 200;

                    Grd_OrderTime.Columns[16].Name = "Comments";
                    Grd_OrderTime.Columns[16].HeaderText = "Comments";
                    Grd_OrderTime.Columns[16].DataPropertyName = "Comments";
                    Grd_OrderTime.Columns[16].Width = 120;

                    Grd_OrderTime.Columns[17].Name = "Detailed_list_of_steps_taken_to_obtain_information";
                    Grd_OrderTime.Columns[17].HeaderText = "Detailed list of steps taken to obtain information";
                    Grd_OrderTime.Columns[17].DataPropertyName = "Detailed_list_of_steps_taken_to_obtain_information";
                    Grd_OrderTime.Columns[17].Width = 200;


                    Grd_OrderTime.Columns[18].Name = "Detailed_Reason_why_it_cannot_be_obtained";
                    Grd_OrderTime.Columns[18].HeaderText = "Detailed Reason why it cannot be obtained";
                    Grd_OrderTime.Columns[18].DataPropertyName = "Detailed_Reason_why_it_cannot_be_obtained";
                    Grd_OrderTime.Columns[18].Width = 200;

                    Grd_OrderTime.DataSource = dt_Status;





                }
                else
                {
                    Grd_OrderTime.Rows.Clear();
                    Grd_OrderTime.Visible = false;
                    Grd_OrderTime.DataSource = null;
                    //Grd_OrderTime.EmptyDataText = "No Orders Added";
                    //Grd_OrderTime.DataBind();

                }
            }
            else
            {

                MessageBox.Show("Please Select Client and Subclient");
            }
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {

            form_loader.Start_progres();
            if (Grd_OrderTime.Rows.Count > 0)
            {
                Export_ReportData();
            }
            else
            {

                MessageBox.Show("Refresh The Report and Export");
            }
        }

        private void Export_ReportData()
        {



            System.Data.DataTable dt = new System.Data.DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in Grd_OrderTime.Columns)
            {
                if (column.HeaderText != "")
                {
                    if (column.ValueType == null)
                    {

                        dt.Columns.Add(column.HeaderText, typeof(string));

                    }
                    else
                    {
                        if (column.ValueType == typeof(int))
                        {
                            dt.Columns.Add(column.HeaderText, typeof(int));

                        }
                        else if (column.ValueType == typeof(decimal))
                        {
                            dt.Columns.Add(column.HeaderText, typeof(decimal));

                        }
                        else if (column.ValueType == typeof(DateTime))
                        {

                            dt.Columns.Add(column.HeaderText, typeof(string));
                        }
                        else
                        {
                            dt.Columns.Add(column.HeaderText, column.ValueType);
                        }
                    }
                }

            }

            //Adding the Rows
            foreach (DataGridViewRow row in Grd_OrderTime.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //string Value1 = cell.Value.ToString();
                    //string m = Value1.Trim().ToString();


                    if (cell.Value != null && cell.Value.ToString() != "")
                    {

                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }

            //Exporting to Excel
            string Export_Title_Name = "Tax_User_Production";
            string folderPath = "C:\\Temp\\";
            Path1 = folderPath + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "-" + Export_Title_Name + ".xlsx";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);


            }

           
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, Export_Title_Name.ToString());


                try
                {

                    wb.SaveAs(Path1);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("File is Opened, Please Close and Export it");
                }



            }

            System.Diagnostics.Process.Start(Path1);
        }

        private void Tree_View_Report_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Tree_View_Report.SelectedNode.Index == 0)
            {

                Lbl_Title.Text = "EXTERNAL PRODUCTION REPORT";
                lbl_Client.Visible = false;
                lbl_SubClient.Visible = false;
                ddl_Client.Visible = false;
                ddl_Subclient.Visible = false;

                lbl_from.Visible = true;
                lbl_to.Visible = true;
                txt_Fromdate.Visible = true;
                txt_Todate.Visible = true;
            }
            else if (Tree_View_Report.SelectedNode.Index == 1)
            {
                Lbl_Title.Text = "INTERNAL PRODUCTION REPORT";

                lbl_Client.Visible = false;
                lbl_SubClient.Visible = false;
                ddl_Client.Visible = false;
                ddl_Subclient.Visible = false;

                lbl_from.Visible = true;
                lbl_to.Visible = true;
                txt_Fromdate.Visible = true;
                txt_Todate.Visible = true;
            }
            else if (Tree_View_Report.SelectedNode.Index == 2)
            {

                Lbl_Title.Text = "CODE VIOLATION REPORT";
                lbl_Client.Visible = true;
                lbl_SubClient.Visible = true;
                ddl_Client.Visible = true;
                ddl_Subclient.Visible = true;

                lbl_from.Visible = false;
                lbl_to.Visible = false;
                txt_Fromdate.Visible = false;
                txt_Todate.Visible = false;

            }
        }

        private void rbtn_Recived_Date_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtn_Completed_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ddl_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Client.SelectedIndex > 0)
            {

                db.Bind_Sub_Client_For_Tax_Violation(ddl_Subclient, int.Parse(ddl_Client.SelectedValue.ToString()));
            }
        }
    }
}
