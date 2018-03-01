using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Speech.Synthesis;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System.Globalization;
using System.Threading;

namespace Ordermanagement_01
{
    public partial class Order_Allocate : Form
    {
        SpeechSynthesizer reader;
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        string Order_Process;
        int Order_Status_Id;
        int Tree_View_UserId;
        int User_id;
        int PausePlay=0;
        string County_Type;
        bool Abstractor_Check;
        // int MouseEnterNode;
        Genral gen = new Genral();
        Hashtable htexp = new Hashtable();
        System.Data.DataTable dtexp = new System.Data.DataTable();
        DataSet ds = new DataSet();
        System.Data.DataTable dtexport = new System.Data.DataTable();
        Hashtable htAllocate = new Hashtable();
        System.Data.DataTable dtAllocate = new System.Data.DataTable();
        System.Data.DataTable dtchild = new System.Data.DataTable();

        System.Data.DataTable dtselect = new System.Data.DataTable();
        System.Data.DataTable dtinfo = new System.Data.DataTable();
    
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataTable dtuserexport = new System.Data.DataTable();
        string Path1;
        Classes.Load_Progres load_Progressbar = new Classes.Load_Progres();
       
       

          string lbl_Order_Id;
        
        //=========================Vendors==========================================
        string Vendor_Id;
        string lbl_Order_Type_Id;
        int Order_Type_Abs_Id,Client_Id,Sub_Process_Id;


        int Vendor_Total_No_Of_Order_Recived, Vendor_No_Of_Order_For_each_Vendor, Vendor_Order_capacity;
        decimal Vendor_Order_Percentage;
        int No_Of_Order_Assignd_for_Vendor;
           string Vendor_Date;

           int Vendor_State_Count, Vendor_Order_Type_Count, Vendor_Client_COunt;

//===========================================================================================

  static int   External_Client_Order_Id, External_Client_Order_Task_Id, Check_External_Production;
     
        string Export_Title_Name,userroleid;
        int Max_Time_Id, Differnce_Time,Differnce_Count;
        public Order_Allocate(string OrderProcess, int OrderStatusId, int Userid,string User_RoleID)
        {
            InitializeComponent();
            User_id = Userid;
            Order_Process = OrderProcess;
            Order_Status_Id = OrderStatusId;
            userroleid = User_RoleID;

            if (User_RoleID == "2")
            {

                btn_user_Export.Enabled = false;
                btn_Export.Enabled = false;


            }
            else
            {

                btn_user_Export.Enabled = true;
                btn_Export.Enabled = true;
            }
         

        }

        // Set new application state, handling button sensitivity, labels, etc.
        private void GetrowTable(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dtAllocate.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }

        protected void Gridview_Bind_All_Orders()
        {
            //if (ddl_Client_Name.SelectedValue == "ALL")
            //{
            System.Windows.Forms.Button nodebutton;
            htexp.Clear();
            dtexp.Clear();
            htAllocate.Clear();
            dtAllocate.Clear();


            if (Order_Process == "SEARCH_ORDER_ALLOCATE" || Order_Process == "SEARCH_QC_ORDER_ALLOCATE" || Order_Process == "SEARCH_TYPING_ORDER_ALLOCATE" || Order_Process == "TYPING_QC_ORDERS_ALLOCATE" || Order_Process == "UPLOAD_ORDERS_ALLOCATE" || Order_Process == "FINAL_QC_ORDERS_ALLOCATE" || Order_Process == "EXCEPTION_ORDERS_ALLOCATE")
            {
                dtexport.Rows.Clear();
                htAllocate.Add("@Trans", "NOT ASSIGNED");
                htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);

             
            }
            else if (Order_Process == "TAX_ORDERS_ALLOCATE")

            {
                dtexport.Rows.Clear();
                htAllocate.Add("@Trans", "INTERNAL_TAX_ORDER_ALLOCATE");

                dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);

                //htexp.Add("@Trans", "CLARIFICATION_ORDER_ALLOCATE_PENDING");

                //dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);

                //dtexport = dtexp;
            }

            else if (Order_Process == "CLARIFICATION_ORDER_ALLOCATE_PENDING")
            {
                dtexport.Rows.Clear();
                htAllocate.Add("@Trans", "CLARIFICATION_ORDER_ALLOCATE_PENDING");

                dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);

                //htexp.Add("@Trans", "CLARIFICATION_ORDER_ALLOCATE_PENDING");

                //dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);

