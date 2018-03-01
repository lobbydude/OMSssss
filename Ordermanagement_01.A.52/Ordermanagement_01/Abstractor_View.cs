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


namespace Ordermanagement_01
{
    public partial class Abstractor_View : Form
    {
        Commonclass commnclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        int userid;
        string Empname;
        int Count;
        int Chk_Typing;
        int Status_Count;
        Hashtable htselect = new Hashtable();
        DataTable dtselect = new DataTable();
        Genral gen = new Genral();
        int BRANCH_ID;
        string User_Role_Id;
        int client_Id, Subprocess_id;
        int Order_Status;
        string Order_Process;

        InfiniteProgressBar.clsProgress cProbar = new InfiniteProgressBar.clsProgress();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        InfiniteProgressBar.frmProgress form = new InfiniteProgressBar.frmProgress();
        public Abstractor_View(int OrderStatus, string OrderProcess, int user_id, string Role_Id)
        {
             Order_Status = OrderStatus;
             Order_Process = OrderProcess;
             userid = user_id;
             User_Role_Id = Role_Id;
            InitializeComponent();
        }

        private void Abstractor_View_Load(object sender, EventArgs e)
        {
            if (User_Role_Id == "1")
            {
                Gridview_Bind_Assigned_Orders();
            }
        }

