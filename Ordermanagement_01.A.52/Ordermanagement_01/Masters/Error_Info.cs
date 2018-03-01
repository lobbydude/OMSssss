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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;

namespace Ordermanagement_01.Masters
{
    public partial class Error_Info : Form
    {
         Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        int userid, ErrorTypeID, value,RepeatVal,ErrRepeat,InsertVal,InsertErrVal; string username, ErrorType;
        private System.Drawing.Point pt, pt1, err, err1, btn, btn1,grp;
        System.Data.DataTable dtSelType = new System.Data.DataTable();
        System.Data.DataTable dtSelDes = new System.Data.DataTable();
        System.Data.DataTable dtsel = new System.Data.DataTable();
        public Error_Info(int Userid,string Username)
        {
            InitializeComponent();
            userid=Userid;
            username=Username;
            Gridview_Bind_Error_Type();
            Gridview_Bind_Error_description();
            dbc.Bind_Error_Type(ddl_ErrorType);
        }

        private void Error_Info_Load(object sender, EventArgs e)
        {
            txt_ErrorType.Select();
            dbc.Bind_Error_Type(ddl_ErrorType);
            
            Gridview_Bind_Error_Type();
            Gridview_Bind_Error_description();
        }

        private void btn_ErrorAdd_Click(object sender, EventArgs e)
        {
            if (lbl_ErrorTypeId.Text == "")
            {
                string ErrorType = txt_ErrorType.Text;
                Hashtable ht = new Hashtable();
                System.Data.DataTable dt = new System.Data.DataTable();
                ht.Add("@Error_Type", txt_ErrorType.Text);
                dt = dataaccess.ExecuteSP("Sp_Errors_Details", ht);
                if (dt.Rows.Count > 0)
                {
                    ErrRepeat = 1;
                }
                if (ErrorType != "")
                {
                    if (ErrRepeat == 0)
                    {
                        Hashtable htinsert_Type = new Hashtable();
                        System.Data.DataTable dtinsert_Type = new System.Data.DataTable();
                        htinsert_Type.Add("@Trans", "INSERT_Error_Type");
                        htinsert_Type.Add("@Error_Type", ErrorType);
                        htinsert_Type.Add("@Inserted_By", userid);
                        htinsert_Type.Add("@Instered_Date", DateTime.Now);
                        dtinsert_Type = dataaccess.ExecuteSP("Sp_Errors_Details", htinsert_Type);
                        Cancel();
                        string title = "Insert";
                        MessageBox.Show("*" + ErrorType + "*" + " Inserted Successfully",title);
                    }
                    else
                    {
                        string title = "Exist";
                        MessageBox.Show("Error Type Name Already Exists",title);
                    }
                }
                else
                {
                    string title = "Alert!";
                    MessageBox.Show("Please Enter Error Type Value",title);
                    txt_ErrorType.Focus();
                }
            }
            else
            {
                string Error_Type_Id = lbl_ErrorTypeId.Text;
                Hashtable htinsert_Type = new Hashtable();
                System.Data.DataTable dtinsert_Type = new System.Data.DataTable();
                htinsert_Type.Add("@Trans", "UPDATE_Error_Type");
                htinsert_Type.Add("@Error_Type_Id", Error_Type_Id);
                htinsert_Type.Add("@Error_Type", txt_ErrorType.Text);
                htinsert_Type.Add("@Modified_By", userid);
                htinsert_Type.Add("@Modified_Date", DateTime.Now);
                dtinsert_Type = dataaccess.ExecuteSP("Sp_Errors_Details", htinsert_Type);
                btn_ErrorAdd.Text = "Submit";

                string title = "Update";
                MessageBox.Show("*"+txt_ErrorType.Text +"*"+ " Error Type Updated Successfully",title);
            }
            Gridview_Bind_Error_Type();
            dbc.Bind_Error_Type(ddl_ErrorType);
            
            txt_ErrorType.Text = "";
            lbl_ErrorTypeId.Text = "";
           
        }
        
        
        private void Gridview_Bind_Error_Type()
        {
            Grd_ErrorType.Rows.Clear();
            Hashtable htSelect = new Hashtable();
            
            htSelect.Add("@Trans", "SELECT_Error_Type");
            dtsel = dataaccess.ExecuteSP("Sp_Errors_Details", htSelect);
            Column3.Visible = true;
            Column4.Visible = true;
            if (dtsel.Rows.Count > 0)
            {
                for (int i = 0; i < dtsel.Rows.Count; i++)
                {
                    Grd_ErrorType.Rows.Add();
                    Grd_ErrorType.Rows[i].Cells[0].Value = dtsel.Rows[i]["Error_Type_Id"].ToString();
                    Grd_ErrorType.Rows[i].Cells[1].Value = i + 1;
                    Grd_ErrorType.Rows[i].Cells[2].Value = dtsel.Rows[i]["Error_Type"].ToString();
                    Grd_ErrorType.Rows[i].Cells[3].Value = "View";
                    Grd_ErrorType.Rows[i].Cells[4].Value = "Delete";
                }
            }
            else
            {
                Grd_ErrorType.DataSource = null;

            }
         }
        private bool Validation()
        {
            string title = "Validation!";
            if (txt_ErrorDescription.Text == "")
            {
                MessageBox.Show("Please Enter Error Description",title);
                txt_ErrorDescription.Focus();
                return false;
            }
            //else if (ddl_ErrorType.SelectedValue != null)
            //{
            //    MessageBox.Show("Please Select Error Type");
            //    ddl_ErrorType.Focus();
            //    dbc.Bind_Error_Type(ddl_ErrorType);
            //    return false;
            //}
            else if (ddl_ErrorType.SelectedText == "Select")
            {
                MessageBox.Show("Please Select Error Type",title);
                ddl_ErrorType.Focus();
                dbc.Bind_Error_Type(ddl_ErrorType);
                return false;
            }
            else if (ddl_ErrorType.SelectedText == null)
            {
                MessageBox.Show("Please Select Error Type",title);
                ddl_ErrorType.Focus();
                dbc.Bind_Error_Type(ddl_ErrorType);
                return false;
            }
            else if (ddl_ErrorType.SelectedIndex == 0 || ddl_ErrorType.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Error Type",title);
                ddl_ErrorType.Focus();
                dbc.Bind_Error_Type(ddl_ErrorType);
                return false;
            }
            return true;
        }
        private void btn_ErrorDesAdd_Click(object sender, EventArgs e)
        {
            if (lbl_ErrorDesc.Text == "")
            {
                if (Validation() != false)
                {
                    Hashtable ht = new Hashtable();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    ht.Add("@Trans", "CHECK");
                    ht.Add("@Error_Type_Id", ddl_ErrorType.SelectedValue);
                    ht.Add("@Error_description", txt_ErrorDescription.Text.ToUpper());
                    dt = dataaccess.ExecuteSP("Sp_Errors_Details", ht);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["count"].ToString() == "0")
                        {
                            RepeatVal = 0;
                        }
                        else
                        {
                            RepeatVal = 1;
                        }
                    }


                    if (RepeatVal == 0)
                    {
                        string ErrorDesc = txt_ErrorDescription.Text;
                        //int ddlErrorType =;


                        Hashtable htinsert_Type = new Hashtable();
                        System.Data.DataTable dtinsert_Type = new System.Data.DataTable();
                        htinsert_Type.Add("@Trans", "INSERT_Error_description");
                        htinsert_Type.Add("@Error_Type_Id", ddl_ErrorType.SelectedValue);
                        htinsert_Type.Add("@Error_description", ErrorDesc);
                        htinsert_Type.Add("@Inserted_By", userid);
                        htinsert_Type.Add("@Instered_Date", DateTime.Now);
                        dtinsert_Type = dataaccess.ExecuteSP("Sp_Errors_Details", htinsert_Type);

                        btn_ErrorDesAdd.Text = "Submit";
                        Clear();
                        string title = "Insert";
                        MessageBox.Show("*" + ErrorDesc + "*" + " Error Description Inserted Successfully",title);
                    }
                    else
                    {
                        string title = "Exist";
                        MessageBox.Show("Error Description Value Already Exists",title);

                    }

                }
            }
            else
            {
                string ErrorDesId = lbl_ErrorDesc.Text;
                int ddlErrorType = int.Parse(ddl_ErrorType.SelectedValue.ToString());
                string ErrorDesc = txt_ErrorDescription.Text;
                if (ddlErrorType != 0 && ErrorDesc != "")
                {
                    Hashtable htinsert_Type = new Hashtable();
                    System.Data.DataTable dtinsert_Type = new System.Data.DataTable();
                    htinsert_Type.Add("@Trans", "UPDATE_Error_description");
                    htinsert_Type.Add("@Error_description_Id", ErrorDesId);
                    htinsert_Type.Add("@Error_Type_Id", ddlErrorType);
                    htinsert_Type.Add("@Error_description", ErrorDesc);
                    htinsert_Type.Add("@Modified_By", userid);
                    htinsert_Type.Add("@Modified_Date", DateTime.Now);
                    dtinsert_Type = dataaccess.ExecuteSP("Sp_Errors_Details", htinsert_Type);
                    Clear();
                    string title = "Update";
                    MessageBox.Show("*" + ErrorDesc + "*" + " Error Description Updated Successfully",title);
                }
                else
                {
                    string title = "Select!";
                    MessageBox.Show("Please Select Error Type",title);
                    ddl_ErrorType.Focus();
                }
            }
            Gridview_Bind_Error_description();
            txt_ErrorDescription.Text = "";
            lbl_ErrorDesc.Text = "";
            ddl_ErrorType.SelectedValue = 0;
        }
        private void Gridview_Bind_Error_description()
        {
            Grd_ErrorDesc.Rows.Clear();
            Hashtable htSelect = new Hashtable();
            
            htSelect.Add("@Trans", "SELECT_Error_description_grd");
            dtSelDes = dataaccess.ExecuteSP("Sp_Errors_Details", htSelect);
            Column9.Visible = true;
            Column10.Visible = true;
            if (dtSelDes.Rows.Count > 0)
            {
                for (int i = 0; i < dtSelDes.Rows.Count; i++)
                {
                    Grd_ErrorDesc.Rows.Add();
                    Grd_ErrorDesc.Rows[i].Cells[0].Value = dtSelDes.Rows[i]["Error_description_Id"].ToString();
                    Grd_ErrorDesc.Rows[i].Cells[1].Value = dtSelDes.Rows[i]["Error_Type_Id"].ToString();
                    Grd_ErrorDesc.Rows[i].Cells[2].Value = i + 1;
                    Grd_ErrorDesc.Rows[i].Cells[3].Value = dtSelDes.Rows[i]["Error_Type"].ToString();
                    Grd_ErrorDesc.Rows[i].Cells[4].Value = dtSelDes.Rows[i]["Error_description"].ToString();
                    Grd_ErrorDesc.Rows[i].Cells[5].Value = "View";
                    Grd_ErrorDesc.Rows[i].Cells[6].Value = "Delete";
                }
            }
            else
            {
                Grd_ErrorDesc.DataSource = null;

            }
        }

        private void Grd_ErrorType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grd_ErrorType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 3)
                {
                    int ErrorTypeId = int.Parse(Grd_ErrorType.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string Value = Grd_ErrorType.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value == "View")
                    {
                        Hashtable htselect = new Hashtable();
                        System.Data.DataTable dtselect = new System.Data.DataTable();
                        htselect.Add("@Trans", "SEL_ERR_TYPE");
                        htselect.Add("@Error_Type_Id", ErrorTypeId);
                        dtselect = dataaccess.ExecuteSP("Sp_Errors_Details", htselect);
                        if (dtselect.Rows.Count > 0)
                        {
                            txt_ErrorType.Text = dtselect.Rows[0]["Error_Type"].ToString();
                            btn_ErrorAdd.Text = "Edit";
                            lbl_ErrorTypeId.Text = ErrorTypeId.ToString();
                        }

                    }
                }
                else if (e.ColumnIndex == 4)
                {
                    int ErrorTypeId = int.Parse(Grd_ErrorType.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string Value = Grd_ErrorType.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value == "Delete")
                    {

                        // string ErrorType = Grd_ErrorType.Rows[e.RowIndex].Cells[2].Value.ToString();
                        DialogResult dialog = MessageBox.Show("Do you want to Delete Record", "Delete Confirmation", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            Hashtable htdelete = new Hashtable();
                            System.Data.DataTable dtdelete = new System.Data.DataTable();
                            htdelete.Add("@Trans", "DELETE_Error_Type");
                            htdelete.Add("@Error_Type_Id", ErrorTypeId);
                            htdelete.Add("@Modified_By", userid);

                            var op = MessageBox.Show("Do You Want to Delete the Error Type", "Delete confirmation", MessageBoxButtons.YesNo);
                            if (op == DialogResult.Yes)
                            {
                                Grd_ErrorType.Rows.RemoveAt(e.RowIndex);
                                dtdelete = dataaccess.ExecuteSP("Sp_Errors_Details", htdelete);
                                MessageBox.Show("Error Type Deleted successfully");
                            }
                            else
                            {
                                Gridview_Bind_Error_description();
                            }
                        }
                    }
                }

                Gridview_Bind_Error_Type();
                Gridview_Bind_Error_description();
                dbc.Bind_Error_Type(ddl_ErrorType);

            }
           
        }

        private void Grd_ErrorDesc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 5)
                {

                    int ErrorDesId = int.Parse(Grd_ErrorDesc.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int ErrorTypeId = int.Parse(Grd_ErrorDesc.Rows[e.RowIndex].Cells[1].Value.ToString());
                    string Value = Grd_ErrorDesc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //string NValue = Column9.HeaderText;
                    //string Value= col
                    if (Value == "View")
                    {
                        Hashtable htselect = new Hashtable();
                        System.Data.DataTable dtselect = new System.Data.DataTable();
                        htselect.Add("@Trans", "SELECT_Error_Des");
                        htselect.Add("@Error_description_Id", ErrorDesId);
                        htselect.Add("@Error_Type_Id", ErrorTypeId);
                        dtselect = dataaccess.ExecuteSP("Sp_Errors_Details", htselect);
                        if (dtselect.Rows.Count > 0)
                        {
                            ddl_ErrorType.SelectedValue = dtselect.Rows[0]["Error_Type_Id"].ToString();
                            txt_ErrorDescription.Text = dtselect.Rows[0]["Error_description"].ToString();
                            btn_ErrorDesAdd.Text = "Edit";
                            lbl_ErrorDesc.Text = ErrorDesId.ToString();
                        }

                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    int ErrorDesId = int.Parse(Grd_ErrorDesc.Rows[e.RowIndex].Cells[0].Value.ToString());
                    int ErrorTypeId = int.Parse(Grd_ErrorDesc.Rows[e.RowIndex].Cells[1].Value.ToString());
                    string Value = Grd_ErrorDesc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value == "Delete")
                    {

                        string Grd_Desc = Grd_ErrorDesc.Rows[e.RowIndex].Cells[4].ToString();
                        Hashtable htdelete = new Hashtable();
                        System.Data.DataTable dtdelete = new System.Data.DataTable();
                        htdelete.Add("@Trans", "DELETE_Error_description");
                        htdelete.Add("@Error_description_Id", ErrorDesId);
                        htdelete.Add("@Modified_By", userid);


                        var op = MessageBox.Show("Do You Want to Delete the Error Description", "Delete confirmation", MessageBoxButtons.YesNo);
                        if (op == DialogResult.Yes)
                        {
                            Grd_ErrorDesc.Rows.RemoveAt(e.RowIndex);
                            dtdelete = dataaccess.ExecuteSP("Sp_Errors_Details", htdelete);
                            MessageBox.Show("Error Description Deleted successfully");
                        }
                        else
                        {
                            Gridview_Bind_Error_description();
                        }


                        Gridview_Bind_Error_description();
                        dbc.Bind_Error_Type(ddl_ErrorType);

                    }
                }
            }
        }
            
        

        private void ddl_ErrorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_ErrorType.SelectedIndex != 0)
            {
                if (ddl_ErrorType.SelectedValue != null)
                {
                    txt_ErrorDescription.Select();
                    int ErrorTypeID = int.Parse(ddl_ErrorType.SelectedValue.ToString());
                    Hashtable htselgrd = new Hashtable();
                    System.Data.DataTable dtselgrd = new System.Data.DataTable();
                    htselgrd.Add("@Trans", "SELECT_Error_description_Search_grd");
                    htselgrd.Add("@Error_Type_Id", ErrorTypeID);
                    dtselgrd = dataaccess.ExecuteSP("Sp_Errors_Details", htselgrd);

                    if (dtselgrd.Rows.Count > 0)
                    {
                        Grd_ErrorDesc.Rows.Clear();
                        Grd_ErrorType.DataSource = null;
                        for (int i = 0; i < dtselgrd.Rows.Count; i++)
                        {
                            Grd_ErrorDesc.Rows.Add();
                            Grd_ErrorDesc.Rows[i].Cells[0].Value = dtselgrd.Rows[i]["Error_description_Id"].ToString();
                            Grd_ErrorDesc.Rows[i].Cells[1].Value = dtselgrd.Rows[i]["Error_Type_Id"].ToString();
                            Grd_ErrorDesc.Rows[i].Cells[2].Value = i + 1;
                            Grd_ErrorDesc.Rows[i].Cells[3].Value = dtselgrd.Rows[i]["Error_Type"].ToString();
                            Grd_ErrorDesc.Rows[i].Cells[4].Value = dtselgrd.Rows[i]["Error_description"].ToString();
                            Grd_ErrorDesc.Rows[i].Cells[5].Value = "View";
                            Grd_ErrorDesc.Rows[i].Cells[6].Value = "Delete";
                        }
                    }
                }
            }

        }

        private void btn_Export_Excel_Click(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Tables.Clear();
            Hashtable htgrdexp = new Hashtable();
            System.Data.DataTable dtgrdexp = (System.Data.DataTable)(Grd_ErrorType.DataSource);
            htgrdexp.Add("@Trans", "EXP_TYPE");
            dtSelType = dataaccess.ExecuteSP("Sp_Errors_Details", htgrdexp);
            ds.Tables.Add(dtSelType);
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;

            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            Worksheet ws = (Worksheet)wb.ActiveSheet;

            // Headers. 

            for (int i = 0; i < dtSelType.Columns.Count; i++)
            {
                ws.Cells[1, i + 1] = dtSelType.Columns[i].ColumnName;
            }

            // Content. 

            for (int i = 0; i < dtSelType.Rows.Count; i++)
            {

                for (int j = 0; j < dtSelType.Columns.Count; j++)
                {

                    ws.Cells[i + 2, j + 1] = dtSelType.Rows[i][j].ToString();

                }
                app.Columns.AutoFit();
            }

            app.Visible = true;
        }

       

        private void ImportErrorType(string txtFilename)
        {
            if (txtFilename != string.Empty)
            {
                try
                {
                    String name = "Sheet1";
                    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFilename +";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection conn = new OleDbConnection(constr);
                    OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", conn);
                    conn.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                    System.Data.DataTable data = new System.Data.DataTable();

                    sda.Fill(data);
                    Grd_ErrorType.Rows.Clear();
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (data.Rows[i]["Error_Type"].ToString() != "" || data.Rows[i]["Error_Type"].ToString() != null)
                        {
                            btnEnable();
                           // string ErrorType = data.Rows[i]["Error_Type"].ToString();

                            Hashtable ht = new Hashtable();
                            System.Data.DataTable dt = new System.Data.DataTable();
                            ht.Add("@Trans", "ERROR_TYPE");
                            ht.Add("@Error_Type", data.Rows[i]["Error_Type"].ToString());
                            dt = dataaccess.ExecuteSP("Sp_Errors_Details", ht);
                            if (dt.Rows.Count > 0)
                            {
                                ErrRepeat = 1;
                            }
                            
                            Grd_ErrorType.Rows.Add();
                            //Grd_ErrorType.Rows[i].Cells[0].Value = dtSelect.Rows[i]["Error_Type_Id"].ToString();
                            if (ErrRepeat == 1)
                            {
                                Grd_ErrorType.Rows[i].Cells[1].Value = i + 1;
                                Grd_ErrorType.Rows[i].Cells[2].Value = data.Rows[i]["Error_Type"].ToString();
                                Column3.Visible = false;
                                Column4.Visible = false;
                                Grd_ErrorType.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                            }
                            else if (ErrRepeat == 0)
                            {
                                Grd_ErrorType.Rows[i].Cells[1].Value = i + 1;
                                Grd_ErrorType.Rows[i].Cells[2].Value = data.Rows[i]["Error_Type"].ToString();
                                Column3.Visible = false; 
                                Column4.Visible = false;
                                Grd_ErrorType.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            }
                        }
                        else
                        {
                            string title = "Empty!";
                            MessageBox.Show("Check Empty Cells in Error Type Excel",title);
                            break;

                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btn_Import_ErrorType_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < Grd_ErrorType.Rows.Count; i++)
            {
                if (Grd_ErrorType.Rows[i].DefaultCellStyle.BackColor == Color.White)
                {
                    Hashtable htinsert_Type = new Hashtable();
                    System.Data.DataTable dtinsert_Type = new System.Data.DataTable();
                    htinsert_Type.Add("@Trans", "INSERT_Error_Type");
                    htinsert_Type.Add("@Error_Type", Grd_ErrorType.Rows[i].Cells[2].Value);
                    htinsert_Type.Add("@Inserted_By", userid);
                    htinsert_Type.Add("@Instered_Date", DateTime.Now);
                    dtinsert_Type = dataaccess.ExecuteSP("Sp_Errors_Details", htinsert_Type);
                    InsertErrVal = 1;
                }
                else
                {
                    string title = "Check!";
                    MessageBox.Show("Check the Incorrect Values in Excel");
                    break;
                }
            }
            if (InsertErrVal == 1)
            {
                string title = "Insert";
                MessageBox.Show("*" + i + "*" + " Number of Error Type Inserted Successfully",title);
                btnDisable();
                dbc.Bind_Error_Type(ddl_ErrorType);
            }
        }

        private void ImportErrorDes(string txtFilename)
        {
            if (txtFilename != string.Empty)
            {
                try
                {
                    String name = "Sheet1";
                    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFilename + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection conn = new OleDbConnection(constr);
                    OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", conn);
                    conn.Open();

                    OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                    System.Data.DataTable data = new System.Data.DataTable();

                    sda.Fill(data);
                    Grd_ErrorDesc.Rows.Clear();
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        if (data.Rows[i]["Error_Type"].ToString() != "" || data.Rows[i]["Error_Type"].ToString() != null ||
                            data.Rows[i]["Error_Description"].ToString() != "" || data.Rows[i]["Error_Description"].ToString() != null)
                        {
                           // btnErrorEnable();
                            
                            Hashtable htselect = new Hashtable();
                            System.Data.DataTable dtselect = new System.Data.DataTable();
                            htselect.Add("@Trans", "ERROR_TYPE");
                            htselect.Add("@Error_Type", data.Rows[i]["Error_Type"].ToString());
                            dtselect=dataaccess.ExecuteSP("Sp_Errors_Details",htselect);
                            if (dtselect.Rows.Count > 0)
                            {
                                ErrorTypeID = int.Parse(dtselect.Rows[0]["Error_Type_Id"].ToString());
                            }
                            else
                            {
                                value = 1;
                            }
                            if (ErrorTypeID != 0)
                            {
                                Hashtable ht = new Hashtable();
                                System.Data.DataTable dt = new System.Data.DataTable();
                                ht.Add("@Trans", "CHECK");
                                ht.Add("@Error_Type_Id", ErrorTypeID);
                                ht.Add("@Error_description", data.Rows[i]["Error_Description"].ToString());
                                dt = dataaccess.ExecuteSP("Sp_Errors_Details", ht);
                                if (dt.Rows.Count > 0)
                                {
                                    if (dt.Rows[0]["count"].ToString() == "0")
                                    {
                                        RepeatVal = 0;
                                    }
                                    else
                                    {
                                        RepeatVal = 1;
                                    }
                                }
                            }
                            Grd_ErrorDesc.Rows.Add();
                            Column9.Visible = false;
                            Column10.Visible = false;
                            if (value == 1)
                            {
                                Grd_ErrorDesc.Rows[i].Cells[1].Value = ErrorTypeID;
                                Grd_ErrorDesc.Rows[i].Cells[2].Value = i + 1;
                                Grd_ErrorDesc.Rows[i].Cells[3].Value = data.Rows[i]["Error_Type"].ToString();
                                Grd_ErrorDesc.Rows[i].Cells[4].Value = data.Rows[i]["Error_Description"].ToString();
                               
                                Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                            else if (RepeatVal == 1)
                            {
                                Grd_ErrorDesc.Rows[i].Cells[1].Value = ErrorTypeID;
                                Grd_ErrorDesc.Rows[i].Cells[2].Value = i + 1;
                                Grd_ErrorDesc.Rows[i].Cells[3].Value = data.Rows[i]["Error_Type"].ToString();
                                Grd_ErrorDesc.Rows[i].Cells[4].Value = data.Rows[i]["Error_Description"].ToString();
                                
                                Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                            }
                            else if (value == 0 || RepeatVal == 0)
                            {
                                Grd_ErrorDesc.Rows[i].Cells[1].Value = ErrorTypeID;
                                Grd_ErrorDesc.Rows[i].Cells[2].Value = i + 1;
                                Grd_ErrorDesc.Rows[i].Cells[3].Value = data.Rows[i]["Error_Type"].ToString();
                                Grd_ErrorDesc.Rows[i].Cells[4].Value = data.Rows[i]["Error_Description"].ToString();
                               
                                Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            }
                            
                        }
                        else
                        {
                            string title = "Check!";
                            MessageBox.Show("Check Empty Cells in Error Type Excel",title);
                            break;

                        }
                    }
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnErrorEnable()
        {
            pt.X = 13; pt.Y = 96;
            Grd_ErrorDesc.Location =pt;
            Grd_ErrorDesc.Height = 450;
            pt1.X = 15; pt1.Y = 52;
            lbl_Error_TypeDes.Location = pt1;
            lbl_Error_TypeDes.Enabled = false;
            err.X = 103; err.Y = 52;
            ddl_ErrorType.Location = err;
           // ddl_ErrorType.Enabled = false;
            err1.X = 303; err1.Y = 52;
            lbl_Err_Des.Location = err1;
            lbl_Err_Des.Enabled = false;
            btn.X = 438; btn.Y = 52;
            txt_ErrorDescription.Location = btn;
            txt_ErrorDescription.Enabled = false;
            btn1.X = 611; btn1.Y = 52;
            btn_ErrorDesAdd.Location = btn1;
            btn_ErrorDesAdd.Enabled = false;
            grp.X = 645; grp.Y = 26;
            grp_Import_ErrorDes.Location = grp;
           // grp_Import_ErrorDes.Enabled = false;
            Grd_ErrorType.Visible = false;
            txt_ErrorType.Visible= false;
            btn_ErrorAdd.Visible = false;
            grp_Error_Type.Visible = false;

            
        }
        private void btnErrorDisable()
        {
            pt.X = 12; pt.Y = 362;
            Grd_ErrorDesc.Location = pt;
            Grd_ErrorDesc.Height = 190;
            pt1.X = 15; pt1.Y = 319;
            lbl_Error_TypeDes.Location = pt1;
            err.X = 103; err.Y = 315;
            ddl_ErrorType.Location = err;
            err1.X = 303; err1.Y = 316;
            lbl_Err_Des.Location = err1;
            btn.X = 438; btn.Y = 319;
            txt_ErrorDescription.Location = btn;
            btn1.X = 611; btn1.Y = 314;
            btn_ErrorDesAdd.Location = btn1;
            grp.X = 645; grp.Y = 295;
            grp_Import_ErrorDes.Location = grp;
            Grd_ErrorType.Visible = true;
            Grd_ErrorType.Visible = true;
            txt_ErrorType.Visible = true;
            btn_ErrorAdd.Visible = true;
            grp_Error_Type.Visible = true;
        }
        private void btnDisable()
        {
            Grd_ErrorType.Height = 194;
            txt_ErrorType.Enabled = true;
            btn_ErrorAdd.Enabled = true;
            ddl_ErrorType.Visible = true;
            txt_ErrorDescription.Visible = true;
            grp_Import_ErrorDes.Visible = true;
            Grd_ErrorDesc.Visible = true;
            lbl_Err_Des.Visible = true;
            lbl_Error_TypeDes.Visible = true;
            btn_ErrorDesAdd.Visible = true;
            dbc.Bind_Error_Type(ddl_ErrorType);

            Gridview_Bind_Error_Type();
            Gridview_Bind_Error_description();

        }
        private void btnEnable()
        {
            if (tabPage1.Focus())
            {
                Grd_ErrorType.Height = 450;
                txt_ErrorType.Enabled = false;
                btn_ErrorAdd.Enabled = false;
            }
            else if (tabPage2.Focus())
            {
                ddl_ErrorType.Enabled = false;
                txt_ErrorDescription.Enabled = false;
                grp_Import_ErrorDes.Enabled = false;
                lbl_Err_Des.Enabled = false;
                lbl_Error_TypeDes.Enabled = false;
                btn_ErrorDesAdd.Enabled = false;
            }
        }
        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileup = new OpenFileDialog();
            fileup.Title = "Select Error Type File";
            fileup.InitialDirectory = @"c:\";
           
            fileup.Filter = "Excel Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            fileup.FilterIndex = 1;
            fileup.RestoreDirectory = true;
            var txtFileName = fileup.FileName;
            if (fileup.ShowDialog() == DialogResult.OK)
            {
                txtFileName = fileup.FileName;
                ImportErrorType(txtFileName);
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void btn_UploadErrorDes_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileup = new OpenFileDialog();
            fileup.Title = "Select Error Type File";
            fileup.InitialDirectory = @"c:\";

            fileup.Filter = "Excel Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            fileup.FilterIndex = 1;
            fileup.RestoreDirectory = true;
            var txtFileName = fileup.FileName;
            if (fileup.ShowDialog() == DialogResult.OK)
            {
                txtFileName = fileup.FileName;
                ImportErrorDes(txtFileName);
                System.Windows.Forms.Application.DoEvents();
            }
        }


        private void btn_Import_Error_Des_Click(object sender, EventArgs e)
        {



            int i;
            for (i = 0; i < Grd_ErrorDesc.Rows.Count; i++)
            {
                if (Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor == Color.White)
                {
                    //int ddlErrorType = int.Parse(ddl_ErrorType.SelectedValue.ToString());
                    //  string ErrorDesc = txt_ErrorDescription.Text;

                    Hashtable htinsert_Type = new Hashtable();
                    System.Data.DataTable dtinsert_Type = new System.Data.DataTable();
                    htinsert_Type.Add("@Trans", "INSERT_Error_description");
                    htinsert_Type.Add("@Error_description", Grd_ErrorDesc.Rows[i].Cells[4].Value);
                    htinsert_Type.Add("@Error_Type_Id", Grd_ErrorDesc.Rows[i].Cells[1].Value);
                    htinsert_Type.Add("@Inserted_By", userid);
                    htinsert_Type.Add("@Instered_Date", DateTime.Now);
                    dtinsert_Type = dataaccess.ExecuteSP("Sp_Errors_Details", htinsert_Type);
                    InsertVal = 1;
                }
                else
                {
                    string title = "Check!";
                    MessageBox.Show("Check the Incorrect Values in Excel",title);
                    break;
                   // MessageBox.Show("*" + i + "*" + " Number of Error Description Inserted Successfully");
                }
            }
            if (InsertVal == 1)
            {
                string title = "Insert";
                MessageBox.Show("*" + i + "*" + " Number of Error Description Inserted Successfully",title);
                btnDisable();
                dbc.Bind_Error_Type(ddl_ErrorType);
            }

        }

        private void btn_Export_Error_Des_Click(object sender, EventArgs e)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Tables.Clear();
            Hashtable htgrdexp = new Hashtable();
            System.Data.DataTable dtgrdexp = (System.Data.DataTable)(Grd_ErrorDesc.DataSource);
            htgrdexp.Add("@Trans", "EXP_DESCRIPTION");
            dtSelDes = dataaccess.ExecuteSP("Sp_Errors_Details", htgrdexp);
            ds.Tables.Add(dtSelDes);
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;

            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            Worksheet ws = (Worksheet)wb.ActiveSheet;

            // Headers. 

            for (int i = 0; i < dtSelDes.Columns.Count; i++)
            {
                ws.Cells[1, i + 1] = dtSelDes.Columns[i].ColumnName;
            }

            // Content. 

            for (int i = 0; i < dtSelDes.Rows.Count; i++)
            {

                for (int j = 0; j < dtSelDes.Columns.Count; j++)
                {

                    ws.Cells[i + 2, j + 1] = dtSelDes.Rows[i][j].ToString();

                }
                app.Columns.AutoFit();
            }

            app.Visible = true;
        }

        private void btn_ErrorAdd_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        private void Cancel()
        {
            txt_ErrorType.Text = "";
            btn_ErrorAdd.Text = "Submit";
            lbl_ErrorTypeId.Text = "";
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            ddl_ErrorType.SelectedIndex = 0;
            txt_ErrorDescription.Text = "";
            btn_ErrorDesAdd.Text = "Submit";
            lbl_ErrorDesc.Text = "";
        }

        private void ddl_ErrorType_Click(object sender, EventArgs e)
        {

        }

        private void _1(object sender, EventArgs e)
        {

        }

        private void txt_ErrorType_TextChanged(object sender, EventArgs e)
        {
            DataView dtsearch = new DataView(dtsel);

            dtsearch.RowFilter = " Error_Type like '%" + txt_ErrorType.Text.ToString() + "%'";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = dtsearch.ToTable();
            if (dt.Rows.Count > 0)
            {
                Grd_ErrorType.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Grd_ErrorType.AutoGenerateColumns = false;
                    Grd_ErrorType.Rows.Add();
                    
                    Grd_ErrorType.Rows[i].Cells[0].Value = dtsel.Rows[i]["Error_Type_Id"].ToString();
                    Grd_ErrorType.Rows[i].Cells[1].Value = i + 1;
                    Grd_ErrorType.Rows[i].Cells[2].Value = dt.Rows[i]["Error_Type"].ToString();
                    Grd_ErrorType.Rows[i].Cells[3].Value = "View";
                    Grd_ErrorType.Rows[i].Cells[4].Value = "Delete";

                }
            }
            //Grd_ErrorType.Rows.Clear();

            //Hashtable htsearch = new Hashtable();
            //System.Data.DataTable dtsearch = new System.Data.DataTable();
            //htsearch.Add("@Trans", "SEARCH_BYERROR_TYPE");
            //htsearch.Add("@Error_Type", txt_ErrorType.Text.ToUpper());
            //dtsearch = dataaccess.ExecuteSP("Sp_Errors_Details", htsearch);
            //if (dtsearch.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtsearch.Rows.Count; i++)
            //    {
            //        Grd_ErrorType.Rows.Add();
            //        Grd_ErrorType.Rows[i].Cells[0].Value = dtsearch.Rows[i]["Error_Type_Id"].ToString();
            //        Grd_ErrorType.Rows[i].Cells[1].Value = i + 1;
            //        Grd_ErrorType.Rows[i].Cells[2].Value = dtsearch.Rows[i]["Error_Type"].ToString();
            //        Grd_ErrorType.Rows[i].Cells[3].Value = "View";
            //        Grd_ErrorType.Rows[i].Cells[4].Value = "Delete";
            //    }

            //}
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            txt_ErrorType.Text = "";
            btn_ErrorAdd.Text = "Submit";
            Gridview_Bind_Error_Type();
            lbl_ErrorTypeId.Text = "";
            txt_ErrorType.Enabled = true; 
            btn_ErrorAdd.Enabled = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

  
        private void btn_ErrDesRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            Gridview_Bind_Error_description();
           
        }

        private void btn_NonaddedType_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Grd_ErrorType.Rows.Count; i++)
            {
                if (Grd_ErrorType.Rows[i].DefaultCellStyle.BackColor == Color.Cyan)
                {
                    Grd_ErrorType.Rows.RemoveAt(i);
                    i = i - 1;
                }
                else
                {
                    if (Grd_ErrorType.Rows[i].DefaultCellStyle.BackColor != Color.Red)
                    {
                        Grd_ErrorType.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        Grd_ErrorType.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }

        }

        private void btn_NonAddedDes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Grd_ErrorType.Rows.Count; i++)
            {
                if (Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor == Color.Cyan)
                {
                    Grd_ErrorDesc.Rows.RemoveAt(i);
                    i = i - 1;
                }
                else
                {
                    if (Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor != Color.Red)
                    {
                        Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        Grd_ErrorDesc.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void grp_Error_Type_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Sampleformat_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"c:\OMS_Import\");
            string temppath = @"c:\OMS_Import\Error_Type_Master.xlsx";
            if (!Directory.Exists(temppath))
            {
                File.Copy(@"\\192.168.12.33\OMS-Import_Excels\Error_Type_Master.xlsx", temppath, true);
                Process.Start(temppath);
            }
            else
            {
                Process.Start(temppath);
            }
        }

        private void btn_sample_error_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@"c:\OMS_Import\");
            string temppath = @"c:\OMS_Import\Error_Des_Master.xlsx";
            if (!Directory.Exists(temppath))
            {
                File.Copy(@"\\192.168.12.33\OMS-Import_Excels\Error_Des_Master.xlsx", temppath, true);
                Process.Start(temppath);
            }
            else
            {
                Process.Start(temppath);
            }
        }

        private void btn_Import_Error_Des_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_ErrorType_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != (char)Keys.Back && !(char.IsWhiteSpace(e.KeyChar)))
            //{
            //    e.Handled = true;
            //}

            if ((char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Numbers Not Allowed");
            }
        }

        private void txt_ErrorDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if ((char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                string title = "Validation!";
                MessageBox.Show("Numbers Not Allowed",title);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                txt_ErrorType.Select();
                Gridview_Bind_Error_Type();
                txt_ErrorType.Text = "";


                //txt_Search_Instruction.Select();

                //Bind_Client_Instruction_All();

                //ddl_ClientName.SelectedIndex = 0;
                //txt_Client_Instructions.Text = "";
                //txt_Search_Client_Instruction.Text = "";
             

                //grd_Subclient.Rows.Clear();
                //grd_Vendor_CientInst.Rows.Clear();
            }

            if (tabControl1.SelectedIndex == 1)
            {
                ddl_ErrorType.Select();
                dbc.Bind_Error_Type(ddl_ErrorType);
                txt_ErrorDescription.Text = "";
                Gridview_Bind_Error_description();


                //ddl_ClientName.Select();
                //Bind_Client_Instruction();
                //txt_Search_Instruction.Text = "";
                //txt_Search_Client_Instruction.Text = "";
                //// txt_Search_Client_Instruction.ForeColor = System.Drawing.Color.Transparent;
                //txt_Search_Client_Instruction.Text = "Search...";
            }
        }

    
    }
}
