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

namespace Ordermanagement_01.Tax
{
    public partial class Tax_Order_Reallocate : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        Classes.TaxClass taxcls = new Classes.TaxClass();
           System.Data.DataTable dtuser = new System.Data.DataTable();
           int Chk_Allocate_Count;
           string User_Id,User_Role;
         static  string lbl_Order_Id;
        public Tax_Order_Reallocate(string USER_ID,string USER_ROLE)
        {
            InitializeComponent();
            User_Id = USER_ID;
            User_Role = USER_ROLE;
            this.Text = "SEARCH TAX ORDERS";
        }

        

        private void Tax_Order_Reallocate_Load(object sender, EventArgs e)
        {
            txt_Order_number.Focus();
            taxcls.BindTax_UserName(ddl_UserName);
            taxcls.BindTax_Task(ddl_Task);
        }

        private void txt_Order_number_TextChanged(object sender, EventArgs e)
        {
            if (txt_Order_number.Text != "")
            { 
            
                  Hashtable htuser = new Hashtable();
           
                htuser.Add("@Trans", "GET_ORDER_DETAILS_BY_ORDER_NUMBER");
                htuser.Add("@Client_Order_Number",txt_Order_number.Text.Trim().ToString());
                
                dtuser = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htuser);
          
              
            
                grd_order_Allocated.Columns[0].Width = 35;
                grd_order_Allocated.Columns[1].Width = 50;
                grd_order_Allocated.Columns[2].Width = 130;
                grd_order_Allocated.Columns[3].Width = 120;
                grd_order_Allocated.Columns[4].Width = 150;
                grd_order_Allocated.Columns[5].Width = 160;
                grd_order_Allocated.Columns[6].Width = 120;
                grd_order_Allocated.Columns[7].Width = 110;
                grd_order_Allocated.Columns[8].Width = 100;
                grd_order_Allocated.Columns[9].Width = 100;
                grd_order_Allocated.Columns[10].Width = 100;
                grd_order_Allocated.Columns[11].Width = 125;
                if (dtuser.Rows.Count > 0)
                {
                    grd_order_Allocated.Rows.Clear();

                    for (int i = 0; i < dtuser.Rows.Count; i++)
                    {
                        grd_order_Allocated.Rows.Add();
                        grd_order_Allocated.Rows[i].Cells[1].Value = i + 1;


                        grd_order_Allocated.Rows[i].Cells[2].Value = dtuser.Rows[i]["Client_Order_Number"].ToString();
                        grd_order_Allocated.Rows[i].Cells[3].Value = dtuser.Rows[i]["Order_Type"].ToString();
                        grd_order_Allocated.Rows[i].Cells[4].Value = dtuser.Rows[i]["Borrower_Name"].ToString();
                        grd_order_Allocated.Rows[i].Cells[5].Value = dtuser.Rows[i]["Address"].ToString();
                        grd_order_Allocated.Rows[i].Cells[6].Value = dtuser.Rows[i]["State"].ToString();
                        grd_order_Allocated.Rows[i].Cells[7].Value = dtuser.Rows[i]["County"].ToString();
                        grd_order_Allocated.Rows[i].Cells[8].Value = dtuser.Rows[i]["Order_Status"].ToString();
                        grd_order_Allocated.Rows[i].Cells[9].Value = dtuser.Rows[i]["Tax_Task"].ToString();
                        grd_order_Allocated.Rows[i].Cells[10].Value = dtuser.Rows[i]["Tax_Status"].ToString();
                        grd_order_Allocated.Rows[i].Cells[11].Value = dtuser.Rows[i]["User_Name"].ToString();
                        grd_order_Allocated.Rows[i].Cells[12].Value = dtuser.Rows[i]["Order_ID"].ToString();
                        grd_order_Allocated.Rows[i].Cells[13].Value = dtuser.Rows[i]["User_Id"].ToString();
                        grd_order_Allocated.Rows[i].Cells[14].Value = dtuser.Rows[i]["Tax_Task_Id"].ToString();
                       

                    }
                }
                else
                {

                    grd_order_Allocated.DataSource = null;
                    grd_order_Allocated.Rows.Clear();

                }

            }
            }


        private bool Validate_Order_Agent_Lvel()
        {

            Hashtable ht = new Hashtable();
            DataTable dt = new DataTable();

            ht.Add("@Trans", "CHECK_ORDER_AGENT_LEVEL_COMPLETED");
            ht.Add("@Order_Id",lbl_Order_Id);
            dt = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", ht);

            int count;
            if (dt.Rows.Count > 0)
            {

                count = int.Parse(dt.Rows[0]["count"].ToString());

            }
            else
            {

                count = 0;
            }

            if (count == 0)
            {
                MessageBox.Show("This Order Agent Level is not completed");

                return false;
            }
            else
            {

                return true;
            }
        }
        private void btn_Reassign_Click(object sender, EventArgs e)
        {
              int CheckedCount = 0;

              if (ddl_UserName.SelectedIndex > 0 && ddl_Task.SelectedIndex > 0)
              {

                  int allocated_Userid = int.Parse(ddl_UserName.SelectedValue.ToString());

                  int Tax_Task_Id = int.Parse(ddl_Task.SelectedValue.ToString());


                  CheckedCount = 1;
                   lbl_Order_Id = grd_order_Allocated.Rows[0].Cells[12].Value.ToString();
                  Hashtable htinsertrec = new Hashtable();
                  System.Data.DataTable dtinsertrec = new System.Data.DataTable();
                  DateTime date = new DateTime();
                  date = DateTime.Now;
                  string dateeval = date.ToString("dd/MM/yyyy");
                  string time = date.ToString("hh:mm tt");

                  int Check_Count;

                  if (Tax_Task_Id == 2 && Validate_Order_Agent_Lvel()!=false)
                  {

                      if (Tax_Task_Id == 2)
                      {

                          Hashtable htchk = new Hashtable();
                          System.Data.DataTable dtchk = new System.Data.DataTable();
                          htchk.Add("@Trans", "CHECK_ORDER_COMPLTED_BY_ALLOCATED_USER");
                          htchk.Add("@Order_Id", lbl_Order_Id);
                          htchk.Add("@User_Id", allocated_Userid);
                          dtchk = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htchk);
                          if (dtchk.Rows.Count > 0)
                          {

                              Chk_Allocate_Count = int.Parse(dtchk.Rows[0]["count"].ToString());
                          }
                          else
                          {

                              Chk_Allocate_Count = 0;
                          }
                      }

                      if (Tax_Task_Id == 2 && Chk_Allocate_Count == 0)
                      {

                          Hashtable htchk_Assign = new Hashtable();
                          System.Data.DataTable dtchk_Assign = new System.Data.DataTable();
                          htchk_Assign.Add("@Trans", "CHECK");
                          htchk_Assign.Add("@Order_Id", lbl_Order_Id);
                          dtchk_Assign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htchk_Assign);
                          if (dtchk_Assign.Rows.Count > 0)
                          {


                              Hashtable htupassin = new Hashtable();
                              System.Data.DataTable dtupassign = new System.Data.DataTable();

                              htupassin.Add("@Trans", "DELET_BY_ORDER");
                              htupassin.Add("@Order_Id", lbl_Order_Id);


                              dtupassign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htupassin);
                          }




                          htinsertrec.Add("@Trans", "INSERT");
                          htinsertrec.Add("@Order_Id", lbl_Order_Id);
                          htinsertrec.Add("@User_Id", allocated_Userid);
                          htinsertrec.Add("@Tax_Task_Id", Tax_Task_Id);
                          htinsertrec.Add("@Tax_Status_Id", 7);
                          htinsertrec.Add("@Assigned_Date", dateeval);
                          htinsertrec.Add("@Assigned_By", User_Id);
                          htinsertrec.Add("@Inserted_By", User_Id);
                          htinsertrec.Add("@Inserted_date", date);
                          htinsertrec.Add("@Status", "True");
                          dtinsertrec = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htinsertrec);

                          Hashtable htupdate = new Hashtable();
                          System.Data.DataTable dtupdate = new System.Data.DataTable();
                          htupdate.Add("@Trans", "UPDATE_TAX_ORDER_STATUS");
                          htupdate.Add("@Order_Id", lbl_Order_Id);
                          htupdate.Add("@Order_Status", 14);
                          htupdate.Add("@Modified_By", User_Id);
                          htupdate.Add("@Modified_Date", date);
                          dtupdate = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htupdate);

                          Hashtable httaxupdate = new Hashtable();
                          System.Data.DataTable dttaxupdate = new System.Data.DataTable();
                          httaxupdate.Add("@Trans", "UPDATE_TAX_STATUS");
                          httaxupdate.Add("@Order_Id", lbl_Order_Id);
                          httaxupdate.Add("@Tax_Status_Id", 7);
                          httaxupdate.Add("@Modified_By", User_Id);
                          httaxupdate.Add("@Modified_Date", date);
                          dttaxupdate = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", httaxupdate);


                          MessageBox.Show("Order Reassigend Sucessfully");
                          //Update tbl_Order_Progress




                          //OrderHistory
                          //Hashtable ht_Order_History = new Hashtable();
                          //System.Data.DataTable dt_Order_History = new System.Data.DataTable();
                          //ht_Order_History.Add("@Trans", "INSERT");
                          //ht_Order_History.Add("@Order_Id", lbl_Order_Id);
                          //ht_Order_History.Add("@User_Id", allocated_Userid);
                          //ht_Order_History.Add("@Status_Id", Order_Status_Id);
                          //ht_Order_History.Add("@Progress_Id", 6);
                          //ht_Order_History.Add("@Work_Type", 1);
                          //ht_Order_History.Add("@Assigned_By", User_id);
                          //ht_Order_History.Add("@Modification_Type", "Order Allocate");
                          //dt_Order_History = dataaccess.ExecuteSP("Sp_Order_History", ht_Order_History);
                      }
                      else
                      {
                          MessageBox.Show("This Order Processed by the Same User");

                      }
                  }
                  else if (Tax_Task_Id == 1)
                  {
                      Hashtable htchk_Assign = new Hashtable();
                      System.Data.DataTable dtchk_Assign = new System.Data.DataTable();
                      htchk_Assign.Add("@Trans", "CHECK");
                      htchk_Assign.Add("@Order_Id", lbl_Order_Id);
                      dtchk_Assign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htchk_Assign);
                      if (dtchk_Assign.Rows.Count > 0)
                      {


                          Hashtable htupassin = new Hashtable();
                          System.Data.DataTable dtupassign = new System.Data.DataTable();

                          htupassin.Add("@Trans", "DELET_BY_ORDER");
                          htupassin.Add("@Order_Id", lbl_Order_Id);


                          dtupassign = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htupassin);
                      }




                      htinsertrec.Add("@Trans", "INSERT");
                      htinsertrec.Add("@Order_Id", lbl_Order_Id);
                      htinsertrec.Add("@User_Id", allocated_Userid);
                      htinsertrec.Add("@Tax_Task_Id", Tax_Task_Id);
                      htinsertrec.Add("@Tax_Status_Id", 7);
                      htinsertrec.Add("@Assigned_Date", dateeval);
                      htinsertrec.Add("@Assigned_By", User_Id);
                      htinsertrec.Add("@Inserted_By", User_Id);
                      htinsertrec.Add("@Inserted_date", date);
                      htinsertrec.Add("@Status", "True");
                      dtinsertrec = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htinsertrec);

                      Hashtable htupdate = new Hashtable();
                      System.Data.DataTable dtupdate = new System.Data.DataTable();
                      htupdate.Add("@Trans", "UPDATE_TAX_ORDER_STATUS");
                      htupdate.Add("@Order_Id", lbl_Order_Id);
                      htupdate.Add("@Order_Status", 14);
                      htupdate.Add("@Modified_By", User_Id);
                      htupdate.Add("@Modified_Date", date);
                      dtupdate = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", htupdate);

                      Hashtable httaxupdate = new Hashtable();
                      System.Data.DataTable dttaxupdate = new System.Data.DataTable();
                      httaxupdate.Add("@Trans", "UPDATE_TAX_STATUS");
                      httaxupdate.Add("@Order_Id", lbl_Order_Id);
                      httaxupdate.Add("@Tax_Status_Id", 7);
                      httaxupdate.Add("@Modified_By", User_Id);
                      httaxupdate.Add("@Modified_Date", date);
                      dttaxupdate = dataaccess.ExecuteSP("Sp_Tax_Order_Allocate", httaxupdate);


                      MessageBox.Show("Order Reassigend Sucessfully");

                  }
              }
              else
              {

                  MessageBox.Show("Select Username and Task");
              }

                   
              

             
                  
            
             
            }

        private void grd_order_Allocated_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (e.ColumnIndex == 2)
                {

                    string Order_Id = grd_order_Allocated.Rows[e.RowIndex].Cells[12].Value.ToString();
                    string Order_Number = grd_order_Allocated.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Tax.Tax_Order_View taxorview = new Tax_Order_View(Order_Id, User_Id, Order_Number, User_Role);
                    taxorview.Show();
                }
            }
        }
           
        }
        
    
}
