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
using System.Text.RegularExpressions;
using System.Globalization;
namespace Ordermanagement_01.Masters
{
    public partial class Client_Order_Cost : Form
    {
        int User_Id, Check_value, Clientid;
        decimal orderCost;
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        System.Data.DataTable dtorder_info = new System.Data.DataTable();
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataTable dtselect = new System.Data.DataTable();
        static int currentpageindex = 0;
        int pagesize = 10;
        int Client_Order_Cost_Id;
        public Client_Order_Cost(int USER_ID)
        {
            InitializeComponent();
            User_Id = USER_ID;
        }
        private void GetDataRowTable(ref DataRow dest, DataRow source)
        {
            foreach(DataColumn col in dtorder_info.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }

        private void Bind_Clint_Order_CostDetails()
        {


            Hashtable ht = new Hashtable();
            
            grd_Client_cost.Rows.Clear();
            ht.Add("@Trans", "SELECT");
            dtorder_info = dataaccess.ExecuteSP("Sp_Client_Order_Cost", ht);

            DataTable temptable = dtorder_info.Clone();
            int startindex = currentpageindex * pagesize;
            int endindex = currentpageindex * pagesize + pagesize;
            if (endindex > dtorder_info.Rows.Count)
            {
                endindex = dtorder_info.Rows.Count;
            }
            for (int i = startindex; i < endindex; i++)
            {
                DataRow newrow = temptable.NewRow();
                GetDataRowTable(ref newrow, dtorder_info.Rows[i]);
                temptable.Rows.Add(newrow);
            }

            grd_Client_cost.Rows.Clear();
            if (temptable.Rows.Count > 0)
            {

                for (int i = 0; i < temptable.Rows.Count; i++)
                {

                    grd_Client_cost.Rows.Add();
                    grd_Client_cost.Rows[i].Cells[0].Value = temptable.Rows[i]["Client_Name"].ToString();
                    grd_Client_cost.Rows[i].Cells[1].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                    grd_Client_cost.Rows[i].Cells[2].Value = temptable.Rows[i]["Abbreviation"].ToString();
                    grd_Client_cost.Rows[i].Cells[3].Value = temptable.Rows[i]["County"].ToString();
                    grd_Client_cost.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Type"].ToString();
                    grd_Client_cost.Rows[i].Cells[5].Value = temptable.Rows[i]["Order_Cost"].ToString();
                    grd_Client_cost.Rows[i].Cells[6].Value = temptable.Rows[i]["State_ID"].ToString();
                    grd_Client_cost.Rows[i].Cells[7].Value = temptable.Rows[i]["County_ID"].ToString();
                    grd_Client_cost.Rows[i].Cells[8].Value = temptable.Rows[i]["Client_Order_Cost_Id"].ToString();
                    grd_Client_cost.Rows[i].Cells[9].Value = temptable.Rows[i]["Client_Id"].ToString();
                    grd_Client_cost.Rows[i].Cells[10].Value = temptable.Rows[i]["Order_Type_ID"].ToString();
                    grd_Client_cost.Rows[i].Cells[11].Value = temptable.Rows[i]["Subprocess_Id"].ToString();
                }


            }
            else
            {

                grd_Client_cost.Rows.Clear();
            }
            lbl_Total_Orders.Text = dtorder_info.Rows.Count.ToString();
            lblRecordsStatus.Text = (currentpageindex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtorder_info.Rows.Count) / pagesize);

            
        
        }

        private void Client_Order_Cost_Load(object sender, EventArgs e)
        {
            dbc.BindClientName(ddl_ClientName);
            dbc.BindState(ddl_State);
            dbc.BindOrderType(ddl_ordertype);
            Bind_Clint_Order_CostDetails();
            First_Page();
         //   ddl_Search_By.Items.Add("Select");
            ddl_Search_By.SelectedItem = "Select";
            dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));

           // Clientid = int.Parse(ddl_ClientName.SelectedValue.ToString());
            dbc.Bind_Sub_ClientName(ddl_Sub_ClientName);
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

