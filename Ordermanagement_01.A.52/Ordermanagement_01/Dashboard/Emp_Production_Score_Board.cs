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

namespace Ordermanagement_01.Dashboard
{
    public partial class Emp_Production_Score_Board : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        int Emp_User_Id;
        string User_Role_Id, Production_Date;

        System.Data.DataTable dtexport = new System.Data.DataTable();
        System.Data.DataTable dttargetorder = new System.Data.DataTable();
        System.Data.DataTable dt = new System.Data.DataTable();
        public Emp_Production_Score_Board(int EMP_USER_ID,string USER_ROLE,string PRODUCTION_DATE)
        {
            InitializeComponent();
            Emp_User_Id = EMP_USER_ID;
            User_Role_Id = USER_ROLE;
            Production_Date = PRODUCTION_DATE;




        }


        private void Bind_Grid_View_Total()
        {

            Hashtable htcount = new Hashtable();
            DataTable dtcount = new DataTable();
            htcount.Add("@Trans", "SELECT_BY_TOTAL_Completed_Order_WORK_TYPE_Count");
            dtcount = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", htcount);

            if (dtcount.Rows.Count > 0) { Grid_Total.DataSource = dtcount; } else { Grid_Total.Rows.Clear(); }

        }


        private void Gridview_Employee_Production_Dataview()
        {
            Hashtable ht = new Hashtable();
            System.Data.DataTable dt = new System.Data.DataTable();





            Hashtable htlivecount = new Hashtable();
            Hashtable htreworkcount = new Hashtable();
            Hashtable htsuperqccount = new Hashtable();
            DataTable dtlivecount = new DataTable();
            DataTable dtreworkcount = new DataTable();
            DataTable dtsuperqccount = new DataTable();


            Hashtable htlivetype = new Hashtable();
            DataTable dtlivetype = new DataTable();

            Hashtable htReworktype = new Hashtable();
            DataTable dtReworktype = new DataTable();

            Hashtable htSuperqctype = new Hashtable();
            DataTable dtsuperqctype = new DataTable();











                htlivecount.Add("@Trans", "SELECT_LIVE_Completed_Order_Status_Count");

                htlivecount.Add("@User_Id", Emp_User_Id);

                htreworkcount.Add("@Trans", "SELECT_REWORK_Completed_Order_Status_Count");

                htreworkcount.Add("@User_Id", Emp_User_Id);


                htsuperqccount.Add("@Trans", "SELECT_SUPER_QC_Completed_Order_Status_Count");

                htsuperqccount.Add("@User_Id", Emp_User_Id);




                htlivetype.Add("@Trans", "SELECT_LIVE_Completed_OrderType_Wise_Count");

                htlivetype.Add("@User_Id", Emp_User_Id);


                htReworktype.Add("@Trans", "SELECT_REWORK_Completed_OrderType_Wise_Count");

                htReworktype.Add("@User_Id", Emp_User_Id);

                htSuperqctype.Add("@Trans", "SELECT_SUPER_QC_Completed_OrderType_Wise_Count");

                htSuperqctype.Add("@User_Id", Emp_User_Id);









                dtlivecount = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", htlivecount);
                dtreworkcount = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", htreworkcount);
                dtsuperqccount = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", htsuperqccount);

                dtlivetype = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", htlivetype);
                dtReworktype = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", htReworktype);
                dtsuperqctype = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", htSuperqctype);


            if (dtlivecount.Rows.Count > 0) { Grid_Live_Task_Count.DataSource = dtlivecount; } else { Grid_Live_Task_Count.Rows.Clear(); }

            if (dtlivetype.Rows.Count > 0) { Grdi_Live_OrderType_Count.DataSource = dtlivetype; } else { Grdi_Live_OrderType_Count.Rows.Clear(); }



            if (dtreworkcount.Rows.Count > 0) { Grid_Rework_Task_Count.DataSource = dtreworkcount; } else { Grid_Rework_Task_Count.Rows.Clear(); }
            if (dtReworktype.Rows.Count > 0) { Grdi_Rework_OrderType_Count.DataSource = dtReworktype; } else { Grdi_Rework_OrderType_Count.Rows.Clear(); }



            if (dtsuperqccount.Rows.Count > 0) { Grid_Super_Qc_Task_Count.DataSource = dtsuperqccount; } else { Grid_Super_Qc_Task_Count.Rows.Clear(); }
            if (dtsuperqctype.Rows.Count > 0) { Grdi_Super_Qc_OrderType_Count.DataSource = dtsuperqctype; } else { Grdi_Super_Qc_OrderType_Count.Rows.Clear(); }

            ArrangeGrid(Grid_Live_Task_Count);
            ArrangeGrid(Grdi_Live_OrderType_Count);
            ArrangeGrid(Grid_Rework_Task_Count);
            ArrangeGrid(Grdi_Rework_OrderType_Count);
            ArrangeGrid(Grid_Super_Qc_Task_Count);
            ArrangeGrid(Grdi_Super_Qc_OrderType_Count);



            ht.Add("@Trans", "GET_COMPLETED_ORDERS");

            ht.Add("@Production_Date", Production_Date);


            ht.Add("@User_Id", Emp_User_Id);
            dttargetorder = dataaccess.ExecuteSP("Sp_Employee_Production_Score_Board", ht);

            if (dttargetorder.Rows.Count > 0)
            {

              
                
                lbl_total.Text = dttargetorder.Rows.Count.ToString();
                if (dttargetorder.Rows.Count > 0)
                {
                    lbl_Name.Text = dttargetorder.Rows[0]["User_Name"].ToString();
                }
                if (dttargetorder.Rows.Count > 0)
                {

                    //   grd_Targetorder.DataBind();





                    grd_Targetorder.DataSource = null;
                    grd_Targetorder.AutoGenerateColumns = false;




                    grd_Targetorder.ColumnCount = 16;

                    grd_Targetorder.Columns[0].Name = "SNo";
                    grd_Targetorder.Columns[0].HeaderText = "S. No";
                    grd_Targetorder.Columns[0].Width = 65;

                    grd_Targetorder.Columns[1].Name = "Production Date";
                    grd_Targetorder.Columns[1].HeaderText = "PRODUCTION DATE";
                    grd_Targetorder.Columns[1].DataPropertyName = "Order_Production_Date";
                    grd_Targetorder.Columns[1].Width = 150;

                    grd_Targetorder.Columns[2].Name = "User Name";
                    grd_Targetorder.Columns[2].HeaderText = "USER NAME";
                    grd_Targetorder.Columns[2].DataPropertyName = "User_Name";
                    grd_Targetorder.Columns[2].Width = 110;


                    grd_Targetorder.Columns[3].Name = "Order Number";
                    grd_Targetorder.Columns[3].HeaderText = "ORDER NUMBER";
                    grd_Targetorder.Columns[3].DataPropertyName = "Client_Order_Number";
                    grd_Targetorder.Columns[3].Width = 175;
                    grd_Targetorder.Columns[3].Visible = false;

                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();
                    grd_Targetorder.Columns.Add(link);
                    link.Name = "Order Number";
                    link.HeaderText = "ORDER NUMBER";
                    link.DataPropertyName = "Client_Order_Number";
                    link.Width = 200;
                    link.DisplayIndex = 1;

                    if (User_Role_Id == "1")
                    {
                        grd_Targetorder.Columns[4].Name = "Client Name";
                        grd_Targetorder.Columns[4].HeaderText = "CLIENT NAME";
                        grd_Targetorder.Columns[4].DataPropertyName = "Client_Name";
                        grd_Targetorder.Columns[4].Width = 130;

                        grd_Targetorder.Columns[5].Name = "SubProcessName";
                        grd_Targetorder.Columns[5].HeaderText = "SUB PROCESS NAME";
                        grd_Targetorder.Columns[5].DataPropertyName = "Sub_ProcessName";
                        grd_Targetorder.Columns[5].Width = 220;
                    }
                    else if (User_Role_Id == "2")
                    {
                        grd_Targetorder.Columns[4].Name = "Client Name";
                        grd_Targetorder.Columns[4].HeaderText = "CLIENT NAME";
                        grd_Targetorder.Columns[4].DataPropertyName = "Client_Number";
                        grd_Targetorder.Columns[4].Width = 130;

                        grd_Targetorder.Columns[5].Name = "SubProcessName";
                        grd_Targetorder.Columns[5].HeaderText = "SUB PROCESS NAME";
                        grd_Targetorder.Columns[5].DataPropertyName = "Subprocess_Number";
                        grd_Targetorder.Columns[5].Width = 220;
                    

                    }

                    grd_Targetorder.Columns[6].Name = "OrderType";
                    grd_Targetorder.Columns[6].HeaderText = "ORDER TYPE";
                    grd_Targetorder.Columns[6].DataPropertyName = "Order_Type";
                    grd_Targetorder.Columns[6].Width = 160;

                    grd_Targetorder.Columns[7].Name = "Order_Work_Type";
                    grd_Targetorder.Columns[7].HeaderText = "ORDER WORK TYPE";
                    grd_Targetorder.Columns[7].DataPropertyName = "Order_Work_Type";
                    grd_Targetorder.Columns[7].Width = 160;

                    grd_Targetorder.Columns[8].Name = "Task";
                    grd_Targetorder.Columns[8].HeaderText = "TASK";
                    grd_Targetorder.Columns[8].DataPropertyName = "Order_Status";
                    grd_Targetorder.Columns[8].Width = 120;

                    grd_Targetorder.Columns[9].Name = "Status";
                    grd_Targetorder.Columns[9].HeaderText = "PROGRESS STATUS";
                    grd_Targetorder.Columns[9].DataPropertyName = "Progress_Status";
                    grd_Targetorder.Columns[9].Width = 160;


                    grd_Targetorder.Columns[10].Name = "Order_Production_Date";
                    grd_Targetorder.Columns[10].HeaderText = "PRODUCTION DATE";
                    grd_Targetorder.Columns[10].DataPropertyName = "Order_Production_Date";
                    grd_Targetorder.Columns[10].Width = 160;



                    grd_Targetorder.Columns[11].Name = "StartTime";
                    grd_Targetorder.Columns[11].HeaderText = "START TIME";
                    grd_Targetorder.Columns[11].DataPropertyName = "Start_Time";
                    grd_Targetorder.Columns[11].Width = 120;

                    grd_Targetorder.Columns[12].Name = "EndTime";
                    grd_Targetorder.Columns[12].HeaderText = "END TIME";
                    grd_Targetorder.Columns[12].DataPropertyName = "End_Time";
                    grd_Targetorder.Columns[12].Width = 120;

                    grd_Targetorder.Columns[13].Name = "TotalTime";
                    grd_Targetorder.Columns[13].HeaderText = "TOTAL TIME";
                    grd_Targetorder.Columns[13].DataPropertyName = "Total_Time_hh_mm_ss";
                    grd_Targetorder.Columns[13].Width = 100;


                    grd_Targetorder.Columns[14].Name = "Order_User_Effeciency";
                    grd_Targetorder.Columns[14].HeaderText = "ORDER EFF";
                    grd_Targetorder.Columns[14].DataPropertyName = "Order_User_Effeciency";
                    grd_Targetorder.Columns[14].Width = 100;



                    grd_Targetorder.Columns[15].Name = "Order Id";
                    grd_Targetorder.Columns[15].HeaderText = "Order id";
                    grd_Targetorder.Columns[15].DataPropertyName = "Order_ID";
                    grd_Targetorder.Columns[15].Width = 100;
                    grd_Targetorder.Columns[15].Visible = false;

                    grd_Targetorder.DataSource = dttargetorder;




                }
                else
                {
                    grd_Targetorder.Visible = true;
                    //grd_Targetorder.Rows.Clear();
                    grd_Targetorder.DataSource = null;
                }
             
                for (int i = 0; i < grd_Targetorder.Rows.Count; i++)
                {
                    grd_Targetorder.Rows[i].Cells[0].Value = i + 1;
                }
            }







        }



