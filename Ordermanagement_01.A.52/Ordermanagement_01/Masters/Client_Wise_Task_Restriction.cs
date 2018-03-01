using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Web.UI.WebControls;


namespace Ordermanagement_01.Masters
{
    public partial class Client_Wise_Task_Restriction : Form
    {
        int Userid;
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        int R_Count;
        Hashtable htclient_Task = new Hashtable();
        DataTable dtclient_Task = new DataTable();
        int count_task;
        int count_TaskInstr;
        public Client_Wise_Task_Restriction(int USER_ID)
        {
            InitializeComponent();
            Userid = USER_ID;
        }

        private void Client_Wise_Task_Restriction_Load(object sender, EventArgs e)
        {

            dbc.Bind_Client_Names(ddl_ClientName);
            dbc.Bind_Order_Task(ddl_Task);
            Bind_Client_Wise_Task_Restrictions();



        }

        private void ddl_Task_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Task.SelectedIndex > 0)
            {

                int Order_Task_Id = int.Parse(ddl_Task.SelectedValue.ToString());


                Hashtable httask = new Hashtable();
                DataTable dttask = new DataTable();
                httask.Add("@Trans", "SELECT_ORDER_TASK_STAGE_WIESE");
                httask.Add("@order_status_Id", Order_Task_Id);
                dttask = dataaccess.ExecuteSP("Sp_Genral", httask);
                if (dttask.Rows.Count > 0)
                {


                    for (int i = 0; i < dttask.Rows.Count; i++)
                    {
                        grd_Task.Rows.Add();
                        grd_Task.Rows[i].Cells[1].Value = dttask.Rows[i]["Order_Status_ID"].ToString();
                        grd_Task.Rows[i].Cells[2].Value = dttask.Rows[i]["Order_Status"].ToString();
                       
                    }

                }
                else
                {
                    grd_Task.Rows.Clear();

                }
                
            }
            else
            {
                grd_Task.Rows.Clear();

            }


        }

        private bool Validate()
        {
            string title = "Validation!";
            if (ddl_ClientName.SelectedIndex <= 0)
            {

                MessageBox.Show("Select Client Name",title);
                ddl_ClientName.Focus();
                return false;
            }
            if (ddl_Task.SelectedIndex <= 0)
            { 
            
                MessageBox.Show("Select Task Name",title);
                ddl_Task.Focus();
                return false;
            }
            //if (chk_Task.Checked == false)
            //{
            //    for (int i = 0; i < grd_Task.Rows.Count; i++)
            //    {
            //        grd_Task[0, i].Value = false;
            //    }
            //}

            for (int task = 0; task < grd_Task.Rows.Count; task++)
            {
                bool isclient = (bool)grd_Task[0, task].FormattedValue;
                if (!isclient)
                {
                    count_task++;
                }
            }
            if (count_task == grd_Task.Rows.Count)
            {
                string title1 = "Select!";
                MessageBox.Show("Kindly Select Any One Target Task ",title1);
                count_task = 0;
                return false;
            }
            count_task = 0;

            return true;


        }
        private void btn_Submit_Click(object sender, EventArgs e)
        {

            if (Validate() != false)
            {
                int Task_Id;int Record_Count=0;
                if (grd_Task.Rows.Count > 0)
                {


                    for(int i=0;i<grd_Task.Rows.Count;i++)
                    {
             
                        bool isChecked = (bool)grd_Task[0, i].FormattedValue;
                    if (isChecked == true)
                    {
                     Task_Id   = int.Parse(grd_Task.Rows[i].Cells[1].Value.ToString());



                    Hashtable htcheck = new Hashtable();
                    DataTable dtchek = new DataTable();

                    htcheck.Add("@Trans", "CHECK");
                    htcheck.Add("@Client_Id",int.Parse(ddl_ClientName.SelectedValue.ToString()));
                    htcheck.Add("@Task_Id ", Task_Id);
                    htcheck.Add("@Task_Stage_Id ",int.Parse(ddl_Task.SelectedValue.ToString()));
                    dtchek=dataaccess.ExecuteSP("Sp_Client_Task_Stage_Target",htcheck);

                    int Check_Count=0;
                    if(dtchek.Rows.Count>0)
                    {
                    
                        Check_Count=int.Parse(dtchek.Rows[0]["count"].ToString());


                    }
                    else
                    {
                    
                        Check_Count=0;
                    }

                    if(Check_Count==0)
                    {  
                        Record_Count=1;
                        
                    Hashtable htinsert = new Hashtable();
                    DataTable dtinsert = new DataTable();

                    htinsert.Add("@Trans", "INSERT");
                    htinsert.Add("@Client_Id",int.Parse(ddl_ClientName.SelectedValue.ToString()));
                    htinsert.Add("@Task_Id", Task_Id);
                    htinsert.Add("@Task_Stage_Id ", int.Parse(ddl_Task.SelectedValue.ToString()));
                    
                    dtinsert=dataaccess.ExecuteSP("Sp_Client_Task_Stage_Target",htinsert);


                    }

                    }
                }

                    if (Record_Count >= 1)
                    {
                        Bind_Client_Wise_Task_Restrictions();
                        string title = "Successfull";
                        MessageBox.Show("Task Added Successfully",title);

                    }
                    ddl_ClientName.SelectedIndex = 0;
                    ddl_Task.SelectedIndex = 0;
                    for (int i = 0; i < grd_Task.Rows.Count; i++)
                    {
                        grd_Task[0, i].Value = false;
                    }
                }

            }
            

        }

        private void Bind_Client_Wise_Task_Restrictions()
        {

            htclient_Task.Clear();

            htclient_Task.Add("@Trans", "SELECT");

            dtclient_Task = dataaccess.ExecuteSP("Sp_Client_Task_Stage_Target", htclient_Task);

            if (dtclient_Task.Rows.Count > 0)
            {

                grd_Client_Task.Rows.Clear();
                for (int i = 0; i < dtclient_Task.Rows.Count; i++)
                {
                    grd_Client_Task.Rows.Add();
                    grd_Client_Task.Rows[i].Cells[1].Value = dtclient_Task.Rows[i]["Client_Name"].ToString();
                    grd_Client_Task.Rows[i].Cells[2].Value = dtclient_Task.Rows[i]["Task_Stage_Status"].ToString();
                    grd_Client_Task.Rows[i].Cells[3].Value = dtclient_Task.Rows[i]["Task_Status"].ToString();
                    grd_Client_Task.Rows[i].Cells[4].Value = dtclient_Task.Rows[i]["Client_Task_Target_Id"].ToString();
                }

                  
            }
            else
            {

                grd_Client_Task.DataSource = null;
                grd_Client_Task.Rows.Clear();
            }
        }

        private void chk_Task_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Task.Checked == true)
            {
                for (int i = 0; i < grd_Task.Rows.Count; i++)
                {
                    grd_Task[0, i].Value = true;
                }
            }
            else if (chk_Task.Checked == false)
            {
                for (int i = 0; i < grd_Task.Rows.Count; i++)
                {
                    grd_Task[0, i].Value = false;
                }
            }
        }
        
         private bool Validation_del()
        {
            for (int inst = 0; inst < grd_Client_Task.Rows.Count; inst++)
            {
                bool isinst = (bool)grd_Client_Task[0, inst].FormattedValue;
                if (!isinst)
                {
                    count_TaskInstr++;
                }
            }
            if (grd_Client_Task.Rows.Count == count_TaskInstr)
            {
                string title = "Select!";
                MessageBox.Show("Kindly Select Any One Record To delete",title);
                count_TaskInstr = 0;
                return false;
            }
            count_TaskInstr = 0;
            return true;
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Validation_del()!=false)
            {
                 DialogResult del = MessageBox.Show("Do you want to delete selected Instructions", "Delete Confirmation", MessageBoxButtons.YesNo);
                 if (del == DialogResult.Yes)
                 {

                     for (int i = 0; i < grd_Client_Task.Rows.Count; i++)
                     {
                         int Client_Task_Id;

                         bool isChecked = (bool)grd_Client_Task[0, i].FormattedValue;
                         if (isChecked == true)
                         {

                             R_Count = 1;
                             Client_Task_Id = int.Parse(grd_Client_Task.Rows[i].Cells[4].Value.ToString());

                             Hashtable htclient_Task = new Hashtable();
                             DataTable dtclient_Task = new DataTable();

                             htclient_Task.Add("@Trans", "DELETE");
                             htclient_Task.Add("@Client_Task_Target_Id", Client_Task_Id);

                             dtclient_Task = dataaccess.ExecuteSP("Sp_Client_Task_Stage_Target", htclient_Task);


                         }
                     }
                 }
            }
            if (R_Count >= 1)
            {

                MessageBox.Show("Record Deleted Sucessfully");
                Bind_Client_Wise_Task_Restrictions();
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_Search.Text != "Search..." && txt_Search.Text != "")
            {
                DataView dtsearch = new DataView(dtclient_Task);
                dtsearch.RowFilter = "Client_Name like '%" + txt_Search.Text.ToString() + "%'  or Task_Stage_Status like '% " + txt_Search.Text.ToString() + "%'  or Task_Status like '%" + txt_Search.Text.ToString() + "%' ";
                DataTable temp = new DataTable();
                temp = dtsearch.ToTable();
                if (temp.Rows.Count > 0)
                {

                    grd_Client_Task.Rows.Clear();
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        grd_Client_Task.Rows.Add();
                        grd_Client_Task.Rows[i].Cells[1].Value = temp.Rows[i]["Client_Name"].ToString();
                        grd_Client_Task.Rows[i].Cells[2].Value = temp.Rows[i]["Task_Stage_Status"].ToString();
                        grd_Client_Task.Rows[i].Cells[3].Value = temp.Rows[i]["Task_Status"].ToString();
                        grd_Client_Task.Rows[i].Cells[4].Value = temp.Rows[i]["Client_Task_Target_Id"].ToString();

                    }
                }
                else
                {

                }
            }
            else
            {
                Bind_Client_Wise_Task_Restrictions();
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Bind_Client_Wise_Task_Restrictions();
            ddl_ClientName.SelectedIndex = 0;
            ddl_Task.SelectedIndex = 0;
            for (int i = 0; i < grd_Task.Rows.Count; i++)
            {
                grd_Task[0, i].Value = false;
            }
            txt_Search.Text = "Search...";

            for (int i = 0; i < grd_Client_Task.Rows.Count; i++)
            {
                grd_Client_Task[0, i].Value = false;
            }
            chk_Task.Checked = false;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            chk_Task.Checked = false;
            ddl_ClientName.SelectedIndex = 0;
            ddl_Task.SelectedIndex = 0;
            txt_Search.Text = "Search...";
            for (int i = 0; i < grd_Client_Task.Rows.Count; i++)
            {
                grd_Client_Task[0, i].Value = false;
            }
            for (int i = 0; i < grd_Task.Rows.Count; i++)
            {
                grd_Task[0, i].Value = false;
            }
        }

        private void txt_Search_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_Search.Text == "Search...")
            {
                txt_Search.Text = "";
            }
        }

      
    }
}
