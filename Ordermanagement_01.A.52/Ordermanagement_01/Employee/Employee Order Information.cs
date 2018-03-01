using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ordermanagement_01.Employee
{
    public partial class Employee_Order_Information : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        int Userid, order_id,order_type_abs; string state_id,user_Role;
        

        public Employee_Order_Information(int userid, string State_ID, int Order_Id,string USER_ROLE)
        {
            InitializeComponent();
            Userid = userid;
            state_id = State_ID;
            order_id = Order_Id;
            user_Role = USER_ROLE;


            
        }

    

        private void Bind_US_Tax()
        {
            Hashtable ht = new Hashtable();
            DataTable dt = new DataTable();
            ht.Add("@Trans", "SELECT");
            ht.Add("@State_Id", state_id);
            dt = dataaccess.ExecuteSP("Sp_State_Tax_Due_Date", ht);
            if (dt.Rows.Count > 0)
            {
                Grid_Tax.DataSource = dt;

            }
            else
            {

                Grid_Tax.DataSource = null;

                Grid_Tax.Rows.Clear();
            }
        }
        private void Get_Order_Details()
        {
            Hashtable ht_Select_Order_Details = new Hashtable();
            DataTable dt_Select_Order_Details = new DataTable();

            ht_Select_Order_Details.Add("@Trans", "SELECT_EMPLOYEE_ENTRY_INFORMATION");
            ht_Select_Order_Details.Add("@Order_ID", order_id);
            dt_Select_Order_Details = dataaccess.ExecuteSP("Sp_Order", ht_Select_Order_Details);
            if (dt_Select_Order_Details.Rows.Count > 0)
            {
                txt_Order_Instructions.Text = dt_Select_Order_Details.Rows[0]["Notes"].ToString();
                order_type_abs = int.Parse(dt_Select_Order_Details.Rows[0]["OrderType_ABS_Id"].ToString());
            }
        }
        private void Bind_Statute_limitation()
        {
            Hashtable ht_Select = new Hashtable();
            DataTable dt_Select= new DataTable();

            ht_Select.Add("@Trans", "SELECT_EMPLOYEE_STATUE_INFO");
            ht_Select.Add("@State", state_id);
            ht_Select.Add("@Order_Type_Id", order_type_abs);

            dt_Select = dataaccess.ExecuteSP("Sp_Order", ht_Select);
            if (dt_Select.Rows.Count > 0)
            {
                //grd_Statue_of_limitation.DataSource = dt_Select;
                txt_Statue_of_Info.Text = dt_Select.Rows[0]["Statute of limitation"].ToString();
            }
            else
            {
                txt_Statue_of_Info.Text = "";
            }

        }


        private void Employee_Order_Information_Load(object sender, EventArgs e)
        {
            Bind_US_Tax();
            Get_Order_Details();
            Bind_Statute_limitation();

            if (user_Role == "2")
            {

                this.ControlBox = false;
            }
            else if (user_Role == "1")
            {

                this.ControlBox = true;
            }
        }
    }
}
