using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office;
using System.Runtime.InteropServices;
using System.IO;
using System.DirectoryServices;
using System.Diagnostics;

namespace Ordermanagement_01.Tax
{
    public partial class Tax_Order_Processing : Form
    {
        string Order_Id, Order_TaskId, Tax_Task_Id, Tax_Status_Id, User_Id,Order_Number,User_Role;

        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        Classes.TaxClass taxcls = new Classes.TaxClass();
        Classes.Load_Progres load_Progressbar = new Classes.Load_Progres();
        InfiniteProgressBar.clsProgress clsLoader = new InfiniteProgressBar.clsProgress();
        int DateCustom = 0,Follow_Up_Custom=0;
        string Tax_Content_Path, Tax_Header_Path;
        public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
        string Error_Status;
        int Order_Type_Id;
        public Tax_Order_Processing(string ORDER_ID,string ORDER_TASK_ID,string TAX_TASK_ID,string TAX_STSTAUS_ID,string USER_ID,string ORDER_NUMBER,string USER_ROLE)
        {
            InitializeComponent();
            Order_Id = ORDER_ID;
            Order_TaskId = ORDER_TASK_ID;
            Tax_Task_Id = TAX_TASK_ID;
            Tax_Status_Id = TAX_STSTAUS_ID;
            User_Id = USER_ID;
            Order_Number = ORDER_NUMBER;
            User_Role = USER_ROLE;

            this.Text = "Order Number:"+Order_Number+" - Processing";
            lbl_Header.Text = this.Text;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        protected void Geydview_Bind_Comments()
        {

            Hashtable htComments = new Hashtable();
            System.Data.DataTable dtComments = new System.Data.DataTable();

            htComments.Add("@Trans", "GET_TAX_ORDER_COMMENTS");
            htComments.Add("@Order_Id", Order_Id);

            dtComments = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htComments);
            Grid_Comments.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            Grid_Comments.EnableHeadersVisualStyles = false;
            Grid_Comments.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.WhiteSmoke;
            Grid_Comments.Columns[0].Width = 50;
            Grid_Comments.Columns[2].Width = 400;
            Grid_Comments.Columns[3].Width = 130;
            if (dtComments.Rows.Count > 0)
            {
                //ex2.Visible = true;
                Grid_Comments.Rows.Clear();
                for (int i = 0; i < dtComments.Rows.Count; i++)
                {
                    Grid_Comments.Rows.Add();
                    Grid_Comments.Rows[i].Cells[0].Value = i + 1;
                    Grid_Comments.Rows[i].Cells[1].Value = dtComments.Rows[i]["Tax_Order_Production_Id"].ToString();
                    Grid_Comments.Rows[i].Cells[2].Value = dtComments.Rows[i]["Comment"].ToString();
                    Grid_Comments.Rows[i].Cells[3].Value = dtComments.Rows[i]["User_Name"].ToString();
                }
            }
            else
            {
            }
        }

        private void lbl_APN_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tax_Order_Processing_Load(object sender, EventArgs e)
        {
            this.ResizeRedraw = true;
            taxcls.BindTax_Status(ddl_order_Staus);
          
            Bind_Order_Details();
            Geydview_Bind_Comments();
            DateCustom = 1;
            
            txt_Prdoductiondate.Value = DateTime.Now;
            txt_followup_Date.Value = DateTime.Now;
            this.WindowState = FormWindowState.Maximized;

            if (Tax_Task_Id == "1")
            {

                pnl_Error.Visible = false;

            }
            else
            {
                pnl_Error.Visible = true;
            

            }
        }


       
        private void Bind_Order_Details()
        {

            Hashtable htorderdetail = new Hashtable();
            System.Data.DataTable dtorderdetail = new System.Data.DataTable();
            htorderdetail.Add("@Trans", "GET_ORDER_DETAILS");
            htorderdetail.Add("@Order_Id", Order_Id);
            dtorderdetail = dataaccess.ExecuteSP("Sp_Tax_Orders", htorderdetail);
            if (dtorderdetail.Rows.Count > 0)
            {

                txt_Order_Number.Text = dtorderdetail.Rows[0]["Client_Order_Number"].ToString();
                txt_Order_Type.Text = dtorderdetail.Rows[0]["Order_Type"].ToString();

                txt_Barrower_Name.Text = dtorderdetail.Rows[0]["Borrower_Name"].ToString();
                txt_Property_Address.Text = dtorderdetail.Rows[0]["Address"].ToString();
                txt_APN.Text = dtorderdetail.Rows[0]["APN"].ToString();
                txt_State.Text = dtorderdetail.Rows[0]["State"].ToString();
                txt_ReceivedDate.Text = dtorderdetail.Rows[0]["Assigned_Date"].ToString();
                txt_County.Text = dtorderdetail.Rows[0]["County"].ToString();
                txt_Notes.Text = dtorderdetail.Rows[0]["Notes"].ToString();

                Order_Type_Id = int.Parse(dtorderdetail.Rows[0]["Order_Type_ID"].ToString());
            }
 

            
        }

