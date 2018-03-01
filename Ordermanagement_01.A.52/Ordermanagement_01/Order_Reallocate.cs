using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ordermanagement_01
{

    public partial class Order_Reallocate : Form
    {
          Commonclass Comclass = new Commonclass();
            DataAccess dataAccess = new DataAccess();
            DropDownistBindClass dbc = new DropDownistBindClass();
            int Order_Id; string userroleid;
        int userid, External_Client_Order_Id, External_Client_Order_Task_Id, Check_External_Production,Max_Time_Id;
        int Differnce_Time;

        //=========================Vendors==========================================
        string Vendor_Id;
        string lbl_Order_Type_Id;
        int Order_Type_Abs_Id, Client_Id, Sub_Process_Id;


        int Vendor_Total_No_Of_Order_Recived, Vendor_No_Of_Order_For_each_Vendor, Vendor_Order_capacity;
        decimal Vendor_Order_Percentage;
        int No_Of_Order_Assignd_for_Vendor;
        string Vendor_Date, lbl_Order_Id;
     

        //===========================================================================================


        public Order_Reallocate(int User_ID, string UserRoleid)
        {

            userid = User_ID;
            userroleid = UserRoleid;
            InitializeComponent();
            dbc.BindUserName_Allocate(ddl_UserName);
            dbc.BindOrderStatus_For_Reallocate(ddl_Order_Status_Reallocate);
            dbc.Bind_Order_Progress_FOR_REAALOCATE(ddl_Order_Progress);
        }

        private void btn_Reallocate_Click(object sender, EventArgs e)
        {
            if (txt_Order_number.Text != "" && ddl_UserName.SelectedItem != "" && ddl_Order_Status_Reallocate.SelectedItem != "" && ddl_Order_Status_Reallocate.SelectedItem != "SELECT" && ddl_UserName.SelectedItem != "SELECT" && ddl_UserName.SelectedIndex > 0 && ddl_Order_Status_Reallocate.SelectedIndex > 0)
            {
                //  Label lbl_Order_Id = (Label)row.FindControl("lblAllocatedOrder_id");
                //  string  Label lbl_Order_Id = (Label)row.FindControl("lblAllocatedOrder_id");


               // userid = int.Parse(ddl_UserName.SelectedValue.ToString());
                Hashtable htselect_Orderid = new Hashtable();
                DataTable dtselect_Orderid = new System.Data.DataTable();
                htselect_Orderid.Add("@Trans", "SELECT_ORDER_NO_WISE");
                htselect_Orderid.Add("@Client_Order_Number", txt_Order_number.Text);
                dtselect_Orderid = dataAccess.ExecuteSP("Sp_Order", htselect_Orderid);
                Order_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Id"].ToString());
                Client_Id = int.Parse(dtselect_Orderid.Rows[0]["Client_Id"].ToString());
                Sub_Process_Id = int.Parse(dtselect_Orderid.Rows[0]["Sub_ProcessId"].ToString());
                int Abs_Staus_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Status_Id"].ToString());
                int Abs_Progress_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Progress"].ToString());


                Hashtable htget_User_Order_Last_Time_Updaetd = new Hashtable();
                DataTable dtget_User_Order_Last_Time_Updated = new DataTable();

                htget_User_Order_Last_Time_Updaetd.Add("@Trans", "MAX_TIME_BY_ORDER_ID");
                htget_User_Order_Last_Time_Updaetd.Add("@Order_Id", Order_Id);
                dtget_User_Order_Last_Time_Updated = dataAccess.ExecuteSP("[Sp_Order_User_Wise_Time_Track]", htget_User_Order_Last_Time_Updaetd);

                if (dtget_User_Order_Last_Time_Updated.Rows.Count > 0)
                {
                    Max_Time_Id = int.Parse(dtget_User_Order_Last_Time_Updated.Rows[0]["MAX_TIME_ID"].ToString());

                }
                else
                {

                    Max_Time_Id = 0;
                }

                if (Max_Time_Id != 0)
                {

                    Hashtable htget_User_Order_Differnce_Time = new Hashtable();
                    DataTable dtget_User_Order_Differnce_Time = new DataTable();
                    htget_User_Order_Differnce_Time.Add("@Trans", "GET_DIFFERNCE_TIME");
                    htget_User_Order_Differnce_Time.Add("@Order_Time_Id", Max_Time_Id);
                    dtget_User_Order_Differnce_Time = dataAccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htget_User_Order_Differnce_Time);

                     if (dtget_User_Order_Differnce_Time.Rows.Count > 0)
                    {
                        Differnce_Time = int.Parse(dtget_User_Order_Differnce_Time.Rows[0]["Diff"].ToString());

                    }
                    else
                    {
                        Differnce_Time = 0;

                    }

                    //htget_User_Order_Differnce_Time.Add("","");
                }





                if (Abs_Staus_Id == 20)
                {


                    MessageBox.Show("This Order is Assigned To Vendor and It will Not Reallocate");




                }

                else if (Abs_Progress_Id != 6 && Abs_Progress_Id != 8 && Abs_Progress_Id != 1 && Abs_Progress_Id != 3 && Abs_Progress_Id != 4 && Abs_Progress_Id!=5)
                    {


                 if (Abs_Staus_Id != 17 && Abs_Staus_Id != 20 && Differnce_Time < 5)
                {
                   

                        MessageBox.Show("This Order is in Work in Progress you can't Reallocate");
                    

                }
                     }


                else if (Abs_Staus_Id != 17 && Abs_Staus_Id != 20)
                {
                    if (Differnce_Time > 5 || Differnce_Time==0)
                    {

                        string lbl_Allocated_Userid = ddl_UserName.ValueMember;
                        Hashtable htchk_Assign = new Hashtable();
                        DataTable dtchk_Assign = new System.Data.DataTable();
                        htchk_Assign.Add("@Trans", "ORDER_ASSIGN_VERIFY");
                        htchk_Assign.Add("@Order_Id", Order_Id);
                        dtchk_Assign = dataAccess.ExecuteSP("Sp_Order_Assignment", htchk_Assign);
                        if (dtchk_Assign.Rows.Count <= 0)
                        {
                            Hashtable htupassin = new Hashtable();
                            DataTable dtupassign = new DataTable();

                            htupassin.Add("@Trans", "DELET_BY_ORDER");
                            htupassin.Add("@Order_Id", Order_Id);
                            //  htinsert_Assign.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            // htinsert_Assign.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            //  htinsert_Assign.Add("@Order_Progress_Id", 6);
                            // htinsert_Assign.Add("@Assigned_Date", Convert.ToString(dateeval));

                            dtupassign = dataAccess.ExecuteSP("Sp_Order_Assignment", htupassin);


                            Hashtable htinsert_Assign = new Hashtable();
                            DataTable dtinsertrec_Assign = new System.Data.DataTable();
                            htinsert_Assign.Add("@Trans", "INSERT");
                            htinsert_Assign.Add("@Order_Id", Order_Id);
                            //  htinsert_Assign.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            // htinsert_Assign.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            //  htinsert_Assign.Add("@Order_Progress_Id", 6);
                            // htinsert_Assign.Add("@Assigned_Date", Convert.ToString(dateeval));
                            htinsert_Assign.Add("@Assigned_By", userid);
                            htinsert_Assign.Add("@Modified_By", userid);
                            htinsert_Assign.Add("@Modified_Date", DateTime.Now);
                            htinsert_Assign.Add("@status", "True");
                            dtinsertrec_Assign = dataAccess.ExecuteSP("Sp_Order_Assignment", htinsert_Assign);
                        }
                        //  int Allocated_Userid = int.Parse(lbl_Allocated_Userid.Text);

                        Hashtable htinsertrec = new Hashtable();
                        DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");

                        htinsertrec.Add("@Trans", "UPDATE_REALLOCATE");
                        htinsertrec.Add("@Order_Id", Order_Id);
                        htinsertrec.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        htinsertrec.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htinsertrec.Add("@Order_Progress_Id", 6);
                        htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
                        htinsertrec.Add("@Assigned_By", userid);
                        htinsertrec.Add("@Modified_By", userid);
                        htinsertrec.Add("@Modified_Date", DateTime.Now);
                        htinsertrec.Add("@status", "True");
                        dtinsertrec = dataAccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);


                        Hashtable htorderStatus = new Hashtable();
                        DataTable dtorderStatus = new DataTable();
                        htorderStatus.Add("@Trans", "UPDATE_STATUS");
                        htorderStatus.Add("@Order_ID", Order_Id);
                        htorderStatus.Add("@Order_Status", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus.Add("@Modified_By", userid);
                        htorderStatus.Add("@Modified_Date", date);
                        dtorderStatus = dataAccess.ExecuteSP("Sp_Order", htorderStatus);
                        Hashtable htorderStatus_Allocate = new Hashtable();
                        DataTable dtorderStatus_Allocate = new DataTable();
                        htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
                        htorderStatus_Allocate.Add("@Order_ID", Order_Id);
                        htorderStatus_Allocate.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_By", userid);
                        htorderStatus_Allocate.Add("@Assigned_Date", Convert.ToString(dateeval));
                        htorderStatus_Allocate.Add("@Assigned_By", userid);
                        htorderStatus_Allocate.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_Date", date);
                        dtorderStatus_Allocate = dataAccess.ExecuteSP("Sp_Order_Assignment", htorderStatus_Allocate);


                        Hashtable htupdate_Prog = new Hashtable();
                        DataTable dtupdate_Prog = new System.Data.DataTable();
                        htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                        htupdate_Prog.Add("@Order_ID", Order_Id);
                        htupdate_Prog.Add("@Order_Progress", 6);
                        htupdate_Prog.Add("@Modified_By", userid);
                        htupdate_Prog.Add("@Modified_Date", DateTime.Now);
                        dtupdate_Prog = dataAccess.ExecuteSP("Sp_Order", htupdate_Prog);


                        //OrderHistory
                        Hashtable ht_Order_History = new Hashtable();
                        DataTable dt_Order_History = new DataTable();
                        ht_Order_History.Add("@Trans", "INSERT");
                        ht_Order_History.Add("@Order_Id", Order_Id);
                        ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        ht_Order_History.Add("@Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        ht_Order_History.Add("@Progress_Id", 6);
                        ht_Order_History.Add("@Work_Type", 1);
                        ht_Order_History.Add("@Assigned_By", userid);
                        ht_Order_History.Add("@Modification_Type", "Order Reallocate");
                        dt_Order_History = dataAccess.ExecuteSP("Sp_Order_History", ht_Order_History);

                        Hashtable ht_Update_Emp_Status = new Hashtable();
                        DataTable dt_Update_Emp_Status = new DataTable();
                        ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                        ht_Update_Emp_Status.Add("@Employee_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        ht_Update_Emp_Status.Add("@Allocate_Status", "True");
                        dt_Update_Emp_Status = dataAccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);




                        //==================================External Client_Vendor_Orders(Titlelogy)=====================================================


                        Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                        System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                        htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                        htCheck_Order_InTitlelogy.Add("@Order_ID", Order_Id);
                        dt_Order_InTitleLogy = dataAccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                        if (dt_Order_InTitleLogy.Rows.Count > 0)
                        {

                            External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                            External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());

                           
                            // if The Db title client for Titlelogy No Need to Update Status 33 -->Db Title

                            if (External_Client_Order_Task_Id != 18 && Client_Id!=33)
                            {

                                Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_TASK_STATUS");
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Task", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Status", 14);

                                dt_TitleLogy_Order_Task_Status = dataAccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);


                            }


                        }

                        //   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('Order Reallocated Successfully')</script>", false);





                        htchk_Assign.Clear();
                        dtchk_Assign.Clear();
                        htchk_Assign.Add("@Trans", "ORDER_ASSIGN_VERIFY");
                        htchk_Assign.Add("@Order_Id", Order_Id);
                        dtchk_Assign = dataAccess.ExecuteSP("Sp_Order_Assignment", htchk_Assign);
                        if (dtchk_Assign.Rows.Count <= 0)
                        {
                            Hashtable htinsert_Assign = new Hashtable();
                            DataTable dtinsertrec_Assign = new System.Data.DataTable();
                            htinsert_Assign.Add("@Trans", "INSERT");
                            htinsert_Assign.Add("@Order_Id", Order_Id);
                            //  htinsert_Assign.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            // htinsert_Assign.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                            //  htinsert_Assign.Add("@Order_Progress_Id", 6);
                            // htinsert_Assign.Add("@Assigned_Date", Convert.ToString(dateeval));
                            htinsert_Assign.Add("@Assigned_By", userid);
                            htinsert_Assign.Add("@Modified_By", userid);
                            htinsert_Assign.Add("@Modified_Date", DateTime.Now);
                            htinsert_Assign.Add("@status", "True");
                            dtinsertrec_Assign = dataAccess.ExecuteSP("Sp_Order_Assignment", htinsert_Assign);
                        }
                        //  int Allocated_Userid = int.Parse(lbl_Allocated_Userid.Text);

                        htinsertrec.Clear();
                        dtinsertrec.Clear();
                        //DateTime date = new DateTime();
                        //date = DateTime.Now;
                        //string dateeval = date.ToString("dd/MM/yyyy");
                        //string time = date.ToString("hh:mm tt");

                        htinsertrec.Add("@Trans", "UPDATE_REALLOCATE");
                        htinsertrec.Add("@Order_Id", Order_Id);
                        htinsertrec.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        htinsertrec.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htinsertrec.Add("@Order_Progress_Id", 6);
                        htinsertrec.Add("@Assigned_Date", Convert.ToString(dateeval));
                        htinsertrec.Add("@Assigned_By", userid);
                        htinsertrec.Add("@Modified_By", userid);
                        htinsertrec.Add("@Modified_Date", DateTime.Now);
                        htinsertrec.Add("@status", "True");
                        dtinsertrec = dataAccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);
                        htorderStatus.Clear();
                        dtorderStatus.Clear();
                        htorderStatus.Add("@Trans", "UPDATE_STATUS");
                        htorderStatus.Add("@Order_ID", Order_Id);
                        htorderStatus.Add("@Order_Status", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus.Add("@Modified_By", userid);
                        htorderStatus.Add("@Modified_Date", date);
                        dtorderStatus = dataAccess.ExecuteSP("Sp_Order", htorderStatus);
                        htorderStatus_Allocate.Clear();
                        dtorderStatus_Allocate.Clear();
                        htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
                        htorderStatus_Allocate.Add("@Order_ID", Order_Id);
                        htorderStatus_Allocate.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_By", userid);
                        htorderStatus_Allocate.Add("@Assigned_Date", Convert.ToString(dateeval));
                        htorderStatus_Allocate.Add("@Assigned_By", userid);
                        htorderStatus_Allocate.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_Date", date);
                        dtorderStatus_Allocate = dataAccess.ExecuteSP("Sp_Order_Assignment", htorderStatus_Allocate);
                        htupdate_Prog.Clear();
                        dtupdate_Prog.Clear();
                        htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                        htupdate_Prog.Add("@Order_ID", Order_Id);
                        htupdate_Prog.Add("@Order_Progress", 6);
                        htupdate_Prog.Add("@Modified_By", userid);
                        htupdate_Prog.Add("@Modified_Date", DateTime.Now);
                        dtupdate_Prog = dataAccess.ExecuteSP("Sp_Order", htupdate_Prog);


                        ht_Update_Emp_Status.Clear();
                        dt_Update_Emp_Status.Clear();
                        ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                        ht_Update_Emp_Status.Add("@Employee_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        ht_Update_Emp_Status.Add("@Allocate_Status", "True");
                        dt_Update_Emp_Status = dataAccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);

                        MessageBox.Show("Order Reallocated Successfully");
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Order Is in Work in Progress Please Wait a moment or Inform to User to Close the Order");


                    }

                }
                else
                {

                    MessageBox.Show("Abstractor Order Cannot be Reallocate");

                }



            }
            else
            {
                MessageBox.Show("Please Select Username and Task");

            }
        }
      
    
        private void Clear()
        {
            txt_Order_number.Text = "";
            ddl_UserName.SelectedIndex = 0;
            ddl_Order_Status_Reallocate.SelectedIndex = 0;
        }

        private void btn_deallocate_Click(object sender, EventArgs e)
        {
            if (txt_Order_number.Text != "" && ddl_Order_Status_Reallocate.SelectedItem != "" && ddl_Order_Status_Reallocate.SelectedItem != "SELECT" && ddl_Order_Status_Reallocate.SelectedIndex > 0)
            {
                int User_Dealocated = 0;
                Hashtable htselect_Orderid = new Hashtable();
                DataTable dtselect_Orderid = new System.Data.DataTable();
                htselect_Orderid.Add("@Trans", "SELECT_ORDER_NO_WISE");
                htselect_Orderid.Add("@Client_Order_Number", txt_Order_number.Text);
                dtselect_Orderid = dataAccess.ExecuteSP("Sp_Order", htselect_Orderid);
                Order_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Id"].ToString());
                int Abs_Staus_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Status_Id"].ToString());
                int Abs_Progress_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Progress"].ToString());


                Hashtable htget_User_Order_Last_Time_Updaetd = new Hashtable();
                DataTable dtget_User_Order_Last_Time_Updated = new DataTable();

                htget_User_Order_Last_Time_Updaetd.Add("@Trans", "MAX_TIME_BY_ORDER_ID");
                htget_User_Order_Last_Time_Updaetd.Add("@Order_Id", Order_Id);
                dtget_User_Order_Last_Time_Updated = dataAccess.ExecuteSP("[Sp_Order_User_Wise_Time_Track]", htget_User_Order_Last_Time_Updaetd);

                if (dtget_User_Order_Last_Time_Updated.Rows.Count > 0)
                {
                    Max_Time_Id = int.Parse(dtget_User_Order_Last_Time_Updated.Rows[0]["MAX_TIME_ID"].ToString());

                }
                else
                {

                    Max_Time_Id = 0;
                }

                if (Max_Time_Id != 0)
                {

                    Hashtable htget_User_Order_Differnce_Time = new Hashtable();
                    DataTable dtget_User_Order_Differnce_Time = new DataTable();
                    htget_User_Order_Differnce_Time.Add("@Trans", "GET_DIFFERNCE_TIME");
                    htget_User_Order_Differnce_Time.Add("@Order_Time_Id", Max_Time_Id);
                    dtget_User_Order_Differnce_Time = dataAccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htget_User_Order_Differnce_Time);

                    if (dtget_User_Order_Differnce_Time.Rows.Count > 0)
                    {
                        Differnce_Time = int.Parse(dtget_User_Order_Differnce_Time.Rows[0]["Diff"].ToString());

                    }
                    else
                    {
                        Differnce_Time = 0;

                    }

                    //htget_User_Order_Differnce_Time.Add("","");
                }




                if (Abs_Staus_Id == 20)
                {


                    MessageBox.Show("This Order is Assigned To Vendor and It will Not Deallocate");


                }
                else if (Abs_Staus_Id != 17 && Abs_Staus_Id != 20 && Differnce_Time < 5 && Differnce_Time>0)
                {


                    MessageBox.Show("This Order is in Work in Progress you can't Deallocate");

                }


                else if (Abs_Staus_Id != 17 && Abs_Staus_Id != 20)
                {
                    if (Differnce_Time > 5 || Differnce_Time==0)
                    {
                        string lbl_Allocated_Userid = ddl_UserName.ValueMember;
                        Hashtable htinsertrec = new Hashtable();
                        DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");

                        htinsertrec.Add("@Trans", "UPDATE_DEALLOCATE");
                        htinsertrec.Add("@Order_Id", Order_Id);
                        htinsertrec.Add("@Modified_By", userid);

                        dtinsertrec = dataAccess.ExecuteSP("Sp_Order_Assignment", htinsertrec);


                        //Hashtable ht_Update_Emp_Status = new Hashtable();
                        //DataTable dt_Update_Emp_Status = new DataTable();
                        //ht_Update_Emp_Status.Add("@Trans", "Update_Allocate_Status");
                        //ht_Update_Emp_Status.Add("@Employee_Id", userid);
                        //ht_Update_Emp_Status.Add("@Allocate_Status", "False");
                        //dt_Update_Emp_Status = dataAccess.ExecuteSP("Sp_Employee_Status", ht_Update_Emp_Status);


                        Hashtable htorderStatus = new Hashtable();
                        DataTable dtorderStatus = new DataTable();
                        htorderStatus.Add("@Trans", "UPDATE_STATUS");
                        htorderStatus.Add("@Order_ID", Order_Id);
                        htorderStatus.Add("@Order_Status", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus.Add("@Modified_By", userid);
                        htorderStatus.Add("@Modified_Date", date);
                        dtorderStatus = dataAccess.ExecuteSP("Sp_Order", htorderStatus);

                        Hashtable htupdate_Prog = new Hashtable();
                        DataTable dtupdate_Prog = new System.Data.DataTable();
                        htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                        htupdate_Prog.Add("@Order_ID", Order_Id);
                        htupdate_Prog.Add("@Order_Progress", 8);
                        htupdate_Prog.Add("@Modified_By", userid);
                        htupdate_Prog.Add("@Modified_Date", DateTime.Now);
                        //OrderHistory
                        Hashtable ht_Order_History = new Hashtable();
                        DataTable dt_Order_History = new DataTable();
                        ht_Order_History.Add("@Trans", "INSERT");
                        ht_Order_History.Add("@Order_Id", Order_Id);
                        //ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                        ht_Order_History.Add("@Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        ht_Order_History.Add("@Progress_Id", 8);
                        ht_Order_History.Add("@Assigned_By", userid);
                        ht_Order_History.Add("@Work_Type", 1);
                        ht_Order_History.Add("@Modification_Type", "Order Deallocate");
                        dt_Order_History = dataAccess.ExecuteSP("Sp_Order_History", ht_Order_History);





                        Hashtable htorderStatus_Allocate = new Hashtable();
                        DataTable dtorderStatus_Allocate = new DataTable();
                        htorderStatus_Allocate.Add("@Trans", "UPDATE_REALLOCATE_STATUS");
                        htorderStatus_Allocate.Add("@Order_ID", Order_Id);
                        htorderStatus_Allocate.Add("@Order_Status_Id", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                        htorderStatus_Allocate.Add("@Modified_By", userid);
                        htorderStatus_Allocate.Add("@Modified_Date", date);
                        dtorderStatus_Allocate = dataAccess.ExecuteSP("Sp_Order_Assignment", htorderStatus_Allocate);



                        dtupdate_Prog = dataAccess.ExecuteSP("Sp_Order", htupdate_Prog);


                        //==================================External Client_Vendor_Orders(Titlelogy)=====================================================


                        Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                        System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                        htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                        htCheck_Order_InTitlelogy.Add("@Order_ID", Order_Id);
                        dt_Order_InTitleLogy = dataAccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                        if (dt_Order_InTitleLogy.Rows.Count > 0)
                        {

                            External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                            External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());



                            if (External_Client_Order_Task_Id != 18)
                            {

                                Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_TASK_STATUS");
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Task", int.Parse(ddl_Order_Status_Reallocate.SelectedValue.ToString()));
                                ht_Titlelogy_Order_Task_Status.Add("@Order_Status", 14);

                                dt_TitleLogy_Order_Task_Status = dataAccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);

                            }



                        }

                        MessageBox.Show("Order Deallocated Successfully");
                        //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('Order Deallocated Successfully')</script>", false);
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Order Is in Work in Progress Please Wait a moment");
                    

                    }
                }
                else
                {
                    MessageBox.Show("Abstractor Order Cannaot be Deallocate ");
                }
           
        }
        else
    {
     MessageBox.Show("Please Select Task");


    }
        }



        private void txt_Order_number_TextChanged(object sender, EventArgs e)
        {

            if (txt_Order_number.Text != "")
            {
                Hashtable htselect = new Hashtable();
                System.Data.DataTable dtselect = new System.Data.DataTable();
                string OrderNumber = txt_Order_number.Text.ToString();


                htselect.Add("@Trans", "SELECT_ORDER_NO_WISE");
                htselect.Add("@Client_Order_Number", OrderNumber);
                dtselect = dataAccess.ExecuteSP("Sp_Order", htselect);


                if (dtselect.Rows.Count > 0)
                {
                    grd_order.Rows.Clear();
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        grd_order.Rows.Add();
                        grd_order.Rows[i].Cells[0].Value = dtselect.Rows[i]["Client_Order_Number"].ToString();
                        grd_order.Rows[i].Cells[1].Value = dtselect.Rows[i]["Order_Number"].ToString();
                        if (userroleid == "1")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Name"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Sub_ProcessName"].ToString();
                        }
                        else if (userroleid == "2")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Number"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Subprocess_Number"].ToString();
                        }
                        grd_order.Rows[i].Cells[4].Value = dtselect.Rows[i]["Date"].ToString();
                        grd_order.Rows[i].Cells[5].Value = dtselect.Rows[i]["Order_Type"].ToString();
                        grd_order.Rows[i].Cells[6].Value = dtselect.Rows[i]["Client_Order_Ref"].ToString();
                        grd_order.Rows[i].Cells[7].Value = dtselect.Rows[i]["County_Type"].ToString();
                        grd_order.Rows[i].Cells[8].Value = dtselect.Rows[i]["County"].ToString();
                        grd_order.Rows[i].Cells[9].Value = dtselect.Rows[i]["State"].ToString();
                        grd_order.Rows[i].Cells[10].Value = dtselect.Rows[i]["Order_Status"].ToString();
                        grd_order.Rows[i].Cells[11].Value = dtselect.Rows[i]["Progress_Status"].ToString();
                        grd_order.Rows[i].Cells[12].Value = dtselect.Rows[i]["User_Name"].ToString();
                        grd_order.Rows[i].Cells[13].Value = dtselect.Rows[i]["Order_ID"].ToString();
                        grd_order.Rows[i].Cells[14].Value = dtselect.Rows[i]["Client_Id"].ToString();
                        grd_order.Rows[i].Cells[15].Value = dtselect.Rows[i]["Sub_ProcessId"].ToString();
                        grd_order.Rows[i].Cells[17].Value = dtselect.Rows[i]["Tax_Task"].ToString();
                        grd_order.Rows[i].Cells[18].Value = dtselect.Rows[i]["Tax_Team_Status"].ToString();
                        grd_order.Rows[i].Cells[19].Value = dtselect.Rows[i]["Tax_Internal_Task_Status"].ToString();
                        grd_order.Rows[i].Cells[20].Value = dtselect.Rows[i]["Tax_Task_Internal_User"].ToString();
                       

                    }

                }
                else
                {
                    grd_order.Visible = true;
                    grd_order.DataSource = null;

                }
            }
            else
            {

                grd_order.Rows.Clear();

            }

        }

        private void grd_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {

                    Ordermanagement_01.Order_Entry OrderEntry = new Ordermanagement_01.Order_Entry(int.Parse(grd_order.Rows[e.RowIndex].Cells[13].Value.ToString()), userid, userroleid);
                    OrderEntry.Show();
                }
            }
        }

        private void Order_Reallocate_Load(object sender, EventArgs e)
        {
            Rb_Task_CheckedChanged( sender,  e);
            dbc.Bind_Vendors(ddl_Vendor_Name);
        }

        private void Rb_Task_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Task.Checked == true)
            {
                grd_order.Rows.Clear();
                rb_Status.Checked = false;
                group_Task.Visible = true;
                group_Status.Visible = false;
                grp_Vendor.Visible = false;
                txt_Order_number.Text = "";
                ddl_Order_Status_Reallocate.SelectedIndex = 0;
                ddl_UserName.SelectedIndex = 0;
                
            }
        }

        private void rb_Status_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Status.Checked == true)
            {
                group_Status.Text = "Moce To Status";
                grd_order.Rows.Clear();
                Rb_Task.Checked = false;
                group_Task.Visible = false;
                group_Status.Visible = true;
                lbl_Status.Visible = true;
                ddl_Order_Progress.Visible = true;
                grp_Vendor.Visible = false;
                txt_Order_Status_Order_Number.Text = "";
                ddl_Order_Progress.SelectedIndex = 0;

            }

        }

        private void txt_Order_Status_Order_Number_TextChanged(object sender, EventArgs e)
        {
            if (txt_Order_Status_Order_Number.Text != "")
            {

                Hashtable htselect = new Hashtable();
                System.Data.DataTable dtselect = new System.Data.DataTable();
                string OrderNumber = txt_Order_Status_Order_Number.Text.ToString();


                htselect.Add("@Trans", "SELECT_ORDER_NO_WISE");
                htselect.Add("@Client_Order_Number", OrderNumber);
                dtselect = dataAccess.ExecuteSP("Sp_Order", htselect);


                if (dtselect.Rows.Count > 0)
                {
                    grd_order.Rows.Clear();
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        grd_order.Rows.Add();
                        grd_order.Rows[i].Cells[0].Value = dtselect.Rows[i]["Client_Order_Number"].ToString();
                        grd_order.Rows[i].Cells[1].Value = dtselect.Rows[i]["Order_Number"].ToString();
                        if (userroleid == "1")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Name"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Sub_ProcessName"].ToString();
                        }
                        else if (userroleid == "2")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Number"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Subprocess_Number"].ToString();
                        }
                        grd_order.Rows[i].Cells[4].Value = dtselect.Rows[i]["Date"].ToString();
                        grd_order.Rows[i].Cells[5].Value = dtselect.Rows[i]["Order_Type"].ToString();
                        grd_order.Rows[i].Cells[6].Value = dtselect.Rows[i]["Client_Order_Ref"].ToString();
                        grd_order.Rows[i].Cells[7].Value = dtselect.Rows[i]["County_Type"].ToString();
                        grd_order.Rows[i].Cells[8].Value = dtselect.Rows[i]["County"].ToString();
                        grd_order.Rows[i].Cells[9].Value = dtselect.Rows[i]["State"].ToString();
                        grd_order.Rows[i].Cells[10].Value = dtselect.Rows[i]["Order_Status"].ToString();
                        grd_order.Rows[i].Cells[11].Value = dtselect.Rows[i]["Progress_Status"].ToString();
                        grd_order.Rows[i].Cells[12].Value = dtselect.Rows[i]["User_Name"].ToString();
                        grd_order.Rows[i].Cells[13].Value = dtselect.Rows[i]["Order_ID"].ToString();
                        grd_order.Rows[i].Cells[14].Value = dtselect.Rows[i]["Client_Id"].ToString();
                        grd_order.Rows[i].Cells[15].Value = dtselect.Rows[i]["Sub_ProcessId"].ToString();
                        //  grd_order.Rows[i].Cells[12].Value = "Delete";
                        // DataGridViewButtonColumn btn_Orderid = (DataGridViewButtonColumn)grd_order.SelectedColumns[0];
                        //   DataGridViewButtonColumn btn_Delete = (DataGridViewButtonColumn)grd_order.SelectedColumns[11];
                        //   btn_Orderid.DefaultCellStyle.BackColor = System.Drawing.Color.RoyalBlue;
                        //btn_Delete.DefaultCellStyle.BackColor = System.Drawing.Color.RoyalBlue;

                    }

                }
                else
                {
                    grd_order.Visible = true;
                    grd_order.DataSource = null;

                }
            }
            else
            {

                grd_order.Rows.Clear();
            }
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (rb_Status.Checked == true)
            {
                if (validate_Status() != false && Checkvalidate_Order_Assigned() != false)
                {
                    Hashtable htselect_Orderid = new Hashtable();
                    DataTable dtselect_Orderid = new System.Data.DataTable();
                    htselect_Orderid.Add("@Trans", "SELECT_ORDER_NO_WISE");
                    htselect_Orderid.Add("@Client_Order_Number", txt_Order_Status_Order_Number.Text);
                    dtselect_Orderid = dataAccess.ExecuteSP("Sp_Order", htselect_Orderid);
                    Order_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Id"].ToString());
                    Client_Id = int.Parse(dtselect_Orderid.Rows[0]["Client_Id"].ToString());
                    Sub_Process_Id = int.Parse(dtselect_Orderid.Rows[0]["Sub_ProcessId"].ToString());
                    int Abs_Staus_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Status_Id"].ToString());
                    int Abs_Progress_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Progress"].ToString());
                    Hashtable htget_User_Order_Last_Time_Updaetd = new Hashtable();
                    DataTable dtget_User_Order_Last_Time_Updated = new DataTable();

                    htget_User_Order_Last_Time_Updaetd.Add("@Trans", "MAX_TIME_BY_ORDER_ID");
                    htget_User_Order_Last_Time_Updaetd.Add("@Order_Id", Order_Id);
                    dtget_User_Order_Last_Time_Updated = dataAccess.ExecuteSP("[Sp_Order_User_Wise_Time_Track]", htget_User_Order_Last_Time_Updaetd);

                    if (dtget_User_Order_Last_Time_Updated.Rows.Count > 0)
                    {
                        Max_Time_Id = int.Parse(dtget_User_Order_Last_Time_Updated.Rows[0]["MAX_TIME_ID"].ToString());

                    }
                    else
                    {

                        Max_Time_Id = 0;
                    }

                    if (Max_Time_Id != 0)
                    {

                        Hashtable htget_User_Order_Differnce_Time = new Hashtable();
                        DataTable dtget_User_Order_Differnce_Time = new DataTable();
                        htget_User_Order_Differnce_Time.Add("@Trans", "GET_DIFFERNCE_TIME");
                        htget_User_Order_Differnce_Time.Add("@Order_Time_Id", Max_Time_Id);
                        dtget_User_Order_Differnce_Time = dataAccess.ExecuteSP("Sp_Order_User_Wise_Time_Track", htget_User_Order_Differnce_Time);

                        if (dtget_User_Order_Differnce_Time.Rows.Count > 0)
                        {
                            Differnce_Time = int.Parse(dtget_User_Order_Differnce_Time.Rows[0]["Diff"].ToString());

                        }
                        else
                        {
                            Differnce_Time = 0;

                        }

                        //htget_User_Order_Differnce_Time.Add("","");
                    }


                    if (Abs_Staus_Id != 17)
                    {

                        if (Differnce_Time > 5 || Differnce_Time==0)
                        {

                            int Order_PRogress = int.Parse(ddl_Order_Progress.SelectedValue.ToString());

                            Hashtable htupdate_Prog = new Hashtable();
                            DataTable dtupdate_Prog = new System.Data.DataTable();
                            htupdate_Prog.Add("@Trans", "UPDATE_PROGRESS");
                            htupdate_Prog.Add("@Order_ID", Order_Id);
                            htupdate_Prog.Add("@Order_Progress", Order_PRogress);
                            htupdate_Prog.Add("@Modified_By", userid);
                            htupdate_Prog.Add("@Modified_Date", DateTime.Now);
                            dtupdate_Prog = dataAccess.ExecuteSP("Sp_Order", htupdate_Prog);
                            MessageBox.Show("Status Updated Sucessfully");

                            //OrderHistory
                            Hashtable ht_Order_History = new Hashtable();
                            DataTable dt_Order_History = new DataTable();
                            ht_Order_History.Add("@Trans", "INSERT");
                            ht_Order_History.Add("@Order_Id", Order_Id);
                            //  ht_Order_History.Add("@User_Id", int.Parse(ddl_UserName.SelectedValue.ToString()));
                            ht_Order_History.Add("@Status_Id", Abs_Staus_Id);
                            ht_Order_History.Add("@Progress_Id", Order_PRogress);
                            ht_Order_History.Add("@Assigned_By", userid);
                            ht_Order_History.Add("@Modification_Type", "Order Status Changed to " + ddl_Order_Progress.Text.ToString() + "");
                            ht_Order_History.Add("@Work_Type", 1);
                            dt_Order_History = dataAccess.ExecuteSP("Sp_Order_History", ht_Order_History);



                            //==================================External Client_Vendor_Orders(Titlelogy)=====================================================



                            int Valiate_Order_Staus_Id = int.Parse(ddl_Order_Progress.SelectedValue.ToString());
                            if (Valiate_Order_Staus_Id == 1 || Valiate_Order_Staus_Id == 3 || Valiate_Order_Staus_Id == 4 || Valiate_Order_Staus_Id == 5)
                            {

                                Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                                System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                                htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                                htCheck_Order_InTitlelogy.Add("@Order_ID", Order_Id);
                                dt_Order_InTitleLogy = dataAccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                                if (dt_Order_InTitleLogy.Rows.Count > 0)
                                {


                                    External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                                    External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());


                                    // if The Db title client for Titlelogy No Need to Update Status 33 -->Db Title
                                    if (External_Client_Order_Task_Id != 18 && Client_Id!=33)
                                    {


                                        Hashtable htcheckExternalProduction = new Hashtable();
                                        DataTable dtcheckExternalProduction = new DataTable();
                                        htcheckExternalProduction.Add("@Trans", "CHK_PRODUCTION_DATE");
                                        htcheckExternalProduction.Add("@External_Order_Id", External_Client_Order_Id);
                                        htcheckExternalProduction.Add("@Order_Task", External_Client_Order_Task_Id);
                                        dtcheckExternalProduction = dataAccess.ExecuteSP("Sp_External_Client_Orders_Production", htcheckExternalProduction);



                                        if (dtcheckExternalProduction.Rows.Count > 0)
                                        {


                                            Check_External_Production = int.Parse(dtcheckExternalProduction.Rows[0]["count"].ToString());
                                        }
                                        else
                                        {

                                            Check_External_Production = 0;
                                        }


                                        if (Check_External_Production == 0)
                                        {

                                            Hashtable htProductionDate = new Hashtable();
                                            DataTable dtproductiondate = new System.Data.DataTable();
                                            htProductionDate.Add("@Trans", "INSERT");
                                            htProductionDate.Add("@External_Order_Id", External_Client_Order_Id);
                                            htProductionDate.Add("@Order_Task", External_Client_Order_Task_Id);
                                            htProductionDate.Add("@Order_Status", int.Parse(ddl_Order_Progress.SelectedValue.ToString()));
                                            htProductionDate.Add("@Order_Production_date", DateTime.Now.ToString("MM/dd/yyyy"));
                                            htProductionDate.Add("@Inserted_By", userid);
                                            htProductionDate.Add("@Inserted_date", DateTime.Now);
                                            htProductionDate.Add("@status", "True");
                                            dtproductiondate = dataAccess.ExecuteSP("Sp_External_Client_Orders_Production", htProductionDate);

                                        }
                                        else if (Check_External_Production > 0)
                                        {
                                            Hashtable htProductionDate = new Hashtable();
                                            DataTable dtproductiondate = new System.Data.DataTable();
                                            htProductionDate.Add("@Trans", "UPDATE");
                                            htProductionDate.Add("@External_Order_Id", External_Client_Order_Id);
                                            htProductionDate.Add("@Order_Task", External_Client_Order_Task_Id);
                                            htProductionDate.Add("@Order_Status", int.Parse(ddl_Order_Progress.SelectedValue.ToString()));
                                            htProductionDate.Add("@Order_Production_date", DateTime.Now.ToString("MM/dd/yyyy"));
                                            htProductionDate.Add("@Inserted_By", userid);
                                            htProductionDate.Add("@Inserted_date", DateTime.Now);
                                            htProductionDate.Add("@status", "True");
                                            dtproductiondate = dataAccess.ExecuteSP("Sp_External_Client_Orders_Production", htProductionDate);

                                        }

                                        Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                        System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                        ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_STATUS");
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Status", Valiate_Order_Staus_Id);

                                        dt_TitleLogy_Order_Task_Status = dataAccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);








                                    }


                                }
                            }
                        }
                        else
                        {

                            MessageBox.Show("This Order is in Work in Progress you can't change the Status");
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Abstractor Order Cannot be Update Status");

                    }
                }
            }
            else if (rbtn_Move_To_Tax.Checked == true)
            {
                Hashtable htselect_Orderid = new Hashtable();
                DataTable dtselect_Orderid = new System.Data.DataTable();
                htselect_Orderid.Add("@Trans", "SELECT_ORDER_NO_WISE");
                htselect_Orderid.Add("@Client_Order_Number", txt_Order_Status_Order_Number.Text);
                dtselect_Orderid = dataAccess.ExecuteSP("Sp_Order", htselect_Orderid);
                Order_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Id"].ToString());

                if (Order_Id != null && check_Order_In_Tax_Queau()!=false)
                {

                    Insert_Tax_Order_Status();

                    Hashtable htupdate = new Hashtable();
                    System.Data.DataTable dtupdate = new System.Data.DataTable();
                    htupdate.Add("@Trans", "UPDATE_SEARCH_TAX_REQUEST");
                    htupdate.Add("@Order_ID", Order_Id);
                    htupdate.Add("@Search_Tax_Request", "True");

                    dtupdate = dataAccess.ExecuteSP("Sp_Order", htupdate);

                    Hashtable httaxupdate = new Hashtable();
                    System.Data.DataTable dttaxupdate = new System.Data.DataTable();
                    httaxupdate.Add("@Trans", "UPDATE_SEARCH_TAX_REQUEST_STATUS");
                    httaxupdate.Add("@Order_ID", Order_Id);
                    httaxupdate.Add("@Search_Tax_Request_Progress", 14);

                    dttaxupdate = dataAccess.ExecuteSP("Sp_Order", httaxupdate);



                    //OrderHistory
                    Hashtable ht_Order_History = new Hashtable();
                    DataTable dt_Order_History = new DataTable();
                    ht_Order_History.Add("@Trans", "INSERT");
                    ht_Order_History.Add("@Order_Id", Order_Id);
                    ht_Order_History.Add("@User_Id",userid);
                    ht_Order_History.Add("@Status_Id", int.Parse(dtselect_Orderid.Rows[0]["Order_Status_Id"].ToString()));
                    ht_Order_History.Add("@Progress_Id", int.Parse(dtselect_Orderid.Rows[0]["Order_Progress"].ToString()));
                    ht_Order_History.Add("@Work_Type", 1);
                    ht_Order_History.Add("@Assigned_By", userid);
                    ht_Order_History.Add("@Modification_Type", "Order Moved to Search Tax Request");
                    dt_Order_History = dataAccess.ExecuteSP("Sp_Order_History", ht_Order_History);

                    MessageBox.Show("Order Moved to Search Tax Request");

                }

            }
        }

        private bool check_Order_In_Tax_Queau()
        {

            Hashtable htcheck = new Hashtable();
            DataTable dtcheck = new DataTable();
            htcheck.Add("@Trans", "CHECK_ORDER");
            htcheck.Add("@Order_Id",Order_Id);
            dtcheck = dataAccess.ExecuteSP("Sp_Tax_Order_Status", htcheck);
            int check = 0;
            if (dtcheck.Rows.Count > 0)
            {

                check = int.Parse(dtcheck.Rows[0]["count"].ToString());
            }
            else
            {
                check = 0;
            }

            if (check == 0)
            {

                return true;
            }
            else

            {
                MessageBox.Show("This Order is Already Assigened to Tax");
                return false;
            }
        }


        private void Insert_Tax_Order_Status()
        {



            Hashtable httax = new Hashtable();
            DataTable dttax = new DataTable();

            httax.Add("@Trans", "INSERT");
            httax.Add("@Order_Id", Order_Id);
            httax.Add("@Order_Task", 22);
            httax.Add("@Order_Status", 8);
            httax.Add("@Tax_Task", 1);
            httax.Add("@Tax_Status", 6);
            httax.Add("@Inserted_By", userid);
            httax.Add("@Status", "True");
            dttax = dataAccess.ExecuteSP("Sp_Tax_Order_Status", httax);



        }

        public bool validate_Status()
        {

            if (txt_Order_Status_Order_Number.Text == "")
            {

                MessageBox.Show("Enter Order Number");
                txt_Order_Status_Order_Number.Focus();
                return false;
            }
            if (ddl_Order_Progress.SelectedIndex <= 0)
            {

                MessageBox.Show("Select Order Status");
                ddl_Order_Progress.Focus();
                return false;
            }
            return true;
        }
        public bool Checkvalidate_Order_Assigned()
        {
            Hashtable htselect_Orderid = new Hashtable();
            DataTable dtselect_Orderid = new System.Data.DataTable();
            htselect_Orderid.Add("@Trans", "SELECT_ORDER_NO_WISE");
            htselect_Orderid.Add("@Client_Order_Number", txt_Order_Status_Order_Number.Text);
            dtselect_Orderid = dataAccess.ExecuteSP("Sp_Order", htselect_Orderid);
            Order_Id = int.Parse(dtselect_Orderid.Rows[0]["Order_Id"].ToString());
            int orderprogress = int.Parse(dtselect_Orderid.Rows[0]["Order_Progress"].ToString());

          
                int Check;
                Hashtable htupdate_Prog = new Hashtable();
                DataTable dtupdate_Prog = new System.Data.DataTable();
                htupdate_Prog.Add("@Trans", "CHECK_ASSIGNED");
                htupdate_Prog.Add("@Order_ID", Order_Id);

                dtupdate_Prog = dataAccess.ExecuteSP("Sp_Order", htupdate_Prog);

                if (dtupdate_Prog.Rows.Count > 0 )
                {

                    if (orderprogress == 6 || orderprogress == 8)
                    {
                        Check = 0;

                    }
                    else
                    {
                        Check = 1;
                    }
                }
                else
                {

                    Check = 0;
                    
                }
                if (Check == 1)
                {
                    MessageBox.Show("Order is Assigned to Some One Please check");
                    return false;
                }
                else if (orderprogress == 6 || orderprogress == 8)
                {
                    Check = 0;
                    return true;
                }
                else
                {


                    return true;
                }
           
          
            

        }

        private void rbtn_Move_To_Tax_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_Move_To_Tax.Checked == true)
            {
                group_Status.Text = "Moce To Search Tax-Request";
                grd_order.Rows.Clear();
                Rb_Task.Checked = false;
                group_Task.Visible = false;
                group_Status.Visible = true;
                txt_Order_Status_Order_Number.Text = "";
                ddl_Order_Progress.SelectedIndex = 0;

                lbl_Status.Visible = false;
                ddl_Order_Progress.Visible = false;

                grp_Vendor.Visible = false;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            group_Task.Visible = false;
            group_Status.Visible = false;
            grp_Vendor.Visible = true;
        }

        private void btn_Vendor_Submit_Click(object sender, EventArgs e)
        {
               int CheckedCount = 0;
               if (ddl_Vendor_Name.SelectedIndex != 0)
               {


                   int allocated_Vendor_Id = int.Parse(ddl_Vendor_Name.SelectedValue.ToString());


                       for (int i = 0; i < grd_order.Rows.Count; i++)
                {
                   

                 
                        CheckedCount = 1;
                         lbl_Order_Id = grd_order.Rows[i].Cells[13].Value.ToString();
                         Vendor_Id = ddl_Vendor_Name.SelectedValue.ToString();


                          lbl_Order_Type_Id = grd_order.Rows[i].Cells[16].Value.ToString();
                          Client_Id = int.Parse(grd_order.Rows[i].Cells[14].Value.ToString());
                          Sub_Process_Id = int.Parse(grd_order.Rows[i].Cells[15].Value.ToString());

                          Hashtable ht_Get_Order_Type_Abs_Id = new Hashtable();
                          System.Data.DataTable dt_Get_Order_Type_Abs_Id = new System.Data.DataTable();
                          ht_Get_Order_Type_Abs_Id.Add("@Trans", "SELECT_BY_ORDER_TYPE_ID");
                          ht_Get_Order_Type_Abs_Id.Add("@Order_Type_ID", lbl_Order_Type_Id.ToString());
                          dt_Get_Order_Type_Abs_Id = dataAccess.ExecuteSP("Sp_Order_Type", ht_Get_Order_Type_Abs_Id);

                          if (dt_Get_Order_Type_Abs_Id.Rows.Count > 0)
                          {
                              Order_Type_Abs_Id = int.Parse(dt_Get_Order_Type_Abs_Id.Rows[0]["OrderType_ABS_Id"].ToString());

                          }
                        

                        Hashtable htinsertrec = new Hashtable();
                        System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                        DateTime date = new DateTime();
                        date = DateTime.Now;
                        string dateeval = date.ToString("dd/MM/yyyy");
                        string time = date.ToString("hh:mm tt");



                        if (Validate_Vedndor_Sate_county() != false && Validate_Order_Type(allocated_Vendor_Id, Order_Type_Abs_Id) && Validate_Client_Sub_Client(allocated_Vendor_Id, Client_Id, Sub_Process_Id))
                        {

                             Hashtable htdel = new Hashtable();
                            System.Data.DataTable dtdel = new System.Data.DataTable();
                            htdel.Add("@Trans", "DELETE");
                            htdel.Add("@Order_Id", lbl_Order_Id);
                            dtdel = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htdel);


                            Hashtable htdelvendstatus = new Hashtable();
                            System.Data.DataTable dtdelvendstatus = new System.Data.DataTable();
                            htdelvendstatus.Add("@Trans", "DELETE");
                            htdelvendstatus.Add("@Order_Id", lbl_Order_Id);
                            dtdelvendstatus = dataAccess.ExecuteSP("Sp_Vendor_Order_Status", htdelvendstatus);




                            Hashtable htvenncapacity = new Hashtable();
                            System.Data.DataTable dtvencapacity = new System.Data.DataTable();
                            htvenncapacity.Add("@Trans", "GET_VENDOR_CAPACITY");
                            htvenncapacity.Add("@Venodor_Id", allocated_Vendor_Id);
                            dtvencapacity = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htvenncapacity);

                            if (dtvencapacity.Rows.Count > 0)
                            {

                                Hashtable htetcdate = new Hashtable();
                                System.Data.DataTable dtetcdate = new System.Data.DataTable();
                                htetcdate.Add("@Trans", "GET_DATE");

                                dtetcdate = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htetcdate);


                                Vendor_Order_capacity = int.Parse(dtvencapacity.Rows[0]["Capacity"].ToString());


                                Hashtable htVendor_No_Of_Order_Assigned = new Hashtable();
                                System.Data.DataTable dtVendor_No_Of_Order_Assigned = new System.Data.DataTable();
                                htVendor_No_Of_Order_Assigned.Add("@Trans", "COUNT_NO_OF_ORDER_ASSIGNED_TO_VENDOR_DATE_WISE");
                                htVendor_No_Of_Order_Assigned.Add("@Venodor_Id", allocated_Vendor_Id);
                                htVendor_No_Of_Order_Assigned.Add("@Date", Vendor_Date);

                                dtVendor_No_Of_Order_Assigned = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htVendor_No_Of_Order_Assigned);

                                if (dtVendor_No_Of_Order_Assigned.Rows.Count > 0)
                                {

                                    No_Of_Order_Assignd_for_Vendor = int.Parse(dtVendor_No_Of_Order_Assigned.Rows[0]["count"].ToString());
                                }
                                else
                                {

                                    No_Of_Order_Assignd_for_Vendor = 0;
                                }



                                if (No_Of_Order_Assignd_for_Vendor <= Vendor_Order_capacity)
                                {


                                    Hashtable htCheckOrderAssigned = new Hashtable();
                                    System.Data.DataTable dtcheckorderassigned = new System.Data.DataTable();

                                    htCheckOrderAssigned.Add("@Trans", "CHECK_ORDER_ASSIGNED");
                                    htCheckOrderAssigned.Add("@Order_Id", lbl_Order_Id);
                                    dtcheckorderassigned = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htCheckOrderAssigned);

                                    int CheckCount = int.Parse(dtcheckorderassigned.Rows[0]["count"].ToString());


                                    if (CheckCount <= 0)
                                    {


                                        Hashtable htupdatestatus = new Hashtable();
                                        System.Data.DataTable dtupdatestatus = new System.Data.DataTable();
                                        htupdatestatus.Add("@Trans", "UPDATE_STATUS");
                                        htupdatestatus.Add("@Order_Status", 20);
                                        htupdatestatus.Add("@Modified_By", userid);
                                        htupdatestatus.Add("@Order_ID", lbl_Order_Id);
                                        dtupdatestatus = dataAccess.ExecuteSP("Sp_Order", htupdatestatus);


                                        Hashtable htupdateprogress = new Hashtable();
                                        System.Data.DataTable dtupdateprogress = new System.Data.DataTable();
                                        htupdateprogress.Add("@Trans", "UPDATE_PROGRESS");
                                        htupdateprogress.Add("@Order_Progress", 6);
                                        htupdateprogress.Add("@Modified_By", userid);
                                        htupdateprogress.Add("@Order_ID", lbl_Order_Id);
                                        dtupdateprogress = dataAccess.ExecuteSP("Sp_Order", htupdateprogress);






                                        Hashtable htinsert = new Hashtable();
                                        System.Data.DataTable dtinert = new System.Data.DataTable();

                                        htinsert.Add("@Trans", "INSERT");
                                        htinsert.Add("@Order_Id", lbl_Order_Id);
                                        htinsert.Add("@Order_Task_Id", 2);
                                        htinsert.Add("@Order_Status_Id", 13);
                                        htinsert.Add("@Venodor_Id", allocated_Vendor_Id);
                                        htinsert.Add("@Assigned_Date_Time", dtetcdate.Rows[0]["Date"]);
                                        htinsert.Add("@Assigned_By", userid);
                                        htinsert.Add("@Inserted_By", userid);
                                        htinsert.Add("@Inserted_date", dtetcdate.Rows[0]["Date"]);
                                        htinsert.Add("@Status", "True");
                                        dtinert = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htinsert);




                                        Hashtable htinsertstatus = new Hashtable();
                                        System.Data.DataTable dtinsertstatus = new System.Data.DataTable();
                                        htinsertstatus.Add("@Trans", "INSERT");
                                        htinsertstatus.Add("@Vendor_Id", allocated_Vendor_Id);
                                        htinsertstatus.Add("@Order_Id", lbl_Order_Id);
                                        htinsertstatus.Add("@Order_Task", 2);
                                        htinsertstatus.Add("@Order_Status", 13);
                                        htinsertstatus.Add("@Assigen_Date", dtetcdate.Rows[0]["Date"]);
                                        htinsertstatus.Add("@Inserted_By", userid);
                                        htinsertstatus.Add("@Inserted_date", dtetcdate.Rows[0]["Date"]);
                                        htinsertstatus.Add("@Status", "True");

                                        dtinsertstatus = dataAccess.ExecuteSP("Sp_Vendor_Order_Status", htinsertstatus);




                                    }



                                }






                                //OrderHistory
                                Hashtable ht_Order_History = new Hashtable();
                                System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                                ht_Order_History.Add("@Trans", "INSERT");
                                ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                                ht_Order_History.Add("@User_Id", userid);
                                ht_Order_History.Add("@Status_Id", 2);
                                ht_Order_History.Add("@Progress_Id", 6);
                                ht_Order_History.Add("@Assigned_By", userid);
                                ht_Order_History.Add("@Work_Type", 1);
                                ht_Order_History.Add("@Modification_Type", "Vendor Order Allocate from Inhouse Order Queue");
                                dt_Order_History = dataAccess.ExecuteSP("Sp_Order_History", ht_Order_History);


                                //==================================External Client_Vendor_Orders=====================================================


                                Hashtable htCheck_Order_InTitlelogy = new Hashtable();
                                System.Data.DataTable dt_Order_InTitleLogy = new System.Data.DataTable();
                                htCheck_Order_InTitlelogy.Add("@Trans", "CHECK_ORDER_IN_TITLLELOGY");
                                htCheck_Order_InTitlelogy.Add("@Order_ID", lbl_Order_Id);
                                dt_Order_InTitleLogy = dataAccess.ExecuteSP("Sp_Order", htCheck_Order_InTitlelogy);

                                if (dt_Order_InTitleLogy.Rows.Count > 0)
                                {

                                    External_Client_Order_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Id"].ToString());
                                    External_Client_Order_Task_Id = int.Parse(dt_Order_InTitleLogy.Rows[0]["External_Order_Task_id"].ToString());


                                    // if The Db title client for Titlelogy No Need to Update Status 33 -->Db Title
                                    if (External_Client_Order_Task_Id != 18 && Client_Id!=33)
                                    {
                                        Hashtable ht_Titlelogy_Order_Task_Status = new Hashtable();
                                        System.Data.DataTable dt_TitleLogy_Order_Task_Status = new System.Data.DataTable();
                                        ht_Titlelogy_Order_Task_Status.Add("@Trans", "UPDATE_ORDER_TASK_STATUS");
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Id", External_Client_Order_Id);
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Task", 2);
                                        ht_Titlelogy_Order_Task_Status.Add("@Order_Status", 14);

                                        dt_TitleLogy_Order_Task_Status = dataAccess.ExecuteSP("Sp_External_Client_Orders", ht_Titlelogy_Order_Task_Status);
                                    }




                                }
                            }
                            else
                            { 
                            

                            }





                                //TreeView1.SelectedNode.Value =ViewState["User_Id"].ToString();
                                //   lbl_allocated_user.Text = ViewState["User_Wise_Count"].ToString();
                                //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Msg", "<script> alert('Order Reallocated Successfully')</script>", false);

                            }


                        
                       
            }

                   if (CheckedCount >= 1)
                {
                    MessageBox.Show("Order were Allocated to Vendors Successfully");

                    ddl_Vendor_Name.SelectedIndex = 0;
                    grd_order.Rows.Clear();
                 
                }


                }

                
               }
        

        private void txt_Vendor_Order_Number_TextChanged(object sender, EventArgs e)
        {
            if (txt_Vendor_Order_Number.Text != "")
            {
                Hashtable htselect = new Hashtable();
                System.Data.DataTable dtselect = new System.Data.DataTable();
                string OrderNumber = txt_Vendor_Order_Number.Text.ToString();


                htselect.Add("@Trans", "SELECT_ORDER_NO_WISE");
                htselect.Add("@Client_Order_Number", OrderNumber);
                dtselect = dataAccess.ExecuteSP("Sp_Order", htselect);


                if (dtselect.Rows.Count > 0)
                {
                    grd_order.Rows.Clear();
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        grd_order.Rows.Add();
                        grd_order.Rows[i].Cells[0].Value = dtselect.Rows[i]["Client_Order_Number"].ToString();
                        grd_order.Rows[i].Cells[1].Value = dtselect.Rows[i]["Order_Number"].ToString();
                        if (userroleid == "1")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Name"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Sub_ProcessName"].ToString();
                        }
                        else if (userroleid == "2")
                        {
                            grd_order.Rows[i].Cells[2].Value = dtselect.Rows[i]["Client_Number"].ToString();
                            grd_order.Rows[i].Cells[3].Value = dtselect.Rows[i]["Subprocess_Number"].ToString();
                        }
                        grd_order.Rows[i].Cells[4].Value = dtselect.Rows[i]["Date"].ToString();
                        grd_order.Rows[i].Cells[5].Value = dtselect.Rows[i]["Order_Type"].ToString();
                        grd_order.Rows[i].Cells[6].Value = dtselect.Rows[i]["Client_Order_Ref"].ToString();
                        grd_order.Rows[i].Cells[7].Value = dtselect.Rows[i]["County_Type"].ToString();
                        grd_order.Rows[i].Cells[8].Value = dtselect.Rows[i]["County"].ToString();
                        grd_order.Rows[i].Cells[9].Value = dtselect.Rows[i]["State"].ToString();
                        grd_order.Rows[i].Cells[10].Value = dtselect.Rows[i]["Order_Status"].ToString();
                        grd_order.Rows[i].Cells[11].Value = dtselect.Rows[i]["Progress_Status"].ToString();
                        grd_order.Rows[i].Cells[12].Value = dtselect.Rows[i]["User_Name"].ToString();
                        grd_order.Rows[i].Cells[13].Value = dtselect.Rows[i]["Order_ID"].ToString();
                        grd_order.Rows[i].Cells[14].Value = dtselect.Rows[i]["Client_Id"].ToString();
                        grd_order.Rows[i].Cells[15].Value = dtselect.Rows[i]["Sub_ProcessId"].ToString();
                        grd_order.Rows[i].Cells[16].Value = dtselect.Rows[i]["Order_Type_Id"].ToString();
                 

                    }

                }
                else
                {
                    grd_order.Visible = true;
                    grd_order.DataSource = null;

                }
            }
            else
            {

                grd_order.Rows.Clear();

            }
        }

        private bool Validate_Vedndor_Sate_county()
        {


            Hashtable htstatecounty = new Hashtable();
            System.Data.DataTable dtstatecounty = new System.Data.DataTable();
            Hashtable htcheckstate = new Hashtable();
            System.Data.DataTable dtcheckstate = new System.Data.DataTable();
            htstatecounty.Add("@Trans", "GET_STATE_COUNTY_OF_THE_ORDER");
            htstatecounty.Add("@Order_Id", lbl_Order_Id);
            dtstatecounty = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htstatecounty);
            if (dtstatecounty.Rows.Count > 0)
            {


                htcheckstate.Add("@Trans", "CHECK_VENDOR_AVILABLE_IN_STATE_COUNTY");
                htcheckstate.Add("@State_Id", dtstatecounty.Rows[0]["State"].ToString());
                htcheckstate.Add("@County_Id", dtstatecounty.Rows[0]["County"].ToString());
                htcheckstate.Add("@Venodor_Id", Vendor_Id);

                dtcheckstate = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htcheckstate);




            }

            if (dtcheckstate.Rows.Count > 0)
            {

                return true;

            }
            else
            {
                MessageBox.Show("This vendor dont have coverage of this state and county");

                return false;
            }





        }

        private bool Validate_Order_Type(int Vendor_Id, int Order_Type_Id)
        {

            Hashtable htcheck_Vendor_Order_Type_Abs = new Hashtable();
            System.Data.DataTable dtcheck_Vendor_Order_Type_Abs = new System.Data.DataTable();
            htcheck_Vendor_Order_Type_Abs.Add("@Trans", "GET_VENDOR_ORDER_TYPE_COVERAGE");
            htcheck_Vendor_Order_Type_Abs.Add("@Vendors_Id", Vendor_Id);
            htcheck_Vendor_Order_Type_Abs.Add("@Order_Type_Abs_Id", Order_Type_Id);
            dtcheck_Vendor_Order_Type_Abs = dataAccess.ExecuteSP("Sp_Vendor_Order_Type_Abs_Coverage", htcheck_Vendor_Order_Type_Abs);

            if (dtcheck_Vendor_Order_Type_Abs.Rows.Count > 0)
            {

                return true;
            }
            else
            {
                MessageBox.Show("This Order Type is not Allocated for this Vendor");
                return false;

            }
        }

        private bool Validate_Client_Sub_Client(int Vendor_Id, int Client_Id, int Sub_Process_Id)
        {

            Hashtable htget_vendor_Client_And_Sub_Client = new Hashtable();
            System.Data.DataTable dtget_Vendor_Client_And_Sub_Client = new System.Data.DataTable();

            htget_vendor_Client_And_Sub_Client.Add("@Trans", "GET_VENDOR_ON_CLIENT_AND_SUB_CLIENT");
            htget_vendor_Client_And_Sub_Client.Add("@Client_Id", Client_Id);
            htget_vendor_Client_And_Sub_Client.Add("@Sub_Client_Id", Sub_Process_Id);
            htget_vendor_Client_And_Sub_Client.Add("@Vendors_Id", Vendor_Id);
            dtget_Vendor_Client_And_Sub_Client = dataAccess.ExecuteSP("Sp_Vendor_Order_Assignment", htget_vendor_Client_And_Sub_Client);

            if (dtget_Vendor_Client_And_Sub_Client.Rows.Count > 0)
            {


                return true;


            }
            else
            {

                MessageBox.Show("This Vendor not belongs to this Client");
                return false;
            }

        }

       

       
        }
        }
    
