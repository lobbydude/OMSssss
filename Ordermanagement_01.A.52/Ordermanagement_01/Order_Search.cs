using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using Ordermanagement_01.Classes;
namespace Ordermanagement_01
{
    public partial class Order_Search : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataAccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();

        // below is the datacess layer for Old server

        Olddb_Datacess oldbdatacess = new Olddb_Datacess();


        int User_Id;
        string userroleid;
        InfiniteProgressBar.clsProgress cPro = new InfiniteProgressBar.clsProgress();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        string Export_Title_Name, Path1;
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataTable dtselect = new System.Data.DataTable();
        System.Data.DataTable dtnewselect = new System.Data.DataTable();
        System.Data.DataTable dtoldselect = new System.Data.DataTable();
        System.Data.DataTable dtAll = new System.Data.DataTable();
        string Search_Value,Old_Server_Value;
       
        public Order_Search(int USER_ID,string User_RoleID,string SEARCH_VALUE)
        {
            User_Id = USER_ID;
            userroleid = User_RoleID;
            Search_Value = SEARCH_VALUE;
            InitializeComponent();

            if (Search_Value != "")
            {

                txt_Order_number.Text = Search_Value.ToString();

                if (txt_Order_number.Text != "" && txt_Order_number.Text.Length > 0)
                {
                    //cPro.startProgress();
                    form_loader.Start_progres();
                    Hashtable htselect = new Hashtable();
                    dtselect.Clear();
                    string OrderNumber = txt_Order_number.Text.ToString();


                    htselect.Add("@Trans", "SEARCH");
                    htselect.Add("@Search_By", OrderNumber);
                    dtselect = dataAccess.ExecuteSP("Sp_Order", htselect);
                    dt = dtselect;

                    if (dtselect.Rows.Count > 0)
                    {
                        grd_order.Rows.Clear();
                        for (int i = 0; i < dtselect.Rows.Count; i++)
                        {
                            grd_order.Rows.Add();
                            grd_order.Rows[i].Cells[1].Value = dtselect.Rows[i]["Client_Order_Number"].ToString();
                            if (userroleid == "1")
                            {
                                grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Name"].ToString();
                                grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Sub_ProcessName"].ToString();


                            }
                            else if (userroleid == "2")
                            {
                                grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Number"].ToString();
                                grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Subprocess_Number"].ToString();

                            }

                            grd_order.Rows[i].Cells[4].Value = dtselect.Rows[i]["Date"].ToString();
                            grd_order.Rows[i].Cells[5].Value = dtselect.Rows[i]["Client_Order_Ref"].ToString();
                            grd_order.Rows[i].Cells[6].Value = dtselect.Rows[i]["Order_Type"].ToString();
                            grd_order.Rows[i].Cells[7].Value = dtselect.Rows[i]["Borrower_Name"].ToString();//BArrower Namr
                            grd_order.Rows[i].Cells[8].Value = dtselect.Rows[i]["Address"].ToString();
                            grd_order.Rows[i].Cells[9].Value = dtselect.Rows[i]["County"].ToString();
                            grd_order.Rows[i].Cells[10].Value = dtselect.Rows[i]["State"].ToString();
                            grd_order.Rows[i].Cells[11].Value = dtselect.Rows[i]["County_Type"].ToString();
                            grd_order.Rows[i].Cells[12].Value = dtselect.Rows[i]["Date"].ToString();//Process date Should be Completed or Recived date
                            grd_order.Rows[i].Cells[13].Value = dtselect.Rows[i]["Order_Status"].ToString();
                            grd_order.Rows[i].Cells[14].Value = dtselect.Rows[i]["Progress_Status"].ToString();
                            grd_order.Rows[i].Cells[15].Value = dtselect.Rows[i]["User_Name"].ToString();

                            grd_order.Rows[i].Cells[16].Value = dtselect.Rows[i]["Order_ID"].ToString();


                        }

                    }
                    else
                    {
                        grd_order.Visible = true;
                        grd_order.Rows.Clear();
                        grd_order.DataSource = null;

                    }

                    //cPro.stopProgress();

                }
        
            }
        }

       

        private void grd_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string Order_Old_New = grd_order.Rows[e.RowIndex].Cells[17].Value.ToString();
                // This If condition will get the Data From the Old Server
                if (Order_Old_New == "Old")
                {

                    Ordermanagement_01.Order_Entry_Old OrderEntryold = new Ordermanagement_01.Order_Entry_Old(int.Parse(grd_order.Rows[e.RowIndex].Cells[16].Value.ToString()), User_Id, userroleid);
                    OrderEntryold.Show();
                }