        private void txt_Prdoductiondate_ValueChanged(object sender, EventArgs e)
        {
            if (DateCustom != 0)
            {
                txt_Prdoductiondate.CustomFormat = "MM/dd/yyyy";
            }
            DateCustom = 1;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            load_Progressbar.Start_progres();
           
            if (Validate() != false && validateStatus()!=false)
            {
              
                Hashtable htupdateTaxTask = new Hashtable();
                System.Data.DataTable dtupdateTask = new System.Data.DataTable();
                Hashtable htupdateTaxStatus = new Hashtable();
                System.Data.DataTable dtupdateTaxStatus = new System.Data.DataTable();


                   Hashtable htupdateTaxfollowupdate = new Hashtable();
                System.Data.DataTable dtupdateTaxfollowupdate = new System.Data.DataTable();

                Hashtable htupdateOrderTaxStatus = new Hashtable();
                System.Data.DataTable dtupdateOrderTaxStatus = new System.Data.DataTable();

                Hashtable htorderassign = new Hashtable();
                System.Data.DataTable dtorderassign = new System.Data.DataTable();
                Hashtable htinsert = new Hashtable();
                System.Data.DataTable dtinert = new System.Data.DataTable();
             
              int  Tax_StatusId = int.Parse(ddl_order_Staus.SelectedValue.ToString());
                if(Tax_Task_Id=="1")
                {

                    //Tax Order Qc Completes
                    if (Tax_StatusId == 1 && Validate_Tax_Document_Upload() != false && ValidateTax_Violation_Entry()!=false)
                    {
                            clsLoader.startProgress();
                       
                            htupdateTaxTask.Add("@Trans", "UPDATE_TAX_TASK");
                            htupdateTaxTask.Add("@Tax_Task", 2);
                            htupdateTaxTask.Add("@Modified_By", User_Id);
                            htupdateTaxTask.Add("@Order_Id", Order_Id);
                            dtupdateTask = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxTask);


                            htupdateTaxStatus.Add("@Trans", "UPDATE_TAX_STATUS");
                            htupdateTaxStatus.Add("@Tax_Status",6);
                            htupdateTaxStatus.Add("@Modified_By", User_Id);
                            htupdateTaxStatus.Add("@Order_Id", Order_Id);
                            dtupdateTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxStatus);


                            htupdateOrderTaxStatus.Add("@Trans", "UPDATE_ORDER_TAX_STATUS");
                            htupdateOrderTaxStatus.Add("@Order_Status", 14);
                            htupdateOrderTaxStatus.Add("@Modified_By", User_Id);
                            htupdateOrderTaxStatus.Add("@Order_Id", Order_Id);
                            dtupdateOrderTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateOrderTaxStatus);


                        //Updaet Tbl_Order_Assign

                            htorderassign.Add("@Trans", "DELET_BY_ORDER");
                            htorderassign.Add("@Order_Id", Order_Id);
                            dtorderassign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htorderassign);

