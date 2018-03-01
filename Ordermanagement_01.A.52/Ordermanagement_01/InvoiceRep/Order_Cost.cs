﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Speech.Synthesis;
using System.DirectoryServices;
using iTextSharp.text;
using iTextSharp.text.pdf;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Ordermanagement_01.InvoiceRep
{
    public partial class Order_Cost : Form
    {
       
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        CheckBox chkbox = new CheckBox();
        int Order_Id = 0;
        int userid;
        string Empname;
        int Count;
        string Gender, PaymentType, Employee_Type;
        decimal Abstractor_Cost;
        int Abstractor_Tat;
        int Order_Type_Id;
        string User_Role;
        int Sub_Process_ID;
        string Email, Alternative_Email;
        string Inv_Status;
        string[] FName;

        static int currentpageindex = 0;
        int pagesize = 15;
        System.Data.DataTable dtuser = new System.Data.DataTable();
        System.Data.DataTable dt = new System.Data.DataTable();
        InfiniteProgressBar.clsProgress cProbar = new InfiniteProgressBar.clsProgress();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        string View_File_Path;
        string Invoice_Status;
        DialogResult dialogResult;
        PdfCopy pdfCopyProvider = null;
        PdfImportedPage importedPage;
        string Package = "";
        string P1, P2;
        int Index;
        public Order_Cost(int User_Id, string Role_id)
        {


            InitializeComponent();
            userid = User_Id;

            User_Role = Role_id;



        }
        private void GetDataRow(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dtuser.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }
        private void Geridview_Bind_Orders_Cost_Details()
        {


            Hashtable htuser = new Hashtable();
            


            htuser.Add("@Trans", "GET_ORDER_COST_DETAILS");
            if (rbtn_Invoice_NotSended.Checked == true)
            {
                htuser.Add("@Email_Status", "False");
            }
            else if (rbtn_Invoice_Sended.Checked == true)
            {
                htuser.Add("@Email_Status", "True");

            }
            dtuser = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htuser);



            grd_order.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DarkCyan;
            grd_order.EnableHeadersVisualStyles = false;
            grd_order.Columns[0].Width = 36;
            grd_order.Columns[1].Width = 120;
            grd_order.Columns[2].Width = 120;
            grd_order.Columns[3].Width = 100;
            grd_order.Columns[4].Width = 126;
            grd_order.Columns[5].Width = 132;
            grd_order.Columns[6].Width = 120;
            grd_order.Columns[7].Width = 100;
            grd_order.Columns[8].Width = 70;
            grd_order.Columns[9].Width = 70;
            grd_order.Columns[10].Width = 40;
            grd_order.Columns[11].Width = 40;

            if (userid == 99 || userid == 1 || userid == 4)
            {

                grd_order.Columns[2].Visible = true;
                grd_order.Columns[3].Visible = true;
                grd_order.Columns[7].Visible = true;


            }
            else
            {

                grd_order.Columns[2].Visible = false;
                grd_order.Columns[3].Visible = false;
                grd_order.Columns[7].Visible = false;
             
            }

            System.Data.DataTable temptable = dtuser.Clone();
            int startindex = currentpageindex * pagesize;
            int endindex = currentpageindex * pagesize + pagesize;
            if (endindex > dtuser.Rows.Count)
            {
                endindex = dtuser.Rows.Count;
            }
            for (int i = startindex; i < endindex; i++)
            {
                DataRow row = temptable.NewRow();
                GetDataRow(ref row, dtuser.Rows[i]);
                temptable.Rows.Add(row);
            }
            if (temptable.Rows.Count > 0)
            {
                grd_order.Rows.Clear();
                for (int i = 0; i < temptable.Rows.Count; i++)
                {
                    grd_order.Rows.Add();
                    grd_order.Rows[i].Cells[0].Value = i + 1;
                    grd_order.Rows[i].Cells[1].Value = temptable.Rows[i]["Client_Order_Number"].ToString();
                    grd_order.Rows[i].Cells[2].Value = temptable.Rows[i]["Client_Name"].ToString();
                    grd_order.Rows[i].Cells[3].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                    grd_order.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Type"].ToString();
                    grd_order.Rows[i].Cells[5].Value = temptable.Rows[i]["STATECOUNTY"].ToString();
                    grd_order.Rows[i].Cells[6].Value = temptable.Rows[i]["Date"].ToString();
                    grd_order.Rows[i].Cells[7].Value = temptable.Rows[i]["Order_Cost"].ToString();
                    grd_order.Rows[i].Cells[8].Value = temptable.Rows[i]["Order_Cost_Date"].ToString();
                    grd_order.Rows[i].Cells[11].Value = temptable.Rows[i]["Order_ID"].ToString();
                    grd_order.Rows[i].Cells[12].Value = temptable.Rows[i]["Sub_ProcessId"].ToString();
                    grd_order.Rows[i].Cells[13].Value = temptable.Rows[i]["Order_Cost_Id"].ToString();
                }
            }
            else
            {
                grd_order.Visible = true;
                grd_order.Rows.Clear();
                grd_order.DataSource = null;
            }
            lbl_Total_orders.Text = dtuser.Rows.Count.ToString();
            lbl_Record_status.Text = (currentpageindex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dtuser.Rows.Count) / pagesize);
          
            //if (dtuser.Rows.Count > 0)
            //{
            //    //ex2.Visible = true;
            //    grd_order.Rows.Clear();
            //    for (int i = 0; i < dtuser.Rows.Count; i++)
            //    {
            //        grd_order.Rows.Add();
            //        grd_order.Rows[i].Cells[0].Value = i + 1;
            //        grd_order.Rows[i].Cells[1].Value = dtuser.Rows[i]["Client_Order_Number"].ToString();
            //        grd_order.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Name"].ToString();
            //        grd_order.Rows[i].Cells[3].Value = dtuser.Rows[i]["Sub_ProcessName"].ToString();
            //        grd_order.Rows[i].Cells[4].Value = dtuser.Rows[i]["Order_Type"].ToString();
            //        grd_order.Rows[i].Cells[5].Value = dtuser.Rows[i]["STATECOUNTY"].ToString();
            //        grd_order.Rows[i].Cells[6].Value = dtuser.Rows[i]["Date"].ToString();
            //        grd_order.Rows[i].Cells[7].Value = dtuser.Rows[i]["Order_Cost"].ToString();
            //        grd_order.Rows[i].Cells[8].Value = dtuser.Rows[i]["Order_Cost_Date"].ToString();
            //        grd_order.Rows[i].Cells[11].Value = dtuser.Rows[i]["Order_ID"].ToString();
            //        grd_order.Rows[i].Cells[12].Value = dtuser.Rows[i]["Sub_ProcessId"].ToString();
            //        grd_order.Rows[i].Cells[13].Value = dtuser.Rows[i]["Order_Cost_Id"].ToString();


            //    }
            //    // lbl_Total_Orders.Text = grd_order.Rows.Count.ToString();
            //}
            //else
            //{
            //    grd_order.Rows.Clear();
            //    grd_order.DataSource = null;
            //    // lbl_Total_Orders.Text = "0";
            //    //grd_Admin_orders.EmptyDataText = "No Orders Are Avilable";
            //    //grd_Admin_orders.DataBind();
            //}



        }
        private void GetDataRow_Search(ref DataRow dest, DataRow source)
        {
            foreach (DataColumn col in dt.Columns)
            {
                dest[col.ColumnName] = source[col.ColumnName];
            }
        }
        private void txt_orderserach_Number_TextChanged(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in grd_order.Rows)
            //{
            //    if (txt_orderserach_Number.Text != "")
            //    {
            //        if (txt_orderserach_Number.Text != "" && txt_orderserach_Number.Text != "Search..." && cbo_colmn.Text == "Client" && row.Cells[3].Value.ToString().StartsWith(txt_orderserach_Number.Text, true, CultureInfo.InvariantCulture))
            //        {
            //            row.Visible = true;
            //        }
            //        else if (txt_orderserach_Number.Text != "" && txt_orderserach_Number.Text != "Search..." && cbo_colmn.Text == "Sub Client" && row.Cells[4].Value.ToString().StartsWith(txt_orderserach_Number.Text, true, CultureInfo.InvariantCulture))
            //        {
            //            row.Visible = true;
            //        }
            //        else if (txt_orderserach_Number.Text != "" && txt_orderserach_Number.Text != "Search..." && cbo_colmn.Text == "Received Date" && row.Cells[6].Value.ToString().StartsWith(txt_orderserach_Number.Text, true, CultureInfo.InvariantCulture))
            //        {
            //            row.Visible = true;
            //        }
            //        else if (txt_orderserach_Number.Text != "" && txt_orderserach_Number.Text != "Search..." && cbo_colmn.Text == "Order Type" && row.Cells[4].Value.ToString().StartsWith(txt_orderserach_Number.Text, true, CultureInfo.InvariantCulture))
            //        {
            //            row.Visible = true;
            //        }


            //        else if (txt_orderserach_Number.Text != "" && txt_orderserach_Number.Text != "Search..." && cbo_colmn.Text == "Order Number" && row.Cells[1].Value.ToString().StartsWith(txt_orderserach_Number.Text, true, CultureInfo.InvariantCulture))
            //        {
            //            row.Visible = true;
            //        }
            //        else if (txt_orderserach_Number.Text != "" && txt_orderserach_Number.Text != "Search..." && cbo_colmn.Text == "GEN_Date" && row.Cells[7].Value.ToString().StartsWith(txt_orderserach_Number.Text, true, CultureInfo.InvariantCulture))
            //        {
            //            row.Visible = true;
            //        }

            //        else
            //        {
            //            row.Visible = false;
            //        }
            //    }
            //    else
            //    {

            //        row.Visible = true;
            //    }
            //}

            Filter_Data();
            First_Page();
        }
        private void First_Page()
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentpageindex = 0;
            btn_Previous.Enabled = false;
            btn_Next.Enabled = true;
            btn_Last.Enabled = true;
            btn_First.Enabled = false;
            this.Cursor = currentCursor;
        }
        private void Filter_Data()
        {
            DataView dtsearch = new DataView(dtuser);

            if (txt_orderserach_Number.Text != "" && txt_orderserach_Number.Text != "Search...")
            {
                string search = txt_orderserach_Number.Text;

                //dtsearch.RowFilter = "Client_Order_Number like '%" + search.ToString() + "%' or Client_Name like '%" + search.ToString() + "%' or  Sub_ProcessName like '%" + search.ToString() + "%' or Order_Type like '%" + search.ToString() + "%'  or STATECOUNTY like '%" + search.ToString() + "%' or Date like '%" + search.ToString() + "%' or Order_Cost like '%" + search.ToString() + "%' or Order_Cost_Date like '%" + search.ToString() + "%' or  Order_ID like '%" + search.ToString() +"%' or  Sub_ProcessId like '%" + search.ToString() +"%' or  Order_Cost_Id like '%" + search.ToString() + "%'";
                dtsearch.RowFilter = "Client_Order_Number like '%" + search.ToString() + "%' or Client_Name like '%" + search.ToString() + "%' or  Sub_ProcessName like '%" + search.ToString() + "%' or Order_Type like '%" + search.ToString() + "%' or Order_Cost_Date like '%" + search.ToString() + "%' or Date like '%" + search.ToString() + "%'";


                dt = dtsearch.ToTable();

                System.Data.DataTable temptable = dt.Clone();
                int startindex = currentpageindex * pagesize;
                int endindex = currentpageindex * pagesize + pagesize;
                if (endindex > dt.Rows.Count)
                {
                    endindex = dt.Rows.Count;
                }
                for (int i = startindex; i < endindex; i++)
                {
                    DataRow row = temptable.NewRow();
                    GetDataRow_Search(ref row, dt.Rows[i]);
                    temptable.Rows.Add(row);
                }
                if (temptable.Rows.Count > 0)
                {
                    grd_order.Rows.Clear();
                    for (int i = 0; i < temptable.Rows.Count; i++)
                    {
                        grd_order.Rows.Add();
                        grd_order.Rows[i].Cells[0].Value = i + 1;
                        grd_order.Rows[i].Cells[1].Value = temptable.Rows[i]["Client_Order_Number"].ToString();
                        grd_order.Rows[i].Cells[2].Value = temptable.Rows[i]["Client_Name"].ToString();
                        grd_order.Rows[i].Cells[3].Value = temptable.Rows[i]["Sub_ProcessName"].ToString();
                        grd_order.Rows[i].Cells[4].Value = temptable.Rows[i]["Order_Type"].ToString();
                        grd_order.Rows[i].Cells[5].Value = temptable.Rows[i]["STATECOUNTY"].ToString();
                        grd_order.Rows[i].Cells[6].Value = temptable.Rows[i]["Date"].ToString();
                        grd_order.Rows[i].Cells[7].Value = temptable.Rows[i]["Order_Cost"].ToString();
                        grd_order.Rows[i].Cells[8].Value = temptable.Rows[i]["Order_Cost_Date"].ToString();
                        grd_order.Rows[i].Cells[11].Value = temptable.Rows[i]["Order_ID"].ToString();
                        grd_order.Rows[i].Cells[12].Value = temptable.Rows[i]["Sub_ProcessId"].ToString();
                        grd_order.Rows[i].Cells[13].Value = temptable.Rows[i]["Order_Cost_Id"].ToString();
                    }
                }
                else
                {
                    grd_order.Visible = true;
                    grd_order.Rows.Clear();
                    grd_order.DataSource = null;
                }
                lbl_Total_orders.Text = dt.Rows.Count.ToString();
                lbl_Record_status.Text = (currentpageindex + 1) + " / " + (int)Math.Ceiling(Convert.ToDecimal(dt.Rows.Count) / pagesize);
            }
            else
            {
                Geridview_Bind_Orders_Cost_Details();
            }
        }

        private void rbtn_Invoice_NotSended_CheckedChanged(object sender, EventArgs e)
        {
            Geridview_Bind_Orders_Cost_Details();
            btn_First_Click(sender, e);
        }

        private void rbtn_Invoice_Sended_CheckedChanged(object sender, EventArgs e)
        {
            Geridview_Bind_Orders_Cost_Details();
            btn_First_Click(sender,  e);
        }

        private void btn_New_Invoice_Click(object sender, EventArgs e)
        {

            Order_Cost_Details invid = new Order_Cost_Details(0, userid, "Insert",User_Role);
            invid.Show();
        }

        private void grd_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                form_loader.Start_progres();
                //cProbar.startProgress();
                Order_Id = int.Parse(grd_order.Rows[e.RowIndex].Cells[11].Value.ToString());
                Order_Cost_Details inv = new Order_Cost_Details(Order_Id, userid, "Update", User_Role);
                inv.Show();
                //cProbar.stopProgress();
            }
            else if (e.ColumnIndex == 9)
            {
                form_loader.Start_progres();
                //cProbar.startProgress();
                Order_Id = int.Parse(grd_order.Rows[e.RowIndex].Cells[11].Value.ToString());
                View_Search_Document();
                //cProbar.stopProgress();
            }
            else if (e.ColumnIndex == 10)
            {
                dialogResult = MessageBox.Show("Do you Want to Proceed?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    form_loader.Start_progres();
                    //cProbar.startProgress();
                    Sub_Process_ID = int.Parse(grd_order.Rows[e.RowIndex].Cells[12].Value.ToString());
                    int Order_Cost_Id = int.Parse(grd_order.Rows[e.RowIndex].Cells[13].Value.ToString());
                    string Order_Number = grd_order.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int order_Id = int.Parse(grd_order.Rows[e.RowIndex].Cells[11].Value.ToString());
                string OrderCost=grd_order.Rows[e.RowIndex].Cells[7].Value.ToString();

                    Hashtable htsearch = new Hashtable();
                    DataTable dtsearch = new DataTable();
                    htsearch.Add("@Trans", "GET_SEARCH_PACKAGE_DOCUEMNT_PATH");
                    htsearch.Add("@Order_ID", order_Id);
                    dtsearch = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htsearch);

                    if (dtsearch.Rows.Count > 0)
                    {

                        InvoiceRep.Order_Cost_Email inv = new InvoiceRep.Order_Cost_Email(Order_Number, userid, order_Id, Order_Cost_Id, Sub_Process_ID, OrderCost);
                       
                        Geridview_Bind_Orders_Cost_Details();
                        //cProbar.stopProgress();
                    }
                    else
                    {
                        MessageBox.Show("Search Package is not added please check it");
                        //cProbar.stopProgress();
                    }
                   
                }
                else if (dialogResult == DialogResult.No)
                {
                 
                }


            }
        }

        protected void View_Search_Document()
        {

            Hashtable htsearch = new Hashtable();
            DataTable dtsearch = new DataTable();
            htsearch.Add("@Trans", "GET_SEARCH_PACKAGE_DOCUEMNT_PATH");
            htsearch.Add("@Order_ID", Order_Id);
            dtsearch = dataaccess.ExecuteSP("Sp_Order_Cost_Entry", htsearch);


            if (dtsearch.Rows.Count > 0)
            {

                FName = dtsearch.Rows[0]["Document_Name"].ToString().Split('\\');
                string Source_Path = dtsearch.Rows[0]["Document_Path"].ToString();
                System.IO.Directory.CreateDirectory(@"C:\temp");

                File.Copy(Source_Path, @"C:\temp\" + FName[FName.Length - 1], true);
                Hashtable htUpload = new Hashtable();
                DataTable dtUpload = new System.Data.DataTable();
                htUpload.Add("@Trans", "SELECT_EMP");
                htUpload.Add("@Employee_Id", userid);
                dtUpload = dataaccess.ExecuteSP("Sp_Employee_Status", htUpload);

                System.Diagnostics.Process.Start(@"C:\temp\" + FName[FName.Length - 1]);
            }
            else
            {

              

                    MessageBox.Show("Search Package is Not added Please Check it");

            }
        }

        private void Order_Cost_Load(object sender, EventArgs e)
        {
            rbtn_Invoice_NotSended_CheckedChanged(sender, e);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Geridview_Bind_Orders_Cost_Details();

        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentpageindex++;
            if (txt_orderserach_Number.Text != "")
            {
                if (currentpageindex == (int)Math.Ceiling(Convert.ToDecimal(dt.Rows.Count) / pagesize) - 1)
                {
                    btn_Next.Enabled = false;
                    btn_Last.Enabled = false;
                }
                else
                {
                    btn_Next.Enabled = true;
                    btn_Last.Enabled = true;

                }
                Filter_Data();
            }
            else
            {
                if (currentpageindex == (int)Math.Ceiling(Convert.ToDecimal(dtuser.Rows.Count) / pagesize) - 1)
                {
                    btn_Next.Enabled = false;
                    btn_Last.Enabled = false;
                }
                else
                {
                    btn_Next.Enabled = true;
                    btn_Last.Enabled = true;

                }
                Geridview_Bind_Orders_Cost_Details();
            }
            btn_First.Enabled = true;
            btn_Previous.Enabled = true;
            this.Cursor = currentCursor;
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (txt_orderserach_Number.Text != "")
            {
                currentpageindex = (int)Math.Ceiling(Convert.ToDecimal(dt.Rows.Count) / pagesize) - 1;
                Filter_Data();
            }
            else
            {
                currentpageindex = (int)Math.Ceiling(Convert.ToDecimal(dtuser.Rows.Count) / pagesize) - 1;
                Geridview_Bind_Orders_Cost_Details();
            }
            btn_First.Enabled = true;
            btn_Previous.Enabled = true;
            btn_Next.Enabled = false;
            btn_Last.Enabled = false;
            
            this.Cursor = currentCursor;
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // splitContainer1.Enabled = false;
            currentpageindex--;
            if (currentpageindex == 0)
            {
                btn_Previous.Enabled = false;
                btn_First.Enabled = false;
            }
            else
            {
                btn_Previous.Enabled = true;
                btn_First.Enabled = true;

            }
            btn_Next.Enabled = true;
            btn_Last.Enabled = true;
            if (txt_orderserach_Number.Text != "")
            {
                Filter_Data();
            }
            else
            {
                Geridview_Bind_Orders_Cost_Details();
            }
            this.Cursor = currentCursor;
        }

        private void btn_First_Click(object sender, EventArgs e)
        {
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            currentpageindex = 0;
            btn_Previous.Enabled = false;
            btn_Next.Enabled = true;
            btn_Last.Enabled = true;
            btn_First.Enabled = false;
            if (txt_orderserach_Number.Text != "")
            {
                Filter_Data();
            }
            else
            {
                Geridview_Bind_Orders_Cost_Details();
            }
            this.Cursor = currentCursor;
        }
    }
}
