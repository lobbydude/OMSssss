using System;
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
using System.Diagnostics;
namespace Ordermanagement_01
{
    public partial class Typing_Task_Confirmation : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        int Gv_Q_No, Pre_Q_No, Next_Q_No, questionno;
        string Gv_Q, Next_Q, Pre_Q, Gv_Group, Gv_Prev_Group, Gv_Next_Group;
        int User_Id, Row_Index, Col_index, Last_Q_No, AVAILABLE_COUNT, Last_Q_No_in;
        string ordertype, orderstatus, question, groupname, yes, no;
        int Updating_Current_Question_Value_ID, Updating_Previous_Question_Value_ID, Updating_Current_Question_Value_ID1, Updating_Previous_Question_Value_ID1, Updating_Next_Question_Value_ID, Updating_Next_Question_Value_ID1;
        int Current_Question_Value, Previous_Questio_Value, Next_Question_Value,Current_Question_Id,Previous_Question_Id;
        int insertion, Question_ID, Question_ID_NO;
        public Typing_Task_Confirmation(int userid)
        {
            InitializeComponent();
            User_Id = userid;
            Bind_Order_Status();
            Bind_Question_No();
            
            
           // GV_Q_Bind();


            foreach (DataGridViewColumn column in Gv_Question_Bind.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

           // Bind_Grid_Question();

        }
        private void Bind_Order_Status()
        {
            Hashtable htParam = new Hashtable();
            DataTable dt = new DataTable();
            htParam.Add("@Trans", "BIND");
            dt = dataaccess.ExecuteSP("Sp_Order_Status", htParam);
            //DataRow dr = dt.NewRow();
            //dr[0] = 0;
            //dr[4] = "Select";
            //dt.Rows.InsertAt(dr, 0);
            ddl_Status.DataSource = dt;
            ddl_Status_Search.DataSource = dt;
            ddl_Status.DisplayMember = "Order_Status";
            ddl_Status_Search.DisplayMember = "Order_Status";
            ddl_Status.ValueMember = "Order_Status_ID";
            ddl_Status_Search.ValueMember = "Order_Status_ID";

        }
        private void Bind_Question_No()
        {
            
                //Bind Question no
                Hashtable ht_QNO = new Hashtable();
                DataTable dt_QNO = new DataTable();
                DataTable dt_Q = new DataTable();
                ht_QNO.Add("@Trans", "BIND_QUESTION_NO");
                if (ddl_Status_Search.Text == "Typing" || ddl_Status_Search.Text == "Typing QC")
                {
                    ht_QNO.Add("@Order_Type_ABS", "COS");
                }
                else
                {
                    ht_QNO.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                }
                ht_QNO.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dt_QNO = dataaccess.ExecuteSP("Sp_Check_List", ht_QNO);
                dt_Q = dataaccess.ExecuteSP("Sp_Check_List", ht_QNO);


                ddl_Next_Question_Y.DataSource = dt_QNO;
                ddl_Next_Question_Y.DisplayMember = "Question_no";
                ddl_Next_Question_Y.ValueMember = "Question_no";


                ddl_Next_Question_N.DataSource = dt_Q;
                ddl_Next_Question_N.DisplayMember = "Question_no";
                ddl_Next_Question_N.ValueMember = "Question_no";
                lbl_Question_No.Text = (dt_Q.Rows.Count + 1).ToString();
                Last_Q_No = int.Parse((dt_Q.Rows.Count + 1).ToString());
                Last_Q_No_in =int.Parse((dt_Q.Rows.Count).ToString());
            
        }
        private void Bind_Grid_Question()
        {
            if (ddl_OrderType_Search.SelectedIndex != -1 && ddl_Status_Search.SelectedIndex !=-1)
            {
                Hashtable ht_BIND = new Hashtable();
                DataTable dt_BIND = new DataTable();
                ht_BIND.Add("@Trans", "QUESTION_BIND");
                if (ddl_Status_Search.Text == "Typing" || ddl_Status_Search.Text == "Typing QC")
                {
                    ht_BIND.Add("@Order_Type_ABS", "COS");
                }
                else
                {
                    ht_BIND.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                }
                ht_BIND.Add("@Order_Task_Id", ddl_Status_Search.SelectedValue.ToString());
                dt_BIND = dataaccess.ExecuteSP("Sp_Check_List", ht_BIND);

                if (dt_BIND.Rows.Count > 0)
                {
                    Gv_Question.Rows.Clear();
                    // Gv_Question.DataSource = dt_BIND;

                    for (int i = 0; i < dt_BIND.Rows.Count; i++)
                    {
                        Gv_Question.Rows.Add();
                        Gv_Question.Rows[i].Cells[0].Value = dt_BIND.Rows[i]["Question_no"].ToString();
                        Gv_Question.Rows[i].Cells[1].Value = dt_BIND.Rows[i]["Order_Type_ABS"].ToString();
                        Gv_Question.Rows[i].Cells[2].Value = dt_BIND.Rows[i]["Order_Status"].ToString();
                        Gv_Question.Rows[i].Cells[3].Value = dt_BIND.Rows[i]["Confirmation_Message"].ToString();
                        Gv_Question.Rows[i].Cells[4].Value = dt_BIND.Rows[i]["Group_Name"].ToString();
                        Gv_Question.Rows[i].Cells[5].Value = dt_BIND.Rows[i]["1"].ToString();
                        Gv_Question.Rows[i].Cells[6].Value = dt_BIND.Rows[i]["0"].ToString();
                        Gv_Question.Rows[i].Cells[7].Value = "View";
                        Gv_Question.Rows[i].Cells[8].Value = "Delete";
                        Gv_Question.Rows[i].Cells[9].Value = dt_BIND.Rows[i]["Status_ID"].ToString();
                        //Gv_Question.Rows[i].Cells[10].Value = dt_BIND.Rows[i]["Type_Task_Confirmation_Id"].ToString();
                    }

                }
                else
                {
                    Gv_Question.Rows.Clear();
                    lbl_Question_No.Text = "1";
                }
            }
            else
            {

            }
            
        }
        private void GV_Q_Bind()
        {
            if (ddl_OrderType_Search.SelectedIndex != -1 && ddl_Status_Search.SelectedIndex != -1)
            {
                Hashtable ht_BIND = new Hashtable();
                DataTable dt_BIND = new DataTable();
                ht_BIND.Add("@Trans", "BIND_QUESTION_NO");
                if (ddl_Status_Search.Text == "Typing" || ddl_Status_Search.Text == "Typing QC")
                {
                    ht_BIND.Add("@Order_Type_ABS", "COS");
                }
                else
                {
                    ht_BIND.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                }
                ht_BIND.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dt_BIND = dataaccess.ExecuteSP("Sp_Check_List", ht_BIND);

                if (dt_BIND.Rows.Count > 0)
                {
                    //Gv_Question_Bind.DataSource = dt_BIND;
                    Gv_Question_Bind.Rows.Clear();
                    // Gv_Question.DataSource = dt_BIND;

                    for (int i = 0; i < dt_BIND.Rows.Count; i++)
                    {
                        Gv_Question_Bind.Rows.Add();
                        Gv_Question_Bind.Rows[i].Cells[0].Value = i+1;
                        Gv_Question_Bind.Rows[i].Cells[1].Value = dt_BIND.Rows[i]["Question_no"].ToString();
                        Gv_Question_Bind.Rows[i].Cells[2].Value = dt_BIND.Rows[i]["Confirmation_Message"].ToString();
                        Gv_Question_Bind.Rows[i].Cells[3].Value = dt_BIND.Rows[i]["Group_Name"].ToString();
                        Gv_Question_Bind.Rows[i].Cells[4].Value = dt_BIND.Rows[i]["Type_Task_Confirmation_Id"].ToString();
                    }

                }
                else
                {
                    Gv_Question_Bind.DataSource = null;
                    Gv_Question_Bind.Rows.Clear();
                }
            }
        }
        private void Typing_Task_Confirmation_Load(object sender, EventArgs e)
        {
            Hashtable htParam = new Hashtable();
            DataTable dt = new DataTable();
            htParam.Add("@Trans", "ORDERTYPE_Group");
            dt = dataaccess.ExecuteSP("Sp_Order_Type", htParam);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Chk_List_OrderType.Items.Add(dt.Rows[i]["Order_Type_Abrivation"].ToString());
                ddl_Order_Type.Items.Add(dt.Rows[i]["Order_Type_Abrivation"].ToString());
                //ddl_Order_Type.Items[0] = "ALL";
                ddl_OrderType_Search.Items.Add(dt.Rows[i]["Order_Type_Abrivation"].ToString());
            }
           Task_Question_Disable();
        }
        private void Task_Question_Disable()
        {
            lbl_Question_No.Enabled = false;
            ddl_Status.Enabled = false;
            ddl_Order_Type.Enabled = false;
            ddl_Next_Question_N.Enabled = false;
            ddl_Next_Question_Y.Enabled = false;
            Txt_Question.Enabled = false;
            btn_Submit.Enabled = false;
            btn_Cancel.Enabled = false;
        }
        private void Task_Question_Enable()
        {
            lbl_Question_No.Enabled = true;
            ddl_Status.Enabled = true;
            ddl_Order_Type.Enabled = true;
            ddl_Next_Question_N.Enabled = true;
            ddl_Next_Question_Y.Enabled = true;
            Txt_Question.Enabled = true;
            btn_Submit.Enabled = true;
            btn_Cancel.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ht_Update1.Add("@Trans", "UPDATE_Q_NO");
            //ht_Update1.Add("@Group_Name", Gv_Prev_Group);
            //ht_Update1.Add("@Question_no", Pre_Q_No);
            //ht_Update1.Add("@Confirmation_Message", Gv_Q);
            //ht_Update1.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
            //ht_Update1.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
            //dt_Update1 = dataaccess.ExecuteSP("Sp_Check_List", ht_Update1);



            //ht_Update.Clear();
            //dt_Update.Clear();
            //ht_Update.Add("@Trans", "UPDATE_Q_NO");
            //ht_Update.Add("@Group_Name", Gv_Group);
            //ht_Update.Add("@Question_no", Gv_Q_No);
            //ht_Update.Add("@Confirmation_Message", Pre_Q);
            //ht_Update.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
            //ht_Update.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
            //dt_Update = dataaccess.ExecuteSP("Sp_Check_List", ht_Update);


            //Update Previous Question
            
            if (Gv_Question_Bind.Rows.Count > 0)
            {

                int rowscount = Gv_Question_Bind.Rows.Count;
                int index = Gv_Question_Bind.SelectedCells[0].OwningRow.Index;
                if (index == 0)
                {
                    return;
                }
                DataGridViewRowCollection rows = Gv_Question_Bind.Rows;

                // remove the previous row and add it behind the selected row.
                DataGridViewRow prevRow = rows[index - 1]; ;
                rows.Remove(prevRow);
                prevRow.Frozen = false;
                rows.Insert(index, prevRow);
                Gv_Question_Bind.ClearSelection();
                Gv_Question_Bind.Rows[index - 1].Selected = true;
                int Updating_Current_Question_Value = Current_Question_Value - 1;
                int Updating_Previous_Question_Value = Updating_Current_Question_Value + 1;
                Gv_Question_Bind.CurrentRow.Cells[0].Value = Updating_Current_Question_Value;
                prevRow.Cells[0].Value = Updating_Previous_Question_Value;

                //Update Current QUestrion
                
                /*Selecting Current question id*/
                Hashtable htcurrentID = new Hashtable();
                DataTable dtcurrentID = new DataTable();
                htcurrentID.Add("@Trans", "CURRENT_QUESTION_ID");
                htcurrentID.Add("@CurrentQuestion_no_Value", Updating_Current_Question_Value);
                htcurrentID.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                htcurrentID.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dtcurrentID = dataaccess.ExecuteSP("Sp_Check_List", htcurrentID);
                if (dtcurrentID.Rows.Count > 0)
                {
                    Updating_Current_Question_Value_ID = int.Parse(dtcurrentID.Rows[0]["Type_Task_Confirmation_Id"].ToString());
                    Updating_Current_Question_Value_ID1 = int.Parse(dtcurrentID.Rows[1]["Type_Task_Confirmation_Id"].ToString());
                }

                /*Selecting Previous Question Id*/

                Hashtable htpreviousID = new Hashtable();
                DataTable dtpreviousID = new DataTable();
                htpreviousID.Add("@Trans", "PREVIOUS_QUESTION_ID");
                htpreviousID.Add("@Updateing_Previous_Question_no", Updating_Previous_Question_Value);
                htpreviousID.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                htpreviousID.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dtpreviousID = dataaccess.ExecuteSP("Sp_Check_List", htpreviousID);
                if (dtpreviousID.Rows.Count > 0)
                {
                    Updating_Previous_Question_Value_ID = int.Parse(dtpreviousID.Rows[0]["Type_Task_Confirmation_Id"].ToString());
                    Updating_Previous_Question_Value_ID1 = int.Parse(dtpreviousID.Rows[1]["Type_Task_Confirmation_Id"].ToString());
                }

                


                Hashtable ht_Update = new Hashtable();
                
                DataTable dt_Update = new DataTable();
                
                ht_Update.Add("@Trans", "UPDATE_CUR_QUESTION");
                ht_Update.Add("@CurrentQuestion_no_Value", Updating_Previous_Question_Value);
                ht_Update.Add("@Updating_Current_Question_Value_ID", Updating_Current_Question_Value_ID);
                ht_Update.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));