                            htinsert.Add("@Trans", "INSERT");
                            htinsert.Add("@Order_Id", Order_Id);
                            htinsert.Add("@Tax_Task_Id", Tax_Task_Id);
                            htinsert.Add("@Tax_Status_Id", int.Parse(ddl_order_Staus.SelectedValue.ToString()));
                            htinsert.Add("@User_Id", User_Id);
                            htinsert.Add("@Order_Production_Date", txt_Prdoductiondate.Text);
                            htinsert.Add("@Comments", txt_Comments.Text);
                            htinsert.Add("@Inserted_By", User_Id);
                            htinsert.Add("@Status", "True");
                            dtinert = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htinsert);

                            clsLoader.stopProgress();
                        MessageBox.Show("Order Submitted Sucessfully");
                        this.Close();
                        
                    }

                    else if(Tax_StatusId!=1 && validateStatus()!=false )

                    {


                        clsLoader.startProgress();
                        htupdateTaxTask.Add("@Trans", "UPDATE_TAX_TASK");
                        htupdateTaxTask.Add("@Tax_Task", 1);
                        htupdateTaxTask.Add("@Modified_By", User_Id);
                        htupdateTaxTask.Add("@Order_Id", Order_Id);
                        dtupdateTask = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxTask);


                        htupdateTaxStatus.Add("@Trans", "UPDATE_TAX_STATUS");
                        htupdateTaxStatus.Add("@Tax_Status", Tax_StatusId);
                        htupdateTaxStatus.Add("@Modified_By", User_Id);
                        htupdateTaxStatus.Add("@Order_Id", Order_Id);
                        dtupdateTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxStatus);


                        htupdateTaxfollowupdate.Add("@Trans", "UPDATE_TAX_FOLLOWUP_DATE");
                        htupdateTaxfollowupdate.Add("@Order_Id", Order_Id);
                        htupdateTaxfollowupdate.Add("@Followup_Date", txt_followup_Date.Text);
                        dtupdateTaxfollowupdate = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxfollowupdate);


                        htupdateOrderTaxStatus.Add("@Trans", "UPDATE_ORDER_TAX_STATUS");
                        htupdateOrderTaxStatus.Add("@Order_Status", 17);
                        htupdateOrderTaxStatus.Add("@Modified_By", User_Id);
                        htupdateOrderTaxStatus.Add("@Order_Id", Order_Id);
                        dtupdateOrderTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateOrderTaxStatus);


                        htinsert.Add("@Trans", "INSERT");
                        htinsert.Add("@Order_Id", Order_Id);
                        htinsert.Add("@Tax_Task_Id", Tax_Task_Id);
                        htinsert.Add("@Tax_Status_Id", int.Parse(ddl_order_Staus.SelectedValue.ToString()));
                        htinsert.Add("@User_Id", User_Id);
                        htinsert.Add("@Order_Production_Date", txt_Prdoductiondate.Text);
                        htinsert.Add("@Comments", txt_Comments.Text);
                        htinsert.Add("@Inserted_By", User_Id);
                        htinsert.Add("@Status", "True");
                        dtinert = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htinsert);
                        clsLoader.stopProgress();
                        MessageBox.Show("Order Submitted Sucessfully");
                        this.Close();

                    }

              
                }

                else if (Tax_Task_Id == "2")
                {

                    if (Tax_StatusId == 1 && Validate_Tax_Document_Upload_In_Qc() != false && Validate_Error_Status() != false && ValidateTax_Violation_Entry() != false)
                    {

                        // This is for External Orders 
                        if (Order_TaskId == "21" && Order_Type_Id!=110)
                        {




                            Hashtable ht = new Hashtable();
                            System.Data.DataTable dt = new System.Data.DataTable();
                            ht.Add("@Trans", "GET_TAX_DOCUMENT_UPLOADED");
                            ht.Add("@Order_Id", Order_Id);
                            dt = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", ht);


                            if (dt.Rows.Count > 0)
                            {



                                Tax_Content_Path = dt.Rows[0]["Document_Path"].ToString();

                                string Extension = Path.GetExtension(Tax_Content_Path);
                                if (Extension == ".doc" || Extension == ".docx")
                                {

                                    clsLoader.startProgress();

                                    Tax_Header_Path = @"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\Tax_Header_Document.docx";

                                    Object oMissing = System.Reflection.Missing.Value;

                                    var wordApp = new Word.Application();

                                    var ContentDoc = wordApp.Documents.Open(@Tax_Content_Path);


                                    // you can do the line above by passing ReadOnly=False like this as well
                                    //var originalDoc = wordApp.Documents.Open(@oTemplatePath, oMissing, false);


                                    ContentDoc.ActiveWindow.Selection.WholeStory();


                                    ContentDoc.ActiveWindow.Selection.Copy();
                                    //copy the sourcefile to Destination to  Pate
                                    ContentDoc.Close();


                                    //Copy File into Order file 




                                    string Tax_Header_Source = @"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\Tax_Header_Document.docx";

                                    string File_Name = "Tax_Header_" + Order_Number + ".docx";
                                    string dest_path1 = @"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\" + Order_Id + @"\" + File_Name;
                                    string Tax_Pdf_Source = @"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\Taxcertpdf.pdf";
                                    string current_time = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
                                    string Pdf_File_Name = "Tax_Certifcate_" + Order_Number+"-"+current_time +".pdf";
                                    string Pdf_File_Path = @"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\" + Order_Id + @"\" + Pdf_File_Name;
                                    DirectoryEntry de = new DirectoryEntry(dest_path1, "administrator", "password1$");
                                    de.Username = "administrator";
                                    de.Password = "password1$";
                                    Directory.CreateDirectory(@"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\" + Order_Id);

                                    File.Copy(Tax_Header_Source, dest_path1, true);





                                    //Need to Paste the Contents to Destination path

                                    var Destinationdoc = wordApp.Documents.Open(@dest_path1);


                                    Destinationdoc.ActiveWindow.Selection.WholeStory();



                                    Destinationdoc.ActiveWindow.Selection.PasteAndFormat(WdRecoveryType.wdUseDestinationStylesRecovery);



                                    Destinationdoc.SaveAs(@dest_path1);
                                    Destinationdoc.Save();
                                    Destinationdoc.Close();



                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(ContentDoc);

                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Destinationdoc);
                                    GC.Collect();

                                    File.Copy(Tax_Pdf_Source, Pdf_File_Path, true);

                                    Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                                    wordDocument = appWord.Documents.Open(@dest_path1);
                                    wordDocument.ExportAsFixedFormat(@Pdf_File_Path, WdExportFormat.wdExportFormatPDF);
                                    wordDocument.Close();

                                    string Pdf_Extension = Path.GetExtension(@Pdf_File_Path);





                                    Hashtable htorderkb = new Hashtable();
                                    System.Data.DataTable dtorderkb = new System.Data.DataTable();
                                    htorderkb.Add("@Trans", "INSERT");
                                    htorderkb.Add("@Order_Id", Order_Id);
                                    htorderkb.Add("@Instuction", "Qc Final Tax Certificate");
                                    htorderkb.Add("@Document_Path", Pdf_File_Path);
                                    htorderkb.Add("@File_Extension", Pdf_Extension);
                                    htorderkb.Add("@Tax_Task",2);
                                    htorderkb.Add("@Inserted_By", User_Id);
                                    htorderkb.Add("@status", "True");
                                    dtorderkb = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htorderkb);


                                    Hashtable htemailstatus = new Hashtable();
                                    System.Data.DataTable dtemailstatus = new System.Data.DataTable();

                                    htemailstatus.Add("@Trans", "UPDATE_TAX_EMAIL_STATUS");
                                    htemailstatus.Add("@Order_Id", Order_Id);
                                    dtemailstatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htemailstatus);



                                    if (chk_Yes.Checked == true)
                                    {
                                    
                                        Error_Status="True";
                                    }
                                    else if(chk_No.Checked==true)
                                    {
                                      Error_Status="false";

                                    }

                                    Hashtable hterror = new Hashtable();
                                    System.Data.DataTable dterror = new System.Data.DataTable();
                                    hterror.Add("@Trans", "INSERT");
                                    hterror.Add("@Order_Id", Order_Id);
                                    hterror.Add("@Tax_Task",2);
                                    hterror.Add("@User_Id",User_Id);
                                    hterror.Add("@Error_Status", Error_Status);
                                    hterror.Add("@Error_Note",txt_Error_Description.Text.ToString());
                                    dterror = dataaccess.ExecuteSP("Sp_Tax_Order_Error_Details", hterror);







                                    htupdateTaxStatus.Add("@Trans", "UPDATE_TAX_STATUS");
                                    htupdateTaxStatus.Add("@Tax_Status", Tax_StatusId);
                                    htupdateTaxStatus.Add("@Modified_By", User_Id);
                                    htupdateTaxStatus.Add("@Order_Id", Order_Id);
                                    dtupdateTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxStatus);



                                    htupdateOrderTaxStatus.Add("@Trans", "UPDATE_ORDER_TAX_STATUS");
                                    htupdateOrderTaxStatus.Add("@Order_Status", 3);
                                    htupdateOrderTaxStatus.Add("@Modified_By", User_Id);
                                    htupdateOrderTaxStatus.Add("@Order_Id", Order_Id);
                                    dtupdateOrderTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateOrderTaxStatus);
                                    //Updaet Tbl_Order_Assign

                                    htorderassign.Add("@Trans", "DELET_BY_ORDER");
                                    htorderassign.Add("@Order_Id", Order_Id);
                                    dtorderassign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htorderassign);

                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Id", Order_Id);
                                    htinsert.Add("@Tax_Task_Id", Tax_Task_Id);
                                    htinsert.Add("@Tax_Status_Id", int.Parse(ddl_order_Staus.SelectedValue.ToString()));
                                    htinsert.Add("@User_Id", User_Id);
                                    htinsert.Add("@Order_Production_Date", txt_Prdoductiondate.Text);
                                    htinsert.Add("@Comments", txt_Comments.Text);
                                    htinsert.Add("@Inserted_By", User_Id);
                                    htinsert.Add("@Status", "True");
                                    dtinert = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htinsert);


                                    clsLoader.stopProgress();
                                    MessageBox.Show("Order Submitted Sucessfully");

                                    this.Close();

                                }
                                else
                                {

                               
                                    MessageBox.Show("Please Upload Word Format Tax Certificate");
                                }
                            }
                            else
                            {

                                MessageBox.Show("Tax Document is not Uploaded please check it");
                            }
                        }
                        else if (Order_TaskId == "21" && Order_Type_Id == 110)
                        {


                            if (chk_Yes.Checked == true)
                            {

                                Error_Status = "True";
                            }
                            else if (chk_No.Checked == true)
                            {
                                Error_Status = "false";

                            }

                            Hashtable hterror = new Hashtable();
                            System.Data.DataTable dterror = new System.Data.DataTable();
                            hterror.Add("@Trans", "INSERT");
                            hterror.Add("@Order_Id", Order_Id);
                            hterror.Add("@Tax_Task", 2);
                            hterror.Add("@User_Id", User_Id);
                            hterror.Add("@Error_Status", Error_Status);
                            hterror.Add("@Error_Note", txt_Error_Description.Text.ToString());
                            dterror = dataaccess.ExecuteSP("Sp_Tax_Order_Error_Details", hterror);







                            htupdateTaxStatus.Add("@Trans", "UPDATE_TAX_STATUS");
                            htupdateTaxStatus.Add("@Tax_Status", Tax_StatusId);
                            htupdateTaxStatus.Add("@Modified_By", User_Id);
                            htupdateTaxStatus.Add("@Order_Id", Order_Id);
                            dtupdateTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxStatus);



                            htupdateOrderTaxStatus.Add("@Trans", "UPDATE_ORDER_TAX_STATUS");
                            htupdateOrderTaxStatus.Add("@Order_Status", 3);
                            htupdateOrderTaxStatus.Add("@Modified_By", User_Id);
                            htupdateOrderTaxStatus.Add("@Order_Id", Order_Id);
                            dtupdateOrderTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateOrderTaxStatus);
                            //Updaet Tbl_Order_Assign

                            htorderassign.Add("@Trans", "DELET_BY_ORDER");
                            htorderassign.Add("@Order_Id", Order_Id);
                            dtorderassign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htorderassign);

                            htinsert.Add("@Trans", "INSERT");
                            htinsert.Add("@Order_Id", Order_Id);
                            htinsert.Add("@Tax_Task_Id", Tax_Task_Id);
                            htinsert.Add("@Tax_Status_Id", int.Parse(ddl_order_Staus.SelectedValue.ToString()));
                            htinsert.Add("@User_Id", User_Id);
                            htinsert.Add("@Order_Production_Date", txt_Prdoductiondate.Text);
                            htinsert.Add("@Comments", txt_Comments.Text);
                            htinsert.Add("@Inserted_By", User_Id);
                            htinsert.Add("@Status", "True");
                            dtinert = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htinsert);


                            clsLoader.stopProgress();
                            MessageBox.Show("Order Submitted Sucessfully");

                            }
                        else
                        {

                            //This is for internal Order Assign

                            clsLoader.startProgress();

                            //Update Tbl_Order Search Tax Status once Qc Completes

                            Hashtable htorder_taxStatus = new Hashtable();
                            System.Data.DataTable dtorder_taxstatus = new System.Data.DataTable();

                            htorder_taxStatus.Add("@Trans", "UPDATE_ORDER_TAX_SERACH_REQUEST_STATUS");
                            htorder_taxStatus.Add("@Order_Id",Order_Id);
                            dtorder_taxstatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htorder_taxStatus);


                            //Update tbl_orders Search_request_Internal_Status



                            Hashtable htorder_taxinternalStatus = new Hashtable();
                            System.Data.DataTable dtorder_taxinternalstatus = new System.Data.DataTable();

                            htorder_taxinternalStatus.Add("@Trans", "UPDATE_INTERNAL_TAX_STATUS");
                            htorder_taxinternalStatus.Add("@Order_Id", Order_Id);
                            htorder_taxinternalStatus.Add("@Search_Tax_Req_Inhouse_Status", 8);
                            dtorder_taxinternalstatus = dataaccess.ExecuteSP("Sp_Order", htorder_taxinternalStatus);



                            //Tax Order Status
                    

                            htupdateTaxStatus.Add("@Trans", "UPDATE_TAX_STATUS");
                            htupdateTaxStatus.Add("@Tax_Status", Tax_StatusId);
                            htupdateTaxStatus.Add("@Modified_By", User_Id);
                            htupdateTaxStatus.Add("@Order_Id", Order_Id);
                            dtupdateTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxStatus);






                            htupdateOrderTaxStatus.Add("@Trans", "UPDATE_ORDER_TAX_STATUS");
                            htupdateOrderTaxStatus.Add("@Order_Status", 3);
                            htupdateOrderTaxStatus.Add("@Modified_By", User_Id);
                            htupdateOrderTaxStatus.Add("@Order_Id", Order_Id);
                            dtupdateOrderTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateOrderTaxStatus);
                            //Updaet Tbl_Order_Assign

                            htorderassign.Add("@Trans", "DELET_BY_ORDER");
                            htorderassign.Add("@Order_Id", Order_Id);
                            dtorderassign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htorderassign);

                            htinsert.Add("@Trans", "INSERT");
                            htinsert.Add("@Order_Id", Order_Id);
                            htinsert.Add("@Tax_Task_Id", Tax_Task_Id);
                            htinsert.Add("@Tax_Status_Id", int.Parse(ddl_order_Staus.SelectedValue.ToString()));
                            htinsert.Add("@User_Id", User_Id);
                            htinsert.Add("@Order_Production_Date", txt_Prdoductiondate.Text);
                            htinsert.Add("@Comments", txt_Comments.Text);
                            htinsert.Add("@Inserted_By", User_Id);
                            htinsert.Add("@Status", "True");
                            dtinert = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htinsert);
                            clsLoader.stopProgress();

                            MessageBox.Show("Order Submitted Sucessfully");
                            this.Close();
                        }


                    }
                      else if(Tax_StatusId!=1 && validateStatus()!=false)

                    {
                        clsLoader.startProgress();

                        htupdateTaxStatus.Add("@Trans", "UPDATE_TAX_STATUS");
                        htupdateTaxStatus.Add("@Tax_Status", Tax_StatusId);
                        htupdateTaxStatus.Add("@Modified_By", User_Id);
                        htupdateTaxStatus.Add("@Order_Id", Order_Id);
                        dtupdateTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateTaxStatus);


                        htupdateOrderTaxStatus.Add("@Trans", "UPDATE_ORDER_TAX_STATUS");
                        htupdateOrderTaxStatus.Add("@Order_Status", 17);
                        htupdateOrderTaxStatus.Add("@Modified_By", User_Id);
                        htupdateOrderTaxStatus.Add("@Order_Id", Order_Id);
                        dtupdateOrderTaxStatus = dataaccess.ExecuteSP("Sp_Tax_Order_Status", htupdateOrderTaxStatus);

                        htinsert.Add("@Trans", "INSERT");
                        htinsert.Add("@Order_Id", Order_Id);
                        htinsert.Add("@Tax_Task_Id", Tax_Task_Id);
                        htinsert.Add("@Tax_Status_Id", int.Parse(ddl_order_Staus.SelectedValue.ToString()));
                        htinsert.Add("@User_Id", User_Id);
                        htinsert.Add("@Order_Production_Date", txt_Prdoductiondate.Text);
                        htinsert.Add("@Comments", txt_Comments.Text);
                        htinsert.Add("@Inserted_By", User_Id);
                        htinsert.Add("@Status", "True");
                        dtinert = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htinsert);
                        clsLoader.stopProgress();
                        MessageBox.Show("Order Submitted Sucessfully");
                        this.Close();

                    }

                }

                }
            }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool Validate_Error_Status()
        {


            if (chk_Yes.Checked == false && chk_No.Checked == false)
            {

                MessageBox.Show("Please Check Error Status");
                chk_No.Focus();
                return false;
            }
            if ( chk_Yes.Checked==true && txt_Error_Description.Text == "")
            {

                MessageBox.Show("Please Enter Error Note");
                txt_Error_Description.Focus();
                return false;
            }
            return true;



        }

        public void Insert_Order_Commnets()
        {

            if (txt_Comments.Text != "")
            {
                Hashtable htinsert = new Hashtable();
                System.Data.DataTable dtinert = new System.Data.DataTable();
                htinsert.Add("@Trans", "INSERT");
                htinsert.Add("@Order_Id", Order_Id);
                htinsert.Add("@Tax_Task", Tax_Task_Id);
                htinsert.Add("@Tax_Status", int.Parse(ddl_order_Staus.SelectedValue.ToString()));
                htinsert.Add("@User_Id", User_Id);
                htinsert.Add("@Order_Production_Date", txt_Prdoductiondate.Text);
                htinsert.Add("@Comments", txt_Comments.Text);
                htinsert.Add("@Inserted_By", User_Id);
                htinsert.Add("@Status", "True");
                dtinert = dataaccess.ExecuteSP("Sp_Tax_Order_Production_Date", htinsert);


            }


        }
        
        private bool Validate()
        {

            if (txt_Prdoductiondate.Text == "")
            {

                MessageBox.Show("Enter Production Date");
                txt_Prdoductiondate.Focus();
                return false;
            }
            if (ddl_order_Staus.SelectedIndex <= 0)
            {

                MessageBox.Show("Select Order Status");
                ddl_order_Staus.Focus();
                return false;

            }

            if (ddl_order_Staus.SelectedIndex > 0 && ddl_order_Staus.SelectedValue.ToString() == "2" && txt_followup_Date.Text=="")
            {

                MessageBox.Show("Enter Followup Date");
                txt_followup_Date.Focus();
                return false;
            }

            return true;
        }

        private bool validateStatus()
        {

            int Status = int.Parse(ddl_order_Staus.SelectedValue.ToString());
            if (Status!=1 && txt_Comments.Text=="")
            {
                MessageBox.Show("Please Enter Comments");
                txt_Comments.Focus();
                return false;


            }
            else
            {

                return true;
            }
        
        
        
        }

        private bool Validate_Tax_Document_Upload()
        {

            if (Tax_Task_Id == "1" && Order_Type_Id!=110)
            {
            Hashtable htcheck = new Hashtable();
            System.Data.DataTable dtcheck = new System.Data.DataTable();
            htcheck.Add("@Trans", "CHECK_TAX_DOCUMENT_UPLOADED");
            htcheck.Add("@Order_Id", Order_Id);
            htcheck.Add("@User_id",User_Id);
            dtcheck = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htcheck);

            int check = 0;
            if (dtcheck.Rows.Count > 0)
            {
                check = int.Parse(dtcheck.Rows[0]["count"].ToString());
            

            }
            else
            {
                check=0;
            }

            if(check==0)
            {
            
                MessageBox.Show("Upload Tax Certificate");
                Tax_Document_Upload txdoc = new Tax_Document_Upload(Order_Id, User_Id, txt_Order_Number.Text, Tax_Task_Id,User_Role);
            txdoc.Show();
                return false;
            }
            else
            {
            
                return true;
            }
            }
            else
            {
            
                return true;
            }
           
        }

            private bool Validate_Tax_Document_Upload_In_Qc()
        {

            if(Tax_Task_Id=="2")
            {
            Hashtable htcheck = new Hashtable();
            System.Data.DataTable dtcheck = new System.Data.DataTable();
            htcheck.Add("@Trans", "CHECK_DOCUMENT_IN_QC_STAGE");
            htcheck.Add("@Order_Id", Order_Id);
            dtcheck = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htcheck);

            int check = 0;
            if (dtcheck.Rows.Count > 0)
            {
                check = int.Parse(dtcheck.Rows[0]["count"].ToString());
            

            }
            else
            {
                check=0;
            }

            if (check == 0 && Order_Type_Id != 110)
            {
            
                MessageBox.Show("Tax Document is not Uploaded Check it");
                Tax_Document_Upload txdoc = new Tax_Document_Upload(Order_Id, User_Id, txt_Order_Number.Text, Tax_Task_Id,User_Role);
            txdoc.Show();
                return false;
            }
            else
            {
            
                return true;
            }
            }
            else
            {
            
                return true;
            }
           
        }
            private bool ValidateTax_Violation_Entry()
            {
                if (Order_Type_Id == 110)
                {
                    int Check = 0;
                    Hashtable htcheck = new Hashtable();
                    System.Data.DataTable dtcheck = new System.Data.DataTable();
                    htcheck.Add("@Trans", "CHECK");
                    htcheck.Add("@Order_Id", Order_Id);
                    dtcheck = dataaccess.ExecuteSP("Sp_Tax_Violation_Entry", htcheck);

                    if (dtcheck.Rows.Count > 0)
                    {

                        Check = int.Parse(dtcheck.Rows[0]["count"].ToString());
                    }
                    else
                    {

                        Check = 0;
                    }
                    if (Check == 0)
                    {

                        MessageBox.Show("Enter Tax Violation Form");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;

                }
            }

        private void btn_Upload_Click(object sender, EventArgs e)
        {
            Tax_Document_Upload txdoc = new Tax_Document_Upload(Order_Id, User_Id, txt_Order_Number.Text, Tax_Task_Id, User_Role);
            txdoc.Show();

        }

     

        private void chk_Yes_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Yes.Checked == true)
            {

                chk_No.Checked = false;
            }
        }

        private void chk_No_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_No.Checked == true)
            {

                chk_Yes.Checked = false;
            }
        }

        private void btn_Tax_ViolationEntry_Click(object sender, EventArgs e)
        {
            Ordermanagement_01.Tax.Tax_Order_Violation_Entry tax_v = new Tax_Order_Violation_Entry(Order_Id, Order_TaskId, Tax_Task_Id, Tax_Status_Id, User_Id, Order_Number, User_Role);
            tax_v.Show();
        }

        private void ddl_order_Staus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_order_Staus.SelectedIndex > 0)
            {

                if (ddl_order_Staus.SelectedValue.ToString() == "2")
                {

                    txt_followup_Date.Enabled = true;
                    MessageBox.Show("Enter Followup Date");

                }
            }
        }

        private void txt_followup_Date_ValueChanged(object sender, EventArgs e)
        {
            if (Follow_Up_Custom != 0)
            {
                txt_followup_Date.CustomFormat = "MM/dd/yyyy";
            }
            Follow_Up_Custom = 1;
        }

      
       

      
     
    }
}