        private void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_State.SelectedIndex > 0)
            {

                dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (btn_Save.Text == "Save" && validate()!=false && Client_Order_Cost_Id==0)
            {
              
                Hashtable htcheck = new Hashtable();
                System.Data.DataTable dtcheck = new System.Data.DataTable();
                htcheck.Add("@Trans", "CHECK");
                htcheck.Add("@Client_Id",ddl_ClientName.SelectedValue.ToString());
                htcheck.Add("@Sub_Process_Id", ddl_Sub_ClientName.SelectedValue.ToString());
                htcheck.Add("@Order_Type_Id",ddl_ordertype.SelectedValue.ToString());
                htcheck.Add("@County_Id", ddl_County.SelectedValue.ToString());
                htcheck.Add("@State_Id", ddl_State.SelectedValue.ToString());
                dtcheck = dataaccess.ExecuteSP("Sp_Client_Order_Cost", htcheck);
                if (dtcheck.Rows.Count > 0)
                {
                    Check_value = int.Parse(dtcheck.Rows[0]["COUNT"].ToString());
                }
                else
                {

                    Check_value = 0;
                }

                if (Check_value == 0)
                {
                     string Value = txt_Order_Cost.Text;
                        if (Value != "")
                        {
                       
                            orderCost = Convert.ToDecimal(txt_Order_Cost.Text);
                        }
                        else
                        {

                            orderCost = 0;
                        }
                    Hashtable htabsinsert = new Hashtable();
                    System.Data.DataTable dtabsinsert = new System.Data.DataTable();
                    htabsinsert.Add("@Trans", "INSERT");
                    htabsinsert.Add("@Client_Id", ddl_ClientName.SelectedValue.ToString());
                    htabsinsert.Add("@Sub_Process_Id", ddl_Sub_ClientName.SelectedValue.ToString());
                    htabsinsert.Add("@Order_Type_Id", ddl_ordertype.SelectedValue.ToString());
                    htabsinsert.Add("@County_Id", ddl_County.SelectedValue.ToString());
                    htabsinsert.Add("@State_Id", ddl_State.SelectedValue.ToString());
                    htabsinsert.Add("@Order_Cost", orderCost);
                    htabsinsert.Add("@Inserted_By", User_Id);
                    htabsinsert.Add("@Inserted_date", DateTime.Now);
                    htabsinsert.Add("@Status", "True");
                    dtabsinsert = dataaccess.ExecuteSP("Sp_Client_Order_Cost", htabsinsert);
                    string title = "Insert";
                    MessageBox.Show("Order Cost Added Sucessfully",title);
                    btn_Clear_Click(sender, e);
                    Bind_Clint_Order_CostDetails();
                }

            }
            else if (btn_Save.Text == "Edit" && validate() != false && Client_Order_Cost_Id != 0)
            {
                string Value = txt_Order_Cost.Text;
                if (Value != "")
                {

                    orderCost = Convert.ToDecimal(txt_Order_Cost.Text);
                }
                else
                {

                    orderCost = 0;
                }
                Hashtable htabs_Update = new Hashtable();
                System.Data.DataTable dtabs_Update = new System.Data.DataTable();

                htabs_Update.Add("@Trans", "UPDATE");
                htabs_Update.Add("@Client_Order_Cost_Id", Client_Order_Cost_Id);
                htabs_Update.Add("@Client_Id", ddl_ClientName.SelectedValue.ToString());
                htabs_Update.Add("@Sub_Process_Id", ddl_Sub_ClientName.SelectedValue.ToString());
                htabs_Update.Add("@Order_Type_Id", ddl_ordertype.SelectedValue.ToString());
                htabs_Update.Add("@County_Id", ddl_County.SelectedValue.ToString());
                htabs_Update.Add("@State_Id", ddl_State.SelectedValue.ToString());
                htabs_Update.Add("@Order_Cost", orderCost);
                htabs_Update.Add("@Inserted_By", User_Id);
                htabs_Update.Add("@Inserted_date", DateTime.Now);
                htabs_Update.Add("@Status", "True");
                dtabs_Update = dataaccess.ExecuteSP("Sp_Client_Order_Cost", htabs_Update);
                string title = "Updated";
                MessageBox.Show("Order Cost Updated Sucessfully",title);
                btn_Clear_Click(sender, e);
                Bind_Clint_Order_CostDetails();
            }
        }

        private bool validate()
        {
            string title = "Validation!";
            if (ddl_ClientName.SelectedIndex <= 0)
            {

                MessageBox.Show("Select Client Name",title);
                ddl_ClientName.Focus();
                return false;
                
            }
            if (ddl_Sub_ClientName.SelectedIndex <= 0)
            {

                MessageBox.Show("Select Sub Client Name", title);
                ddl_Sub_ClientName.Focus();
                return false;

            }
            if (ddl_State.SelectedIndex <= 0)
            {
                
                MessageBox.Show("Select State Name",title);
                ddl_State.Focus();
                return false;

            }
            if (ddl_County.SelectedIndex <= 0)
            {

                MessageBox.Show("Select County Name",title);
                ddl_County.Focus();
                return false;

            }
            if (ddl_ordertype.SelectedIndex <= 0)
            {
                
                MessageBox.Show("Select Order Type",title);
                ddl_County.Focus();
                return false;

            }
            if (txt_Order_Cost.Text == "")
            {
                MessageBox.Show("Enter Order Cost",title);
                txt_Order_Cost.Focus();
                return false;

            }
            return true;
            
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ddl_ClientName.SelectedIndex = 0;
            ddl_Sub_ClientName.SelectedIndex = 0;
            ddl_State.SelectedIndex = 0;
            ddl_ordertype.SelectedIndex = 0;
            ddl_County.SelectedIndex = 0;
            txt_Order_Cost.Text = "";
            btn_Save.Text = "Save";

            ddl_Search_By.SelectedIndex = 0;
            txt_search.Text = "";

        }

        private void grd_Client_cost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
            if (e.ColumnIndex == 0)
            {

                ddl_ClientName.SelectedValue = grd_Client_cost.Rows[e.RowIndex].Cells[9].Value.ToString();
                ddl_Sub_ClientName.SelectedValue = grd_Client_cost.Rows[e.RowIndex].Cells[11].Value.ToString();
                ddl_State.SelectedValue = grd_Client_cost.Rows[e.RowIndex].Cells[6].Value.ToString();
                dbc.BindCounty(ddl_County,int.Parse(ddl_State.SelectedValue.ToString()));
                ddl_County.SelectedValue = grd_Client_cost.Rows[e.RowIndex].Cells[7].Value.ToString();
                txt_Order_Cost.Text = grd_Client_cost.Rows[e.RowIndex].Cells[5].Value.ToString();
                ddl_ordertype.SelectedValue = grd_Client_cost.Rows[e.RowIndex].Cells[10].Value.ToString();
                btn_Save.Text = "Edit";
                 Client_Order_Cost_Id = int.Parse(grd_Client_cost.Rows[e.RowIndex].Cells[8].Value.ToString());

            }
            }
        }

        private void txt_APN_TextChanged(object sender, EventArgs e)
        {
            Binnd_Filter_Data();
            First_Page();
            //foreach (DataGridViewRow row in grd_Client_cost.Rows)
            //{
            //    if (txt_search.Text != "")
            //    {

            //        if (txt_search.Text != "" && ddl_Search_By.Text == "Client" && row.Cells[0].Value.ToString().StartsWith(txt_search.Text, true, CultureInfo.InvariantCulture))
            //        {

            //            row.Visible = true;

            //        }
            //        else if (txt_search.Text != "" && ddl_Search_By.Text == "State" && row.Cells[1].Value.ToString().StartsWith(txt_search.Text, true, CultureInfo.InvariantCulture))
            //        {

            //            row.Visible = true;
            //        }
            //        else if (txt_search.Text != "" && ddl_Search_By.Text == "County" && row.Cells[2].Value.ToString().StartsWith(txt_search.Text, true, CultureInfo.InvariantCulture))
            //        {

            //            row.Visible = true;
            //        }
            //        else if (txt_search.Text != "" && ddl_Search_By.Text == "OrderType" && row.Cells[3].Value.ToString().StartsWith(txt_search.Text, true, CultureInfo.InvariantCulture))
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
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Bind_Clint_Order_CostDetails();

            First_Page();
            //btn_Clear_Click(sender, e);
            ddl_ClientName.SelectedIndex = 0;
            ddl_State.SelectedIndex = 0;
            ddl_ordertype.SelectedIndex = 0;
            ddl_Search_By.SelectedIndex = 0;
            txt_Order_Cost.Text = "";
            txt_search.Text = "";
            ddl_County.SelectedIndex = 0;
         
        }

        private void ddl_ClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_ClientName.SelectedIndex != 0)
            {
                Clientid = int.Parse(ddl_ClientName.SelectedValue.ToString());
                dbc.Bind_ClientWise_SubClientName(ddl_Sub_ClientName, Clientid);
            }
            else
            {
            }
        }
        private void GetDataRowTable_search(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dtselect.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }
        private void Binnd_Filter_Data()
        {
            DataView dtsearch = new DataView(dtorder_info);

            string search = ddl_Search_By.Text.ToString();

            if (search == "Client")
            {
                dtsearch.RowFilter = "Client_Name like '%" + txt_search.Text.ToString() + "%'";
            }
            else if (search == "Sub ClientName")
            {
                dtsearch.RowFilter = "Sub_ProcessName like '%" + txt_search.Text.ToString() + "%'";
            }
            else if (search == "State")
            {
                dtsearch.RowFilter = "Abbreviation like '%" + txt_search.Text.ToString() + "%'";
            }
            else if (search == "County")
            {
                dtsearch.RowFilter = "County like '%" + txt_search.Text.ToString() + "%'";
            }
            else if (search == "OrderType")
            {
                dtsearch.RowFilter = "Order_Type like '%" + txt_search.Text.ToString() + "%'";
            }

            dtselect = dtsearch.ToTable();
            DataTable temptable = dtselect.Clone();
            int startindex = currentpageindex * pagesize;
            int endindex = currentpageindex * pagesize + pagesize;
            if (endindex > dtselect.Rows.Count)
            {
                endindex = dtselect.Rows.Count;
            }
            for (int i = startindex; i < endindex; i++)
            {
                DataRow newrow = temptable.NewRow();
                GetDataRowTable_search(ref newrow, dtselect.Rows[i]);
                temptable.Rows.Add(newrow);
            }

            grd_Client_cost.Rows.Clear();
            if (temptable.Rows.Count > 0)
            {

                for (int i = 0; i < temptable.Rows.Count; i++)
                {

                    grd_Client_cost.Rows.Add();
                    grd_Client_cost.Rows[i].Cells[0].Value = temptable.Rows[i]["Client_Name"].ToString();
                    grd_Client_cost.Rows[i].Cells[1].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                    grd_Client_cost.Rows[i].Cells[2].Value = temptable.Rows[i]["Abbreviation"].ToString();
                    grd_Client_cost.Rows[i].Cells[3].Value = temptable.Rows[i]["County"].ToString();
                    grd_Client_cost.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Type"].ToString();
                    grd_Client_cost.Rows[i].Cells[5].Value = temptable.Rows[i]["Order_Cost"].ToString();
                    grd_Client_cost.Rows[i].Cells[6].Value = temptable.Rows[i]["State_ID"].ToString();
                    grd_Client_cost.Rows[i].Cells[7].Value = temptable.Rows[i]["County_ID"].ToString();
                    grd_Client_cost.Rows[i].Cells[8].Value = temptable.Rows[i]["Client_Order_Cost_Id"].ToString();
                    grd_Client_cost.Rows[i].Cells[9].Value = temptable.Rows[i]["Client_Id"].ToString();
                    grd_Client_cost.Rows[i].Cells[10].Value = temptable.Rows[i]["Order_Type_ID"].ToString();
                    grd_Client_cost.Rows[i].Cells[11].Value = temptable.Rows[i]["Subprocess_Id"].ToString();
                }


            }
            else
            {

                grd_Client_cost.Rows.Clear();
            }
            lbl_Total_Orders.Text = dtselect.Rows.Count.ToString();
            lblRecordsStatus.Text = (currentpageindex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pagesize);
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
            if (txt_search.Text!="")
            {
                Binnd_Filter_Data();
            }
            else
            {
                Bind_Clint_Order_CostDetails();
            }
            this.Cursor = currentCursor;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
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
            if (txt_search.Text!="")
            {

                Binnd_Filter_Data();

            }
            else
            {
                Bind_Clint_Order_CostDetails();
            }
            this.Cursor = currentCursor;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentpageindex++;
            if (txt_search.Text!="")
            {
                if (currentpageindex == (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pagesize) - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;

                }
                Binnd_Filter_Data();

            }
            else
            {
                if (currentpageindex == (int)Math.Ceiling(Convert.ToDecimal(dtorder_info.Rows.Count) / pagesize) - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;

                }

                Bind_Clint_Order_CostDetails();
            }



            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;

            this.Cursor = currentCursor;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (txt_search.Text!="")
            {
                currentpageindex = (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pagesize) - 1;
                Binnd_Filter_Data();
            }
            else
            {
                currentpageindex = (int)Math.Ceiling(Convert.ToDecimal(dtorder_info.Rows.Count) / pagesize) - 1;
                Bind_Clint_Order_CostDetails();
            }
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            btnLast.Enabled = false;

            this.Cursor = currentCursor;
        }

        private void txt_Order_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                string title = "Validation!";
                MessageBox.Show("Alphabets Not Allowed",title);
            }
        }
    }
    
   


}
