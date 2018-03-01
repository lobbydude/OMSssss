﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections;
using System.Data;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ClosedXML.Excel;

namespace Ordermanagement_01.Vendors
{
    public partial class Vendor_Report : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        string Path1;
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        int User_Id,User_Role_Id;
        public Vendor_Report(int USER_ID,int USER_ROLE )
        {
          
            InitializeComponent();
            User_Id = USER_ID;
            User_Role_Id = USER_ROLE;
        }

        private void Vendor_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            txt_Fromdate.Value = DateTime.Now;
            txt_Todate.Value = DateTime.Now;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            form_loader.Start_progres();
        
            Load_Vendor_Production_Report();
            Load_Vendor_Production_Count();
        }

        
        private void Load_Vendor_Production_Report()
        {
            DateTime Fromdate = Convert.ToDateTime(txt_Fromdate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(txt_Todate.Text.ToString());


            DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;


            Hashtable ht_Status = new Hashtable();
            System.Data.DataTable dt_Status = new System.Data.DataTable();
            System.Data.DataTable dt_orders = new System.Data.DataTable();

            dt_Status.Rows.Clear();
            string From_Date = Fromdate.ToString("MM/dd/yyyy");
            string To_Date = Todate.ToString("MM/dd/yyyy");

            ht_Status.Clear();
            dt_Status.Clear();
            string Client, SubProcess;


         
                if (rbtn_Assigned_Date.Checked == true)
                {
                    ht_Status.Add("@Trans", "SELECT_BY_ASSIGNED_DATE_WISE");
                }
                else if (rbtn_Completed.Checked == true)
                {
                    ht_Status.Add("@Trans", "SELECT_BY_COMPLETED_DATE_WISE");

                }
           
            

            ht_Status.Add("@From_Date", From_Date);
            ht_Status.Add("@To_Date", To_Date);

            dt_Status = dataaccess.ExecuteSP("Sp_Vendor_Order_Report", ht_Status);




            dt_orders.Clear();
            dt_orders = dt_Status;


            if (dt_orders.Rows.Count > 0)
            {


                //    Grd_OrderTime.Rows.Clear();
                //Grd_OrderTime.DataSource = null;
                Grd_OrderTime.Visible = true;

                Grd_OrderTime.DataSource = null;
                Grd_OrderTime.AutoGenerateColumns = false;

                Grd_OrderTime.ColumnCount = 16;
                //Grd_OrderTime.Rows.Add();
                Grd_OrderTime.Columns[0].Name = "Orderid";
                Grd_OrderTime.Columns[0].HeaderText = "Order Id";
                Grd_OrderTime.Columns[0].DataPropertyName = "Order_ID";
                Grd_OrderTime.Columns[0].Width = 50;
                Grd_OrderTime.Columns[0].Visible = false;



                Grd_OrderTime.Columns[1].Name = "Assigned Date";
                Grd_OrderTime.Columns[1].HeaderText = "Assigned Date";
                Grd_OrderTime.Columns[1].DataPropertyName = "Assigned Date";
                Grd_OrderTime.Columns[1].Width = 140;

                Grd_OrderTime.Columns[2].Name = "Completed Date";
                Grd_OrderTime.Columns[2].HeaderText = "Completed Date";
                Grd_OrderTime.Columns[2].DataPropertyName = "Completed Date";
                Grd_OrderTime.Columns[2].Width = 140;

        

                Grd_OrderTime.Columns[3].Name = "Client_Order_Number";
                Grd_OrderTime.Columns[3].HeaderText = "Client_Order_Number";
                Grd_OrderTime.Columns[3].DataPropertyName = "Client_Order_Number";
                Grd_OrderTime.Columns[3].Width = 120;

                if (User_Role_Id == 1)
                {
                    Grd_OrderTime.Columns[4].Name = "Client_Name";
                    Grd_OrderTime.Columns[4].HeaderText = "Client Name";
                    Grd_OrderTime.Columns[4].DataPropertyName = "Client_Name";
                    Grd_OrderTime.Columns[4].Width = 120;

                    Grd_OrderTime.Columns[5].Name = "Sub_ProcessName";
                    Grd_OrderTime.Columns[5].HeaderText = "Sub process";
                    Grd_OrderTime.Columns[5].DataPropertyName = "Sub_ProcessName";
                    Grd_OrderTime.Columns[5].Width = 120;
                }
                else
                {
                    Grd_OrderTime.Columns[4].Name = "Client_Number";
                    Grd_OrderTime.Columns[4].HeaderText = "Client Name";
                    Grd_OrderTime.Columns[4].DataPropertyName = "Client_Number";
                    Grd_OrderTime.Columns[4].Width = 120;

                    Grd_OrderTime.Columns[5].Name = "Subprocess_Number";
                    Grd_OrderTime.Columns[5].HeaderText = "Sub process";
                    Grd_OrderTime.Columns[5].DataPropertyName = "Subprocess_Number";
                    Grd_OrderTime.Columns[5].Width = 120;

                }

           

                Grd_OrderTime.Columns[6].Name = "Order_Number";
                Grd_OrderTime.Columns[6].HeaderText = "Order_Number";
                Grd_OrderTime.Columns[6].DataPropertyName = "Order_Number";
                Grd_OrderTime.Columns[6].Width = 120;


                Grd_OrderTime.Columns[7].Name = "Order_Type";
                Grd_OrderTime.Columns[7].HeaderText = "Order Type";
                Grd_OrderTime.Columns[7].DataPropertyName = "Order_Type";
                Grd_OrderTime.Columns[7].Width = 120;


                Grd_OrderTime.Columns[8].Name = "Property Address";
                Grd_OrderTime.Columns[8].HeaderText = "Property Address";
                Grd_OrderTime.Columns[8].DataPropertyName = "Property Address";
                Grd_OrderTime.Columns[8].Width = 120;

                Grd_OrderTime.Columns[9].Name = "Abbreviation";
                Grd_OrderTime.Columns[9].HeaderText = "State";
                Grd_OrderTime.Columns[9].DataPropertyName = "Abbreviation";
                Grd_OrderTime.Columns[9].Width = 200;

                Grd_OrderTime.Columns[10].Name = "County";
                Grd_OrderTime.Columns[10].HeaderText = "County";
                Grd_OrderTime.Columns[10].DataPropertyName = "County";
                Grd_OrderTime.Columns[10].Width = 200;

                Grd_OrderTime.Columns[11].Name = "Borrower_Name";
                Grd_OrderTime.Columns[11].HeaderText = "Borrower Name";
                Grd_OrderTime.Columns[11].DataPropertyName = "Borrower_Name";
                Grd_OrderTime.Columns[11].Width = 300;

                Grd_OrderTime.Columns[12].Name = "Progress_Status";
                Grd_OrderTime.Columns[12].HeaderText = "Status";
                Grd_OrderTime.Columns[12].DataPropertyName = "Progress_Status";
                Grd_OrderTime.Columns[12].Width = 300;

                Grd_OrderTime.Columns[13].Name = "Vendor_Name";
                Grd_OrderTime.Columns[13].HeaderText = "Vendor Name";
                Grd_OrderTime.Columns[13].DataPropertyName = "Vendor_Name";
                Grd_OrderTime.Columns[13].Width = 150;



                Grd_OrderTime.Columns[14].Name = "Comments";
                Grd_OrderTime.Columns[14].HeaderText = "Comments";
                Grd_OrderTime.Columns[14].DataPropertyName = "Comments";
                Grd_OrderTime.Columns[14].Width = 150;

                Grd_OrderTime.Columns[15].Name = "TAT";
                Grd_OrderTime.Columns[15].HeaderText = "TAT";
                Grd_OrderTime.Columns[15].DataPropertyName = "TAT";
                Grd_OrderTime.Columns[15].Width = 150;

                

                Grd_OrderTime.DataSource = dt_Status;





            }
            else
            {
                Grd_OrderTime.Rows.Clear();
                Grd_OrderTime.Visible = false;
                Grd_OrderTime.DataSource = null;
                //Grd_OrderTime.EmptyDataText = "No Orders Added";
                //Grd_OrderTime.DataBind();

            }
        }

        private void Load_Vendor_Production_Count()
        {
            DateTime Fromdate = Convert.ToDateTime(txt_Fromdate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(txt_Todate.Text.ToString());


            DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;


            Hashtable ht_Status1 = new Hashtable();
            System.Data.DataTable dt_Status1 = new System.Data.DataTable();
            System.Data.DataTable dt_orders1 = new System.Data.DataTable();

            dt_Status1.Rows.Clear();
            string From_Date = Fromdate.ToString("MM/dd/yyyy");
            string To_Date = Todate.ToString("MM/dd/yyyy");

            ht_Status1.Clear();
            dt_Status1.Clear();
            string Client, SubProcess;



            if (rbtn_Assigned_Date.Checked == true)
            {
                ht_Status1.Add("@Trans", "GET_ASSIGNED_DATE_WISE_COUNT");
            }
            else if (rbtn_Completed.Checked == true)
            {
                ht_Status1.Add("@Trans", "GET_COMPLETED_DATE_WISE_COUNT");

            }



      

            dt_Status1 = dataaccess.ExecuteSP("Sp_Vendor_Order_Report", ht_Status1);




            dt_orders1.Clear();
            dt_orders1 = dt_Status1;


            if (dt_orders1.Rows.Count > 0)
            {


                Grid_Count.Visible = true;
       
                Grid_Count.DataSource = null;
                Grid_Count.AutoGenerateColumns = false;

                Grid_Count.ColumnCount = 6;
                //Grd_OrderTime.Rows.Add();
                Grid_Count.Columns[0].Name = "Vendor_Id";
                Grid_Count.Columns[0].HeaderText = "Vendor_Id";
                Grid_Count.Columns[0].DataPropertyName = "Vendor_Id";
                Grid_Count.Columns[0].Width = 50;
                Grid_Count.Columns[0].Visible = false;



                Grid_Count.Columns[1].Name = "Vendor_Name";
                Grid_Count.Columns[1].HeaderText = "Vendor Name";
                Grid_Count.Columns[1].DataPropertyName = "Vendor_Name";
                Grid_Count.Columns[1].Width = 140;

                Grid_Count.Columns[2].Name = "Waiting_For_Accept";
                Grid_Count.Columns[2].HeaderText = "Waiting_For_Accept";
                Grid_Count.Columns[2].DataPropertyName = "Waiting_For_Accept";
                Grid_Count.Columns[2].Width = 180;
                



                Grid_Count.Columns[3].Name = "Work_In_Progress";
                Grid_Count.Columns[3].HeaderText = "Work_In_Progress";
                Grid_Count.Columns[3].DataPropertyName = "Work_In_Progress";
                Grid_Count.Columns[3].Width = 180;


                Grid_Count.Columns[4].Name = "Returned";
                Grid_Count.Columns[4].HeaderText = "Returned";
                Grid_Count.Columns[4].DataPropertyName = "Returned";
                Grid_Count.Columns[4].Width = 180;

                Grid_Count.Columns[5].Name = "Rejected";
                Grid_Count.Columns[5].HeaderText = "Rejected";
                Grid_Count.Columns[5].DataPropertyName = "Rejected";
                Grid_Count.Columns[5].Width = 180;


         

                Grid_Count.DataSource = dt_Status1;





            }
            else
            {
                Grid_Count.Rows.Clear();
                Grid_Count.Visible = false;
                Grid_Count.DataSource = null;
                //Grd_OrderTime.EmptyDataText = "No Orders Added";
                //Grd_OrderTime.DataBind();

            }
        }


        private void rbtn_Assigned_Date_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            form_loader.Start_progres();
            if (Grd_OrderTime.Rows.Count > 0)
            {
                Export_ReportData();
            }
            else
            {

                MessageBox.Show("Refresh The Report and Export");
            }
        }

        private void Export_ReportData()
        {



            System.Data.DataTable dt = new System.Data.DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in Grd_OrderTime.Columns)
            {
                if (column.HeaderText != "")
                {
                    if (column.ValueType == null)
                    {

                        dt.Columns.Add(column.HeaderText, typeof(string));

                    }
                    else
                    {
                        if (column.ValueType == typeof(int))
                        {
                            dt.Columns.Add(column.HeaderText, typeof(int));

                        }
                        else if (column.ValueType == typeof(decimal))
                        {
                            dt.Columns.Add(column.HeaderText, typeof(decimal));

                        }
                        else if (column.ValueType == typeof(DateTime))
                        {

                            dt.Columns.Add(column.HeaderText, typeof(string));
                        }
                        else
                        {
                            dt.Columns.Add(column.HeaderText, column.ValueType);
                        }
                    }
                }

            }

            //Adding the Rows
            foreach (DataGridViewRow row in Grd_OrderTime.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //string Value1 = cell.Value.ToString();
                    //string m = Value1.Trim().ToString();


                    if (cell.Value != null && cell.Value.ToString() != "")
                    {

                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }

            //Exporting to Excel
            string Export_Title_Name = "Vendor_Production";
            string folderPath = "C:\\Temp\\";
            Path1 = folderPath + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + "-" + Export_Title_Name + ".xlsx";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);


            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, Export_Title_Name.ToString());


                try
                {

                    wb.SaveAs(Path1);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("File is Opened, Please Close and Export it");
                }



            }

            System.Diagnostics.Process.Start(Path1);
        }

        private void Grid_Count_DataSourceChanged(object sender, EventArgs e)
        {
        
            int Work_In_Progres = 0; int Waiting_For_Acceptance = 0; int Returned = 0; int Rejected = 0;



            for (int i = 0; i < Grid_Count.Rows.Count - 1; i++)
            {
                if (Grid_Count["Waiting_For_Accept", i].Value != DBNull.Value)
                {
                    Waiting_For_Acceptance += (int)Grid_Count["Waiting_For_Accept", i].Value;
                }
                if (Grid_Count["Work_In_Progress", i].Value != DBNull.Value)
                {
                    Work_In_Progres += (int)Grid_Count["Work_In_Progress", i].Value;
                }
                if (Grid_Count["Returned", i].Value != DBNull.Value)
                {

                    Returned += (int)Grid_Count["Returned", i].Value;
                }
                if (Grid_Count["Rejected", i].Value != DBNull.Value)
                {

                    Rejected += (int)Grid_Count["Rejected", i].Value;
                }
                
            }

   
            Grid_Count["Waiting_For_Accept", Grid_Count.Rows.Count - 1].Value = Waiting_For_Acceptance;
            Grid_Count["Work_In_Progress", Grid_Count.Rows.Count - 1].Value = Work_In_Progres;
            Grid_Count["Returned", Grid_Count.Rows.Count - 1].Value = Returned;
            Grid_Count["Rejected", Grid_Count.Rows.Count - 1].Value = Rejected;
        
          
         

        }

        private void Grid_Count_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Row_Index = Grid_Count.Rows.Count - 1;

            

            if (e.RowIndex != -1 && e.RowIndex!=Row_Index)
            {


                if (e.ColumnIndex == 2)
                {

                    int Vendor_Id = int.Parse(Grid_Count.Rows[e.RowIndex].Cells[0].Value.ToString());

                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(13, "GET_WAITING_FOR_ACCEPT_ORDER_VENDOR_WISE", Vendor_Id, User_Id, User_Role_Id);
                    vr.Show();



                }
                if (e.ColumnIndex == 3)
                {

                    int Vendor_Id = int.Parse(Grid_Count.Rows[e.RowIndex].Cells[0].Value.ToString());

                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(6, "GET_WORKING_PROGRESS_VENDOR_WISE", Vendor_Id, User_Id, User_Role_Id);
                    vr.Show();



                }

                if (e.ColumnIndex == 4)
                {

                    int Vendor_Id = int.Parse(Grid_Count.Rows[e.RowIndex].Cells[0].Value.ToString());

                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(3, "GET_RETURNED_ORDER_VENDOR_WISE", Vendor_Id, User_Id, User_Role_Id);
                    vr.Show();



                }
                if (e.ColumnIndex == 5)
                {

                    int Vendor_Id = int.Parse(Grid_Count.Rows[e.RowIndex].Cells[0].Value.ToString());

                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(16, "GET_REJECTED_ORDER_VENDOR_WISE", Vendor_Id, User_Id, User_Role_Id);
                    vr.Show();



                }

            }
            else if (Row_Index != -1 && e.RowIndex==Row_Index)
            {

                if (e.ColumnIndex == 2)
                {



                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(13, "GET_WAITING_FOR_ACCEPT_ORDER_ALL", 0, User_Id, User_Role_Id);
                    vr.Show();



                }
                if (e.ColumnIndex == 3)
                {



                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(6, "GET_WORKING_PROGRESS_ALL", 0, User_Id, User_Role_Id);
                    vr.Show();



                }

                if (e.ColumnIndex == 4)
                {



                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(3, "GET_RETURNED_ORDER_ALL", 0, User_Id, User_Role_Id);
                    vr.Show();



                }
                if (e.ColumnIndex == 5)
                {


                    Ordermanagement_01.Vendors.Vendor_Orders vr = new Vendor_Orders(16, "GET_REJECTED_ORDER_ALL", 0, User_Id, User_Role_Id);
                    vr.Show();



                }


                Grid_Count_DataSourceChanged( sender,  e);



            }

        }
    }
}
