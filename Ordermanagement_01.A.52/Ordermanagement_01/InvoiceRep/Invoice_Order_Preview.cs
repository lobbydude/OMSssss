using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows;
using System.DirectoryServices;
using System.IO;
using System.Collections;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;


namespace Ordermanagement_01.InvoiceRep
{
    public partial class Invoice_Order_Preview : Form
    {
        ReportDocument rptDoc = new ReportDocument();
        System.Data.Common.DbConnectionStringBuilder builder = new System.Data.Common.DbConnectionStringBuilder();
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        string server = "192.168.12.33";
        string database = "TITLELOGY_NEW_OMS";
        string UserID = "sa";
        string password = "password1$";

        int Order_Id;

        string Client_Order_no;
        int Order_Type;
        int abstarctor_id;
        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        Tables CrTables;

        int Client_Id;
        int External_Order_Id;
        string User_Role;
        public Invoice_Order_Preview(int ORDER_ID,int CLIENT_ID,int EXTERNAL_ORDER_ID,string USER_ROLE)
        {
            InitializeComponent();
            
            Order_Id = ORDER_ID;
            Client_Id = CLIENT_ID;
            External_Order_Id = EXTERNAL_ORDER_ID;
            User_Role = USER_ROLE;
            
        }
        public void Logon_To_Crystal()
        {

            crConnectionInfo.ServerName = server;
            crConnectionInfo.DatabaseName = database;
            crConnectionInfo.UserID = UserID;
            crConnectionInfo.Password = password;
            CrTables = rptDoc.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            
        }
        private void Invoice_Order_Preview_Load(object sender, EventArgs e)
        {
            if (External_Order_Id == 0)
            {
                if (Client_Id == 11)
                {
                    rptDoc = new InvoiceRep.InvReport.Invoice_Report();

                }
                else if (Client_Id == 18 || Client_Id == 19)
                {
                    rptDoc = new InvoiceRep.InvReport.Invoice_Nssclient();


                }
                else if(Client_Id==4)
                {
                    rptDoc = new InvoiceRep.InvReport.Client_RDC_Inovice_Report();

                }
                Logon_To_Crystal();
                rptDoc.SetParameterValue("@Order_ID", Order_Id);
                rptDoc.SetParameterValue("User_Role", User_Role);
                crViewer.ReportSource = rptDoc;
            }
            else if (External_Order_Id > 0)
            {
                // for Titlelogy DB title Vendor Client Invoice Reports
                if (Client_Id == 33)
                {
                    rptDoc = new InvoiceRep.InvReport.InvoiceReport_DbTitle();
                    Logon_To_Crystal();
                    rptDoc.SetParameterValue("@Order_Id", External_Order_Id);
                    rptDoc.SetParameterValue("User_Role", User_Role);
                    crViewer.ReportSource = rptDoc;
                }
            }

        }

        private void btn_New_Invoice_Click(object sender, EventArgs e)
        {
            Export_Report();
        }

        public void Export_Report()
        {

            rptDoc = new InvoiceRep.InvReport.Invoice_Report();

            Logon_To_Crystal();
            rptDoc.SetParameterValue("@Order_ID", Order_Id);
            ExportOptions CrExportOptions;
            string Abstractor_Name = "00001";
            string Source = @"\\192.168.12.33\Invoice-Reports\Invoice.pdf";

            string File_Name = "0001.pdf";
            string dest_path1 = @"\\192.168.12.33\Invoice-Reports\" + Abstractor_Name +  @"\" + File_Name;
            DirectoryEntry de = new DirectoryEntry(dest_path1, "administrator", "password1$");
            de.Username = "administrator";
            de.Password = "password1$";
       
            //Directory.CreateDirectory(@"\\192.168.12.33\Invoice-Reports\" + "00001" + @"\" + "Invoice.pdf");
            Directory.CreateDirectory(@"\\192.168.12.33\Invoice-Reports\" + Abstractor_Name);
            File.Copy(Source, dest_path1, true);
            FileInfo newFile = new FileInfo(@"\\192.168.12.33\Invoice-Reports\00001\Invoice.pdf");

            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();

            PdfFormatOptions CrFormatTypeOptions = new PdfFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = newFile.ToString();
            CrExportOptions = rptDoc.ExportOptions;
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
            rptDoc.Export();





        }

        private void btn_Merge_Click(object sender, EventArgs e)
        {

            Hashtable htsearch = new Hashtable();
            DataTable dtsearch = new DataTable();
            htsearch.Add("@Trans", "GET_SEARCH_PACKAGE_DOCUEMNT_PATH");
            htsearch.Add("@Order_ID",Order_Id);
            dtsearch = dataaccess.ExecuteSP("Sp_Order_Invoice_Entry", htsearch);

            Hashtable htinvoice = new Hashtable();
            DataTable dtinvoice = new DataTable();
            htinvoice.Add("@Trans", "GET_INVOICE_DOCUEMNT_PATH");
            htinvoice.Add("@Order_ID", Order_Id);
            dtinvoice = dataaccess.ExecuteSP("Sp_Order_Invoice_Entry", htinvoice);

            DataSet ds = new DataSet();
            ds.Clear();
            ds.Tables.Add(dtinvoice);
            ds.Merge(dtsearch);

           

         
            List<PdfReader> readerList = new List<PdfReader>();
            foreach (DataTable table in ds.Tables)
            {

              
                foreach (DataRow gvrow1 in table.Rows)
                {


                    string path = gvrow1["Document_Path"].ToString();
                    FileStream fs = new FileStream(path, FileMode.Open);
                    PdfReader pf = new PdfReader(fs);
                    readerList.Add(pf);

                }
            }


                //Define a new output document and its size, type
                Document document = new Document(PageSize.A4, 0, 0, 0, 0);
                //Get instance response output stream to write output file.
                string outPutFilePath = @"\\192.168.12.33\Invoice-Reports\Invoicemerge.pdf";
             
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outPutFilePath, FileMode.Create));


                document.Open();

                foreach (PdfReader reader in readerList)
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        document.Add(iTextSharp.text.Image.GetInstance(page));
                    }
                }
                document.Close();

              
            }
           
        

        public static void MergePdfFiles(string destinationfile, List<string> files)
        {
           
       Document document = null;
       
       try
       {
           List<PdfReader> readers = new List<PdfReader>();
           List<int> pages = new List<int>();

   
           foreach (string file in files)
           {
               readers.Add(new PdfReader(file));
           }
   
           document = new Document(readers[0].GetPageSizeWithRotation(1));
   
           PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationfile, FileMode.Create));
   
           document.Open();
   
           foreach (PdfReader reader in readers)
           {
               pages.Add(reader.NumberOfPages);
               WritePage(reader, document, writer);
           }
       }
       catch (Exception ex)
       {
           MessageBox.Show("An Error occurred");
       }
       finally
       {
           document.Close();
       }
   }
   
   private static void WritePage(PdfReader reader, iTextSharp.text.Document document, PdfWriter writer)
   {
       try
       {
           PdfContentByte cb = writer.DirectContent;
           PdfImportedPage page;
   
           int rotation = 0;
   
           for (int i = 1; i <= reader.NumberOfPages; i++)
           {
               document.SetPageSize(reader.GetPageSizeWithRotation(i));
               document.NewPage();
   
               page = writer.GetImportedPage(reader, i);
   
               rotation = reader.GetPageRotation(i);
   
               if (rotation == 90 || rotation == 270)
               {
                   cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
               }
               else
               {
                   cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
               }
           }
       }
       catch (Exception ex)
       {
           MessageBox.Show("An Error occurred");
       }
   }
    }
}
