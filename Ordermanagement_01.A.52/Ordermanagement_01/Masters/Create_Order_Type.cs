using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using ClosedXML.Excel;
using System.Data.OleDb;
using System.Diagnostics;


namespace Ordermanagement_01
{
    public partial class Create_Order_Type : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        DataTable dt = new System.Data.DataTable();
        DataTable dtnew = new DataTable();

        int userid = 0, Ordertype_id, ordertypeid, abbrid, insert = 0, order_insert,order_type_absid;
        string username;
        DataTable dtview = new DataTable();
        private Point pt, pt1, comp_pt, comp_pt1, add_pt, add_pt1, form_pt, form1_pt, order_lbl, order_lbl1, create_or, create_or1, del_or, del_or1, clear_btn, clear_btn1;
        public Create_Order_Type(int user_id,string Username)
        {
            InitializeComponent();
            userid = user_id;
            username = Username;
            
        }

        private void Create_Order_Type_Load(object sender, EventArgs e)
        {
            //btn_treeview.Left = Width - 50;
            txt_Order_Type.Select();
            dbc.Bind_SELECT_ORDER_TYPE_ABS(txt_Order_Type_Abbrivation);
            dbc.Bind_Billing_Product_Type(ddl_Billing_Order_type);
            pnlSideTree.Visible = true;
            txt_Order_No.Enabled = false;
            AddParent();
            lbl_RecordAddedBy.Text = "";
            lbl_RecordAddedOn.Text = "";
            genOrderType();
            BIND_ORDER_TYPE_ABS();
            Bind_grd_View_OrderType();
        }
       