        protected void Gridview_Bind_Assigned_Orders()
        {
            Hashtable htuser = new Hashtable();
            DataTable dtuser = new System.Data.DataTable();
            //if (User_Role_Id == "2")
            //{
            if (Order_Process == "Abstract_ORDERS_ALLOCATE")
            {
                htuser.Add("@Trans", "USER_ABSTRACTOR_ORDERS_ADMIN1");
            }
            else
            {
                htuser.Add("@Trans", "USER_ABSTRACTOR_ORDERS_ADMIN1");
            }
            //}
            //else if (User_Role_Id == "1")
            //{
            //    htuser.Add("@Trans", "USER_ASSIGNED_ORDER_ADMIN");
            //}
            htuser.Add("@User_Id", userid);
            htuser.Add("@Order_Status", int.Parse(Order_Status.ToString()));
            dtuser = dataaccess.ExecuteSP("Sp_Order_Count", htuser);
            grd_Admin_orders.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkCyan;
            grd_Admin_orders.EnableHeadersVisualStyles = false;
            grd_Admin_orders.Columns[0].Width = 50;
            grd_Admin_orders.Columns[1].Width = 110;
            grd_Admin_orders.Columns[2].Width = 150;
            grd_Admin_orders.Columns[3].Width = 180;
            grd_Admin_orders.Columns[4].Width = 150;
            grd_Admin_orders.Columns[5].Width = 100;
            grd_Admin_orders.Columns[6].Width = 120;
            grd_Admin_orders.Columns[7].Width = 100;
            grd_Admin_orders.Columns[8].Width = 100;
            grd_Admin_orders.Columns[9].Width = 50;
            if (dtuser.Rows.Count > 0)
            {
                //ex2.Visible = true;
                grd_Admin_orders.Rows.Clear();
                for (int i = 0; i < dtuser.Rows.Count; i++)
                {
                    grd_Admin_orders.Rows.Add();
                    grd_Admin_orders.Rows[i].Cells[0].Value = i + 1;
                    grd_Admin_orders.Rows[i].Cells[1].Value = dtuser.Rows[i]["Client_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[2].Value = dtuser.Rows[i]["Sub_ProcessName"].ToString();
                    grd_Admin_orders.Rows[i].Cells[3].Value = dtuser.Rows[i]["Client_Order_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[4].Value = dtuser.Rows[i]["Order_Type"].ToString();
                    grd_Admin_orders.Rows[i].Cells[5].Value = dtuser.Rows[i]["STATECOUNTY"].ToString();
                    grd_Admin_orders.Rows[i].Cells[6].Value = dtuser.Rows[i]["User_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[7].Value = dtuser.Rows[i]["Date"].ToString();
                    grd_Admin_orders.Rows[i].Cells[8].Value = dtuser.Rows[i]["Progress_Status"].ToString();
                    grd_Admin_orders.Rows[i].Cells[9].Value = dtuser.Rows[i]["Order_ID"].ToString();
                    grd_Admin_orders.Rows[i].Cells[11].Value = dtuser.Rows[i]["Subprocess_Id"].ToString();
                    grd_Admin_orders.Rows[i].Cells[12].Value = dtuser.Rows[i]["State_ID"].ToString();
                    // grd_Pending_Orders.Rows[i].Cells[9].Value = dtuser.Rows[i]["Order_Statusid"].ToString();

                    if (int.Parse(grd_Admin_orders.Rows[i].Cells[11].Value.ToString()) == 210 && int.Parse(grd_Admin_orders.Rows[i].Cells[12].Value.ToString()) == 34)
                    {

                        grd_Admin_orders.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.YellowGreen;
                    }
                }
            }
            else
            {
                grd_Admin_orders.Rows.Clear();
                grd_Admin_orders.DataSource = null;
                //grd_Admin_orders.EmptyDataText = "No Orders Are Avilable";
                //grd_Admin_orders.DataBind();
            }
        }

        private void link_Search_Order_Allocation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grd_Admin_orders.Rows.Count; i++)
            {

                bool chkId = (bool)grd_Admin_orders[10, i].FormattedValue;

                if (chkId== true)
                {
                    string lbl_Order_Id = grd_Admin_orders.Rows[i].Cells[9].Value.ToString();

                    Hashtable htstatus = new Hashtable();
                    DataTable dtstatus = new System.Data.DataTable();
                    htstatus.Add("@Trans", "UPDATE_STATUS");
                    htstatus.Add("@Order_ID", lbl_Order_Id);
                    htstatus.Add("@Order_Status", 2);
                    htstatus.Add("@Modified_By", userid);
                    htstatus.Add("@Modified_Date", DateTime.Now);
                    dtstatus = dataaccess.ExecuteSP("Sp_Order", htstatus);


                    Hashtable htupdate_ABS = new Hashtable();
                    DataTable dtupdate_ABS = new System.Data.DataTable();
                    htupdate_ABS.Add("@Trans", "UPDATE_ABSTRACTOR");
                    htupdate_ABS.Add("@Order_ID", lbl_Order_Id);
                    htupdate_ABS.Add("@Order_Progress", 8);
                    htupdate_ABS.Add("@Modified_By", userid);
                    htupdate_ABS.Add("@Modified_Date", DateTime.Now);
                    dtupdate_ABS = dataaccess.ExecuteSP("Sp_Order", htupdate_ABS);




                    Hashtable htupdate = new Hashtable();
                    DataTable dtupdate = new System.Data.DataTable();
                    htupdate.Add("@Trans", "UPDATE_ORDER_ASSIGN_TYPE");
                    htupdate.Add("@Order_ID", lbl_Order_Id);
                    htupdate.Add("@Order_Assign_Type", 4);
                    htupdate.Add("@Modified_By", userid);
                    htupdate.Add("@Modified_Date", DateTime.Now);
                    dtupdate = dataaccess.ExecuteSP("Sp_Order", htupdate);


                    /*-----------------Order History---------------------------*/
                    Hashtable hthistroy = new Hashtable();
                    DataTable dthistroy = new DataTable();
                    hthistroy.Add("@Trans", "INSERT");
                    hthistroy.Add("@Order_Id", lbl_Order_Id);
                    //hthistroy.Add("@User_Id", Tree_View_UserId);
                    hthistroy.Add("@Status_Id", 2);
                    hthistroy.Add("@Progress_Id", 8);
                    hthistroy.Add("@Assigned_By", userid);
                    hthistroy.Add("@Modification_Type", "Abstractor order Reallocated");
                    hthistroy.Add("@Work_Type", 1);
                    dthistroy = dataaccess.ExecuteSP("Sp_Order_History", hthistroy);
                }


            }
            Gridview_Bind_Assigned_Orders();
        }

        private void grd_Admin_orders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3 )
            {
                //Ordermanagement_01.Abstractor_Order_Entry OrderEntry = new Ordermanagement_01.Abstractor_Order_Entry(grd_Admin_orders.Rows[e.RowIndex].Cells[3].Value.ToString(), int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[8].Value.ToString()), userid, User_Role_Id, Order_Process, Order_Status);
                //OrderEntry.Show();
            }
        }

        private void grd_Admin_orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                form_loader.Start_progres();
                //cProbar.startProgress();

                Ordermanagement_01.Order_Entry OrderEntry = new Ordermanagement_01.Order_Entry(int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[9].Value.ToString()), userid, User_Role_Id);
                OrderEntry.Show();
                //cProbar.stopProgress();
            }
        }

        private void txt_SearchOrdernumber_TextChanged(object sender, EventArgs e)
        {
            txt_SearchOrdernumber.ForeColor = Color.Black;
            foreach (DataGridViewRow row in grd_Admin_orders.Rows)
            {
                if (txt_SearchOrdernumber.Text != "" && row.Cells[3].Value.ToString().StartsWith(txt_SearchOrdernumber.Text, true, CultureInfo.InvariantCulture))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void txt_SearchOrdernumber_Click(object sender, EventArgs e)
        {
            txt_SearchOrdernumber.ForeColor = Color.Black;
            txt_SearchOrdernumber.Text = "";
        }
    }
}
