using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ordermanagement_01.Matrix
{
    public partial class Employee_Efficiency_Matrix : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        System.Data.DataTable dtsel = new System.Data.DataTable();
        Classes.Load_Progres form_loader = new Classes.Load_Progres();
        decimal allcoated_Time;
        int chkeck_task, User_ID, check_del, check_list, check_order, Check, insert_val, check_task, abbrid,insert_abr=0; string Order_Type_ABS;

        public Employee_Efficiency_Matrix(int userid)
        {
            InitializeComponent();
            User_ID = userid;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Bind_Emp_Efficiency();
            BindDbMatrix();
        }
        private void Bind_Emp_Efficiency()
        {
            try
            {
                Hashtable htsel = new Hashtable();
                htsel.Add("@Trans", "SELECT");
                dtsel = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsel);
                if (dtsel.Rows.Count > 0)
                {
                    grd_Employee_Efficiency.Rows.Clear();
                    for (int i = 0; i < dtsel.Rows.Count; i++)
                    {
                        grd_Employee_Efficiency.Rows.Add();
                        grd_Employee_Efficiency.Rows[i].Cells[0].Value = dtsel.Rows[i]["Order_Type_ABS"].ToString();
                        grd_Employee_Efficiency.Rows[i].Cells[1].Value = dtsel.Rows[i]["Search"].ToString();
                        grd_Employee_Efficiency.Rows[i].Cells[2].Value = dtsel.Rows[i]["Search QC"].ToString();
                        grd_Employee_Efficiency.Rows[i].Cells[3].Value = dtsel.Rows[i]["Typing"].ToString();
                        grd_Employee_Efficiency.Rows[i].Cells[4].Value = dtsel.Rows[i]["Typing QC"].ToString();
                        grd_Employee_Efficiency.Rows[i].Cells[5].Value = dtsel.Rows[i]["Upload"].ToString();
                        grd_Employee_Efficiency.Rows[i].Cells[6].Value = dtsel.Rows[i]["Final QC"].ToString();
                        grd_Employee_Efficiency.Rows[i].Cells[7].Value = dtsel.Rows[i]["Search Tax Request"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private bool validate()
        {

           
            if (txt_Hours.Text=="")
            {
                MessageBox.Show("Enter No of Hours");
                return false;
            }
            else
            {

                return true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            if (validate() != false)
            {
                for (int j = 0; j < grd_OrderType.Rows.Count; j++)
                {
                    bool isChecked = (bool)grd_OrderType[0, j].FormattedValue;
                    if (isChecked == true)
                    {
                        check_order = 1;
                        Order_Type_ABS = grd_OrderType.Rows[j].Cells[1].Value.ToString();
                        //  Order_Type_Id = int.Parse(grd_OrderType.Rows[j].Cells[2].Value.ToString());
                        for (int a = 0; a < grd_Order_Task.Rows.Count; a++)
                        {

                            bool ischk_task = (bool)grd_Order_Task[0, a].FormattedValue;
                            if (ischk_task == true)
                            {
                                chkeck_task = 1;

                                Hashtable htcheck = new Hashtable();
                                DataTable dtcheck = new DataTable();
                                htcheck.Add("@Trans", "CHECK_ALLOCATED_TIME");

                                htcheck.Add("@Order_Type_ABS", Order_Type_ABS);
                                htcheck.Add("@Order_Status_id", int.Parse(grd_Order_Task.Rows[a].Cells[2].Value.ToString()));

                                dtcheck = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htcheck);
                                if (dtcheck.Rows.Count > 0)
                                {

                                    Check = int.Parse(dtcheck.Rows[0]["count"].ToString());

                                }
                                else
                                {

                                    Check = 0;

                                }
                                string Value = txt_Hours.Text.ToString();
                                if (Value != "")
                                {

                                    allcoated_Time = Convert.ToDecimal(Value.ToString());
                                }
                                else
                                {

                                    allcoated_Time = 0;
                                }
                                if (allcoated_Time == 0)
                                {
                                    break;

                                }
                                else
                                {
                                    if (Check == 0)
                                    {
                                        Hashtable htinsert = new Hashtable();
                                        DataTable dtinsert = new DataTable();

                                        htinsert.Add("@Trans", "INSERT");

                                        htinsert.Add("@Order_Type_ABS", Order_Type_ABS);
                                        htinsert.Add("@Order_Status_id", int.Parse(grd_Order_Task.Rows[a].Cells[2].Value.ToString()));
                                        htinsert.Add("@Allocated_Time", allcoated_Time);
                                        htinsert.Add("@Inserted_By", User_ID);
                                        htinsert.Add("@Status", "True");
                                        dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                        insert_val = 1;
                                    }
                                    else
                                    {
                                        insert_val = 1;
                                        Hashtable htUpdate = new Hashtable();
                                        DataTable dtUpdate = new DataTable();

                                        htUpdate.Add("@Trans", "UPDATE");
                                        htUpdate.Add("@Order_Type_ABS", Order_Type_ABS);
                                        htUpdate.Add("@Allocated_Time", allcoated_Time);
                                        htUpdate.Add("@Order_Status_id", int.Parse(grd_Order_Task.Rows[a].Cells[2].Value.ToString()));
                                        htUpdate.Add("@Status", "True");
                                        dtUpdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htUpdate);

                                    }
                                }


                            }
                        }
                    }
                }

                if (insert_val != 0)
                {
                    MessageBox.Show("Employee Efficiency Matrix Updated Successfully");
                    insert_val = 0;
                    Clear();
                    BindDbMatrix();
                    Bind_Emp_Efficiency();



                    for (int i = 0; i < grd_OrderType.Rows.Count; i++)
                        {
                            grd_OrderType[0, i].Value = false;
                        }


                    for (int i = 0; i < grd_Order_Task.Rows.Count; i++)
                        {
                            grd_Order_Task[0, i].Value = false;
                        }
                    
                }

            }


        }
        private void BindDbMatrix()
        {
            try
            {
                Hashtable htsel = new Hashtable();
                DataTable dtsel = new DataTable();
                htsel.Add("@Trans", "SELECT");
                dtsel = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsel);
                if (dtsel.Rows.Count > 0)
                {
                    grd_Db_Subclient.Rows.Clear();
                    for (int i = 0; i < dtsel.Rows.Count; i++)
                    {
                        grd_Db_Subclient.Rows.Add();
                        grd_Db_Subclient.Rows[i].Cells[1].Value = dtsel.Rows[i]["Order_Type_ABS"].ToString();
                        grd_Db_Subclient.Rows[i].Cells[2].Value = dtsel.Rows[i]["Search"].ToString();
                        grd_Db_Subclient.Rows[i].Cells[3].Value = dtsel.Rows[i]["Search QC"].ToString();
                        grd_Db_Subclient.Rows[i].Cells[4].Value = dtsel.Rows[i]["Typing"].ToString();
                        grd_Db_Subclient.Rows[i].Cells[5].Value = dtsel.Rows[i]["Typing QC"].ToString();
                        grd_Db_Subclient.Rows[i].Cells[6].Value = dtsel.Rows[i]["Upload"].ToString();
                        grd_Db_Subclient.Rows[i].Cells[7].Value = dtsel.Rows[i]["Final QC"].ToString();
                        grd_Db_Subclient.Rows[i].Cells[8].Value = dtsel.Rows[i]["Search Tax Request"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear()
        {
            txt_Hours.Text = "";
            ck_Ordertype.Checked = false;
            ck_Task.Checked = false;
            chk_Db_Empmatrix.Checked = false;
        }


        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (grd_Db_Subclient.Rows.Count == 0)
            {

            }
            else
            {
                //remove the particulary employee efficiency record
                // form_loader.Start_progres();
                //cProbar.startProgress();
                for (int j = 0; j < grd_Db_Subclient.Rows.Count; j++)
                {

                    bool isChecked = (bool)grd_Db_Subclient[0, j].FormattedValue;
                    if (isChecked == true)
                    {
                        Hashtable htdel = new Hashtable();
                        DataTable dtdel = new DataTable();
                        htdel.Add("@Trans", "DELETE");
                        htdel.Add("@Order_Type_ABS", grd_Db_Subclient.Rows[j].Cells[1].Value.ToString());
                        dtdel = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htdel);
                        check_del = 1;
                    }
                    else
                    {
                        check_list = 1;
                    }
                }
                if (check_del == 0 && check_list == 1)
                {
                    MessageBox.Show("Kindly select any one record to delete");
                    check_list = 0;
                }
                if (check_del == 1)
                {
                    MessageBox.Show("Client Target Matrix Deleted Successfully");
                    check_del = 0;
                    BindDbMatrix();
                    Bind_Emp_Efficiency();
                }
                //cProbar.stopProgress();
            }

        }


        private void chk_Db_Empmatrix_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Db_Empmatrix.Checked == true)
            {
                for (int i = 0; i < grd_Db_Subclient.Rows.Count; i++)
                {
                    grd_Db_Subclient[0, i].Value = true;
                }
            }
            else if (chk_Db_Empmatrix.Checked == false)
            {
                for (int i = 0; i < grd_Db_Subclient.Rows.Count; i++)
                {
                    grd_Db_Subclient[0, i].Value = false;
                }
            }
        }

        private void ck_Ordertype_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Ordertype.Checked == true)
            {
                for (int i = 0; i < grd_OrderType.Rows.Count; i++)
                {
                    grd_OrderType[0, i].Value = true;
                }
            }
            else if (ck_Ordertype.Checked == false)
            {
                for (int i = 0; i < grd_OrderType.Rows.Count; i++)
                {
                    grd_OrderType[0, i].Value = false;
                }

            }
        }

        private void ck_Task_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Task.Checked == true)
            {
                for (int i = 0; i < grd_Order_Task.Rows.Count; i++)
                {
                    grd_Order_Task[0, i].Value = true;
                }
            }
            else if (ck_Task.Checked == false)
            {
                for (int i = 0; i < grd_Order_Task.Rows.Count; i++)
                {
                    grd_Order_Task[0, i].Value = false;
                }
            }

        }

        private void txt_SearchBy_TextChanged(object sender, EventArgs e)
        {
            DataView dtsearch = new DataView(dtsel);
            dtsearch.RowFilter = "Order_Type_ABS like '%" + txt_SearchBy.Text.ToString() + " or Search like '%" + txt_SearchBy.Text.ToString()
                + " or [Search QC] like '%" + txt_SearchBy.Text.ToString() + " or Typing like '%" + txt_SearchBy.Text.ToString()
                + " or [Typing QC] like '%" + txt_SearchBy.Text.ToString() + " or Upload like '%" + txt_SearchBy.Text.ToString() + "%'";
            DataTable dt = new DataTable();
            dt = dtsearch.ToTable();
            if (dt.Rows.Count > 0)
            {
                grd_Db_Subclient.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    grd_Db_Subclient.Rows.Add();
                    grd_Db_Subclient.Rows[i].Cells[1].Value = dt.Rows[i]["Order_Type_ABS"].ToString();
                    grd_Db_Subclient.Rows[i].Cells[2].Value = dt.Rows[i]["Search"].ToString();
                    grd_Db_Subclient.Rows[i].Cells[3].Value = dt.Rows[i]["Search QC"].ToString();
                    grd_Db_Subclient.Rows[i].Cells[4].Value = dt.Rows[i]["Typing"].ToString();
                    grd_Db_Subclient.Rows[i].Cells[5].Value = dt.Rows[i]["Typing QC"].ToString();
                    grd_Db_Subclient.Rows[i].Cells[6].Value = dt.Rows[i]["Upload"].ToString();
                    grd_Db_Subclient.Rows[i].Cells[7].Value = dt.Rows[i]["Search Tax Request"].ToString();
                }
            }
        }

        private void Employee_Efficiency_Matrix_Load(object sender, EventArgs e)
        {
            Hashtable htParam = new Hashtable();
            DataTable dt = new DataTable();
            htParam.Add("@Trans", "ORDERTYPE_Group");
            dt = dataaccess.ExecuteSP("Sp_Order_Type", htParam);
            grd_OrderType.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grd_OrderType.Rows.Add();
                grd_OrderType.Rows[i].Cells[1].Value = dt.Rows[i]["Order_Type_Abrivation"].ToString();
                //grd_OrderType.Rows[i].Cells[2].Value= dt.Rows[i]["Order_Type_ID"].ToString();
            }
            Hashtable htorder = new Hashtable();
            DataTable dtorder = new DataTable();
            htorder.Add("@Trans", "BIND_FOR_ORDER_ALLOCATE");
            dtorder = dataaccess.ExecuteSP("Sp_Order_Status", htorder);
            grd_Order_Task.Rows.Clear();
            for (int i = 0; i < dtorder.Rows.Count; i++)
            {
                grd_Order_Task.Rows.Add();
                grd_Order_Task.Rows[i].Cells[1].Value = dtorder.Rows[i]["Order_Status"].ToString();
                grd_Order_Task.Rows[i].Cells[2].Value = dtorder.Rows[i]["Order_Status_ID"].ToString();
            }
            BindDbMatrix();
            Bind_Emp_Efficiency();
            //Hashtable htselect = new Hashtable();
            //DataTable dtselect = new DataTable();
            //htselect.Add("@Trans", "SELECT");
            //htselect.Add("@Employee_Efficiency_Id", );
            //dtselect = dataaccess.ExecuteSP("Sp_Order_Status", htselect);
            //grd_Db_Subclient.Rows.Clear();
            //for (int i = 0; i < dtorder.Rows.Count; i++)
            //{
            //    grd_Db_Subclient.Rows.Add();
            //    grd_Order_Task.Rows[i].Cells[1].Value = dtorder.Rows[i]["Order_Status"].ToString();
            //    grd_Order_Task.Rows[i].Cells[2].Value = dtorder.Rows[i]["Order_Status_ID"].ToString();
            //}


        }

        private void btn_SaveAll_Click(object sender, EventArgs e)
        {
            
            Hashtable htupdate = new Hashtable();
            DataTable dtupdate = new DataTable();

            Hashtable htinsert = new Hashtable();
            DataTable dtinsert = new DataTable();
            for (int i = 0; i < grd_Employee_Efficiency.Columns.Count; i++)
            {
                
                for (int j = 0; j < grd_Employee_Efficiency.Rows.Count-1; j++)
                {
                    if (grd_Employee_Efficiency.Rows[j].Cells[i].Value.ToString() != "")
                    {
                        //error order type abbreivation
                        Hashtable htorder = new Hashtable();
                        DataTable dtorder = new DataTable();
                        htorder.Add("@Trans", "SEARCH_ORDER_TYPE_ABBR");
                        htorder.Add("Order_Type_Abrivation", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                        dtorder = dataaccess.ExecuteSP("Sp_Order_Type", htorder);
                        if (dtorder.Rows.Count > 0)
                        {
                            abbrid = int.Parse(dtorder.Rows[0]["Order_Type_ID"].ToString());
                        }
                        else
                        {
                            insert_abr = 1;
                        }

                     

                            Hashtable htsearch = new Hashtable();
                            DataTable dtsearch = new DataTable();
                            htsearch.Add("@Trans", "SEARCH_BY_NAME");
                            htsearch.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                            if (Column13.HeaderText == "Search")
                            {
                                htsearch.Add("@Order_Status_id", 2);
                                htsearch.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[1].Value.ToString());
                                dtsearch = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsearch);
                                if (dtsearch.Rows.Count > 0)
                                {
                                    int employe = int.Parse(dtsearch.Rows[0]["Employee_Efficiency_Id"].ToString());
                                    //update
                                    htupdate.Clear(); dtupdate.Clear();
                                    htupdate.Add("@Trans", "UPDATE_BY_ID");
                                    htupdate.Add("@Employee_Efficiency_Id", employe);
                                    htupdate.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htupdate.Add("@Order_Status_id", 2);
                                    htupdate.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[1].Value.ToString());
                                    htupdate.Add("@Modified_By", User_ID);
                                    dtupdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htupdate);
                                }
                                else
                                {
                                    //insert
                                    htinsert.Clear(); dtinsert.Clear();
                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htinsert.Add("@Order_Status_id", 2);
                                    htinsert.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[1].Value.ToString());
                                    htinsert.Add("@Inserted_By", User_ID);
                                    dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                }
                            }
                            if (Column15.HeaderText == "Search QC")
                            {
                                htsearch.Clear(); dtsearch.Clear();
                                htsearch.Add("@Trans", "SEARCH_BY_NAME");
                                htsearch.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                htsearch.Add("@Order_Status_id", 3);
                                htsearch.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                dtsearch = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsearch);
                                if (dtsearch.Rows.Count > 0)
                                {
                                    int employe = int.Parse(dtsearch.Rows[0]["Employee_Efficiency_Id"].ToString());
                                    //update
                                    htupdate.Clear(); dtupdate.Clear();
                                    htupdate.Add("@Trans", "UPDATE_BY_ID");
                                    htupdate.Add("@Employee_Efficiency_Id", employe);
                                    htupdate.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htupdate.Add("@Order_Status_id", 3);
                                    htupdate.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                    htupdate.Add("@Modified_By", User_ID);
                                    dtupdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htupdate);
                                }
                                else
                                {
                                    //insert
                                    htinsert.Clear(); dtinsert.Clear();
                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htinsert.Add("@Order_Status_id", 3);
                                    htinsert.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                    htinsert.Add("@Inserted_By", User_ID);
                                    dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                }
                            }
                            if (Column16.HeaderText == "Typing")
                            {
                                htsearch.Clear(); dtsearch.Clear();
                                htsearch.Add("@Trans", "SEARCH_BY_NAME");

                                htsearch.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                htsearch.Add("@Order_Status_id", 4);
                                htsearch.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[3].Value.ToString());
                                dtsearch = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsearch);
                                if (dtsearch.Rows.Count > 0)
                                {
                                    int employe = int.Parse(dtsearch.Rows[0]["Employee_Efficiency_Id"].ToString());
                                    //update
                                    htupdate.Clear(); dtupdate.Clear();
                                    htupdate.Add("@Trans", "UPDATE_BY_ID");
                                    htupdate.Add("@Employee_Efficiency_Id", employe);
                                    htupdate.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htupdate.Add("@Order_Status_id", 4);
                                    htupdate.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[3].Value.ToString());
                                    htupdate.Add("@Modified_By", User_ID);
                                    dtupdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htupdate);
                                }
                                else
                                {
                                    //insert
                                    htinsert.Clear(); dtinsert.Clear();
                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htinsert.Add("@Order_Status_id", 4);
                                    htinsert.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[3].Value.ToString());
                                    htinsert.Add("@Inserted_By", User_ID);
                                    dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                }
                            }
                            if (Column17.HeaderText == "Typing QC")
                            {
                                htsearch.Clear(); dtsearch.Clear();
                                htsearch.Add("@Trans", "SEARCH_BY_NAME");
                                htsearch.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                htsearch.Add("@Order_Status_id", 7);
                                htsearch.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[4].Value.ToString());
                                dtsearch = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsearch);
                                if (dtsearch.Rows.Count > 0)
                                {
                                    int employe = int.Parse(dtsearch.Rows[0]["Employee_Efficiency_Id"].ToString());
                                    //update
                                    htupdate.Clear(); dtupdate.Clear();
                                    htupdate.Add("@Trans", "UPDATE_BY_ID");
                                    htupdate.Add("@Employee_Efficiency_Id", employe);
                                    htupdate.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htupdate.Add("@Order_Status_id", 7);
                                    htupdate.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[4].Value.ToString());
                                    htupdate.Add("@Modified_By", User_ID);
                                    dtupdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htupdate);
                                }
                                else
                                {
                                    //insert
                                    htinsert.Clear(); dtinsert.Clear();
                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htinsert.Add("@Order_Status_id", 7);
                                    htinsert.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[4].Value.ToString());
                                    htinsert.Add("@Inserted_By", User_ID);
                                    dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                }
                            }
                            if (Column18.HeaderText == "Upload")
                            {
                                htsearch.Clear(); dtsearch.Clear();
                                htsearch.Add("@Trans", "SEARCH_BY_NAME");
                                htsearch.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                htsearch.Add("@Order_Status_id", 12);
                                htsearch.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[5].Value.ToString());
                                dtsearch = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsearch);
                                if (dtsearch.Rows.Count > 0)
                                {
                                    int employe = int.Parse(dtsearch.Rows[0]["Employee_Efficiency_Id"].ToString());
                                    //update
                                    htupdate.Clear(); dtupdate.Clear();
                                    htupdate.Add("@Trans", "UPDATE_BY_ID");
                                    htupdate.Add("@Employee_Efficiency_Id", employe);
                                    htupdate.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htupdate.Add("@Order_Status_id", 12);
                                    htupdate.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[5].Value.ToString());
                                    htupdate.Add("@Modified_By", User_ID);
                                    dtupdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htupdate);
                                }
                                else
                                {
                                    //insert
                                    htinsert.Clear(); dtinsert.Clear();
                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htinsert.Add("@Order_Status_id", 12);
                                    htinsert.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[5].Value.ToString());
                                    htinsert.Add("@Inserted_By", User_ID);
                                    dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                }
                            }

                            if (Column1.HeaderText == "Final QC")
                            {
                                htsearch.Clear(); dtsearch.Clear();
                                htsearch.Add("@Trans", "SEARCH_BY_NAME");
                                htsearch.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                htsearch.Add("@Order_Status_id", 23);
                                htsearch.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                dtsearch = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsearch);
                                if (dtsearch.Rows.Count > 0)
                                {
                                    int employe = int.Parse(dtsearch.Rows[0]["Employee_Efficiency_Id"].ToString());
                                    //update
                                    htupdate.Clear(); dtupdate.Clear();
                                    htupdate.Add("@Trans", "UPDATE_BY_ID");
                                    htupdate.Add("@Employee_Efficiency_Id", employe);
                                    htupdate.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htupdate.Add("@Order_Status_id", 23);
                                    htupdate.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                    htupdate.Add("@Modified_By", User_ID);
                                    dtupdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htupdate);
                                }
                                else
                                {
                                    //insert
                                    htinsert.Clear(); dtinsert.Clear();
                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htinsert.Add("@Order_Status_id", 23);
                                    htinsert.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                    htinsert.Add("@Inserted_By", User_ID);
                                    dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                }
                            }

                            if (Column1.HeaderText == "Tax")
                            {
                                htsearch.Clear(); dtsearch.Clear();
                                htsearch.Add("@Trans", "SEARCH_BY_NAME");
                                htsearch.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                htsearch.Add("@Order_Status_id", 22);
                                htsearch.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                dtsearch = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htsearch);
                                if (dtsearch.Rows.Count > 0)
                                {
                                    int employe = int.Parse(dtsearch.Rows[0]["Employee_Efficiency_Id"].ToString());
                                    //update
                                    htupdate.Clear(); dtupdate.Clear();
                                    htupdate.Add("@Trans", "UPDATE_BY_ID");
                                    htupdate.Add("@Employee_Efficiency_Id", employe);
                                    htupdate.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htupdate.Add("@Order_Status_id", 22);
                                    htupdate.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                    htupdate.Add("@Modified_By", User_ID);
                                    dtupdate = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htupdate);
                                }
                                else
                                {
                                    //insert
                                    htinsert.Clear(); dtinsert.Clear();
                                    htinsert.Add("@Trans", "INSERT");
                                    htinsert.Add("@Order_Type_ABS", grd_Employee_Efficiency.Rows[j].Cells[0].Value.ToString());
                                    htinsert.Add("@Order_Status_id", 22);
                                    htinsert.Add("@Allocated_Time", grd_Employee_Efficiency.Rows[j].Cells[2].Value.ToString());
                                    htinsert.Add("@Inserted_By", User_ID);
                                    dtinsert = dataaccess.ExecuteSP("Sp_Employee_Efficiency", htinsert);
                                }
                            }
                        }
                       
                        
                        

                    
                    
                }
                
            }
           
              MessageBox.Show("Record updated successfully");
                Bind_Emp_Efficiency();

            
        }
    }
}
