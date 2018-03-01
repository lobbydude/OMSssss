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

namespace Ordermanagement_01.Masters
{
    public partial class Tax_Assessment_Link : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        
        System.Data.DataTable dtselect = new System.Data.DataTable();
        System.Data.DataTable dtcounty = new System.Data.DataTable();
        System.Data.DataTable dtsort = new System.Data.DataTable();
        InfiniteProgressBar.clsProgress progBar = new InfiniteProgressBar.clsProgress();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();

        int User_ID,CountyTaxId,count,count_non;
        static int CurrentpageIndex = 0;
        private int pagesize = 10;
        string username;
       string state ;
       string county;
       string duplicate;

       int cntr = 0; //used for custom sort toggle
        public Tax_Assessment_Link(int User_id,string UserName)
        {
            InitializeComponent();
            User_ID = User_id;
            username = UserName;
            dbc.BindState(ddl_State);
            dbc.BindState(cbo_State);
            dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
            dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
        }

        private void Btn_Upload_Click(object sender, EventArgs e)
        {

            grp_TaxAssessInfo.Visible = true;
            grp_TaxAssessReg.Visible = false;

            TaxAssessment_view.Visible = false;
            TaxAssessment_delete.Visible = false;

            Grd_CountyTaxLink.Rows.Clear();

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
                Grd_CountyTaxLink.Rows.Clear();
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {


                        Grd_CountyTaxLink.Rows.Add();
                        Grd_CountyTaxLink.Rows[i].Cells[0].Value = i + 1;
                        Grd_CountyTaxLink.Rows[i].Cells[1].Value = data.Rows[i]["State"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[2].Value = data.Rows[i]["County"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[3].Value = data.Rows[i]["Tax_PhoneNo"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[4].Value = data.Rows[i]["Assessor_PhoneNo"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[5].Value = data.Rows[i]["CountyTax_Link"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[6].Value = data.Rows[i]["Assessor_Link"].ToString();


                    }
                    btn_Import.Visible = true;
                    TaxAssessment_view.Visible = false;
                    TaxAssessment_delete.Visible = false;
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
            count = 0;
            int count_grd = Grd_CountyTaxLink.Rows.Count;
            int count_ex=0;
            for (int i = 0; i < Grd_CountyTaxLink.Rows.Count; i++)
            {
                int Stateid;
                int Countyid;
                
                Hashtable htbarowerstate = new Hashtable();
                DataTable dtbarrowerstate = new System.Data.DataTable();
                htbarowerstate.Add("@Trans", "GETSTATE_BY_ABR");
                htbarowerstate.Add("@state_name", Grd_CountyTaxLink.Rows[i].Cells[1].Value.ToString());
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
                htBarcounty.Add("@County_Name", Grd_CountyTaxLink.Rows[i].Cells[2].Value.ToString());
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
                    dt = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", ht);
                    if (dt.Rows.Count == 0)
                    {
                        Hashtable ht_INSERT = new Hashtable();
                        DataTable dt_INSERT = new System.Data.DataTable();
                        ht_INSERT.Add("@Trans", "INSERT");
                        ht_INSERT.Add("@State", Stateid);
                        ht_INSERT.Add("@County", Countyid);
                        ht_INSERT.Add("@Tax_PhoneNo", Grd_CountyTaxLink.Rows[i].Cells[3].Value.ToString());
                        ht_INSERT.Add("@Assessor_PhoneNo", Grd_CountyTaxLink.Rows[i].Cells[4].Value.ToString());
                        ht_INSERT.Add("@CountyTax_Link", Grd_CountyTaxLink.Rows[i].Cells[5].Value.ToString());
                        ht_INSERT.Add("@Assessor_Link", Grd_CountyTaxLink.Rows[i].Cells[6].Value.ToString());
                        ht_INSERT.Add("@Inserted_By", User_ID);
                        ht_INSERT.Add("@Status", "True");
                        dt_INSERT = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", ht_INSERT);
                        count = count + 1;
                    }
                }
                else
                {
                    count_non = count_non + 1;
                }
            }
            form_loader.Start_progres();
            //progBar.startProgress();
            if (count > 0)
            {
                string title = "Successfull";
                MessageBox.Show(count +" No of Tax Assessment Link Records Imported successfully",title);
            }
            else
            {
                count_ex = count_grd - count_non;
                string title = "Existed!";
                MessageBox.Show(count_ex + " No of Tax Assessment Link Records Already Exists",title);
               // MessageBox.Show(count_non + " No of Tax Assessment Link Records Incorrect Format");
            }
            BindTaxAssessmentGrid();
            btn_Import.Visible = false;
            TaxAssessment_view.Visible = true;
            TaxAssessment_delete.Visible = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (btn_Add.Text == "Add New")
            {
                btn_Import.Visible = false;
                grp_TaxAssessInfo.Visible = false;
                grp_TaxAssessReg.Visible = true;
                TaxAssessmentClear();
                btn_Add.Text = "Back";
                btn_AddTaxCounty.Text = "Submit";
                dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
                Btn_Upload.Visible = false;
                btn_GetImportExcel.Visible = false;
                lbl_Record_Addedby.Text = username;
                lbl_Record_AddedDate.Text =DateTime.Now.ToString();
            }
            else
            {
                grp_TaxAssessInfo.Visible = true;
                grp_TaxAssessReg.Visible = false;
                TaxAssessmentClear();
                btn_Add.Text = "Add New";
                dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
                Btn_Upload.Visible = true;
                btn_GetImportExcel.Visible = true;
                btn_Import.Visible = true;
            }
        }
        private bool Validation()
        {
            string title = "Validation!";
            if (ddl_State.SelectedIndex==0)
            {
                
                MessageBox.Show("Select State Name",title);
                return false;
            }
            else if (ddl_County.SelectedIndex==0)
            {
               
                MessageBox.Show("Select County Name", title);
                return false;
            }
            else if (txt_Tax_PhoneNo.Text=="")
            {
              
                MessageBox.Show("Select Tax Phone Number", title);
                return false;
            }

         

            return true;
        }
        private bool Duplicate_Record()
        {
            Hashtable ht_checkDuplicate = new Hashtable();
            DataTable dt_checkDuplicate = new DataTable();

            ht_checkDuplicate.Add("@Trans", "SELECT_BY_STATE_COUNTY");
            ht_checkDuplicate.Add("@State", ddl_State.SelectedValue.ToString());
            ht_checkDuplicate.Add("@County", ddl_County.SelectedValue.ToString());
            dt_checkDuplicate = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", ht_checkDuplicate);
          
            for (int i = 0; i <= dt_checkDuplicate.Rows.Count - 1; i++)
            {
                state = dt_checkDuplicate.Rows[0]["State_ID"].ToString();
                county = dt_checkDuplicate.Rows[0]["County_ID"].ToString();

                string selected_state = ddl_State.SelectedValue.ToString();
                string selected_County = ddl_County.SelectedValue.ToString();

                if (state == selected_state && county == selected_County && btn_AddTaxCounty.Text != "Edit")
                {
                    duplicate = "Duplicate Data";
                    string title = "Duplicate Record!";
                    MessageBox.Show("Record Already Existed", title);
                 
                    return false;
                }
            }

            return true;
        }
        private void btn_AddTaxCounty_Click(object sender, EventArgs e)
        {


            if (Validation() != false && Duplicate_Record()!=false)
            {
                if (CountyTaxId == 0 && btn_AddTaxCounty.Text == "Submit")
                {
                    
                    Hashtable htinsert = new Hashtable();
                    DataTable dtinsert = new DataTable();
                    htinsert.Add("@Trans", "INSERT");
                    htinsert.Add("@State", int.Parse(ddl_State.SelectedValue.ToString()));
                    htinsert.Add("@County", int.Parse(ddl_County.SelectedValue.ToString()));
                    htinsert.Add("@Tax_PhoneNo", txt_Tax_PhoneNo.Text);
                    htinsert.Add("@Assessor_PhoneNo", txt_Assessor_PhoneNo.Text);
                    htinsert.Add("@CountyTax_Link", txt_CountyTax_Link.Text);
                    htinsert.Add("@Assessor_Link", txt_Assessor_Link.Text);
                    htinsert.Add("@Inserted_By", User_ID);
                    htinsert.Add("@Inserted_date", DateTime.Now);
                    htinsert.Add("@Status", "True");
                    dtinsert = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", htinsert);

                    string title = "Insert Window";
                    MessageBox.Show("Tax Assessment Link Inserted Successfully",title);
                    //Btn_Upload.Visible = false;
                    //btn_GetImportExcel.Visible = false;
                    BindTaxAssessmentGrid();

                    //cbo_State.SelectedIndex = 0;
                    //cbo_County.SelectedIndex = 0;
                }
                else if (CountyTaxId!=0)
                {
                  
                    Grd_CountyTaxLink.Rows.Clear();
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

                   // CountyTaxId = int.Parse(Grd_CountyTaxLink.Rows[e.RowIndex].Cells[11].Value.ToString());

                   // CountyTaxId =int.Parse(ddl_County.SelectedValue.ToString());

                    Hashtable htupdate = new Hashtable();
                    DataTable dtupdate = new DataTable();
                    htupdate.Add("@Trans", "UPDATE");
                    htupdate.Add("@County_Assement_Link_Id", CountyTaxId);
                    htupdate.Add("@State", Stateid);
                    htupdate.Add("@County", Countyid);

                    htupdate.Add("@Tax_PhoneNo", txt_Tax_PhoneNo.Text);
                    htupdate.Add("@Assessor_PhoneNo", txt_Assessor_PhoneNo.Text);
                    htupdate.Add("@CountyTax_Link", txt_CountyTax_Link.Text);
                    htupdate.Add("@Assessor_Link", txt_Assessor_Link.Text);
                    htupdate.Add("@Inserted_By", User_ID);
                    htupdate.Add("@Inserted_date", DateTime.Now);
                    htupdate.Add("@Status", "True");
                    dtupdate = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", htupdate);

                    string title = "Updated";
                    MessageBox.Show("Tax Assessment Link Updated Successfully",title);
                    BindTaxAssessmentGrid();
                }
                TaxAssessmentClear();
                grp_TaxAssessReg.Visible = false;
                grp_TaxAssessInfo.Visible = true;
                //BindTaxAssessmentGrid();
                btn_Add.Text = "Add New";

                cbo_State.SelectedIndex = 0;
                cbo_County.SelectedIndex = 0;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            TaxAssessmentClear();
            dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
        }

        private void TaxAssessmentClear()
        {

            ddl_State.SelectedIndex = 0;
            ddl_County.SelectedIndex = -1;
         
            txt_CountyTax_Link.Text = "";
            txt_Tax_PhoneNo.Text = "";
            txt_Assessor_PhoneNo.Text = "";
            txt_Assessor_Link.Text = "";
            //lbl_Record_Addedby.Text = "";
            //lbl_Record_AddedDate.Text = "";


        }

        private void Grd_CountyTaxLink_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                
                if (e.ColumnIndex == 9)
                {
                    grp_TaxAssessInfo.Visible = false;
                    grp_TaxAssessReg.Visible = true;
                    Btn_Upload.Visible = false;
                    btn_GetImportExcel.Visible = false;
                    //View code
                    CountyTaxId = int.Parse(Grd_CountyTaxLink.Rows[e.RowIndex].Cells[11].Value.ToString());
                    Hashtable htselect = new Hashtable();
                    DataTable dtselect = new DataTable();
                    htselect.Add("@Trans", "SELECT");
                    htselect.Add("@County_Assement_Link_Id", CountyTaxId);
                    dtselect = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", htselect);
                    if (dtselect.Rows.Count > 0)
                    {
                        ddl_State.Text = dtselect.Rows[0]["State"].ToString();
                        ddl_County.Text = dtselect.Rows[0]["County"].ToString();
                        txt_Tax_PhoneNo.Text = dtselect.Rows[0]["Tax_PhoneNo"].ToString();
                        txt_Assessor_PhoneNo.Text = dtselect.Rows[0]["Assessor_PhoneNo"].ToString();
                        txt_CountyTax_Link.Text = dtselect.Rows[0]["CountyTax_Link"].ToString();
                        txt_Assessor_Link.Text = dtselect.Rows[0]["Assessor_Link"].ToString();
                        lbl_Record_Addedby.Text = dtselect.Rows[0]["User_Name"].ToString();
                        lbl_Record_AddedDate.Text = dtselect.Rows[0]["Inserted_date"].ToString();
                    }
                    btn_AddTaxCounty.Text = "Edit";
                    btn_Add.Text = "Back";
                    
                }
                //Delete code
                else if (e.ColumnIndex == 10)
                {
                    DialogResult dialog = MessageBox.Show("Do you want to Delete Record", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        if (CountyTaxId!=0)
                        {
                            CountyTaxId = int.Parse(Grd_CountyTaxLink.Rows[e.RowIndex].Cells[11].Value.ToString());
                            Hashtable htdelete = new Hashtable();
                            DataTable dtdelete = new DataTable();
                            htdelete.Add("@Trans", "DELETE");
                            htdelete.Add("@County_Assement_Link_Id", CountyTaxId);
                            dtdelete = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", htdelete);

                           // string message = "Close Window";
                           // string title = "Delete Window";
                            MessageBox.Show("Record Deleted Successfully");
                            BindTaxAssessmentGrid();
                        }
                        else
                        {
                            string title = "Select!";
                            MessageBox.Show("Please Select the Record",title);
                        }
                    }
                }
            }
        }

        private void Filter_State_Data()
        {
            System.Data.DataTable tempTable = dtsort.Clone();
            int startindex = CurrentpageIndex * pagesize;
            int endindex = CurrentpageIndex * pagesize + pagesize;
            if (endindex > dtsort.Rows.Count)
            {
                endindex = dtsort.Rows.Count;
            }
            for (int i = startindex; i < endindex; i++)
            {
                DataRow newrow = tempTable.NewRow();
                GetNewRow_State(ref newrow, dtsort.Rows[i]);
                tempTable.Rows.Add(newrow);
            }

            if (tempTable.Rows.Count > 0)
            {
                Grd_CountyTaxLink.Rows.Clear();
                for (int i = 0; i < tempTable.Rows.Count; i++)
                {
                    Grd_CountyTaxLink.Rows.Add();
                    Grd_CountyTaxLink.Rows[i].Cells[0].Value = i + 1;
                    Grd_CountyTaxLink.Rows[i].Cells[1].Value = tempTable.Rows[i]["State"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[2].Value = tempTable.Rows[i]["County"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[3].Value = tempTable.Rows[i]["Tax_PhoneNo"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[4].Value = tempTable.Rows[i]["Assessor_PhoneNo"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[5].Value = tempTable.Rows[i]["CountyTax_Link"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[6].Value = tempTable.Rows[i]["Assessor_Link"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[7].Value = tempTable.Rows[i]["State_ID"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[8].Value = tempTable.Rows[i]["County_ID"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[11].Value = tempTable.Rows[i]["County_Assement_Link_Id"].ToString();
                }

            }



            else
            {
                Grd_CountyTaxLink.Rows.Clear();
                Grd_CountyTaxLink.Visible = true;
                Grd_CountyTaxLink.DataSource = null;
            }
            lbl_count.Text = "Total Orders: " + dtsort.Rows.Count.ToString();
            lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pagesize);
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

        private void cbo_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_State.SelectedIndex > 0)
            {
                dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
                Grd_CountyTaxLink.Rows.Clear();
                form_loader.Start_progres();
                //progBar.startProgress();
                Hashtable htsort = new Hashtable();
               
                htsort.Add("@Trans", "SELECT_BY_STATE");
                htsort.Add("@State", int.Parse(cbo_State.SelectedValue.ToString()));
                //Bind_Grid_Tax_PageIndex();

                dtsort = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", htsort);

                System.Data.DataTable tempTable = dtsort.Clone();
                int startindex = CurrentpageIndex * pagesize;
                int endindex = CurrentpageIndex * pagesize + pagesize;
                if (endindex > dtsort.Rows.Count)
                {
                    endindex = dtsort.Rows.Count;
                }
                for (int i = startindex; i < endindex; i++)
                {
                    DataRow newrow = tempTable.NewRow();
                    GetNewRow_State(ref newrow, dtsort.Rows[i]);
                    tempTable.Rows.Add(newrow);
                }

                if (tempTable.Rows.Count > 0)
                {
                    Grd_CountyTaxLink.Rows.Clear();
                    for (int i = 0; i < tempTable.Rows.Count; i++)
                    {
                        Grd_CountyTaxLink.Rows.Add();
                        Grd_CountyTaxLink.Rows[i].Cells[0].Value = i + 1;
                        Grd_CountyTaxLink.Rows[i].Cells[1].Value = tempTable.Rows[i]["State"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[2].Value = tempTable.Rows[i]["County"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[3].Value = tempTable.Rows[i]["Tax_PhoneNo"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[4].Value = tempTable.Rows[i]["Assessor_PhoneNo"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[5].Value = tempTable.Rows[i]["CountyTax_Link"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[6].Value = tempTable.Rows[i]["Assessor_Link"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[7].Value = tempTable.Rows[i]["State_ID"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[8].Value = tempTable.Rows[i]["County_ID"].ToString();
                        Grd_CountyTaxLink.Rows[i].Cells[11].Value = tempTable.Rows[i]["County_Assement_Link_Id"].ToString();
                    }
                    lbl_count.Text = "Total Records: " + dtsort.Rows.Count.ToString();
                    lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pagesize);
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
                    Grd_CountyTaxLink.Rows.Clear();
                    Grd_CountyTaxLink.Visible = true;
                    Grd_CountyTaxLink.DataSource = null;
                }
                //lbl_count.Text = "Total Orders: " + dtsort.Rows.Count.ToString();
                //lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pagesize);
                //First_Page();
               
            }
          
        }

        private void Filter_County_Data()
        {
            System.Data.DataTable tempTable = dtcounty.Clone();
            int startindex = CurrentpageIndex * pagesize;
            int endindex = CurrentpageIndex * pagesize + pagesize;
            if (endindex > dtcounty.Rows.Count)
            {
                endindex = dtcounty.Rows.Count;
            }
            for (int i = startindex; i < endindex; i++)
            {
                DataRow newrow = tempTable.NewRow();
                GetNewRow_County(ref newrow, dtcounty.Rows[i]);
                tempTable.Rows.Add(newrow);
            }

            if (tempTable.Rows.Count > 0)
            {
                Grd_CountyTaxLink.Rows.Clear();
                for (int i = 0; i < tempTable.Rows.Count; i++)
                {
                    Grd_CountyTaxLink.Rows.Add();
                    Grd_CountyTaxLink.Rows[i].Cells[0].Value = i + 1;
                    Grd_CountyTaxLink.Rows[i].Cells[1].Value = tempTable.Rows[i]["State"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[2].Value = tempTable.Rows[i]["County"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[3].Value = tempTable.Rows[i]["Tax_PhoneNo"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[4].Value = tempTable.Rows[i]["Assessor_PhoneNo"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[5].Value = tempTable.Rows[i]["CountyTax_Link"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[6].Value = tempTable.Rows[i]["Assessor_Link"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[7].Value = tempTable.Rows[i]["State_ID"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[8].Value = tempTable.Rows[i]["County_ID"].ToString();
                    Grd_CountyTaxLink.Rows[i].Cells[11].Value = tempTable.Rows[i]["County_Assement_Link_Id"].ToString();
                }

            }



            else
            {
                Grd_CountyTaxLink.Rows.Clear();
                Grd_CountyTaxLink.Visible = true;
                Grd_CountyTaxLink.DataSource = null;
            }
            lbl_count.Text = "Total Orders: " + dtcounty.Rows.Count.ToString();
            lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pagesize);
        }

        private void cbo_County_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_State.SelectedIndex > 0)
            {
                if (cbo_County.SelectedIndex > 0)
                {
                    Grd_CountyTaxLink.Rows.Clear();
                    form_loader.Start_progres();
                    //progBar.startProgress();
                    Hashtable ht = new Hashtable();
                    
                    ht.Add("@Trans", "SELECT_BY_STATE_COUNTY");
                    ht.Add("@State", int.Parse(cbo_State.SelectedValue.ToString()));
                    ht.Add("@County", int.Parse(cbo_County.SelectedValue.ToString()));

                    dtcounty = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", ht);

                    System.Data.DataTable tempTable = dtcounty.Clone();
                    int startindex = CurrentpageIndex * pagesize;
                    int endindex = CurrentpageIndex * pagesize + pagesize;
                    if (endindex > dtcounty.Rows.Count)
                    {
                        endindex = dtcounty.Rows.Count;
                    }
                    for (int i = startindex; i < endindex; i++)
                    {
                        DataRow newrow = tempTable.NewRow();
                        GetNewRow_County(ref newrow, dtcounty.Rows[i]);
                        tempTable.Rows.Add(newrow);
                    }

                    if (tempTable.Rows.Count > 0)
                    {
                        Grd_CountyTaxLink.Rows.Clear();
                        for (int i = 0; i < tempTable.Rows.Count; i++)
                        {
                            Grd_CountyTaxLink.Rows.Add();
                            Grd_CountyTaxLink.Rows[i].Cells[0].Value = i + 1;
                            Grd_CountyTaxLink.Rows[i].Cells[1].Value = tempTable.Rows[i]["State"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[2].Value = tempTable.Rows[i]["County"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[3].Value = tempTable.Rows[i]["Tax_PhoneNo"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[4].Value = tempTable.Rows[i]["Assessor_PhoneNo"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[5].Value = tempTable.Rows[i]["CountyTax_Link"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[6].Value = tempTable.Rows[i]["Assessor_Link"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[7].Value = tempTable.Rows[i]["State_ID"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[8].Value = tempTable.Rows[i]["County_ID"].ToString();
                            Grd_CountyTaxLink.Rows[i].Cells[11].Value = tempTable.Rows[i]["County_Assement_Link_Id"].ToString();
                        }
                        lbl_count.Text = "Total Records: " + dtcounty.Rows.Count.ToString();
                        lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pagesize);

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
                        Grd_CountyTaxLink.Rows.Clear();
                        Grd_CountyTaxLink.Visible = true;
                        Grd_CountyTaxLink.DataSource = null;

                    }
                    //lbl_count.Text = "Total Orders: " + dtcounty.Rows.Count.ToString();
                    //lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pagesize);
                    
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
          // First_Page();
        }

        private void GetNewRow(ref DataRow newrow, DataRow source)
        {
            foreach (DataColumn col in dtselect.Columns)
            {
                newrow[col.ColumnName] = source[col.ColumnName];
            }
        }

        private void GetNewRow_State(ref DataRow newrow, DataRow source)
        {
            foreach (DataColumn col in dtsort.Columns)
            {
                newrow[col.ColumnName] = source[col.ColumnName];
            }
        }

        private void GetNewRow_County(ref DataRow newrow, DataRow source)
        {
            foreach (DataColumn col in dtcounty.Columns)
            {
                newrow[col.ColumnName] = source[col.ColumnName];
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            cbo_State.SelectedIndex = 0;
            cbo_County.SelectedIndex = -1;
            BindTaxAssessmentGrid();
            First_Page();

            dbc.BindCounty(cbo_County, int.Parse(cbo_State.SelectedValue.ToString()));
            
        }
     
        private void BindTaxAssessmentGrid()
        {
            form_loader.Start_progres();
            //progBar.startProgress();

            Grd_CountyTaxLink.Rows.Clear();
            Hashtable htselect = new Hashtable();
            

            if (cbo_State.SelectedIndex > 0)
            {
                htselect.Add("@Trans", "SELECT_BY_STATE");
                htselect.Add("@State", int.Parse(cbo_State.SelectedValue.ToString()));
                if (cbo_County.SelectedIndex > 0)
                {
                    htselect.Clear();
                    htselect.Add("@Trans", "SELECT_BY_STATE_COUNTY");

                    htselect.Add("@State", int.Parse(cbo_State.SelectedValue.ToString()));
                    htselect.Add("@County", int.Parse(cbo_County.SelectedValue.ToString()));
                }
            }
            else
            {
                htselect.Add("@Trans", "SELECT_ALL");
                
            }
           dtselect = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", htselect);

           System.Data.DataTable tempTable = dtselect.Clone();
           int startindex = CurrentpageIndex * pagesize;
           int endindex = CurrentpageIndex * pagesize + pagesize;
           if (endindex > dtselect.Rows.Count)
           {
               endindex = dtselect.Rows.Count;
           }
           for (int i = startindex; i < endindex; i++)
           {
               DataRow newrow = tempTable.NewRow();
               GetNewRow(ref newrow, dtselect.Rows[i]);
               tempTable.Rows.Add(newrow);
           }

           if (tempTable.Rows.Count > 0)
           {
               Grd_CountyTaxLink.Rows.Clear();
               for (int i = 0; i < tempTable.Rows.Count; i++)
               {
                   Grd_CountyTaxLink.Rows.Add();
                   Grd_CountyTaxLink.Rows[i].Cells[0].Value = i + 1;
                   Grd_CountyTaxLink.Rows[i].Cells[1].Value = tempTable.Rows[i]["State"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[2].Value = tempTable.Rows[i]["County"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[3].Value = tempTable.Rows[i]["Tax_PhoneNo"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[4].Value = tempTable.Rows[i]["Assessor_PhoneNo"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[5].Value = tempTable.Rows[i]["CountyTax_Link"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[6].Value = tempTable.Rows[i]["Assessor_Link"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[7].Value = tempTable.Rows[i]["State_ID"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[8].Value = tempTable.Rows[i]["County_ID"].ToString();
                   Grd_CountyTaxLink.Rows[i].Cells[11].Value = tempTable.Rows[i]["County_Assement_Link_Id"].ToString();
               }

           }



           else
           {
               Grd_CountyTaxLink.Rows.Clear();
               Grd_CountyTaxLink.Visible = true;
               Grd_CountyTaxLink.DataSource = null;
           }
           lbl_count.Text = "Total Records: " + dtselect.Rows.Count.ToString();
           lblRecordsStatus.Text = (CurrentpageIndex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pagesize);

            
           
        }


        private void Tax_Assessment_Link_Load(object sender, EventArgs e)
        {
            btn_Import.Visible = true;
            grp_TaxAssessReg.Visible = false;
            grp_TaxAssessInfo.Visible = true;
            if (cbo_State.SelectedIndex == 0 && cbo_County.SelectedIndex==0)
            {
            BindTaxAssessmentGrid();
            }
            First_Page();

            dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
         
        }
        

        private void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_State.SelectedIndex > 0)
            {
                dbc.BindCounty(ddl_County, int.Parse(ddl_State.SelectedValue.ToString()));
            }
        }

        private void btn_GetImportExcel_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"c:\OMS_Import\");
            string temppath = @"c:\OMS_Import\Tax_Assesment_Import.xlsx";
            if (!Directory.Exists(temppath))
            {
                File.Copy(@"\\192.168.12.33\OMS-Import_Excels\Tax_Assesment_Import.xlsx", temppath, true);
                Process.Start(temppath);
            }
            else
            {
                Process.Start(temppath);
            }
        }

        private void txt_Tax_PhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Assessor_PhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            CurrentpageIndex++;
            if (cbo_State.SelectedIndex > 0)
            {
                if (CurrentpageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pagesize) - 1)
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
                if (CurrentpageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pagesize) - 1)
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
                btnNext.Enabled = false;
                //btnLast.Enabled = false;
                //btnPrevious.Enabled = true;
                Filter_County_Data();
            }
            else
            {
                if (CurrentpageIndex == (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pagesize) - 1)
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
                //btnNext.Enabled = false;
                //btnLast.Enabled = false;

              //  BindTaxAssessmentGrid();
            }
            
            BindTaxAssessmentGrid();

           
            this.Cursor = currentCursor;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (cbo_State.SelectedIndex > 0)
            {
                CurrentpageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtsort.Rows.Count) / pagesize) - 1;
                Filter_State_Data();
            }
            else if (cbo_County.SelectedIndex > 0)
            {
                CurrentpageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtcounty.Rows.Count) / pagesize) - 1;
                Filter_County_Data();
            }
            else
            {
                CurrentpageIndex = (int)Math.Ceiling(Convert.ToDecimal(dtselect.Rows.Count) / pagesize) - 1;
                BindTaxAssessmentGrid();
            }
            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
            
            this.Cursor = currentCursor;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
        
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
                BindTaxAssessmentGrid();
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
                BindTaxAssessmentGrid();
            }

            

            this.Cursor = currentCursor;
        }

        private void Grd_CountyTaxLink_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (cntr % 2 == 0) //This condition applied for toggeling the Ascending and Descending sort
                Grd_CountyTaxLink.Sort(Grd_CountyTaxLink.Columns[e.ColumnIndex], ListSortDirection.Ascending);
            else
                Grd_CountyTaxLink.Sort(Grd_CountyTaxLink.Columns[e.ColumnIndex], ListSortDirection.Descending);
            cntr++;

            //DataGridViewColumn newColumn = Grd_CountyTaxLink.Columns[e.ColumnIndex];
            //DataGridViewColumn oldColumn = Grd_CountyTaxLink.SortedColumn;
            //ListSortDirection direction;

            //// If oldColumn is null, then the DataGridView is not sorted.
            //if (oldColumn != null)
            //{
            //    // Sort the same column again, reversing the SortOrder.
            //    if (oldColumn == newColumn &&
            //        Grd_CountyTaxLink.SortOrder == SortOrder.Ascending)
            //    {
            //        direction = ListSortDirection.Descending;
            //    }
            //    else
            //    {
            //        // Sort a new column and remove the old SortGlyph.
            //        direction = ListSortDirection.Ascending;
            //        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            //    }
            //}
            //else
            //{
            //    direction = ListSortDirection.Ascending;
            //}

            //// Sort the selected column.
            //Grd_CountyTaxLink.Sort(newColumn, direction);
            //newColumn.HeaderCell.SortGlyphDirection =
            //    direction == ListSortDirection.Ascending ?
            //    SortOrder.Ascending : SortOrder.Descending;

         
        
        }

      
    
    }
}
