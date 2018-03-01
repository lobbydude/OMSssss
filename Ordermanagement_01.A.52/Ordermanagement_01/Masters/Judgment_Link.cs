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
    public partial class Judgment_Link : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();

        System.Data.DataTable dtselect = new System.Data.DataTable();
        System.Data.DataTable dtsort = new System.Data.DataTable();
        System.Data.DataTable dtcounty = new System.Data.DataTable();
        InfiniteProgressBar.clsProgress progBar = new InfiniteProgressBar.clsProgress();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        int UserId, JudgmentID = 0, count = 0, count_non=0;
        static int CurrentpageIndex = 0;
        int Pagesize = 10;
        string username;
        string state;
        string county;
        string duplicate;

        public Judgment_Link(int User_Id,string UserName)
        {
            InitializeComponent();
            UserId = User_Id;
            username = UserName;
            dbc.BindState(ddl_State);
            dbc.BindState(cbo_State);
            dbc.BindCounty(ddl_County,int.Parse(ddl_State.SelectedValue.ToString()));
            dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
        }

        private void Btn_Upload_Click(object sender, EventArgs e)
        {
          
            grp_JudgmentInfo.Visible = true;
            grp_JugmentReg.Visible = false;

            Judgment_view.Visible = false;
            Judgment_delete.Visible = false;

            Grd_Judgment_Link.Rows.Clear();

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
        private void Import(string txtFileName)
        {
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
                    Grd_Judgment_Link.Rows.Clear();
                    if (data.Rows.Count > 0)
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {


                            Grd_Judgment_Link.Rows.Add();
                            Grd_Judgment_Link.Rows[i].Cells[0].Value = i + 1;
                            Grd_Judgment_Link.Rows[i].Cells[1].Value = data.Rows[i]["State"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[2].Value = data.Rows[i]["County"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[3].Value = data.Rows[i]["Research_Date"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[4].Value = data.Rows[i]["Judgment_Link"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[5].Value = data.Rows[i]["Lien_Link"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[6].Value = data.Rows[i]["Criminal"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[7].Value = data.Rows[i]["Subscription"].ToString();
                        }
                        btn_Import.Visible = true;
                        Judgment_view.Visible = false;
                        Judgment_delete.Visible = false;
                     
                    }
                    else
                    {
                        string title = "Empty!";
                        MessageBox.Show("Check the Excel is empty",title);
                    }
                
                }
            
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            form_loader.Start_progres();
            //progBar.startProgress();
            count = 0; count_non = 0;
            int count_grd=Grd_Judgment_Link.Rows.Count;
            int count_ex=0;
            for (int i = 0; i < Grd_Judgment_Link.Rows.Count; i++)
            {
                int Stateid;
                int Countyid;
                Hashtable htbarowerstate = new Hashtable();
                DataTable dtbarrowerstate = new System.Data.DataTable();
                htbarowerstate.Add("@Trans", "GETSTATE_BY_ABR");
                //htbarowerstate.Add("@state_name", Grd_Judgment_Link.Rows[i].Cells[1].Value.ToString());
                htbarowerstate.Add("@state_name", Grd_Judgment_Link.Rows[i].Cells[1].Value.ToString());
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
                htBarcounty.Add("@County_Name", Grd_Judgment_Link.Rows[i].Cells[2].Value.ToString());
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
                    ht.Add("@Trans", "SORT_COUNTY");
                    ht.Add("@State_Id", Stateid);
                    ht.Add("@County_Id", Countyid);
                    dt = dataaccess.ExecuteSP("Sp_Judgment_Link", ht);
                    if (dt.Rows.Count == 0)
                    {
                        Hashtable ht_INSERT = new Hashtable();
                        DataTable dt_INSERT = new System.Data.DataTable();
                        ht_INSERT.Add("@Trans", "INSERT");
                        ht_INSERT.Add("@State_Id", Stateid);
                        ht_INSERT.Add("@County_Id", Countyid);
                        ht_INSERT.Add("@Research_Date", Grd_Judgment_Link.Rows[i].Cells[3].Value.ToString());
                        ht_INSERT.Add("@Judgment_Link", Grd_Judgment_Link.Rows[i].Cells[4].Value.ToString());
                        ht_INSERT.Add("@Lien_Link", Grd_Judgment_Link.Rows[i].Cells[5].Value.ToString());
                        ht_INSERT.Add("@Criminal", Grd_Judgment_Link.Rows[i].Cells[6].Value.ToString());
                        ht_INSERT.Add("@Subscription", Grd_Judgment_Link.Rows[i].Cells[7].Value.ToString());
                        ht_INSERT.Add("@Inserted_By", UserId);
                        ht_INSERT.Add("@Status", "True");
                        dt_INSERT = dataaccess.ExecuteSP("Sp_Judgment_Link", ht_INSERT);
                        count = count + 1;
                    }
                }
                else
                {
                    count_non=count_non+1;
                }



            }
        
            if (count > 0)
            {
                string title = "Successfull";
                MessageBox.Show(count + " No of Judgment Link Records Imported successfully",title);
            }
            else
            {
                count_ex = count_grd - count_non;
                string title = "Duplicate Record!";
                MessageBox.Show(count_ex + " No of Judgment Link Records Already Exists",title);
              //  MessageBox.Show(count_non + "No of Judgment Link Incorrect Format");
            }
            BindJugmentGrid();
            btn_Import.Visible = false;
            Judgment_view.Visible = true;
            Judgment_delete.Visible = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (btn_Add.Text == "Add New")
            {
                btn_Import.Visible = false;
                grp_JudgmentInfo.Visible = false;
                grp_JugmentReg.Visible = true;
                JudgmentClear();
                btn_Add.Text = "Back";
                btn_AddJugment.Text = "Submit";
                dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
                Btn_Upload.Visible = false;
                btn_GetImportExcel.Visible = false;
                lbl_Record_Addedby.Text = username;
                lbl_Record_AddedDate.Text = DateTime.Now.ToString();
            }
            else
            {

               
                grp_JudgmentInfo.Visible = true;
                grp_JugmentReg.Visible = false;
                JudgmentClear();
                btn_Add.Text = "Add New";
                dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
                Btn_Upload.Visible = true;
                btn_GetImportExcel.Visible = true;
            }
            
        }
        private void JudgmentClear()
        {

            ddl_State.SelectedIndex = 0;
            ddl_County.SelectedIndex = -1;
            txt_ResearchDate.Text = "";
            txt_Criminallink.Text = "";
            txt_Judgmentlink.Text = "";
            txt_Lienlink.Text = "";
            txt_Subscriptionlink.Text = "";
            ////lbl_Record_Addedby.Text = "";
            ////lbl_Record_AddedDate.Text = "";
           

        }


        private void Judgment_Link_Load(object sender, EventArgs e)
        {

            btn_Import.Visible = true;
            grp_JugmentReg.Visible = false;
            grp_JudgmentInfo.Visible = true;    
            BindJugmentGrid();
            First_Page();
            dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
        }

        private void First_Page()
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            CurrentpageIndex = 0;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            btnFirst.Enabled = false;
            this.Cursor = currentCursor;
        }

        private void BindJugmentGrid()
        {
            form_loader.Start_progres();
            //progBar.startProgress();


            Grd_Judgment_Link.Rows.Clear();
            Hashtable htselect = new Hashtable();
            // System.Data.DataTable dtselect = new System.Data.DataTable();



            if (cbo_State.SelectedIndex > 0)
            {
                htselect.Add("@Trans", "SORT_STATE");
                htselect.Add("@State_Id", int.Parse(cbo_State.SelectedValue.ToString()));
                if (cbo_County.SelectedIndex > 0)
                {
                    htselect.Clear();
                    htselect.Add("@Trans", "SORT_COUNTY");

                    htselect.Add("@State_Id", int.Parse(cbo_State.SelectedValue.ToString()));
                    htselect.Add("@County_Id", int.Parse(cbo_County.SelectedValue.ToString()));
                }
            }
            else
            {

                htselect.Add("@Trans", "SELECTGRID");
            }

            Grd_Judgment_Link.Rows.Clear();
            dtselect = dataaccess.ExecuteSP("Sp_Judgment_Link", htselect);
            System.Data.DataTable temptable = dtselect.Clone();
            int startIndex = CurrentpageIndex * Pagesize;
            int endIndex = CurrentpageIndex * Pagesize + Pagesize;
            if (endIndex > dtselect.Rows.Count)
            {
                endIndex = dtselect.Rows.Count;
            }
            for (int i = startIndex; i < endIndex; i++)
            {
                DataRow Row = temptable.NewRow();
                Get_New_Row_Column(ref Row, dtselect.Rows[i]);
                temptable.Rows.Add(Row);
            }

            if (temptable.Rows.Count > 0)
            {
                Grd_Judgment_Link.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    Grd_Judgment_Link.Rows.Add();
                    Grd_Judgment_Link.Rows[i].Cells[0].Value = i + 1;
                    Grd_Judgment_Link.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString(); ;
                    Grd_Judgment_Link.Rows[i].Cells[3].Value = temptable.Rows[i]["Research_Date"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[4].Value = temptable.Rows[i]["Judgment_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[5].Value = temptable.Rows[i]["Lien_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[6].Value = temptable.Rows[i]["Criminal"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[7].Value = temptable.Rows[i]["Subscription"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[8].Value = temptable.Rows[i]["State_ID"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[9].Value = temptable.Rows[i]["County_ID"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[12].Value = temptable.Rows[i]["Judgment_Links_Id"].ToString();
                }
            }
            else
            {
                Grd_Judgment_Link.Rows.Clear();
                Grd_Judgment_Link.Visible = true;
                Grd_Judgment_Link.DataSource = null;
            }
            lbl_count.Text =" Total Records " + dtselect.Rows.Count.ToString();
            lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / Pagesize);

           // progBar.stopProgress();


        }

        private void Get_New_Row_Column(ref DataRow Row,DataRow Source)
        {
            foreach (DataColumn col in dtselect.Columns)
            {
                Row[col.ColumnName] = Source[col.ColumnName];
            }
        }

        private void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_State.SelectedIndex > 0)
            {
                dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            JudgmentClear();
            dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
        }

        private bool Duplicate_Record()
        {
            Hashtable ht_checkDuplicate = new Hashtable();
            DataTable dt_checkDuplicate = new DataTable();

            ht_checkDuplicate.Add("@Trans", "CHECK_DUPLICATE");
            ht_checkDuplicate.Add("@State", ddl_State.SelectedValue.ToString());
            ht_checkDuplicate.Add("@County", ddl_County.SelectedValue.ToString());
            dt_checkDuplicate = dataaccess.ExecuteSP("Sp_Judgment_Link", ht_checkDuplicate);

            for (int i = 0; i <= dt_checkDuplicate.Rows.Count - 1; i++)
            {
                state = dt_checkDuplicate.Rows[0]["State_ID"].ToString();
                county = dt_checkDuplicate.Rows[0]["County_ID"].ToString();

                string selected_state = ddl_State.SelectedValue.ToString();
                string selected_County = ddl_County.SelectedValue.ToString();

                if (state == selected_state && county == selected_County && btn_AddJugment.Text != "Edit")
                {
                    duplicate = "Duplicate Data";
                    string title = "Duplicate Record!";
                    MessageBox.Show("Record Already Existed",title);
                    JudgmentClear();
                    return false;
                }
            }

            return true;
        }

        private void btn_AddJugment_Click(object sender, EventArgs e)
        {
            if (Validation() != false )
            {
                if (Duplicate_Record() != false)
                {
                    if (JudgmentID == 0)
                    {
                        Hashtable htinsert = new Hashtable();
                        DataTable dtinsert = new DataTable();
                        htinsert.Add("@Trans", "INSERT");
                        htinsert.Add("@State_Id", int.Parse(ddl_State.SelectedValue.ToString()));
                        htinsert.Add("@County_Id", int.Parse(ddl_County.SelectedValue.ToString()));
                        htinsert.Add("@Research_Date", Convert.ToDateTime(txt_ResearchDate.Text));
                        htinsert.Add("@Judgment_Link", txt_Judgmentlink.Text);
                        htinsert.Add("@Lien_Link", txt_Lienlink.Text);
                        htinsert.Add("@Criminal", txt_Criminallink.Text);
                        htinsert.Add("@Subscription", txt_Subscriptionlink.Text);
                        htinsert.Add("@Inserted_By", UserId);
                        htinsert.Add("@Instered_Date", DateTime.Now);
                        htinsert.Add("@Status", "True");
                        dtinsert = dataaccess.ExecuteSP("Sp_Judgment_Link", htinsert);
                        string title = "Insert";
                        MessageBox.Show("Judgment Link Inserted Successfully",title);
                        JudgmentClear();
                        grp_JugmentReg.Visible = false;
                        grp_JudgmentInfo.Visible = true;
                        BindJugmentGrid();
                        btn_Add.Text = "Add New";
                    }
                }
                else if (JudgmentID != 0)
                {
                    Grd_Judgment_Link.Rows.Clear();
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
                    htupdate.Add("@Judgment_Links_Id", JudgmentID);
                    htupdate.Add("@State_Id", Stateid);
                    htupdate.Add("@County_Id", Countyid);
                    htupdate.Add("@Research_Date", txt_ResearchDate.Text);
                    htupdate.Add("@Judgment_Link", txt_Judgmentlink.Text);
                    htupdate.Add("@Lien_Link", txt_Lienlink.Text);
                    htupdate.Add("@Criminal", txt_Criminallink.Text);
                    htupdate.Add("@Subscription", txt_Subscriptionlink.Text);
                    htupdate.Add("@Inserted_By", UserId);
                    htupdate.Add("@Instered_Date", DateTime.Now);
                    htupdate.Add("@Status", "True");
                    dtupdate = dataaccess.ExecuteSP("Sp_Judgment_Link", htupdate);
                    string title = "Update";
                    MessageBox.Show("Judgment Link Updated Successfully",title);

                    JudgmentClear();
                    grp_JugmentReg.Visible = false;
                    grp_JudgmentInfo.Visible = true;
                    BindJugmentGrid();
                    btn_Add.Text = "Add New";
                }
                ddl_State.SelectedIndex = 0;
                ddl_County.SelectedIndex = 0;
                txt_Judgmentlink.Text = "";
            }
            
        }

        private bool Validation()
        {
            string title = "Validation!";
            if (ddl_State.SelectedIndex==0)
            {

                MessageBox.Show("Select State Name", title);
                ddl_State.Focus();
                return false;
            }
            else if (ddl_County.SelectedIndex==0)
            {

                MessageBox.Show("Select County Name", title);
                ddl_County.Focus();
                return false;
            }
            else if (txt_ResearchDate.Text == "")
            {
                MessageBox.Show("Select Research date", title);
                txt_ResearchDate.Focus();
                return false;
            }
            else if (txt_Judgmentlink.Text == "")
            {
                MessageBox.Show("Enter Judgement link", title);
                txt_Judgmentlink.Focus();
                return false;
            }
            return true;
        }

        private void Grd_Judgment_Link_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
               
                //View code
                if (e.ColumnIndex == 10)
                {
                    grp_JudgmentInfo.Visible = false;
                    grp_JugmentReg.Visible = true;
                    Btn_Upload.Visible = false;
                    btn_GetImportExcel.Visible = false;
                    JudgmentID = int.Parse(Grd_Judgment_Link.Rows[e.RowIndex].Cells[12].Value.ToString());
                    Hashtable htselect = new Hashtable();
                    DataTable dtselect = new DataTable();
                    htselect.Add("@Trans", "SELECT");
                    htselect.Add("@Judgment_Links_Id", JudgmentID);
                    dtselect = dataaccess.ExecuteSP("Sp_Judgment_Link", htselect);
                    if (dtselect.Rows.Count > 0)
                    {
                        ddl_State.Text = dtselect.Rows[0]["State"].ToString();
                        ddl_County.Text = dtselect.Rows[0]["County"].ToString();
                        txt_ResearchDate.Text = dtselect.Rows[0]["Research_Date"].ToString();
                        txt_Criminallink.Text = dtselect.Rows[0]["Criminal"].ToString();
                        txt_Judgmentlink.Text = dtselect.Rows[0]["Judgment_Link"].ToString();
                        txt_Lienlink.Text = dtselect.Rows[0]["Lien_Link"].ToString();
                        txt_Subscriptionlink.Text = dtselect.Rows[0]["Subscription"].ToString();
                        lbl_Record_Addedby.Text = dtselect.Rows[0]["User_Name"].ToString();
                        lbl_Record_AddedDate.Text = dtselect.Rows[0]["Instered_Date"].ToString();
                    }
                    btn_AddJugment.Text = "Edit";
                    btn_Add.Text = "Back";
                }
                //Delete code
                else if (e.ColumnIndex == 11)
                {
                    JudgmentID = int.Parse(Grd_Judgment_Link.Rows[e.RowIndex].Cells[12].Value.ToString());
                       var op = MessageBox.Show("Do You Want to Delete the Error Type", "Delete confirmation", MessageBoxButtons.YesNo);
                       if (op == DialogResult.Yes)
                       {
                           Hashtable htdelete = new Hashtable();
                           DataTable dtdelete = new DataTable();
                           htdelete.Add("@Trans", "DELETE");
                           htdelete.Add("@Judgment_Links_Id", JudgmentID);
                           dtdelete = dataaccess.ExecuteSP("Sp_Judgment_Link", htdelete);
                           MessageBox.Show("Record Deleted Successfully");
                           BindJugmentGrid();
                       }
                       else
                       {
                           BindJugmentGrid();
                       }
                }
            }
        }

        private void ddl_County_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            int startindex = CurrentpageIndex * Pagesize;
            int endindex = CurrentpageIndex * Pagesize + Pagesize;
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
                Grd_Judgment_Link.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    Grd_Judgment_Link.Rows.Add();
                    Grd_Judgment_Link.Rows[i].Cells[0].Value = i + 1;
                    Grd_Judgment_Link.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[3].Value = temptable.Rows[i]["Research_Date"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[4].Value = temptable.Rows[i]["Judgment_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[5].Value = temptable.Rows[i]["Lien_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[6].Value = temptable.Rows[i]["Criminal"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[7].Value = temptable.Rows[i]["Subscription"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[8].Value = temptable.Rows[i]["State_ID"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[9].Value = temptable.Rows[i]["County_ID"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[12].Value = temptable.Rows[i]["Judgment_Links_Id"].ToString();

                }
            }
            else
            {
                Grd_Judgment_Link.Rows.Clear();
                Grd_Judgment_Link.Visible = true;
                Grd_Judgment_Link.DataSource = null;
            }

            lbl_count.Text = "Total Records: " + dtsort.Rows.Count.ToString();
            lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / Pagesize);
        }
        private void cbo_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_State.SelectedIndex > 0)
            {
                dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
                Grd_Judgment_Link.Rows.Clear();

                form_loader.Start_progres();
                //progBar.startProgress();
                Hashtable htsort = new Hashtable();
                
                htsort.Add("@Trans", "SORT_STATE");
                htsort.Add("@State_Id", int.Parse(cbo_State.SelectedValue.ToString()));
                dtsort = dataaccess.ExecuteSP("Sp_Judgment_Link", htsort);

                System.Data.DataTable temptable = dtsort.Clone();
                int startindex = CurrentpageIndex * Pagesize;
                int endindex = CurrentpageIndex * Pagesize + Pagesize;
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
                    Grd_Judgment_Link.Rows.Clear();
                    for (int i = 0; i < temptable.Rows.Count; i++)
                    {
                        Grd_Judgment_Link.Rows.Add();
                        Grd_Judgment_Link.Rows[i].Cells[0].Value = i + 1;
                        Grd_Judgment_Link.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[3].Value = temptable.Rows[i]["Research_Date"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[4].Value = temptable.Rows[i]["Judgment_Link"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[5].Value = temptable.Rows[i]["Lien_Link"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[6].Value = temptable.Rows[i]["Criminal"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[7].Value = temptable.Rows[i]["Subscription"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[8].Value = temptable.Rows[i]["State_ID"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[9].Value = temptable.Rows[i]["County_ID"].ToString();
                        Grd_Judgment_Link.Rows[i].Cells[12].Value = temptable.Rows[i]["Judgment_Links_Id"].ToString();

                    }
                    lbl_count.Text = "Total Records: " + dtsort.Rows.Count.ToString();
                    lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / Pagesize);
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
                    Grd_Judgment_Link.Rows.Clear();
                    Grd_Judgment_Link.Visible = true;
                    Grd_Judgment_Link.DataSource = null;
                }

             
               // First_Page();
              
            }
            
        }
        private void GetDataRow_County(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dtcounty.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }

        }
        private void Filter_County_Data()
        {
            System.Data.DataTable temptable = dtsort.Clone();
            int startindex = CurrentpageIndex * Pagesize;
            int endindex = CurrentpageIndex * Pagesize + Pagesize;
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
                Grd_Judgment_Link.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    Grd_Judgment_Link.Rows.Add();
                    Grd_Judgment_Link.Rows[i].Cells[0].Value = i + 1;
                    Grd_Judgment_Link.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[3].Value = temptable.Rows[i]["Research_Date"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[4].Value = temptable.Rows[i]["Judgment_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[5].Value = temptable.Rows[i]["Lien_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[6].Value = temptable.Rows[i]["Criminal"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[7].Value = temptable.Rows[i]["Subscription"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[8].Value = temptable.Rows[i]["State_ID"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[9].Value = temptable.Rows[i]["County_ID"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[12].Value = temptable.Rows[i]["Judgment_Links_Id"].ToString();

                }
            }
            else
            {
                Grd_Judgment_Link.Rows.Clear();
                Grd_Judgment_Link.Visible = true;
                Grd_Judgment_Link.DataSource = null;
            }

            lbl_count.Text = "Total Orders: " + dtcounty.Rows.Count.ToString();
            lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / Pagesize);
          
        }

        private void cbo_County_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_State.SelectedIndex > 0)
            {
                if (cbo_County.SelectedIndex > 0)
                {
                    Grd_Judgment_Link.Rows.Clear();
                    form_loader.Start_progres();
                    //progBar.startProgress();
                    Hashtable ht = new Hashtable();
                   
                    ht.Add("@Trans", "SORT_COUNTY");
                    ht.Add("@State_Id", int.Parse(cbo_State.SelectedValue.ToString()));
                    ht.Add("@County_Id", int.Parse(cbo_County.SelectedValue.ToString()));
                    dtcounty = dataaccess.ExecuteSP("Sp_Judgment_Link", ht);

                    System.Data.DataTable temptable = dtcounty.Clone();
                    int startindex = CurrentpageIndex * Pagesize;
                    int endindex = CurrentpageIndex * Pagesize + Pagesize;
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
                        Grd_Judgment_Link.Rows.Clear();
                        for (int i = 0; i < temptable.Rows.Count; i++)
                        {
                            Grd_Judgment_Link.Rows.Add();
                            Grd_Judgment_Link.Rows[i].Cells[0].Value = i + 1;
                            Grd_Judgment_Link.Rows[i].Cells[1].Value = temptable.Rows[i]["State"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[2].Value = temptable.Rows[i]["County"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[3].Value = temptable.Rows[i]["Research_Date"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[4].Value = temptable.Rows[i]["Judgment_Link"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[5].Value = temptable.Rows[i]["Lien_Link"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[6].Value = temptable.Rows[i]["Criminal"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[7].Value = temptable.Rows[i]["Subscription"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[8].Value = temptable.Rows[i]["State_ID"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[9].Value = temptable.Rows[i]["County_ID"].ToString();
                            Grd_Judgment_Link.Rows[i].Cells[12].Value = temptable.Rows[i]["Judgment_Links_Id"].ToString();

                        }
                        lbl_count.Text = "Total Orders: " + dtcounty.Rows.Count.ToString();
                        lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / Pagesize);
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
                        Grd_Judgment_Link.Rows.Clear();
                        Grd_Judgment_Link.Visible = true;
                        Grd_Judgment_Link.DataSource = null;
                    }

                   
                 
                  //  First_Page();
                    
                }
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            cbo_State.SelectedIndex = 0;
            cbo_County.SelectedIndex = -1;
            BindJugmentGrid();
            First_Page();
            dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
        }

        private void btn_GetImportExcel_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"c:\OMS_Import\");
            string temppath = @"c:\OMS_Import\Judgment_Import.xlsx";
            if (!(Directory.Exists(temppath)))
            {
                File.Copy(@"\\192.168.12.33\OMS-Import_Excels\Judgment_Import.xlsx", temppath, true);
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
            CurrentpageIndex--;
            if (CurrentpageIndex == 0)
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
            if (cbo_State.SelectedIndex > 0)
            {
                Filter_State_Data();
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                Filter_County_Data();
            }
            else
            {
                BindJugmentGrid();
            }
            this.Cursor = currentCursor;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            CurrentpageIndex = 0;
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            btnFirst.Enabled = false;
            if (cbo_State.SelectedIndex > 0)
            {
                Filter_State_Data();
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                Filter_County_Data();
            }
            else
            {
                BindJugmentGrid();
            }

            this.Cursor = currentCursor;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            CurrentpageIndex++;
            if (cbo_State.SelectedIndex > 0)
            {
                if (CurrentpageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / Pagesize) - 1)
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
            else if (cbo_State.SelectedIndex > 0)
            {
                if (CurrentpageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / Pagesize) - 1)
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
                if (CurrentpageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / Pagesize) - 1)
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

            
            }
            BindJugmentGrid();
            this.Cursor = currentCursor; 
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (cbo_State.SelectedIndex > 0)
            {
                CurrentpageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / Pagesize) - 1;
                Filter_State_Data();
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                CurrentpageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / Pagesize) - 1;
                Filter_County_Data();
            }
            else
            {
                CurrentpageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / Pagesize) - 1;
                BindJugmentGrid();
            }
            
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            
            this.Cursor = currentCursor;
        
        }

     


        
    }
}
