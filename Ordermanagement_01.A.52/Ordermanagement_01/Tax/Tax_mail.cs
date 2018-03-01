using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace Ordermanagement_01.Tax
{
    public partial class Tax_mail : Form
    {
        DataAccess dataAccess = new DataAccess();
        Hashtable htorder = new Hashtable();
        DataTable dtorder = new DataTable();
        NetworkCredential NetworkCred;
        int Order_id; string userid, user_role, path, Ordernumber,OPERATION,SUBPROCESSID,EMAILID;
        public Tax_mail(int orderid, string User_Id, string User_Role, string orderno,string operation,string subprocessid)
        {
            InitializeComponent();
            Order_id = orderid;
            userid = User_Id;
            user_role = User_Role;
            Ordernumber = orderno;
            OPERATION = operation;
            SUBPROCESSID = subprocessid;
            Get_Uploaded_Attached_Document();
            Send_Html_Email_Body();
        }
        private void Get_Email_Id()
        {
            Hashtable htmail = new Hashtable();
            DataTable dtmail = new DataTable();
            htmail.Add("@Trans", "GET_EMAIL_ID");
            htmail.Add("@Tax_Order_Id", SUBPROCESSID);
            dtmail = dataAccess.ExecuteSP("Sp_Tax_Order_Status", htmail);
            if (dtmail.Rows.Count > 0)
            {
                EMAILID = dtmail.Rows[0]["Email_ID"].ToString();
            }
        }
        private void Get_Uploaded_Attached_Document()
        {
            htorder.Clear(); dtorder.Clear();
            htorder.Add("@Trans", "SELECT_MAX_UPLOAD_DOCUMENTS");
            htorder.Add("@Order_Id", Order_id);
            dtorder = dataAccess.ExecuteSP("Sp_Tax_Order_Status", htorder);
            if (dtorder.Rows.Count > 0)
            {
                path = dtorder.Rows[0]["Document_Path"].ToString();

            }
        }
        private string Populate_Body()
        {
            string body = string.Empty;
            string docu_path = @"\\192.168.12.33\Oms Email Templates\Tax_Completed_Mail.htm";
            using (StreamReader reader = new StreamReader(docu_path))
            {

                body = reader.ReadToEnd();
            }
            return body;
        }
        private void SendHtmlFormattedEmail(string mail, string subject, string body)
        {
            if (OPERATION == "Bulk")
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("neworders@abstractshop.com");
                    //mailMessage.From = new MailAddress("techteam@drnds.com");
                    string Attachment = Ordernumber.ToString() + ".pdf";
                    var maxsize = 20 * 1024 * 1000;
                    var filename = path;
                    FileInfo fi = new FileInfo(filename);
                    var file_len = fi.Length;
                    MemoryStream ms = new MemoryStream();
                    if (file_len <= maxsize)
                    {
                        ms = new MemoryStream(File.ReadAllBytes(path));
                        mailMessage.Attachments.Add(new Attachment(ms, Attachment.ToString()));//mail attachments
                        //mailMessage.To.Add("neworders@abstractshop.com");//mail sending to

                       // mailMessage.To.Add("techteam@drnds.com");//mail sending to
                        Get_Email_Id();
                        mailMessage.To.Add(EMAILID);
                        mailMessage.CC.Add("neworders@abstractshop.com");//mail sending cc
                       // mailMessage.CC.Add("techteam@drnds.com");//mail sending cc
                        string Subject = Ordernumber.ToString();
                        mailMessage.Subject = Subject.ToString();//mail subject
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = "smtpout.secureserver.net";
                        NetworkCred = new NetworkCredential("neworders@abstractshop.com", "DinNavABS");
                       // NetworkCredential NetworkCred = new NetworkCredential("techteam@drnds.com", "nop539");
                        smtp.UseDefaultCredentials = false;
                        smtp.Timeout = (60 * 5 * 1000);
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 25;
                        smtp.Send(mailMessage);
                        smtp.Dispose();

                        htorder.Clear(); dtorder.Clear();
                        htorder.Add("@Trans", "UPDATE_EMAIL_STATUS");
                        htorder.Add("@Order_Id", Order_id);
                        dtorder = dataAccess.ExecuteSP("Sp_Tax_Order_Status", htorder);
                    }
                    else
                    {
                        MessageBox.Show("File is too long, Restrict file size within 20 MB");
                        this.Close();
                    }
                }
            }
            else
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("neworders@abstractshop.com");
                    //mailMessage.From = new MailAddress("techteam@drnds.com");
                    string Attachment = Ordernumber.ToString() + ".pdf";
                    var maxsize = 20 * 1024 * 1000;
                    var filename = path;
                    FileInfo fi = new FileInfo(filename);
                    var file_len = fi.Length;
                    MemoryStream ms = new MemoryStream();
                    if (file_len <= maxsize)
                    {
                        ms = new MemoryStream(File.ReadAllBytes(path));
                        mailMessage.Attachments.Add(new Attachment(ms, Attachment.ToString()));//mail attachments
                        //mailMessage.To.Add("neworders@abstractshop.com");//mail sending to
                        //mailMessage.To.Add("techteam@drnds.com");//mail sending to
                        Get_Email_Id();
                        mailMessage.To.Add(EMAILID);
                        mailMessage.CC.Add("neworders@abstractshop.com");//mail sending cc
                        //mailMessage.CC.Add("techteam@drnds.com");//mail sending cc
                        string Subject = Ordernumber.ToString();
                        mailMessage.Subject = Subject.ToString();//mail subject
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();

                        smtp.Host = "smtpout.secureserver.net";
                        NetworkCred = new NetworkCredential("neworders@abstractshop.com", "DinNavABS");
                        //NetworkCredential NetworkCred = new NetworkCredential("techteam@drnds.com", "nop539");
                        smtp.UseDefaultCredentials = false;
                        smtp.Timeout = (60 * 5 * 1000);
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 25;
                        smtp.Send(mailMessage);
                        smtp.Dispose();

                        Update_Email_Status();
                    }
                    else
                    {
                        MessageBox.Show("File is too long, Restrict file size within 20 MB");
                        this.Close();
                    }
                }
            }
        }
        private void Update_Email_Status()
        {
            htorder.Clear(); dtorder.Clear();
            htorder.Add("@Trans", "UPDATE_EMAIL_STATUS");
            htorder.Add("@Order_Id", Order_id);
            dtorder = dataAccess.ExecuteSP("Sp_Tax_Order_Status", htorder);
            MessageBox.Show("Mail Sent Successfully");
        }
        private void Send_Html_Email_Body()
        {
            using (MailMessage mail = new MailMessage())
            {
                try
                {
                    mail.IsBodyHtml = true;
                    string body = this.Populate_Body();
                    SendHtmlFormattedEmail("neworders@abstractshop.com", "Sample", body);
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Tax_mail_Load(object sender, EventArgs e)
        {

        }

    }
}
