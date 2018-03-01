using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.DirectoryServices;

namespace Ordermanagement_01.Tax
{
    public partial class Tax_Document_Upload : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        string Order_Id, User_ID,Order_Number,Task_Id,User_Role;
        string[] FName;
        string File_size, extension;
        DialogResult dialogResult;
        string Document_ID;
        public Tax_Document_Upload(string ORDER_ID,string USER_ID,string ORDER_NUMBER,string TASK_ID,string USER_ROLE)
        {
            Order_Id = ORDER_ID;
            User_ID = USER_ID;
            Order_Number = ORDER_NUMBER;
            Task_Id = TASK_ID;
            User_Role = USER_ROLE;
            InitializeComponent();

            lbl_Header.Text = ""+Order_Number+" - Tax Document Upload";
            this.Text = lbl_Header.Text;
            if (User_Role == "1")
            {
                Gridview_bind_Tax_Admin_Side_Document_Upload();
            }
            else if (User_Role == "2")
            {

                Gridview_bind_Tax_Employee_Side_Document_Upload();
            }
        }


        private void Gridview_bind_Tax_Admin_Side_Document_Upload()
        {
            Hashtable htselect = new Hashtable();
            System.Data.DataTable dtselect = new System.Data.DataTable();
            htselect.Add("@Trans", "GET_TAX_DOCUMENTS_FOR_ADMIN");
            htselect.Add("@Order_Id", Order_Id);
            dtselect = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htselect);
            if (dtselect.Rows.Count > 0)
            {
                Grid_Tax_Upload.Columns[0].Width = 100;
                Grid_Tax_Upload.Columns[1].Width = 50;
                Grid_Tax_Upload.Columns[2].Width = 100;
                Grid_Tax_Upload.Columns[3].Width = 80;
                Grid_Tax_Upload.Columns[4].Width = 60;
                Grid_Tax_Upload.Columns[5].Width = 60;
                Grid_Tax_Upload.Columns[6].Width = 60;
                Grid_Tax_Upload.Columns[7].Width = 60;
            


                if (dtselect.Rows.Count > 0)
                {
                    //ex2.Visible = true;
                    Grid_Tax_Upload.Rows.Clear();
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        Grid_Tax_Upload.Rows.Add();
                        Grid_Tax_Upload.Rows[i].Cells[0].Value = dtselect.Rows[i]["Instuction"].ToString();
                        Grid_Tax_Upload.Rows[i].Cells[1].Value = dtselect.Rows[i]["FileSize"].ToString();
                        Grid_Tax_Upload.Rows[i].Cells[2].Value = dtselect.Rows[i]["User_Name"].ToString();
                        Grid_Tax_Upload.Rows[i].Cells[3].Value = dtselect.Rows[i]["Tax_Task"].ToString();
                       
                        Grid_Tax_Upload.Rows[i].Cells[4].Value = dtselect.Rows[i]["Inserted_date"].ToString();
                       
                        Grid_Tax_Upload.Rows[i].Cells[5].Value = "View";
                        Grid_Tax_Upload.Rows[i].Cells[6].Value = "Edit";
                        Grid_Tax_Upload.Rows[i].Cells[7].Value = "Delete";
                        Grid_Tax_Upload.Rows[i].Cells[8].Value = dtselect.Rows[i]["Tax_Document_Upload_Id"].ToString();

                        Grid_Tax_Upload.Rows[i].Cells[9].Value = dtselect.Rows[i]["Document_Path"].ToString();

                    }



                }
            }
            else
            {
                Grid_Tax_Upload.Rows.Clear();
                Grid_Tax_Upload.DataSource = null;

            }
        }

        private void Gridview_bind_Tax_Employee_Side_Document_Upload()
        {
            Hashtable htselect = new Hashtable();
            System.Data.DataTable dtselect = new System.Data.DataTable();
            htselect.Add("@Trans", "GET_TAX_DOCUMENTS_FOR_EMPLOYEE");
            htselect.Add("@Order_Id", Order_Id);
            dtselect = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htselect);
            if (dtselect.Rows.Count > 0)
            {
                Grid_Tax_Upload.Columns[0].Width = 100;
                Grid_Tax_Upload.Columns[1].Width = 50;
                Grid_Tax_Upload.Columns[2].Width = 100;
                Grid_Tax_Upload.Columns[3].Width = 80;
                Grid_Tax_Upload.Columns[4].Width = 60;
                Grid_Tax_Upload.Columns[5].Width = 60;
                Grid_Tax_Upload.Columns[6].Width = 60;
                Grid_Tax_Upload.Columns[7].Width = 60;



                if (dtselect.Rows.Count > 0)
                {
                    //ex2.Visible = true;
                    Grid_Tax_Upload.Rows.Clear();
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        Grid_Tax_Upload.Rows.Add();
                        Grid_Tax_Upload.Rows[i].Cells[0].Value = dtselect.Rows[i]["Instuction"].ToString();
                        Grid_Tax_Upload.Rows[i].Cells[1].Value = dtselect.Rows[i]["FileSize"].ToString();
                        Grid_Tax_Upload.Rows[i].Cells[2].Value = dtselect.Rows[i]["User_Name"].ToString();
                        Grid_Tax_Upload.Rows[i].Cells[3].Value = dtselect.Rows[i]["Tax_Task"].ToString();

                        Grid_Tax_Upload.Rows[i].Cells[4].Value = dtselect.Rows[i]["Inserted_date"].ToString();

                        Grid_Tax_Upload.Rows[i].Cells[5].Value = "View";
                        Grid_Tax_Upload.Rows[i].Cells[6].Value = "Edit";
                        Grid_Tax_Upload.Rows[i].Cells[7].Value = "Delete";
                        Grid_Tax_Upload.Rows[i].Cells[8].Value = dtselect.Rows[i]["Tax_Document_Upload_Id"].ToString();

                        Grid_Tax_Upload.Rows[i].Cells[9].Value = dtselect.Rows[i]["Document_Path"].ToString();

                    }



                }
            }
            else
            {
                Grid_Tax_Upload.Rows.Clear();
                Grid_Tax_Upload.DataSource = null;

            }
        }
        private string GetFileSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";
            File_size = size;
            return size;
        }

      

        private void btn_Tax_Upload_Click(object sender, EventArgs e)
        {
            if (Order_Id != "0" && txt_Tax_Dscription.Text!="")
            {
                Hashtable htorderkb = new Hashtable();
                System.Data.DataTable dtorderkb = new System.Data.DataTable();
                OpenFileDialog op1 = new OpenFileDialog();
                op1.Multiselect = true;
                op1.ShowDialog();
                op1.Filter = "allfiles|*.xls";
                // txt_path.Text = op1.FileName;

                int count = 0;
                int Chk = 0;

                foreach (string s in op1.FileNames)
                {
                    string file = op1.FileName.ToString();
                    System.IO.FileInfo f = new System.IO.FileInfo(file);
                    string Extension = f.Extension;
                    double filesize = f.Length;
                    GetFileSize(filesize);
                 
                    FName = s.Split('\\');
                    string Docname = FName[FName.Length - 1].ToString();

                    string dest_path1 = @"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\" + Order_Id + @"\" + FName[FName.Length - 1];
                    DirectoryEntry de = new DirectoryEntry(dest_path1, "administrator", "password1$");
                    de.Username = "administrator";
                    de.Password = "password1$";

                    Directory.CreateDirectory(@"\\192.168.12.33\INHOUSE-TAX-DOCUMENTS\" + Order_Id);
                    extension = Path.GetExtension(Docname);
                    File.Copy(s, dest_path1, true);
                    
                    count++;
                    htorderkb.Clear();
                    dtorderkb.Clear();
                    htorderkb.Add("@Trans", "INSERT");
                    htorderkb.Add("@Order_Id", Order_Id);
                    htorderkb.Add("@Instuction", txt_Tax_Dscription.Text.ToString());
                    htorderkb.Add("@Document_Path", dest_path1);
                    htorderkb.Add("@Tax_Task", Task_Id);
                    htorderkb.Add("@FileSize", File_size);
                    htorderkb.Add("@File_Extension", Extension);
                    htorderkb.Add("@Inserted_By", User_ID);
                    htorderkb.Add("@status", "True");
                    dtorderkb = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htorderkb);
                    if (User_Role == "1")
                    {
                        Gridview_bind_Tax_Admin_Side_Document_Upload();
                    }
                    else if (User_Role == "2")
                    {

                        Gridview_bind_Tax_Employee_Side_Document_Upload();
                    }

                    txt_Tax_Dscription.Text = "";
                }
                MessageBox.Show(Convert.ToString(count) + " File(s) copied");
            }
            else
            {
                MessageBox.Show("Enter Description of  Uploading File");

            }
        }

        private void Grid_Tax_Upload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {


                string Source_Path = Grid_Tax_Upload.Rows[e.RowIndex].Cells[9].Value.ToString();
                if (Source_Path != "")
                {
                    string docName = Path.GetFileName(Source_Path.ToString());

                    System.IO.Directory.CreateDirectory(@"C:\temp");

                    File.Copy(Source_Path, @"C:\temp\" + docName, true);

                    System.Diagnostics.Process.Start(@"C:\temp\" + docName);
                }

            }
            else if (e.ColumnIndex == 6)
            {
                btn_Update.Visible = true;
                btn_Tax_Upload.Visible = false;
                 Document_ID = Grid_Tax_Upload.Rows[e.RowIndex].Cells[8].Value.ToString();
                txt_Tax_Dscription.Text = Grid_Tax_Upload.Rows[e.RowIndex].Cells[0].Value.ToString();


            }
            else if (e.ColumnIndex == 7)
            {
                dialogResult = MessageBox.Show("Do you Want to Proceed?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                     Document_ID = Grid_Tax_Upload.Rows[e.RowIndex].Cells[8].Value.ToString();


                    Hashtable htdel = new Hashtable();
                    System.Data.DataTable dtdel = new System.Data.DataTable();
                    htdel.Add("@Trans", "DELETE");
                    htdel.Add("@Tax_Document_Upload_Id", Document_ID.ToString());
                    dtdel = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htdel);
                    if (User_Role == "1")
                    {
                        Gridview_bind_Tax_Admin_Side_Document_Upload();
                    }
                    else if (User_Role == "2")
                    {

                        Gridview_bind_Tax_Employee_Side_Document_Upload();
                    }

                }

                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }


            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            btn_Update.Visible = false;
            btn_Tax_Upload.Visible = true;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Hashtable htupdate = new Hashtable();
            DataTable dtupdate = new DataTable();
            htupdate.Add("@Trans", "UPDATE_INSTRUCTION");
            htupdate.Add("@Instuction",txt_Tax_Dscription.Text);
            htupdate.Add("@Tax_Document_Upload_Id", Document_ID);
            dtupdate = dataaccess.ExecuteSP("Sp_Tax_Orders_Documents", htupdate);
            MessageBox.Show("Description Updated");
            btn_Update.Visible = false;
            btn_Tax_Upload.Visible = true;
            txt_Tax_Dscription.Text = "";
            if (User_Role == "1")
            {
                Gridview_bind_Tax_Admin_Side_Document_Upload();
            }
            else if (User_Role == "2")
            {

                Gridview_bind_Tax_Employee_Side_Document_Upload();
            }

        }

        private void Tax_Document_Upload_Load(object sender, EventArgs e)
        {
            btn_Update.Visible = false;
            btn_Tax_Upload.Visible = true;

        }
    }
}
