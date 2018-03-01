using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Threading;

namespace Ordermanagement_01
{
    public partial class Employee_View : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        DataTable dtuser = new System.Data.DataTable();
        DataTable dtpend = new System.Data.DataTable();
        int Order_Status = 0;
        string Order_Process = "";
        int userid = 0;
        string User_Role_Id = "";
        string OrderNo;
        string Operation;
        string Work_Type;
        int Work_Type_Id;
        int MAX_TIME_ID;
        int Order_Id, Message_Count, orderType_ABS_id;
        int Tax_Completed;
        int Entered_Count, Entered_Count_1, Entered_Count_2, Entered_Count_3, Entered_Count_4, Entered_Count_5, Entered_Count_6,ClientQenrty_Count, orderid = 0;
        public Employee_View(int OrderStatus, string OrderProcess, int user_id, string Role_Id, string WORK_TYPE, int WORK_TYPE_ID)
        {
            InitializeComponent();
            Order_Status = OrderStatus;
            Order_Process = OrderProcess;
            userid = user_id;
            User_Role_Id = Role_Id;
            Work_Type = WORK_TYPE;
            Work_Type_Id = WORK_TYPE_ID;

            btn_Send_Tax_Request.Visible = false;
            btn_Cancel_Tax_Request.Visible = false;

            if (Work_Type_Id == 1 )
            {
                btn_Send_Tax_Request.Visible = true;
                btn_Cancel_Tax_Request.Visible = true;
                if (OrderStatus == 2)
                {

                    lbl_Header.Text = "SEARCH PROCESSING ORDERS";

                  

                }
                else if (OrderStatus == 3)
                {

                    lbl_Header.Text = "SEARCH QC PROCESSING ORDERS";
                }
                else if (OrderStatus == 4)
                {

                    lbl_Header.Text = "TYPING PROCESSING ORDERS";
                }
                else if (OrderStatus == 7)
                {

                    lbl_Header.Text = "TYPING QC PROCESSING ORDERS";
                }
                else if (OrderStatus == 12)
                {

                    lbl_Header.Text = "UPLOAD PROCESSING ORDERS";
                }
                else if (OrderStatus == 22)
                {

                    lbl_Header.Text = "TAX PROCESSING ORDERS";
                }
                else if (OrderStatus == 23)
                {

                    lbl_Header.Text = "FINAL QC PROCESSING ORDERS";
                }
                else if (OrderStatus == 24)
                {

                    lbl_Header.Text = "EXCEPTION PROCESSING ORDERS";
                }
            }
            else if (Work_Type_Id == 2)
            {
                if (OrderStatus == 2)
                {

                    lbl_Header.Text = "REWORK-SEARCH PROCESSING ORDERS";


                }
                else if (OrderStatus == 3)
                {

                    lbl_Header.Text = "REWORK-SEARCH QC PROCESSING ORDERS";
                }
                else if (OrderStatus == 4)
                {

                    lbl_Header.Text = "REWORK-TYPING PROCESSING ORDERS";
                }
                else if (OrderStatus == 7)
                {

                    lbl_Header.Text = "REWORK-TYPING QC PROCESSING ORDERS";
                }
                else if (OrderStatus == 12)
                {

                    lbl_Header.Text = "REWORK-UPLOAD PROCESSING ORDERS";
                }
            

            }
            else if (Work_Type_Id == 3)
            {
               
                 if (OrderStatus == 3)
                {

                    lbl_Header.Text = "SEARCH SUPER QC PROCESSING ORDERS";
                }
               
                else if (OrderStatus == 7)
                {

                    lbl_Header.Text = "TYPING SUPER QC PROCESSING ORDERS";
                }
               


            }
          

            Gridview_Bind_Assigned_Orders();
            Gridview_Bind_Pending_Orders();
            if (User_Role_Id == "2")
            {
                Btn_Allorders.Visible = false;
            }
            else if (User_Role_Id == "1")
            {
                Btn_Allorders.Visible = true;
            }
            this.Text = lbl_Header.Text;
      
            }
        
        private void Employee_View_Load(object sender, EventArgs e)
        {
             btn_My_Orders_Click( sender,  e);
             label1.Text = "MY  ORDERS:";
             //Color toolover = System.Drawing.ColorTranslator.FromHtml("#6E828E");
             grd_Admin_orders.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
             grd_Admin_orders.EnableHeadersVisualStyles = false;
             grd_Admin_orders.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
             grd_Pending_Orders.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
             grd_Pending_Orders.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
             grd_Pending_Orders.EnableHeadersVisualStyles = false;
             this.WindowState = FormWindowState.Maximized;
        }

