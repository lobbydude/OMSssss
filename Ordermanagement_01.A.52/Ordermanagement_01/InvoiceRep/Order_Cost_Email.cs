using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows;
using System.Collections;
using System.IO;
using RTF;
using System.Net.Mime;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.DirectoryServices;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

namespace Ordermanagement_01.InvoiceRep
{
    public partial class Order_Cost_Email : Form
    {
        
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
      
        int Order_Id;
        string[] FName;
        string Document_Name;
        string Client_Order_no;
        int Order_Type;
        int abstarctor_id, User_Id;
        string Path1;
        string Attachment_Name;
        string Directory_Path;
       
        string Order_Number;
     
        string Email, Alternative_Email;
        int Order_Cost_Id;
        string View_File_Path;
        string Invoice_Status;
        DialogResult dialogResult;
        string Forms;
        string Package = "";
        string P1, P2;
        int Index;
        int Sub_Process_ID;
        string Order_Costs;
        public Order_Cost_Email(string ORDER_NUMBER, int USER_ID, int ORDER_ID, int ORDER_COST_ID, int SUB_PROCESS_ID,string ORDERCOST)
        {
            InitializeComponent();
            Order_Id = ORDER_ID;
            User_Id = USER_ID;

        
            Order_Number = ORDER_NUMBER.ToString();
            Order_Cost_Id = ORDER_COST_ID;
            Sub_Process_ID = SUB_PROCESS_ID;
            Order_Costs = ORDERCOST;
            Send_Html_Email_Body();
        }

        public void Send_Html_Email_Body()
        {
            using (MailMessage mm = new MailMessage())
            {
                try
                {

                   

                

                    mm.IsBodyHtml = true;

                  

                    string body = this.PopulateBody();
                    SendHtmlFormattedEmail("netco@drnds.com", "Sample", body);

                    this.Close();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    return;

                }
            }

        }

        public string PopulateBody()
        {
            string body = string.Empty;




            Hashtable htorder = new Hashtable();
            DataTable dtorder = new DataTable();
            htorder.Add("@Trans", "GET_ORDER_COST_DETAILS_FOR_EMAIL");
            htorder.Add("@Order_ID", Order_Id);
            dtorder = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htorder);
            if (dtorder.Rows.Count > 0)
            {


            }

            string Title = dtorder.Rows[0]["Order_Type"].ToString();
            string Comments = dtorder.Rows[0]["Comments"].ToString();

            Directory_Path = @"\\192.168.12.33\Oms Email Templates\order_Cost.htm";

            using (StreamReader reader = new StreamReader(Directory_Path))
            {

                body = reader.ReadToEnd();
            }



            body = body.Replace("{Text}", "The fee for this order is $"+Order_Costs.ToString()+"");

            if (Comments != "")
            {
                body = body.Replace("{Comments}", "Comments:" + Comments.ToString() + "");
            }
            
            return body;
        }


        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("netco@drnds.com");

                Hashtable htsearch = new Hashtable();
                DataTable dtsearch = new DataTable();
                htsearch.Add("@Trans", "GET_SEARCH_PACKAGE_DOCUEMNT_PATH");
                htsearch.Add("@Order_ID", Order_Id);
                dtsearch = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htsearch);


                if (dtsearch.Rows.Count > 0)
                {
                    FName = dtsearch.Rows[0]["Document_Name"].ToString().Split('\\');
                    string Source_Path = dtsearch.Rows[0]["Document_Path"].ToString();
                    Path1 = Source_Path;
                    var maxsize = 20 * 1024 * 1000;
                    var fileName = Path1;
                    FileInfo fi = new FileInfo(fileName);
                    var size = fi.Length;
                    if (size <= maxsize)
                    {

                        Attachment_Name = Order_Number.ToString() + ".pdf";



                        MemoryStream ms = new MemoryStream(File.ReadAllBytes(Path1));



                        mailMessage.Attachments.Add(new System.Net.Mail.Attachment(ms, Attachment_Name.ToString()));

                        Hashtable htdate = new Hashtable();
                        System.Data.DataTable dtdate = new System.Data.DataTable();
                        htdate.Add("@Trans", "SELECT_CLIENT_EMAIL");
                        htdate.Add("@Order_ID", Order_Id);
                        dtdate = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htdate);
                        if (dtdate.Rows.Count > 0)
                        {

                            Email = "Avilable";
                            Alternative_Email = "Avilable";


                        }
                        else
                        {

                            Email = "";
                            Alternative_Email = "";
                        }


                        if (Email != "")
                        {


                            for (int j = 0; j < dtdate.Rows.Count; j++)
                            {
                                mailMessage.To.Add(dtdate.Rows[j]["Email_ID"].ToString());

                            }


                            mailMessage.Bcc.Add("jegadeesh@drnds.com");
                         

                            Hashtable htorder = new Hashtable();
                            DataTable dtorder = new DataTable();
                            htorder.Add("@Trans", "GET_ORDER_COST_DETAILS_FOR_EMAIL");
                            htorder.Add("@Order_ID", Order_Id);
                            dtorder = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htorder);
                            if (dtorder.Rows.Count > 0)
                            {


                            }

                            string Title = dtorder.Rows[0]["Order_Type"].ToString();
                            string Comments = dtorder.Rows[0]["Comments"].ToString();
                            string Subject = " " + Order_Number + "  -  " + Title.ToString();
                            mailMessage.Subject = Subject.ToString();

                            StringBuilder sb = new StringBuilder();
                            sb.Append("Subject: " + Subject.ToString() + "" + Environment.NewLine);


                            mailMessage.Body = body;
                            mailMessage.IsBodyHtml = true;



                            SmtpClient smtp = new SmtpClient();

                            smtp.Host = "smtpout.secureserver.net";

                            NetworkCredential NetworkCred = new NetworkCredential("netco@drnds.com", "llp225");
                            smtp.UseDefaultCredentials = false;
                            // smtp.Timeout = Math.Max(attachments.Sum(Function(Item) (DirectCast(Item, MailAttachment).Size / 1024)), 100) * 1000
                            smtp.Timeout = (60 * 5 * 1000);
                            smtp.Credentials = NetworkCred;
                            // smtp.EnableSsl = true;
                            smtp.Port = 80;
                            //string userState = "test message1";
                            smtp.Send(mailMessage);
                            smtp.Dispose();


                            Update_Email_Status();

                        }
                        else
                        {

                            MessageBox.Show("Email is Not Added Kindly Check It");
                        }
                    }
                    else
                    {

                        MessageBox.Show("Attachment Should Not be greater than 20 mb");
                    }
                }
                else
                {

                    MessageBox.Show("Search Package not added check it");
                }
            }
        }

        public void Update_Email_Status()
        {

            Hashtable htupdate = new Hashtable();
            DataTable dtupdate = new DataTable();
            htupdate.Add("@Trans", "UPDATE_EMAIL_STATUS");
            htupdate.Add("@Order_ID", Order_Id);
            dtupdate = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htupdate);

        }
    }

}
