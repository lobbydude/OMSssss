using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Windows.Forms;
namespace Ordermanagement_01.Classes
{
    class TaxClass
    {

        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        public TaxClass()
    {
        
        //
        // TODO: Add constructor logic here
        //
    }
        public void BindTax_UserName(ComboBox ddlName)
        {
            Hashtable htParam = new Hashtable();

            htParam.Add("@Trans", "GET_TAX_USERS");
            dt = da.ExecuteSP("Sp_Tax_Orders", htParam);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Select";
            dt.Rows.InsertAt(dr, 0);
            ddlName.DataSource = dt;
            ddlName.DisplayMember = "User_Name";
            ddlName.ValueMember = "User_id";
            // ddlName.DataBind();
            //  ddlName.Items.Insert(0, "SELECT");
        }
        public void BindTax_Task(ComboBox ddlName)
        {
            Hashtable htParam = new Hashtable();

            htParam.Add("@Trans", "GET_TAX_TASK");
            dt = da.ExecuteSP("Sp_Tax_Orders", htParam);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Select";
            dt.Rows.InsertAt(dr, 0);
            ddlName.DataSource = dt;
            ddlName.DisplayMember = "Tax_Task";
            ddlName.ValueMember = "Tax_Task_Id";
            // ddlName.DataBind();
            //  ddlName.Items.Insert(0, "SELECT");
        }
        public void BindTax_Status(ComboBox ddlName)
        {
            Hashtable htParam = new Hashtable();

            htParam.Add("@Trans", "GET_TAX_STATUS");
            dt = da.ExecuteSP("Sp_Tax_Orders", htParam);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Select";
            dt.Rows.InsertAt(dr, 0);
            ddlName.DataSource = dt;
            ddlName.DisplayMember = "Tax_Status";
            ddlName.ValueMember = "Tax_Status_Id";
            // ddlName.DataBind();
            //  ddlName.Items.Insert(0, "SELECT");
        }
        public void BindSubProcessNumber(ComboBox ddlName, int Clientid)
        {
            Hashtable htParam = new Hashtable();

            htParam.Add("@Trans", "SELECTCLIENTWISE");
            htParam.Add("@Client_Id", Clientid);
            dt = da.ExecuteSP("Sp_Client_SubProcess", htParam);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[4] = "Select";
            dt.Rows.InsertAt(dr, 0);
            ddlName.DataSource = dt;
            ddlName.DisplayMember = "Subprocess_Number";
            ddlName.ValueMember = "Subprocess_Id";
        }

        public void Bind_Client_Name_For_Tax_Violation(ComboBox ddlName)
        {
            Hashtable htPar = new Hashtable();

            htPar.Add("@Trans", "GET_CLIENT");
            dt = da.ExecuteSP("Sp_Tax_Violation_Entry", htPar);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "SELECT";

            dt.Rows.InsertAt(dr, 0);
            ddlName.DataSource = dt;
            ddlName.DisplayMember = "Client_Name";
            ddlName.ValueMember = "Client_Id";
            //ddlName.DataBind();
            //Column19.Items.Insert(1,"SELECT");
        }

        public void Bind_Sub_Client_For_Tax_Violation(ComboBox ddlName, int Client_Id)
        {
            Hashtable htParam = new Hashtable();

            htParam.Add("@Trans", "GET_SUB_CLIENT");
            htParam.Add("@Client_Id", Client_Id);
            dt = da.ExecuteSP("Sp_Tax_Violation_Entry", htParam);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "SELECT";
            dt.Rows.InsertAt(dr, 0);
            ddlName.DataSource = dt;
            ddlName.DisplayMember = "Sub_ProcessName";
            ddlName.ValueMember = "Subprocess_Id";
            //ddlName.DataBind();
            //   ddlName.Items.Insert(0, "SELECT");
        }

    }
}