        public static void ArrangeGrid(DataGridView Grid)
        {
            int twidth = 0;
            if (Grid.Rows.Count > 0)
            {
                twidth = (Grid.Width * Grid.Columns.Count) / 75;
                for (int i = 0; i < Grid.Columns.Count; i++)
                {
                    Grid.Columns[i].Width = 75;
                }

            }
        }

        private void grd_Targetorder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == 16 && User_Role_Id == "1")
                {


                    string Order_Id = grd_Targetorder.Rows[e.RowIndex].Cells[15].Value.ToString();
                    string Work_Type = grd_Targetorder.Rows[e.RowIndex].Cells[7].Value.ToString();

                    if (Work_Type == "Live")
                    {

                        Ordermanagement_01.Order_Entry Order_Entry = new Ordermanagement_01.Order_Entry(int.Parse(Order_Id.ToString()), Emp_User_Id, User_Role_Id.ToString());
                        Order_Entry.Show();
                    }
                    else if (Work_Type == "Rework")
                    {
                        Ordermanagement_01.Rework_Superqc_Order_Entry orderentry = new Ordermanagement_01.Rework_Superqc_Order_Entry(int.Parse(Order_Id.ToString()), Emp_User_Id, "Rework", User_Role_Id.ToString());
                        orderentry.Show();

                    }
                    else if (Work_Type == "Super Qc")
                    {
                        Ordermanagement_01.Rework_Superqc_Order_Entry orderentry = new Ordermanagement_01.Rework_Superqc_Order_Entry(int.Parse(Order_Id.ToString()), Emp_User_Id, "Superqc", User_Role_Id.ToString());
                        orderentry.Show();

                    }



                }
            }
        }

        private void Emp_Production_Score_Board_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            Bind_Grid_View_Total();
            Gridview_Employee_Production_Dataview();

        }

        private void txt_SearchOrdernumber_TextChanged(object sender, EventArgs e)
        {
            txt_SearchOrdernumber.ForeColor = Color.Black;

            foreach (DataGridViewRow row in grd_Targetorder.Rows)
            {
                if (txt_SearchOrdernumber.Text != "" && row.Cells[3].Value.ToString().StartsWith(txt_SearchOrdernumber.Text, true, CultureInfo.InvariantCulture) || row.Cells[3].Value.ToString().StartsWith(txt_SearchOrdernumber.Text, true, CultureInfo.InvariantCulture))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}
