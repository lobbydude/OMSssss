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
using System.Collections;
using System.DirectoryServices;

namespace Ordermanagement_01.Abstractor
{  
    public partial class Abstractor_Entry : Form
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
        int Abstractor_Id;
        string OPERATION;
        string ABSTRACT_ID;
        string Region_Type;
        int State, County;
        int Check;
        string[] FName;
        string Document_Name;
        string Abstractor_Name;
        public Abstractor_Entry(string AbstractorName,string abstractor_id,string Operation,int User_Id)
        {
            InitializeComponent();
            userid = User_Id;
            OPERATION=Operation.ToString();
            ABSTRACT_ID=abstractor_id.ToString();
            dbc.BindState(ddl_Search_State);
            if(OPERATION=="Insert")
            {
              

          
               btn_Save.Text="Add New Abstractor";
               btn_W9_Upload.Enabled = false;
               btn_Eno_Upload.Enabled = false;

               lbl_Created_Date.Text = DateTime.Now.ToString();
            }
            else if(OPERATION=="Update")
            {
                btn_W9_Upload.Enabled = true;
                btn_Eno_Upload.Enabled = true;
                Get_Abstror_Details();
                Gridview_Bind_State_County_Details();
                Grd_Document_upload_Load();
                btn_Save.Text="Update Abstractor";
            }
        }

      