                dt_Update = dataaccess.ExecuteSP("Sp_Check_List", ht_Update);

                Hashtable ht_Update2 = new Hashtable();
                DataTable dt_Update2 = new DataTable();
                ht_Update2.Add("@Trans", "UPDATE_CUR_QUESTION_false");
                ht_Update2.Add("@CurrentQuestion_no_Value", Updating_Previous_Question_Value);
                ht_Update2.Add("@Updating_Current_Question_Value_ID1", Updating_Current_Question_Value_ID1);
                ht_Update2.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update2.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));

                
                dt_Update2 = dataaccess.ExecuteSP("Sp_Check_List", ht_Update2);


                Hashtable ht_Update1 = new Hashtable();
                DataTable dt_Update1 = new DataTable();

                ht_Update1.Add("@Trans", "UPDATE_PREV_QUESTION");
                ht_Update1.Add("@PreviousQuestion_no_Value", Updating_Current_Question_Value);
                ht_Update1.Add("@Updating_Previous_Question_Value_ID", Updating_Previous_Question_Value_ID);
                ht_Update1.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update1.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dt_Update1 = dataaccess.ExecuteSP("Sp_Check_List", ht_Update1);

                Hashtable ht_Update3 = new Hashtable();
                DataTable dt_Update3 = new DataTable();
                
                ht_Update3.Add("@Trans", "UPDATE_PREV_QUESTION_false");
                ht_Update3.Add("@PreviousQuestion_no_Value", Updating_Current_Question_Value);
                ht_Update3.Add("@Updating_Previous_Question_Value_ID1", Updating_Previous_Question_Value_ID1);
                ht_Update3.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update3.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dt_Update3 = dataaccess.ExecuteSP("Sp_Check_List", ht_Update3);

                
                //GV_Q_Bind();
                Bind_Grid_Question();
                ht_Update.Clear();
                dt_Update.Clear();

                //Gv_Question_Bind.Rows[Current_Question_Value].Cells[1].Value = Updating_Current_Question_Value;
                //Gv_Question_Bind.Rows[Updating_Previous_Question_Value].Cells[1].Value = Updating_Previous_Question_Value;
                //set the gridvalue
                //int current = int.Parse(Gv_Question_Bind.Rows[Row_Index].Cells[0].Value.ToString());
                //for (int i = current; i <= Last_Q_No_in; i++)
                //{
                //    Gv_Question_Bind.Rows[i].Cells[0].Value = i++;
                //}

                Current_Question_Value = Current_Question_Value - 1;
            }

                //Pre_Q_No = 0;

                
        }

        private void Gv_Question_Bind_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int currentRow = Gv_Question_Bind.CurrentCell.RowIndex;
            //Gv_Question_Bind.Rows[currentRow].Selected = true;
            //if (e.RowIndex >= 0)
            //{
            //    Gv_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    Gv_Q = Gv_Question_Bind.Rows[e.RowIndex].Cells[1].Value.ToString();

            //    Gv_Group = Gv_Question_Bind.Rows[e.RowIndex].Cells[2].Value.ToString();


            //    if (e.RowIndex > 0)
            //    {
            //        Pre_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[0].Value.ToString());
            //        Pre_Q = Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[1].Value.ToString();
            //        Gv_Prev_Group = Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[2].Value.ToString();
            //    }
            //    else
            //    {
            //        Pre_Q_No = 0;
                    
            //    }
            //    if (e.RowIndex < Gv_Question_Bind.Rows.Count-1)
            //    {
            //        Next_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[0].Value.ToString());
            //        Next_Q = Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[1].Value.ToString();
            //        Gv_Next_Group = Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[2].Value.ToString();
            //    }
            //    else
            //    {
            //        Next_Q_No = 0;
            //    }
            //}
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            //if (Next_Q_No != 0)
            //{
            //    if (Gv_Question_Bind.Rows.Count > 0)
            //    {
            //        int rowCount = Gv_Question_Bind.Rows.Count;
            //        int index = Gv_Question_Bind.SelectedCells[0].OwningRow.Index;

            //        if (index == (rowCount - 2)) // include the header row
            //        {
            //            return;
            //        }
            //        DataGridViewRowCollection rows = Gv_Question_Bind.Rows;

            //        // remove the next row and add it in front of the selected row.
            //        DataGridViewRow nextRow = rows[index + 1];
            //        rows.Remove(nextRow);
            //        nextRow.Frozen = false;
            //        rows.Insert(index, nextRow);
            //        Gv_Question_Bind.ClearSelection();
            //        Gv_Question_Bind.Rows[index + 1].Selected = true;
            //        Gv_Question_Bind.CurrentRow.Cells[0].Value = Next_Q_No;
            //        nextRow.Cells[0].Value = Gv_Q_No;

            //        Hashtable ht_Update = new Hashtable();
            //        DataTable dt_Update = new DataTable();
            //        ht_Update.Add("@Trans", "UPDATE_Q_NO");
            //        ht_Update.Add("@Question_no", Next_Q_No);
            //        ht_Update.Add("@Group_Name", Gv_Next_Group);
            //        ht_Update.Add("@Confirmation_Message", Gv_Q);
            //        ht_Update.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
            //        ht_Update.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
            //        dt_Update = dataaccess.ExecuteSP("Sp_Check_List", ht_Update);

            //        ht_Update.Clear();
            //        dt_Update.Clear();
            //        ht_Update.Add("@Trans", "UPDATE_Q_NO");
            //        ht_Update.Add("@Question_no", Gv_Q_No);
            //        ht_Update.Add("@Group_Name", Gv_Group);
            //        ht_Update.Add("@Confirmation_Message", Next_Q);
            //        ht_Update.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
            //        ht_Update.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
            //        dt_Update = dataaccess.ExecuteSP("Sp_Check_List", ht_Update);
            //        //   GV_Q_Bind();
            //        Bind_Grid_Question();
            //        ht_Update.Clear();
            //        dt_Update.Clear();
            //    }
            //    Next_Q_No = 0;
            //}
            //else
            //{
            //    MessageBox.Show("Kindly select specified Question");
            //}

            if (Gv_Question_Bind.Rows.Count > 0)
              {

                  int rowCount = Gv_Question_Bind.Rows.Count;
                  int index = Gv_Question_Bind.SelectedCells[0].OwningRow.Index;

                  if (index == (rowCount - 2)) // include the header row
                  {
                      return;
                  }
                  DataGridViewRowCollection rows = Gv_Question_Bind.Rows;

                  // remove the next row and add it in front of the selected row.
                  DataGridViewRow nextRow = rows[index + 1];
                  rows.Remove(nextRow);
                  nextRow.Frozen = false;
                  rows.Insert(index, nextRow);
                  Gv_Question_Bind.ClearSelection();
                  Gv_Question_Bind.Rows[index + 1].Selected = true;
                  int Updating_Current_Question_Value = Current_Question_Value + 1;
                  int Updating_Next_Question_Value = Updating_Current_Question_Value - 1;
                  Gv_Question_Bind.CurrentRow.Cells[0].Value = Updating_Current_Question_Value;
                  nextRow.Cells[0].Value = Updating_Next_Question_Value;

                //Update Current QUestrion
                
                /*Selecting Current question id*/
                Hashtable htcurrentID = new Hashtable();
                DataTable dtcurrentID = new DataTable();
                htcurrentID.Add("@Trans", "CURRENT_QUESTION_ID");
                htcurrentID.Add("@CurrentQuestion_no_Value", Updating_Current_Question_Value);
                htcurrentID.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                htcurrentID.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dtcurrentID = dataaccess.ExecuteSP("Sp_Check_List", htcurrentID);
                if (dtcurrentID.Rows.Count > 0)
                {
                    Updating_Current_Question_Value_ID = int.Parse(dtcurrentID.Rows[0]["Type_Task_Confirmation_Id"].ToString());
                    Updating_Current_Question_Value_ID1 = int.Parse(dtcurrentID.Rows[1]["Type_Task_Confirmation_Id"].ToString());
                }

                /*Selecting Previous Question Id*/

                Hashtable htpreviousID = new Hashtable();
                DataTable dtpreviousID = new DataTable();
                htpreviousID.Add("@Trans", "NEXT_QUESTION_ID");
                htpreviousID.Add("@Updating_Next_Question_Value", Updating_Next_Question_Value);
                htpreviousID.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                htpreviousID.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dtpreviousID = dataaccess.ExecuteSP("Sp_Check_List", htpreviousID);
                if (dtpreviousID.Rows.Count > 0)
                {
                    Updating_Next_Question_Value_ID = int.Parse(dtpreviousID.Rows[0]["Type_Task_Confirmation_Id"].ToString());
                    Updating_Next_Question_Value_ID1 = int.Parse(dtpreviousID.Rows[1]["Type_Task_Confirmation_Id"].ToString());
                }




                Hashtable ht_Update = new Hashtable();

                DataTable dt_Update = new DataTable();

                ht_Update.Add("@Trans", "UPDATE_CURR_QUESTION");
                ht_Update.Add("@CurrentQuestion_no_Value", Updating_Next_Question_Value);
                ht_Update.Add("@Updating_Current_Question_Value_ID", Updating_Current_Question_Value_ID);
                ht_Update.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));

                dt_Update = dataaccess.ExecuteSP("Sp_Check_List", ht_Update);

                Hashtable ht_Update2 = new Hashtable();
                DataTable dt_Update2 = new DataTable();
                ht_Update2.Add("@Trans", "UPDATE_CURR_QUESTION_false");
                ht_Update2.Add("@CurrentQuestion_no_Value", Updating_Next_Question_Value);
                ht_Update2.Add("@Updating_Current_Question_Value_ID1", Updating_Current_Question_Value_ID1);
                ht_Update2.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update2.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));


                dt_Update2 = dataaccess.ExecuteSP("Sp_Check_List", ht_Update2);


                Hashtable ht_Update1 = new Hashtable();
                DataTable dt_Update1 = new DataTable();

                ht_Update1.Add("@Trans", "UPDATE_NEXT_QUESTION");
                ht_Update1.Add("@PreviousQuestion_no_Value", Updating_Current_Question_Value);
                ht_Update1.Add("@Updating_Next_Question_Value_ID", Updating_Next_Question_Value_ID);
                ht_Update1.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update1.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dt_Update1 = dataaccess.ExecuteSP("Sp_Check_List", ht_Update1);

                Hashtable ht_Update3 = new Hashtable();
                DataTable dt_Update3 = new DataTable();

                ht_Update3.Add("@Trans", "UPDATE_NEXT_QUESTION_false");
                ht_Update3.Add("@PreviousQuestion_no_Value", Updating_Current_Question_Value);
                ht_Update3.Add("@Updating_Next_Question_Value_ID1", Updating_Next_Question_Value_ID1);
                ht_Update3.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                ht_Update3.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dt_Update3 = dataaccess.ExecuteSP("Sp_Check_List", ht_Update3);


                //GV_Q_Bind();
                Bind_Grid_Question();
                ht_Update.Clear();
                dt_Update.Clear();

                Current_Question_Value = Current_Question_Value + 1;
            }
            //Pre_Q_No = 0;

                
        }
        private bool Validation()
        {
            if (ddl_GroupName.Text == "")
            {
                MessageBox.Show("Select Group Name");
                return false;
            }
            else if (ddl_Status.Text == "")
            {
                MessageBox.Show("Select Status Name");
                return false;
            }
            else if (ddl_Order_Type.Text == "")
            {
                MessageBox.Show("Select Order Type");
                return false;
            }
            else if (Txt_Question.Text == "")
            {
                MessageBox.Show("Kindly Enter Question");
                return false;
            }
            else if (ddl_Next_Question_Y.Text == "")
            {
                MessageBox.Show("Select Next Questions for Yes");
                return false;
            }
            else if (ddl_Next_Question_N.Text == "")
            {
                MessageBox.Show("Select Next Questions for No");
                return false;
            }
            return true;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            int QuestionNo=int.Parse(lbl_Question_No.Text.ToString());

            question = Txt_Question.Text;
            groupname = ddl_GroupName.Text;
            yes = ddl_Next_Question_Y.Text;
            no = ddl_Next_Question_N.Text;

            Hashtable htcheck = new Hashtable();
            DataTable dtcheck = new DataTable();
            htcheck.Add("@Trans", "CHECK_QUESTION");
            htcheck.Add("@Order_Type_ABS", ddl_Order_Type.Text);
            htcheck.Add("@Order_Status", ddl_Status.SelectedValue);
            htcheck.Add("@Confirmation_Message", question);
            htcheck.Add("@Group_Name", groupname);
            dtcheck = dataaccess.ExecuteSP("Sp_Check_List", htcheck);
            if (dtcheck.Rows.Count > 0)
            {
                //updation
                //if (QuestionNo <= Last_Q_No_in && QuestionNo != 0){
                if (Validation() != false)
                {
                    if (ddl_Next_Question_Y.Text != "")
                    {
                        Hashtable htupdate_s = new Hashtable();
                        DataTable dtupdate_s = new DataTable();
                        htupdate_s.Add("@Trans", "UPDATE_YES");
                        htupdate_s.Add("@Question_no", lbl_Question_No.Text);
                        htupdate_s.Add("@Next_Confirmation_Id", ddl_Next_Question_Y.Text);
                        htupdate_s.Add("@Confirmation_Message", Txt_Question.Text);
                        htupdate_s.Add("@Group_Name", ddl_GroupName.Text);
                        htupdate_s.Add("@Order_Type_ABS", ddl_Order_Type.Text);
                        htupdate_s.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
                        htupdate_s.Add("@Task_Confirmation", "True");
                        htupdate_s.Add("@Modified_By", User_Id);
                        htupdate_s.Add("@Modified_Date", DateTime.Now);
                        dtupdate_s = dataaccess.ExecuteSP("Sp_Check_List", htupdate_s);


                    }
                    if (ddl_Next_Question_N.Text != "")
                    {
                        Hashtable htupdate_n = new Hashtable();
                        DataTable dtupdate_n = new DataTable();
                        htupdate_n.Add("@Trans", "UPDATE_NO");
                        htupdate_n.Add("@Question_no", lbl_Question_No.Text);
                        htupdate_n.Add("@Confirmation_Message", Txt_Question.Text);
                        htupdate_n.Add("@Next_Confirmation_Id", ddl_Next_Question_N.Text);
                        htupdate_n.Add("@Group_Name", ddl_GroupName.Text);
                        htupdate_n.Add("@Order_Type_ABS", ddl_Order_Type.Text);
                        htupdate_n.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
                        htupdate_n.Add("@Task_Confirmation", "False");
                        htupdate_n.Add("@Modified_By", User_Id);
                        htupdate_n.Add("@Modified_Date", DateTime.Now);
                        dtupdate_n = dataaccess.ExecuteSP("Sp_Check_List", htupdate_n);
                    }
                    //changing gridview values
                    Gv_Question.Rows[Row_Index].Cells[3].Value = Txt_Question.Text;
                    Gv_Question.Rows[Row_Index].Cells[4].Value = ddl_GroupName.Text;
                    Gv_Question.Rows[Row_Index].Cells[5].Value = ddl_Next_Question_Y.Text;
                    Gv_Question.Rows[Row_Index].Cells[6].Value = ddl_Next_Question_N.Text;
                    MessageBox.Show(lbl_Question_No.Text + " Questions Updated Successfully");
                }
               // }
            }
            //insertion
            else
            {
                if (Validation() != false)
                {


                    Hashtable htinsert = new Hashtable();
                    DataTable dtinsert = new DataTable();

                    for (int i = 0; i < 2; i++)
                    {

                        if (i == 0)
                        {
                            htinsert.Add("@Trans", "INSERT");
                            htinsert.Add("@Question_no", lbl_Question_No.Text);
                            htinsert.Add("@Order_Type_ABS", ddl_Order_Type.Text);
                            htinsert.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
                            htinsert.Add("@Confirmation_Message", Txt_Question.Text);
                            htinsert.Add("@Group_Name", ddl_GroupName.Text);
                            htinsert.Add("@Next_Confirmation_Id", ddl_Next_Question_Y.Text);
                            htinsert.Add("@Task_Confirmation", "True");
                            htinsert.Add("@Inserted_By", User_Id);
                            htinsert.Add("@Inserted_Date", DateTime.Now);
                            dtinsert = dataaccess.ExecuteSP("Sp_Check_List", htinsert);
                        }
                        else if (i == 1)
                        {
                            Hashtable htinsertno = new Hashtable();
                            DataTable dtinsertno = new DataTable();
                            htinsertno.Add("@Trans", "INSERT");
                            htinsertno.Add("@Question_no", lbl_Question_No.Text);
                            htinsertno.Add("@Order_Type_ABS", ddl_Order_Type.Text);
                            htinsertno.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
                            htinsertno.Add("@Confirmation_Message", Txt_Question.Text);
                            htinsertno.Add("@Group_Name", ddl_GroupName.Text);
                            htinsertno.Add("@Next_Confirmation_Id", ddl_Next_Question_N.Text);
                            htinsertno.Add("@Task_Confirmation", "False");
                            htinsertno.Add("@Inserted_By", User_Id);
                            htinsertno.Add("@Inserted_Date", DateTime.Now);
                            dtinsertno = dataaccess.ExecuteSP("Sp_Check_List", htinsertno);
                        }
                    }

                    MessageBox.Show("Questions Inserted Successfully");
                    //  Bind_Grid_Question();
                }
            }
            GV_Q_Bind();
            Bind_Question_No();
           //Bind_Grid_Question();
            Txt_Question.Text = "";
        }
        private bool Validate_Question()
        {
            if (Txt_Question.Text == "")
            {
                return false;

            }
            return true;
        }


        private void clear()
        {
            Txt_Question.Text = "";
            btn_Submit.Text = "Submit";
            ddl_GroupName.SelectedIndex = 0;
            ddl_Next_Question_N.SelectedIndex = 0;
            ddl_Next_Question_Y.SelectedIndex = 0;
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {

            clear();
            Bind_Question_No();

        }

        private bool Validation_Search()
        {
            if(ddl_OrderType_Search.Text=="" || ddl_OrderType_Search.Text==null)
            {
                MessageBox.Show("Please select Order type");
                return false;
            }
            else if (ddl_Status_Search.Text == "" || ddl_Status_Search.Text == null)
            {
                MessageBox.Show("Please select Order Status");
                return false;
            }
            return true;
        }

        private void btn_Search_Submit_Click(object sender, EventArgs e)
        {
            if (Validation_Search()!=false)
            {
                if (ddl_OrderType_Search.Text == "COS")
                {
                   
                    grp_Order_TypeTask.Text = "Current Owner Search Task Questions";
                    ddl_Order_Type.Text = ddl_OrderType_Search.Text;
                    ddl_Status.Text = ddl_Status_Search.Text;

                }
                else if (ddl_OrderType_Search.Text == "TOS")
                {
                    grp_Order_TypeTask.Text = "Two Owner Search Task Questions";
                    ddl_Order_Type.Text = ddl_OrderType_Search.Text;
                    ddl_Status.Text = ddl_Status_Search.Text;
                }
                else if (ddl_OrderType_Search.Text == "US")
                {
                    grp_Order_TypeTask.Text = "Update Search Task Questions";
                    ddl_Order_Type.Text = ddl_OrderType_Search.Text;
                    ddl_Status.Text = ddl_Status_Search.Text;
                }
                else if (ddl_OrderType_Search.Text == "FS")
                {
                    grp_Order_TypeTask.Text = "Full Search Task Questions";
                    ddl_Order_Type.Text = ddl_OrderType_Search.Text;
                    ddl_Status.Text = ddl_Status_Search.Text;
                }
                else if (ddl_OrderType_Search.Text == "CCS")
                {
                    grp_Order_TypeTask.Text = "Current Owner - Commercial Task Questions";
                    ddl_Order_Type.Text = ddl_OrderType_Search.Text;
                    ddl_Status.Text = ddl_Status_Search.Text;
                }
                
                Bind_Grid_Question();
                GV_Q_Bind();
                Bind_Question_No();
                Task_Question_Enable();
            }
            
        }

        private void btn_Search_clear_Click(object sender, EventArgs e)
        {
            ddl_OrderType_Search.SelectedIndex = -1;
            ddl_Status_Search.SelectedIndex = -1;
           
            Gv_Question_Bind.Rows.Clear();
            Gv_Question.Rows.Clear();
            
            Task_Question_Disable();
            grp_Order_TypeTask.Text = "Check list Questions";
        }

        private void Gv_Question_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Row_Index = e.RowIndex;
            Col_index = e.ColumnIndex;
            if (e.ColumnIndex == 7)
            {
                ddl_Next_Question_Y.Visible = true;
                ddl_Next_Question_N.Visible = true;
                questionno = int.Parse(Gv_Question.Rows[e.RowIndex].Cells[0].Value.ToString());
                lbl_Question_No.Text = Gv_Question.Rows[e.RowIndex].Cells[0].Value.ToString();
                ddl_Order_Type.Text = Gv_Question.Rows[e.RowIndex].Cells[1].Value.ToString();
                ddl_Status.Text = Gv_Question.Rows[e.RowIndex].Cells[2].Value.ToString();
                Txt_Question.Text = Gv_Question.Rows[e.RowIndex].Cells[3].Value.ToString();
                ddl_GroupName.Text = Gv_Question.Rows[e.RowIndex].Cells[4].Value.ToString();
                ddl_Next_Question_Y.Text = Gv_Question.Rows[e.RowIndex].Cells[5].Value.ToString();
                ddl_Next_Question_N.Text = Gv_Question.Rows[e.RowIndex].Cells[6].Value.ToString();
                
                btn_Submit.Text = "Update";
            }
            else if (e.ColumnIndex == 8 && e.ColumnIndex !=-1)
            {

                questionno = int.Parse(Gv_Question.Rows[e.RowIndex].Cells[0].Value.ToString());
                ordertype = Gv_Question.Rows[e.RowIndex].Cells[1].Value.ToString();
                orderstatus = Gv_Question.Rows[e.RowIndex].Cells[2].Value.ToString();
                question = Gv_Question.Rows[e.RowIndex].Cells[3].Value.ToString();
                groupname = Gv_Question.Rows[e.RowIndex].Cells[4].Value.ToString();
                yes = Gv_Question.Rows[e.RowIndex].Cells[5].Value.ToString();
                no = Gv_Question.Rows[e.RowIndex].Cells[6].Value.ToString();
               

                //DELETE OPERATION
                Hashtable htselect_pre = new Hashtable();
                DataTable dtselect_pre = new DataTable();
                htselect_pre.Add("@Trans", "DELETE");
                htselect_pre.Add("@Question_no", questionno);
                htselect_pre.Add("@Order_Type_ABS", ordertype);
                htselect_pre.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dtselect_pre = dataaccess.ExecuteSP("Sp_Check_List", htselect_pre);

                
                int ques_no = questionno;
                //int prev = questionno - 1;
                int next = questionno + 1;
                //taken current quseston
                Hashtable htselect = new Hashtable();
                DataTable dtselect = new DataTable();
                htselect.Add("@Trans", "SELECT_NXTQUEST");
                htselect.Add("@Question_no", next);
                htselect.Add("@Order_Type_ABS", ordertype);
                htselect.Add("@Order_Status", int.Parse(ddl_Status_Search.SelectedValue.ToString()));
                dtselect = dataaccess.ExecuteSP("Sp_Check_List", htselect);
                if (dtselect.Rows.Count > 0)
                {
                    int T_QId = int.Parse(dtselect.Rows[0]["Type_Task_Confirmation_Id"].ToString());
                    int F_QId = int.Parse(dtselect.Rows[1]["Type_Task_Confirmation_Id"].ToString());

                    //Update Question number
                    for (int i = T_QId, j = F_QId; questionno < Last_Q_No; i = i + 2, j = j + 2, questionno++)
                    {
                        htselect.Clear();
                        dtselect.Clear();
                        htselect.Add("@Trans", "UPDATE_NXTQUEST");
                        htselect.Add("@Type_Task_Confirmation_Id", i);
                        htselect.Add("@Question_no", questionno);

                        dtselect = dataaccess.ExecuteSP("Sp_Check_List", htselect);

                        htselect.Clear();
                        dtselect.Clear();
                        htselect.Add("@Trans", "UPDATE_NXTQUEST");
                        htselect.Add("@Type_Task_Confirmation_Id", j);
                        htselect.Add("@Question_no", questionno);

                        dtselect = dataaccess.ExecuteSP("Sp_Check_List", htselect);

                    }


                    MessageBox.Show(ques_no + " Deleted Successfully");
                }
                Bind_Grid_Question();
                GV_Q_Bind();
                Bind_Question_No();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ddl_Status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ddl_OrderType_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_OrderType_Search.Text == "COS")
            {
                grp_Order_TypeTask.Text = "Current Owner Search Task Questions";
            }
            else if (ddl_OrderType_Search.Text == "CCS")
            {
                grp_Order_TypeTask.Text = "Commercial Current Owner Search Task Questions";
            }
            else if (ddl_OrderType_Search.Text == "US")
            {
                grp_Order_TypeTask.Text = "Update Search Task Questions";
            }
            else if (ddl_OrderType_Search.Text == "TOS")
            {
                grp_Order_TypeTask.Text = "Two Owner Search Task Questions";
            }
            else if (ddl_OrderType_Search.Text == "FS")
            {
                grp_Order_TypeTask.Text = "Full Search Task Questions";
            }
        }

        private void Gv_Question_Bind_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    Gv_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    Gv_Q = Gv_Question_Bind.Rows[e.RowIndex].Cells[1].Value.ToString();

            //    if (e.RowIndex > 0)
            //    {
            //        Pre_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[0].Value.ToString());
            //        Pre_Q = Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[1].Value.ToString();
            //    }
            //    else
            //    {
            //        Pre_Q_No = 0;
            //    }
            //    if (e.RowIndex < Gv_Question_Bind.Rows.Count - 1)
            //    {
            //        Next_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[0].Value.ToString());
            //        Next_Q = Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[1].Value.ToString();
            //    }
            //    else
            //    {
            //        Next_Q_No = 0;
            //    }
            //}
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            GV_Q_Bind();
            Bind_Grid_Question();
        }

        private void Gv_Question_Bind_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Row_Index = e.RowIndex;


            int currentRow = Gv_Question_Bind.CurrentCell.RowIndex;
            Gv_Question_Bind.Rows[currentRow].Selected = true;



            if (e.RowIndex >= 0)
            {
                 Current_Question_Id = int.Parse(Gv_Question_Bind.Rows[e.RowIndex].Cells[4].Value.ToString());

                Current_Question_Value = int.Parse(Gv_Question_Bind.Rows[e.RowIndex].Cells[0].Value.ToString());
                Previous_Questio_Value = Current_Question_Value - 1;
                Next_Question_Value = Current_Question_Value + 1;

                //Update Curerent Question to Next Question 

                //Update Previopus to Current Question Value 




            }
            else
            {
                MessageBox.Show("Click specified cell in the Grid");
            }

            //if (e.RowIndex >= 0)
            //{
            //    Gv_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex].Cells[0].Value.ToString());
            //    Gv_Q = Gv_Question_Bind.Rows[e.RowIndex].Cells[1].Value.ToString();

            //    Gv_Group = Gv_Question_Bind.Rows[e.RowIndex].Cells[2].Value.ToString();


            //    if (e.RowIndex > 0)
            //    {
            //        Pre_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[0].Value.ToString());
            //        Pre_Q = Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[1].Value.ToString();
            //        Gv_Prev_Group = Gv_Question_Bind.Rows[e.RowIndex - 1].Cells[2].Value.ToString();
            //    }
            //    else
            //    {
            //        Pre_Q_No = 0;

            //    }
            //    if (e.RowIndex < Gv_Question_Bind.Rows.Count - 1)
            //    {
            //        Next_Q_No = int.Parse(Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[0].Value.ToString());
            //        Next_Q = Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[1].Value.ToString();
            //        Gv_Next_Group = Gv_Question_Bind.Rows[e.RowIndex + 1].Cells[2].Value.ToString();
            //    }
            //    else
            //    {
            //        Next_Q_No = 0;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("");
            //}
        }

        private void Gv_Question_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Gv_Question_Enter(object sender, EventArgs e)
        {
            
        }

        private void Gv_Question_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != 0 && e.ColumnIndex != 0)
            //{
            //    if (e.ColumnIndex != 7 && e.ColumnIndex != 8)
            //    {
            //        //if (Gv_Question.Rows[e.RowIndex].Cells[0].Value.ToString() != "0")
            //        //{
            //            if (ddl_Next_Question_Y.Text != "")
            //            {
            //                Hashtable htupdate_s = new Hashtable();
            //                DataTable dtupdate_s = new DataTable();
            //                htupdate_s.Add("@Trans", "UPDATE_YES");
            //                htupdate_s.Add("@Question_no", Gv_Question.Rows[e.RowIndex].Cells[0].Value.ToString());
            //                htupdate_s.Add("@Order_Type_ABS", Gv_Question.Rows[e.RowIndex].Cells[1].Value.ToString());
            //                htupdate_s.Add("@Order_Status", Gv_Question.Rows[e.RowIndex].Cells[9].Value.ToString());
            //                htupdate_s.Add("@Confirmation_Message", Gv_Question.Rows[e.RowIndex].Cells[3].Value.ToString());
            //                htupdate_s.Add("@Group_Name", Gv_Question.Rows[e.RowIndex].Cells[4].Value.ToString());
            //                htupdate_s.Add("@Next_Confirmation_Id", int.Parse(Gv_Question.Rows[e.RowIndex - 1].Cells[5].Value.ToString()));
            //                htupdate_s.Add("@Task_Confirmation", "True");
            //                dtupdate_s = dataaccess.ExecuteSP("Sp_Check_List", htupdate_s);
            //            }
            //            if (ddl_Next_Question_N.Text != "")
            //            {
            //                Hashtable htupdate_n = new Hashtable();
            //                DataTable dtupdate_n = new DataTable();
            //                htupdate_n.Add("@Trans", "UPDATE_NO");
            //                htupdate_n.Add("@Question_no", Gv_Question.Rows[e.RowIndex].Cells[0].Value.ToString());
            //                htupdate_n.Add("@Order_Type_ABS", Gv_Question.Rows[e.RowIndex].Cells[1].Value.ToString());
            //                htupdate_n.Add("@Order_Status", Gv_Question.Rows[e.RowIndex].Cells[9].Value.ToString());
            //                htupdate_n.Add("@Confirmation_Message", Gv_Question.Rows[e.RowIndex].Cells[3].Value.ToString());
            //                htupdate_n.Add("@Group_Name", Gv_Question.Rows[e.RowIndex].Cells[4].Value.ToString());
            //                htupdate_n.Add("@Next_Confirmation_Id", int.Parse(Gv_Question.Rows[e.RowIndex - 1].Cells[6].Value.ToString()));
            //                htupdate_n.Add("@Task_Confirmation", "False");
            //                dtupdate_n = dataaccess.ExecuteSP("Sp_Check_List", htupdate_n);
            //            }
            //            //changing gridview values
            //            //Gv_Question.Rows[Row_Index].Cells[3].Value = Txt_Question.Text;
            //            //Gv_Question.Rows[Row_Index].Cells[4].Value = ddl_GroupName.Text;
            //            //Gv_Question.Rows[Row_Index].Cells[5].Value = ddl_Next_Question_Y.Text;
            //            //Gv_Question.Rows[Row_Index].Cells[6].Value = ddl_Next_Question_N.Text;
            //            // MessageBox.Show(Gv_Question.Rows[e.RowIndex].Cells[0].Value.ToString() + " Questions Updated Successfully");

            //        //}
            //    }
            //}
        }

        private void Gv_Question_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            
        }

        private void Gv_Question_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Gv_Question_Bind_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Gv_Question_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Gv_Question_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Gv_Question_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }

        private void Gv_Question_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Gv_Question_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {
            //if (Validation() != false)
            //{


                
                //  Bind_Grid_Question();
            //}
        }

        private void Gv_Question_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void Gv_Question_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //    Hashtable htinsert = new Hashtable();
            //    DataTable dtinsert = new DataTable();

            //    for (int i = 0; i < 2; i++)
            //    {

            //        if (i == 0)
            //        {
            //            htinsert.Add("@Trans", "INSERT");
            //            htinsert.Add("@Question_no", lbl_Question_No.Text);
            //            htinsert.Add("@Order_Type_ABS", ddl_Order_Type.Text);
            //            htinsert.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
            //            htinsert.Add("@Confirmation_Message", Txt_Question.Text);
            //            htinsert.Add("@Group_Name", ddl_GroupName.Text);
            //            htinsert.Add("@Next_Confirmation_Id", ddl_Next_Question_Y.Text);
            //            htinsert.Add("@Task_Confirmation", "True");
            //            htinsert.Add("@Inserted_By", User_Id);
            //            htinsert.Add("@Inserted_Date", DateTime.Now);
            //            dtinsert = dataaccess.ExecuteSP("Sp_Check_List", htinsert);
            //        }
            //        else if (i == 1)
            //        {
            //            Hashtable htinsertno = new Hashtable();
            //            DataTable dtinsertno = new DataTable();
            //            htinsertno.Add("@Trans", "INSERT");
            //            htinsertno.Add("@Question_no", lbl_Question_No.Text);
            //            htinsertno.Add("@Order_Type_ABS", ddl_Order_Type.Text);
            //            htinsertno.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
            //            htinsertno.Add("@Confirmation_Message", Txt_Question.Text);
            //            htinsertno.Add("@Group_Name", ddl_GroupName.Text);
            //            htinsertno.Add("@Next_Confirmation_Id", ddl_Next_Question_N.Text);
            //            htinsertno.Add("@Task_Confirmation", "False");
            //            htinsertno.Add("@Inserted_By", User_Id);
            //            htinsertno.Add("@Inserted_Date", DateTime.Now);
            //            dtinsertno = dataaccess.ExecuteSP("Sp_Check_List", htinsertno);
            //        }
            //    }

            //    MessageBox.Show("Questions Inserted Successfully");
            //}
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < Gv_Question.Rows.Count-1; i++)
            {
                questionno = int.Parse(Gv_Question.Rows[i].Cells[0].Value.ToString());
                
                question = Gv_Question.Rows[i].Cells[3].Value.ToString();
                groupname = Gv_Question.Rows[i].Cells[4].Value.ToString();
                if (Gv_Question.Rows[i].Cells[5].Value != null)
                {
                    yes = Gv_Question.Rows[i].Cells[5].Value.ToString();
                    no = Gv_Question.Rows[i].Cells[6].Value.ToString();
                }
                else
                {
                    yes = " ";
                    no = " ";
                }

                Hashtable htcheck = new Hashtable();
                DataTable dtcheck = new DataTable();
                htcheck.Add("@Trans", "CHECK_QUESTION");
                htcheck.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                htcheck.Add("@Order_Status", ddl_Status_Search.SelectedValue);
                htcheck.Add("@Confirmation_Message", question);
                htcheck.Add("@Group_Name", groupname);
                dtcheck = dataaccess.ExecuteSP("Sp_Check_List", htcheck);
                if (dtcheck.Rows.Count > 0)
                {
                    //Question_ID = int.Parse(dtcheck.Rows[0]["Type_Task_Confirmation_Id"].ToString());
                    //Question_ID_NO = int.Parse(dtcheck.Rows[1]["Type_Task_Confirmation_Id"].ToString());
                    //updation
                    if (yes != "")
                    {
                        Hashtable htupdate_s = new Hashtable();
                        DataTable dtupdate_s = new DataTable();
                        htupdate_s.Add("@Trans", "UPDATE_YES");
                        //htupdate_s.Add("@Type_Task_Confirmation_Id", Question_ID);
                        htupdate_s.Add("@Question_no", questionno);
                        htupdate_s.Add("@Next_Confirmation_Id", yes);
                        htupdate_s.Add("@Confirmation_Message", question);
                        htupdate_s.Add("@Group_Name", groupname);
                        htupdate_s.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                        htupdate_s.Add("@Order_Status", ddl_Status.SelectedValue);
                        htupdate_s.Add("@Task_Confirmation", "True");
                        htupdate_s.Add("@Modified_By", User_Id);
                        htupdate_s.Add("@Modified_Date", DateTime.Now);
                        dtupdate_s = dataaccess.ExecuteSP("Sp_Check_List", htupdate_s);
                    }
                    if (no != "")
                    {
                        Hashtable htupdate_n = new Hashtable();
                        DataTable dtupdate_n = new DataTable();
                        htupdate_n.Add("@Trans", "UPDATE_NO");
                        //htupdate_n.Add("@Type_Task_Confirmation_Id", Question_ID_NO);
                        htupdate_n.Add("@Question_no", questionno);
                        htupdate_n.Add("@Confirmation_Message", question);
                        htupdate_n.Add("@Next_Confirmation_Id", no);
                        htupdate_n.Add("@Group_Name", groupname);
                        htupdate_n.Add("@Order_Type_ABS", ddl_OrderType_Search.Text);
                        htupdate_n.Add("@Order_Status", ddl_Status_Search.SelectedValue);
                        htupdate_n.Add("@Task_Confirmation", "False");
                        htupdate_n.Add("@Modified_By", User_Id);
                        htupdate_n.Add("@Modified_Date", DateTime.Now);
                        dtupdate_n = dataaccess.ExecuteSP("Sp_Check_List", htupdate_n);
                    }
                }
                else
                {
                    //insertion
                    if (GridValidation() != false)
                    {
                        Hashtable htinsert = new Hashtable();
                        DataTable dtinsert = new DataTable();

                        for (int j = 0; j < 2; j++)
                        {

                            if (j == 0)
                            {
                                htinsert.Add("@Trans", "INSERT");
                                htinsert.Add("@Question_no", lbl_Question_No.Text);
                                htinsert.Add("@Order_Type_ABS", ddl_Order_Type.Text);
                                htinsert.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
                                htinsert.Add("@Confirmation_Message", question);
                                htinsert.Add("@Group_Name", groupname);
                                htinsert.Add("@Next_Confirmation_Id", yes);
                                htinsert.Add("@Task_Confirmation", "True");
                                htinsert.Add("@Inserted_By", User_Id);
                                htinsert.Add("@Inserted_Date", DateTime.Now);
                                dtinsert = dataaccess.ExecuteSP("Sp_Check_List", htinsert);
                            }
                            else if (j == 1)
                            {
                                Hashtable htinsertno = new Hashtable();
                                DataTable dtinsertno = new DataTable();
                                htinsertno.Add("@Trans", "INSERT");
                                htinsertno.Add("@Question_no", lbl_Question_No.Text);
                                htinsertno.Add("@Order_Type_ABS", ddl_Order_Type.Text);
                                htinsertno.Add("@Order_Status", ddl_Status.SelectedValue.ToString());
                                htinsertno.Add("@Confirmation_Message", question);
                                htinsertno.Add("@Group_Name", groupname);
                                htinsertno.Add("@Next_Confirmation_Id", no);
                                htinsertno.Add("@Task_Confirmation", "False");
                                htinsertno.Add("@Inserted_By", User_Id);
                                htinsertno.Add("@Inserted_Date", DateTime.Now);
                                dtinsertno = dataaccess.ExecuteSP("Sp_Check_List", htinsertno);
                            }
                        }

                    }
                    insertion = 1;
                }
                
            }
            if (insertion == 0)
            {
                MessageBox.Show("Old Questions Updated Successfully");
                Bind_Grid_Question();
                Bind_Question_No();
                GV_Q_Bind();
            }
            else
            {
                MessageBox.Show("New Questions Inserted.. Old Questions Updated Successfully");
                Bind_Grid_Question();
                Bind_Question_No();
                GV_Q_Bind();
            }
        }
        private bool GridValidation()
        {
            if (questionno == 0 || questionno == null)
            {
                MessageBox.Show("Check question number");
                return false;
            }
            else if (question == "")
            {
                MessageBox.Show("Check Question");
                return false;
            }
            else if (groupname == "")
            {
                MessageBox.Show("Check Group Name");
                return false;
            }
            else if (yes == "")
            {
                MessageBox.Show("Check Task Yes Question Number");
                return false;
            }
            else if (no == "")
            {
                MessageBox.Show("Check Task No Question Number");
                return false;
            }
            return true;
        }
    }
}

