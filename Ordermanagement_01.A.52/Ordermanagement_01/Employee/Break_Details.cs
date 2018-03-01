using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;


namespace Ordermanagement_01.Employee
{
    public partial class Break_Details : Form

    {

        DateTime Start_Time, Current_Time,Total_Break_Time;

        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        int Closing_value = 0;
        int Order_Id,User_Id;
        DialogResult dialogResult = new DialogResult();
        int Last_Inserted_Record_Id;
        string First_date, Secod_Date;
        int datetimediff;
        public Break_Details(int USER_ID, string FIRST_DATE, string SECOND_DATE)
        {
            InitializeComponent();
            User_Id = USER_ID;
            First_date = FIRST_DATE;
            Secod_Date = SECOND_DATE;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

          
          //  var datetimediff = new DateTime((DateTime.Now - Start_Time).Ticks);

            Hashtable htget_Start_End_Time = new Hashtable();
            DataTable dtget_Start_End_Time = new System.Data.DataTable();

            htget_Start_End_Time.Add("@Trans", "DATE_DIFF");
            htget_Start_End_Time.Add("@Order_Break_Id",Last_Inserted_Record_Id);
            dtget_Start_End_Time = dataaccess.ExecuteSP("Sp_Order_User_Break_Details", htget_Start_End_Time);

            if (dtget_Start_End_Time.Rows.Count > 0)
            {

                 datetimediff = int.Parse(dtget_Start_End_Time.Rows[0]["Diff_Seconds"].ToString());

            }

            TimeSpan tb;


            if (ddl_Break_Mode.SelectedValue.ToString() == "1" && datetimediff < 900)
            {
                lbl_Total_Time.ForeColor = System.Drawing.Color.Green;


            }
           

            else  if (ddl_Break_Mode.SelectedValue.ToString() == "2" && datetimediff < 1800)
            {

                lbl_Total_Time.ForeColor = System.Drawing.Color.Green;
            }
          
            else if (ddl_Break_Mode.SelectedValue.ToString() == "3" && datetimediff < 900)
            {
                lbl_Total_Time.ForeColor = System.Drawing.Color.Green;


            }
            else
            {
                lbl_Total_Time.ForeColor = System.Drawing.Color.Red;
            }

            tb = TimeSpan.FromSeconds(datetimediff);




            string breakformatedTime = string.Format("{0:D2}H:{1:D2}M:{2:D2}S",
                   tb.Hours,
                   tb.Minutes,
                   tb.Seconds);


            lbl_Total_Time.Text = breakformatedTime.ToString();
                
         
        }

        private void btn_Start_Time_Click(object sender, EventArgs e)
        {
            if (ddl_Break_Mode.SelectedIndex > 0)
            {
                timer1.Enabled = true;
                 timer1_Tick( sender,  e);
           
                lbl_Start.Visible = true;
                lbl_Start_Time.Visible = true;
                lbl_Total.Visible = true;
                lbl_Total_Time.Visible = true;
                btn_Start_Time.Enabled = false;

                btn_Stop.Enabled = true;
                btn_Exit.Enabled = false;


                if (ddl_Break_Mode.SelectedIndex == 1 || ddl_Break_Mode.SelectedIndex == 2 || ddl_Break_Mode.SelectedIndex == 3 || ddl_Break_Mode.SelectedIndex == 4)
                {

                    FormCollection fc = Application.OpenForms;

                    foreach (Form frm in fc)
                    {
                        frm.Enabled = false;
                    }

                    foreach (Form f in Application.OpenForms)
                    {

                        if (f.Name == "Break_Details")
                        {

                            f.Enabled = true;

                        }

                    }


                    Hashtable htComments = new Hashtable();
                    DataTable dtComments = new System.Data.DataTable();

                    DateTime date = new DateTime();
                    date = DateTime.Now;
                    string dateeval = date.ToString("dd/MM/yyyy");
                    string time = date.ToString("hh:mm tt");

                    htComments.Add("@Trans", "INSERT");
                  
                    htComments.Add("@Break_Mode_Id",int.Parse(ddl_Break_Mode.SelectedValue.ToString()));
                    htComments.Add("@Start_Time", date);
                    htComments.Add("@End_Time", date);
                    htComments.Add("@User_Id", User_Id);
                    htComments.Add("@Date", date);

                    object Max_Id = dataaccess.ExecuteSPForScalar("Sp_Order_User_Break_Details", htComments);


                    Hashtable htget_Start_End_Time = new Hashtable();
                    DataTable dtget_Start_End_Time = new System.Data.DataTable();

                    htget_Start_End_Time.Add("@Trans", "GET_START_END_TIME");
                    htget_Start_End_Time.Add("@Order_Break_Id", Max_Id);
                    dtget_Start_End_Time = dataaccess.ExecuteSP("Sp_Order_User_Break_Details", htget_Start_End_Time);

                    if (dtget_Start_End_Time.Rows.Count > 0)
                    {

                        lbl_Start_Time.Text = dtget_Start_End_Time.Rows[0]["Start_Time"].ToString();
                       
                    }

                    Last_Inserted_Record_Id = int.Parse(Max_Id.ToString());



                    
                }
                else {

                    FormCollection fc = Application.OpenForms;

                    foreach (Form frm in fc)
                    {
                        frm.Enabled = true;
                    }

                }

              
            }
            else
            {

                MessageBox.Show("Select Break Mode.");
                ddl_Break_Mode.Focus();
               
            }


        }