        private void Btn_Allorders_Click(object sender, EventArgs e)
        {


                Operation = "All_Orders";
                label1.Text = "ALL  ASSIGNED  ORDER:";
                Gridview_Bind_Admin_Orders();
                grd_Pending_Orders.Rows.Clear();
        }
        protected void Gridview_Bind_Admin_Orders()
        {
            Hashtable htuser = new Hashtable();
            
            if (Work_Type == "Live")
            {
                if (Order_Process == "Abstract_ORDERS_ALLOCATE")
                {
                    htuser.Add("@Trans", "USER_ABSTRACTOR_ORDERS_ADMIN");
                }
                else if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                {

                    htuser.Add("@Trans", "RUS_OVER_DUE_ASSIGNED_ORDER_ADMIN");
                }
                else if (Order_Process == "TAX")
                {
                    htuser.Add("@Trans", "USER_INTERNAL_TAX_ASSIGNED_ORDER_ADMIN");
                    
                }
                else
                {
                    htuser.Add("@Trans", "USER_ASSIGNED_ORDER_ADMIN");
                }

            }
            else if (Work_Type == "Rework")
            {


                htuser.Add("@Trans", "REWORK_USER_ASSIGNED_ORDER_ADMIN");


            }
            else if (Work_Type == "SuperQc")

            {

                if (Order_Status == 3)
                {
                    htuser.Add("@Trans", "SUPER_QC_SEARCH_QC_ORDER_FOR_ADMIN");

                }
                else if (Order_Status == 7)
                {
                    htuser.Add("@Trans", "SUPER_QC_TYPING_QC_ORDER_FOR_ADMIN");


                }

            }

            htuser.Add("@User_Id", userid);
            htuser.Add("@Order_Status", Order_Status);

            if (Work_Type == "Live")
            {
                dtuser = dataaccess.ExecuteSP("Sp_Order_Count", htuser);
            }
            else if (Work_Type == "Rework")
            {
                dtuser = dataaccess.ExecuteSP("Sp_Order_Rework_Count", htuser);

            }
            else if (Work_Type == "SuperQc")
            {
                dtuser = dataaccess.ExecuteSP("Sp_Order_SuperQc_Count", htuser);

            }

            grd_Admin_orders.Columns[0].Width = 50;
         
            grd_Admin_orders.Columns[1].Width = 125;
            grd_Admin_orders.Columns[2].Width = 250;
            grd_Admin_orders.Columns[3].Width = 195;
            grd_Admin_orders.Columns[4].Width = 180;
            grd_Admin_orders.Columns[5].Width = 100;
            grd_Admin_orders.Columns[6].Width = 110;
            grd_Admin_orders.Columns[7].Width = 100;
            grd_Admin_orders.Columns[8].Width = 150;
            grd_Admin_orders.Columns[9].Width = 150;
            if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
            {

                grd_Admin_orders.Columns[9].Visible = true;
                grd_Admin_orders.Columns[10].Visible = true;

            }
            else
            {
                grd_Admin_orders.Columns[9].Visible = false;
                grd_Admin_orders.Columns[10].Visible = false;
            }
            if (dtuser.Rows.Count > 0)
            {
                //ex2.Visible = true;
                if (Order_Process == "Abstract_ORDERS_ALLOCATE")
                {
                    grd_Admin_orders.Visible = false;
                }
                else
                {
                    grd_Admin_orders.Visible = true;
                }
                grd_Admin_orders.Rows.Clear();

                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    grd_Admin_orders.Rows.Add();
                    grd_Admin_orders.Rows[i].Cells[1].Value = i + 1;
                    grd_Admin_orders.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[3].Value = dtuser.Rows[i]["Subprocess_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[4].Value = dtuser.Rows[i]["Client_Order_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[5].Value = dtuser.Rows[i]["Order_Type"].ToString();
                    grd_Admin_orders.Rows[i].Cells[6].Value = dtuser.Rows[i]["User_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[7].Value = dtuser.Rows[i]["Date"].ToString();
                    grd_Admin_orders.Rows[i].Cells[8].Value = dtuser.Rows[i]["Progress_Status"].ToString();
                    grd_Admin_orders.Rows[i].Cells[9].Value = dtuser.Rows[i]["Order_ID"].ToString();
                    
                    grd_Admin_orders.Rows[i].Cells[12].Value = dtuser.Rows[i]["Order_Status"].ToString();

                    if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                    {
                        grd_Admin_orders.Rows[i].Cells[10].Value = dtuser.Rows[i]["TARGET_TIME"].ToString();

                        grd_Admin_orders.Rows[i].Cells[11].Value = dtuser.Rows[i]["BALANCE_TIME"].ToString();

                    }




                    if (Order_Process != "RUS_DUE_ORDERS_FOR_EMPLOYEE" && Work_Type == "Live")
                    {
                        grd_Admin_orders.Rows[i].Cells[13].Value = dtuser.Rows[i]["Tax_Task"].ToString();


                        if (grd_Admin_orders.Rows[i].Cells[13].Value.ToString() == "1" || grd_Admin_orders.Rows[i].Cells[13].Value.ToString() == "2")
                        {


                            grd_Admin_orders.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;

                        }
                        if (grd_Admin_orders.Rows[i].Cells[13].Value.ToString() == "3")
                        {


                            grd_Admin_orders.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;

                        }


                    }
                }

            }
            else
            {
                //grd_Admin_orders.DataSource = null;
                //grd_Admin_orders.EmptyDataText = "No Orders Are Avilable";
                //grd_Admin_orders.DataBind();
            }
        }
        protected void Gridview_Bind_Assigned_Orders()
        {
            Hashtable htuser = new Hashtable();
            
            //if (User_Role_Id == "2")
            //{
            if (Work_Type == "Live")
            {
                if (Order_Process == "Abstract_ORDERS_ALLOCATE")
                {
                    htuser.Add("@Trans", "USER_ABSTRACTOR_ORDERS_ADMIN");
                }
                else if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                {

                    htuser.Add("@Trans", "RUSH_OVER_DUE_USER_ASSIGNED_ORDER");
                }
                else if (Order_Process == "TAX")
                {

                    htuser.Add("@Trans", "USER_INTERNAL_TAX_ASSIGNED_ORDER");
                }
                else
                {
                    htuser.Add("@Trans", "USER_ASSIGNED_ORDER");
                }
                if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                {

                    grd_Admin_orders.Columns[10].Visible = true;
                    grd_Admin_orders.Columns[11].Visible = true;

                }
                else
                {
                    grd_Admin_orders.Columns[10].Visible = false;
                    grd_Admin_orders.Columns[11].Visible = false;
                }
            }
            else if (Work_Type == "Rework")
            {


                htuser.Add("@Trans", "REWORK_USER_ASSIGNED_ORDER");
                grd_Admin_orders.Columns[10].Visible = false;
                grd_Admin_orders.Columns[11].Visible = false;

            }
            else if (Work_Type == "SuperQc")
            {
                if (Order_Status == 3)
                {
                    htuser.Add("@Trans", "SUPER_QC_SEARCH_QC_ORDER_FOR_USER");
                }
                else if (Order_Status == 7)
                {
                    htuser.Add("@Trans", "SUPER_QC_TYPING_QC_ORDER_FOR_USER");

                }

                grd_Admin_orders.Columns[10].Visible = false;
                grd_Admin_orders.Columns[11].Visible = false;



            }


            //}
            //else if (User_Role_Id == "1")
            //{
            //    htuser.Add("@Trans", "USER_ASSIGNED_ORDER_ADMIN");
            //}
            htuser.Add("@User_Id", userid);
            htuser.Add("@Order_Status", Order_Status);

            if (Work_Type == "Live")
            {
                dtuser = dataaccess.ExecuteSP("Sp_Order_Count", htuser);
            }
            else if (Work_Type == "Rework")
            {
                dtuser = dataaccess.ExecuteSP("Sp_Order_Rework_Count", htuser);

            }
            else if (Work_Type == "SuperQc")
            {
                dtuser = dataaccess.ExecuteSP("Sp_Order_SuperQc_Count", htuser);

            }
            grd_Admin_orders.Columns[0].Width = 50;
            grd_Admin_orders.Columns[1].Width = 50;
            grd_Admin_orders.Columns[2].Width = 125;
            grd_Admin_orders.Columns[3].Width = 250;
            grd_Admin_orders.Columns[4].Width = 195;
            grd_Admin_orders.Columns[5].Width = 180;
            grd_Admin_orders.Columns[6].Width = 100;
            grd_Admin_orders.Columns[7].Width = 110;
            grd_Admin_orders.Columns[8].Width = 100;
            grd_Admin_orders.Columns[9].Width = 150;
            grd_Admin_orders.Columns[10].Width = 150;
            if (dtuser.Rows.Count > 0)
            {
                grd_Admin_orders.Rows.Clear();

                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    grd_Admin_orders.Rows.Add();
                    grd_Admin_orders.Rows[i].Cells[1].Value = i + 1;
                    grd_Admin_orders.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[3].Value = dtuser.Rows[i]["Subprocess_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[4].Value = dtuser.Rows[i]["Client_Order_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[5].Value = dtuser.Rows[i]["Order_Type"].ToString();
                    grd_Admin_orders.Rows[i].Cells[6].Value = dtuser.Rows[i]["User_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[7].Value = dtuser.Rows[i]["Date"].ToString();
                    grd_Admin_orders.Rows[i].Cells[8].Value = dtuser.Rows[i]["Progress_Status"].ToString();
                    grd_Admin_orders.Rows[i].Cells[9].Value = dtuser.Rows[i]["Order_ID"].ToString();
                   
                    grd_Admin_orders.Rows[i].Cells[12].Value = dtuser.Rows[i]["Order_Status"].ToString();

                    if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                    {
                        grd_Admin_orders.Rows[i].Cells[10].Value = dtuser.Rows[i]["TARGET_TIME"].ToString();

                        grd_Admin_orders.Rows[i].Cells[11].Value = dtuser.Rows[i]["BALANCE_TIME"].ToString();

                    }
                    if (Order_Process != "RUS_DUE_ORDERS_FOR_EMPLOYEE" && Work_Type == "Live")
                    {
                        grd_Admin_orders.Rows[i].Cells[13].Value = dtuser.Rows[i]["Tax_Task"].ToString();


                        if (grd_Admin_orders.Rows[i].Cells[13].Value.ToString() == "1" || grd_Admin_orders.Rows[i].Cells[13].Value.ToString() == "2")
                        {


                            grd_Admin_orders.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;

                        }
                         if (grd_Admin_orders.Rows[i].Cells[13].Value.ToString() == "3")
                         {


                             grd_Admin_orders.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;

                         }

                    }

                
                    // grd_Pending_Orders.Rows[i].Cells[9].Value = dtuser.Rows[i]["Order_Statusid"].ToString();
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
        protected void Gridview_Bind_Pending_Orders()
        {
            Hashtable htpend = new Hashtable();
            
            if (Work_Type == "Live")
            {
                if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                {

                    htpend.Add("@Trans", "RUSH_OVER_DUE_USER_ASSIGNED_ORDER_PENDING");
                }
                else
                {
                    htpend.Add("@Trans", "USER_ASSIGNED_ORDER_PENDING");
                }
                if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                {

                    grd_Pending_Orders.Columns[10].Visible = true;
                    grd_Pending_Orders.Columns[11].Visible = true;

                }
                else
                {
                    grd_Pending_Orders.Columns[10].Visible = false;
                    grd_Pending_Orders.Columns[11].Visible = false;
                }
            }
            else if (Work_Type == "Rework")
            {


                htpend.Add("@Trans", "REWORK_USER_ASSIGNED_ORDER_PENDING");


            }
            else if (Work_Type == "SuperQc")
            {
                if (Order_Status == 3)
                {
                    htpend.Add("@Trans", "SUPER_QC_USER_ASSIGNED_ORDER_PENDING");

                }
                else if (Order_Status == 7)
                {

                    htpend.Add("@Trans", "SUPER_QC_USER_ASSIGNED_ORDER_PENDING");

                }

            }




            htpend.Add("@User_Id", userid);
            htpend.Add("@Order_Status", Order_Status);
            if (Work_Type == "Live")
            {
                dtpend = dataaccess.ExecuteSP("Sp_Order_Count", htpend);
            }
            else if (Work_Type == "Rework")
            {
                dtpend = dataaccess.ExecuteSP("Sp_Order_Rework_Count", htpend);

            }
            else if (Work_Type == "SuperQc")
            {
                dtpend = dataaccess.ExecuteSP("Sp_Order_SuperQc_Count", htpend);

            }

            grd_Pending_Orders.Columns[0].Width = 50;
            grd_Pending_Orders.Columns[1].Width = 50;
            grd_Pending_Orders.Columns[2].Width = 125;
            grd_Pending_Orders.Columns[3].Width = 250;
            grd_Pending_Orders.Columns[4].Width = 195;
            grd_Pending_Orders.Columns[5].Width = 180;
            grd_Pending_Orders.Columns[6].Width = 100;
            grd_Pending_Orders.Columns[7].Width = 110;
            grd_Pending_Orders.Columns[8].Width = 100;
            grd_Pending_Orders.Columns[9].Width = 150;
            grd_Pending_Orders.Columns[11].Width = 150;
            if (dtpend.Rows.Count > 0)
            {
                grd_Pending_Orders.Rows.Clear();
                for (int i = 0; i < dtpend.Rows.Count; i++)
                {
                    grd_Pending_Orders.Rows.Add();
                    grd_Pending_Orders.Rows[i].Cells[1].Value = i + 1;
                    grd_Pending_Orders.Rows[i].Cells[2].Value = dtpend.Rows[i]["Client_Number"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[3].Value = dtpend.Rows[i]["Subprocess_Number"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[4].Value = dtpend.Rows[i]["Client_Order_Number"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[5].Value = dtpend.Rows[i]["Order_Type"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[6].Value = dtpend.Rows[i]["User_Name"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[7].Value = dtpend.Rows[i]["Date"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[8].Value = dtpend.Rows[i]["Progress_Status"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[9].Value = dtpend.Rows[i]["Order_ID"].ToString();
                    grd_Pending_Orders.Rows[i].Cells[12].Value = dtpend.Rows[i]["Order_Status"].ToString();

                    if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                    {
                        grd_Pending_Orders.Rows[i].Cells[10].Value = dtpend.Rows[i]["TARGET_TIME"].ToString();

                        grd_Pending_Orders.Rows[i].Cells[11].Value = dtpend.Rows[i]["BALANCE_TIME"].ToString();

                    }
                }

            }
            else
            {

                grd_Pending_Orders.DataSource = null;


            }
        }
        private bool Check_Order_Number()
        {
            Hashtable ht_Select_Order_Details = new Hashtable();
            DataTable dt_Select_Order_Details = new DataTable();

            ht_Select_Order_Details.Add("@Trans", "SELECT_ORDER_NO_WISE");
            ht_Select_Order_Details.Add("@Client_Order_Number", OrderNo);
            dt_Select_Order_Details = dataaccess.ExecuteSP("Sp_Order", ht_Select_Order_Details);

            if (dt_Select_Order_Details.Rows.Count > 0)
            {

                return true;
            }
            else
            {
                MessageBox.Show("This OrderNumber is Not Avilable");
               // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('This OrderNumber is Not Avilable')</script>", false);
                return false;
            }

        }

        private bool ValidationChecklist_Quest_Entry()
        {
           // int Entered_Count, ClientQenrty_Count, orderid = 0;
            int Client_Id=0;

            Hashtable htorderId = new Hashtable();
            DataTable dtOrderid = new System.Data.DataTable();
            htorderId.Add("@Trans", "SELECT_ORDER_NO_WISE");
            htorderId.Add("@Client_Order_Number", OrderNo);
            dtOrderid = dataaccess.ExecuteSP("Sp_Order", htorderId);
            if (dtOrderid.Rows.Count > 0)
            {
                orderid = int.Parse(dtOrderid.Rows[0]["Order_ID"].ToString());
            }

            Hashtable htorderType_AbsId = new Hashtable();
            DataTable dtorderType_AbsId = new System.Data.DataTable();
            htorderType_AbsId.Add("@Trans", "SELECT_ORDER_NO_WISE_FOR_EMPLOYEE_ORDER_ENTRY");
            htorderType_AbsId.Add("@Order_ID", orderid);
            dtorderType_AbsId = dataaccess.ExecuteSP("Sp_Order", htorderType_AbsId);

            if (dtorderType_AbsId.Rows.Count > 0)
            {
                orderType_ABS_id = int.Parse(dtorderType_AbsId.Rows[0]["OrderType_ABS_Id"].ToString());
            }


            // htget_max_num.Add("@User_id", userid);


            Hashtable htget = new Hashtable();
            DataTable dtget = new DataTable();
            htget.Add("@Trans", "CHECK_QUESTIONS");
            htget.Add("@Order_Task", Order_Status);
            htget.Add("@Order_Type_Abs_Id", orderType_ABS_id);
          
            dtget = dataaccess.ExecuteSP("Sp_Checklist_Detail", htget);
            if (dtget.Rows.Count > 0)
            {
                Entered_Count_1 = int.Parse(dtget.Rows[0]["Genral_Q"].ToString());
                Entered_Count_2 = int.Parse(dtget.Rows[0]["Ass_Q"].ToString());
                Entered_Count_3 = int.Parse(dtget.Rows[0]["Deed_Q"].ToString());
                Entered_Count_4 = int.Parse(dtget.Rows[0]["Mortgage_Q"].ToString());
                Entered_Count_5 = int.Parse(dtget.Rows[0]["Jud_Q"].ToString());
                Entered_Count_6 = int.Parse(dtget.Rows[0]["oth_Q"].ToString());
            }
            else
            {
               
                Entered_Count_1 = 0;
                Entered_Count_2 = 0;
                Entered_Count_3 = 0;
                Entered_Count_4 = 0;
                Entered_Count_5 = 0;
                Entered_Count_6 = 0;
            }

           

            Hashtable ht_get = new Hashtable();
            DataTable dt_get = new DataTable();
            if (Work_Type_Id ==1 && Order_Status != 12 && Order_Status!=24)
            {
                if (Entered_Count_1 == 0 && Entered_Count_2 == 0 && Entered_Count_3 == 0 && Entered_Count_4 == 0 && Entered_Count_5 == 0 && Entered_Count_6 == 0)
                {
                    MessageBox.Show("Need to Set Up Checklist Questions");
                    return false;
                }
               


                else if (Entered_Count_1 >= 0 || Entered_Count_2>=0 || Entered_Count_3>=0 || Entered_Count_4>=0 || Entered_Count_5>=0 || Entered_Count_6>=0 )
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Need to Set Up Checklist Questions");
                    return false;
                }

            }
            else if (Work_Type_Id == 2 && Order_Status != 12 && Order_Status != 24)
            {


                if (Entered_Count_1 == 0 && Entered_Count_2 == 0 && Entered_Count_3 == 0 && Entered_Count_4 == 0 && Entered_Count_5 == 0 && Entered_Count_6 == 0)
                {
                    MessageBox.Show("Need to Set Up Checklist Questions");
                    return false;
                }
               


                else if (Entered_Count_1 >= 0 || Entered_Count_2 >= 0 || Entered_Count_3 >= 0 || Entered_Count_4 >= 0 || Entered_Count_5 >= 0 || Entered_Count_6 >= 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Need to Set Up Checklist Questions");
                    return false;
                }


            }
            else if (Work_Type_Id == 3)
            {
                if (Entered_Count_1 == 0 && Entered_Count_2 == 0 && Entered_Count_3 == 0 && Entered_Count_4 == 0 && Entered_Count_5 == 0 && Entered_Count_6 == 0)
                {
                    MessageBox.Show("Need to Set Up Checklist Questions");
                    return false;
                }
                   


                else if (Entered_Count_1 >= 0 || Entered_Count_2 >= 0 || Entered_Count_3 >= 0 || Entered_Count_4 >= 0 || Entered_Count_5 >= 0 || Entered_Count_6 >= 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Need to Set Up Checklist Questions");
                    return false;
                }


            }
            else
            {
                return true;
            }


           
        }


        private void grd_Admin_orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                OrderNo = grd_Admin_orders.Rows[e.RowIndex].Cells[4].Value.ToString();
                int Order_Status_Id = int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[12].Value.ToString());
                string Order_Status_Type;
                if (e.ColumnIndex == 4 && Operation == "My_Orders")
                {
                    Hashtable htuser = new Hashtable();
                    DataTable dtuser = new System.Data.DataTable();
                    htuser.Add("@Trans", "SELECT");
                    htuser.Add("@Order_Status_ID", Order_Status_Id);
                    dtuser = dataaccess.ExecuteSP("Sp_Order_Status", htuser);
                    Order_Status_Type = dtuser.Rows[0]["Order_Status"].ToString();
                    if (Check_Order_Number() != false)
                    {
                        int orderid = 0;
                        Hashtable htorderId = new Hashtable();
                        DataTable dtOrderid = new System.Data.DataTable();
                        htorderId.Add("@Trans", "SELECT_ORDER_NO_WISE");
                        htorderId.Add("@Client_Order_Number", OrderNo);
                        dtOrderid = dataaccess.ExecuteSP("Sp_Order", htorderId);
                        if (dtOrderid.Rows.Count > 0)
                        {
                            orderid = int.Parse(dtOrderid.Rows[0]["Order_ID"].ToString());
                        }

                        if (Order_Process != "Abstract_ORDERS_ALLOCATE")
                        {
                            //Hashtable ht_Chk = new Hashtable();
                            //DataTable dtChk = new System.Data.DataTable();
                            //ht_Chk.Add("@Trans", "SELECT_Chk");
                            //ht_Chk.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[8].Value.ToString()));
                            //ht_Chk.Add("@Order_Status_Id", Order_Status);
                            //dtChk = dataaccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", ht_Chk);
                            //if (dtChk.Rows.Count > 0)
                            //{
                            //    Hashtable htComments = new Hashtable();
                            //    DataTable dtComments = new System.Data.DataTable();

                            //    DateTime date1 = new DateTime();
                            //    date1 = DateTime.Now;
                            //    string dateeval1 = date1.ToString("dd/MM/yyyy");
                            //    string time1 = date1.ToString("hh:mm tt");

                            //    htComments.Add("@Trans", "UPDATE_ON_LOGOUT");
                            //    htComments.Add("@Order_Time_Id", dtChk.Rows[0]["Order_Time_Id"].ToString());
                            //    htComments.Add("@End_Time", DateTime.Now);
                            //    htComments.Add("@Open_Status", "False");
                            //    dtComments = dataaccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htComments);


                            //    Hashtable ht_User = new Hashtable();
                            //    DataTable dt_User = new System.Data.DataTable();
                            //    ht_User.Add("@Trans", "UPDATE_USER_ID");
                            //    ht_User.Add("@Order_Time_Id", dtChk.Rows[0]["Order_Time_Id"].ToString());
                            //    ht_User.Add("@User_Id", userid);
                            //    dt_User = dataaccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", ht_User);
                            //}
                            //else
                            //{


                          
                                if (Work_Type_Id == 1 && ValidationChecklist_Quest_Entry() != false)
                                {


                                    Hashtable htComments = new Hashtable();
                                    DataTable dtComments = new System.Data.DataTable();

                                    DateTime date = new DateTime();
                                    date = DateTime.Now;
                                    string dateeval = date.ToString("dd/MM/yyyy");
                                    string time = date.ToString("hh:mm tt");

                                    htComments.Add("@Trans", "INSERT");
                                    htComments.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    htComments.Add("@Order_Status_Id", Order_Status);
                                    htComments.Add("@Start_Time", date);
                                    htComments.Add("@End_Time", date);
                                    htComments.Add("@User_Id", userid);
                                    htComments.Add("@Order_Progress_Id", 14);
                                    object Max_time_Id = dataaccess.ExecuteSPForScalar("Sp_Order_User_Wise_Time_Track", htComments);

                                    MAX_TIME_ID = int.Parse(Max_time_Id.ToString());




                                    if (Order_Status_Id != 22)
                                    {

                                        Hashtable htProgress_update = new Hashtable();
                                        DataTable dtProgress_update = new System.Data.DataTable();
                                        htProgress_update.Add("@Trans", "UPDATE_PROGRESS");
                                        htProgress_update.Add("@Order_Progress", 14);
                                        htProgress_update.Add("@Order_ID", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                        dtProgress_update = dataaccess.ExecuteSP("Sp_Order", htProgress_update);
                                    }

                                    Hashtable htorderAssign_update = new Hashtable();
                                    DataTable dtorderAssign_update = new System.Data.DataTable();
                                    htorderAssign_update.Add("@Trans", "UPDATE");
                                    htorderAssign_update.Add("@Order_Progress_Id", 14);
                                    htorderAssign_update.Add("@Modified_By", userid);
                                    htorderAssign_update.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    dtorderAssign_update = dataaccess.ExecuteSP("Sp_Order_Assignment", htorderAssign_update);

                                    if (grd_Admin_orders.Rows[e.RowIndex].Cells[13].Value.ToString() == "3")
                                    {

                                        Tax_Completed = 1;
                                    }
                                    else
                                    {

                                        Tax_Completed = 0;
                                    }

                                    // }
                                    Ordermanagement_01.Employee_Order_Entry OrderEntry = new Ordermanagement_01.Employee_Order_Entry(grd_Admin_orders.Rows[e.RowIndex].Cells[4].Value.ToString(), int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()), userid, User_Role_Id, Order_Process, Order_Status_Type, Order_Status_Id, Work_Type_Id, MAX_TIME_ID, Tax_Completed);
                                   
                                    if (!CheckOpened("Employee_Order_Entry"))
                                    {
                                        OrderEntry.Show();
                                        this.Close();
                                    }
                                }
                                else if (Work_Type_Id == 2 && ValidationChecklist_Quest_Entry() != false)
                                {
                                    Hashtable htComments = new Hashtable();
                                    DataTable dtComments = new System.Data.DataTable();

                                    DateTime date = new DateTime();
                                    date = DateTime.Now;
                                    string dateeval = date.ToString("dd/MM/yyyy");
                                    string time = date.ToString("hh:mm tt");

                                    htComments.Add("@Trans", "INSERT");
                                    htComments.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    htComments.Add("@Order_Status_Id", Order_Status);
                                    htComments.Add("@Start_Time", date);
                                    htComments.Add("@End_Time", date);
                                    htComments.Add("@User_Id", userid);
                                    object Max_time_id = dataaccess.ExecuteSPForScalar("Sp_Order_Rework_User_Wise_Time_Track", htComments);

                                    MAX_TIME_ID = int.Parse(Max_time_id.ToString());





                                    Hashtable htProgress_update = new Hashtable();
                                    DataTable dtProgress_update = new System.Data.DataTable();
                                    htProgress_update.Add("@Trans", "UPDATE_STATUS");
                                    htProgress_update.Add("@Cureent_Status", 14);
                                    htProgress_update.Add("@Order_ID", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    dtProgress_update = dataaccess.ExecuteSP("Sp_Order_Rework_Status", htProgress_update);

                                    Hashtable htorderAssign_update = new Hashtable();
                                    DataTable dtorderAssign_update = new System.Data.DataTable();
                                    htorderAssign_update.Add("@Trans", "UPDATE");
                                    htorderAssign_update.Add("@Order_Progress_Id", 14);
                                    htorderAssign_update.Add("@Modified_By", userid);
                                    htorderAssign_update.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    dtorderAssign_update = dataaccess.ExecuteSP("Sp_Order_Rework_Assignment", htorderAssign_update);


                                    // }
                                    Ordermanagement_01.Employee_Order_Entry OrderEntry = new Ordermanagement_01.Employee_Order_Entry(grd_Admin_orders.Rows[e.RowIndex].Cells[4].Value.ToString(), int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()), userid, User_Role_Id, Order_Process, Order_Status_Type, Order_Status_Id, Work_Type_Id, MAX_TIME_ID, 0);
                                    if (!CheckOpened("Employee_Order_Entry"))
                                    {
                                        OrderEntry.Show();
                                        this.Close();
                                    }

                                }
                                else if (Work_Type_Id == 3 && ValidationChecklist_Quest_Entry()!=false)
                                {
                                    Hashtable htComments = new Hashtable();
                                    DataTable dtComments = new System.Data.DataTable();

                                    DateTime date = new DateTime();
                                    date = DateTime.Now;
                                    string dateeval = date.ToString("dd/MM/yyyy");
                                    string time = date.ToString("hh:mm tt");

                                    htComments.Add("@Trans", "INSERT");
                                    htComments.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    htComments.Add("@Order_Status_Id", Order_Status);
                                    htComments.Add("@Start_Time", date);
                                    htComments.Add("@End_Time", date);
                                    htComments.Add("@User_Id", userid);
                                    object Max_time_id = dataaccess.ExecuteSPForScalar("Sp_Order_Super_Qc_User_Wise_Time_Track", htComments);


                                    MAX_TIME_ID = int.Parse(Max_time_id.ToString());

                                    Hashtable htProgress_update = new Hashtable();
                                    DataTable dtProgress_update = new System.Data.DataTable();
                                    htProgress_update.Add("@Trans", "UPDATE_STATUS");
                                    htProgress_update.Add("@Current_Task", Order_Status);// Task ==status
                                    htProgress_update.Add("@Cureent_Status", 14);// status== progress
                                    htProgress_update.Add("@Order_ID", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    dtProgress_update = dataaccess.ExecuteSP("Sp_Super_Qc_Status", htProgress_update);

                                    Hashtable htorderAssign_update = new Hashtable();
                                    DataTable dtorderAssign_update = new System.Data.DataTable();
                                    htorderAssign_update.Add("@Trans", "UPDATE");
                                    htorderAssign_update.Add("@Order_Status_Id", Order_Status);
                                    htorderAssign_update.Add("@Order_Progress_Id", 14);
                                    htorderAssign_update.Add("@Modified_By", userid);
                                    htorderAssign_update.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()));
                                    dtorderAssign_update = dataaccess.ExecuteSP("Sp_Super_Qc_Order_Assignment", htorderAssign_update);


                                    // }
                                    Ordermanagement_01.Employee_Order_Entry OrderEntry = new Ordermanagement_01.Employee_Order_Entry(grd_Admin_orders.Rows[e.RowIndex].Cells[4].Value.ToString(), int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()), userid, User_Role_Id, Order_Process, Order_Status_Type, Order_Status_Id, Work_Type_Id, MAX_TIME_ID, 0);
                                    if (!CheckOpened("Employee_Order_Entry"))
                                    {
                                        OrderEntry.Show();
                                        this.Close();
                                    }

                                }
                            
                      }



                    }
                }
                else if (e.ColumnIndex == 4 && User_Role_Id == "1" && Operation == "All_Orders")
                {
                    Ordermanagement_01.Order_Entry Order_Entry = new Ordermanagement_01.Order_Entry(int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()), userid, User_Role_Id);
                    Order_Entry.Show();

                }
            }
        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
        private void grd_Pending_Orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                OrderNo = grd_Pending_Orders.Rows[e.RowIndex].Cells[4].Value.ToString();
                int Order_Status_Id = int.Parse(grd_Pending_Orders.Rows[e.RowIndex].Cells[12].Value.ToString());
                string Order_Status_Type;
                if (e.ColumnIndex == 4)
                {
                    if (Work_Type_Id == 1 && ValidationChecklist_Quest_Entry()!=false)
                    {

                        Hashtable htuser = new Hashtable();
                        DataTable dtuser = new System.Data.DataTable();
                        htuser.Add("@Trans", "SELECT");
                        htuser.Add("@Order_Status_ID", Order_Status_Id);
                        dtuser = dataaccess.ExecuteSP("Sp_Order_Status", htuser);
                        Order_Status_Type = dtuser.Rows[0]["Order_Status"].ToString();
                        //Response.Redirect("~/Admin/Employee_Order_Entry.aspx");
                        if (Check_Order_Number() != false)
                        {

                            int orderid = 0;
                            Hashtable htorderId = new Hashtable();
                            DataTable dtOrderid = new System.Data.DataTable();
                            htorderId.Add("@Trans", "SELECT_ORDER_NO_WISE");
                            htorderId.Add("@Client_Order_Number", OrderNo);
                            dtOrderid = dataaccess.ExecuteSP("Sp_Order", htorderId);
                            if (dtOrderid.Rows.Count > 0)
                            {
                                orderid = int.Parse(dtOrderid.Rows[0]["Order_ID"].ToString());
                            }

                            Hashtable htComments = new Hashtable();
                            DataTable dtComments = new System.Data.DataTable();
                            DateTime date = new DateTime();
                            date = DateTime.Now;
                            string dateeval = date.ToString("dd/MM/yyyy");
                            string time = date.ToString("hh:mm tt");

                            htComments.Add("@Trans", "INSERT");
                            htComments.Add("@Order_Id", orderid);
                            htComments.Add("@Order_Status_Id", int.Parse(Order_Status.ToString()));
                            htComments.Add("@Start_Time", date);
                            htComments.Add("@End_Time", date);
                            htComments.Add("@User_Id", userid);
                            object Max_time_id = dataaccess.ExecuteSPForScalar("Sp_Order_User_Wise_Time_Track", htComments);

                            MAX_TIME_ID = int.Parse(Max_time_id.ToString());

                            Hashtable htProgress_update = new Hashtable();
                            DataTable dtProgress_update = new System.Data.DataTable();
                            htProgress_update.Add("@Trans", "UPDATE_PROGRESS");
                            htProgress_update.Add("@Order_Progress", 14);
                            htProgress_update.Add("@Order_ID", orderid);
                            dtProgress_update = dataaccess.ExecuteSP("Sp_Order", htProgress_update);

                            Hashtable htorderAssign_update = new Hashtable();
                            DataTable dtorderAssign_update = new System.Data.DataTable();
                            htorderAssign_update.Add("@Trans", "UPDATE");
                            htorderAssign_update.Add("@Order_Progress_Id", 14);
                            htorderAssign_update.Add("@Modified_By", userid);
                            htorderAssign_update.Add("@Order_Id", orderid);
                            dtorderAssign_update = dataaccess.ExecuteSP("Sp_Order_Assignment", htorderAssign_update);


                            Ordermanagement_01.Employee_Order_Entry OrderEntry = new Ordermanagement_01.Employee_Order_Entry(grd_Pending_Orders.Rows[e.RowIndex].Cells[3].Value.ToString(), int.Parse(grd_Pending_Orders.Rows[e.RowIndex].Cells[9].Value.ToString()), userid, User_Role_Id, Order_Process, Order_Status_Type, Order_Status_Id, Work_Type_Id, MAX_TIME_ID,0);
                            if (!CheckOpened("Employee_Order_Entry"))
                            {
                                OrderEntry.Show();
                                this.Close();
                            }

                        }
                    }
                    else if (Work_Type_Id == 2 && ValidationChecklist_Quest_Entry() != false)
                    {
                        Hashtable htuser = new Hashtable();
                        DataTable dtuser = new System.Data.DataTable();
                        htuser.Add("@Trans", "SELECT");
                        htuser.Add("@Order_Status_ID", Order_Status_Id);
                        dtuser = dataaccess.ExecuteSP("Sp_Order_Status", htuser);
                        Order_Status_Type = dtuser.Rows[0]["Order_Status"].ToString();
                        //Response.Redirect("~/Admin/Employee_Order_Entry.aspx");
                        if (Check_Order_Number() != false)
                        {

                            int orderid = 0;
                            Hashtable htorderId = new Hashtable();
                            DataTable dtOrderid = new System.Data.DataTable();
                            htorderId.Add("@Trans", "SELECT_ORDER_NO_WISE");
                            htorderId.Add("@Client_Order_Number", OrderNo);
                            dtOrderid = dataaccess.ExecuteSP("Sp_Order", htorderId);
                            if (dtOrderid.Rows.Count > 0)
                            {
                                orderid = int.Parse(dtOrderid.Rows[0]["Order_ID"].ToString());
                            }

                            Hashtable htComments = new Hashtable();
                            DataTable dtComments = new System.Data.DataTable();
                            DateTime date = new DateTime();
                            date = DateTime.Now;
                            string dateeval = date.ToString("dd/MM/yyyy");
                            string time = date.ToString("hh:mm tt");

                            htComments.Add("@Trans", "INSERT");
                            htComments.Add("@Order_Id", orderid);
                            htComments.Add("@Order_Status_Id", int.Parse(Order_Status.ToString()));
                            htComments.Add("@Start_Time", date);
                            htComments.Add("@End_Time", date);
                            htComments.Add("@User_Id", userid);
                            object Max_time_id = dataaccess.ExecuteSP("Sp_Order_Rework_User_Wise_Time_Track", htComments);
                            MAX_TIME_ID = int.Parse(Max_time_id.ToString());


                            Hashtable htProgress_update = new Hashtable();
                            DataTable dtProgress_update = new System.Data.DataTable();
                            htProgress_update.Add("@Trans", "UPDATE_STATUS");
                            htProgress_update.Add("@Cureent_Status", 14);
                            htProgress_update.Add("@Order_ID", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[8].Value.ToString()));
                            dtProgress_update = dataaccess.ExecuteSP("Sp_Order_Rework_Status", htProgress_update);

                            Hashtable htorderAssign_update = new Hashtable();
                            DataTable dtorderAssign_update = new System.Data.DataTable();
                            htorderAssign_update.Add("@Trans", "UPDATE");
                            htorderAssign_update.Add("@Order_Progress_Id", 14);
                            htorderAssign_update.Add("@Modified_By", userid);
                            htorderAssign_update.Add("@Order_Id", int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[8].Value.ToString()));
                            dtorderAssign_update = dataaccess.ExecuteSP("Sp_Order_Rework_Assignment", htorderAssign_update);



                            Ordermanagement_01.Employee_Order_Entry OrderEntry = new Ordermanagement_01.Employee_Order_Entry(grd_Pending_Orders.Rows[e.RowIndex].Cells[3].Value.ToString(), int.Parse(grd_Pending_Orders.Rows[e.RowIndex].Cells[9].Value.ToString()), userid, User_Role_Id, Order_Process, Order_Status_Type, Order_Status_Id, Work_Type_Id, MAX_TIME_ID,0);
                            if (!CheckOpened("Employee_Order_Entry"))
                            {
                                OrderEntry.Show();
                                this.Close();
                            }

                        }

                    }

                }
            }
        
        }
        private void grd_Admin_orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_My_Orders_Click(object sender, EventArgs e)
        {

            Operation = "My_Orders";
            label1.Text = "MY  ORDERS:";
            grd_Admin_orders.EnableHeadersVisualStyles = false;
            Gridview_Bind_Assigned_Orders();
            Gridview_Bind_Pending_Orders();
            

        }

        private void txt_SearchOrdernumber_TextChanged(object sender, EventArgs e)
        {
            DataView dtsearch = new DataView(dtuser);
            dtsearch.RowFilter = "Client_Order_Number like '%" + txt_SearchOrdernumber.Text.ToString() + "%'";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = dtsearch.ToTable();
            if (dt.Rows.Count > 0)
            {
                grd_Admin_orders.Columns[0].Width = 50;
                grd_Admin_orders.Columns[1].Width = 50;
                grd_Admin_orders.Columns[2].Width = 125;
                grd_Admin_orders.Columns[3].Width = 250;
                grd_Admin_orders.Columns[4].Width = 195;
                grd_Admin_orders.Columns[5].Width = 180;
                grd_Admin_orders.Columns[6].Width = 100;
                grd_Admin_orders.Columns[7].Width = 110;
                grd_Admin_orders.Columns[8].Width = 100;
                grd_Admin_orders.Columns[10].Width = 150;
                grd_Admin_orders.Columns[12].Width = 150;
                if (dt.Rows.Count > 0)
                {
                    grd_Admin_orders.Rows.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        grd_Admin_orders.Rows.Add();
                        grd_Admin_orders.Rows[i].Cells[1].Value = i + 1;
                        grd_Admin_orders.Rows[i].Cells[2].Value = dt.Rows[i]["Client_Number"].ToString();
                        grd_Admin_orders.Rows[i].Cells[3].Value = dt.Rows[i]["Subprocess_Number"].ToString();
                        grd_Admin_orders.Rows[i].Cells[4].Value = dt.Rows[i]["Client_Order_Number"].ToString();
                        grd_Admin_orders.Rows[i].Cells[5].Value = dt.Rows[i]["Order_Type"].ToString();
                        grd_Admin_orders.Rows[i].Cells[6].Value = dt.Rows[i]["User_Name"].ToString();
                        grd_Admin_orders.Rows[i].Cells[7].Value = dt.Rows[i]["Date"].ToString();
                        grd_Admin_orders.Rows[i].Cells[8].Value = dt.Rows[i]["Progress_Status"].ToString();
                        grd_Admin_orders.Rows[i].Cells[9].Value = dt.Rows[i]["Order_ID"].ToString();
                    
                        grd_Admin_orders.Rows[i].Cells[12].Value = dt.Rows[i]["Order_Status"].ToString();

                        if (Order_Process == "RUS_DUE_ORDERS_FOR_EMPLOYEE")
                        {
                            grd_Admin_orders.Rows[i].Cells[10].Value = dt.Rows[i]["TARGET_TIME"].ToString();

                            grd_Admin_orders.Rows[i].Cells[11].Value = dt.Rows[i]["BALANCE_TIME"].ToString();

                        }
                        // grd_Pending_Orders.Rows[i].Cells[9].Value = dtuser.Rows[i]["Order_Statusid"].ToString();
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
            //txt_SearchOrdernumber.ForeColor = Color.Black;
            
            //foreach (DataGridViewRow row in grd_Admin_orders.Rows)
            //{
            //    if(txt_SearchOrdernumber.Text!="" && row.Cells[2].Value.ToString().StartsWith(txt_SearchOrdernumber.Text, true, CultureInfo.InvariantCulture))
            //    {
            //        row.Visible = true;
            //    }
            //    else
            //    {
            //        row.Visible = false;
            //    }
            //}
        }

        private void txt_SearchOrdernumber_Click(object sender, EventArgs e)
        {
            txt_SearchOrdernumber.ForeColor = Color.Black;
            txt_SearchOrdernumber.Text = "";
        }

        private void txt_SearchPending_TextChanged(object sender, EventArgs e)
        {
            txt_SearchPending.ForeColor = Color.Black;
            txt_SearchPending.Text = "";
            foreach (DataGridViewRow row in grd_Admin_orders.Rows)
            {
                if (txt_SearchPending.Text != "" && row.Cells[3].Value.ToString().StartsWith(txt_SearchPending.Text, true, CultureInfo.InvariantCulture))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void txt_SearchPending_Click(object sender, EventArgs e)
        {
            txt_SearchPending.ForeColor = Color.Black;
            txt_SearchPending.Text = "";
        }


        private bool check_Order_In_Tax_Queau(int Order_Id)
        {

            Hashtable htcheck = new Hashtable();
            DataTable dtcheck = new DataTable();
            htcheck.Add("@Trans", "CHECK_ORDER");
            htcheck.Add("@Order_Id", Order_Id);
            dtcheck = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htcheck);
            int check = 0;
            if (dtcheck.Rows.Count > 0)
            {

                check = int.Parse(dtcheck.Rows[0]["count"].ToString());
            }
            else
            {
                check = 0;
            }

            if (check == 0)
            {

                return true;
            }
            else
            {
                MessageBox.Show("This Order is alreaday Sent for Tax Request");
                return false;
            }
        }


        private bool check_Order_In_Tax_Queau_For_Cancel(int Order_Id)
        {

            Hashtable htcheck = new Hashtable();
            DataTable dtcheck = new DataTable();
            htcheck.Add("@Trans", "CHECK_ORDER");
            htcheck.Add("@Order_Id", Order_Id);
            dtcheck = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htcheck);
            int check = 0;
            if (dtcheck.Rows.Count > 0)
            {

                check = int.Parse(dtcheck.Rows[0]["count"].ToString());
            }
            else
            {
                check = 0;
            }

            if (check == 0)
            {
                MessageBox.Show("This Order is not yet Sent for Tax Request");
                return false;

               
            }
            else
            {
              
                return true;
            }
        }
        private void Insert_Tax_Order_Status(int Order_Id)
        {



            Hashtable httax = new Hashtable();
            DataTable dttax = new DataTable();

            httax.Add("@Trans", "INSERT");
            httax.Add("@Order_Id", Order_Id);
            httax.Add("@Order_Task", 22);
            httax.Add("@Order_Status", 8);
            httax.Add("@Tax_Task", 1);
            httax.Add("@Tax_Status", 6);
            httax.Add("@Inserted_By", userid);
            httax.Add("@Status", "True");
            dttax = dataaccess.ExecuteSP("Sp_Tax_Order_Status", httax);



        }
        private void btn_Send_Tax_Request_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_Admin_orders.Rows.Count; i++)
            {
                bool isChecked = (bool)grd_Admin_orders[0, i].FormattedValue;


                if (isChecked == true)
                {

                    Hashtable htselect_Orderid = new Hashtable();
                    DataTable dtselect_Orderid = new System.Data.DataTable();
                    htselect_Orderid.Add("@Trans", "SELECT_ORDER_NO_WISE");
                    htselect_Orderid.Add("@Client_Order_Number",grd_Admin_orders.Rows[i].Cells[4].Value.ToString());
                    dtselect_Orderid = dataaccess.ExecuteSP("Sp_Order", htselect_Orderid);
                    Order_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_ID"].ToString());

                    if (Order_Id != null)
                    {
                        Message_Count = 1;

                        Hashtable htcheck = new Hashtable();
                        DataTable dtcheck = new DataTable();
                        htcheck.Add("@Trans", "CHECK_ORDER");
                        htcheck.Add("@Order_Id", Order_Id);
                        dtcheck = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htcheck);
                        int check = 0;
                        if (dtcheck.Rows.Count > 0)
                        {

                            check = int.Parse(dtcheck.Rows[0]["count"].ToString());
                        }
                        else
                        {
                            check = 0;
                        }

                        if (check == 0)
                        {
                            Insert_Tax_Order_Status(Order_Id);
                        }
                        else
                        { 
                        

                        }

                        Hashtable htupdate = new Hashtable();
                        System.Data.DataTable dtupdate = new System.Data.DataTable();
                        htupdate.Add("@Trans", "UPDATE_SEARCH_TAX_REQUEST");
                        htupdate.Add("@Order_ID", Order_Id);
                        htupdate.Add("@Search_Tax_Request", "True");

                        dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);

                        Hashtable httaxupdate = new Hashtable();
                        System.Data.DataTable dttaxupdate = new System.Data.DataTable();
                        httaxupdate.Add("@Trans", "UPDATE_SEARCH_TAX_REQUEST_STATUS");
                        httaxupdate.Add("@Order_ID", Order_Id);
                        httaxupdate.Add("@Search_Tax_Request_Progress", 14);

                        dttaxupdate = dataaccess.ExecuteSP("Sp_Order", httaxupdate);



                        //OrderHistory
                        Hashtable ht_Order_History = new Hashtable();
                        DataTable dt_Order_History = new DataTable();
                        ht_Order_History.Add("@Trans", "INSERT");
                        ht_Order_History.Add("@Order_Id", Order_Id);
                        ht_Order_History.Add("@User_Id", userid);
                        ht_Order_History.Add("@Status_Id", int.Parse(dtselect_Orderid.Rows[0]["Order_Status_Id"].ToString()));
                        ht_Order_History.Add("@Progress_Id", int.Parse(dtselect_Orderid.Rows[0]["Order_Progress"].ToString()));
                        ht_Order_History.Add("@Work_Type", 1);
                        ht_Order_History.Add("@Assigned_By", userid);
                        ht_Order_History.Add("@Modification_Type", "Order Send to Search Tax Request");
                        dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);

                      

                    }
                }
            }