                //dtexport = dtexp;
            }

            else if (Order_Process == "HOLD_ORDER_ALLOCATE_PENDING")
            {
                dtexport.Rows.Clear();
                htAllocate.Add("@Trans", "HOLD_ORDER_ALLOCATE_PENDING");
                // htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);


                //htexp.Add("@Trans", "HOLD_ORDER_ALLOCATE_PENDING");
                //// htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                //dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);

                //dtexport = dtexp;
            }
            else if (Order_Process == "CANCELLED_ORDER_ALLOCATE_PENDING")
            {
                dtexport.Rows.Clear();
                htAllocate.Add("@Trans", "CANCELLED_ORDER_ALLOCATE_PENDING");
                // htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);


                //htexp.Add("@Trans", "CANCELLED_ORDER_ALLOCATE_PENDING");
                //// htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                //dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);


                //dtexport = dtexp;
            }
            else if (Order_Process == "COMPLETED_ORDER_ALLOCATE")
            {
                dtexport.Rows.Clear();
                htAllocate.Add("@Trans", "COMPLETED_ORDER_ALLOCATE");
                htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);


                //htexp.Add("@Trans", "CANCELLED_ORDER_ALLOCATE_PENDING");
                //// htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                //dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);


                //dtexport = dtexp;
            }
            else if (Order_Process == "REASSIGNED_ORDER_ALLOCATE_PENDING")
            {
                dtexport.Rows.Clear();
                htAllocate.Add("@Trans", "REASSIGNED_ORDER_ALLOCATE_PENDING");
                // htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);


                //htexp.Add("@Trans", "REASSIGNED_ORDER_ALLOCATE_PENDING");
                //// htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                //dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);


                //dtexport = dtexp;
            }
            grd_order.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
            grd_order.EnableHeadersVisualStyles = false;

            grd_order.Columns[0].Width = 35;
            grd_order.Columns[1].Width = 50;
            grd_order.Columns[2].Width = 110;
            grd_order.Columns[3].Width = 220;
            grd_order.Columns[4].Width = 195;
            grd_order.Columns[5].Width = 160;
            grd_order.Columns[6].Width = 125;
            grd_order.Columns[7].Width = 120;


            System.Data.DataTable temptable = dtAllocate;
          
            if (temptable.Rows.Count > 0)
            {
                grd_order.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    grd_order.Rows.Add();
                    grd_order.Rows[i].Cells[1].Value = i + 1;
                    if (userroleid == "1")
                    {
                        grd_order.Rows[i].Cells[2].Value = temptable.Rows[i]["Client_Name"].ToString();
                        grd_order.Rows[i].Cells[3].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                    }
                    else if (userroleid == "2")
                    {
                        grd_order.Rows[i].Cells[2].Value = temptable.Rows[i]["Client_Number"].ToString();
                        grd_order.Rows[i].Cells[3].Value = temptable.Rows[i]["Subprocess_Number"].ToString();
                    }
                    grd_order.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Number"].ToString();

                    grd_order.Rows[i].Cells[5].Value = temptable.Rows[i]["Client_Order_Ref"].ToString();

                    grd_order.Rows[i].Cells[6].Value = temptable.Rows[i]["Order_Type"].ToString();
                    grd_order.Rows[i].Cells[7].Value = temptable.Rows[i]["STATECOUNTY"].ToString();
                    grd_order.Rows[i].Cells[8].Value = temptable.Rows[i]["County_Type"].ToString();
                    grd_order.Rows[i].Cells[9].Value = temptable.Rows[i]["Date"].ToString();
                    grd_order.Rows[i].Cells[10].Value = temptable.Rows[i]["Order_ID"].ToString();
                    grd_order.Rows[i].Cells[11].Value = 0;//Not requried its from titlelogy 
                    grd_order.Rows[i].Cells[12].Value = temptable.Rows[i]["Order_Status"].ToString();
                    grd_order.Rows[i].Cells[13].Value = temptable.Rows[i]["State"].ToString();

                    grd_order.Rows[i].Cells[14].Value = temptable.Rows[i]["Client_Id"].ToString();
                    grd_order.Rows[i].Cells[15].Value = temptable.Rows[i]["Sub_ProcessId"].ToString();
                    grd_order.Rows[i].Cells[16].Value = temptable.Rows[i]["Order_Type_ID"].ToString();
                    grd_order.Rows[i].Cells[19].Value = temptable.Rows[i]["Search_Tax_Request"].ToString();

                    grd_order.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.DarkCyan;
                    
                }
                for (int j = 0; j < temptable.Rows.Count; j++)
                {
                    int v1 = int.Parse(grd_order.Rows[j].Cells[11].Value.ToString());
                    int v2 = int.Parse(grd_order.Rows[j].Cells[12].Value.ToString());
                    if (v1 == 1 && v2 != 2)
                    {

                        grd_order.Rows[j].DefaultCellStyle.BackColor = Color.YellowGreen;

                    }
                }
                //lbl_Total_Orders.Text = grd_order.Rows.Count.ToString();
            }
            else
            {
                grd_order.DataSource = null;
                grd_order.Rows.Clear();
                lbl_Total_Orders.Text = "0";

            }
            lbl_Total_Orders.Text = dtAllocate.Rows.Count.ToString();
      


            //if (dtAllocate.Rows.Count > 0)
            //{
            //    grd_order.Rows.Clear();


            //    for (int i = 0; i < dtAllocate.Rows.Count; i++)
            //    {
            //        grd_order.Rows.Add();
            //        grd_order.Rows[i].Cells[1].Value = i + 1;
            //        grd_order.Rows[i].Cells[2].Value = dtAllocate.Rows[i]["Client_Name"].ToString();
            //        grd_order.Rows[i].Cells[3].Value = dtAllocate.Rows[i]["Sub_ProcessName"].ToString();
            //        grd_order.Rows[i].Cells[4].Value = dtAllocate.Rows[i]["Order_Number"].ToString();
            //        grd_order.Rows[i].Cells[5].Value = dtAllocate.Rows[i]["Order_Type"].ToString();
            //        grd_order.Rows[i].Cells[6].Value = dtAllocate.Rows[i]["STATECOUNTY"].ToString();
            //        grd_order.Rows[i].Cells[7].Value = dtAllocate.Rows[i]["County_Type"].ToString();
            //        grd_order.Rows[i].Cells[8].Value = dtAllocate.Rows[i]["Date"].ToString();
            //        grd_order.Rows[i].Cells[9].Value = dtAllocate.Rows[i]["Order_ID"].ToString();
            //        grd_order.Rows[i].Cells[10].Value = 0;//Not requried its from titlelogy 
            //        grd_order.Rows[i].Cells[11].Value = dtAllocate.Rows[i]["Order_Status"].ToString();
            //        grd_order.Rows[i].Cells[12].Value = dtAllocate.Rows[i]["State"].ToString();
            //        grd_order.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.DarkCyan;
            //        System.Windows.Forms.Application.DoEvents();
            //    }
            //    //  lbl_Remainig_Order.Text = Convert.ToString(dtAllocate.Rows.Count);

            //    for (int j = 0; j < grd_order.Rows.Count; j++)
            //    {
            //        int v1 = int.Parse(grd_order.Rows[j].Cells[10].Value.ToString());
            //        int v2 = int.Parse(grd_order.Rows[j].Cells[11].Value.ToString());
            //        if (v1 == 1 && v2 != 2)
            //        {

            //            grd_order.Rows[j].DefaultCellStyle.BackColor = Color.YellowGreen;

            //        }
            //    }
            //    lbl_Total_Orders.Text = grd_order.Rows.Count.ToString();
            //}
            // else
            //{
            // grd_order.DataSource = null;
            //  grd_order.Rows.Clear();
            //  lbl_Total_Orders.Text = "0";
            // grd_order.EmptyDataText = "No Orders Are Avilable to Allocate";
            // grd_order.DataBind();
            // lbl_Remainig_Order.Text = "0";

            //  }
            // }
            // GridviewOrderUrgent();



        }
        private void Order_Allocate_Load(object sender, EventArgs e)
        {

            //Thread th = new Thread(new ThreadStart(Sub_AddParent));
            //th.Start();
            //Thread th1 = new Thread(new ThreadStart(Gridview_Bind_All_Orders));
            //th1.Start();
            reader = new SpeechSynthesizer();
           
            if (userroleid == "1")
            {
                dbc.BindClient(ddl_Client_Name);
            }
            else if (userroleid == "2")
            { 
            
                dbc.BindClientNo(ddl_Client_Name);
            }
            dbc.BindState(ddl_State);
            dbc.Bind_Order_Progress_FOR_REAALOCATE(ddl_Status);
            dbc.BindUserName_Allocate(ddl_UserName);
            dbc.BindOrderStatus(ddl_Order_Status_Reallocate);
            dbc.Bind_Order_Assign_Type(ddl_County_Type);
            Sub_AddParent();
            grd_order.AllowUserToAddRows = false;
            pnl_help.Visible = false;
            Rb_Task_CheckedChanged( sender,  e);
            dbc.Bind_Vendors(ddl_Vendor_Name);
            if (Order_Process == "SEARCH_ORDER_ALLOCATE")
            {
                lbl_Header.Text = "SEARCH ORDER ALLOCATION";
            }
            else if (Order_Process == "SEARCH_QC_ORDER_ALLOCATE")
            {

                lbl_Header.Text = "SEARCH QC ORDER ALLOCATION";
            }
            else if (Order_Process == "SEARCH_TYPING_ORDER_ALLOCATE")
            {
                lbl_Header.Text = "TYPING ORDER ALLOCATION";

            }
            else if (Order_Process == "TYPING_QC_ORDERS_ALLOCATE")
            {
                lbl_Header.Text = "TYPING QC ORDER ALLOCATION";

            }
            else if (Order_Process == "UPLOAD_ORDERS_ALLOCATE")
            {
                lbl_Header.Text = "UPLOAD ORDER ALLOCATION";

            }
            else if (Order_Process == "FINAL_QC_ORDERS_ALLOCATE")
            {
                lbl_Header.Text = "FINAL QC ORDER ALLOCATION";

            }
            else if (Order_Process == "EXCEPTION_ORDERS_ALLOCATE")
            {
                lbl_Header.Text = "EXCEPTION ORDER ALLOCATION";

            }
            
            else if (Order_Process == "CLARIFICATION_ORDER_ALLOCATE_PENDING")
            {
                lbl_Header.Text = "CLARIFICATION ORDER ALLOCATION";

            }
            else if (Order_Process == "HOLD_ORDER_ALLOCATE_PENDING")
            {

                lbl_Header.Text = "HOLD ORDER ALLOCATION";
            }
            else if (Order_Process == "CANCELLED_ORDER_ALLOCATE_PENDING")
            {
                lbl_Header.Text = "CANCELLED ORDER ALLOCATION";
            }
            else if (Order_Process == "REASSIGNED_ORDER_ALLOCATE_PENDING")
            {
                lbl_Header.Text = "REASSIGNED ORDER ALLOCATION";
            }
            else if (Order_Process == "TAX_ORDERS_ALLOCATE")
            {

                lbl_Header.Text = "TAX ORDER ALLOCATION";
            }
           // grd_order.VirtualMode = true;
            Gridview_Bind_All_Orders();
            if (userroleid == "1")
            {
                btn_Export.Enabled = true;
                btn_user_Export.Enabled = true;
            }
            else
            {
                btn_Export.Enabled = false;
                btn_user_Export.Enabled = false;

            }

            this.Text = lbl_Header.Text;
          
            
        }
        private void Sub_AddParent()
        {

            string sKeyTemp = "User Name";
            string sTempText = "User Name";
            TreeView1.Nodes.Clear();
            // TreeView1.Nodes.Add("User Name", "User Name");
            AddChilds(sKeyTemp);
        }
        private void AddChilds(string sKeyTemp)
        {
            System.Windows.Forms.Button  nodebutton;

           
          
            Hashtable htselect = new Hashtable();
            
         
            htselect.Add("@Trans", "ALL_ORDER_ALLOCATE");
            // htselect.Add("@Subprocess_id", Subprocess_id);
            dtselect = dataaccess.ExecuteSP("Sp_Orders_Que", htselect);
            
            dtchild = gen.FillChildTable();
            for (int i = 0; i < dtchild.Rows.Count; i++)
            {
                TreeView1.Nodes.Add(dtchild.Rows[i]["User_ID"].ToString(), dtchild.Rows[i]["User_Name"].ToString());
                
            }
         

        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (TreeView1.SelectedNode.Text != "")
            {
                var selectedNode = TreeView1.SelectedNode;

                if (selectedNode.Parent == null)
                {
                    int NODE = int.Parse(TreeView1.SelectedNode.Name);
                    Tree_View_UserId = NODE;
                   // Gridview_Bind_All_Orders();
                    btn_Allocate.Enabled = true;
                    Gridview_Bind_Orders_Wise_Treeview_Selected();

                }
                else
                {

                    lbl_allocated_user.Text = TreeView1.SelectedNode.Text;
                    lbl_allocated_user.ForeColor = System.Drawing.Color.DeepPink;
                    Tree_View_UserId = int.Parse(TreeView1.SelectedNode.Name);
                    // ViewState["User_Wise_Count"] = lbl_allocated_user.Text;
                    Gridview_Bind_Orders_Wise_Treeview_Selected();
                    // Restrict_Controls();
                    //  btn_Allocate.CssClass = "Windowbutton";
                    btn_Allocate.Enabled = true;
                    CountCheckedRows(sender, e);

                }
            }
            // GridviewOrderUrgent();
            lbl_allocated_user.Text = TreeView1.SelectedNode.Text;
            lbl_allocated_user.ForeColor = System.Drawing.Color.Black;
            Tree_View_UserId = int.Parse(TreeView1.SelectedNode.Name);
        }
        protected void Gridview_Bind_Orders_Wise_Treeview_Selected()
        {
            if (Tree_View_UserId.ToString() != "")
            {

                Hashtable htuser = new Hashtable();
                System.Data.DataTable dtuser = new System.Data.DataTable();
                htuser.Add("@Trans", "GET_ALL_ALLOCATED_ORDERS");
                htuser.Add("@User_Id", Tree_View_UserId);
                //   htuser.Add("@Subprocess_id", Sub_ProcessName);
                htuser.Add("@Order_Status_Id", Order_Status_Id);
                dtuser = dataaccess.ExecuteSP("Sp_Orders_Que", htuser);
                dtuserexport = dtuser;
                grd_order_Allocated.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkCyan;
                grd_order_Allocated.EnableHeadersVisualStyles = false;
                grd_order_Allocated.Columns[0].Width = 35;
                grd_order_Allocated.Columns[1].Width = 50;
                grd_order_Allocated.Columns[2].Width = 125;
                grd_order_Allocated.Columns[3].Width = 250;
                grd_order_Allocated.Columns[4].Width = 195;
                grd_order_Allocated.Columns[5].Width = 115;
                grd_order_Allocated.Columns[6].Width = 160;
                grd_order_Allocated.Columns[7].Width = 105;
                grd_order_Allocated.Columns[9].Width = 100;
                grd_order_Allocated.Columns[10].Width = 120;
                if (dtuser.Rows.Count > 0)
                {
                    grd_order_Allocated.Rows.Clear();

                    for (int i = 0; i < dtuser.Rows.Count; i++)
                    {
                        grd_order_Allocated.Rows.Add();
                        grd_order_Allocated.Rows[i].Cells[1].Value = i + 1;
                        if (userroleid == "1")
                        {
                            grd_order_Allocated.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Name"].ToString();
                            grd_order_Allocated.Rows[i].Cells[3].Value = dtuser.Rows[i]["Sub_ProcessName"].ToString();
                        }
                        else if (userroleid == "2")
                        {
                            grd_order_Allocated.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Number"].ToString();
                            grd_order_Allocated.Rows[i].Cells[3].Value = dtuser.Rows[i]["Subprocess_Number"].ToString();
                        }
                        grd_order_Allocated.Rows[i].Cells[4].Value = dtuser.Rows[i]["Order_Number"].ToString();
                        grd_order_Allocated.Rows[i].Cells[5].Value = dtuser.Rows[i]["STATECOUNTY"].ToString();
                        grd_order_Allocated.Rows[i].Cells[6].Value = dtuser.Rows[i]["Order_Type"].ToString();
                        grd_order_Allocated.Rows[i].Cells[7].Value = dtuser.Rows[i]["Date"].ToString();
                        grd_order_Allocated.Rows[i].Cells[8].Value = dtuser.Rows[i]["Order_ID"].ToString();
                        grd_order_Allocated.Rows[i].Cells[9].Value = dtuser.Rows[i]["User_Name"].ToString();
                        grd_order_Allocated.Rows[i].Cells[10].Value = dtuser.Rows[i]["Task"].ToString();
                        grd_order_Allocated.Rows[i].Cells[11].Value = dtuser.Rows[i]["User_id"].ToString();
                        grd_order_Allocated.Rows[i].Cells[12].Value = dtuser.Rows[i]["Order_Status"].ToString();
                        grd_order_Allocated.Rows[i].Cells[13].Value = dtuser.Rows[i]["County"].ToString();
                        grd_order_Allocated.Rows[i].Cells[14].Value = dtuser.Rows[i]["Client_Number"].ToString();
                        grd_order_Allocated.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.DarkCyan;
                       
                    }
                }
                else
                {

                    grd_order_Allocated.DataSource = null;
                    grd_order_Allocated.Rows.Clear();

                }

            }
            // GridviewOrderUrgent();
        }
        protected void CountCheckedRows(object sender, EventArgs e)
        {

        }
        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // int NODE = int.Parse(TreeView1.SelectedNode.Name);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      

        private void btn_Allocate_Click(object sender, EventArgs e)
        {
            int CheckedCount = 0;
            if (Tree_View_UserId != 0)
            {


                int allocated_Userid = Tree_View_UserId;



                for (int i = 0; i < grd_order.Rows.Count; i++)
                {
                    bool isChecked = (bool)grd_order[0, i].FormattedValue;

                   // string lbl_Internal_Tax_request_Id = grd_order.Rows[i].Cells[19].Value.ToString();
    

                    //hearer lblInternal_tax Request is indicates to the Order has Sent to Tax Request and Come back for allocation

                    if (isChecked == true &&  Order_Status_Id!=22)
                    {
                        CheckedCount = 1;
                        string lbl_Order_Id = grd_order.Rows[i].Cells[10].Value.ToString();
                        int Client_Id = int.Parse(grd_order.Rows[i].Cells[16].Value.ToString());
                        Hashtable htinsertrec = new Hashtable();
                        System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");

                        int Check_Count;


                    

                            Hashtable htchk_Assign = new Hashtable();
                            System.Data.DataTable dtchk_Assign = new System.Data.DataTable();
                            htchk_Assign.Add("@Trans", "CHECK");
                            htchk_Assign.Add("@Order_Id", lbl_Order_Id);
                            dtchk_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htchk_Assign);
                            if (dtchk_Assign.Rows.Count > 0)
                            {


                                Hashtable htupassin = new Hashtable();
                                System.Data.DataTable dtupassign = new System.Data.DataTable();

                                htupassin.Add("@Trans", "DELET_BY_ORDER");
                                htupassin.Add("@Order_Id", lbl_Order_Id);


                                dtupassign = dataaccess.ExecuteSP("Sp_Order_Assignment", htupassin);
                            }

                        


                        htinsertrec.Add("@Trans", "INSERT");
                        htinsertrec.Add("@Order_Id", lbl_Order_Id);
                        htinsertrec.Add("@User_Id", allocated_Userid);
                        htinsertrec.Add("@Order_Status_Id", Order_Status_Id);
                        htinsertrec.Add("@Order_Progress_Id", 6);
                        htinsertrec.Add("@Assigned_Date", dateeval);
                        htinsertrec.Add("@Assigned_By", User_id);
                        htinsertrec.Add("@Inserted_By", User_id);
                        htinsertrec.Add("@Inserted_date", date);
                        htinsertrec.Add("@status", "True");
                        dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);

                        Hashtable htupdate = new Hashtable();
                        System.Data.DataTable dtupdate = new System.Data.DataTable();
                        htupdate.Add("@Trans", "UPDATE_STATUS");
                        htupdate.Add("@Order_ID", lbl_Order_Id);
                        htupdate.Add("@Order_Status", Order_Status_Id);
                        htupdate.Add("@Modified_By", User_id);
                        htupdate.Add("@Modified_Date", date);
                        dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);
                        Hashtable htprogress = new Hashtable();
                        System.Data.DataTable dtprogress = new System.Data.DataTable();
                        htprogress.Add("@Trans", "UPDATE_PROGRESS");
                        htprogress.Add("@Order_ID", lbl_Order_Id);
                        htprogress.Add("@Order_Progress", 6);
                        htprogress.Add("@Modified_By", User_id);
                        htprogress.Add("@Modified_Date", date);
                        dtprogress = dataaccess.ExecuteSP("Sp_Order", htprogress);
                        Hashtable ht_Update_Emp_Status = new Hashtable();
                        System.Data.DataTable dt_Update_Emp_Status = new System.Data.DataTable();
                        ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                        ht_Update_Emp_Status.Add("@Employee_Id", allocated_Userid);
                        ht_Update_Emp_Status.Add("@Allocate_Status", "True");
                        dt_Update_Emp_Status = dataaccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);

                        //OrderHistory
                        Hashtable ht_Order_History = new Hashtable();
                        System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                        ht_Order_History.Add("@Trans", "INSERT");
                        ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                        ht_Order_History.Add("@User_Id", allocated_Userid);
                        ht_Order_History.Add("@Status_Id", Order_Status_Id);
                        ht_Order_History.Add("@Progress_Id", 6);
                        ht_Order_History.Add("@Work_Type", 1);
                        ht_Order_History.Add("@Assigned_By", User_id);
                        ht_Order_History.Add("@Modification_Type", "Order Allocate");
                        dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);


                        //==================================External Client_Vendor_Orders=====================================================


                        Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                        System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                        htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                        htCheck_Order_InTitlelogy.Add("@Order_ID", lbl_Order_Id);
                        dt_Order_InTitleLogy = dataaccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                        if (dt_Order_InTitleLogy.Rows.Count > 0)
                        {

                            External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                            External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());



                            if (External_Client_Order_Task_Id != 18 && Client_Id!=33)
                            {
                                Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_TASK_STATUS");
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Task", Order_Status_Id);
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Status", 14);

                                dt_TitleLogy_Order_Task_Status = dataaccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);
                            }




                        }





                        //TreeView1.SelectedNode.Value =ViewState["User_Id"].ToString();
                        //   lbl_allocated_user.Text = ViewState["User_Wise_Count"].ToString();
                        //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('Order Reallocated Successfully')</script>", false);

                    }


                    // Internal Tax Order Assigning to Users

                    else if (isChecked == true &&  Order_Status_Id==22)
                    {

                        CheckedCount = 1;
                        string lbl_Order_Id = grd_order.Rows[i].Cells[10].Value.ToString();
                        Hashtable htinsertrec = new Hashtable();
                        System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");

                        int Check_Count;

                        Hashtable htchk_Assign = new Hashtable();
                        System.Data.DataTable dtchk_Assign = new System.Data.DataTable();
                        htchk_Assign.Add("@Trans", "CHECK");
                        htchk_Assign.Add("@Order_Id", lbl_Order_Id);
                        dtchk_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htchk_Assign);
                        if (dtchk_Assign.Rows.Count > 0)
                        {


                            Hashtable htupassin = new Hashtable();
                            System.Data.DataTable dtupassign = new System.Data.DataTable();

                            htupassin.Add("@Trans", "DELET_BY_ORDER");
                            htupassin.Add("@Order_Id", lbl_Order_Id);


                            dtupassign = dataaccess.ExecuteSP("Sp_Order_Assignment", htupassin);
                        }




                        htinsertrec.Add("@Trans", "INSERT");
                        htinsertrec.Add("@Order_Id", lbl_Order_Id);
                        htinsertrec.Add("@User_Id", allocated_Userid);
                        htinsertrec.Add("@Order_Status_Id", 22);// for internal tax Order Assign
                        htinsertrec.Add("@Order_Progress_Id", 6);
                        htinsertrec.Add("@Assigned_Date", dateeval);
                        htinsertrec.Add("@Assigned_By", User_id);
                        htinsertrec.Add("@Inserted_By", User_id);
                        htinsertrec.Add("@Inserted_date", date);
                        htinsertrec.Add("@status", "True");
                        dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);

                        //Updtating Internal Tax Order Status in Tbl_Order Table
                        Hashtable htupdate = new Hashtable();
                        System.Data.DataTable dtupdate = new System.Data.DataTable();
                        htupdate.Add("@Trans", "UPDATE_INTERNAL_TAX_STATUS");
                        htupdate.Add("@Order_ID", lbl_Order_Id);
                        htupdate.Add("@Search_Tax_Req_Inhouse_Status", 6);
                        htupdate.Add("@Modified_By", User_id);
                        htupdate.Add("@Modified_Date", date);
                        dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);

           
                  

                        //OrderHistory
                        Hashtable ht_Order_History = new Hashtable();
                        System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                        ht_Order_History.Add("@Trans", "INSERT");
                        ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                        ht_Order_History.Add("@User_Id", allocated_Userid);
                        ht_Order_History.Add("@Status_Id", 22);
                        ht_Order_History.Add("@Progress_Id", 6);
                        ht_Order_History.Add("@Work_Type", 1);
                        ht_Order_History.Add("@Assigned_By", User_id);
                        ht_Order_History.Add("@Modification_Type", "Order Assigned For tax");
                        dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);







                    }


                }
                if (CheckedCount >= 1)
                {
                    MessageBox.Show("Order Allocated Successfully");
                }
                Gridview_Bind_All_Orders();
                Gridview_Bind_Orders_Wise_Selected();
                //  Restrict_Controls();
                Sub_AddParent();
            }
            
        }
        protected void Gridview_Bind_Orders_Wise_Selected()
        {
            if (Tree_View_UserId.ToString() != "")
            {

                Hashtable htuser = new Hashtable();
                System.Data.DataTable dtuser = new System.Data.DataTable();
                htuser.Add("@Trans", "GET_ALL_ALLOCATED_ORDERS");
                htuser.Add("@User_Id", Tree_View_UserId);
                //  htuser.Add("@Subprocess_id", Subprocess_id);
                htuser.Add("@Order_Status_Id", Order_Status_Id);

                dtuser = dataaccess.ExecuteSP("Sp_Orders_Que", htuser);
                if (dtuser.Rows.Count > 0)
                {
                    grd_order_Allocated.Rows.Clear();
                    for (int i = 0; i < dtuser.Rows.Count; i++)
                    {
                        grd_order_Allocated.Rows.Add();
                        grd_order_Allocated.Rows[i].Cells[1].Value = i + 1;
                        grd_order_Allocated.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Name"].ToString();
                        grd_order_Allocated.Rows[i].Cells[3].Value = dtuser.Rows[i]["Sub_ProcessName"].ToString();
                        grd_order_Allocated.Rows[i].Cells[4].Value = dtuser.Rows[i]["Order_Number"].ToString();
                        grd_order_Allocated.Rows[i].Cells[5].Value = dtuser.Rows[i]["STATECOUNTY"].ToString();
                        grd_order_Allocated.Rows[i].Cells[6].Value = dtuser.Rows[i]["Order_Type"].ToString();
                        grd_order_Allocated.Rows[i].Cells[7].Value = dtuser.Rows[i]["Date"].ToString();
                        grd_order_Allocated.Rows[i].Cells[8].Value = dtuser.Rows[i]["Order_ID"].ToString();
                        grd_order_Allocated.Rows[i].Cells[9].Value = dtuser.Rows[i]["User_Name"].ToString();
                        grd_order_Allocated.Rows[i].Cells[10].Value = dtuser.Rows[i]["Task"].ToString();
                        grd_order_Allocated.Rows[i].Cells[11].Value = dtuser.Rows[i]["User_id"].ToString();
                        grd_order_Allocated.Rows[i].Cells[12].Value = dtuser.Rows[i]["Order_Status"].ToString();
                        grd_order_Allocated.Rows[i].Cells[13].Value = dtuser.Rows[i]["County"].ToString();

                    }

                }
                else
                {

                    grd_order_Allocated.DataSource = null;

                    grd_order_Allocated.Rows.Clear();
                }
                //GridviewOrderUrgent();
            }


        }

        private void grd_order_MouseDown(object sender, MouseEventArgs e)
        {
          

        }

        private void TreeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewSelectedRowCollection)))
            {
                e.Effect = DragDropEffects.Move;
            }
            // MouseEnterNode = int.Parse(TreeView1.SelectedNode.Name);
        }

        private void TreeView1_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode dropNode = this.TreeView1.GetNodeAt(this.TreeView1.PointToClient(new System.Drawing.Point (e.X, e.Y)));
            dropNode.BackColor = System.Drawing.Color.DarkGreen;

            Tree_View_UserId = int.Parse(dropNode.Name);

            DataGridViewSelectedRowCollection rows = (DataGridViewSelectedRowCollection)e.Data.GetData(typeof(DataGridViewSelectedRowCollection));
            int CheckedCount = 0;
            foreach (DataGridViewRow row in rows)
            {
                CheckedCount = 1;
                // string lbl_Order_Id = grd_order.Rows[i].Cells[8].Value.ToString();
                Hashtable htinsertrec = new Hashtable();
                System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                DateTime date = new DateTime();
                date = DateTime.Now;
                string dateeval = date.ToString("dd/MM/yyyy");
                string time = date.ToString("hh:mm tt");
                htinsertrec.Add("@Trans", "INSERT");
                htinsertrec.Add("@Order_Id", row.Cells[8].Value);
                htinsertrec.Add("@User_Id", Tree_View_UserId);
                htinsertrec.Add("@Order_Status_Id", Order_Status_Id);
                htinsertrec.Add("@Order_Progress_Id", 6);
                htinsertrec.Add("@Assigned_Date", dateeval);
                htinsertrec.Add("@Assigned_By", User_id);
                htinsertrec.Add("@Inserted_By", User_id);
                htinsertrec.Add("@Inserted_date", date);
                htinsertrec.Add("@status", "True");
                dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);

                Hashtable htUpdate_assign = new Hashtable();
                System.Data.DataTable dtUpdate_assign = new System.Data.DataTable();
                htUpdate_assign.Add("@Trans", "UPDATE_REALLOCATE");
                htUpdate_assign.Add("@Order_Id", row.Cells[8].Value);
                htUpdate_assign.Add("@User_Id", Tree_View_UserId);
                htUpdate_assign.Add("@Assigned_Date", dateeval);
                htUpdate_assign.Add("@Assigned_By", User_id);
                htUpdate_assign.Add("@Modified_By", User_id);
                htUpdate_assign.Add("@Modified_Date", date);
                dtUpdate_assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htUpdate_assign);
            
                Hashtable htupdate = new Hashtable();
                System.Data.DataTable dtupdate = new System.Data.DataTable();
                htupdate.Add("@Trans", "UPDATE_STATUS");
                htupdate.Add("@Order_ID", row.Cells[8].Value);
                htupdate.Add("@Order_Status", Order_Status_Id);
                htupdate.Add("@Modified_By", User_id);
                htupdate.Add("@Modified_Date", date);
                dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);
                Hashtable htprogress = new Hashtable();
                System.Data.DataTable dtprogress = new System.Data.DataTable();
                htprogress.Add("@Trans", "UPDATE_PROGRESS");
                htprogress.Add("@Order_ID", row.Cells[8].Value);
                htprogress.Add("@Order_Progress", 6);
                htprogress.Add("@Modified_By", User_id);
                htprogress.Add("@Modified_Date", date);
                dtprogress = dataaccess.ExecuteSP("Sp_Order", htprogress);
                Hashtable ht_Update_Emp_Status = new Hashtable();
                System.Data.DataTable dt_Update_Emp_Status = new System.Data.DataTable();
                ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                ht_Update_Emp_Status.Add("@Employee_Id", Tree_View_UserId);
                ht_Update_Emp_Status.Add("@Allocate_Status", "True");
                dt_Update_Emp_Status = dataaccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);

                //OrderHistory
                Hashtable ht_Order_History = new Hashtable();
                System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                ht_Order_History.Add("@Trans", "INSERT");
                ht_Order_History.Add("@Order_Id", row.Cells[8].Value);
                ht_Order_History.Add("@User_Id", Tree_View_UserId);
                ht_Order_History.Add("@Status_Id", Order_Status_Id);
                ht_Order_History.Add("@Progress_Id", 6);
                ht_Order_History.Add("@Assigned_By", User_id);
                ht_Order_History.Add("@Modification_Type", "Order Allocate");
                dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);

            }
            if (CheckedCount >= 1)
            {
                MessageBox.Show("Order Allocated Successfully");
            }
            Gridview_Bind_All_Orders();
            Gridview_Bind_Orders_Wise_Selected();
            //  Restrict_Controls();
            Sub_AddParent();

        }

        private void TreeView1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void TreeView1_MouseEnter(object sender, EventArgs e)
        {
            
           
        }

        private void grd_order_Allocated_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

     

        private void btn_Reallocate_Click(object sender, EventArgs e)
        {
            int Check_Count = 0;
            if (ddl_Order_Status_Reallocate.Text != "SELECT" && ddl_UserName.Text != "SELECT")
            {
                for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                {
                    bool isChecked = (bool)grd_order_Allocated[0, i].FormattedValue;


                    int Reallocateduser = int.Parse(ddl_UserName.SelectedValue.ToString());

                    System.Windows.Forms.CheckBox chk = (grd_order_Allocated.Rows[i].Cells[0].FormattedValue as System.Windows.Forms.CheckBox);
                   
                    // CheckBox chk = (CheckBox)row.f("chkAllocatedSelect");
                    if (isChecked == true)
                    {
                        Check_Count = 1;
                        string lbl_Order_Id = grd_order_Allocated.Rows[i].Cells[8].Value.ToString();
                        string lbl_County_ID = grd_order_Allocated.Rows[i].Cells[13].Value.ToString();
                        string lbl_Allocated_Userid = grd_order_Allocated.Rows[i].Cells[11].Value.ToString();
                        string Client_Number = grd_order_Allocated.Rows[i].Cells[14].Value.ToString();
                        Hashtable htget_User_Order_Last_Time_Updaetd = new Hashtable();
                        System.Data.DataTable dtget_User_Order_Last_Time_Updated = new System.Data.DataTable();

                        htget_User_Order_Last_Time_Updaetd.Add("@Trans", "MAX_TIME_BY_ORDER_ID");
                        htget_User_Order_Last_Time_Updaetd.Add("@Order_Id", lbl_Order_Id);
                        dtget_User_Order_Last_Time_Updated = dataaccess.ExecuteSP("[Sp_Order_User_Wise_Time_Track]", htget_User_Order_Last_Time_Updaetd);

                        if (dtget_User_Order_Last_Time_Updated.Rows.Count > 0)
                        {
                            Max_Time_Id = int.Parse(dtget_User_Order_Last_Time_Updated.Rows[0]["MAX_TIME_ID"].ToString());

                        }
                        else
                        {

                            Max_Time_Id = 0;
                        }

                        if (Max_Time_Id != 0)
                        {

                            Hashtable htget_User_Order_Differnce_Time = new Hashtable();
                            System.Data.DataTable dtget_User_Order_Differnce_Time = new System.Data.DataTable();
                            htget_User_Order_Differnce_Time.Add("@Trans", "GET_DIFFERNCE_TIME");
                            htget_User_Order_Differnce_Time.Add("@Order_Time_Id", Max_Time_Id);
                            dtget_User_Order_Differnce_Time = dataaccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htget_User_Order_Differnce_Time);

                            if (dtget_User_Order_Differnce_Time.Rows.Count > 0)
                            {
                                Differnce_Time = int.Parse(dtget_User_Order_Differnce_Time.Rows[0]["Diff"].ToString());

                            }
                            else
                            {
                                Differnce_Time = 0;

                            }

                            //htget_User_Order_Differnce_Time.Add("","");
                        }


                        if (Differnce_Time < 5)
                        {

                            Differnce_Count = 1;

                        }


                        if (Differnce_Time > 5)
                        {



                            Hashtable htchk_Assign = new Hashtable();
                            System.Data.DataTable dtchk_Assign = new System.Data.DataTable();
                            htchk_Assign.Add("@Trans", "ORDER_ASSIGN_VERIFY");
                            htchk_Assign.Add("@Order_Id", lbl_Order_Id);
                            dtchk_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htchk_Assign);
                            if (dtchk_Assign.Rows.Count <= 0)
                            {
                                Hashtable htupassin = new Hashtable();
                                System.Data.DataTable dtupassign = new System.Data.DataTable();

                                htupassin.Add("@Trans", "DELET_BY_ORDER");
                                htupassin.Add("@Order_Id", lbl_Order_Id);

                                dtupassign = dataaccess.ExecuteSP("Sp_Order_Assignment", htupassin);

                                Hashtable htinsert_Assign = new Hashtable();
                                System.Data.DataTable dtinsertrec_Assign = new System.Data.DataTable();
                                htinsert_Assign.Add("@Trans", "INSERT");
                                htinsert_Assign.Add("@Order_Id", lbl_Order_Id);
                                //  htinsert_Assign.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                                // htinsert_Assign.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                //  htinsert_Assign.Add("@Order_Progress_Id", 6);
                                // htinsert_Assign.Add("@Assigned_Date", Convert.ToString(dateeval));
                                htinsert_Assign.Add("@Assigned_By", User_id);
                                htinsert_Assign.Add("@Modified_By", User_id);
                                htinsert_Assign.Add("@Modified_Date", DateTime.Now);
                                htinsert_Assign.Add("@status", "True");
                                dtinsertrec_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsert_Assign);
                            }
                            //  int Allocated_Userid = int.Parse(lbl_Allocated_Userid.Text);

                            Hashtable htinsertrec = new Hashtable();
                            System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                            DateTime date = new DateTime();
                            date = DateTime.Now;
                            string dateeval = date.ToString("dd/MM/yyyy");
                            string time = date.ToString("hh:mm tt");

                            htinsertrec.Add("@Trans", "UPDATE_REALLOCATE");
                            htinsertrec.Add("@Order_Id", lbl_Order_Id);
                            htinsertrec.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            htinsertrec.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            htinsertrec.Add("@Order_Progress_Id", 6);
                            htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
                            htinsertrec.Add("@Assigned_By", User_id);
                            htinsertrec.Add("@Modified_By", User_id);
                            htinsertrec.Add("@Modified_Date", DateTime.Now);
                            htinsertrec.Add("@status", "True");
                            dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);

                            Hashtable htcountyType = new Hashtable();
                            System.Data.DataTable dtcountytype = new System.Data.DataTable();
                            htcountyType.Add("@Trans", "GET_COUNTY_TYPE");
                            htcountyType.Add("@County", lbl_County_ID);

                            dtcountytype = dataaccess.ExecuteSP("Sp_Order", htcountyType);

                            if (dtcountytype.Rows.Count > 0)
                            {

                                County_Type = dtcountytype.Rows[0]["County_Type"].ToString();

                            }

                            Hashtable htcheckabbstract = new Hashtable();
                            System.Data.DataTable dtcheckabbstract = new System.Data.DataTable();
                            htcheckabbstract.Add("@Trans", "GET_ABSTRACTOR_CHECK");
                            htcheckabbstract.Add("@Order_ID", lbl_Order_Id);

                            dtcheckabbstract = dataaccess.ExecuteSP("Sp_Order", htcheckabbstract);

                            if (dtcheckabbstract.Rows.Count > 0)
                            {

                                Abstractor_Check = Convert.ToBoolean(dtcheckabbstract.Rows[0]["Abstractor_Chk"].ToString());

                            }

                            if (County_Type == "TIER 2" && Abstractor_Check == false)
                            {

                                Hashtable htupdateabstractcheck = new Hashtable();
                                System.Data.DataTable dtupdateabstractcheck = new System.Data.DataTable();
                                htupdateabstractcheck.Add("@Trans", "UPDATE_ABSTRACTOR_CHECK");
                                htupdateabstractcheck.Add("@Order_ID", lbl_Order_Id);
                                dtupdateabstractcheck = dataaccess.ExecuteSP("Sp_Order", htupdateabstractcheck);
                            }


                            Hashtable htorderStatus = new Hashtable();
                            System.Data.DataTable dtorderStatus = new System.Data.DataTable();
                            htorderStatus.Add("@Trans", "UPDATE_STATUS");
                            htorderStatus.Add("@Order_ID", lbl_Order_Id);
                            htorderStatus.Add("@Order_Status", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            htorderStatus.Add("@Modified_By", User_id);
                            htorderStatus.Add("@Modified_Date", date);
                            dtorderStatus = dataaccess.ExecuteSP("Sp_Order", htorderStatus);

                            Hashtable htorderStatus_Allocate = new Hashtable();
                            System.Data.DataTable dtorderStatus_Allocate = new System.Data.DataTable();
                            htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
                            htorderStatus_Allocate.Add("@Order_ID", lbl_Order_Id);
                            htorderStatus_Allocate.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            htorderStatus_Allocate.Add("@Modified_By", User_id);
                            htorderStatus_Allocate.Add("@Assigned_Date", Convert.ToString(dateeval));
                            htorderStatus_Allocate.Add("@Assigned_By", User_id);
                            htorderStatus_Allocate.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            htorderStatus_Allocate.Add("@Modified_Date", date);
                            dtorderStatus_Allocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htorderStatus_Allocate);

                            Hashtable htupdate_Prog = new Hashtable();
                            System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                            htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                            htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                            htupdate_Prog.Add("@Order_Progress", 6);
                            htupdate_Prog.Add("@Modified_By", User_id);
                            htupdate_Prog.Add("@Modified_Date", DateTime.Now);
                            dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);


                            //OrderHistory
                            Hashtable ht_Order_History = new Hashtable();
                            System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                            ht_Order_History.Add("@Trans", "INSERT");
                            ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                            ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            ht_Order_History.Add("@Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            ht_Order_History.Add("@Progress_Id", 6);
                            ht_Order_History.Add("@Assigned_By", User_id);
                            ht_Order_History.Add("@Modification_Type", "Order Reallocate");
                            dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);



                            //==================================External Client_Vendor_Orders(Titlelogy)=====================================================


                            Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                            System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                            htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                            htCheck_Order_InTitlelogy.Add("@Order_ID", lbl_Order_Id);
                            dt_Order_InTitleLogy = dataaccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                            if (dt_Order_InTitleLogy.Rows.Count > 0)
                            {

                                External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                                External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());



                                if (External_Client_Order_Task_Id != 18 && Client_Number!="32000")
                                {

                                    Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                    System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                    ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_TASK_STATUS");
                                    ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                    ht_Titlelogy_Order_Task_Status.Add("@Order_Task", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                    ht_Titlelogy_Order_Task_Status.Add("@Order_Status", 14);

                                    dt_TitleLogy_Order_Task_Status = dataaccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);

                                }



                            }



                            Gridview_Bind_All_Orders();
                            // PopulateTreeview();

                            Hashtable ht_Update_Emp_Status = new Hashtable();
                            System.Data.DataTable dt_Update_Emp_Status = new System.Data.DataTable();
                            ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                            ht_Update_Emp_Status.Add("@Employee_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            ht_Update_Emp_Status.Add("@Allocate_Status", "True");
                            dt_Update_Emp_Status = dataaccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);




                        }
                    }
                }

                if (Check_Count >= 1)
                {
                    if (Differnce_Count != 1)
                    {
                        MessageBox.Show("Order Reallocated Successfully");
                    }
                    else
                    {

                        MessageBox.Show("Some Orders Were not Reallocated beacuse of Orders are Work in Progress");
                    }
                    ddl_Status.SelectedIndex = 0;
                    ddl_Order_Status_Reallocate.SelectedIndex = 0;
                    ddl_UserName.SelectedIndex = 0;
                }

                }
            
            else if (ddl_Order_Status_Reallocate.Text == "SELECT" && ddl_UserName.Text != "SELECT")
            {


                for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                {
                    bool isChecked = (bool)grd_order_Allocated[0, i].FormattedValue;



                    int Reallocateduser = int.Parse(ddl_UserName.SelectedValue.ToString());

                    //bool Check = (Boolean)((DataGridViewCheckBoxCell)row.Cells[0]).FormattedValue;

                    //System.Windows.Forms.CheckBox chk = (row.Cells[0].FormattedValue as System.Windows.Forms.CheckBox);

                    if (isChecked == true)
                    {

                        string lbl_Order_Id = grd_order_Allocated.Rows[i].Cells[8].Value.ToString();
                        string lbl_County_ID = grd_order_Allocated.Rows[i].Cells[13].Value.ToString();
                        string lbl_Allocated_Userid = grd_order_Allocated.Rows[i].Cells[11].Value.ToString();
                        string Lbl_Staus_id = grd_order_Allocated.Rows[i].Cells[12].Value.ToString();
                        int Allocated_Userid = int.Parse(lbl_Allocated_Userid);


                        Hashtable htchk_Assign = new Hashtable();
                        System.Data.DataTable dtchk_Assign = new System.Data.DataTable();
                        htchk_Assign.Add("@Trans", "ORDER_ASSIGN_VERIFY");
                        htchk_Assign.Add("@Order_Id", lbl_Order_Id);
                        dtchk_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htchk_Assign);
                        if (dtchk_Assign.Rows.Count <= 0)
                        {
                            Hashtable htinsert_Assign = new Hashtable();
                            System.Data.DataTable dtinsertrec_Assign = new System.Data.DataTable();
                            htinsert_Assign.Add("@Trans", "INSERT");
                            htinsert_Assign.Add("@Order_Id", lbl_Order_Id);
                            //  htinsert_Assign.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            // htinsert_Assign.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            //  htinsert_Assign.Add("@Order_Progress_Id", 6);
                            // htinsert_Assign.Add("@Assigned_Date", Convert.ToString(dateeval));
                            htinsert_Assign.Add("@Assigned_By", User_id);
                            htinsert_Assign.Add("@Modified_By", User_id);
                            htinsert_Assign.Add("@Modified_Date", DateTime.Now);
                            htinsert_Assign.Add("@status", "True");
                            dtinsertrec_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsert_Assign);
                        }




                        Hashtable htinsertrec = new Hashtable();
                        System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");

                        htinsertrec.Add("@Trans", "UPDATE_REALLOCATE");
                        htinsertrec.Add("@Order_Id", lbl_Order_Id);
                        htinsertrec.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        htinsertrec.Add("@Order_Progress_Id", 6);
                        htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
                        htinsertrec.Add("@Assigned_By", User_id);
                        htinsertrec.Add("@Modified_By", User_id);
                        htinsertrec.Add("@Modified_Date", DateTime.Now);
                        htinsertrec.Add("@status", "True");
                        dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);


                        Hashtable htcountyType = new Hashtable();
                        System.Data.DataTable dtcountytype = new System.Data.DataTable();
                        htcountyType.Add("@Trans", "GET_COUNTY_TYPE");
                        htcountyType.Add("@County", lbl_County_ID);

                        dtcountytype = dataaccess.ExecuteSP("Sp_Order", htcountyType);

                        if (dtcountytype.Rows.Count > 0)
                        {

                            County_Type = dtcountytype.Rows[0]["County_Type"].ToString();

                        }

                        Hashtable htcheckabbstract = new Hashtable();
                        System.Data.DataTable dtcheckabbstract = new System.Data.DataTable();
                        htcheckabbstract.Add("@Trans", "GET_ABSTRACTOR_CHECK");
                        htcheckabbstract.Add("@Order_ID", lbl_Order_Id);

                        dtcheckabbstract = dataaccess.ExecuteSP("Sp_Order", htcheckabbstract);

                        if (dtcheckabbstract.Rows.Count > 0)
                        {

                            Abstractor_Check = Convert.ToBoolean(dtcheckabbstract.Rows[0]["Abstractor_Chk"].ToString());

                        }

                        if (County_Type == "TIER 2" && Abstractor_Check == false)
                        {

                            Hashtable htupdateabstractcheck = new Hashtable();
                            System.Data.DataTable dtupdateabstractcheck = new System.Data.DataTable();
                            htupdateabstractcheck.Add("@Trans", "UPDATE_ABSTRACTOR_CHECK");
                            htupdateabstractcheck.Add("@Order_ID", lbl_Order_Id);
                            dtupdateabstractcheck = dataaccess.ExecuteSP("Sp_Order", htupdateabstractcheck);
                        }

                        Hashtable ht_Update_Emp_Status = new Hashtable();
                        System.Data.DataTable dt_Update_Emp_Status = new System.Data.DataTable();
                        ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                        ht_Update_Emp_Status.Add("@Employee_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        ht_Update_Emp_Status.Add("@Allocate_Status", "True");
                        dt_Update_Emp_Status = dataaccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);

                        Hashtable htupdate_Prog = new Hashtable();
                        System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                        htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                        htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                        htupdate_Prog.Add("@Order_Progress", 6);
                        htupdate_Prog.Add("@Modified_By", User_id);
                        htupdate_Prog.Add("@Modified_Date", DateTime.Now);

                        dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);

                        Gridview_Bind_All_Orders();

                        //PopulateTreeview();
                        MessageBox.Show("Order Reallocated Successfully");
                        ddl_Status.SelectedIndex = 0;
                        ddl_Order_Status_Reallocate.SelectedIndex = 0;
                        ddl_UserName.SelectedIndex = 0;

                    }

                }
            }
            else if (ddl_Order_Status_Reallocate.Text != "SELECT" && ddl_UserName.Text == "SELECT")
            {
                for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                {
                    bool isChecked = (bool)grd_order_Allocated[0, i].FormattedValue;

                  //  System.Windows.Forms.CheckBox chk = (row.Cells[0].FormattedValue as System.Windows.Forms.CheckBox);
                    if (isChecked == true)
                    {

                        string lbl_Order_Id = grd_order_Allocated.Rows[i].Cells[8].Value.ToString();
                        string lbl_County_ID = grd_order_Allocated.Rows[i].Cells[13].Value.ToString();
                        string lbl_Allocated_Userid = grd_order_Allocated.Rows[i].Cells[11].Value.ToString();
                        string Lbl_Staus_id = grd_order_Allocated.Rows[i].Cells[12].Value.ToString();
                        Hashtable htchk_Assign = new Hashtable();
                        System.Data.DataTable dtchk_Assign = new System.Data.DataTable();
                        htchk_Assign.Add("@Trans", "ORDER_ASSIGN_VERIFY");
                        htchk_Assign.Add("@Order_Id", lbl_Order_Id);
                        dtchk_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htchk_Assign);
                        if (dtchk_Assign.Rows.Count <= 0)
                        {
                            Hashtable htinsert_Assign = new Hashtable();
                            System.Data.DataTable dtinsertrec_Assign = new System.Data.DataTable();
                            htinsert_Assign.Add("@Trans", "INSERT");
                            htinsert_Assign.Add("@Order_Id", lbl_Order_Id);
                            //  htinsert_Assign.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            // htinsert_Assign.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            //  htinsert_Assign.Add("@Order_Progress_Id", 6);
                            // htinsert_Assign.Add("@Assigned_Date", Convert.ToString(dateeval));
                            htinsert_Assign.Add("@Assigned_By", User_id);
                            htinsert_Assign.Add("@Modified_By", User_id);
                            htinsert_Assign.Add("@Modified_Date", DateTime.Now);
                            htinsert_Assign.Add("@status", "True");
                            dtinsertrec_Assign = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsert_Assign);
                        }
                        //  Label Lbl_Staus_id = (Label)row.FindControl("Lbl_Staus_id");
                        // int Allocated_Userid = int.Parse(lbl_Allocated_Userid.Text);

                        Hashtable htinsertrec = new Hashtable();
                        System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");

                        htinsertrec.Add("@Trans", "UPDATE_REALLOCATE");
                        htinsertrec.Add("@Order_Id", lbl_Order_Id);
                        htinsertrec.Add("@User_Id", lbl_Allocated_Userid);
                        htinsertrec.Add("@Order_Progress_Id", 6);
                        htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
                        htinsertrec.Add("@Assigned_By", User_id);
                        htinsertrec.Add("@Modified_By", User_id);
                        htinsertrec.Add("@Modified_Date", DateTime.Now);
                        htinsertrec.Add("@status", "True");
                        dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);

                        Hashtable htcountyType = new Hashtable();
                        System.Data.DataTable dtcountytype = new System.Data.DataTable();
                        htcountyType.Add("@Trans", "GET_COUNTY_TYPE");
                        htcountyType.Add("@County", lbl_County_ID);

                        dtcountytype = dataaccess.ExecuteSP("Sp_Order", htcountyType);

                        if (dtcountytype.Rows.Count > 0)
                        {

                            County_Type = dtcountytype.Rows[0]["County_Type"].ToString();

                        }

                        Hashtable htcheckabbstract = new Hashtable();
                        System.Data.DataTable dtcheckabbstract = new System.Data.DataTable();
                        htcheckabbstract.Add("@Trans", "GET_ABSTRACTOR_CHECK");
                        htcheckabbstract.Add("@Order_ID", lbl_Order_Id);

                        dtcheckabbstract = dataaccess.ExecuteSP("Sp_Order", htcheckabbstract);

                        if (dtcheckabbstract.Rows.Count > 0)
                        {

                            Abstractor_Check = Convert.ToBoolean(dtcheckabbstract.Rows[0]["Abstractor_Chk"].ToString());

                        }

                        if (County_Type == "TIER 2" && Abstractor_Check == false)
                        {

                            Hashtable htupdateabstractcheck = new Hashtable();
                            System.Data.DataTable dtupdateabstractcheck = new System.Data.DataTable();
                            htupdateabstractcheck.Add("@Trans", "UPDATE_ABSTRACTOR_CHECK");
                            htupdateabstractcheck.Add("@Order_ID", lbl_Order_Id);
                            dtupdateabstractcheck = dataaccess.ExecuteSP("Sp_Order", htupdateabstractcheck);
                        }

                        Hashtable ht_Update_Emp_Status = new Hashtable();
                        System.Data.DataTable dt_Update_Emp_Status = new System.Data.DataTable();
                        ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                        ht_Update_Emp_Status.Add("@Employee_Id", int.Parse(lbl_Allocated_Userid));
                        ht_Update_Emp_Status.Add("@Allocate_Status", "False");
                        dt_Update_Emp_Status = dataaccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);

                        Hashtable htorderStatus = new Hashtable();
                        System.Data.DataTable dtorderStatus = new System.Data.DataTable();
                        htorderStatus.Add("@Trans", "UPDATE_STATUS");
                        htorderStatus.Add("@Order_ID", lbl_Order_Id);
                        htorderStatus.Add("@Order_Status", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus.Add("@Modified_By", User_id);
                        htorderStatus.Add("@Modified_Date", date);
                        dtorderStatus = dataaccess.ExecuteSP("Sp_Order", htorderStatus);
                        Hashtable htorderStatus_Allocate = new Hashtable();
                        System.Data.DataTable dtorderStatus_Allocate = new System.Data.DataTable();
                        htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
                        htorderStatus_Allocate.Add("@Order_ID", lbl_Order_Id);
                        htorderStatus_Allocate.Add("@User_Id", lbl_Allocated_Userid);
                        htorderStatus_Allocate.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_By", User_id);
                        htorderStatus_Allocate.Add("@Modified_Date", date);
                        dtorderStatus_Allocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htorderStatus_Allocate);

                        Hashtable htupdate_Prog = new Hashtable();
                        System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                        htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                        htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                        htupdate_Prog.Add("@Order_Progress", 6);
                        htupdate_Prog.Add("@Modified_By", User_id);
                        htupdate_Prog.Add("@Modified_Date", DateTime.Now);

                        dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);
                        MessageBox.Show("Order Reallocated Successfully");

                        Gridview_Bind_All_Orders();
                        ddl_Status.SelectedIndex = 0;
                        ddl_Order_Status_Reallocate.SelectedIndex = 0;
                        ddl_UserName.SelectedIndex = 0;
                        //  PopulateTreeview();
                    }

                }
            }

            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "<script> alert('Select User Name To Reallocate')</script>;", false);

            //}
            grd_order_Allocated.DataSource = null;
            Gridview_Bind_All_Orders();
            Gridview_Bind_Orders_Wise_Selected();
            //  Restrict_Controls();
            Sub_AddParent();
            //grd_order_Allocated.DataBind();
        }

        private void grd_order_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void grd_order_MouseEnter(object sender, EventArgs e)
        {

        }

        private void grd_order_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewSelectedRowCollection)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void grd_order_DragDrop(object sender, DragEventArgs e)
        {
            //DataGridViewSelectedRowCollection rows = (DataGridViewSelectedRowCollection)e.Data.GetData(typeof(DataGridViewSelectedRowCollection));
            //int CheckedCount = 0;
            //foreach (DataGridViewRow row in rows)
            //{
             
            //    string lbl_Order_Id = row.Cells[8].Value.ToString();
            //    int Allocated_Userid = 0;
            //    string Lbl_Staus_id = "";
            //    if (row.Cells[11].Value != null)
            //    {
            //        string lbl_Allocated_Userid = row.Cells[11].Value.ToString();
            //        Lbl_Staus_id = row.Cells[12].Value.ToString();

            //        Allocated_Userid = int.Parse(lbl_Allocated_Userid);
            //    }
            //    if (Lbl_Staus_id != "")
            //    {
            //        CheckedCount = 1;
            //        Hashtable htinsertrec = new Hashtable();
            //        DataTable dtinsertrec = new System.Data.DataTable();
            //        DateTime date = new DateTime();
            //        date = DateTime.Now;
            //        string dateeval = date.ToString("dd/MM/yyyy");
            //        string time = date.ToString("hh:mm tt");

            //        htinsertrec.Add("@Trans", "UPDATE_DEALLOCATE");
            //        htinsertrec.Add("@Order_Id", lbl_Order_Id);
            //        htinsertrec.Add("@User_Id", 1);
            //        htinsertrec.Add("@Order_Progress_Id", 8);
            //        htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
            //        htinsertrec.Add("@Assigned_By", User_id);
            //        htinsertrec.Add("@Modified_By", User_id);
            //        htinsertrec.Add("@Modified_Date", DateTime.Now);
            //        htinsertrec.Add("@status", "True");
            //        dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);

            //        if (Allocated_Userid != 0)
            //        {
            //            Hashtable ht_Update_Emp_Status = new Hashtable();
            //            DataTable dt_Update_Emp_Status = new DataTable();
            //            ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
            //            ht_Update_Emp_Status.Add("@Employee_Id", Allocated_Userid);
            //            ht_Update_Emp_Status.Add("@Allocate_Status", "False");
            //            dt_Update_Emp_Status = dataaccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);
            //        }

            //        Hashtable htorderStatus = new Hashtable();
            //        DataTable dtorderStatus = new DataTable();
            //        htorderStatus.Add("@Trans", "UPDATE_STATUS");
            //        htorderStatus.Add("@Order_ID", lbl_Order_Id);
            //        htorderStatus.Add("@Order_Status", Lbl_Staus_id);
            //        htorderStatus.Add("@Modified_By", User_id);
            //        htorderStatus.Add("@Modified_Date", date);
            //        dtorderStatus = dataaccess.ExecuteSP("Sp_Order", htorderStatus);

            //        //Hashtable htorderStatus_Allocate = new Hashtable();
            //        //DataTable dtorderStatus_Allocate = new DataTable();
            //        //htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
            //        //htorderStatus_Allocate.Add("@Order_ID", lbl_Order_Id);
            //        //htorderStatus_Allocate.Add("@Order_Status_Id", Lbl_Staus_id);
            //        //htorderStatus_Allocate.Add("@Modified_By", User_id);
            //        //htorderStatus_Allocate.Add("@Modified_Date", date);
            //        //dtorderStatus_Allocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htorderStatus_Allocate);

            //        Hashtable htupdate_Prog = new Hashtable();
            //        DataTable dtupdate_Prog = new System.Data.DataTable();
            //        htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
            //        htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
            //        htupdate_Prog.Add("@Order_Progress", 8);
            //        htupdate_Prog.Add("@Modified_By", User_id);
            //        htupdate_Prog.Add("@Modified_Date", DateTime.Now);

            //        dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);

            //    }

            //    if (CheckedCount >= 1)
            //    {
            //        MessageBox.Show("Order Deallocated Successfully");
            //    }

            //}
            //Gridview_Bind_All_Orders();
            //Gridview_Bind_Orders_Wise_Selected();
            ////  Restrict_Controls();
            //Sub_AddParent();



        }

        private void grd_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {

                    Ordermanagement_01.Order_Entry Order_Entry = new Ordermanagement_01.Order_Entry(int.Parse(grd_order.Rows[e.RowIndex].Cells[10].Value.ToString()), User_id, userroleid);
                    Order_Entry.Show();
                }
            }
        }

        private void grd_order_Allocated_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 4)
                {

                    Ordermanagement_01.Order_Entry Order_Entry = new Ordermanagement_01.Order_Entry(int.Parse(grd_order_Allocated.Rows[e.RowIndex].Cells[8].Value.ToString()), User_id, userroleid);
                    Order_Entry.Show();
                }
            }
        }

        private void btn_Deallocate_Click(object sender, EventArgs e)
        {
            if (ddl_Order_Status_Reallocate.Text != "SELECT" && ddl_Order_Status_Reallocate.SelectedValue.ToString() !="0")
            {
               
                    //  int Reallocateduser = int.Parse(ddl_UserName.SelectedValue.ToString());

                int Check_Count = 0;
                    for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                    {
                        bool isChecked = (bool)grd_order_Allocated[0, i].FormattedValue;

                        // chk = (CheckBox)row.Cells[0].FormattedValue("chkBxSelect");
                        //  CheckBox chkId = (row.Cells[0].FormattedValue as CheckBox);
                        if (isChecked == true)
                        {
                            Check_Count = 1;
                            string lbl_Order_Id = grd_order_Allocated.Rows[i].Cells[8].Value.ToString();
                            string lbl_County_ID = grd_order_Allocated.Rows[i].Cells[13].Value.ToString();
                            string lbl_Allocated_Userid = grd_order_Allocated.Rows[i].Cells[11].Value.ToString();
                            int Allocated_Userid = 0;
                            Allocated_Userid = int.Parse(lbl_Allocated_Userid);

                            Hashtable htget_User_Order_Last_Time_Updaetd = new Hashtable();
                            System.Data.DataTable dtget_User_Order_Last_Time_Updated = new System.Data.DataTable();
                            htget_User_Order_Last_Time_Updaetd.Add("@Trans", "MAX_TIME_BY_ORDER_ID");
                            htget_User_Order_Last_Time_Updaetd.Add("@Order_Id", lbl_Order_Id);
                            dtget_User_Order_Last_Time_Updated = dataaccess.ExecuteSP("[Sp_Order_User_Wise_Time_Track]", htget_User_Order_Last_Time_Updaetd);

                            if (dtget_User_Order_Last_Time_Updated.Rows.Count > 0)
                            {
                                Max_Time_Id = int.Parse(dtget_User_Order_Last_Time_Updated.Rows[0]["MAX_TIME_ID"].ToString());

                            }
                            else
                            {

                                Max_Time_Id = 0;
                            }

                            if (Max_Time_Id != 0)
                            {

                                Hashtable htget_User_Order_Differnce_Time = new Hashtable();
                                System.Data.DataTable dtget_User_Order_Differnce_Time = new System.Data.DataTable();
                                htget_User_Order_Differnce_Time.Add("@Trans", "GET_DIFFERNCE_TIME");
                                htget_User_Order_Differnce_Time.Add("@Order_Time_Id", Max_Time_Id);
                                dtget_User_Order_Differnce_Time = dataaccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htget_User_Order_Differnce_Time);

                                if (dtget_User_Order_Differnce_Time.Rows.Count > 0)
                                {
                                    Differnce_Time = int.Parse(dtget_User_Order_Differnce_Time.Rows[0]["Diff"].ToString());

                                }
                                else
                                {
                                    Differnce_Time = 0;

                                }

                                //htget_User_Order_Differnce_Time.Add("","");
                            }


                            if (Differnce_Time < 5)
                            {

                                Differnce_Count = 1;

                            }

                            if (Differnce_Time > 5)
                            {


                                Hashtable htinsertrec = new Hashtable();
                                System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                                DateTime date = new DateTime();
                                date = DateTime.Now;
                                string dateeval = date.ToString("dd/MM/yyyy");
                                string time = date.ToString("hh:mm tt");

                                htinsertrec.Add("@Trans", "UPDATE_DEALLOCATE");
                                htinsertrec.Add("@Order_Id", lbl_Order_Id);
                                htinsertrec.Add("@User_Id", 1);
                                htinsertrec.Add("@Order_Progress_Id", 8);
                                htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
                                htinsertrec.Add("@Assigned_By", User_id);
                                htinsertrec.Add("@Modified_By", User_id);
                                htinsertrec.Add("@Modified_Date", DateTime.Now);
                                htinsertrec.Add("@status", "True");
                                dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);



                                Hashtable htorderStatus = new Hashtable();
                                System.Data.DataTable dtorderStatus = new System.Data.DataTable();
                                htorderStatus.Add("@Trans", "UPDATE_STATUS");
                                htorderStatus.Add("@Order_ID", lbl_Order_Id);
                                htorderStatus.Add("@Order_Status", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                htorderStatus.Add("@Modified_By", User_id);
                                htorderStatus.Add("@Modified_Date", date);
                                dtorderStatus = dataaccess.ExecuteSP("Sp_Order", htorderStatus);

                                Hashtable htcountyType = new Hashtable();
                                System.Data.DataTable dtcountytype = new System.Data.DataTable();
                                htcountyType.Add("@Trans", "GET_COUNTY_TYPE");
                                htcountyType.Add("@County", lbl_County_ID);

                                dtcountytype = dataaccess.ExecuteSP("Sp_Order", htcountyType);

                                if (dtcountytype.Rows.Count > 0)
                                {

                                    County_Type = dtcountytype.Rows[0]["County_Type"].ToString();

                                }

                                Hashtable htcheckabbstract = new Hashtable();
                                System.Data.DataTable dtcheckabbstract = new System.Data.DataTable();
                                htcheckabbstract.Add("@Trans", "GET_ABSTRACTOR_CHECK");
                                htcheckabbstract.Add("@Order_ID", lbl_Order_Id);

                                dtcheckabbstract = dataaccess.ExecuteSP("Sp_Order", htcheckabbstract);

                                if (dtcheckabbstract.Rows.Count > 0)
                                {

                                    Abstractor_Check = Convert.ToBoolean(dtcheckabbstract.Rows[0]["Abstractor_Chk"].ToString());

                                }

                                if (County_Type == "TIER 2" && Abstractor_Check == false)
                                {

                                    Hashtable htupdateabstractcheck = new Hashtable();
                                    System.Data.DataTable dtupdateabstractcheck = new System.Data.DataTable();
                                    htupdateabstractcheck.Add("@Trans", "UPDATE_ABSTRACTOR_CHECK");
                                    htupdateabstractcheck.Add("@Order_ID", lbl_Order_Id);
                                    dtupdateabstractcheck = dataaccess.ExecuteSP("Sp_Order", htupdateabstractcheck);
                                }


                                Hashtable htorderStatus_Allocate = new Hashtable();
                                System.Data.DataTable dtorderStatus_Allocate = new System.Data.DataTable();
                                htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
                                htorderStatus_Allocate.Add("@Order_ID", lbl_Order_Id);
                                htorderStatus_Allocate.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                htorderStatus_Allocate.Add("@Modified_By", User_id);
                                htorderStatus_Allocate.Add("@Modified_Date", date);
                                dtorderStatus_Allocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htorderStatus_Allocate);

                                Hashtable htupdate_Prog = new Hashtable();
                                System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                                htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                                htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                                htupdate_Prog.Add("@Order_Progress", 8);
                                htupdate_Prog.Add("@Modified_By", User_id);
                                htupdate_Prog.Add("@Modified_Date", DateTime.Now);

                                dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);


                                //OrderHistory
                                Hashtable ht_Order_History = new Hashtable();
                                System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                                ht_Order_History.Add("@Trans", "INSERT");
                                ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                                //  ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                                ht_Order_History.Add("@Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                ht_Order_History.Add("@Progress_Id", 8);
                                ht_Order_History.Add("@Assigned_By", User_id);
                                ht_Order_History.Add("@Work_Type", 1);
                                ht_Order_History.Add("@Modification_Type", "Order Deallocate");
                                dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);


                                //==================================External Client_Vendor_Orders=====================================================

                                Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                                System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                                htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                                htCheck_Order_InTitlelogy.Add("@Order_ID", lbl_Order_Id);
                                dt_Order_InTitleLogy = dataaccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                                if (dt_Order_InTitleLogy.Rows.Count > 0)
                                {

                                    External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                                    External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());



                                    if (External_Client_Order_Task_Id != 18)
                                    {

                                        Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                        System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                        ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_TASK_STATUS");
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Task", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Status", 14);

                                        dt_TitleLogy_Order_Task_Status = dataaccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);
                                    }




                                }


                                //
                                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('Order Deallocated Successfully')</script>", false);

                            }
                        }

                    }

                    if (Check_Count >= 1)
                    {
                        if (Differnce_Count != 1)
                        {
                            MessageBox.Show("Order Deallocted Successfully");
                        }
                        else
                        {

                            MessageBox.Show("Some Orders Were not Deallocted beacuse of Orders are Work in Progress");
                        }
                       
                        ddl_Status.SelectedIndex = 0;
                        ddl_Order_Status_Reallocate.SelectedIndex = 0;
                        ddl_UserName.SelectedIndex = 0;
                    }
                
            }
            else  if (ddl_Order_Status_Reallocate.Text == "SELECT" || ddl_Order_Status_Reallocate.SelectedValue.ToString() == "0")
                {
                   

                        // int Reallocateduser = int.Parse(ddl_UserName.SelectedValue.ToString());

                    int Check_Count = 0;
                    for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                        {
                            bool isChecked = (bool)grd_order_Allocated[0, i].FormattedValue;

                            // chk = (CheckBox)row.Cells[0].FormattedValue("chkBxSelect");
                            //  CheckBox chkId = (row.Cells[0].FormattedValue as CheckBox);
                            if (isChecked == true)
                            {
                                Check_Count = 1;
                                string lbl_Order_Id = grd_order_Allocated.Rows[i].Cells[8].Value.ToString();
                                string lbl_County_ID = grd_order_Allocated.Rows[i].Cells[13].Value.ToString();
                                string lbl_Allocated_Userid = grd_order_Allocated.Rows[i].Cells[11].Value.ToString();
                                string Order_Status_Id = grd_order_Allocated.Rows[i].Cells[12].Value.ToString();
                                int Allocated_Userid = int.Parse(lbl_Allocated_Userid);

                                Hashtable htinsertrec = new Hashtable();
                                System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                                DateTime date = new DateTime();
                                date = DateTime.Now;
                                string dateeval = date.ToString("dd/MM/yyyy");
                                string time = date.ToString("hh:mm tt");

                                htinsertrec.Add("@Trans", "UPDATE_DEALLOCATE");
                                htinsertrec.Add("@Order_Id", lbl_Order_Id);
                                //   htinsertrec.Add("@User_Id", 1);
                                htinsertrec.Add("@Order_Progress_Id", 8);
                                htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
                                htinsertrec.Add("@Assigned_By", User_id);
                                htinsertrec.Add("@Modified_By", User_id);
                                htinsertrec.Add("@Modified_Date", DateTime.Now);
                                htinsertrec.Add("@status", "True");
                                dtinsertrec = dataaccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);
                                
                               
                                Hashtable htupdate_Prog = new Hashtable();
                                System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                                htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                                htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                                htupdate_Prog.Add("@Order_Progress", 8);
                                htupdate_Prog.Add("@Modified_By", User_id);
                                htupdate_Prog.Add("@Modified_Date", DateTime.Now);

                                dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);

                                Hashtable htcountyType = new Hashtable();
                                System.Data.DataTable dtcountytype = new System.Data.DataTable();
                                htcountyType.Add("@Trans", "GET_COUNTY_TYPE");
                                htcountyType.Add("@County", lbl_County_ID);

                                dtcountytype = dataaccess.ExecuteSP("Sp_Order", htcountyType);

                                if (dtcountytype.Rows.Count > 0)
                                {

                                    County_Type = dtcountytype.Rows[0]["County_Type"].ToString();

                                }

                                Hashtable htcheckabbstract = new Hashtable();
                                System.Data.DataTable dtcheckabbstract = new System.Data.DataTable();
                                htcheckabbstract.Add("@Trans", "GET_ABSTRACTOR_CHECK");
                                htcheckabbstract.Add("@Order_ID", lbl_Order_Id);

                                dtcheckabbstract = dataaccess.ExecuteSP("Sp_Order", htcheckabbstract);

                                if (dtcheckabbstract.Rows.Count > 0)
                                {

                                    Abstractor_Check = Convert.ToBoolean(dtcheckabbstract.Rows[0]["Abstractor_Chk"].ToString());

                                }

                                if (County_Type == "TIER 2" && Abstractor_Check == false)
                                {

                                    Hashtable htupdateabstractcheck = new Hashtable();
                                    System.Data.DataTable dtupdateabstractcheck = new System.Data.DataTable();
                                    htupdateabstractcheck.Add("@Trans", "UPDATE_ABSTRACTOR_CHECK");
                                    htupdateabstractcheck.Add("@Order_ID", lbl_Order_Id);
                                    dtupdateabstractcheck = dataaccess.ExecuteSP("Sp_Order", htupdateabstractcheck);
                                }
                                // Gridview_Bind_Orders_Wise_Selected();
                                // PopulateTreeview();
                                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('Order Deallocated Successfully')</script>", false);


                                //OrderHistory

                                //OrderHistory
                                Hashtable ht_Order_History = new Hashtable();
                                System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                                ht_Order_History.Add("@Trans", "INSERT");
                                ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                               //ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                                ht_Order_History.Add("@Status_Id", int.Parse(Order_Status_Id.ToString()));
                                ht_Order_History.Add("@Progress_Id", 8);
                                ht_Order_History.Add("@Assigned_By", User_id);
                                ht_Order_History.Add("@Work_Type", 1);
                                ht_Order_History.Add("@Modification_Type", "Order Deallocate");
                                dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);
                                

                            }

                        }

                    if (Check_Count >= 1)

                    {

                        MessageBox.Show("Order Deallocated Sucessfully");
                    }
                    

                }
            
            Gridview_Bind_All_Orders();
            Gridview_Bind_Orders_Wise_Selected();
        }
        void reader_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
          //  label2.Text = "IDLE";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // button1.BackgroundImage = Image.FromFile(Environment.CurrentDirectory + @"\pause.png");
            reader.Dispose();
            //if (reader.State == SynthesizerState.Ready)
            //{
                reader = new SpeechSynthesizer();
                reader.Rate = -3;
                reader.SpeakAsync("hello welcome to order allocation help desk. This is the order allocation form where you can allocate, deallocate and reallocate the orders. On the left side of the form you can select the username, then check the dropdown clientName and subclientname, so that respected orders will be displayed on screen with table data. once the orders are displayed you can allocate the order to user by clicking the check box and press allocate button . There is an drag and drop checkbox by using that you can select muliple orders at atime and allocate to user. in order status table there is an ordernumber button , when you click that particular user order details will be displayed in new screen. to deallocate and reallocate the orders which you had been assigned, then select the username on left side of the form, when you select, the datatable will be displays the current order allocation that you made. this option is only to requesting of orders to reallocate and deallocate to another user. if u have doubts please re-play the information in helpdesk. Thank you.  ");
                //  label2.Text = "SPEAKING";
                button2.Enabled = true;
                // button4.Enabled = true;
                reader.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(reader_SpeakCompleted);
           // }
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                 //   label2.Text = "SPEAKING";
                }
               // button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PausePlay = 1;
            if (reader.State == SynthesizerState.Speaking)
            {
                button1.Enabled = false;
                reader.Pause();
               // label2.Text = "PAUSED";
              //  button3.Enabled = true;
           }
            else if (reader != null)
            {
                PausePlay = 2;
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                    button2.Enabled = true;
                   //   label2.Text = "SPEAKING";
                }
                // button3.Enabled = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                button2.Enabled = false;
                reader.Dispose();
                // label2.Text = "IDLE";
                // button2.Enabled = false;
                // button3.Enabled = false;
                //button4.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button1.Enabled = true;
            }
            button1.Enabled = true;
        }


        private void pnl_help_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void lbl_help_MouseEnter(object sender, EventArgs e)
        {
            //if (pnl_help.Visible != true)
            //{
            //    pnl_help.Visible = true;
            //}
        }

        private void pnl_help_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void lbl_help_Click(object sender, EventArgs e)
        {
            if (pnl_help.Visible != true)
            {
                pnl_help.Visible = true;
            }
            else
            {
                pnl_help.Visible = false;
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            load_Progressbar.Start_progres();
            if (dtexp.Rows.Count > 0)
            {
                Export_ReportData();

            }

            else
            {

             
                DataSet dsexport = new DataSet();
               // Grd_Export.Rows.Clear();
              
                Grd_Export.AutoGenerateColumns = true;

                Hashtable htAllocate = new Hashtable();
                System.Data.DataTable dtAllocate = new System.Data.DataTable();
                htexp.Clear();
                dtexp.Clear();
                if (Order_Process == "SEARCH_ORDER_ALLOCATE" || Order_Process == "SEARCH_QC_ORDER_ALLOCATE" || Order_Process == "SEARCH_TYPING_ORDER_ALLOCATE" || Order_Process == "TYPING_QC_ORDERS_ALLOCATE" || Order_Process == "UPLOAD_ORDERS_ALLOCATE")
                {


                    htexp.Add("@Trans", "NOT ASSIGNED");
                    htexp.Add("@Order_Status_Id", Order_Status_Id);
                    dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);

                    dtexport = dtexp;
                }
                else if (Order_Process == "CLARIFICATION_ORDER_ALLOCATE_PENDING")
                {
                    dtexport.Rows.Clear();


                    htexp.Add("@Trans", "CLARIFICATION_ORDER_ALLOCATE_PENDING");

                    dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);

                    dtexport = dtexp;
                }

                else if (Order_Process == "HOLD_ORDER_ALLOCATE_PENDING")
                {
                    dtexport.Rows.Clear();



                    htexp.Add("@Trans", "HOLD_ORDER_ALLOCATE_PENDING");
                    // htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                    dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);

                    dtexport = dtexp;
                }
                else if (Order_Process == "CANCELLED_ORDER_ALLOCATE_PENDING")
                {
                    dtexport.Rows.Clear();


                    htexp.Add("@Trans", "CANCELLED_ORDER_ALLOCATE_PENDING");
                    // htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                    dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);


                    dtexport = dtexp;
                }
                else if (Order_Process == "REASSIGNED_ORDER_ALLOCATE_PENDING")
                {
                    dtexport.Rows.Clear();
                    htAllocate.Add("@Trans", "REASSIGNED_ORDER_ALLOCATE_PENDING");
                    // htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                    dtAllocate = dataaccess.ExecuteSP("Sp_Order_Assignment", htAllocate);


                    //htexp.Add("@Trans", "REASSIGNED_ORDER_ALLOCATE_PENDING");
                    //// htAllocate.Add("@Order_Status_Id", Order_Status_Id);
                    //dtexp = dataaccess.ExecuteSP("Sp_Order_Assignment_Export", htexp);


                    //dtexport = dtexp;
                }
                if(dtexport.Rows.Count>0)
                {
                    Grd_Export.DataSource = dtexport;
                }
                //ds.Clear();
                //ds.Tables.Clear();

                //ds.Tables.Add(dtexport);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    Convert_Dataset_to_Excel();
                //}
                //ds.Clear();
                //dtexport.Clear();

                Export_ReportData();

            }
        }

        private void Export_ReportData()
        {



            System.Data.DataTable dt = new System.Data.DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in Grd_Export.Columns)
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
            foreach (DataGridViewRow row in Grd_Export.Rows)
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
            Export_Title_Name = "Order_Allocation";
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
        private void Convert_Dataset_to_Excel()
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Visible = true;
            Workbook xlWorkbook = ExcelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            DataTableCollection collection = ds.Tables;

            for (int i = collection.Count; i > 0; i--)
            {
                Sheets xlSheets = null;
                Worksheet xlWorksheet = null;
                //Create Excel Sheets
                xlSheets = ExcelApp.Worksheets;
                xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1],
                               Type.Missing, Type.Missing, Type.Missing);

                System.Data.DataTable table = collection[i - 1];
                xlWorksheet.Name = table.TableName;

                for (int j = 1; j < table.Columns.Count + 1; j++)
                {
                    ExcelApp.Cells[1, j] = table.Columns[j - 1].ColumnName;
                }

                // Storing Each row and column value to excel sheet
                for (int k = 0; k < table.Rows.Count; k++)
                {
                    for (int l = 0; l < table.Columns.Count; l++)
                    {
                        ExcelApp.Cells[k + 2, l + 1] =
                        table.Rows[k].ItemArray[l].ToString();
                    }
                }
                ExcelApp.Columns.AutoFit();
            }
            ((Worksheet)ExcelApp.ActiveWorkbook.Sheets[ExcelApp.ActiveWorkbook.Sheets.Count]).Delete();
            ExcelApp.Visible = true;

        }
        private void Get_Order_number_Search(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dt.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }
  
        private void txt_Order_Number_TextChanged(object sender, EventArgs e)
       {
            if (txt_Order_Number.Text != "")
            {
                DataView dtsearch = new DataView(dtAllocate);
                string search = txt_Order_Number.Text.ToString();
                dtsearch.RowFilter = "Order_Number like '%" + search.ToString() + "%' ";
                dt = dtsearch.ToTable();

                System.Data.DataTable temptable = dt;
              

                if (temptable.Rows.Count > 0)
                {
                    grd_order.Rows.Clear();
                    for (int j = 0; j < temptable.Rows.Count; j++)
                    {
                        grd_order.Rows.Add();
                        grd_order.Rows[j].Cells[1].Value = j + 1;
                        if (userroleid == "1")
                        {
                            grd_order.Rows[j].Cells[2].Value = temptable.Rows[j]["Client_Name"].ToString();
                            grd_order.Rows[j].Cells[3].Value = temptable.Rows[j]["Sub_ProcessName"].ToString();
                        }
                        else if (userroleid == "2")
                        {
                            grd_order.Rows[j].Cells[2].Value = temptable.Rows[j]["Client_Number"].ToString();
                            grd_order.Rows[j].Cells[3].Value = temptable.Rows[j]["Subprocess_Number"].ToString();
                        }
                        grd_order.Rows[j].Cells[4].Value = temptable.Rows[j]["Order_Number"].ToString();
                        grd_order.Rows[j].Cells[5].Value = temptable.Rows[j]["Client_Order_Ref"].ToString();
                        grd_order.Rows[j].Cells[6].Value = temptable.Rows[j]["Order_Type"].ToString();
                        grd_order.Rows[j].Cells[7].Value = temptable.Rows[j]["STATECOUNTY"].ToString();
                        grd_order.Rows[j].Cells[8].Value = temptable.Rows[j]["County_Type"].ToString();
                        grd_order.Rows[j].Cells[9].Value = temptable.Rows[j]["Date"].ToString();
                        grd_order.Rows[j].Cells[10].Value = temptable.Rows[j]["Order_ID"].ToString();
                        grd_order.Rows[j].Cells[11].Value = 0;//Not requried its from titlelogy 
                        grd_order.Rows[j].Cells[12].Value = temptable.Rows[j]["Order_Status"].ToString();
                        grd_order.Rows[j].Cells[13].Value = temptable.Rows[j]["State"].ToString();


                        grd_order.Rows[j].Cells[14].Value = temptable.Rows[j]["Client_Id"].ToString();
                        grd_order.Rows[j].Cells[15].Value = temptable.Rows[j]["Sub_ProcessId"].ToString();
                        grd_order.Rows[j].Cells[16].Value = temptable.Rows[j]["Order_Type_ID"].ToString();
                        //grd_order.Rows[j].Cells[19].Value = temptable.Rows[j]["Search_Tax_Request"].ToString();

                        grd_order.Rows[j].Cells[4].Style.BackColor = System.Drawing.Color.DarkCyan;
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
                else
                {
                    grd_order.Rows.Clear();
                    grd_order.Visible = true;
                    grd_order.DataSource = null;
                }
                //btnFirst_Click(null, null);
             
                lbl_Total_Orders.Text = dt.Rows.Count.ToString();
               
            }
            else
            {
                if (ddl_Client_Name.SelectedIndex > 0 || ddl_Client_SubProcess.SelectedIndex > 0 || ddl_State.SelectedIndex > 0 || ddl_County_Type.SelectedIndex > 0)
                {
                    Binnd_Filter_Data();
                }
                else
                {
                    Gridview_Bind_All_Orders();
                }
            }
            
            
                 
            //foreach (DataGridViewRow row in grd_order.Rows)
            //{
            //    if (txt_Order_Number.Text != "")
            //    {
            //        if (row.Cells[4].Value.ToString().StartsWith(txt_Order_Number.Text.ToString(),true,CultureInfo.InvariantCulture))
            //        {
            //            row.Visible = true;
            //        }

            //        else
            //        {
            //            row.Visible = false;
            //        }
            //    }
            //    else
            //    {
            //        row.Visible = true;
            //    }
            //}
            

            System.Windows.Forms.Application.DoEvents();
        }

        private void txt_Order_Number_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_Order_Number.Text == "Search Order.....")
            {
                txt_Order_Number.Text = "";
                txt_Order_Number.ForeColor = Color.Black;
            }
        }

        private void txt_Order_Number_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Order_Number.Text == "Search Order.....")
            {
                txt_Order_Number.Text = "";
                txt_Order_Number.ForeColor = Color.Black;
            }
        }

        private void txt_Order_Number_MouseLeave(object sender, EventArgs e)
        {
            if (txt_Order_Number.Text == "Search Order.....")
            {
                txt_Order_Number.Text = "";
                txt_Order_Number.ForeColor = Color.SlateGray;
            }
        }

        private void ddl_Client_Name_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (ddl_Client_Name.SelectedIndex > 0)
            {

                if (userroleid == "1")
                {
                    dbc.BindSubProcessName(ddl_Client_SubProcess, int.Parse(ddl_Client_Name.SelectedValue.ToString()));
                }
                else if (userroleid == "2")
                {
                    
                    dbc.BindSubProcessNumber(ddl_Client_SubProcess, int.Parse(ddl_Client_Name.SelectedValue.ToString()));

                }
            }
            Binnd_Filter_Data();
            
            //btnFirst_Click(null, null);
        
        }

      

        private void ddl_Client_SubProcess_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Binnd_Filter_Data();
            
            //btnFirst_Click(null, null);
           
        }

        private void GetrowTable_Client(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dt.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }

        private void Binnd_Filter_Data()
        {
            DataView dtsearch = new DataView(dtAllocate);

            string Client = ddl_Client_Name.Text.ToString();
            string Sub_Client = ddl_Client_SubProcess.Text.ToString();
            string state = ddl_State.Text.ToString();
            string County_Type = ddl_County_Type.Text.ToString();


            if (Client != "ALL" && Sub_Client == "" && state == "Select" && County_Type == "Select")
            {
                if (userroleid == "1")
                {
                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%' ";
                }
                else if (userroleid == "2")
                {
                    dtsearch.RowFilter = "Client_Number = "+ddl_Client_Name.Text.ToString()+ "";

                }
            }
            else if (Client != "ALL" && Sub_Client != "" && state == "Select" && County_Type == "Select")
            {
                if (userroleid == "1")
                {

                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%'  and Sub_ProcessName like '%" + ddl_Client_SubProcess.Text.ToString() + "%'";
                }
                else if (userroleid == "2")
                {
                    dtsearch.RowFilter = "Client_Number =" + ddl_Client_Name.Text.ToString().ToString() + "  and Subprocess_Number = " + ddl_Client_SubProcess.Text.ToString() + "";
                }

            }
            else if (Client != "ALL" && Sub_Client == "" && state != "Select" && County_Type == "Select")
            {
                if (userroleid == "1")
                {
                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%'  and State like '%" + ddl_State.Text.ToString() + "%'";
                }
                else if (userroleid == "2")
                {

                    dtsearch.RowFilter = "Client_Number =" + ddl_Client_Name.Text.ToString().ToString() + "   and State like '%" + ddl_State.Text.ToString() + "%'";
                }
            }
            else if (Client != "ALL" && Sub_Client != "" && state != "Select" && County_Type == "Select")
            {
                if (userroleid == "1")
                {
                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%'   and Sub_ProcessName like '%" + ddl_Client_SubProcess.Text.ToString() + "%' and State like '%" + ddl_State.Text.ToString() + "%'";
                }
                else if (userroleid == "2")
                {

                    dtsearch.RowFilter = "Client_Number =" + ddl_Client_Name.Text.ToString().ToString() + "   and Subprocess_Number = " + ddl_Client_SubProcess.Text.ToString() + "";

                }
                
                }
            else if (Client != "ALL" && Sub_Client == "" && state == "Select" && County_Type != "Select")
            {
                if (userroleid == "1")
                {
                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%'   and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";
                }
                else if (userroleid == "2")
                {

                    dtsearch.RowFilter = "Client_Number =" + ddl_Client_Name.Text.ToString().ToString() + "   and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";

                }
            }
            else if (Client != "ALL" && Sub_Client != "" && state == "Select" && County_Type != "Select")
            {
                if (userroleid == "1")
                {

                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%'  and Sub_ProcessName like '%" + ddl_Client_SubProcess.Text.ToString() + "%'   and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";
                }
                else if (userroleid == "2")
                {

                    dtsearch.RowFilter = "Client_Number =" + ddl_Client_Name.Text.ToString().ToString() + "  and Subprocess_Number = " + ddl_Client_SubProcess.Text.ToString() + "   and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";
                
                }
            }
            else if (Client != "ALL" && Sub_Client != "" && state != "Select" && County_Type != "Select")
            {
                if (userroleid == "1")
                {
                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%'  and Sub_ProcessName like '%" + ddl_Client_SubProcess.Text.ToString() + "%'  and State like '%" + ddl_State.Text.ToString() + "%'  and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";

                }
                else if (userroleid == "2")
                {

                    dtsearch.RowFilter = "Client_Number =" + ddl_Client_Name.Text.ToString().ToString() + "  and Subprocess_Number = " + ddl_Client_SubProcess.Text.ToString() + "  and State like '%" + ddl_State.Text.ToString() + "%'  and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";

                }
            }
            else if (Client != "ALL" && Sub_Client == "" && state != "Select" && County_Type != "Select")
            {
                if (userroleid == "1")
                {

                    dtsearch.RowFilter = "Client_Name like '%" + ddl_Client_Name.Text.ToString().ToString() + "%'  and Sub_ProcessName like '%" + ddl_Client_SubProcess.Text.ToString() + "%'  and State like '%" + ddl_State.Text.ToString() + "%'  and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";

                }
                else if (userroleid == "2")
                {

                    dtsearch.RowFilter = "Client_Number =" + ddl_Client_Name.Text.ToString().ToString() + "  and Subprocess_Number = " + ddl_Client_SubProcess.Text.ToString() + "  and State like '%" + ddl_State.Text.ToString() + "%'  and County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";
                }
            }


            else if (Client == "ALL" && Sub_Client == "" && state != "Select" && County_Type == "Select")
            {
               
                    dtsearch.RowFilter = "State like '%" + ddl_State.Text.ToString() + "%'";

              
            }
            else if (Client == "ALL" && Sub_Client == "" && County_Type != "Select" && state == "Select")
            {

                dtsearch.RowFilter = "County_Type like '%" + ddl_County_Type.Text.ToString() + "%'";
            }
            else if (Client == "ALL" && Sub_Client == "" && state != "Select" && County_Type != "Select")
            {

                dtsearch.RowFilter = "State like '%" + ddl_State.Text.ToString().ToString() + "%' and County_Type like '%" + ddl_County_Type.Text.ToString() + "%' ";
            }
            else
            {

                dtsearch.Table.Rows.Clear();
            }









            dt = dtsearch.ToTable();
            System.Data.DataTable temptable = dt;
            
            if (temptable.Rows.Count > 0)
            {
                grd_order.Rows.Clear();
                grd_order.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                grd_order.EnableHeadersVisualStyles = false;
                for (int i = 0; i < temptable.Rows.Count; i++)
                {

                    grd_order.Rows.Add();
                    grd_order.Rows[i].Cells[1].Value = i + 1;
                    //grd_order.Rows[i].Cells[2].Value = dtAllocate.Rows[i]["Client_Name"].ToString();
                    //grd_order.Rows[i].Cells[3].Value = dtAllocate.Rows[i]["Sub_ProcessName"].ToString();
                    //grd_order.Rows[i].Cells[4].Value = dtAllocate.Rows[i]["Order_Number"].ToString();
                    //grd_order.Rows[i].Cells[5].Value = dtAllocate.Rows[i]["Order_Type"].ToString();
                    //grd_order.Rows[i].Cells[6].Value = dtAllocate.Rows[i]["STATECOUNTY"].ToString();
                    //grd_order.Rows[i].Cells[7].Value = dtAllocate.Rows[i]["Date"].ToString();
                    //grd_order.Rows[i].Cells[8].Value = dtAllocate.Rows[i]["Order_ID"].ToString();
                    //grd_order.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.DarkCyan;

                    if (userroleid == "1")
                    {
                        grd_order.Rows[i].Cells[2].Value = temptable.Rows[i]["Client_Name"].ToString();
                        grd_order.Rows[i].Cells[3].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                    }
                    else if (userroleid == "2")
                    {
                        grd_order.Rows[i].Cells[2].Value = temptable.Rows[i]["Client_Number"].ToString();
                        grd_order.Rows[i].Cells[3].Value = temptable.Rows[i]["Subprocess_Number"].ToString();
                    }

                   
                    grd_order.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Number"].ToString();
                    grd_order.Rows[i].Cells[5].Value = temptable.Rows[i]["Client_Order_Ref"].ToString();
                    grd_order.Rows[i].Cells[6].Value = temptable.Rows[i]["Order_Type"].ToString();
                    grd_order.Rows[i].Cells[7].Value = temptable.Rows[i]["STATECOUNTY"].ToString();
                    grd_order.Rows[i].Cells[8].Value = temptable.Rows[i]["County_Type"].ToString();
                    grd_order.Rows[i].Cells[9].Value = temptable.Rows[i]["Date"].ToString();
                    grd_order.Rows[i].Cells[10].Value = temptable.Rows[i]["Order_ID"].ToString();
                    grd_order.Rows[i].Cells[11].Value = 0;//Not requried its from titlelogy 
                    grd_order.Rows[i].Cells[12].Value = temptable.Rows[i]["Order_Status"].ToString();
                    grd_order.Rows[i].Cells[13].Value = temptable.Rows[i]["State"].ToString();
                    grd_order.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.DarkCyan;

              
                    grd_order.Rows[i].Cells[14].Value = temptable.Rows[i]["Client_Id"].ToString();
                    grd_order.Rows[i].Cells[15].Value = temptable.Rows[i]["Sub_ProcessId"].ToString();
                    grd_order.Rows[i].Cells[16].Value = temptable.Rows[i]["Order_Type_ID"].ToString();
                    grd_order.Rows[i].Cells[19].Value = temptable.Rows[i]["Search_Tax_Request"].ToString();

                }
                
            }
            else
            {
                grd_order.Visible = true;
                grd_order.DataSource = null;
                grd_order.Rows.Clear();
                //  lbl_Remainig_Order.Text = "0";

            }
            //lbl_Total_Orders.Text = "Total Orders: " + dt.Rows.Count.ToString();
            lbl_Total_Orders.Text = dt.Rows.Count.ToString();    
        }

      

        private void ddl_State_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Binnd_Filter_Data();
            
            //btnFirst_Click(null, null);
    
        }

        private void ddl_County_Type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Binnd_Filter_Data();
            
            //btnFirst_Click(null, null);
           
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            load_Progressbar.Start_progres();
            Gridview_Bind_All_Orders();
            Sub_AddParent();
            ddl_Client_Name.SelectedValue = "0";
            ddl_State.SelectedIndex=0;
            ddl_County_Type.SelectedValue = "0";
        }

        private void txt_Order_allocate_TextChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in grd_order_Allocated.Rows)
            {
                if (txt_Order_allocate.Text != "")
                {
                    if (row.Cells[4].Value.ToString().StartsWith(txt_Order_allocate.Text.ToString(),true,CultureInfo.InvariantCulture))
                    {
                        row.Visible = true;
                    }

                    else
                    {
                        row.Visible = false;
                    }
                }
                else
                {
                    row.Visible = true;
                }
            }
        }

        private void txt_Order_allocate_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Order_allocate.Text == "Search Order.....")
            {
                txt_Order_allocate.Text = "";
                txt_Order_allocate.ForeColor = Color.Black;
            }
        }

        private void txt_Order_allocate_MouseLeave(object sender, EventArgs e)
        {
            if (txt_Order_allocate.Text == "Search Order.....")
            {
                txt_Order_allocate.Text = "";
                txt_Order_allocate.ForeColor = Color.SlateGray;
            }
        }

        private void txt_Order_allocate_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_Order_allocate.Text == "Search Order.....")
            {
                txt_Order_allocate.Text = "";
                txt_Order_allocate.ForeColor = Color.Black;
            }
        }

      

        private void label5_Click(object sender, EventArgs e)
        {

        }

   



 

   

        

        private void ddl_Client_SubProcess_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {
            string emp_name = txt_UserName.Text;
            if (emp_name != "" && emp_name != "Search User name...")
            {
                string sKeyTemp = "";
                TreeNode parentnode;
                sKeyTemp = "Users";
                TreeView1.Nodes.Clear();
                parentnode = TreeView1.Nodes.Add(sKeyTemp, sKeyTemp);

                DataView dtsearch = new DataView(dtchild);
                dtsearch.RowFilter = "User_Name like '%" + emp_name + "%'";
                dtinfo = dtsearch.ToTable();
                if (dtinfo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtinfo.Rows.Count; i++)
                    {
                        TreeView1.Nodes[0].Nodes.Add(dtinfo.Rows[i]["User_id"].ToString(), dtinfo.Rows[i]["User_Name"].ToString());
                    }
                }
                //Hashtable htselect = new Hashtable();
                //System.Data.DataTable dt = new System.Data.DataTable();
                //htselect.Add("@Trans", "TREE_SEARCH");
                //htselect.Add("@User_Name", txt_UserName.Text);
                //dt = dataaccess.ExecuteSP("Sp_User_Access", htselect);
                //if (dt.Rows.Count > 0)
                //{
                //    TreeView1.Nodes[0].Nodes.Add(dt.Rows[0]["User_id"].ToString(), dt.Rows[0]["User_Name"].ToString());
                //}
                TreeView1.ExpandAll();
            }
        }

        private void txt_UserName_Enter(object sender, EventArgs e)
        {
            
        }

        private void txt_UserName_MouseEnter(object sender, EventArgs e)
        {
            txt_UserName.Text = "";
        }

        private void chk_All_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_All.Checked == true)
            {

                for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                {

                    grd_order_Allocated[0, i].Value = true;
                }
            }
            else if (chk_All.Checked == false)
            {

                for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                {

                    grd_order_Allocated[0, i].Value = false;
                }
            }
        }

        private void btn_Status_Click(object sender, EventArgs e)
        {
            if (ddl_Status.SelectedIndex > 0)
            {

                int Check_Count = 0;
                for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
                {
                    bool isChecked = (bool)grd_order_Allocated[0, i].FormattedValue;

                    // chk = (CheckBox)row.Cells[0].FormattedValue("chkBxSelect");
                    //  CheckBox chkId = (row.Cells[0].FormattedValue as CheckBox);
                    if (isChecked == true)
                    {
                        Check_Count = 1;

                        string lbl_Order_Id = grd_order_Allocated.Rows[i].Cells[8].Value.ToString();
                        string lbl_OrderStatus_Id = grd_order_Allocated.Rows[i].Cells[12].Value.ToString();
                        string Client_Number = grd_order_Allocated.Rows[i].Cells[14].Value.ToString();
                  
                        int Order_PRogress = int.Parse(ddl_Status.SelectedValue.ToString());
                    

                        Hashtable htget_User_Order_Last_Time_Updaetd = new Hashtable();
                        System.Data.DataTable dtget_User_Order_Last_Time_Updated = new System.Data.DataTable();
                        htget_User_Order_Last_Time_Updaetd.Add("@Trans", "MAX_TIME_BY_ORDER_ID");
                        htget_User_Order_Last_Time_Updaetd.Add("@Order_Id", lbl_Order_Id);
                        dtget_User_Order_Last_Time_Updated = dataaccess.ExecuteSP("[Sp_Order_User_Wise_Time_Track]", htget_User_Order_Last_Time_Updaetd);

                        if (dtget_User_Order_Last_Time_Updated.Rows.Count > 0)
                        {
                            Max_Time_Id = int.Parse(dtget_User_Order_Last_Time_Updated.Rows[0]["MAX_TIME_ID"].ToString());

                        }
                        else
                        {

                            Max_Time_Id = 0;
                        }

                        if (Max_Time_Id != 0)
                        {

                            Hashtable htget_User_Order_Differnce_Time = new Hashtable();
                            System.Data.DataTable dtget_User_Order_Differnce_Time = new System.Data.DataTable();
                            htget_User_Order_Differnce_Time.Add("@Trans", "GET_DIFFERNCE_TIME");
                            htget_User_Order_Differnce_Time.Add("@Order_Time_Id", Max_Time_Id);
                            dtget_User_Order_Differnce_Time = dataaccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htget_User_Order_Differnce_Time);

                            if (dtget_User_Order_Differnce_Time.Rows.Count > 0)
                            {
                                Differnce_Time = int.Parse(dtget_User_Order_Differnce_Time.Rows[0]["Diff"].ToString());

                            }
                            else
                            {
                                Differnce_Time = 0;

                            }

                            //htget_User_Order_Differnce_Time.Add("","");
                        }


                        if (Differnce_Time < 5)
                        {

                            Differnce_Count = 1;

                        }

                        if (Differnce_Time > 5)
                        {


                            Hashtable htupdate_Prog = new Hashtable();
                            System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                            htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                            htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                            htupdate_Prog.Add("@Order_Progress", Order_PRogress);
                            htupdate_Prog.Add("@Modified_By", User_id);
                            htupdate_Prog.Add("@Modified_Date", DateTime.Now);
                            dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);


                            //OrderHistory
                            Hashtable ht_Order_History = new Hashtable();
                            System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                            ht_Order_History.Add("@Trans", "INSERT");
                            ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                            //  ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            ht_Order_History.Add("@Status_Id", int.Parse(lbl_OrderStatus_Id.ToString()));
                            ht_Order_History.Add("@Progress_Id", Order_PRogress);
                            ht_Order_History.Add("@Assigned_By", User_id);
                            ht_Order_History.Add("@Modification_Type", "Order Status Changed to " + ddl_Status.Text.ToString() + "");
                            ht_Order_History.Add("@Work_Type", 1);
                            dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);



                            //==================================External Client_Vendor_Orders(Titlelogy)=====================================================



                            int Valiate_Order_Staus_Id = int.Parse(ddl_Status.SelectedValue.ToString());
                            if (Valiate_Order_Staus_Id == 1 || Valiate_Order_Staus_Id == 3 || Valiate_Order_Staus_Id == 4 || Valiate_Order_Staus_Id == 5)
                            {

                                Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                                System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                                htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                                htCheck_Order_InTitlelogy.Add("@Order_ID", lbl_Order_Id);
                                dt_Order_InTitleLogy = dataaccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                                if (dt_Order_InTitleLogy.Rows.Count > 0)
                                {


                                    External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                                    External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());



                                    if (External_Client_Order_Task_Id != 18 && Client_Number != "32000")
                                    {


                                        Hashtable htcheckExternalProduction = new Hashtable();
                                        System.Data.DataTable dtcheckExternalProduction = new System.Data.DataTable();
                                        htcheckExternalProduction.Add("@Trans", "CHK_PRODUCTION_DATE");
                                        htcheckExternalProduction.Add("@External_Order_Id", External_Client_Order_Id);
                                        htcheckExternalProduction.Add("@Order_Task", External_Client_Order_Task_Id);
                                        dtcheckExternalProduction = dataaccess.ExecuteSP("Sp_External_Client_Orders_Production", htcheckExternalProduction);



                                        if (dtcheckExternalProduction.Rows.Count > 0)
                                        {


                                            Check_External_Production = int.Parse(dtcheckExternalProduction.Rows[0]["count"].ToString());
                                        }
                                        else
                                        {

                                            Check_External_Production = 0;
                                        }


                                        if (Check_External_Production == 0)
                                        {

                                            Hashtable htProductionDate = new Hashtable();
                                            System.Data.DataTable dtproductiondate = new System.Data.DataTable();
                                            htProductionDate.Add("@Trans", "INSERT");
                                            htProductionDate.Add("@External_Order_Id", External_Client_Order_Id);
                                            htProductionDate.Add("@Order_Task", External_Client_Order_Task_Id);
                                            htProductionDate.Add("@Order_Status", int.Parse(ddl_Status.SelectedValue.ToString()));
                                            htProductionDate.Add("@Order_Production_date", DateTime.Now.ToString("MM/dd/yyyy"));
                                            htProductionDate.Add("@Inserted_By", User_id);
                                            htProductionDate.Add("@Inserted_date", DateTime.Now);
                                            htProductionDate.Add("@status", "True");
                                            dtproductiondate = dataaccess.ExecuteSP("Sp_External_Client_Orders_Production", htProductionDate);

                                        }
                                        else if (Check_External_Production > 0)
                                        {
                                            Hashtable htProductionDate = new Hashtable();
                                            System.Data.DataTable dtproductiondate = new System.Data.DataTable();
                                            htProductionDate.Add("@Trans", "UPDATE");
                                            htProductionDate.Add("@External_Order_Id", External_Client_Order_Id);
                                            htProductionDate.Add("@Order_Task", External_Client_Order_Task_Id);
                                            htProductionDate.Add("@Order_Status", int.Parse(ddl_Status.SelectedValue.ToString()));
                                            htProductionDate.Add("@Order_Production_date", DateTime.Now.ToString("MM/dd/yyyy"));
                                            htProductionDate.Add("@Inserted_By", User_id);
                                            htProductionDate.Add("@Inserted_date", DateTime.Now);
                                            htProductionDate.Add("@status", "True");
                                            dtproductiondate = dataaccess.ExecuteSP("Sp_External_Client_Orders_Production", htProductionDate);

                                        }

                                        Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                        System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                        ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_STATUS");
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Status", Valiate_Order_Staus_Id);

                                        dt_TitleLogy_Order_Task_Status = dataaccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);








                                    }


                                }

                            }

                        }
                    }
                }

                if (Check_Count >= 1)
                {
                    Gridview_Bind_Orders_Wise_Treeview_Selected();
                    Sub_AddParent();
                    if (Differnce_Count != 1)
                    {
               
                        MessageBox.Show("Orders Moved to " + ddl_Status.Text.ToString() + "");
                    }
                    else
                    {

                        MessageBox.Show("Some Orders Were not Updated Status because of Order are Work in Progress");
                    }
                  
                    ddl_Status.SelectedIndex = 0;
                    ddl_Order_Status_Reallocate.SelectedIndex = 0;
                    ddl_UserName.SelectedIndex = 0;
                   

                }
            }
            else
            {

                MessageBox.Show("Please Select Status");
            }
        }

        private void rb_Status_CheckedChanged(object sender, EventArgs e)
        {
            lbl_User_And_Status.Text = "Status";
            ddl_UserName.Visible = false;
            ddl_Order_Status_Reallocate.Visible = false;
            btn_Reallocate.Visible = false;
            btn_Deallocate.Visible = false;
            lbl_Task.Visible = false;


            ddl_Status.Visible = true;
            btn_Status.Visible = true;

            btn_Move_Research_User.Visible = false;

        }

        private void Rb_Task_CheckedChanged(object sender, EventArgs e)
        {
            lbl_User_And_Status.Text = "User Name";


            ddl_UserName.Visible = true;
            ddl_Order_Status_Reallocate.Visible = true;
            btn_Reallocate.Visible = true;
            btn_Deallocate.Visible = true;
            lbl_Task.Visible = true;


            ddl_Status.Visible = false;
            btn_Status.Visible = false;
            btn_Move_Research_User.Visible = false;
        }

        private void Export_User_ReportData()
        {



            System.Data.DataTable dt = new System.Data.DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in Grd_Export.Columns)
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
            foreach (DataGridViewRow row in Grd_Export.Rows)
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
            Export_Title_Name = "Order_Allocation";
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

        private void btn_user_Export_Click(object sender, EventArgs e)
        {
            load_Progressbar.Start_progres();
            if (Tree_View_UserId != 0 )
            {
                Hashtable htuser = new Hashtable();
                System.Data.DataTable dtuser = new System.Data.DataTable();
                htuser.Add("@Trans", "EXPORT_ALL_ALLOCATED_ORDERS");
                htuser.Add("@User_Id", Tree_View_UserId);
                //   htuser.Add("@Subprocess_id", Sub_ProcessName);
                htuser.Add("@Order_Status_Id", Order_Status_Id);
                dtuser = dataaccess.ExecuteSP("Sp_Orders_Que", htuser);
                if (dtuser.Rows.Count > 0)
                {

                    Grd_Export.DataSource = dtuser;


                }
                if (Grd_Export.Rows.Count > 0)
                {

                    Export_ReportData();
                }
            }

        }

        private void chk_Dragdrop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Vendor_Allocate_Click(object sender, EventArgs e)
        {
            
            int CheckedCount = 0;
            if (ddl_Vendor_Name.SelectedIndex != 0)
            {


                int allocated_Vendor_Id =int.Parse(ddl_Vendor_Name.SelectedValue.ToString());



                for (int i = 0; i < grd_order.Rows.Count; i++)
                {
                    bool isChecked = (bool)grd_order[0, i].FormattedValue;

                    // chk = (CheckBox)row.Cells[0].FormattedValue("chkBxSelect");
                    //  CheckBox chkId = (row.Cells[0].FormattedValue as CheckBox);
                    if (isChecked == true)
                    {
                        CheckedCount = 1;
                         lbl_Order_Id = grd_order.Rows[i].Cells[10].Value.ToString();
                         Vendor_Id = ddl_Vendor_Name.SelectedValue.ToString();


                          lbl_Order_Type_Id = grd_order.Rows[i].Cells[16].Value.ToString();
                          Client_Id = int.Parse(grd_order.Rows[i].Cells[14].Value.ToString());
                          Sub_Process_Id = int.Parse(grd_order.Rows[i].Cells[15].Value.ToString());

                          Hashtable ht_Get_Order_Type_Abs_Id = new Hashtable();
                          System.Data.DataTable dt_Get_Order_Type_Abs_Id = new System.Data.DataTable();
                          ht_Get_Order_Type_Abs_Id.Add("@Trans", "SELECT_BY_ORDER_TYPE_ID");
                          ht_Get_Order_Type_Abs_Id.Add("@Order_Type_ID", lbl_Order_Type_Id.ToString());
                          dt_Get_Order_Type_Abs_Id = dataaccess.ExecuteSP("Sp_Order_Type", ht_Get_Order_Type_Abs_Id);

                          if (dt_Get_Order_Type_Abs_Id.Rows.Count > 0)
                          {
                              Order_Type_Abs_Id = int.Parse(dt_Get_Order_Type_Abs_Id.Rows[0]["OrderType_ABS_Id"].ToString());

                          }
                        

                        Hashtable htinsertrec = new Hashtable();
                        System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");



                        if (Validate_Vedndor_Sate_county() != false && Validate_Order_Type(allocated_Vendor_Id, Order_Type_Abs_Id) && Validate_Client_Sub_Client(allocated_Vendor_Id, Client_Id, Sub_Process_Id))
                        {

                         Hashtable htdel = new Hashtable();
                            System.Data.DataTable dtdel = new System.Data.DataTable();
                            htdel.Add("@Trans", "DELETE");
                            htdel.Add("@Order_Id", lbl_Order_Id);
                            dtdel = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htdel);


                            Hashtable htdelvendstatus = new Hashtable();
                            System.Data.DataTable dtdelvendstatus = new System.Data.DataTable();
                            htdelvendstatus.Add("@Trans", "DELETE");
                            htdelvendstatus.Add("@Order_Id", lbl_Order_Id);
                            dtdelvendstatus = dataaccess.ExecuteSP("Sp_Vendor_Order_Status", htdelvendstatus);




                            Hashtable htvenncapacity = new Hashtable();
                            System.Data.DataTable dtvencapacity = new System.Data.DataTable();
                            htvenncapacity.Add("@Trans", "GET_VENDOR_CAPACITY");
                            htvenncapacity.Add("@Venodor_Id", allocated_Vendor_Id);
                            dtvencapacity = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htvenncapacity);

                            if (dtvencapacity.Rows.Count > 0)
                            {

                                Hashtable htetcdate = new Hashtable();
                                System.Data.DataTable dtetcdate = new System.Data.DataTable();
                                htetcdate.Add("@Trans", "GET_DATE");

                                dtetcdate = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htetcdate);


                                Vendor_Order_capacity = int.Parse(dtvencapacity.Rows[0]["Capacity"].ToString());


                                Hashtable htVendor_No_Of_Order_Assigned = new Hashtable();
                                System.Data.DataTable dtVendor_No_Of_Order_Assigned = new System.Data.DataTable();
                                htVendor_No_Of_Order_Assigned.Add("@Trans", "COUNT_NO_OF_ORDER_ASSIGNED_TO_VENDOR_DATE_WISE");
                                htVendor_No_Of_Order_Assigned.Add("@Venodor_Id", allocated_Vendor_Id);
                                htVendor_No_Of_Order_Assigned.Add("@Date", Vendor_Date);

                                dtVendor_No_Of_Order_Assigned = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htVendor_No_Of_Order_Assigned);

                                if (dtVendor_No_Of_Order_Assigned.Rows.Count > 0)
                                {

                                    No_Of_Order_Assignd_for_Vendor = int.Parse(dtVendor_No_Of_Order_Assigned.Rows[0]["count"].ToString());
                                }
                                else
                                {

                                    No_Of_Order_Assignd_for_Vendor = 0;
                                }



                                if (No_Of_Order_Assignd_for_Vendor <= Vendor_Order_capacity)
                                {


                                    Hashtable htCheckOrderAssigned = new Hashtable();
                                    System.Data.DataTable dtcheckorderassigned = new System.Data.DataTable();

                                    htCheckOrderAssigned.Add("@Trans", "CHECK_ORDER_ASSIGNED");
                                    htCheckOrderAssigned.Add("@Order_Id", lbl_Order_Id);
                                    dtcheckorderassigned = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htCheckOrderAssigned);

                                    int CheckCount = int.Parse(dtcheckorderassigned.Rows[0]["count"].ToString());


                                    if (CheckCount <= 0)
                                    {

                                        Hashtable htupdatestatus = new Hashtable();
                                        System.Data.DataTable dtupdatestatus = new System.Data.DataTable();
                                        htupdatestatus.Add("@Trans", "UPDATE_STATUS");
                                        htupdatestatus.Add("@Order_Status", 20);
                                        htupdatestatus.Add("@Modified_By", User_id);
                                        htupdatestatus.Add("@Order_ID", lbl_Order_Id);
                                        dtupdatestatus = dataaccess.ExecuteSP("Sp_Order", htupdatestatus);


                                        Hashtable htupdateprogress = new Hashtable();
                                        System.Data.DataTable dtupdateprogress = new System.Data.DataTable();
                                        htupdateprogress.Add("@Trans", "UPDATE_PROGRESS");
                                        htupdateprogress.Add("@Order_Progress", 6);
                                        htupdateprogress.Add("@Modified_By", User_id);
                                        htupdateprogress.Add("@Order_ID", lbl_Order_Id);
                                        dtupdateprogress = dataaccess.ExecuteSP("Sp_Order", htupdateprogress);






                                        Hashtable htinsert = new Hashtable();
                                        System.Data.DataTable dtinert = new System.Data.DataTable();

                                        htinsert.Add("@Trans", "INSERT");
                                        htinsert.Add("@Order_Id", lbl_Order_Id);
                                        htinsert.Add("@Order_Task_Id", 2);
                                        htinsert.Add("@Order_Status_Id", 13);
                                        htinsert.Add("@Venodor_Id", allocated_Vendor_Id);
                                        htinsert.Add("@Assigned_Date_Time", dtetcdate.Rows[0]["Date"]);
                                        htinsert.Add("@Assigned_By", User_id);
                                        htinsert.Add("@Inserted_By", User_id);
                                        htinsert.Add("@Inserted_date", dtetcdate.Rows[0]["Date"]);
                                        htinsert.Add("@Status", "True");
                                        dtinert = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htinsert);




                                        Hashtable htinsertstatus = new Hashtable();
                                        System.Data.DataTable dtinsertstatus = new System.Data.DataTable();
                                        htinsertstatus.Add("@Trans", "INSERT");
                                        htinsertstatus.Add("@Vendor_Id", allocated_Vendor_Id);
                                        htinsertstatus.Add("@Order_Id", lbl_Order_Id);
                                        htinsertstatus.Add("@Order_Task", 2);
                                        htinsertstatus.Add("@Order_Status", 13);
                                        htinsertstatus.Add("@Assigen_Date", dtetcdate.Rows[0]["Date"]);
                                        htinsertstatus.Add("@Inserted_By", User_id);
                                        htinsertstatus.Add("@Inserted_date", dtetcdate.Rows[0]["Date"]);
                                        htinsertstatus.Add("@Status", "True");

                                        dtinsertstatus = dataaccess.ExecuteSP("Sp_Vendor_Order_Status", htinsertstatus);




                                    }



                                }






                                //OrderHistory
                                Hashtable ht_Order_History = new Hashtable();
                                System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                                ht_Order_History.Add("@Trans", "INSERT");
                                ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                                ht_Order_History.Add("@User_Id", User_id);
                                ht_Order_History.Add("@Status_Id", 2);
                                ht_Order_History.Add("@Progress_Id", 6);
                                ht_Order_History.Add("@Assigned_By", User_id);
                                ht_Order_History.Add("@Work_Type", 1);
                                ht_Order_History.Add("@Modification_Type", "Vendor Order Allocate from Inhouse Order Queue");
                                dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);


                                //==================================External Client_Vendor_Orders=====================================================


                                Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                                System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                                htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                                htCheck_Order_InTitlelogy.Add("@Order_ID", lbl_Order_Id);
                                dt_Order_InTitleLogy = dataaccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                                if (dt_Order_InTitleLogy.Rows.Count > 0)
                                {

                                    External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                                    External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());



                                    if (External_Client_Order_Task_Id != 18)
                                    {
                                        Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                        System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                        ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_TASK_STATUS");
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Task", 2);
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Status", 14);

                                        dt_TitleLogy_Order_Task_Status = dataaccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);
                                    }




                                }
                            }
                            else
                            { 
                            

                            }





                                //TreeView1.SelectedNode.Value =ViewState["User_Id"].ToString();
                                //   lbl_allocated_user.Text = ViewState["User_Wise_Count"].ToString();
                                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('Order Reallocated Successfully')</script>", false);

                            }


                        }
                       
            }

                }

                if (CheckedCount >= 1)
                {

                   

                    MessageBox.Show("Order were Allocated to Vendors Successfully");

                    if (Vendor_State_Count == 1 || Vendor_Order_Type_Count == 1 || Vendor_Client_COunt == 1)
                    {

                        MessageBox.Show("Some Order were not Allocated to Vendors imporoper State,Product Type and Client not Added to Vendor");
                     
                    }
                    

                    ddl_Vendor_Name.SelectedIndex = 0;
                    Gridview_Bind_All_Orders();
                 
                }
            }


        private bool Validate_Vedndor_Sate_county()
        {


            Hashtable htstatecounty = new Hashtable();
            System.Data.DataTable dtstatecounty = new System.Data.DataTable();
            Hashtable htcheckstate = new Hashtable();
            System.Data.DataTable dtcheckstate = new System.Data.DataTable();
            htstatecounty.Add("@Trans", "GET_STATE_COUNTY_OF_THE_ORDER");
            htstatecounty.Add("@Order_Id", lbl_Order_Id);
            dtstatecounty = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htstatecounty);
            if (dtstatecounty.Rows.Count > 0)
            {


                htcheckstate.Add("@Trans", "CHECK_VENDOR_AVILABLE_IN_STATE_COUNTY");
                htcheckstate.Add("@State_Id", dtstatecounty.Rows[0]["State"].ToString());
                htcheckstate.Add("@County_Id", dtstatecounty.Rows[0]["County"].ToString());
                htcheckstate.Add("@Venodor_Id", Vendor_Id);

                dtcheckstate = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htcheckstate);




            }

            if (dtcheckstate.Rows.Count > 0)
            {


                return true;

            }
            else
            {

                Vendor_State_Count = 1;
                return false;
            }





        }

        private bool Validate_Order_Type(int Vendor_Id, int Order_Type_Id)
        {

            Hashtable htcheck_Vendor_Order_Type_Abs = new Hashtable();
            System.Data.DataTable dtcheck_Vendor_Order_Type_Abs = new System.Data.DataTable();
            htcheck_Vendor_Order_Type_Abs.Add("@Trans", "GET_VENDOR_ORDER_TYPE_COVERAGE");
            htcheck_Vendor_Order_Type_Abs.Add("@Vendors_Id", Vendor_Id);
            htcheck_Vendor_Order_Type_Abs.Add("@Order_Type_Abs_Id", Order_Type_Id);
            dtcheck_Vendor_Order_Type_Abs = dataaccess.ExecuteSP("Sp_Vendor_Order_Type_Abs_Coverage", htcheck_Vendor_Order_Type_Abs);

            if (dtcheck_Vendor_Order_Type_Abs.Rows.Count > 0)
            {
               

                return true;
            }
            else
            {
                Vendor_Order_Type_Count = 1;
                return false;

            }
        }

        private bool Validate_Client_Sub_Client(int Vendor_Id, int Client_Id, int Sub_Process_Id)
        {

            Hashtable htget_vendor_Client_And_Sub_Client = new Hashtable();
            System.Data.DataTable dtget_Vendor_Client_And_Sub_Client = new System.Data.DataTable();

            htget_vendor_Client_And_Sub_Client.Add("@Trans", "GET_VENDOR_ON_CLIENT_AND_SUB_CLIENT");
            htget_vendor_Client_And_Sub_Client.Add("@Client_Id", Client_Id);
            htget_vendor_Client_And_Sub_Client.Add("@Sub_Client_Id", Sub_Process_Id);
            htget_vendor_Client_And_Sub_Client.Add("@Vendors_Id", Vendor_Id);
            dtget_Vendor_Client_And_Sub_Client = dataaccess.ExecuteSP("Sp_Vendor_Order_Assignment", htget_vendor_Client_And_Sub_Client);

            if (dtget_Vendor_Client_And_Sub_Client.Rows.Count > 0)
            {


                return true;


            }
            else
            {

                Vendor_Client_COunt = 1;
                return false;
            }

        }

        private void lbl_Header_Click(object sender, EventArgs e)
        {

        }

        private void btn_Move_To_research_Click(object sender, EventArgs e)
        {
               int Check_Count = 0;
               for (int i = 0; i < grd_order.Rows.Count; i++)
               {
                   bool isChecked = (bool)grd_order[0, i].FormattedValue;


                   if (isChecked == true)
                   {
                       Check_Count = 1;
                       string lbl_Order_Id = grd_order.Rows[i].Cells[10].Value.ToString();
                   

                       Hashtable htupdate = new Hashtable();
                       System.Data.DataTable dtupdate = new System.Data.DataTable();
                       htupdate.Add("@Trans", "UPDATE_STATUS");
                       htupdate.Add("@Order_ID", lbl_Order_Id);
                       htupdate.Add("@Order_Status", 25);
                       htupdate.Add("@Modified_By", User_id);
                       htupdate.Add("@Modified_Date", DateTime.Now);
                       dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);

                       Hashtable htupdate_Prog = new Hashtable();
                       System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                       htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                       htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                       htupdate_Prog.Add("@Order_Progress", 8);
                       htupdate_Prog.Add("@Modified_By", User_id);
                       htupdate_Prog.Add("@Modified_Date", DateTime.Now);

                       dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);


                       //OrderHistory
                       Hashtable ht_Order_History = new Hashtable();
                       System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                       ht_Order_History.Add("@Trans", "INSERT");
                       ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                       //  ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                       ht_Order_History.Add("@Status_Id", 25);
                       ht_Order_History.Add("@Progress_Id", 8);
                       ht_Order_History.Add("@Assigned_By", User_id);
                       ht_Order_History.Add("@Work_Type", 1);
                       ht_Order_History.Add("@Modification_Type", "Order Moved to ReSearch Order Queue");
                       dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);


                   }

                  

               }

               if (Check_Count == 1)
               {

                   MessageBox.Show("Order were moved to Research Order Queue");
                   Gridview_Bind_All_Orders();
               }
        }

        private void Rb_Task_Click(object sender, EventArgs e)
        {

        }

        private void rbtn_Move_To_Research_CheckedChanged(object sender, EventArgs e)
        {
            lbl_User_And_Status.Text = "Status";
            ddl_UserName.Visible = false;
            ddl_Order_Status_Reallocate.Visible = false;
            btn_Reallocate.Visible = false;
            btn_Deallocate.Visible = false;
            lbl_Task.Visible = false;


            ddl_Status.Visible = false;
            btn_Status.Visible = false;

            btn_Move_Research_User.Visible = true;
        }

        private void btn_Move_Research_User_Click(object sender, EventArgs e)
        {
            int Check_Count = 0;
            for (int i = 0; i < grd_order_Allocated.Rows.Count; i++)
            {
                bool isChecked = (bool)grd_order_Allocated[0, i].FormattedValue;


                if (isChecked == true)
                {
                    Check_Count = 1;
                    string lbl_Order_Id = grd_order_Allocated.Rows[i].Cells[8].Value.ToString();


                        Hashtable htget_User_Order_Last_Time_Updaetd = new Hashtable();
                        System.Data.DataTable dtget_User_Order_Last_Time_Updated = new System.Data.DataTable();
                        htget_User_Order_Last_Time_Updaetd.Add("@Trans", "MAX_TIME_BY_ORDER_ID");
                        htget_User_Order_Last_Time_Updaetd.Add("@Order_Id", lbl_Order_Id);
                        dtget_User_Order_Last_Time_Updated = dataaccess.ExecuteSP("[Sp_Order_User_Wise_Time_Track]", htget_User_Order_Last_Time_Updaetd);

                        if (dtget_User_Order_Last_Time_Updated.Rows.Count > 0)
                        {
                            Max_Time_Id = int.Parse(dtget_User_Order_Last_Time_Updated.Rows[0]["MAX_TIME_ID"].ToString());

                        }
                        else
                        {

                            Max_Time_Id = 0;
                        }

                        if (Max_Time_Id != 0)
                        {

                            Hashtable htget_User_Order_Differnce_Time = new Hashtable();
                            System.Data.DataTable dtget_User_Order_Differnce_Time = new System.Data.DataTable();
                            htget_User_Order_Differnce_Time.Add("@Trans", "GET_DIFFERNCE_TIME");
                            htget_User_Order_Differnce_Time.Add("@Order_Time_Id", Max_Time_Id);
                            dtget_User_Order_Differnce_Time = dataaccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htget_User_Order_Differnce_Time);

                            if (dtget_User_Order_Differnce_Time.Rows.Count > 0)
                            {
                                Differnce_Time = int.Parse(dtget_User_Order_Differnce_Time.Rows[0]["Diff"].ToString());

                            }
                            else
                            {
                                Differnce_Time = 0;

                            }

                            //htget_User_Order_Differnce_Time.Add("","");
                        }


                        if (Differnce_Time < 5)
                        {

                            Differnce_Count = 1;

                        }

                        if (Differnce_Time > 5)
                        {


                            Hashtable htupdate = new Hashtable();
                            System.Data.DataTable dtupdate = new System.Data.DataTable();
                            htupdate.Add("@Trans", "UPDATE_STATUS");
                            htupdate.Add("@Order_ID", lbl_Order_Id);
                            htupdate.Add("@Order_Status", 25);
                            htupdate.Add("@Modified_By", User_id);
                            htupdate.Add("@Modified_Date", DateTime.Now);
                            dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);

                            Hashtable htupdate_Prog = new Hashtable();
                            System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                            htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                            htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                            htupdate_Prog.Add("@Order_Progress", 8);
                            htupdate_Prog.Add("@Modified_By", User_id);
                            htupdate_Prog.Add("@Modified_Date", DateTime.Now);

                            dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order", htupdate_Prog);


                            //OrderHistory
                            Hashtable ht_Order_History = new Hashtable();
                            System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                            ht_Order_History.Add("@Trans", "INSERT");
                            ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                            //  ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            ht_Order_History.Add("@Status_Id", 25);
                            ht_Order_History.Add("@Progress_Id", 8);
                            ht_Order_History.Add("@Assigned_By", User_id);
                            ht_Order_History.Add("@Work_Type", 1);
                            ht_Order_History.Add("@Modification_Type", "Order Moved from Users Search Order Queue to ReSearch Order Allocation Queue");
                            dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);

                        }
                }



            }

            if (Check_Count == 1)
            {
                if (Differnce_Count != 1)
                {

                    MessageBox.Show("Some Orders Were not Updated Status because of Order are Work in Progress");
                }
                else
                {
                    MessageBox.Show("Order were moved to Research Order Queue");

                }
                Gridview_Bind_All_Orders();
            }
        }

        private void ddl_Client_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
       
        

       

  
        
   

   

      
        
        
    }
}