        private void Break_Details_Load(object sender, EventArgs e)
        {
            lbl_Stop.Visible = false;
            lbl_Start_Time.Visible = false;
            lbl_Stop_Time.Visible = false;
            lbl_Total.Visible = false;
            lbl_Total_Time.Visible = false;
            btn_Stop.Enabled = false;
            lbl_Start.Visible = false;
            btn_Stop.Enabled = false;

            Hashtable htComments = new Hashtable();
            DataTable dtComments = new System.Data.DataTable();

            htComments.Add("@Trans", "GET_BREAK_DETAILS");
            htComments.Add("@Firstdate", First_date);
            htComments.Add("@Second_Date", Secod_Date);
            htComments.Add("@User_Id", User_Id);
            dtComments = dataaccess.ExecuteSP("Sp_Order_User_Break_Details", htComments);


            dbc.Bind_BreakMode_Type(ddl_Break_Mode,User_Id);



        
           


        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            lbl_Stop.Visible = true;
            lbl_Stop_Time.Visible = true;
         
            timer1.Enabled = false;
            btn_Stop.Enabled = false;
            btn_Exit.Enabled = true;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                frm.Enabled = true;
            }

            Hashtable htComments = new Hashtable();
            DataTable dtComments = new System.Data.DataTable();

            DateTime date = new DateTime();
            date = DateTime.Now;
            string dateeval = date.ToString("dd/MM/yyyy");
            string time = date.ToString("hh:mm tt");

            htComments.Add("@Trans", "UPDATE_BREAK_END_TIME");
            htComments.Add("@Order_Break_Id", Last_Inserted_Record_Id);
            htComments.Add("@Start_Time", date);
            htComments.Add("@End_Time", date);
            htComments.Add("@User_Id", User_Id);
       
            dtComments = dataaccess.ExecuteSP("Sp_Order_User_Break_Details", htComments);

            Hashtable htget_Start_End_Time = new Hashtable();
            DataTable dtget_Start_End_Time = new System.Data.DataTable();

            htget_Start_End_Time.Add("@Trans", "GET_START_END_TIME");
            htget_Start_End_Time.Add("@Order_Break_Id", Last_Inserted_Record_Id);
            dtget_Start_End_Time = dataaccess.ExecuteSP("Sp_Order_User_Break_Details", htget_Start_End_Time);

            if (dtget_Start_End_Time.Rows.Count > 0)
            {

                lbl_Stop_Time.Text = dtget_Start_End_Time.Rows[0]["End_Time"].ToString();

            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Closing_value = 1;
            

                dialogResult = MessageBox.Show("Do you Want to Exit?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    FormCollection fc = Application.OpenForms;
                    foreach (Form frm in fc)
                    {
                        frm.Enabled = true;
                    }


                    this.Close();


                }
                else
                { 
                


                }

          
        }

        private void Break_Details_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (Closing_value != 1)
            //{
            //    dialogResult = MessageBox.Show("Do you Want to Exit?", "Some Title", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        FormCollection fc = Application.OpenForms;
            //        foreach (Form frm in fc)
            //        {
            //            frm.Enabled = true;
            //        }

            //        this.Close();
            //    }
            //    else
            //    {



            //    }
            //}
            if (Closing_value != 1)
            {

                e.Cancel = true;

                this.WindowState = FormWindowState.Minimized;
            }

        }

        private void link_Break_Details_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Ordermanagement_01.Employee.Employee_View_Break_Details emb = new Employee.Employee_View_Break_Details(First_date, Secod_Date, User_Id,"Break");

            foreach (Form f in Application.OpenForms)
            {

                if (f.Name == "Employee_View_Break_Details")
                {

                    f.Hide();


                }

            }
            emb.Show();

        }
    }
}