                else if(Order_Old_New=="New")
                {
                    Ordermanagement_01.Order_Entry OrderEntry = new Ordermanagement_01.Order_Entry(int.Parse(grd_order.Rows[e.RowIndex].Cells[16].Value.ToString()), User_Id, userroleid);
                    OrderEntry.Show();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Order_number.Text != "" && txt_Order_number.Text.Length>0)
            {
                //cPro.startProgress();
                form_loader.Start_progres();
                Hashtable htselect = new Hashtable();
                dtselect.Clear();
                string OrderNumber = txt_Order_number.Text.ToString();


                htselect.Add("@Trans", "SEARCH");
                htselect.Add("@Search_By", OrderNumber);
                dtnewselect = dataAccess.ExecuteSP("Sp_Order", htselect);
                dt = dtnewselect;

                // Check in Old Server 

                htselect.Clear();

                htselect.Add("@Trans", "SEARCH");
                htselect.Add("@Search_By", OrderNumber);
                dtoldselect = oldbdatacess.ExecuteSP("Sp_Order", htselect);

                if (dtoldselect.Rows.Count > 0)
                {

                    Old_Server_Value = "True";
                }
                else
                {
                    Old_Server_Value = "False";

                }

                dtselect = dtnewselect.Copy();
                dtselect.Merge(dtoldselect);


                if (dtselect.Rows.Count > 0)
                {
                    grd_order.Rows.Clear();
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        grd_order.Rows.Add();
                        grd_order.Rows[i].Cells[1].Value = dtselect.Rows[i]["Client_Order_Number"].ToString();
                        if (userroleid == "1")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Name"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Sub_ProcessName"].ToString();
                           
                           
                        }
                        else if (userroleid == "2")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Number"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Subprocess_Number"].ToString();
                           
                        }
                        
                        grd_order.Rows[i].Cells[4].Value = dtselect.Rows[i]["Date"].ToString();
                        grd_order.Rows[i].Cells[5].Value = dtselect.Rows[i]["Client_Order_Ref"].ToString();
                        grd_order.Rows[i].Cells[6].Value = dtselect.Rows[i]["Order_Type"].ToString();
                        grd_order.Rows[i].Cells[7].Value = dtselect.Rows[i]["Borrower_Name"].ToString();//BArrower Namr
                        grd_order.Rows[i].Cells[8].Value = dtselect.Rows[i]["Address"].ToString();
                        grd_order.Rows[i].Cells[9].Value = dtselect.Rows[i]["County"].ToString();
                        grd_order.Rows[i].Cells[10].Value = dtselect.Rows[i]["State"].ToString();
                        grd_order.Rows[i].Cells[11].Value = dtselect.Rows[i]["County_Type"].ToString();
                        grd_order.Rows[i].Cells[12].Value = dtselect.Rows[i]["Date"].ToString();//Process date Should be Completed or Recived date
                        grd_order.Rows[i].Cells[13].Value = dtselect.Rows[i]["Order_Status"].ToString();
                        grd_order.Rows[i].Cells[14].Value = dtselect.Rows[i]["Progress_Status"].ToString();
                        grd_order.Rows[i].Cells[15].Value = dtselect.Rows[i]["User_Name"].ToString();
                     
                        grd_order.Rows[i].Cells[16].Value = dtselect.Rows[i]["Order_ID"].ToString();

                        grd_order.Rows[i].Cells[17].Value = dtselect.Rows[i]["Order_old_New"].ToString();
                    }

                }
                else
                {
                    grd_order.Visible = true;
                    grd_order.Rows.Clear();
                    grd_order.DataSource = null;

                }

                //cPro.stopProgress();

            }
        }

        private void Order_Search_Load(object sender, EventArgs e)
        {
            if (userroleid == "2")
            {

                btn_Export.Visible = false;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (grd_order.Rows.Count > 0)
            {
                Export_ReportData();
            }
        }

        private void Export_ReportData()
        {



            System.Data.DataTable dt = new System.Data.DataTable();
           

            //Adding the Columns

            foreach (DataGridViewColumn column in grd_order.Columns)
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
            foreach (DataGridViewRow row in grd_order.Rows)
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
            string Export_Title_Name = "Search_ORrders";
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
    }
}
