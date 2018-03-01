using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace Ordermanagement_01.Tax
{
    public partial class Tax_Employee_Order_View : Form
    {
        string User_Id, User_Role,Order_Process;
        string Operation;
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        DataTable dtuser = new System.Data.DataTable();
        DataTable dtpend = new System.Data.DataTable();

        DataTable dt = new System.Data.DataTable();
        public Tax_Employee_Order_View(string USER_ID,string USER_ROLE,string ORDER_PROCESS)
        {
            InitializeComponent();
            User_Id = USER_ID;
            User_Role = USER_ROLE;
            Order_Process = ORDER_PROCESS;

            if (Order_Process == "Internal_Tax_Request")
            {

                lbl_Header.Text = "INTERNAL TAX SEARCH ORDERS PROCESSING";

            }
            else if (Order_Process == "External_Tax_Request")
            {
                lbl_Header.Text = "EXTERNAL TAX SEARCH ORDERS PROCESSING";
              
            }
            else if (Order_Process == "Internal_Tax_Request_Qc")
            {
                lbl_Header.Text = "INTERNAL TAX SEARCH QC ORDERS PROCESSING";
                
            }
            else if (Order_Process == "External_Tax_Request_Qc")
            {
                lbl_Header.Text = "EXTERNAL TAX REQUEST QC ORDERS PROCESSING";
                

            }

            this.Text = lbl_Header.Text;

            if (User_Role == "1")
            {
                Btn_Allorders.Visible = true;
            

            }
            else if (User_Role == "2")
            {

                Btn_Allorders.Visible = false;
            
            }
        }

        private void btn_My_Orders_Click(object sender, EventArgs e)
        {
            Operation = "My_Orders";
            lbl_Order.Text = "MY  ORDERS:";
            grd_Admin_orders.EnableHeadersVisualStyles = false;
            Gridview_Bind_Assigned_Orders();
         


        }
          
        private void Btn_Allorders_Click(object sender, EventArgs e)
        {
            Operation = "All_Orders";
            lbl_Order.Text = "ALL  ASSIGNED  ORDER:";
            Gridview_Bind_Assigned_Orders();
           
        }

        private void Tax_Employee_Order_View_Load(object sender, EventArgs e)
        {
            btn_My_Orders_Click( sender,  e);
            this.WindowState = FormWindowState.Maximized;
        }

        protected void Gridview_Bind_Assigned_Orders()
        {
            Hashtable htuser = new Hashtable();

            if (Operation == "My_Orders")
            {

                if (Order_Process == "Internal_Tax_Request")
                {
                    htuser.Add("@Trans", "INTERNAL_TAX_REQUEST_USERS_ORDERS_VIEW");

                }
                else if (Order_Process == "External_Tax_Request")

                {

                    htuser.Add("@Trans", "EXTERNAL_TAX_REQUEST_USERS_ORDERS_VIEW");
                }
                else if (Order_Process == "Internal_Tax_Request_Qc")
                {

                    htuser.Add("@Trans", "INTERNAL_TAX_REQUEST_QC_USERS_ORDERS_VIEW");
                }
                else if (Order_Process == "External_Tax_Request_Qc")
                {
                    htuser.Add("@Trans", "EXTERNAL_TAX_REQUEST_QC_USERS_ORDERS_VIEW");

                }
            }
            else if (Operation == "All_Orders")
            {

                if (Order_Process == "Internal_Tax_Request")
                {
                    htuser.Add("@Trans", "INTERNAL_TAX_TAX_REQUEST_ADMIN_ORDERS_VIEW");
                

                }

                else if (Order_Process == "External_Tax_Request")
                {

                    htuser.Add("@Trans", "EXTERNAL_TAX_REQUEST_ADMIN_ORDERS_VIEW");
                }

                else if (Order_Process == "Internal_Tax_Request_Qc")
                {

                    htuser.Add("@Trans", "INTERNAL_TAX_REQUEST_QC_ADMIN_ORDERS_VIEW");
                }
                else if (Order_Process == "External_Tax_Request_Qc")
                {
                    htuser.Add("@Trans", "EXTERNAL_TAX_REQUEST_QC_ADMIN_ORDERS_VIEW");

                }
            }



            htuser.Add("@User_Id", User_Id);


            dtuser = dataaccess.ExecuteSP("Sp_Tax_Orders", htuser);
        
                grd_Admin_orders.Columns[0].Width = 50;
                grd_Admin_orders.Columns[1].Width = 150;
                grd_Admin_orders.Columns[2].Width = 120;
                grd_Admin_orders.Columns[3].Width = 120;
                grd_Admin_orders.Columns[4].Width = 250;
                grd_Admin_orders.Columns[5].Width = 195;
                grd_Admin_orders.Columns[6].Width = 180;
                grd_Admin_orders.Columns[7].Width = 150;
                grd_Admin_orders.Columns[8].Width = 170;
                grd_Admin_orders.Columns[9].Width = 170;
                grd_Admin_orders.Columns[10].Width = 120;
                grd_Admin_orders.Columns[11].Width = 120;
             
                grd_Admin_orders.Rows.Clear();
            if (dtuser.Rows.Count > 0)
            {
             
             

                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    grd_Admin_orders.Rows.Add();
                    grd_Admin_orders.Rows[i].Cells[0].Value = i + 1;
                    grd_Admin_orders.Rows[i].Cells[1].Value =  dtuser.Rows[i]["Client_Order_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[3].Value = dtuser.Rows[i]["Subprocess_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[4].Value =  dtuser.Rows[i]["Order_Type"].ToString();
                    grd_Admin_orders.Rows[i].Cells[5].Value =  dtuser.Rows[i]["State"].ToString();
                    grd_Admin_orders.Rows[i].Cells[6].Value =  dtuser.Rows[i]["County"].ToString();
                    grd_Admin_orders.Rows[i].Cells[7].Value =  dtuser.Rows[i]["User_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[8].Value =  dtuser.Rows[i]["Assigned_Date"].ToString();
                    grd_Admin_orders.Rows[i].Cells[9].Value =  dtuser.Rows[i]["Tax_Status"].ToString();
                    grd_Admin_orders.Rows[i].Cells[10].Value =  dtuser.Rows[i]["Order_ID"].ToString();
                    grd_Admin_orders.Rows[i].Cells[11].Value =  dtuser.Rows[i]["Order_Task"].ToString();
                    grd_Admin_orders.Rows[i].Cells[12].Value = dtuser.Rows[i]["Tax_Task_Id"].ToString();
                    grd_Admin_orders.Rows[i].Cells[13].Value = dtuser.Rows[i]["Tax_Status_Id"].ToString();
                    grd_Admin_orders.Rows[i].Cells[13].Value = dtuser.Rows[i]["Tax_Status_Id"].ToString();
                    grd_Admin_orders.Rows[i].Cells[14].Value = dtuser.Rows[i]["Followup_Date"].ToString();
                
               
               

             
                }
            }
            else
            {
                grd_Admin_orders.DataSource = null;
                grd_Admin_orders.Rows.Clear();
                //grd_Assigned_Orders.EmptyDataText = "No Orders Are Avilable";
                //grd_Assigned_Orders.DataBind();
            }
        }

        private void grd_Admin_orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {


                if (e.ColumnIndex == 1 && Operation == "My_Orders")
                {

                    string Order_Id = grd_Admin_orders.Rows[e.RowIndex].Cells[10].Value.ToString();
                    string Order_Task_Id =grd_Admin_orders.Rows[e.RowIndex].Cells[11].Value.ToString();
                    string Tax_TAsk_Id =grd_Admin_orders.Rows[e.RowIndex].Cells[12].Value.ToString();
                    string Tax_Status=grd_Admin_orders.Rows[e.RowIndex].Cells[13].Value.ToString();
                    string Order_Number = grd_Admin_orders.Rows[e.RowIndex].Cells[1].Value.ToString();


                    Tax_Order_Processing txpr = new Tax_Order_Processing(Order_Id, Order_Task_Id, Tax_TAsk_Id, Tax_Status, User_Id, Order_Number,User_Role);
                    txpr.Show();
                    this.Close();

                }
                else if (e.ColumnIndex == 1 && Operation == "All_Orders")
                {
                    string Order_Id = grd_Admin_orders.Rows[e.RowIndex].Cells[10].Value.ToString();
                    string Order_Task_Id = grd_Admin_orders.Rows[e.RowIndex].Cells[11].Value.ToString();
                    string Tax_TAsk_Id = grd_Admin_orders.Rows[e.RowIndex].Cells[12].Value.ToString();
                    string Tax_Status = grd_Admin_orders.Rows[e.RowIndex].Cells[13].Value.ToString();
                    string Order_Number = grd_Admin_orders.Rows[e.RowIndex].Cells[1].Value.ToString();

                    Tax_Order_View txview = new Tax_Order_View(Order_Id, User_Id, Order_Number, User_Role);
                    txview.Show();
                }
            }

        }

        private void txt_SearchOrdernumber_TextChanged(object sender, EventArgs e)
        {
            if (txt_SearchOrdernumber.Text != "")
            {
                Bind_Filter_Data();
            }
            else
            {
                Gridview_Bind_Assigned_Orders();

            }
        }

        private void Bind_Filter_Data()
        {
            DataView dtsearch = new DataView(dtuser);
            dtsearch.RowFilter = "Client_Order_Number like '%" + txt_SearchOrdernumber.Text.ToString().ToString() + "%' ";
            dt = dtsearch.ToTable();

       



            if (dt.Rows.Count > 0)
            {
                grd_Admin_orders.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grd_Admin_orders.Rows.Add();
                    grd_Admin_orders.Rows[i].Cells[0].Value = i + 1;
                    grd_Admin_orders.Rows[i].Cells[1].Value = dt.Rows[i]["Client_Order_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[2].Value = dt.Rows[i]["Client_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[3].Value = dt.Rows[i]["Subprocess_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[4].Value = dt.Rows[i]["Order_Type"].ToString();
                    grd_Admin_orders.Rows[i].Cells[5].Value = dt.Rows[i]["State"].ToString();
                    grd_Admin_orders.Rows[i].Cells[6].Value = dt.Rows[i]["County"].ToString();
                    grd_Admin_orders.Rows[i].Cells[7].Value = dt.Rows[i]["User_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[8].Value = dt.Rows[i]["Assigned_Date"].ToString();
                    grd_Admin_orders.Rows[i].Cells[9].Value = dt.Rows[i]["Tax_Status"].ToString();
                    grd_Admin_orders.Rows[i].Cells[10].Value = dt.Rows[i]["Order_ID"].ToString();
                    grd_Admin_orders.Rows[i].Cells[11].Value = dt.Rows[i]["Order_Task"].ToString();
                    grd_Admin_orders.Rows[i].Cells[12].Value = dt.Rows[i]["Tax_Task_Id"].ToString();
                    grd_Admin_orders.Rows[i].Cells[13].Value = dt.Rows[i]["Tax_Status_Id"].ToString();
                    grd_Admin_orders.Rows[i].Cells[14].Value = dtuser.Rows[i]["Followup_Date"].ToString();
                

                }
            }
            else
            {
                grd_Admin_orders.Rows.Clear();
                grd_Admin_orders.Visible = true;
                grd_Admin_orders.DataSource = null;
            }
         
        


        }

        private void txt_SearchOrdernumber_MouseEnter(object sender, EventArgs e)
        {
            if (txt_SearchOrdernumber.Text == "Search by order number...")
            {
                txt_SearchOrdernumber.Text = "";
                txt_SearchOrdernumber.ForeColor = Color.Black;
            }
        }

        private void btn_My_Orders_Click_1(object sender, EventArgs e)
        {

        }

        private void Btn_Allorders_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