            if (Message_Count == 1)
            {

                MessageBox.Show("Order Send to Search Tax Request");
                if (Operation == "My_Orders")
                {
                    btn_My_Orders_Click(sender, e);
                }
                else
                {

                    Gridview_Bind_Admin_Orders();
                }

                Message_Count = 0;
            }
        }

        private void btn_Cancel_Tax_Request_Click(object sender, EventArgs e)
        {



            for (int i = 0; i < grd_Admin_orders.Rows.Count; i++)
            {
                bool isChecked = (bool)grd_Admin_orders[0, i].FormattedValue;


                if (isChecked == true)
                {

                    Hashtable htselect_Orderid = new Hashtable();
                    DataTable dtselect_Orderid = new System.Data.DataTable();
                    htselect_Orderid.Add("@Trans", "SELECT_ORDER_NO_WISE");
                    htselect_Orderid.Add("@Client_Order_Number", grd_Admin_orders.Rows[i].Cells[4].Value.ToString());
                    dtselect_Orderid = dataaccess.ExecuteSP("Sp_Order", htselect_Orderid);
                    Order_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Id"].ToString());

                    if (Order_Id != null && check_Order_In_Tax_Queau_For_Cancel(Order_Id) != false)
                    {
                        Message_Count = 1;
                       

                        Hashtable htupdate = new Hashtable();
                        System.Data.DataTable dtupdate = new System.Data.DataTable();
                        htupdate.Add("@Trans", "UPDATE_SEARCH_TAX_REQUEST");
                        htupdate.Add("@Order_ID", Order_Id);
                        htupdate.Add("@Search_Tax_Request", "False");

                        dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);

                  
                       



                        //OrderHistory
                        Hashtable ht_Order_History = new Hashtable();
                        DataTable dt_Order_History = new DataTable();
                        ht_Order_History.Add("@Trans", "INSERT");
                        ht_Order_History.Add("@Order_Id", Order_Id);
                        ht_Order_History.Add("@User_Id", userid);
                        ht_Order_History.Add("@Status_Id", int.Parse(dtselect_Orderid.Rows[0]["Order_Status_Id"].ToString()));
                        ht_Order_History.Add("@Progress_Id", int.Parse(dtselect_Orderid.Rows[0]["Order_Progress"].ToString()));
                        ht_Order_History.Add("@Work_Type", 1);
                        ht_Order_History.Add("@Assigned_By", userid);
                        ht_Order_History.Add("@Modification_Type", "Tax Request Cancelled");
                        dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);

                      

                    }
                }
            }

            if (Message_Count == 1)
            {

                MessageBox.Show("Tax Request Cancelled");
            }

            if (Operation == "My_Orders")
            {
                btn_My_Orders_Click(sender, e);
            }
            else
            {

                Gridview_Bind_Admin_Orders();
            }

            Message_Count = 0;
        
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
