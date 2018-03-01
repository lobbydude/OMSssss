﻿using System;
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
using System.Diagnostics;
using System.DirectoryServices;


namespace Ordermanagement_01.Masters
{
    public partial class Client_Template : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        OpenFileDialog op1 = new OpenFileDialog();
        OpenFileDialog op2 = new OpenFileDialog();
        int Subprocess_id,Client_Id;
        string HeaderFName,ContentFName;
        string Header_Path, Content_Path;
        string value;
        int User_Id;
        public Client_Template(int USER_ID)
        {
            InitializeComponent();
            User_Id = USER_ID;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_Order_Type_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddParent()
        {

            string sKeyTemp = "";
            tree_Subprocess.Nodes.Clear();
            Hashtable ht = new Hashtable();
            DataTable dt = new System.Data.DataTable();
            TreeNode parentnode;
            string clientid;
            ht.Add("@Trans", "SELECT");
            sKeyTemp = "Clients";
            dt = dataaccess.ExecuteSP("Sp_Client", ht);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                clientid = dt.Rows[i]["Client_Id"].ToString();
                sKeyTemp = dt.Rows[i]["Client_Name"].ToString();
                parentnode = tree_Subprocess.Nodes.Add(clientid, sKeyTemp);
                AddChilds(parentnode, clientid);
            }


        }
        private void AddChilds(TreeNode parentnode, string sKey)
        {
            string sKeyTemp2 = "";
            Hashtable ht = new Hashtable();
            DataTable dt = new System.Data.DataTable();
            ht.Add("@Trans", "Client_sub");
            ht.Add("@Client_Id", sKey);
            dt = dataaccess.ExecuteSP("Sp_Tree_Orders", ht);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sKeyTemp2 = dt.Rows[i]["Sub_ProcessName"].ToString();
                string ckey = dt.Rows[i]["Subprocess_Id"].ToString();
                parentnode.Nodes.Add(ckey, sKeyTemp2);
            }
        }

        private void Client_Template_Load(object sender, EventArgs e)
        {
            AddParent();
            Hashtable htParam = new Hashtable();
            DataTable dt = new DataTable();
            htParam.Add("@Trans", "ORDERTYPE_Group");
            dt = dataaccess.ExecuteSP("Sp_Order_Type", htParam);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Chk_List_OrderType.Items.Add(dt.Rows[i]["Order_Type_Abrivation"].ToString());
                ddl_Order_Type.Items.Add(dt.Rows[i]["Order_Type_Abrivation"].ToString());
            
            }
            ddl_Order_Type.Items.Insert(0, "ALL");
            //ddl_Order_Type.SelectedValue = "ALL";
            ddl_Order_Type.SelectedIndex = 0;
            ddl_Order_Type.Select();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (ddl_Order_Type.SelectedIndex > 0)
            {

                if (ddl_Order_Type.SelectedItem.ToString() != "")
                {
                    if (ddl_Order_Type.SelectedItem.ToString() == "ALL")
                    {

                        for (int i = 1; i < ddl_Order_Type.Items.Count; i++)
                        {

                            value = ddl_Order_Type.GetItemText(ddl_Order_Type.Items[i]);



                            Hashtable htcheck = new Hashtable();
                            DataTable dtcheck = new DataTable();
                            htcheck.Add("@Trans", "CHECK");
                            htcheck.Add("@Sub_Client_Id", Subprocess_id);
                            htcheck.Add("@Order_Type_Abrivation", value);
                            dtcheck = dataaccess.ExecuteSP("Sp_Client_Template", htcheck);
                            int Check;
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
                                Hashtable htinsert = new Hashtable();
                                DataTable dtinsert = new DataTable();

                                if (txt_Header.Text != "")
                                {

                                    string headerSourcepath = txt_Header.Text;
                                    HeaderFName = Path.GetFileName(headerSourcepath);
                                    Header_Path = @"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString() + @"\" + HeaderFName;
                                    DirectoryEntry de = new DirectoryEntry(Header_Path, "administrator", "password1$");
                                    de.Username = "administrator";
                                    de.Password = "password1$";

                                    Directory.CreateDirectory(@"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString());

                                    File.Copy(headerSourcepath, Header_Path, true);


                                }
                                if (txt_Content.Text != "")
                                {
                                    string ContentSourcepath = txt_Content.Text;
                                    ContentFName = Path.GetFileName(ContentSourcepath);
                                    Content_Path = @"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString() + @"\" + ContentFName;
                                    DirectoryEntry de = new DirectoryEntry(Content_Path, "administrator", "password1$");
                                    de.Username = "administrator";
                                    de.Password = "password1$";

                                    Directory.CreateDirectory(@"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString());

                                    File.Copy(ContentSourcepath, Content_Path, true);

                                }


                                htinsert.Add("@Trans", "INSERT");

                                htinsert.Add("@Client_ID", Client_Id);
                                htinsert.Add("@Sub_Client_Id", Subprocess_id);
                                htinsert.Add("@Order_Type_Abrivation", value.ToString());
                                htinsert.Add("@Header_Template_Path", Header_Path);
                                htinsert.Add("@Content_Template_Path", Content_Path);
                                htinsert.Add("@Inserted_By", User_Id);
                                htinsert.Add("@Status", "True");
                                dtinsert = dataaccess.ExecuteSP("Sp_Client_Template", htinsert);
                                Bind_Template_Path();
                            }
                            else if (Check > 0)
                            {



                                Hashtable htdel = new Hashtable();
                                DataTable dtdel = new DataTable();
                                htdel.Add("@Trans", "DELETE_ORDER_TYPE_WISE");
                                htdel.Add("@Sub_Client_Id", Subprocess_id);
                                htdel.Add("@Order_Type_Abrivation", value.ToString());

                                Hashtable htpath = new Hashtable();
                                DataTable dtpath = new DataTable();
                                htpath.Add("@Trans", "SELECT_PATH_BY_ORDERTYPE_WISE");
                                htpath.Add("@Sub_Client_Id", Subprocess_id);
                                htpath.Add("@Order_Type_Abrivation", value.ToString());

                                dtpath = dataaccess.ExecuteSP("Sp_Client_Template", htpath);
                                if (dtpath.Rows.Count > 0)
                                {


                                    string delheaderpath = dtpath.Rows[0]["Header_Template_Path"].ToString();
                                    string delcontentpath = dtpath.Rows[0]["Content_Template_Path"].ToString();


                                    if (File.Exists(delheaderpath))
                                    {


                                        File.Delete(delheaderpath);
                                    }
                                    if (File.Exists(delcontentpath))
                                    {

                                        File.Delete(delcontentpath);
                                    }

                                }


                                dtdel = dataaccess.ExecuteSP("Sp_Client_Template", htdel);


                                Hashtable htinsert = new Hashtable();
                                DataTable dtinsert = new DataTable();

                                if (txt_Header.Text != "")
                                {

                                    string headerSourcepath = txt_Header.Text;
                                    HeaderFName = Path.GetFileName(headerSourcepath);
                                    Header_Path = @"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString() + @"\" + HeaderFName;
                                    DirectoryEntry de = new DirectoryEntry(Header_Path, "administrator", "password1$");
                                    de.Username = "administrator";
                                    de.Password = "password1$";

                                    Directory.CreateDirectory(@"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString());

                                    File.Copy(headerSourcepath, Header_Path, true);


                                }
                                if (txt_Content.Text != "")
                                {
                                    string ContentSourcepath = txt_Content.Text;
                                    ContentFName = Path.GetFileName(ContentSourcepath);
                                    Content_Path = @"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString() + @"\" + ContentFName;
                                    DirectoryEntry de = new DirectoryEntry(Content_Path, "administrator", "password1$");
                                    de.Username = "administrator";
                                    de.Password = "password1$";

                                    Directory.CreateDirectory(@"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + value.ToString());

                                    File.Copy(ContentSourcepath, Content_Path, true);

                                }


                                htinsert.Add("@Trans", "INSERT");
                                htinsert.Add("@Client_ID", Client_Id);
                                htinsert.Add("@Sub_Client_Id", Subprocess_id);
                                htinsert.Add("@Order_Type_Abrivation", value.ToString());
                                htinsert.Add("@Header_Template_Path", Header_Path);
                                htinsert.Add("@Content_Template_Path", Content_Path);
                                htinsert.Add("@Inserted_By", User_Id);
                                htinsert.Add("@Status", "True");
                                dtinsert = dataaccess.ExecuteSP("Sp_Client_Template", htinsert);



                            }
                        }
                        string title = "Successfull";
                        MessageBox.Show("Template Submitted Sucessfully",title);
                        Bind_Template_Path();
                    }
                    else if (ddl_Order_Type.SelectedItem.ToString() != "ALL")
                    {
                        if (Validate() != false)
                        {

                            Hashtable htinsert = new Hashtable();
                            DataTable dtinsert = new DataTable();

                            if (txt_Header.Text != "")
                            {

                                string headerSourcepath = txt_Header.Text;
                                HeaderFName = Path.GetFileName(headerSourcepath);
                                Header_Path = @"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + ddl_Order_Type.SelectedItem.ToString() + @"\" + HeaderFName;
                                DirectoryEntry de = new DirectoryEntry(Header_Path, "administrator", "password1$");
                                de.Username = "administrator";
                                de.Password = "password1$";

                                Directory.CreateDirectory(@"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + ddl_Order_Type.SelectedItem.ToString());

                                File.Copy(headerSourcepath, Header_Path, true);


                            }
                            if (txt_Content.Text != "")
                            {
                                string ContentSourcepath = txt_Content.Text;
                                ContentFName = Path.GetFileName(ContentSourcepath);
                                Content_Path = @"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + ddl_Order_Type.SelectedItem.ToString() + @"\" + ContentFName;
                                DirectoryEntry de = new DirectoryEntry(Content_Path, "administrator", "password1$");
                                de.Username = "administrator";
                                de.Password = "password1$";

                                Directory.CreateDirectory(@"\\192.168.12.33\Client_Template\" + Client_Id + @"\" + Subprocess_id + @"\" + ddl_Order_Type.SelectedItem.ToString());

                                File.Copy(ContentSourcepath, Content_Path, true);

                            }


                            htinsert.Add("@Trans", "INSERT");

                            htinsert.Add("@Client_ID", Client_Id);
                            htinsert.Add("@Sub_Client_Id", Subprocess_id);
                            htinsert.Add("@Order_Type_Abrivation", ddl_Order_Type.SelectedItem.ToString());
                            htinsert.Add("@Header_Template_Path", Header_Path);
                            htinsert.Add("@Content_Template_Path", Content_Path);
                            htinsert.Add("@Inserted_By", User_Id);
                            htinsert.Add("@Status", "True");
                            dtinsert = dataaccess.ExecuteSP("Sp_Client_Template", htinsert);
                            string title = "Successfull!";
                            MessageBox.Show("Template Submitted Sucessfully",title);
                        }
                       // MessageBox.Show("Template Submitted Sucessfully");
                        Bind_Template_Path();
                        btn_Cancel_Click(sender, e);
                    }
                }
            }
            else
            {
                string title = "Select!";
                MessageBox.Show("Please Select Order Type",title);
                ddl_Order_Type.Focus();
            }
        }

        public bool Validate()
        {

            Hashtable htcheck = new Hashtable();
            DataTable dtcheck = new DataTable();
            htcheck.Add("@Trans", "CHECK");
            htcheck.Add("@Sub_Client_Id",Subprocess_id);
            htcheck.Add("@Order_Type_Abrivation",ddl_Order_Type.SelectedItem.ToString());
            dtcheck = dataaccess.ExecuteSP("Sp_Client_Template", htcheck);
            int Check;
            if (dtcheck.Rows.Count > 0)
            {

                Check = int.Parse(dtcheck.Rows[0]["count"].ToString());

            }
            else
            {

                Check = 0;
            }

            if (Check > 0)
            {
                string title = "Exist!";
                MessageBox.Show("Template Already Avilable for " + ddl_Order_Type.SelectedItem.ToString() + "",title);
                return false;
            }
            else
            {

                return true;
                  
            }
        }
        public bool Validate1()
        {

            Hashtable htcheck = new Hashtable();
            DataTable dtcheck = new DataTable();
            htcheck.Add("@Trans", "CHECK");
            htcheck.Add("@Sub_Client_Id", Subprocess_id);
            htcheck.Add("@Order_Type_Abrivation", value);
            dtcheck = dataaccess.ExecuteSP("Sp_Client_Template", htcheck);
            int Check;
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

                //MessageBox.Show("Template Already Avilable for " + ddl_Order_Type.SelectedItem.ToString() + "");
                return false;
            }
            else
            {

                return true;

            }
        }

        private void Bind_Template_Path()
        { 
        
              Hashtable htsel = new Hashtable();
                    DataTable dtsel = new DataTable();
                    htsel.Add("@Trans", "SELECT");
                    htsel.Add("@Sub_Client_Id",Subprocess_id);
                    dtsel = dataaccess.ExecuteSP("Sp_Client_Template", htsel);
                  

                    if (dtsel.Rows.Count > 0)
                    {

                       
                        grd_Template.Rows.Clear();
                        
                      
                        for (int i = 0; i < dtsel.Rows.Count; i++)
                        {

                            grd_Template.AutoGenerateColumns = false;
                            grd_Template.Rows.Add();
                            grd_Template.Rows[i].Cells[0].Value = i + 1;
                            grd_Template.Rows[i].Cells[1].Value = dtsel.Rows[i]["Order_Type_Abrivation"].ToString();
                            grd_Template.Rows[i].Cells[2].Value ="View";
                            grd_Template.Rows[i].Cells[3].Value ="View";
                            grd_Template.Rows[i].Cells[4].Value = dtsel.Rows[i]["User_Name"].ToString();
                            grd_Template.Rows[i].Cells[5].Value = "Delete";
                            grd_Template.Rows[i].Cells[6].Value = dtsel.Rows[i]["Header_Template_Path"].ToString();
                            grd_Template.Rows[i].Cells[7].Value = dtsel.Rows[i]["Content_Template_Path"].ToString();
                            grd_Template.Rows[i].Cells[8].Value = dtsel.Rows[i]["Template_Id"].ToString();
                            grd_Template.Rows[i].Cells[9].Value = dtsel.Rows[i]["User_id"].ToString();
                            grd_Template.Rows[i].Cells[10].Value = dtsel.Rows[i]["Subprocess_Id"].ToString();

                          
                        }




                    }
                    else
                    {
                        grd_Template.Rows.Clear();
                        //grd_Template.Rows[0].Cells[1].Value = "No Template files added";
                        //Value = 1;

                    }
                    
                   
                }

       
        

        private void btn_Header_Template_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Multiselect = true;
            op1.ShowDialog();
        
            op1.Filter = "Word document|*.doc;*.docx";
            string fulllocimage = op1.FileName;

            txt_Header.Text = fulllocimage.ToString();


        }

        private void btn_Content_Template_Click(object sender, EventArgs e)
        {
            OpenFileDialog op2 = new OpenFileDialog();
            op2.Multiselect = true;
            op2.ShowDialog();
           
            op2.Filter = "Word document|*.doc;*.docx";
            string fulllocimage = op2.FileName;

            txt_Content.Text = fulllocimage.ToString();

        }

        private void tree_Subprocess_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //clear();
            if (tree_Subprocess.SelectedNode.Level != 0)
            {
                lbl_Header.Text = tree_Subprocess.SelectedNode.Text +  " - Template";
                Subprocess_id = int.Parse(tree_Subprocess.SelectedNode.Name);
                grd_Template.Rows.Clear();
                bool isNum = Int32.TryParse(tree_Subprocess.SelectedNode.Name, out Subprocess_id);
                if (isNum)
                {
                   
                 

                    Hashtable hsforSP = new Hashtable();
                    DataTable dt = new DataTable();
                    hsforSP.Add("@Trans", "GET_CLIENT_ID");
                    hsforSP.Add("@Sub_Client_Id", Subprocess_id);
                    dt = dataaccess.ExecuteSP("Sp_Client_Template", hsforSP);


                   

                   
                    
                    Client_Id = int.Parse(dt.Rows[0]["Client_Id"].ToString());


                   

                    Hashtable htsel = new Hashtable();
                    DataTable dtsel = new DataTable();
                    htsel.Add("@Trans", "SELECT");
                    htsel.Add("@Sub_Client_Id",Subprocess_id);
                    dtsel = dataaccess.ExecuteSP("Sp_Client_Template", htsel);
                  

                    if (dtsel.Rows.Count > 0)
                    {

                       
                        grd_Template.Rows.Clear();
                 
                      
                        for (int i = 0; i < dtsel.Rows.Count; i++)
                        {

                            grd_Template.AutoGenerateColumns = false;
                            grd_Template.Rows.Add();
                            grd_Template.Rows[i].Cells[0].Value = i + 1;
                            grd_Template.Rows[i].Cells[1].Value = dtsel.Rows[i]["Order_Type_Abrivation"].ToString();
                            grd_Template.Rows[i].Cells[2].Value ="View";
                            grd_Template.Rows[i].Cells[3].Value ="View";
                            grd_Template.Rows[i].Cells[4].Value = dtsel.Rows[i]["User_Name"].ToString();
                            grd_Template.Rows[i].Cells[5].Value = "Delete";
                            grd_Template.Rows[i].Cells[6].Value = dtsel.Rows[i]["Header_Template_Path"].ToString();
                            grd_Template.Rows[i].Cells[7].Value = dtsel.Rows[i]["Content_Template_Path"].ToString();
                            grd_Template.Rows[i].Cells[8].Value = dtsel.Rows[i]["Template_Id"].ToString();
                            grd_Template.Rows[i].Cells[9].Value = dtsel.Rows[i]["User_id"].ToString();
                            grd_Template.Rows[i].Cells[10].Value = dtsel.Rows[i]["Subprocess_Id"].ToString();

                          
                        }




                    }
                    else
                    {

                        //grd_Template.Rows[0].Cells[1].Value = "No Template files added";
                        //Value = 1;

                    }
                    
                   
                }
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //} 
            }
           

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Header.Text = "";
            txt_Content.Text = "";
            ddl_Order_Type.SelectedIndex = 0;
        }

        private void grd_Template_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
            if(e.ColumnIndex==2)
            {
            
                  string localpath = grd_Template.Rows[e.RowIndex].Cells[6].Value.ToString();
                  if (localpath != "")
                  {
                      Process.Start(localpath);
                  }
            }
            else if(e.ColumnIndex==3)
            {
                string localpath = grd_Template.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (localpath != "")
                {
                    Process.Start(localpath);
                }

            }
            else if (e.ColumnIndex == 5)
            {

                Hashtable htdel = new Hashtable();
                DataTable dtdel = new DataTable();
                htdel.Add("@Trans", "DELETE");
                htdel.Add("@Template_Id", grd_Template.Rows[e.RowIndex].Cells[8].Value.ToString());
              

                string Headerpath=grd_Template.Rows[e.RowIndex].Cells[6].Value.ToString();
                string Contentpath = grd_Template.Rows[e.RowIndex].Cells[7].Value.ToString();

                if (File.Exists(Headerpath))
                {
                    File.Delete(Headerpath);
                }

                if (File.Exists(Contentpath))
                {

                    File.Delete(Contentpath);
                }

                dtdel = dataaccess.ExecuteSP("Sp_Client_Template", htdel);
                Bind_Template_Path();
            
            }
        }
        }
      

        
    }
}