        public void Get_Abstror_Details()
        {

            Hashtable htselect = new System.Collections.Hashtable();
            DataTable dtselect = new DataTable();
            htselect.Add("@Trans", "SELECT_ABSTRACTOR_WISE");
            htselect.Add("@Abstractor_Id", ABSTRACT_ID);
            dtselect = dataaccess.ExecuteSP("Sp_Abstractor_Detail", htselect);
          
            if (dtselect.Rows.Count > 0)
            {

                txt_Abstractor_Name.Text = dtselect.Rows[0]["Name"].ToString();
              //  ddl_State.SelectedValue = dtselect.Rows[0]["State_Id"].ToString();
                //if (ddl_State.SelectedIndex > 0)
                //{
                //    int stateid = int.Parse(ddl_State.SelectedValue.ToString());
                //    dbc.BindCounty(ddl_County, stateid);

                //}
                //if (dtselect.Rows[0]["County_ID"].ToString() != "0")
                //{
                //    ddl_County.SelectedValue = dtselect.Rows[0]["County_ID"].ToString();
                //}
                //else
                //{
                //    ddl_County.SelectedValue = "SELECT";
                //}


                txt_Contact_Name.Text = dtselect.Rows[0]["Contact_Name"].ToString();
                txt_ZipCode.Text = dtselect.Rows[0]["Zip_Code"].ToString();
                ddl_gender.Text = dtselect.Rows[0]["Gender"].ToString();
                txt_Phone_No.Text = dtselect.Rows[0]["Phone_No"].ToString();
                txt_Alternative_Phone_No.Text = dtselect.Rows[0]["Alternative_Phone_No"].ToString();
                txt_Email.Text = dtselect.Rows[0]["Email"].ToString();
                txt_alternative_Email.Text = dtselect.Rows[0]["Alternative_Email"].ToString();
                txt_Fax_No.Text = dtselect.Rows[0]["Fax_No"].ToString();
                txt_alternative_Fax_no.Text = dtselect.Rows[0]["Alternative_Fax"].ToString();
                txt_Address.Text = dtselect.Rows[0]["Address"].ToString();
                ddl_Employee_Type.Text = dtselect.Rows[0]["Employee_Type"].ToString();
                ddl_PaymentType.Text = dtselect.Rows[0]["Payment_Type"].ToString();
                txt_Bank_Name.Text = dtselect.Rows[0]["Bank_Name"].ToString();
                txt_Bank_Address.Text = dtselect.Rows[0]["Bank_Address"].ToString();
                txt_Account_No.Text = dtselect.Rows[0]["Account_No"].ToString();
                lbl_Created_Date.Text = dtselect.Rows[0]["Instered_Date"].ToString();
                Region_Type = dtselect.Rows[0]["Region_Type"].ToString();
                txt_Routing_Number.Text = dtselect.Rows[0]["Routing_No"].ToString();
                if (dtselect.Rows[0]["Send_Mode"].ToString() != null && dtselect.Rows[0]["Send_Mode"].ToString() !="")
                {
                    ddl_SendMode.Text = dtselect.Rows[0]["Send_Mode"].ToString();
                }
                else
                {
                    ddl_SendMode.SelectedIndex = 0;
                }
                if (Region_Type == "1")
                {

                    rbtn_Regional.Checked = true;
                }
                else if (Region_Type == "2")
                {

                    rbtn_Multiple_State.Checked = true;
                }
                else if (Region_Type == "3")
                {

                    rbtn_nation_Wide.Checked = true;
                }

                var status = dtselect.Rows[0]["Abstractor_Status"];

                if (Convert.ToBoolean(status)==true)
                {
                    ddl_abstractor_status.SelectedIndex = 1;
                }
                else
                {
                    ddl_abstractor_status.SelectedIndex = 2;
                }


               


                Hashtable htcost = new System.Collections.Hashtable();
                DataTable dtcost = new DataTable();
                htcost.Add("@Trans", "SELECT_ABSTRACTOR_WISE");
                htcost.Add("@Abstractor_Id", ABSTRACT_ID);
                dtcost = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htcost);
                if (dtcost.Rows.Count > 0)
                {

                    grd_Services.Rows.Clear();
                    for (int i = 0; i < dtcost.Rows.Count; i++)
                    {
                        grd_Services.AutoGenerateColumns = false;
                        grd_Services.Rows.Add();
                        grd_Services.Rows[i].Cells[0].Value = i + 1;
                        //grd_Services.Rows[i].Cells[0].Value = i + 1;
                        grd_Services.Rows[i].Cells[1].Value = dtcost.Rows[i]["Order_Type"].ToString();
                        grd_Services.Rows[i].Cells[2].Value = dtcost.Rows[i]["Cost"].ToString();
                        grd_Services.Rows[i].Cells[3].Value = dtcost.Rows[i]["Tat"].ToString();

                        grd_Services.Rows[i].Cells[4].Value = dtcost.Rows[i]["Order_Type_Id"].ToString();
                    }
                }





            }
        }
      

        

        public bool validate()
        {

            if (txt_Abstractor_Name.Text == "")
            {

                MessageBox.Show("Please Enter Abstractor Name");
                txt_Abstractor_Name.Focus();
                return false;
            }
            //if (ddl_State.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Please Select State");
            //    txt_Abstractor_Name.Focus();
            //    return false;

            //}
            //if (ddl_County.SelectedIndex == 0)
            //{

            //    MessageBox.Show("Please Select County");
            //    txt_Abstractor_Name.Focus();
            //    return false;
            //}
            
            return true;

        }

        public void Gridview_Bind_Abstractor_Cost_Tat()
        {
            Hashtable htselect = new System.Collections.Hashtable();
            DataTable dtselect = new DataTable();
            htselect.Add("@Trans", "SELECT_ABSTRACTOR_WISE");
            htselect.Add("@Abstractor_Id", ABSTRACT_ID);
            htselect.Add("@State", State);
            htselect.Add("@County", County);
            dtselect = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htselect);
            if (dtselect.Rows.Count > 0)
            {
                grd_Services.Rows.Clear();
                for (int i = 0; i < dtselect.Rows.Count; i++)
                {
                    grd_Services.AutoGenerateColumns = false;
                    grd_Services.Rows.Add();
                    grd_Services.Rows[i].Cells[0].Value = i + 1;
                    //grd_Services.Rows[i].Cells[0].Value = i + 1;
                    grd_Services.Rows[i].Cells[1].Value = dtselect.Rows[i]["Order_Type"].ToString();
                    grd_Services.Rows[i].Cells[2].Value = dtselect.Rows[i]["Cost"].ToString();
                    grd_Services.Rows[i].Cells[3].Value = dtselect.Rows[i]["Tat"].ToString();
                    grd_Services.Rows[i].Cells[4].Value = dtselect.Rows[i]["Order_Type_Id"].ToString();
                }
            }

        
            


        }
        public void Gridview_Bind_Abstractor_Cost_Tat_Befor()
        {
            Hashtable htselect = new System.Collections.Hashtable();
            DataTable dtselect = new DataTable();
            htselect.Add("@Trans", "SELECT_ABSTRACT_COST_BEFORE");
           
           
            dtselect = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htselect);
            if (dtselect.Rows.Count > 0)
            {
                grd_Services.Rows.Clear();
                for (int i = 0; i < dtselect.Rows.Count; i++)
                {
                    grd_Services.AutoGenerateColumns = false;
                    grd_Services.Rows.Add();
                    grd_Services.Rows[i].Cells[0].Value = i + 1;
                    //grd_Services.Rows[i].Cells[0].Value = i + 1;
                    grd_Services.Rows[i].Cells[1].Value = dtselect.Rows[i]["Order_Type"].ToString();

                    grd_Services.Rows[i].Cells[4].Value = dtselect.Rows[i]["Order_Type_Id"].ToString();
                }
            }





        }
        public void Gridview_Bind_State_County_Details()
        {

            if (ddl_Search_State.SelectedIndex > 0)
            {

                Hashtable htsel = new System.Collections.Hashtable();
                DataTable dtsel = new DataTable();
                htsel.Add("@Trans", "SELECT_STATE_COUNTY_STATE_WISE");
                htsel.Add("@Abstractor_Id", ABSTRACT_ID);
                htsel.Add("@State_ID", int.Parse(ddl_Search_State.SelectedValue.ToString()));
                dtsel = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htsel);
                if (dtsel.Rows.Count > 0)
                {
                    gridstate.Rows.Clear();
                    for (int i = 0; i < dtsel.Rows.Count; i++)
                    {
                        gridstate.AutoGenerateColumns = false;
                        gridstate.Rows.Add();
                        gridstate.Rows[i].Cells[0].Value = i + 1;
                        //grd_Services.Rows[i].Cells[0].Value = i + 1;
                        gridstate.Rows[i].Cells[1].Value = dtsel.Rows[i]["State"].ToString();
                                                          
                        gridstate.Rows[i].Cells[2].Value = dtsel.Rows[i]["County"].ToString();
                        gridstate.Rows[i].Cells[3].Value = dtsel.Rows[i]["State_ID"].ToString();
                        gridstate.Rows[i].Cells[4].Value = dtsel.Rows[i]["County_ID"].ToString();
                    }
                }
                else
                {
                    gridstate.Rows.Clear();

                }

            }
            else
            {
                Hashtable htselect = new System.Collections.Hashtable();
                DataTable dtselect = new DataTable();
                htselect.Add("@Trans", "SELECT_STATE_COUNTY");
                htselect.Add("@Abstractor_Id", ABSTRACT_ID);
                dtselect = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htselect);
                if (dtselect.Rows.Count > 0)
                {
                    gridstate.Rows.Clear();
                    for (int i = 0; i < dtselect.Rows.Count; i++)
                    {
                        gridstate.AutoGenerateColumns = false;
                        gridstate.Rows.Add();
                        gridstate.Rows[i].Cells[0].Value = i + 1;
                        //grd_Services.Rows[i].Cells[0].Value = i + 1;
                        gridstate.Rows[i].Cells[1].Value = dtselect.Rows[i]["State"].ToString();

                        gridstate.Rows[i].Cells[2].Value = dtselect.Rows[i]["County"].ToString();
                        gridstate.Rows[i].Cells[3].Value = dtselect.Rows[i]["State_ID"].ToString();
                        gridstate.Rows[i].Cells[4].Value = dtselect.Rows[i]["County_ID"].ToString();
                    }
                }
                else
                {

                    gridstate.Rows.Clear();
                }

            }
           



        }
        private void btn_Save_Click(object sender, EventArgs e)
        {

            if (validate() != false && btn_Save.Text == "Add New Abstractor")
            {
                Hashtable htorder = new Hashtable();
                DataTable dtorder = new DataTable();
                 bool abstractor_status=true;

                //int state = int.Parse(ddl_State.SelectedValue.ToString());
              //  int county = int.Parse(ddl_County.SelectedValue.ToString());

                if (rbtn_Regional.Checked == true)
                {

                    Region_Type = "1";
                }
                else if (rbtn_Multiple_State.Checked == true)
                {

                    Region_Type = "2";
                }
                else if (rbtn_nation_Wide.Checked == true)
                {

                    Region_Type = "3";
                }
                else {

                    Region_Type = "0";
                }


                if (ddl_gender.Text != "")
                {


                    Gender = ddl_gender.SelectedItem.ToString();
                }
                else
                {

                    Gender = "";
                }

                if (ddl_Employee_Type.Text != "")
                {

                    Employee_Type = ddl_Employee_Type.SelectedItem.ToString();
                }
                else
                {

                    Employee_Type = "";
                }
                if (ddl_PaymentType.Text != "")
                {

                    PaymentType = ddl_PaymentType.SelectedItem.ToString();
                }
                else
                {

                    PaymentType = "";
                }
                if(ddl_abstractor_status.Text=="Enable")
                {
                    abstractor_status=true;
                }
                else if(ddl_abstractor_status.Text=="Disable")
                {
                    abstractor_status=false;
                }
               
               

                DateTime date = new DateTime();
                date = DateTime.Now;
                string dateeval = date.ToString("dd/MM/yyyy");
                htorder.Add("@Trans", "INSERT");

                htorder.Add("@Name",txt_Abstractor_Name.Text);
                htorder.Add("@Contact_Name", txt_Contact_Name.Text);
                htorder.Add("@State", 0);
                htorder.Add("@County",0);
                htorder.Add("@Phone_No",txt_Phone_No.Text);
                htorder.Add("@Alternative_Phone_No", txt_Alternative_Phone_No.Text);
                htorder.Add("@Gender", Gender);
               
                htorder.Add("@Zip_Code", txt_ZipCode.Text);
                htorder.Add("@Email", txt_Email.Text.ToString());
                htorder.Add("@Alternative_Email", txt_alternative_Email.Text.ToString());
                htorder.Add("@Fax_No",txt_Fax_No.Text.ToString());
                htorder.Add("@Alternative_Fax", txt_alternative_Fax_no.Text.ToString());
                htorder.Add("@Address", txt_Address.Text.ToString());

                htorder.Add("@Send_Mode", ddl_SendMode.Text.ToString());

                htorder.Add("@Employee_Type", Employee_Type.ToString());
                // htorder.Add("@Search_Type", Search_type);
                htorder.Add("@Payment_Type", PaymentType.ToString());
                htorder.Add("@Bank_Name", txt_Bank_Name.Text);
                htorder.Add("@Account_No", txt_Account_No.Text);
                htorder.Add("@Bank_Address", txt_Bank_Address.Text);
                htorder.Add("@Region_Type",int.Parse(Region_Type.ToString()));
                htorder.Add("@Status", "True");
               
                htorder.Add("@Inserted_By", userid);
                htorder.Add("@Instered_Date", date);

                htorder.Add("@Routing_No", txt_Routing_Number.Text);
                htorder.Add("@Abstractor_Status", abstractor_status);



                object id = dataaccess.ExecuteSPForScalar("Sp_Abstractor_Detail", htorder);



                MessageBox.Show("New Abstractor Added Sucessfully");
                btn_Cancel_Click( sender,  e);
              
            }
            else if(validate()!=false && btn_Save.Text=="Update Abstractor")
            {
             Hashtable htorder = new Hashtable();
                DataTable dtorder = new DataTable();
                bool abstractor_status = true;
               // int state = int.Parse(ddl_State.SelectedValue.ToString());
                //int county = int.Parse(ddl_County.SelectedValue.ToString());

                if (ddl_gender.Text != "")
                {


                    Gender = ddl_gender.SelectedItem.ToString();
                }
                else
                {

                    Gender = "";
                }

                if (ddl_Employee_Type.Text != "")
                {

                    Employee_Type = ddl_Employee_Type.SelectedItem.ToString();
                }
                else
                {

                    Employee_Type = "";
                }
                if (ddl_PaymentType.Text != "")
                {

                    PaymentType = ddl_PaymentType.SelectedItem.ToString();
                }
                else
                {

                    PaymentType = "";
                }
                if (rbtn_Regional.Checked == true)
                {

                    Region_Type = "1";
                }
                else if (rbtn_Multiple_State.Checked == true)
                {

                    Region_Type = "2";
                }
                else if (rbtn_nation_Wide.Checked == true)
                {

                    Region_Type = "3";
                }
                else
                {

                    Region_Type = "0";
                }
                if (ddl_abstractor_status.Text == "Enable")
                {
                    abstractor_status = true;
                }
                else if (ddl_abstractor_status.Text == "Disable")
                {
                    abstractor_status = false;
                }


               
                DateTime date = new DateTime();
                date = DateTime.Now;
                string dateeval = date.ToString("dd/MM/yyyy");
                htorder.Add("@Trans", "UPDATE");
                 htorder.Add("@Abstractor_Id",ABSTRACT_ID);
                htorder.Add("@Name",txt_Abstractor_Name.Text);
                htorder.Add("@Contact_Name", txt_Contact_Name.Text);
                htorder.Add("@State", 0);
                htorder.Add("@County",0);
                htorder.Add("@Gender", Gender);
                htorder.Add("@Zip_Code", txt_ZipCode.Text);
                htorder.Add("@Phone_No", txt_Phone_No.Text);

                htorder.Add("@Alternative_Phone_No", txt_Alternative_Phone_No.Text);
                htorder.Add("@Email", txt_Email.Text.ToString());
                htorder.Add("@Alternative_Email", txt_alternative_Email.Text.ToString());
                htorder.Add("@Fax_No", txt_Fax_No.Text.ToString());
                htorder.Add("@Alternative_Fax", txt_alternative_Fax_no.Text.ToString());
                htorder.Add("@Address", txt_Address.Text.ToString());
                htorder.Add("@Send_Mode", ddl_SendMode.Text.ToString());
                htorder.Add("@Employee_Type", Employee_Type.ToString());
                // htorder.Add("@Search_Type", Search_type);
                htorder.Add("@Payment_Type", PaymentType.ToString());
                htorder.Add("@Bank_Name", txt_Bank_Name.Text);
                htorder.Add("@Account_No", txt_Account_No.Text);
                htorder.Add("@Bank_Address", txt_Bank_Address.Text);
                htorder.Add("@Region_Type", int.Parse(Region_Type.ToString()));
                htorder.Add("@Status", "True");
               
                htorder.Add("@Inserted_By", userid);
                htorder.Add("@Instered_Date", date);

                htorder.Add("@Routing_No", txt_Routing_Number.Text);
                htorder.Add("@Abstractor_Status", abstractor_status);

                 dtorder = dataaccess.ExecuteSP("Sp_Abstractor_Detail", htorder);


                //for (int i = 0; i < grd_Services.Rows.Count; i++)
                //{

                //        if (grd_Services.Rows[i].Cells[2].Value != "" && grd_Services.Rows[i].Cells[2].Value != null)
                //        {
                //            Abstractor_Cost = Convert.ToDecimal(grd_Services.Rows[i].Cells[2].Value.ToString());

                //        }
                //        else
                //        {

                //            Abstractor_Cost = 0;
                //        }


                //        if (grd_Services.Rows[i].Cells[3].Value != "" && grd_Services.Rows[i].Cells[3].Value != null)
                //        {
                //            Abstractor_Tat = int.Parse(grd_Services.Rows[i].Cells[3].Value.ToString());

                //        }
                //        else
                //        {

                //            Abstractor_Tat = 0;
                //        }

                //        if (grd_Services.Rows[i].Cells[4].Value != null)
                //        {
                //            Order_Type_Id = int.Parse(grd_Services.Rows[i].Cells[4].Value.ToString());
                //        }


                //        Hashtable htcheck = new System.Collections.Hashtable();
                //        DataTable dtcheck = new DataTable();
                //        htcheck.Add("@Trans", "CHECK");
                //        htcheck.Add("@Abstractor_Id", ABSTRACT_ID);
                //        htcheck.Add("@Order_Type_Id", Order_Type_Id);
                //        dtcheck = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htcheck);
                //        int check;
                //        if (dtcheck.Rows.Count > 0)
                //        {

                //            check = int.Parse(dtcheck.Rows[0]["count"].ToString());
                //        }
                //        else
                //        {

                //            check = 0;
                //        }
                //        Hashtable htcost = new System.Collections.Hashtable();
                //        DataTable dtcost = new DataTable();
                //        if (check == 0)
                //        {
                //            htcost.Add("@Trans", "INSERT");
                //            htcost.Add("@Abstractor_Id", ABSTRACT_ID);
                //            htcost.Add("@Order_Type_Id", Order_Type_Id);
                //            htcost.Add("@Cost", Abstractor_Cost);
                //            htcost.Add("@Tat", Abstractor_Tat);
                //            htcost.Add("@Status", "True");
                //            htcost.Add("@Inserted_By", userid);
                //            htcost.Add("@Instered_Date", date);
                //            dtcost = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htcost);
                //        }
                //        else if (check > 0)
                //        {

                //            htcost.Add("@Trans", "UPDATE");
                //            htcost.Add("@Abstractor_Id", ABSTRACT_ID);
                //            htcost.Add("@Order_Type_Id", Order_Type_Id);
                //            htcost.Add("@Cost", Abstractor_Cost);
                //            htcost.Add("@Tat", Abstractor_Tat);

                //            htcost.Add("@Modified_By", userid);
                //            htcost.Add("@Modified_Date", date);
                //            dtcost = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htcost);

                //        }
                   
                //}
                MessageBox.Show("New Abstractor Updated Sucessfully");

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Abstractor_Name.Text = "";
            ddl_gender.SelectedIndex = 0;
            ddl_PaymentType.SelectedIndex = 0;
            ddl_Search_State.SelectedIndex = 0;
            ddl_Employee_Type.SelectedIndex = 0;
            txt_ZipCode.Text = "";
            ddl_gender.Text = "";
            txt_Email.Text = "";
            txt_Fax_No.Text ="";
            txt_Address.Text ="";
            ddl_Employee_Type.Text ="";
            ddl_PaymentType.Text = 
            txt_Bank_Name.Text = "";
            txt_Bank_Address.Text ="";
            txt_Account_No.Text = "";
            txt_Phone_No.Text = "";
            txt_Alternative_Phone_No.Text = "";
            txt_alternative_Email.Text = "";
            txt_Contact_Name.Text = "";
           
            btn_Save.Text = "Add New Abstractor";

        }

        private void gridstate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                State = int.Parse(gridstate.Rows[e.RowIndex].Cells[3].Value.ToString());
                County = int.Parse(gridstate.Rows[e.RowIndex].Cells[4].Value.ToString());
                


                Hashtable hscheck = new Hashtable();
                DataTable dtcheck = new System.Data.DataTable();


                hscheck.Add("@Trans", "CHECK_ABSTRACT_COST");
                hscheck.Add("@Abstractor_Id", ABSTRACT_ID);
                hscheck.Add("@County", County);
                dtcheck = dataaccess.ExecuteSP("Sp_Abstractor_Cost", hscheck);

                Check = int.Parse(dtcheck.Rows[0]["count"].ToString());
                if (Check == 0)
                {
                    Gridview_Bind_Abstractor_Cost_Tat_Befor();
                
                }
                else if (Check > 0)
                {
                    Gridview_Bind_Abstractor_Cost_Tat();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
   
            
            for (int i = 0; i < grd_Services.Rows.Count; i++)
            {

                if (grd_Services.Rows[i].Cells[2].Value != "" && grd_Services.Rows[i].Cells[2].Value != null)
                {
                    Abstractor_Cost = Convert.ToDecimal(grd_Services.Rows[i].Cells[2].Value.ToString());

                }
                else
                {

                    Abstractor_Cost = 0;
                }


                if (grd_Services.Rows[i].Cells[3].Value != "" && grd_Services.Rows[i].Cells[3].Value != null)
                {
                    Abstractor_Tat = int.Parse(grd_Services.Rows[i].Cells[3].Value.ToString());

                }
                else
                {

                    Abstractor_Tat = 0;
                }

                if (grd_Services.Rows[i].Cells[4].Value != null)
                {
                    Order_Type_Id = int.Parse(grd_Services.Rows[i].Cells[4].Value.ToString());
                }

                DateTime date = new DateTime();
                date = DateTime.Now;
                string dateeval = date.ToString("dd/MM/yyyy");
                Hashtable htcheck = new System.Collections.Hashtable();
                DataTable dtcheck = new DataTable();
                htcheck.Add("@Trans", "CHECK");
                htcheck.Add("@Abstractor_Id", ABSTRACT_ID);
                htcheck.Add("@Order_Type_Id", Order_Type_Id);
                htcheck.Add("@County", County);
                dtcheck = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htcheck);
                int check;
                if (dtcheck.Rows.Count > 0)
                {

                    check = int.Parse(dtcheck.Rows[0]["count"].ToString());
                }
                else
                {

                    check = 0;
                }
                Hashtable htcost = new System.Collections.Hashtable();
                DataTable dtcost = new DataTable();
                if (check == 0)
                {
                    htcost.Add("@Trans", "INSERT");
                    htcost.Add("@Abstractor_Id", ABSTRACT_ID);
                    htcost.Add("@State", State);
                    htcost.Add("@County", County);
                    htcost.Add("@Order_Type_Id", Order_Type_Id);
                    htcost.Add("@Cost", Abstractor_Cost);
                    htcost.Add("@Tat", Abstractor_Tat);
                    htcost.Add("@Status", "True");
                    htcost.Add("@Inserted_By", userid);
                    htcost.Add("@Instered_Date", date);
                    dtcost = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htcost);
                }
                else if (check > 0)
                {

                    htcost.Add("@Trans", "UPDATE");
                    htcost.Add("@Abstractor_Id", ABSTRACT_ID);
                    htcost.Add("@State", State);
                    htcost.Add("@County", County);
                    htcost.Add("@Order_Type_Id", Order_Type_Id);
                    htcost.Add("@Cost", Abstractor_Cost);
                    htcost.Add("@Tat", Abstractor_Tat);

                    htcost.Add("@Modified_By", userid);
                    htcost.Add("@Modified_Date", date);
                    dtcost = dataaccess.ExecuteSP("Sp_Abstractor_Cost", htcost);

                }

            }

            MessageBox.Show("Cost Tat Submited Sucessfully");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Upload_DocuemtS()
        {

            Hashtable htorderkb = new Hashtable();
            DataTable dtorderkb = new System.Data.DataTable();
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Multiselect = true;
            op1.ShowDialog();
            op1.Filter = "allfiles|*.xls";
            // txt_path.Text = op1.FileName;
            int count = 0;

          
            Abstractor_Name = txt_Abstractor_Name.Text;
            foreach (string s in op1.FileNames)
            {
                FName = s.Split('\\');
                string dest_path1 = @"\\192.168.12.33\ABSTRACTOR-DOCUMENTS\" + Abstractor_Name + @"\" + Document_Name + @"\" + FName[FName.Length - 1];
                DirectoryEntry de = new DirectoryEntry(dest_path1, "administrator", "password1$");
                de.Username = "administrator";
                de.Password = "password1$";

                Directory.CreateDirectory(@"\\192.168.12.33\ABSTRACTOR-DOCUMENTS\" + Abstractor_Name + @"\" + Document_Name);

                File.Copy(s, dest_path1, true);
                
                count++;
                htorderkb.Clear();
                dtorderkb.Clear();
                htorderkb.Add("@Trans", "INSERT");
                htorderkb.Add("@Doc_Name", Document_Name);
                htorderkb.Add("@Abstractor_Id", ABSTRACT_ID);
                htorderkb.Add("@Document_Name", op1.SafeFileName);
                //htorderkb.Add("@Chk_UploadPackage", chk_Upload.Checked);
                // htorderkb.Add("@Extension", extension);
                htorderkb.Add("@Document_Path", dest_path1);
                htorderkb.Add("@Inserted_By", userid);
                htorderkb.Add("@Inserted_date", DateTime.Now);
                dtorderkb = dataaccess.ExecuteSP("Sp_Abstractor_Document_Upload", htorderkb);
                Grd_Document_upload_Load();
            }
            MessageBox.Show(Convert.ToString(count) + " File(s) copied");
        }
        private void btn_W9_Upload_Click(object sender, EventArgs e)
        {
            Document_Name = "W9Copy";
            Upload_DocuemtS();
        }
        protected void Grd_Document_upload_Load()
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            Hashtable htDocument_Select = new Hashtable();
            DataTable dtDocument_Select = new System.Data.DataTable();
            htDocument_Select.Add("@Trans", "SELECT");
            htDocument_Select.Add("@Abstractor_Id",ABSTRACT_ID);
            // htselSourceuploadkb.Add("@Tax_Type_Id", Tax_Type_Id);
            dtDocument_Select = dataaccess.ExecuteSP("Sp_Abstractor_Document_Upload", htDocument_Select);
            if (dtDocument_Select.Rows.Count > 0)
            {

                Grd_Document_upload.DataSource = null;
                Grd_Document_upload.Columns.Clear();
                Grd_Document_upload.Rows.Clear();
                //ex2.Visible = true;
                Grd_Document_upload.Visible = true;
                Grd_Document_upload.AutoGenerateColumns = false;
                Grd_Document_upload.ColumnCount = 8;

                Grd_Document_upload.Columns[0].Name = "Doc_Name";
                Grd_Document_upload.Columns[0].HeaderText = "DOC NAME";
                Grd_Document_upload.Columns[0].DataPropertyName = "Doc_Name";

                Grd_Document_upload.Columns[1].Name = "DocumentPath";
                Grd_Document_upload.Columns[1].HeaderText = "FILE PATH";
                Grd_Document_upload.Columns[1].DataPropertyName = "Document_Path";
                Grd_Document_upload.Columns[1].Visible = false;

                Grd_Document_upload.Columns[2].Name = "FileName";
                Grd_Document_upload.Columns[2].HeaderText = "FILE NAME";
                Grd_Document_upload.Columns[2].DataPropertyName = "Document_Name";

                Grd_Document_upload.Columns[3].Name = "username";
                Grd_Document_upload.Columns[3].HeaderText = "USER NAME";
                Grd_Document_upload.Columns[3].DataPropertyName = "User_Name";

                Grd_Document_upload.Columns[4].Name = "upload_id";
                Grd_Document_upload.Columns[4].HeaderText = "upload_id";
                Grd_Document_upload.Columns[4].DataPropertyName = "Document_Upload_Id";
                Grd_Document_upload.Columns[4].Visible = false;
                Grd_Document_upload.Columns[5].Visible = false;
                Grd_Document_upload.Columns[6].Visible = false;
                Grd_Document_upload.Columns[7].Visible = false;
               
               


                Grd_Document_upload.Columns.Add(btn);
                btn.HeaderText = "Open";
                btn.Text = "Open";
                btn.Name = "btn";

                Grd_Document_upload.Columns.Add(btnEdit);
                btnEdit.HeaderText = "Edit";
                btnEdit.Text = "Edit";
                btnEdit.Name = "btnEdit";

                Grd_Document_upload.Columns.Add(btnDelete);
                btnDelete.HeaderText = "Delete";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                //Grd_Document_upload.Columns[3].Name = "Open";
                //Grd_Document_upload.Columns[3].HeaderText = "Open";
                Grd_Document_upload.DataSource = dtDocument_Select;
                //Grd_Document_upload.DataBind();
                //btnDownload.Visible = true;
            }
            else
            {
                Grd_Document_upload.DataSource = null;
                //Grd_Document_upload.EmptyDataText = "No Records Are Avilable";
                //Grd_Document_upload.DataBind();
            }
            for (int i = 0; i < dtDocument_Select.Rows.Count; i++)
            {
                for (int j = 0; j < Grd_Document_upload.Rows.Count; j++)
                {
                    Grd_Document_upload.Rows[j].Cells[8].Value = "View";
                    Grd_Document_upload.Rows[j].Cells[9].Value = "Edit";
                    Grd_Document_upload.Rows[j].Cells[10].Value = "Delete";
                   
                }
            }
        }

        private void btn_Eno_Upload_Click(object sender, EventArgs e)
        {
            Document_Name = "EOCopy";
            Upload_DocuemtS();
        }

        private void Grd_Document_upload_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex == 8)
            {
                FName = Grd_Document_upload.Rows[e.RowIndex].Cells[2].Value.ToString().Split('\\');
                //OpenFileDialog op1 = new OpenFileDialog();
                //string loc_path = @"C:\Temp\" + Order_No + @"\" + FName[FName.Length - 1];
                //Directory.CreateDirectory(@"C:\Temp\" + Order_No);
                string Source_Path = Grd_Document_upload.Rows[e.RowIndex].Cells[1].Value.ToString();
                // Directory.CreateDirectory(Source_Path);
                System.Diagnostics.Process.Start(Source_Path);
                //File.Copy(Source_Path, loc_path,true);
                //op1.InitialDirectory = @"C:\Temp\" + Order_No;
                //op1.ShowDialog();
            }
           
            if (e.ColumnIndex == 9)
            {
                Hashtable htEdit = new Hashtable();
                DataTable dtEdit = new System.Data.DataTable();
                htEdit.Add("@Trans", "UPDATE");
                htEdit.Add("@Document_Upload_Id", Grd_Document_upload.Rows[e.RowIndex].Cells[4].Value);
                htEdit.Add("@Doc_Name", Grd_Document_upload.Rows[e.RowIndex].Cells[0].Value);
                dtEdit = dataaccess.ExecuteSP("Sp_Abstractor_Document_Upload", htEdit);
                Grd_Document_upload_Load();
            }
            if (e.ColumnIndex == 10)
            {
                Hashtable htdelete = new Hashtable();
                DataTable dtdelete = new System.Data.DataTable();
                htdelete.Add("@Trans", "DELETE");
                htdelete.Add("@Document_Upload_Id", Grd_Document_upload.Rows[e.RowIndex].Cells[4].Value);
                dtdelete = dataaccess.ExecuteSP("Sp_Abstractor_Document_Upload", htdelete);
                Grd_Document_upload_Load();
            }
        }

        private void ddl_Search_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gridview_Bind_State_County_Details();
        }

        private void txt_Abstractor_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddl_gender.Focus();
            }
        }

        private void ddl_gender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Address.Focus();
            }
        }

        private void txt_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_ZipCode.Focus();
            }
        }

        private void txt_ZipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddl_Employee_Type.Focus();
            }
        }

        private void ddl_Employee_Type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Phone_No.Focus();
            }
        }

        private void txt_Phone_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Alternative_Phone_No.Focus();
            }
        }

        private void txt_Alternative_Phone_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txt_Email.Focus();
            }
        }

        private void txt_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_alternative_Email.Focus();
            }
        }

        private void txt_alternative_Email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Fax_No.Focus();
            }
        }

        private void txt_Fax_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_alternative_Fax_no.Focus();
            }
        }

        private void txt_alternative_Fax_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Bank_Name.Focus();
            }

        }

        private void txt_Bank_Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Account_No.Focus();

            }
        }

        private void txt_Account_No_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_Bank_Address.Focus();
            }
        }

        private void txt_Bank_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddl_PaymentType.Focus();
            }
        }

        private void ddl_PaymentType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_W9_Upload.Focus();
            }
        }

        private void btn_W9_Upload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Eno_Upload.Focus();
            }
        }

        private void btn_Eno_Upload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save.Focus();
            }

        }

        private void btn_Save_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Cancel.Focus();
            }
        }

        private void btn_Import_cost_Click(object sender, EventArgs e)
        {
            Ordermanagement_01.Abstractor.Import_Absractor_Cost_TAT Import_cost = new Ordermanagement_01.Abstractor.Import_Absractor_Cost_TAT(userid,ABSTRACT_ID);
            Import_cost.Show();
        }

        private void Abstractor_Entry_Load(object sender, EventArgs e)
        {

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Gridview_Bind_State_County_Details();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ddl_SendMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }

    
    

}
       
        
        
        


