﻿using System;
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
    public partial class Rework_Order_View : Form
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
        DataTable dtuser = new System.Data.DataTable();
        DataTable dt = new System.Data.DataTable();
        Genral gen = new Genral();
        int BRANCH_ID;
        string User_Role_Id;
        static int currentpageindex = 0;
        int pagesize=10;
        int Order_Progress;
        string Order_Process;

        InfiniteProgressBar.clsProgress cProbar = new InfiniteProgressBar.clsProgress();
        public Rework_Order_View(int OrderProgress, int user_id, string Role_Id)
        {
            InitializeComponent();

            Order_Progress = OrderProgress;
            userid = user_id;
            User_Role_Id = Role_Id;
        }

        private void Rework_Order_View_Load(object sender, EventArgs e)
        {
            dbc.BindUserName_Allocate(ddl_UserName);
            dbc.BindOrderStatus(ddl_Order_Status_Reallocate);
            Gridview_Bind_Assigned_Orders();
            btnFirst_Click(sender, e);
        }
        private void GetRowTable(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dtuser.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }
        protected void Gridview_Bind_Assigned_Orders()
        {
            Hashtable htuser = new Hashtable();
           
            if (Order_Progress == 3)
            {
                htuser.Add("@Trans", "REWORK_COMPLETED_ORDER");
            }
            else
            {
                htuser.Add("@Trans", "REWORK_PENDING_ORDER");
            }
            htuser.Add("@User_Id", userid);
            htuser.Add("@Order_Progress", int.Parse(Order_Progress.ToString()));
            dtuser = dataaccess.ExecuteSP("Sp_Order_Rework_Count", htuser);
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
            grd_Admin_orders.Columns[9].Width = 100;
            grd_Admin_orders.Columns[10].Width = 50;

            System.Data.DataTable temptable = dtuser.Clone();

            int start_index = currentpageindex * pagesize;
            int end_index = currentpageindex * pagesize + pagesize;
            if (end_index > dtuser.Rows.Count)
            {
                end_index = dtuser.Rows.Count;
            }
            for (int i = start_index; i < end_index; i++)
            {
                DataRow row = temptable.NewRow();
                GetRowTable(ref row, dtuser.Rows[i]);
                temptable.Rows.Add(row);
            }


            if (temptable.Rows.Count > 0)
            {
                //ex2.Visible = true;
               
                //ex2.Visible = true;
                grd_Admin_orders.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    grd_Admin_orders.Rows.Add();
                    grd_Admin_orders.Rows[i].Cells[0].Value = i + 1;
                    if (User_Role_Id == "1")
                    {
                        grd_Admin_orders.Rows[i].Cells[1].Value = temptable.Rows[i]["Client_Name"].ToString();
                        grd_Admin_orders.Rows[i].Cells[2].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                    }
                    else if (User_Role_Id == "2")
                    {
                        grd_Admin_orders.Rows[i].Cells[1].Value = temptable.Rows[i]["Client_Number"].ToString();
                        grd_Admin_orders.Rows[i].Cells[2].Value = temptable.Rows[i]["Subprocess_Number"].ToString();
                    
                    }
                    grd_Admin_orders.Rows[i].Cells[3].Value = temptable.Rows[i]["Client_Order_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Type"].ToString();
                    grd_Admin_orders.Rows[i].Cells[5].Value = temptable.Rows[i]["STATECOUNTY"].ToString();
                    grd_Admin_orders.Rows[i].Cells[6].Value = temptable.Rows[i]["User_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[7].Value = temptable.Rows[i]["Date"].ToString();
                    grd_Admin_orders.Rows[i].Cells[8].Value = temptable.Rows[i]["Order_Task"].ToString();
                    grd_Admin_orders.Rows[i].Cells[9].Value = temptable.Rows[i]["Progress_Status"].ToString();
                    grd_Admin_orders.Rows[i].Cells[10].Value = temptable.Rows[i]["Order_ID"].ToString();
                    grd_Admin_orders.Rows[i].Cells[12].Value = temptable.Rows[i]["User_id"].ToString();
                }
            }
            else
            {
                grd_Admin_orders.Rows.Clear();
                grd_Admin_orders.DataSource = null;
            }
            lbl_Total_Orders.Text = dtuser.Rows.Count.ToString();
            lblRecordsStatus.Text = (currentpageindex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtuser.Rows.Count) / pagesize);
            
        }

        private void link_Search_Order_Allocation_Click(object sender, EventArgs e)
        {
            if (ddl_Order_Status_Reallocate.Text != "SELECT" && ddl_UserName.Text != "SELECT")
            {
                for (int i = 0; i < grd_Admin_orders.Rows.Count; i++)
                {
                    bool isChecked = (bool)grd_Admin_orders[11,i].FormattedValue;


                    int Reallocateduser = int.Parse(ddl_UserName.SelectedValue.ToString());

                    System.Windows.Forms.CheckBox chk = (grd_Admin_orders.Rows[i].Cells[11].FormattedValue as System.Windows.Forms.CheckBox);

                    // CheckBox chk = (CheckBox)row.f("chkAllocatedSelect");
                    if (isChecked == true)
                    {
                        string lbl_Order_Id = grd_Admin_orders.Rows[i].Cells[10].Value.ToString();
                     
                        string lbl_Allocated_Userid = grd_Admin_orders.Rows[i].Cells[12].Value.ToString();
                      
                        //  int Allocated_Userid = int.Parse(lbl_Allocated_Userid.Text);

                        Hashtable htinsertrec = new Hashtable();
                        System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");



                        Hashtable htcheck = new Hashtable();
                        System.Data.DataTable dtcheck = new System.Data.DataTable();

                        int Rework_Check;
                        htcheck.Add("@Trans", "CHECK");
                        htcheck.Add("@Order_Id", lbl_Order_Id);
                        dtcheck = dataaccess.ExecuteSP("Sp_Rework_Order_Assignment", htcheck);
                        if (dtcheck.Rows.Count > 0)
                        {
                            Rework_Check = int.Parse(dtcheck.Rows[0]["count"].ToString());

                        }
                        else
                        {

                            Rework_Check = 0;

                        }


                        if (Rework_Check > 0)
                        {
                            Hashtable htdel = new Hashtable();
                            System.Data.DataTable dtdel = new System.Data.DataTable();
                            htdel.Add("@Trans", "DELETE_BY_ORDER_ID");
                            htdel.Add("@Order_Id", lbl_Order_Id);
                            dtdel = dataaccess.ExecuteSP("Sp_Rework_Order_Assignment", htdel);



                        }

                        htinsertrec.Add("@Trans", "INSERT");
                        htinsertrec.Add("@Order_Id", lbl_Order_Id);
                        htinsertrec.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        htinsertrec.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htinsertrec.Add("@Order_Progress_Id", 6);
                        htinsertrec.Add("@Assigned_Date", dateeval);
                        htinsertrec.Add("@Assigned_By", userid);
                        htinsertrec.Add("@Inserted_By", userid);
                        htinsertrec.Add("@Inserted_date", date);
                        htinsertrec.Add("@status", "True");
                        dtinsertrec = dataaccess.ExecuteSP("Sp_Rework_Order_Assignment", htinsertrec);

                      
                        Hashtable htorderStatus = new Hashtable();
                        System.Data.DataTable dtorderStatus = new System.Data.DataTable();
                        htorderStatus.Add("@Trans", "UPDATE_TASK");
                        htorderStatus.Add("@Order_ID", lbl_Order_Id);
                        htorderStatus.Add("@Current_Task", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus.Add("@Modified_By", userid);
                        htorderStatus.Add("@Modified_Date", date);
                        dtorderStatus = dataaccess.ExecuteSP("Sp_Order_Rework_Status", htorderStatus);


                        Hashtable htorderStatus_Allocate = new Hashtable();
                        System.Data.DataTable dtorderStatus_Allocate = new System.Data.DataTable();
                        htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
                        htorderStatus_Allocate.Add("@Order_ID", lbl_Order_Id);
                        htorderStatus_Allocate.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_By", userid);
                        htorderStatus_Allocate.Add("@Assigned_Date", Convert.ToString(dateeval));
                        htorderStatus_Allocate.Add("@Assigned_By", userid);
                        htorderStatus_Allocate.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_Date", date);
                        dtorderStatus_Allocate = dataaccess.ExecuteSP("Sp_Order_Rework_Assignment", htorderStatus_Allocate);


                        Hashtable htupdate_Prog = new Hashtable();
                        System.Data.DataTable dtupdate_Prog = new System.Data.DataTable();
                        htupdate_Prog.Add("@Trans", "UPDATE_STATUS");
                        htupdate_Prog.Add("@Order_ID", lbl_Order_Id);
                        htupdate_Prog.Add("@Cureent_Status", 6);
                        htupdate_Prog.Add("@Modified_By", userid);
                        htupdate_Prog.Add("@Modified_Date", DateTime.Now);
                        dtupdate_Prog = dataaccess.ExecuteSP("Sp_Order_Rework_Status", htupdate_Prog);


                        //OrderHistory
                        Hashtable ht_Order_History = new Hashtable();
                        System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                        ht_Order_History.Add("@Trans", "INSERT");
                        ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                        ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        ht_Order_History.Add("@Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        ht_Order_History.Add("@Progress_Id", 6);
                        ht_Order_History.Add("@Assigned_By", userid);
                        ht_Order_History.Add("@Work_Type",2);
                        ht_Order_History.Add("@Modification_Type", "Rework Order Reallocated");
                        dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);





                        Gridview_Bind_Assigned_Orders();
                        // PopulateTreeview();

                      
                        MessageBox.Show("Order Reallocated Successfully");



                    }
                }

            }
            
        }
        private void Get_Order_number_Search(ref DataRow source,DataRow dest)
        {
            foreach (DataColumn col in dt.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }
        private void Bind_Filter_Data()
        {
            DataView dtsearch = new DataView(dtuser);
            dtsearch.RowFilter = "Client_Order_Number like '%" + txt_Order_Number.Text.ToString().ToString() + "%' ";
            dt = dtsearch.ToTable();

            System.Data.DataTable temptable = dt.Clone();

            int start_index = currentpageindex * pagesize;
            int end_index = currentpageindex * pagesize + pagesize;
            if (end_index > dtuser.Rows.Count)
            {
                end_index = dt.Rows.Count;
            }
            for (int i = start_index; i < end_index; i++)
            {
                DataRow row = temptable.NewRow();
                GetRowTable(ref row, dt.Rows[i]);
                temptable.Rows.Add(row);
            }


            if (temptable.Rows.Count > 0)
            {
                grd_Admin_orders.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    grd_Admin_orders.Rows.Add();
                    grd_Admin_orders.Rows[i].Cells[0].Value = i + 1;
                    if (User_Role_Id == "1")
                    {
                        grd_Admin_orders.Rows[i].Cells[1].Value = temptable.Rows[i]["Client_Name"].ToString();
                        grd_Admin_orders.Rows[i].Cells[2].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                    }
                    else if (User_Role_Id == "2")
                    {
                        grd_Admin_orders.Rows[i].Cells[1].Value = temptable.Rows[i]["Client_Number"].ToString();
                        grd_Admin_orders.Rows[i].Cells[2].Value = temptable.Rows[i]["Subprocess_Number"].ToString();

                    }
                    grd_Admin_orders.Rows[i].Cells[3].Value = temptable.Rows[i]["Client_Order_Number"].ToString();
                    grd_Admin_orders.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Type"].ToString();
                    grd_Admin_orders.Rows[i].Cells[5].Value = temptable.Rows[i]["STATECOUNTY"].ToString();
                    grd_Admin_orders.Rows[i].Cells[6].Value = temptable.Rows[i]["User_Name"].ToString();
                    grd_Admin_orders.Rows[i].Cells[7].Value = temptable.Rows[i]["Date"].ToString();
                    grd_Admin_orders.Rows[i].Cells[8].Value = temptable.Rows[i]["Order_Task"].ToString();
                    grd_Admin_orders.Rows[i].Cells[9].Value = temptable.Rows[i]["Progress_Status"].ToString();
                    grd_Admin_orders.Rows[i].Cells[10].Value = temptable.Rows[i]["Order_ID"].ToString();
                    grd_Admin_orders.Rows[i].Cells[12].Value = temptable.Rows[i]["User_id"].ToString();
                  
                }
            }
            else
            {
                grd_Admin_orders.Rows.Clear();
                grd_Admin_orders.Visible = true;
                grd_Admin_orders.DataSource = null;
            }
            //btnFirst_Click(null, null);
            First_Page();
           

        }
        private void First_Page()
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentpageindex = 0;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            btnFirst.Enabled = false;
           
            this.Cursor = currentCursor;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentpageindex <= (dtuser.Rows.Count / pagesize))
            {
                Cursor currentCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;

                currentpageindex++;

                if (currentpageindex == (int)Math.Ceiling(Convert.ToDecimal(dtuser.Rows.Count) / pagesize) - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;

                }


                if (txt_Order_Number.Text != "Search Order number....." && txt_Order_Number.Text != "")
                {
                    Bind_Filter_Data();
                }
                else
                {
                    Gridview_Bind_Assigned_Orders();
                }

                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;

                this.Cursor = currentCursor;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

        
            if (txt_Order_Number.Text != "Search Order number....." && txt_Order_Number.Text != "")
            {
                currentpageindex = (int)Math.Ceiling(Convert.ToDecimal(dt.Rows.Count) / pagesize) - 1;
                Bind_Filter_Data();
            }
            else
            {
                currentpageindex = (int)Math.Ceiling(Convert.ToDecimal(dt.Rows.Count) / pagesize) - 1;
                Gridview_Bind_Assigned_Orders();
            }
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            btnLast.Enabled = false;

            this.Cursor = currentCursor;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentpageindex >= 1)
            {
                Cursor currentCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                // splitContainer1.Enabled = false;
                currentpageindex--;
                if (currentpageindex == 0)
                {
                    btnPrevious.Enabled = false;
                    btnFirst.Enabled = false;
                }
                else
                {
                    btnPrevious.Enabled = true;
                    btnFirst.Enabled = true;

                }
                btnNext.Enabled = true;
                btnLast.Enabled = true;
                if (txt_Order_Number.Text != "Search Order number....." && txt_Order_Number.Text != "")
                {
                    Bind_Filter_Data();
                }
                else
                {
                    Gridview_Bind_Assigned_Orders();
                }
                this.Cursor = currentCursor;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentpageindex = 0;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            btnFirst.Enabled = false;
            if (txt_Order_Number.Text != "Search Order number....." && txt_Order_Number.Text != "")
            {
                Bind_Filter_Data();
            }
            else
            {
                Gridview_Bind_Assigned_Orders();
            }
            this.Cursor = currentCursor;
        }
     
        private void txt_Order_Number_TextChanged(object sender, EventArgs e)
        {
            if (txt_Order_Number.Text != "")
            {
                Bind_Filter_Data();
            }
            else
            {
                Gridview_Bind_Assigned_Orders();

            }
        }

        private void txt_Order_Number_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Order_Number.Text == "Search Order number.....")
            {
                txt_Order_Number.Text = "";
                txt_Order_Number.ForeColor = Color.Black;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grd_Admin_orders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                Ordermanagement_01.Rework_Superqc_Order_Entry Order_Entry = new Ordermanagement_01.Rework_Superqc_Order_Entry(int.Parse(grd_Admin_orders.Rows[e.RowIndex].Cells[10].Value.ToString()), userid, "Rework", User_Role_Id);
                Order_Entry.Show();

            }

        }
    }
}
