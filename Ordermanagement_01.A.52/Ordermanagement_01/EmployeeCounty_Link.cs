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

namespace Ordermanagement_01
{
    public partial class EmployeeCounty_Link : Form
    {
        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        int State_Id, County_Id;
        string OrderNo;

        public EmployeeCounty_Link(int StateId,int CountyId,string Order_no)
        {
            InitializeComponent();
            OrderNo = Order_no;
            State_Id = StateId;
            County_Id = CountyId;
            Grdiview_Bind_County_Link();
            Grdiview_Bind_Tax_County_Link();
            Grdiview_Bind_Judgment_Link();

        }
        protected void Grdiview_Bind_Judgment_Link()
        {
            Hashtable htselect = new Hashtable();
            DataTable dtselect = new DataTable();
            htselect.Add("@Trans", "SELECT");
            htselect.Add("@State_Id", State_Id);
            htselect.Add("@County_Id", County_Id);
            dtselect = dataaccess.ExecuteSP("Sp_Judgment_Link", htselect);
            if (dtselect.Rows.Count > 0)
            {
                for (int i = 0; i < dtselect.Rows.Count; i++)
                {
                    // Grd_County_Link.DataSource = dtselect;
                    Grd_Judgment_Link.Rows.Add();
                    Grd_Judgment_Link.Rows[i].Cells[0].Value = dtselect.Rows[i]["Judgment_Links_Id"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[1].Value = dtselect.Rows[i]["State"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[2].Value = dtselect.Rows[i]["County"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[3].Value = dtselect.Rows[i]["Research_Date"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[4].Value = dtselect.Rows[i]["Judgment_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[5].Value = dtselect.Rows[i]["Lien_Link"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[6].Value = dtselect.Rows[i]["Criminal"].ToString();
                    Grd_Judgment_Link.Rows[i].Cells[7].Value = dtselect.Rows[i]["Subscription"].ToString();
                   
                }
            }
        }

        protected void Grdiview_Bind_County_Link()
        {
            
            Hashtable htselect = new Hashtable();
            DataTable dtselect = new DataTable();
            htselect.Add("@Trans", "SELECT_BY_STATE_COUNTY");
            htselect.Add("@State", State_Id);
            htselect.Add("@County", County_Id);
            dtselect = dataaccess.ExecuteSP("Sp_County_Link", htselect);
            if (dtselect.Rows.Count > 0)
            {
                for (int i = 0; i < dtselect.Rows.Count; i++)
                {
                   // Grd_County_Link.DataSource = dtselect;
                    Grd_County_Link.Rows.Add();
                    Grd_County_Link.Rows[i].Cells[0].Value = dtselect.Rows[i]["County_Link_Id"].ToString();
                    Grd_County_Link.Rows[i].Cells[1].Value = dtselect.Rows[i]["Index_Availability"].ToString();
                    Grd_County_Link.Rows[i].Cells[2].Value = dtselect.Rows[i]["Index_date_range"].ToString();
                    Grd_County_Link.Rows[i].Cells[3].Value = dtselect.Rows[i]["Back_deed_search"].ToString();
                    Grd_County_Link.Rows[i].Cells[4].Value = dtselect.Rows[i]["Back_deed_range"].ToString();
                    Grd_County_Link.Rows[i].Cells[5].Value = dtselect.Rows[i]["Images"].ToString();
                    Grd_County_Link.Rows[i].Cells[6].Value = dtselect.Rows[i]["Images_date_of_range"].ToString();
                    Grd_County_Link.Rows[i].Cells[7].Value = dtselect.Rows[i]["Land_Records_Link"].ToString();
                    Grd_County_Link.Rows[i].Cells[8].Value = dtselect.Rows[i]["Subscription_Link"].ToString();
                    Grd_County_Link.Rows[i].Cells[9].Value = dtselect.Rows[i]["Plant_availability"].ToString();
                }

            }
            else
            {
                Grd_County_Link.DataSource = null;
            }
        }

        protected void Grdiview_Bind_Tax_County_Link()
        {
            Hashtable htselect = new Hashtable();
            DataTable dtselect = new DataTable();
            htselect.Add("@Trans", "SELECT_BY_STATE_COUNTY");
            htselect.Add("@State", State_Id);
            htselect.Add("@County", County_Id);
            dtselect = dataaccess.ExecuteSP("Sp_County_Tax_Assesment_Link", htselect);
            if (dtselect.Rows.Count > 0)
            {
                for (int i = 0; i < dtselect.Rows.Count; i++)
                {
                    
                    Grd_Tax_County_Link.Rows.Add();
                    Grd_Tax_County_Link.Rows[i].Cells[0].Value = dtselect.Rows[i]["County_Assement_Link_Id"].ToString();
                    Grd_Tax_County_Link.Rows[i].Cells[1].Value = dtselect.Rows[i]["CountyTax_Link"].ToString();
                    Grd_Tax_County_Link.Rows[i].Cells[2].Value = dtselect.Rows[i]["Tax_PhoneNo"].ToString();

                    grd_Assor_Link.Rows.Add();
                    grd_Assor_Link.Rows[i].Cells[0].Value = dtselect.Rows[i]["Assessor_Link"].ToString();
                    grd_Assor_Link.Rows[i].Cells[1].Value = dtselect.Rows[i]["Assessor_PhoneNo"].ToString();
                   
                }

            }
            else
            {
                Grd_Tax_County_Link.DataSource = null;
            }

        }

        private void Grd_County_Link_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 7 || e.ColumnIndex == 8)
                {

                    string url = Grd_County_Link.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (url != "" && url != "N/A")
                    {
                        System.Diagnostics.Process.Start(url);
                    }
                }
            }
        }

        private void Grd_Tax_County_Link_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 3)
            {
                string url = Grd_Tax_County_Link.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (url != "" && url!="N/A")
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
        }

        private void EmployeeCounty_Link_Load(object sender, EventArgs e)
        {
            lbl_orderno.Text = OrderNo + " Links";
        }

        private void Grd_Tax_County_Link_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grd_Judgment_Link_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
            {
                string url = Grd_Judgment_Link.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (url != "" && url != "N/A")
                {
                    System.Diagnostics.Process.Start(url);
                }
            }
        }
    }
}
