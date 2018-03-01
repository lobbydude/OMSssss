using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Data.OleDb;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace Ordermanagement_01
{
    public partial class County_Link : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        System.Data.DataTable tmptable = new System.Data.DataTable();
        System.Data.DataTable dtselect = new System.Data.DataTable();
        System.Data.DataTable dtsort = new System.Data.DataTable();
        System.Data.DataTable dtcounty = new System.Data.DataTable();
        InfiniteProgressBar.clsProgress probar = new InfiniteProgressBar.clsProgress();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        int User_Id, CountyLinkId, count, count_non;
       // static int currentPageIndex = 0;
        private int currentPageIndex = 1;

        private int pageSize = 10;
        string username;
        public County_Link(int userid, string Username)
        {
            InitializeComponent();
            User_Id = userid;
            username = Username;
        }
        private void First_Page()
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentPageIndex = 0;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            btnFirst.Enabled = false;
            this.Cursor = currentCursor;
        }

        private void County_Link_Load(object sender, EventArgs e)
        {
            dbc.BindState(ddl_State_Wise);
            dbc.BindState(ddl_State);
            Grdiview_Bind_Tax_County_Link();
            
            btn_Import.Visible = true;
            grp_CountyReg.Visible = false;
            grp_CountyInfo.Visible = true;
            First_Page();
            dbc.BindCounty(cbo_County, int.Parse(ddl_State_Wise.SelectedValue.ToString()));
            //dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
           
           //lbl_Record_Addedby.Text = username;
           //lbl_Record_AddedDate.Text = DateTime.Now.ToString();
            
           // btn_Import.
        }

        private void GetNewRow(ref DataRow newRow, DataRow source)
        {
            foreach (DataColumn col in dtselect.Columns)
            {
                newRow[col.ColumnName] = source[col.ColumnName];
            }
        }

        protected void Grdiview_Bind_Tax_County_Link()
        {
            form_loader.Start_progres();
            //probar.startProgress();
            grd_CountyImport.Rows.Clear();
            Hashtable htselect = new Hashtable();
            
            //System.Data.DataTable dtselect=
            if (ddl_State_Wise.SelectedIndex > 0)
            {
                htselect.Add("@Trans", "SELECT_BY_STATE_WISE");
                htselect.Add("@State", ddl_State_Wise.SelectedValue.ToString());
                if (cbo_County.SelectedIndex > 0)
                {
                    htselect.Clear();
                    htselect.Add("@Trans", "SELECT_BY_STATE_COUNTY");
                    htselect.Add("@State", int.Parse(ddl_State_Wise.SelectedValue.ToString()));
                    htselect.Add("@County", int.Parse(cbo_County.SelectedValue.ToString()));
                }

            }
            else
            {

                htselect.Add("@Trans", "SELECT_ALL");
            }

            dtselect = dataaccess.ExecuteSP("Sp_County_Link", htselect);

            if (dtselect.Rows.Count > 0)
            {
                System.Data.DataTable tmptable = dtselect.Clone();
                int startIndex = currentPageIndex * pageSize;
                int endIndex = currentPageIndex * pageSize + pageSize;
                if (endIndex > dtselect.Rows.Count)
                {
                    endIndex = dtselect.Rows.Count;
                }
                for (int i = startIndex; i < endIndex; i++)
                {
                    DataRow newrow = tmptable.NewRow();
                    GetNewRow(ref newrow, dtselect.Rows[i]);
                    tmptable.Rows.Add(newrow);
                }

                //Page index format

                if (tmptable.Rows.Count > 0)
                {
                    grd_CountyImport.Rows.Clear();
                    for (int i = 0; i < tmptable.Rows.Count; i++)
                    {
                        // Grd_County_Link.DataSource = dtselect;
                        grd_CountyImport.Rows.Add();
                        grd_CountyImport.Rows[i].Cells[0].Value = i + 1;
                        grd_CountyImport.Rows[i].Cells[1].Value = tmptable.Rows[i]["State"].ToString();
                        grd_CountyImport.Rows[i].Cells[2].Value = tmptable.Rows[i]["County"].ToString();
                        grd_CountyImport.Rows[i].Cells[3].Value = tmptable.Rows[i]["Index_Availability"].ToString();
                        grd_CountyImport.Rows[i].Cells[4].Value = tmptable.Rows[i]["Index_date_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[5].Value = tmptable.Rows[i]["Back_deed_search"].ToString();
                        grd_CountyImport.Rows[i].Cells[6].Value = tmptable.Rows[i]["Back_deed_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[7].Value = tmptable.Rows[i]["Images"].ToString();
                        grd_CountyImport.Rows[i].Cells[8].Value = tmptable.Rows[i]["Images_date_of_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[9].Value = tmptable.Rows[i]["Land_Records_Link"].ToString();
                        grd_CountyImport.Rows[i].Cells[10].Value = tmptable.Rows[i]["Subscription_Link"].ToString();
                        grd_CountyImport.Rows[i].Cells[11].Value = tmptable.Rows[i]["Plant_availability"].ToString();
                        grd_CountyImport.Rows[i].Cells[14].Value = tmptable.Rows[i]["County_Link_Id"].ToString();
                    }

                }
                else
                {
                    grd_CountyImport.Rows.Clear();
                    grd_CountyImport.Visible = true;
                    grd_CountyImport.DataSource = null;
                }
                lbl_count.Text = dtselect.Rows.Count.ToString();
                lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pageSize);

                // probar.stopProgress();
            }
        }

        private void Grd_Tax_County_Link_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 || e.ColumnIndex == 8)
            {
                string url = grd_CountyImport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (url != "" && url != "N/A")
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
                //Update
            else if (e.ColumnIndex == 11)
            {

            }
                //Delete
            else if (e.ColumnIndex == 12)
            {
                if (grd_CountyImport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Hashtable htdelete = new Hashtable();
                    DataTable dtdelete = new DataTable();
                    htdelete.Add("@Trans", "DELETE");
                    htdelete.Add("@County_Link_Id", grd_CountyImport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    dtdelete = dataaccess.ExecuteSP("Sp_County_Link", htdelete);
                    Grdiview_Bind_Tax_County_Link();
                }
            }
        }

        private void lbl_customer_No_TextChanged(object sender, EventArgs e)
        {

        }

        private void CountyClear()
        {
            ddl_State.SelectedIndex = 0;
            ddl_County.SelectedIndex = -1;
            txt_Index_Availability.Text = ""; 
            txt_Index_date_range.Text = ""; 
            txt_Back_deed_search.Text = "";
            txt_Back_deed_range.Text="";  
            txt_Images.Text="";  
            txt_Images_date_of_range.Text="";  
            txt_Land_Records_Link.Text="";  
            txt_Subscription_Link.Text="";  
            txt_Plant_availability.Text="";  
            //lbl_Record_Addedby.Text="";
            //lbl_Record_AddedDate.Text = "";

            CountyLinkId = 0;
        }

        private void btn_Add_New_Click(object sender, EventArgs e)
        {
            if (btn_Add_New.Text == "Add New")
            {
                btn_Import.Visible = false;
                grp_CountyInfo.Visible = false;
                grp_CountyReg.Visible = true;
                CountyClear();
                btn_Add_New.Text = "Back";
                btn_Add_New_Tax.Text = "Submit";
                dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
                     lbl_Record_Addedby.Text = username;
           lbl_Record_AddedDate.Text = DateTime.Now.ToString();
            }
            else
            {
                grp_CountyInfo.Visible = true;
                grp_CountyReg.Visible = false;
                CountyClear();
                btn_Add_New.Text = "Add New";
                btn_Import.Visible = true;
            }
           
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            form_loader.Start_progres();
            //probar.startProgress();
            count = 0; count_non = 0;
            int count_grd = grd_CountyImport.Rows.Count;
            int count_ex;
            for (int i = 0; i < grd_CountyImport.Rows.Count; i++)
            {
                int Stateid;
                int Countyid;
                Hashtable htbarowerstate = new Hashtable();
                DataTable dtbarrowerstate = new System.Data.DataTable();
                htbarowerstate.Add("@Trans", "GETSTATE_BY_ABR");
                htbarowerstate.Add("@state_name", grd_CountyImport.Rows[i].Cells[1].Value.ToString());
                dtbarrowerstate = dataaccess.ExecuteSP("Sp_Order_Get_Details", htbarowerstate);
                if (dtbarrowerstate.Rows.Count > 0)
                {

                    Stateid = int.Parse(dtbarrowerstate.Rows[0]["State_ID"].ToString());
                }
                else
                {
                    Stateid = 0;
                }


                //get County
                Hashtable htBarcounty = new Hashtable();
                DataTable dtbarcounty = new System.Data.DataTable();
                htBarcounty.Add("@Trans", "GETCOUNTY");
                htBarcounty.Add("@State", Stateid);
                htBarcounty.Add("@County_Name", grd_CountyImport.Rows[i].Cells[2].Value.ToString());
                dtbarcounty = dataaccess.ExecuteSP("Sp_Order_Get_Details", htBarcounty);
                if (dtbarcounty.Rows.Count > 0)
                {
                    Countyid = int.Parse(dtbarcounty.Rows[0]["County_ID"].ToString());
                }
                else
                {
                    Countyid = 0;
                }

                if (Stateid != 0 && Countyid != 0)
                {
                    //Record already exists
                    Hashtable ht = new Hashtable();
                    DataTable dt = new System.Data.DataTable();
                    ht.Add("@Trans", "SELECT_BY_STATE_COUNTY");
                    ht.Add("@State", Stateid);
                    ht.Add("@County", Countyid);
                    dt = dataaccess.ExecuteSP("Sp_County_Link", ht);
                    if (dt.Rows.Count == 0)
                    {

                        Hashtable ht_INSERT = new Hashtable();
                        DataTable dt_INSERT = new System.Data.DataTable();
                        ht_INSERT.Add("@Trans", "INSERT");
                        ht_INSERT.Add("@State", Stateid);
                        ht_INSERT.Add("@County", Countyid);
                        ht_INSERT.Add("@Index_Availability", grd_CountyImport.Rows[i].Cells[3].Value.ToString());
                        ht_INSERT.Add("@Index_date_range", grd_CountyImport.Rows[i].Cells[4].Value.ToString());
                        ht_INSERT.Add("@Back_deed_search", grd_CountyImport.Rows[i].Cells[5].Value.ToString());
                        ht_INSERT.Add("@Back_deed_range", grd_CountyImport.Rows[i].Cells[6].Value.ToString());
                        ht_INSERT.Add("@Images", grd_CountyImport.Rows[i].Cells[7].Value.ToString());
                        ht_INSERT.Add("@Images_date_of_range", grd_CountyImport.Rows[i].Cells[8].Value.ToString());
                        ht_INSERT.Add("@Land_Records_Link", grd_CountyImport.Rows[i].Cells[9].Value.ToString());
                        ht_INSERT.Add("@Subscription_Link", grd_CountyImport.Rows[i].Cells[10].Value.ToString());
                        ht_INSERT.Add("@Plant_availability", grd_CountyImport.Rows[i].Cells[11].Value.ToString());
                        ht_INSERT.Add("@Inserted_By", User_Id);
                        ht_INSERT.Add("@Instered_Date", DateTime.Now);
                        ht_INSERT.Add("@Status", "True");
                        dt_INSERT = dataaccess.ExecuteSP("Sp_County_Link", ht_INSERT);
                        count = count + 1;
                    }

                }
                else
                {
                    count_non = count_non + 1;
                }
            }
            
           // probar.stopProgress();
            if (count > 0)
            {
                string title = "Successfull";
                MessageBox.Show(count + " No of County Link Records Imported successfully",title);
            }
            else
            {
                count_ex = count_grd - count_non;

                string title = "Existed!";
                MessageBox.Show(count_ex + " No of County Link Records Already Exists",title);
                //MessageBox.Show(count_non + " No of County Link Records Incorrect format");
            }
            
            Grdiview_Bind_Tax_County_Link();
            btn_Import.Visible = false;
            County_View.Visible = true;
            County_Delete.Visible = true;
        }


        private void Import(string txtFileName)
        {
            form_loader.Start_progres();
            //probar.startProgress();
            if (txtFileName != string.Empty)
            {

                String name = "Sheet1";    // default Sheet1 
                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                           txtFileName +
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                con.Open();

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                System.Data.DataTable data = new System.Data.DataTable();

                sda.Fill(data);
                ////  grd_order.DataSource = data;
                //Hashtable httruncate = new Hashtable();
                //DataTable dttruncate = new System.Data.DataTable();
                //httruncate.Add("@Trans", "TRUNCATE");
                //dttruncate = dataaccess.ExecuteSP("Sp_Temp_Order", httruncate);
                grd_CountyImport.Rows.Clear();
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {

                        grd_CountyImport.Rows.Add();
                        grd_CountyImport.Rows[i].Cells[0].Value = i + 1;
                        grd_CountyImport.Rows[i].Cells[1].Value = data.Rows[i]["State"].ToString();
                        grd_CountyImport.Rows[i].Cells[2].Value = data.Rows[i]["County"].ToString();

                        grd_CountyImport.Rows[i].Cells[3].Value = data.Rows[i]["Index_Availability"].ToString();
                        grd_CountyImport.Rows[i].Cells[4].Value = data.Rows[i]["Index_date_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[5].Value = data.Rows[i]["Back_deed_search"].ToString();
                        grd_CountyImport.Rows[i].Cells[6].Value = data.Rows[i]["Back_deed_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[7].Value = data.Rows[i]["Images"].ToString();
                        grd_CountyImport.Rows[i].Cells[8].Value = data.Rows[i]["Images_date_of_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[9].Value = data.Rows[i]["Land_Records_Link"].ToString();
                        grd_CountyImport.Rows[i].Cells[10].Value = data.Rows[i]["Subscription_Link"].ToString();
                        grd_CountyImport.Rows[i].Cells[11].Value = data.Rows[i]["Plant_availability"].ToString();

                    }
                    
                    btn_Import.Visible = true; 
                    County_View.Visible = false;
                    County_Delete.Visible = false;
                }
                else
                {
                    string title = "Empty!";

                    MessageBox.Show("Check the Excel is empty", title);
                }
                
            }
            //probar.stopProgress();
        }

        private void GetDataRow_State(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dtsort.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }

        private void Filter_State_Data()
        {
            System.Data.DataTable temptable = dtsort.Clone();
            int startindex = currentPageIndex * pageSize;
            int endindex = currentPageIndex * pageSize + pageSize;
            if (endindex > dtsort.Rows.Count)
            {
                endindex = dtsort.Rows.Count;
            }
            for (int i = startindex; i < endindex; i++)
            {
                DataRow newrow = temptable.NewRow();
                GetDataRow_State(ref newrow, dtsort.Rows[i]);
                temptable.Rows.Add(newrow);
            }

            if (temptable.Rows.Count > 0)
            {
                grd_CountyImport.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    grd_CountyImport.Rows.Add();
                    grd_CountyImport.Rows[i].Cells[0].Value = i + 1;
                    grd_CountyImport.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                    grd_CountyImport.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                    grd_CountyImport.Rows[i].Cells[3].Value = temptable.Rows[i]["Index_Availability"].ToString();
                    grd_CountyImport.Rows[i].Cells[4].Value = temptable.Rows[i]["Index_date_range"].ToString();
                    grd_CountyImport.Rows[i].Cells[5].Value = temptable.Rows[i]["Back_deed_search"].ToString();
                    grd_CountyImport.Rows[i].Cells[6].Value = temptable.Rows[i]["Back_deed_range"].ToString();
                    grd_CountyImport.Rows[i].Cells[7].Value = temptable.Rows[i]["Images"].ToString();
                    grd_CountyImport.Rows[i].Cells[8].Value = temptable.Rows[i]["Images_date_of_range"].ToString();
                    grd_CountyImport.Rows[i].Cells[9].Value = temptable.Rows[i]["Land_Records_Link"].ToString();
                    grd_CountyImport.Rows[i].Cells[10].Value = temptable.Rows[i]["Subscription_Link"].ToString();
                    grd_CountyImport.Rows[i].Cells[11].Value = temptable.Rows[i]["Plant_availability"].ToString();
                    grd_CountyImport.Rows[i].Cells[14].Value = temptable.Rows[i]["County_Link_Id"].ToString();

                }
            }
            else
            {
                grd_CountyImport.Rows.Clear();
                grd_CountyImport.Visible = true;
                grd_CountyImport.DataSource = null;
            }

            lbl_count.Text = dtsort.Rows.Count.ToString();
            lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pageSize);
        }

        private void ddl_State_Wise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_State_Wise.SelectedIndex > 0)
            {
                dbc.BindCounty(cbo_County, int.Parse(ddl_State_Wise.SelectedValue.ToString()));
                grd_CountyImport.Rows.Clear();

                form_loader.Start_progres();
                //probar.startProgress();
                Hashtable htsort = new Hashtable();
                
                htsort.Add("@Trans", "SELECT_BY_STATE_WISE");
                htsort.Add("@State", int.Parse(ddl_State_Wise.SelectedValue.ToString()));
                dtsort = dataaccess.ExecuteSP("Sp_County_Link", htsort);


                System.Data.DataTable temptable = dtsort.Clone();
                int startindex = currentPageIndex * pageSize;
                int endindex = currentPageIndex * pageSize + pageSize;
                if (endindex > dtsort.Rows.Count)
                {
                    endindex = dtsort.Rows.Count;
                }
                for (int i = startindex; i < endindex; i++)
                {
                    DataRow newrow = temptable.NewRow();
                    GetDataRow_State(ref newrow,dtsort.Rows[i]);
                    temptable.Rows.Add(newrow);
                }

                if (temptable.Rows.Count > 0)
                {
                    grd_CountyImport.Rows.Clear();
                    for (int i = 0; i < temptable.Rows.Count; i++)
                    {
                        grd_CountyImport.Rows.Add();
                        grd_CountyImport.Rows[i].Cells[0].Value = i + 1;
                        grd_CountyImport.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                        grd_CountyImport.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                        grd_CountyImport.Rows[i].Cells[3].Value = temptable.Rows[i]["Index_Availability"].ToString();
                        grd_CountyImport.Rows[i].Cells[4].Value = temptable.Rows[i]["Index_date_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[5].Value = temptable.Rows[i]["Back_deed_search"].ToString();
                        grd_CountyImport.Rows[i].Cells[6].Value = temptable.Rows[i]["Back_deed_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[7].Value = temptable.Rows[i]["Images"].ToString();
                        grd_CountyImport.Rows[i].Cells[8].Value = temptable.Rows[i]["Images_date_of_range"].ToString();
                        grd_CountyImport.Rows[i].Cells[9].Value = temptable.Rows[i]["Land_Records_Link"].ToString();
                        grd_CountyImport.Rows[i].Cells[10].Value = temptable.Rows[i]["Subscription_Link"].ToString();
                        grd_CountyImport.Rows[i].Cells[11].Value = temptable.Rows[i]["Plant_availability"].ToString();
                        grd_CountyImport.Rows[i].Cells[14].Value = temptable.Rows[i]["County_Link_Id"].ToString();

                    }
                    lbl_count.Text = dtsort.Rows.Count.ToString();
                    lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pageSize);
                    if (lblRecordsStatus.Text == "1 / 1")
                    {
                        btnNext.Enabled = false;
                        btnLast.Enabled = false;
                        btnFirst.Enabled = true;
                    }
                    else
                    {
                        First_Page();
                    }  
              
                }
                else
                {
                    grd_CountyImport.Rows.Clear();
                    grd_CountyImport.Visible = true;
                    grd_CountyImport.DataSource = null;

                   
                }

                //lbl_count.Text = dtsort.Rows.Count.ToString();
                //lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pageSize);
                
              
             //   First_Page();
              
            }
            
        }

        private void GetDataRow_County(ref DataRow dest, DataRow source)
        {
            foreach(DataColumn col in dtcounty.Columns)
            {
                dest[col.ColumnName]=source[col.ColumnName];
            }
        }

        private void Filter_County_Data()
        {
            System.Data.DataTable temptable = dtsort.Clone();
            int startindex = currentPageIndex * pageSize;
            int endindex = currentPageIndex * pageSize + pageSize;
            if (endindex > dtcounty.Rows.Count)
            {
                endindex = dtcounty.Rows.Count;
            }
            for (int i = startindex; i < endindex; i++)
            {
                DataRow newrow = temptable.NewRow();
                GetDataRow_County(ref newrow, dtcounty.Rows[i]);
                temptable.Rows.Add(newrow);
            }

            if (temptable.Rows.Count > 0)
            {
                grd_CountyImport.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    grd_CountyImport.Rows.Add();
                    grd_CountyImport.Rows[i].Cells[0].Value = i + 1;
                    grd_CountyImport.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                    grd_CountyImport.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                    grd_CountyImport.Rows[i].Cells[3].Value = temptable.Rows[i]["Index_Availability"].ToString();
                    grd_CountyImport.Rows[i].Cells[4].Value = temptable.Rows[i]["Index_date_range"].ToString();
                    grd_CountyImport.Rows[i].Cells[5].Value = temptable.Rows[i]["Back_deed_search"].ToString();
                    grd_CountyImport.Rows[i].Cells[6].Value = temptable.Rows[i]["Back_deed_range"].ToString();
                    grd_CountyImport.Rows[i].Cells[7].Value = temptable.Rows[i]["Images"].ToString();
                    grd_CountyImport.Rows[i].Cells[8].Value = temptable.Rows[i]["Images_date_of_range"].ToString();
                    grd_CountyImport.Rows[i].Cells[9].Value = temptable.Rows[i]["Land_Records_Link"].ToString();
                    grd_CountyImport.Rows[i].Cells[10].Value = temptable.Rows[i]["Subscription_Link"].ToString();
                    grd_CountyImport.Rows[i].Cells[11].Value = temptable.Rows[i]["Plant_availability"].ToString();
                    grd_CountyImport.Rows[i].Cells[14].Value = temptable.Rows[i]["County_Link_Id"].ToString();

                }
            }
            else
            {
                grd_CountyImport.Rows.Clear();
                grd_CountyImport.Visible = true;
                grd_CountyImport.DataSource = null;
            }

            lbl_count.Text =  dtcounty.Rows.Count.ToString();
            lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pageSize);
        }

        private void cbo_County_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_State_Wise.SelectedIndex > 0)
            {
                if (cbo_County.SelectedIndex > 0)
                {
                    grd_CountyImport.Rows.Clear();

                    form_loader.Start_progres();
                    //probar.startProgress();
                    Hashtable ht = new Hashtable();
                    DataTable dt = new DataTable();
                    ht.Add("@Trans", "SELECT_BY_STATE_COUNTY");
                    ht.Add("@State", int.Parse(ddl_State_Wise.SelectedValue.ToString()));
                    ht.Add("@County", int.Parse(cbo_County.SelectedValue.ToString()));
                    dtcounty = dataaccess.ExecuteSP("Sp_County_Link", ht);

                    System.Data.DataTable temptable = dtsort.Clone();
                    int startindex = currentPageIndex * pageSize;
                    int endindex = currentPageIndex * pageSize + pageSize;
                    if (endindex > dtcounty.Rows.Count)
                    {
                        endindex = dtcounty.Rows.Count;
                    }
                    for (int i = startindex; i < endindex; i++)
                    {
                        DataRow newrow = temptable.NewRow();
                        GetDataRow_County(ref newrow, dtcounty.Rows[i]);
                        temptable.Rows.Add(newrow);
                    }

                    if (temptable.Rows.Count > 0)
                    {
                        grd_CountyImport.Rows.Clear();
                        for (int i = 0; i < temptable.Rows.Count; i++)
                        {
                            grd_CountyImport.Rows.Add();
                            grd_CountyImport.Rows[i].Cells[0].Value = i + 1;
                            grd_CountyImport.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                            grd_CountyImport.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                            grd_CountyImport.Rows[i].Cells[3].Value = temptable.Rows[i]["Index_Availability"].ToString();
                            grd_CountyImport.Rows[i].Cells[4].Value = temptable.Rows[i]["Index_date_range"].ToString();
                            grd_CountyImport.Rows[i].Cells[5].Value = temptable.Rows[i]["Back_deed_search"].ToString();
                            grd_CountyImport.Rows[i].Cells[6].Value = temptable.Rows[i]["Back_deed_range"].ToString();
                            grd_CountyImport.Rows[i].Cells[7].Value = temptable.Rows[i]["Images"].ToString();
                            grd_CountyImport.Rows[i].Cells[8].Value = temptable.Rows[i]["Images_date_of_range"].ToString();
                            grd_CountyImport.Rows[i].Cells[9].Value = temptable.Rows[i]["Land_Records_Link"].ToString();
                            grd_CountyImport.Rows[i].Cells[10].Value = temptable.Rows[i]["Subscription_Link"].ToString();
                            grd_CountyImport.Rows[i].Cells[11].Value = temptable.Rows[i]["Plant_availability"].ToString();
                            grd_CountyImport.Rows[i].Cells[14].Value = temptable.Rows[i]["County_Link_Id"].ToString();

                        }
                        lbl_count.Text = dtcounty.Rows.Count.ToString();
                        lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pageSize);
                        if (lblRecordsStatus.Text == "1 / 1")
                        {
                            btnNext.Enabled = false;
                            btnLast.Enabled = false;
                            btnFirst.Enabled = true;
                        }
                        else
                        {
                            First_Page();
                        }  
                    }
                      
                    else
                    {
                        grd_CountyImport.Rows.Clear();
                        grd_CountyImport.Visible = true;
                       
                   
                        grd_CountyImport.DataSource = null;
                        MessageBox.Show("No Records Found");
                      
                        //btn_Refresh_Click(sender,e);
                        //lbl_count.Text = dtselect.Rows.Count.ToString();
                        //lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pageSize);

                    }

                    //lbl_count.Text = dtcounty.Rows.Count.ToString();
                    //lblRecordsStatus.Text = (currentPageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pageSize);

                    //if (lblRecordsStatus.Text == "1 / 1")
                    //{
                    //    btnNext.Enabled = false;
                    //    btnLast.Enabled = false;
                    //    btnFirst.Enabled = true;
                    //}
                    //else
                    //{
                    //    First_Page();
                    //}  
                
                }
            }
           
        }

        private void Btn_Upload_Click(object sender, EventArgs e)
        {
            grp_CountyInfo.Visible = true;
            grp_CountyReg.Visible = false;

            County_View.Visible = false;
            County_Delete.Visible = false;

            grd_CountyImport.Rows.Clear();

            OpenFileDialog fdlg = new OpenFileDialog();

            fdlg.Title = "Select file";
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

        private void btn_Add_New_Tax_Click(object sender, EventArgs e)
        {
            if (Validation() != false && CountyLinkId == 0)
            {
                //Insertion Code
                Hashtable htinsert = new Hashtable();
                DataTable dtinsert = new DataTable();
                htinsert.Add("@Trans", "INSERT");
                htinsert.Add("@State", int.Parse(ddl_State.SelectedValue.ToString()));
                htinsert.Add("@County", int.Parse(ddl_County.SelectedValue.ToString()));
                htinsert.Add("@Index_Availability", txt_Index_Availability.Text);
                htinsert.Add("@Index_date_range", txt_Index_date_range.Text);
                htinsert.Add("@Back_deed_search", txt_Back_deed_search.Text);
                htinsert.Add("@Back_deed_range", txt_Back_deed_range.Text);
                htinsert.Add("@Images", txt_Images.Text);
                htinsert.Add("@Images_date_of_range", txt_Images_date_of_range.Text);
                htinsert.Add("@Land_Records_Link", txt_Land_Records_Link.Text);
                htinsert.Add("@Subscription_Link", txt_Subscription_Link.Text);
                htinsert.Add("@Plant_availability", txt_Plant_availability.Text);
                htinsert.Add("@Inserted_By", User_Id);
                htinsert.Add("@Instered_Date", DateTime.Now);
                htinsert.Add("@Status", "True");
                dtinsert = dataaccess.ExecuteSP("Sp_County_Link", htinsert);
                string title = "Insert";
                MessageBox.Show("County Link Inserted Successfully",title);
                grp_CountyReg.Visible = false;
                grp_CountyInfo.Visible = true;
                btn_Add_New.Text = "Back";
            }
            else if (CountyLinkId != 0)
            {
                //Updation Code
                grd_CountyImport.Rows.Clear();
                int Stateid;
                int Countyid;
                Hashtable htbarowerstate = new Hashtable();
                DataTable dtbarrowerstate = new System.Data.DataTable();
                htbarowerstate.Add("@Trans", "GETSTATE");
                htbarowerstate.Add("@state_name", ddl_State.Text);
                dtbarrowerstate = dataaccess.ExecuteSP("Sp_Order_Get_Details", htbarowerstate);
                if (dtbarrowerstate.Rows.Count > 0)
                {

                    Stateid = int.Parse(dtbarrowerstate.Rows[0]["State_ID"].ToString());
                }
                else
                {
                    Stateid = 0;
                }


                //get County
                Hashtable htBarcounty = new Hashtable();
                DataTable dtbarcounty = new System.Data.DataTable();
                htBarcounty.Add("@Trans", "GETCOUNTY");
                htBarcounty.Add("@State", Stateid);
                htBarcounty.Add("@County_Name", ddl_County.Text);
                dtbarcounty = dataaccess.ExecuteSP("Sp_Order_Get_Details", htBarcounty);
                if (dtbarcounty.Rows.Count > 0)
                {
                    Countyid = int.Parse(dtbarcounty.Rows[0]["County_ID"].ToString());
                }
                else
                {
                    Countyid = 0;
                }


                Hashtable htupdate = new Hashtable();
                DataTable dtupdate = new DataTable();
                htupdate.Add("@Trans", "UPDATE");
                htupdate.Add("@County_Link_Id", CountyLinkId);
                htupdate.Add("@State", Stateid);
                htupdate.Add("@County", Countyid);

                htupdate.Add("@Index_Availability", txt_Index_Availability.Text);
                htupdate.Add("@Index_date_range", txt_Index_date_range.Text);
                htupdate.Add("@Back_deed_search", txt_Back_deed_search.Text);
                htupdate.Add("@Back_deed_range", txt_Back_deed_range.Text);
                htupdate.Add("@Images", txt_Images.Text);
                htupdate.Add("@Images_date_of_range", txt_Images_date_of_range.Text);
                htupdate.Add("@Land_Records_Link", txt_Land_Records_Link.Text);
                htupdate.Add("@Subscription_Link", txt_Subscription_Link.Text);
                htupdate.Add("@Plant_availability", txt_Plant_availability.Text);
                htupdate.Add("@Inserted_By", User_Id);
                htupdate.Add("@Instered_Date", DateTime.Now);
                dtupdate = dataaccess.ExecuteSP("Sp_County_Link", htupdate);


                string title = "Update";
                MessageBox.Show("County Link Updated Successfully", title);
                grp_CountyReg.Visible = false;
                grp_CountyInfo.Visible = true;
                btn_Add_New.Text = "Add New";
                Grdiview_Bind_Tax_County_Link();
            }
        }

        private bool Validation()
        {
            string title = "Validation!";
            if (ddl_State.Text == "Select")
            {
                MessageBox.Show("Select State Name", title);
                ddl_State.Focus();
                return false;
            }
            else if (ddl_County.Text == "Select" || ddl_County.Text == "")
            {
                MessageBox.Show("Select County Name", title);
                ddl_County.Focus();
                return false;
            }
            else if (txt_Index_Availability.Text == "")
            {
                MessageBox.Show("Enter Index availability of county link", title);
                txt_Index_Availability.Focus();
                return false;
            }
            else if (txt_Land_Records_Link.Text=="")
            {
                MessageBox.Show("Please Enter Land Records link", title);
                txt_Index_Availability.Focus();
                return false;
            }
            return true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            CountyClear();
            dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
        }

        private void grd_CountyImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex != -1)
            {
            //if (e.ColumnIndex != -1)
            //{
                
                //View code
                if (e.ColumnIndex == 12)
                {
                    grp_CountyInfo.Visible = false;
                    grp_CountyReg.Visible = true;
                    CountyLinkId = int.Parse(grd_CountyImport.Rows[e.RowIndex].Cells[14].Value.ToString());
                    Hashtable htselect = new Hashtable();
                    DataTable dtselect = new DataTable();
                    htselect.Add("@Trans", "SELECT");
                    htselect.Add("@County_Link_Id", CountyLinkId);
                    dtselect = dataaccess.ExecuteSP("Sp_County_Link", htselect);
                    if (dtselect.Rows.Count > 0)
                    {
                        ddl_State.Text = dtselect.Rows[0]["State"].ToString();
                        ddl_County.Text = dtselect.Rows[0]["County"].ToString();
                        txt_Index_Availability.Text = dtselect.Rows[0]["Index_Availability"].ToString();
                        txt_Index_date_range.Text = dtselect.Rows[0]["Index_date_range"].ToString();
                        txt_Back_deed_search.Text = dtselect.Rows[0]["Back_deed_search"].ToString();
                        txt_Back_deed_range.Text = dtselect.Rows[0]["Back_deed_range"].ToString();
                        txt_Images.Text = dtselect.Rows[0]["Images"].ToString();
                        txt_Images_date_of_range.Text = dtselect.Rows[0]["Images_date_of_range"].ToString();
                        txt_Land_Records_Link.Text = dtselect.Rows[0]["Land_Records_Link"].ToString();
                        txt_Subscription_Link.Text = dtselect.Rows[0]["Subscription_Link"].ToString();
                        txt_Plant_availability.Text = dtselect.Rows[0]["Plant_availability"].ToString();  

                        lbl_Record_Addedby.Text = dtselect.Rows[0]["User_Name"].ToString();
                        lbl_Record_AddedDate.Text = dtselect.Rows[0]["Instered_Date"].ToString();
                        btn_Add_New_Tax.Text = "Edit";
                        btn_Add_New.Text = "Back";
                    }
                    Grdiview_Bind_Tax_County_Link();
                }
                //Delete code
                else if (e.ColumnIndex == 13)
                {
                    DialogResult dialog = MessageBox.Show("Do you want to Delete Record", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        CountyLinkId = int.Parse(grd_CountyImport.Rows[e.RowIndex].Cells[14].Value.ToString());
                        Hashtable htdelete = new Hashtable();
                        DataTable dtdelete = new DataTable();
                        htdelete.Add("@Trans", "DELETE");
                        htdelete.Add("@County_Link_Id", CountyLinkId);
                        dtdelete = dataaccess.ExecuteSP("Sp_County_Link", htdelete);
                      //  string title = "Delete!";
                        MessageBox.Show("Record Deleted Successfully");
                    }
                    //Grdiview_Bind_Tax_County_Link();
                }
            }
        }

        private void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_State.SelectedIndex > 0)
            {
                dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            grd_CountyImport.Rows.Clear();
            
            ddl_State_Wise.SelectedIndex = 0;
            cbo_County.SelectedIndex = -1;
            Grdiview_Bind_Tax_County_Link();
            dbc.BindCounty(cbo_County, int.Parse(ddl_State_Wise.SelectedValue.ToString()));
           
        }

        private void btn_GetImportExcel_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"c:\OMS_Import\");
            string temppath = @"c:\OMS_Import\County_Link_Import.xlsx";
            if (!Directory.Exists(temppath))
            {
                File.Copy(@"\\192.168.12.33\OMS-Import_Excels\County_Link_Import.xlsx", temppath, true);
                Process.Start(temppath);
            }
            else
            {
                Process.Start(temppath);
            }
            
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // splitContainer1.Enabled = false;
            currentPageIndex--;
            if (currentPageIndex == 0)
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
            if (ddl_State.SelectedIndex > 0 )
            {
                Filter_State_Data();
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                Filter_County_Data();
            }
            else
            {
                Grdiview_Bind_Tax_County_Link();
            }
            Grdiview_Bind_Tax_County_Link();
            this.Cursor = currentCursor;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentPageIndex = 0;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            btnFirst.Enabled = false;
            if (ddl_State.SelectedIndex > 0)
            {
                Filter_State_Data();
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                Filter_County_Data();
            }
            else
            {
                Grdiview_Bind_Tax_County_Link();
            }
            Grdiview_Bind_Tax_County_Link();
            this.Cursor = currentCursor;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentPageIndex++;
            if (ddl_State.SelectedIndex > 0 )
            {

                if (this.currentPageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pageSize) - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                Filter_State_Data();
                
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                if (currentPageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pageSize) - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                Filter_County_Data();
            }
            
            else
            {
               
                if (currentPageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pageSize) - 1)
                {
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                   // Grdiview_Bind_Tax_County_Link();
                }
                else
                {
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                   // Grdiview_Bind_Tax_County_Link();
                }
               
                Grdiview_Bind_Tax_County_Link();
            }
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;

           // Grdiview_Bind_Tax_County_Link();
            this.Cursor = currentCursor;
        }

       

        private void btnLast_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (ddl_State.SelectedIndex > 0 )
            {
                currentPageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pageSize) - 1;
                Filter_State_Data();
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                currentPageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pageSize) - 1;
                Filter_County_Data();
            }
            else
            {
                currentPageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pageSize) - 1;
                Grdiview_Bind_Tax_County_Link();
            }
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
          //  Grdiview_Bind_Tax_County_Link();
            this.Cursor = currentCursor;
        }

        private void grd_CountyImport_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = grd_CountyImport.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = grd_CountyImport.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted.
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder.
                if (oldColumn == newColumn &&
                    grd_CountyImport.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                  
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
               
            }

            // Sort the selected column.
            grd_CountyImport.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;


            //grd_CountyImport.datasource=
        }

        private void grd_CountyImport_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in grd_CountyImport.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void grd_CountyImport_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Try to sort based on the cells in the current column.
            e.SortResult = System.String.Compare(
                e.CellValue1.ToString(), e.CellValue2.ToString());

            // If the cells are equal, sort based on the ID column.
            if (e.SortResult == 0 && e.Column.Name != "County_Link_Id")
            {
                e.SortResult = System.String.Compare(
                    grd_CountyImport.Rows[e.RowIndex1].Cells["County_Link_Id"].Value.ToString(),
                    grd_CountyImport.Rows[e.RowIndex2].Cells["County_Link_Id"].Value.ToString());
            }
            e.Handled = true;
        }

       
    
      
      
     
     
     
    }
}