        private void Bind_grd_View_OrderType()
        {
            Hashtable htview = new Hashtable();
            
            htview.Add("@Trans", "BIND_ORDER_TYPE_ABB");
            dtview.Rows.Clear();
            dtview = dataaccess.ExecuteSP("Sp_Order_Type", htview);
            if (dtview.Rows.Count > 0)
            {
                grd_Order_Type.Rows.Clear();
                for (int i = 0; i < dtview.Rows.Count; i++)
                {
                    grd_Order_Type.Rows.Add();
                    grd_Order_Type.Rows[i].Cells[0].Value = dtview.Rows[i]["Order_Type_ID"].ToString();
                    grd_Order_Type.Rows[i].Cells[1].Value = dtview.Rows[i]["Order_Type"].ToString();
                    grd_Order_Type.Rows[i].Cells[2].Value = dtview.Rows[i]["Order_Type_Abbreviation"].ToString();
                }
            }
        }


        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Hashtable hsforSP = new Hashtable();
            DataTable dt = new System.Data.DataTable();
            if (Chk_Status.Checked == true)
            {
                hsforSP.Add("@Trans", "SELECT");
                dt = dataaccess.ExecuteSP("Sp_Order_Type", hsforSP);
                hsforSP.Clear();
            }
            //if (Validation() != false)
            //{
                if (Ordertype_id == 0 && Validation() != false)
                {
                    //Insert
                    hsforSP.Add("@Trans", "INSERT");
                    hsforSP.Add("@Order_Type", txt_Order_Type.Text);
                    hsforSP.Add("@OrderType_ABS_Id", txt_Order_Type_Abbrivation.SelectedValue);
                    hsforSP.Add("@Order_Type_Abrivation", txt_Order_Type_Abbrivation.Text);
                    hsforSP.Add("@Status", Chk_Status.Checked);
                    hsforSP.Add("@Inserted_By", userid);
                    hsforSP.Add("@Inserted_Date", DateTime.Now);
                    if (ddl_Billing_Order_type.SelectedIndex > 0)
                    {

                        hsforSP.Add("@Billing_Order_Type_Id", int.Parse(ddl_Billing_Order_type.SelectedValue.ToString()));
                    }
                    dt = dataaccess.ExecuteSP("Sp_Order_Type", hsforSP);
                    string title = "Insert";
                    MessageBox.Show("Order Type Created Sucessfully",title);
                    clear();
                }
                else if (Ordertype_id != 0)
                {
                    //Update

                    hsforSP.Add("@Trans", "UPDATE");
                    hsforSP.Add("@Order_Type_ID", Ordertype_id);
                    hsforSP.Add("@Order_Type", txt_Order_Type.Text);
                    hsforSP.Add("@OrderType_ABS_Id", txt_Order_Type_Abbrivation.SelectedValue);
                    hsforSP.Add("@Order_Type_Abrivation", txt_Order_Type_Abbrivation.Text);
                    hsforSP.Add("@Status", Chk_Status.Checked);
                    hsforSP.Add("@Modified_By", userid);
                    hsforSP.Add("@Modified_Date", DateTime.Now);
                    if (ddl_Billing_Order_type.SelectedIndex > 0)
                    {

                        hsforSP.Add("@Billing_Order_Type_Id", int.Parse(ddl_Billing_Order_type.SelectedValue.ToString()));
                    }

                    dt = dataaccess.ExecuteSP("Sp_Order_Type", hsforSP);
                    string title = "Update";
                    MessageBox.Show("Order Type Updated Sucessfully",title);
                    clear();

                }
           // }
            AddParent();

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void clear()
        {
            lbl_OrderType.Text = "ORDER TYPE";
            pt.X = 390; pt.Y = 20;
            lbl_OrderType.Location=pt;
            btn_Save.Text = "Add Order Type";
            txt_Order_Type.Text = "";
            txt_Order_Type_Abbrivation.SelectedIndex = 0;
            Chk_Status.Checked = true;
            lbl_RecordAddedBy.Text = username;
            txt_Order_Type.BackColor = System.Drawing.Color.White;
            lbl_RecordAddedOn.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            Chk_Status.Checked = false;
            ddl_Billing_Order_type.SelectedIndex = 0;
            genOrderType();
            Ordertype_id = 0;
            txt_Order_No.Enabled = false;
            AddParent();
        }
        private void genOrderType()
        {
            Hashtable ht = new Hashtable();
            DataTable dt = new DataTable();
            dt.Clear();
            ht.Add("@Trans", "MAXORDERTYPENUMBER");
            dt = dataaccess.ExecuteSP("Sp_Order_Type", ht);
            txt_Order_No.Text = dt.Rows[0]["ORDERTYPENUMBER"].ToString();
        }
        private void txt_Branch_Code_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Branch_website_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Branchname_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_Order_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Order_Type.Focus();
            }
        }

        private void txt_Order_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Order_Type_Abbrivation.Focus();
            }
        }

        private void txt_Order_Type_Abbrivation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Chk_Status.Focus();
            }
        }

        private void Chk_Status_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save.Focus();
            }
        }

        private void tree_OrderType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            string Checked;
            //Ordertype_id = int.Parse(tree_OrderType.SelectedNode.Text.Substring(0, 4).ToString());
             bool isNum = Int32.TryParse(tree_OrderType.SelectedNode.Name, out Ordertype_id);
             if (isNum)
             {
                 lbl_OrderType.Text = "EDIT ORDER TYPE";
                 pt.X = 360; pt.Y = 20;
                 lbl_OrderType.Location = pt;
                 Hashtable hsforSP = new Hashtable();
                 DataTable dt = new DataTable();
                 hsforSP.Add("@Trans", "SELECT");
                 hsforSP.Add("@Order_Type_ID", Ordertype_id);
                 dt = dataaccess.ExecuteSP("Sp_Order_Type", hsforSP);
                 txt_Order_No.Text = dt.Rows[0]["Order_Type_ID"].ToString();
                 txt_Order_No.Enabled = false;
                 txt_Order_Type.Text = dt.Rows[0]["Order_Type"].ToString();

                 if (dt.Rows[0]["OrderType_ABS_Id"].ToString()!="" && dt.Rows[0]["OrderType_ABS_Id"].ToString()!=null)
                 {
                    txt_Order_Type_Abbrivation.SelectedValue = dt.Rows[0]["OrderType_ABS_Id"].ToString();
                 }
                 else{
                     txt_Order_Type_Abbrivation.SelectedValue = 0;
                 }
                 if (dt.Rows[0]["Billing_Order_Type_Id"].ToString() != "" && dt.Rows[0]["Billing_Order_Type_Id"].ToString()!=null)
                 {
                    ddl_Billing_Order_type.SelectedValue = dt.Rows[0]["Billing_Order_Type_Id"].ToString();
                 }
                 else
                 {
                    ddl_Billing_Order_type.SelectedValue =0;
                 }
                 string ChkStatus = dt.Rows[0]["Status"].ToString();
                 Checked = dt.Rows[0]["Default_Status"].ToString();
                 if (Checked == "True")
                 {
                     Chk_Status.Checked = true;
                 }
                 else if (Checked == "False")
                 {
                     Chk_Status.Checked = false;
                 }
                 if (dt.Rows[0]["Modifiedby"].ToString() != "")
                 {
                     lbl_RecordAddedBy.Text = dt.Rows[0]["Modifiedby"].ToString();
                     lbl_RecordAddedOn.Text = dt.Rows[0]["Modified_Date"].ToString();
                 }
                 else if (dt.Rows[0]["Modifiedby"].ToString() == "")
                 {
                     lbl_RecordAddedBy.Text = dt.Rows[0]["Insertedby"].ToString();
                     lbl_RecordAddedOn.Text = dt.Rows[0]["Instered_Date"].ToString();
                 }
                 if (Ordertype_id != 0)
                 {
                     btn_Save.Text = "Edit Order Type";
                 }
                 else
                 {
                     btn_Save.Text = "Add Order Type";
                 }
             }
        }

       
        private void AddParent()
        {
            string sKeyTemp = "";
            tree_OrderType.Nodes.Clear();
            Hashtable ht = new Hashtable();


            ht.Add("@Trans", "BIND");

            dt = dataaccess.ExecuteSP("Sp_Order_Type", ht);
            
            sKeyTemp = "Order Type";
            
            tree_OrderType.Nodes.Add(sKeyTemp, sKeyTemp);
            AddChilds(sKeyTemp);
        }
        private void AddChilds(string sKey)
        {
            Hashtable ht = new Hashtable();
            
            TreeNode parentnode;

            ht.Add("@Trans", "BIND");

            dt = dataaccess.ExecuteSP("Sp_Order_Type", ht);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tree_OrderType.Nodes[0].Nodes.Add(dt.Rows[i]["Order_Type_ID"].ToString() , dt.Rows[i]["Order_Type"].ToString());
            }
            tree_OrderType.ExpandAll();
        }
        private bool Validation()
        {
            string title = "Validation!";
            if (txt_Order_Type.Text == "")
            {
                MessageBox.Show("Enter Order Type Name", title);
                txt_Order_Type.Focus();
              //  txt_Order_Type.BackColor = System.Drawing.Color.Red;
                return false;
            }
            if (txt_Order_Type_Abbrivation.SelectedIndex<=0)
            {
                MessageBox.Show("Select Order Type Abbreviation", title);
                txt_Order_Type_Abbrivation.Focus();
                return false;
            }

            if (Chk_Status.Checked==false)
            {
                MessageBox.Show("Please Check Box Status Should Be Right Mark ", title);
                Chk_Status.Focus();
                return false;
            }

            Hashtable ht = new Hashtable();
            DataTable dt = new DataTable();
            ht.Add("@Trans", "ORDERTYPE");
            dt = dataaccess.ExecuteSP("[Sp_Order_Type]", ht);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (txt_Order_Type.Text == dt.Rows[i]["Order_Type"].ToString())
                {
                    string title1 = "Exist!";
                    MessageBox.Show("Order Type Name Already Exist", title1);
                    return false;
                    
                }

            }
            return true;
        }

     
        private void btn_Delete_Click(object sender, EventArgs e)
        { 
            DialogResult dialog = MessageBox.Show("Do you want to Delete Record", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (Ordertype_id != 0)
                {

                    Hashtable ht = new Hashtable();
                    ht.Add("@Trans", "DELETE");
                    ht.Add("@Order_Type_ID", Ordertype_id);
                    dt = dataaccess.ExecuteSP("Sp_Order_Type", ht);
                    MessageBox.Show("Record Deleted Successfully");
                    clear();
                    AddParent();
                }

                else
                {
                    string title1 = "Select!";
                    MessageBox.Show("Please Select Valid Order Type Name",title1);
                    tree_OrderType.Focus();
                }
            }
            clear();
          
        }

        private void txt_Ordertype_TextChanged(object sender, EventArgs e)
        {
            if (txt_Ordertype.Text != "Search Order type...")
            {
                string sKeyTemp = "";
                Hashtable ht = new Hashtable();
                DataTable dt = new System.Data.DataTable();

                ht.Add("@Trans", "BIND");

                dt = dataaccess.ExecuteSP("Sp_Order_Type", ht);

                DataView dtsearch = new DataView(dt);
                dtsearch.RowFilter = "Order_Type like '%" + txt_Ordertype.Text.ToString() + "%'";

                dtnew = dtsearch.ToTable();
                tree_OrderType.Nodes.Clear();
                if (dtnew.Rows.Count > 0)
                {
                    sKeyTemp = "Order Type";
                    tree_OrderType.Nodes.Add(sKeyTemp, sKeyTemp);
                    for (int i = 0; i < dtnew.Rows.Count; i++)
                    {
                        tree_OrderType.Nodes[0].Nodes.Add(dtnew.Rows[i]["Order_Type_ID"].ToString(), dtnew.Rows[i]["Order_Type"].ToString());
                    }
                }
                else
                {
                    AddParent();
                }
                tree_OrderType.ExpandAll();
            }
        }

        private void txt_Ordertype_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Ordertype.Text == "Search Order type...")
            {
                txt_Ordertype.Text = "";
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {

            form_loader.Start_progres();
            Grid_Export_Data();

        }
        private void Grid_Export_Data()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            //Adding gridview columns
            foreach (DataGridViewColumn column in grd_Order_Type.Columns)
            {
                if (column.Index != 0)
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
            }
            //Adding rows in Excel
            foreach (DataGridViewRow row in grd_Order_Type.Rows)
            {
                
                //foreach (DataGridViewCell cell in row.Cells)
                //{
                //    if (cell.ColumnIndex == 1)
                //    {
                //        dt.Rows[dt.Rows.Count - 1][1] = cell.Value.ToString();

                //    }
                //    if (cell.ColumnIndex == 2)
                //    {
                //        dt.Rows[dt.Rows.Count - 1][2] = cell.Value.ToString();
                //    }
                dt.Rows.Add();
                //}
                foreach (DataGridViewCell cell in row.Cells)
                {

                    if (cell.ColumnIndex != 0)
                    {
                       

                        if (cell.Value != null && cell.Value.ToString() != "")
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex - 1] = cell.Value.ToString();
                        }
                    }

                }

            }

            //Exporting to Excel
            string folderPath = "C:\\Temp\\";
            string Path1 = folderPath + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "-" + "Order_Type" + ".xlsx";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);


            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Order_Type");


                try
                {

                    wb.SaveAs(Path1);

                }
                catch (Exception ex)
                {
                    string title = "Alert!";
                    MessageBox.Show("File is Opened, Please Close and Export it",title);
                }



            }

            System.Diagnostics.Process.Start(Path1);
        }

        private void btn_SaveAll_Click(object sender, EventArgs e)
        {
            //form_loader.Start_progres();
            //Hashtable htnew = new Hashtable();
            //for (int i = 0; i < grd_Order_Type.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < grd_Order_Type.Columns.Count; j++)
            //    {

            //        Hashtable htorder = new Hashtable();
            //        DataTable dtorder = new DataTable();
            //        htorder.Add("@Trans", "SELECT");
            //        if (grd_Order_Type.Rows[i].Cells[0].Value != null )
            //        {
            //            htorder.Add("@Order_Type_ID", int.Parse(grd_Order_Type.Rows[i].Cells[0].Value.ToString()));
            //            dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
            //        }
            //        else
            //        {
            //            if (grd_Order_Type.Rows[i].Cells[1].Value.ToString() != "" && grd_Order_Type.Rows[i].Cells[2].Value.ToString() != "")
            //            {
            //                //insert new order type into db
            //                htnew.Add("@Trans", "INSERT");
            //                htnew.Add("@Order_Type", grd_Order_Type.Rows[i].Cells[1].Value.ToString());
            //                htnew.Add("@Order_Type_Abrivation", grd_Order_Type.Rows[i].Cells[2].Value.ToString());
            //                htnew.Add("@Status", "True");
            //                htnew.Add("@Inserted_By", userid);
            //                htnew.Add("@Inserted_Date", DateTime.Now);
            //                dt = dataaccess.ExecuteSP("Sp_Order_Type", htnew);

            //                MessageBox.Show("Order Type Created Sucessfully");
            //                break;
            //            }
            //        }

            //    }
            //}


        }

        private void txt_searchOrderType_TextChanged(object sender, EventArgs e)
        {
            if (txt_Ordertype.Text != "")
            {
                DataView dtsearch = new DataView(dtview);
                dtsearch.RowFilter = "Order_Type like '%" + txt_searchOrderType.Text.ToString() + "%' or  Order_Type_Abbreviation like '%" + txt_searchOrderType.Text.ToString() + "%'";

                DataTable dtorder_search = new DataTable();
                dtorder_search = dtsearch.ToTable();
                
                if (dtorder_search.Rows.Count > 0)
                {
                    grd_Order_Type.Rows.Clear();
                    for (int i = 0; i < dtorder_search.Rows.Count; i++)
                    {
                        grd_Order_Type.Rows.Add();
                        grd_Order_Type.Rows[i].Cells[0].Value = dtorder_search.Rows[i]["Order_Type_ID"].ToString();
                        grd_Order_Type.Rows[i].Cells[1].Value = dtorder_search.Rows[i]["Order_Type"].ToString();
                        grd_Order_Type.Rows[i].Cells[2].Value = dtorder_search.Rows[i]["Order_Type_Abbreviation"].ToString();
                    }
                }
               
            }
        }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            grd_Order_Type.Rows.Clear();
            OpenFileDialog fdlg = new OpenFileDialog();

            fdlg.Title = "Select Excel file";
            fdlg.InitialDirectory = @"c:\";
            var txtFileName = fdlg.FileName;
            fdlg.Filter = "Excel Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName = fdlg.FileName;
                Import(txtFileName);
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void Import(string fileName)
        {
            if (fileName != string.Empty)
            {
                try
                {
                    String name = "Order_Type";    // default Sheet1 
                    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                               fileName +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                    OleDbConnection con = new OleDbConnection(constr);
                    OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                    con.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                    System.Data.DataTable data = new System.Data.DataTable();
                    int value = 0; int newrow = 0;
                    sda.Fill(data);

                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        string ordertype = data.Rows[i]["Order Type"].ToString();
                        string abbr = data.Rows[i]["Order Type ABR"].ToString();
                        if (data.Rows[i]["Order Type"].ToString() != "" && data.Rows[i]["Order Type ABR"].ToString() != "")
                        {
                            grd_Order_Type.Rows.Add();
                            grd_Order_Type.Rows[i].Cells[1].Value = data.Rows[i]["Order Type"].ToString();
                            grd_Order_Type.Rows[i].Cells[2].Value = data.Rows[i]["Order Type ABR"].ToString();

                            grd_Order_Type.Rows[i].DefaultCellStyle.BackColor = Color.White;

                            //error order type
                            Hashtable htorder = new Hashtable();
                            DataTable dtorder = new DataTable();
                            htorder.Add("@Trans", "SEARCH_ORDER_TYPE");
                            htorder.Add("@Order_Type", data.Rows[i]["Order Type"].ToString());
                            dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                            if (dtorder.Rows.Count > 0)
                            {
                                ordertypeid = int.Parse(dtorder.Rows[0]["Order_Type_ID"].ToString());
                                //grd_Order_Type.Rows[i].Cells[1].Style.BackColor = Color.Red;
                            }
                            else
                            {
                                
                            }

                            //error order type abbreivation
                            htorder.Clear(); dtorder.Clear();
                            htorder.Add("@Trans", "SEARCH_ORDER_TYPE_ABBR");
                            htorder.Add("Order_Type_Abrivation", data.Rows[i]["Order Type ABR"].ToString());
                            dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                            if (dtorder.Rows.Count > 0)
                            {
                                abbrid = int.Parse(dtorder.Rows[0]["Order_Type_ID"].ToString());
                                
                            }
                            else
                            {
                                
                            }

                            //duplicate data
                            for (int j = 0; j < i; j++)
                            {
                                string ordertype1 = data.Rows[j]["Order Type"].ToString();
                                string abbr1 = data.Rows[j]["Order Type ABR"].ToString();
                                if (ordertype == ordertype1 )
                                {
                                    value = 1;
                                    grd_Order_Type.Rows[j].DefaultCellStyle.BackColor = Color.Red;
                                    break;
                                }
                                else
                                {
                                    value = 0;
                                }
                            }

                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }



        private void btn_removedup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_Order_Type.Rows.Count-1; i++)
            {
                if (grd_Order_Type.Rows[i].DefaultCellStyle.BackColor == Color.Red)
                {
                    grd_Order_Type.Rows.RemoveAt(i);

                }
            }
            //for (int i = 0; i < grd_Order_Type.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < grd_Order_Type.Columns.Count; j++)
            //    {

            //        if (grd_Order_Type.Rows[i].Cells[j].Style.BackColor == Color.Red)
            //        {
            //            grd_Order_Type.Rows.RemoveAt(i);
            //        }


            //    }

            //}
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_Order_Type.Rows.Count-1; i++)
            {
                //error order type
                Hashtable htorder = new Hashtable();
                DataTable dtorder = new DataTable();
                htorder.Add("@Trans", "SEARCH_ORDER_TYPE");
                htorder.Add("@Order_Type", grd_Order_Type.Rows[i].Cells[1].Value.ToString());
                dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                if (dtorder.Rows.Count > 0)
                {
                    ordertypeid = int.Parse(dtorder.Rows[0]["Order_Type_ID"].ToString());
                }
                else
                {
                    order_insert = 1;
                }

                ////error order type abbreivation
                //htorder.Clear(); dtorder.Clear();
                //htorder.Add("@Trans", "SEARCH_ORDER_TYPE_ABBR");
                //htorder.Add("Order_Type_Abrivation", grd_Order_Type.Rows[i].Cells[2].Value.ToString());
                //dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                //if (dtorder.Rows.Count > 0)
                //{
                //    abbrid = int.Parse(dtorder.Rows[0]["Order_Type_ID"].ToString());
                //}


                if (order_insert == 1)
                {
                    //htorder.Clear(); dtorder.Clear();
                    //htorder.Add("@Trans", "CHECK");
                    //htorder.Add("@Order_Type", grd_Order_Type.Rows[i].Cells[1].Value.ToString());
                    //htorder.Add("@Order_Type_Abrivation", grd_Order_Type.Rows[i].Cells[2].Value.ToString());
                    //dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                    //if (dtorder.Rows.Count > 0)
                    //{

                    //}
                    //else
                    //{
                    //Insert operation
                    htorder.Clear(); htorder.Clear();
                    htorder.Add("@Trans", "INSERT");
                    htorder.Add("@Order_Type", grd_Order_Type.Rows[i].Cells[1].Value.ToString());
                    htorder.Add("@Order_Type_Abrivation", grd_Order_Type.Rows[i].Cells[2].Value.ToString());
                    htorder.Add("@Status", "True");
                    htorder.Add("@Inserted_By", userid);
                    dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                    insert = 0;
                    order_insert = 0;
                }
                else
                {
                    //Insert operation
                    htorder.Clear(); htorder.Clear();
                    htorder.Add("@Trans", "UPDATE");
                    htorder.Add("@Order_Type_ID", dtorder.Rows[0]["Order_Type_ID"].ToString());
                    htorder.Add("@Order_Type", grd_Order_Type.Rows[i].Cells[1].Value.ToString());
                    htorder.Add("@Order_Type_Abrivation", grd_Order_Type.Rows[i].Cells[2].Value.ToString());
                    htorder.Add("@Status", "True");
                    htorder.Add("@Inserted_By", userid);
                    dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                    insert = 1;

                }
                    


            }
            if (insert == 1)
            {
                string title = "Exist!";
                MessageBox.Show("Order type already exists in Db",title);

                insert = 0;
            }
            if(order_insert == 1)
            {
                string title = "Update";
                MessageBox.Show("Order type Records updated successfully",title);
                order_insert = 0;
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            grd_Order_Type.Rows.Clear();
            txt_searchOrderType.Text = "";
            txt_searchOrderType.Select();
            Bind_grd_View_OrderType();
        }

        private void txt_OrderTypeAbs_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_abr_Click(object sender, EventArgs e)
        {
            if (txt_OrderTypeAbs.Text != "" )
            {
                if (order_type_absid == 0 && btn_Add_abr.Text!="Edit")
                {
                    //insert
                    Hashtable htin = new Hashtable();
                    DataTable dtin = new DataTable();
                    htin.Add("@Trans", "INSERT_ORDERTYPEABS");
                    htin.Add("@Order_Type_Abbreviation", txt_OrderTypeAbs.Text);
                    htin.Add("@Inserted_By", userid);
                    dtin = dataaccess.ExecuteSP("Sp_Order_Type", htin);
                    string title = "Insert";
                    MessageBox.Show("Order Type Abbreivation Added successfully",title);
                    txt_OrderTypeAbs.Select();
                    txt_OrderTypeAbs.Text = "";
                }
                else if (order_type_absid != 0)
                {
                   
                    //update
                    Hashtable htup = new Hashtable();
                    DataTable dtup = new DataTable();
                    htup.Add("@Trans", "UPDATE_ORDERTYPEABS");
                    htup.Add("@OrderType_ABS_Id", order_type_absid);
                    htup.Add("@Order_Type_Abbreviation", txt_OrderTypeAbs.Text);
                    htup.Add("@Modified_By", userid);
                    dtup = dataaccess.ExecuteSP("Sp_Order_Type", htup);

                    string title = "Update";
                    MessageBox.Show("Order Type Abbreivation Updated successfully",title);
                    btn_Add_abr.Text = "Add";
                    txt_OrderTypeAbs.Text = "";
                    txt_OrderTypeAbs.Select();
                }
                BIND_ORDER_TYPE_ABS();
            }
            else
            {
                string title = "Select!";
                MessageBox.Show("Kindly Enter Order Type Abbreivation",title);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_OrderTypeAbs.Text = "";
            txt_OrderTypeAbs.Select();
            BIND_ORDER_TYPE_ABS();
            btn_Add_abr.Text = "Add";
        }
        private void BIND_ORDER_TYPE_ABS()
        {
            Hashtable htselect = new Hashtable();
            DataTable dtselect = new DataTable();
            htselect.Add("@Trans", "SELECT_ORDER_ABS");
            dtselect = dataaccess.ExecuteSP("Sp_Order_Type", htselect);
            if (dtselect.Rows.Count > 0)
            {
                grd_OrderTypeABS.Rows.Clear();
                for (int i = 0; i < dtselect.Rows.Count; i++)
                {
                    grd_OrderTypeABS.Rows.Add();
                    grd_OrderTypeABS.Rows[i].Cells[0].Value = dtselect.Rows[i]["OrderType_ABS_Id"].ToString();
                    grd_OrderTypeABS.Rows[i].Cells[1].Value = dtselect.Rows[i]["Order_Type_Abbreviation"].ToString();
                    grd_OrderTypeABS.Rows[i].Cells[2].Value = "View/Edit";
                    grd_OrderTypeABS.Rows[i].Cells[3].Value = "Delete";
                }
            }
       
        }
        private void grd_OrderTypeABS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grd_OrderTypeABS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {//view updation
                if (grd_OrderTypeABS.Rows[e.RowIndex].Cells[0].Value.ToString() != null && grd_OrderTypeABS.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
                {
                    order_type_absid = int.Parse(grd_OrderTypeABS.Rows[e.RowIndex].Cells[0].Value.ToString());
                    Hashtable htsel = new Hashtable();
                    DataTable dtsel = new DataTable();
                    htsel.Add("@Trans", "SELECT_ORDER_ABS_ID");
                    htsel.Add("@OrderType_ABS_Id", order_type_absid);
                    dtsel = dataaccess.ExecuteSP("Sp_Order_Type", htsel);
                    if (dtsel.Rows.Count > 0)
                    {
                        txt_OrderTypeAbs.Text = dtsel.Rows[0]["Order_Type_Abbreviation"].ToString();
                    }
                }
                btn_Add_abr.Text = "Edit";
                txt_OrderTypeAbs.Select();
            }
            else if (e.ColumnIndex == 3)
            {//delete
                DialogResult dialog = MessageBox.Show("Do you want to Delete Record", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    if (grd_OrderTypeABS.Rows[e.RowIndex].Cells[0].Value.ToString() != null && grd_OrderTypeABS.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
                    {
                        order_type_absid = int.Parse(grd_OrderTypeABS.Rows[e.RowIndex].Cells[0].Value.ToString());
                        Hashtable htdel = new Hashtable();
                        DataTable dtdel = new DataTable();
                        htdel.Add("@Trans", "DELETE_ORDER_ABS_ID");
                        htdel.Add("@OrderType_ABS_Id", order_type_absid);
                        dtdel = dataaccess.ExecuteSP("Sp_Order_Type", htdel);
                        BIND_ORDER_TYPE_ABS();
                        MessageBox.Show("Order Type Abbreviation deleted successfully");
                    }
                }
                
            }

        }

        private void txt_Ordertype_MouseEnter_1(object sender, EventArgs e)
        {
            if (txt_Ordertype.Text == "Search Order type...")
            {
                txt_Ordertype.Text = "";
            }
        }

        private void btn_Sample_Format_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"C:\OMS_Import\");
            string temppath = @"c:\OMS_Import\Order_Type.xlsx";
            if (!Directory.Exists(temppath))
            {
                File.Copy(@"\\192.168.12.33\OMS-Import_Excels\Order_Type.xlsx", temppath, true);
                Process.Start(temppath);
            }
            else
            {
                Process.Start(temppath);
            }
        }

        private void txt_Order_Type_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != (char)Keys.Back && !(char.IsWhiteSpace(e.KeyChar)))
            //{
            //    e.Handled = true;
            //}
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                txt_Order_Type.Select();
                txt_OrderTypeAbs.Text = "";
                txt_searchOrderType.Text = "";
            }

            if (tabControl1.SelectedIndex == 1)
            {

                txt_searchOrderType.Select();
                Bind_grd_View_OrderType();
                txt_Order_Type.Text = "";

                txt_Order_Type_Abbrivation.SelectedIndex = 0;
                ddl_Billing_Order_type.SelectedIndex = 0;
                Chk_Status.Checked = false;

                txt_OrderTypeAbs.Text = "";
            }
            if (tabControl1.SelectedIndex == 2)
            {
                txt_OrderTypeAbs.Select();
                BIND_ORDER_TYPE_ABS();

                txt_searchOrderType.Text = "";
                txt_Order_Type.Text = "";
                txt_Order_Type_Abbrivation.SelectedIndex = 0;
                ddl_Billing_Order_type.SelectedIndex = 0;
                Chk_Status.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Order_Type.Select();
            txt_OrderTypeAbs.Select();
          //  grd_OrderTypeABS.Rows.Clear();
            txt_searchOrderType.Text = "";
            txt_searchOrderType.Select();
            txt_OrderTypeAbs.Text = "";
            txt_OrderTypeAbs.Select();
            clear();
            BIND_ORDER_TYPE_ABS();
        }

      
       
    }
}
