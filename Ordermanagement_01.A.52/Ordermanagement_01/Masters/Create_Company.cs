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
using System.Text.RegularExpressions;

namespace Ordermanagement_01
{
    
    public partial class Create_Company : Form
    {

        Commonclass Comclass = new Commonclass();
        DataAccess dataaccess = new DataAccess();
        DropDownistBindClass dbc = new DropDownistBindClass();
        private Point pt, pt1, comp_pt, comp_pt1, add_pt, add_pt1, form_pt, form1_pt, comp_lbl, comp_lbl1, create_comp, create_comp1, del_comp,
            del_comp1, clear_btn, clear_btn1;
        byte[] bimage;
        int userid = 0;
        int Company_Id;
        string username;

        public Regex pinCode = new Regex(@"^\d{6,}$", RegexOptions.Compiled);
        public Regex FaxNum = new Regex(@"^\d{15,}$", RegexOptions.Compiled);
        public Regex phoneno = new Regex(@"^\d{10,}$", RegexOptions.Compiled);
        public Regex CompName = new Regex(@"^[a-zA-Z0-9# ]+$", RegexOptions.Compiled);
        public Regex CompSlogan = new Regex(@"^[a-zA-Z0-9# ]+$", RegexOptions.Compiled);
        public Regex City = new Regex(@"^[a-zA-Z0-9# ]+$", RegexOptions.Compiled);

        public Create_Company(int user_id,string Username)
        {
            InitializeComponent();
            username = Username;
            dbc.BindCountry(ddl_company_country);
            if (ddl_company_country.SelectedIndex > 0)
            {
                dbc.BindState1(ddl_company_state, int.Parse(ddl_company_country.SelectedValue.ToString()));
            }
            if (ddl_company_state.SelectedIndex > 0)
            {
                dbc.BindDistrict(ddl_company_district, int.Parse(ddl_company_state.SelectedValue.ToString()));
            }
            userid = user_id;
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txt_companyname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_slogan.Focus();
            }
        }

        private void txt_company_slogan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_registrationno.Focus();
            }
        }

        private void txt_company_registrationno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_address.Focus();
            }
        }

        private void txt_company_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddl_company_country.Focus();
            }
        }

        private void ddl_company_country_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddl_company_state.Focus();
            }
        }

        private void ddl_company_state_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddl_company_district.Focus();
            }
        }

        private void ddl_company_district_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_city.Focus();
            }
        }

        private void txt_company_city_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_Pincode.Focus();
            }
        }

        private void txt_company_Pincode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_phono.Focus();
            }
        }

        private void txt_company_phono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_fax.Focus();
            }
        }

        private void txt_company_fax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_email.Focus();
            }
        }

        private void txt_company_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_company_website.Focus();
            }
        }

        private void txt_company_website_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChkDefault.Focus();
            }
        }

        private void ChkDefault_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Save.Focus();
            }
        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ChkDefault_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Create_Company_Load(object sender, EventArgs e)
        {
           // btn_treeview.Left = Width - 50;
            Company_Id = 0;
          pnlSideTree.Visible = true;
           AddParent();
           lbl_RecordAddedBy.Text = "";
           lbl_RecordAddedOn.Text = "";
         
        }
         private void AddParent()
         {
       
        string sKeyTemp ="";
        tvwRightSide.Nodes.Clear();
              Hashtable ht = new Hashtable();
            DataTable dt = new System.Data.DataTable();
             
           
           ht.Add("@Trans", "SELECT");
         
            dt = dataaccess.ExecuteSP("Sp_Company", ht);
               //for (int i = 0; i < dt.Rows.Count; i++)
               //  {
            sKeyTemp = "Companies";
           // sKeyTemp = dt.Rows[i]["Company_Name"].ToString();
            tvwRightSide.Nodes.Add(sKeyTemp, sKeyTemp);
           AddChilds(sKeyTemp);
              // }
       
    
         }
           private void AddChilds(string sKey)
           {
           Hashtable ht = new Hashtable();
            DataTable dt = new System.Data.DataTable();
            TreeNode parentnode;
               
           
           ht.Add("@Trans", "SELECT");
         
            dt = dataaccess.ExecuteSP("Sp_Company", ht);
               for (int i = 0; i < dt.Rows.Count; i++)
                 {
                     tvwRightSide.Nodes[0].Nodes.Add(dt.Rows[i]["Company_Id"].ToString() , dt.Rows[i]["Company_Name"].ToString());
          
               }
           }
           private bool Validation()
           {
               if (txt_companyname.Text == "")
               {
                   MessageBox.Show("Enter Company Name"); 
                   txt_companyname.Focus();
                   
                   return false;
               }
               else if (txt_company_address.Text == "")
               {
                   MessageBox.Show("Enter Company Address");
                   txt_company_address.Focus();
                   return false;
               }
               else if (ddl_company_country.Text == "SELECT")
               {
                   MessageBox.Show("Select Company Country");
                   ddl_company_country.Focus();
                   return false;
               }
               else if (ddl_company_state.Text == "SELECT" || ddl_company_state.Text == "")
               {
                   MessageBox.Show("Select Company State");
                   ddl_company_state.Focus();
                   return false;
               }
               else if (ddl_company_district.Text == "SELECT" || ddl_company_district.Text == "")
               {
                   MessageBox.Show("Select Company District");
                   ddl_company_district.Focus();
                   return false;
               }
               else if (txt_company_city.Text == "")
               {
                   MessageBox.Show("Enter Company City");
                   txt_company_city.Focus();
                   return false;
               }
               else if (txt_company_Pincode.Text == "")
               {
                   MessageBox.Show("Enter Company Pincode");
                   txt_company_Pincode.Focus();
                   return false;
               }
               else if (txt_company_phono.Text == "")
               {
                   MessageBox.Show("Enter Company Phone no");
                   txt_company_phono.Focus();
                   return false;
               }
               else if (txt_company_fax.Text == "")
               {
                   MessageBox.Show("Enter Company Fax");
                   txt_company_fax.Focus();
                   return false;
               }
               else if (txt_company_email.Text == "")
               {
                   MessageBox.Show("Enter Company Email");
                   txt_company_email.Focus();
                   return false;
               }
        
               else if (txt_company_website.Text == "")
               {
                   MessageBox.Show("Enter Company Website");
                   txt_company_website.Focus();
                   return false;
               }
               else if (ChkDefault.Checked == false)
               {
                   MessageBox.Show("Check the Check Default");
                   ChkDefault.Focus();
                   return false;
               }
               Hashtable ht = new Hashtable();
               DataTable dt = new DataTable();
               ht.Add("@Trans", "COMPNAME");
               dt = dataaccess.ExecuteSP("Sp_Company", ht);
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   if (txt_companyname.Text == dt.Rows[i]["Company_Name"].ToString())
                   {
                       MessageBox.Show("Company Name Already Exist");
                       return false;
                       break;
                   }

               }
               return true;

           }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Hashtable hsforSP = new Hashtable();
            DataTable dt = new System.Data.DataTable();
            if (ChkDefault.Checked == true)
            {
                hsforSP.Add("@Trans", "ChkDefault");
                dt = dataaccess.ExecuteSP("Sp_Company", hsforSP);
                hsforSP.Clear();
            }


            //if (ddl_company_country.SelectedValue.ToString() != "SELECT" 
            //    && ddl_company_state.SelectedValue.ToString() != "" 
            //    && ddl_company_district.SelectedValue.ToString() != ""
            //    && txt_companyname.Text != "" && txt_company_address.Text!=""
            //    && txt_company_email.Text!="" && txt_company_fax.Text!=""
            //    && txt_company_phono.Text!="")
            //{

                    if (Company_Id ==0 && Validation() != false)
                    {
                        
                        //Insert
                        //img = (byte[])Session["imgempphoto"];
                        hsforSP.Add("@Trans", "INSERT");
                        //hsforSP.Add("@Company_Id", txt_companyname.Text);
                        hsforSP.Add("@Company_Name", txt_companyname.Text);
                        hsforSP.Add("@Comp_slogan", txt_company_slogan.Text);
                        hsforSP.Add("@Comp_RegistrationNo", txt_company_registrationno.Text);
                        hsforSP.Add("@Comp_Address", txt_company_address.Text);
                        hsforSP.Add("@Comp_Country", ddl_company_country.SelectedValue);
                        hsforSP.Add("@Comp_State", ddl_company_state.SelectedValue);
                        hsforSP.Add("@Comp_District", ddl_company_district.SelectedValue);
                        hsforSP.Add("@Comp_City", txt_company_city.Text);
                        hsforSP.Add("@Comp_Pincode", txt_company_Pincode.Text);
                        hsforSP.Add("@Comp_Phone", txt_company_phono.Text);
                        hsforSP.Add("@Comp_Fax", txt_company_fax.Text);
                        hsforSP.Add("@Comp_Email", txt_company_email.Text);
                        hsforSP.Add("@Comp_Web", txt_company_website.Text);
                        hsforSP.Add("@Comp_Logo", bimage);
                        hsforSP.Add("@Com_SetDefault", ChkDefault.Checked);
                        hsforSP.Add("@Inserted_By", userid);
                        hsforSP.Add("@Inserted_date", DateTime.Now);
                        ////hsforSP.Add("@Modified_By", supportContractStartDate);
                        ////hsforSP.Add("@Modified_Date", supportContractEndDate);
                        ////hsforSP.Add("@status", endofSupportLife);
                        dt = dataaccess.ExecuteSP("Sp_Company", hsforSP);
                        string title = "Insert";
                        MessageBox.Show("Company Created Sucessfully",title);
                        clear();
                        AddParent();
                        Company_Id = 0;
                    }
                    else if (Company_Id !=0 )
                    {
                       
                        //Update
                        hsforSP.Add("@Trans", "UPDATE");
                        hsforSP.Add("@Company_Id", Company_Id);
                        hsforSP.Add("@Company_Name", txt_companyname.Text);
                        hsforSP.Add("@Comp_slogan", txt_company_slogan.Text);
                        hsforSP.Add("@Comp_RegistrationNo", txt_company_registrationno.Text);
                        hsforSP.Add("@Comp_Address", txt_company_address.Text);
                        hsforSP.Add("@Comp_Country", ddl_company_country.SelectedValue);
                        hsforSP.Add("@Comp_State", ddl_company_state.SelectedValue);
                        hsforSP.Add("@Comp_District", ddl_company_district.SelectedValue);
                        hsforSP.Add("@Comp_City", txt_company_city.Text);
                        hsforSP.Add("@Comp_Pincode", txt_company_Pincode.Text);
                        hsforSP.Add("@Comp_Phone", txt_company_phono.Text);
                        hsforSP.Add("@Comp_Fax", txt_company_fax.Text);
                        hsforSP.Add("@Comp_Email", txt_company_email.Text);
                        hsforSP.Add("@Comp_Web", txt_company_website.Text);
                        hsforSP.Add("@Comp_Logo", bimage);
                        hsforSP.Add("@Com_SetDefault", ChkDefault.Checked);
                        // hsforSP.Add("@Inserted_By", Empname);
                        //  hsforSP.Add("@Inserted_date", DateTime.Now);
                        hsforSP.Add("@Modified_By", userid);
                        hsforSP.Add("@Modified_Date", DateTime.Now);
                        ////hsforSP.Add("@status", endofSupportLife);
                        dt = dataaccess.ExecuteSP("Sp_Company", hsforSP);
                       // model1.Hide();
                        string title = "Update";
                        MessageBox.Show("Company Updated Sucessfully",title);
                        clear();
                        AddParent();
                    }

            //}
            //else
            //{
            //    MessageBox.Show("Select Country , State  And District");
            //}
            
            }

            

        private void clear()
        {
            lbl_Company.Text = "Company";
            pt.X = 485; pt.Y = 4;
            lbl_Company.Location = pt;
            txt_companyname.Text = "";
            Company_Id = 0;
            txt_company_slogan.Text = "";
            txt_company_registrationno.Text = "";
            txt_company_address.Text = "";
            ddl_company_state.DataSource = null;
            ddl_company_district.DataSource = null;
            ddl_company_country.SelectedIndex = 0;
            txt_company_city.Text = "";
            txt_company_Pincode.Text = "";
            txt_company_phono.Text = "";
            txt_company_fax.Text = "";
            txt_company_email.Text = "";
            txt_company_website.Text = "";
            btn_Save.Text = "Create Company";
            textBoximage.Text = "";
            cmp_Image.Image = null;
            txt_companyname.BackColor = System.Drawing.Color.White;
            ddl_company_district.BackColor = System.Drawing.Color.White;
            ddl_company_state.BackColor = System.Drawing.Color.White;
            ddl_company_country.BackColor = System.Drawing.Color.White;
            lbl_RecordAddedBy.Text = "";
            ChkDefault.Checked = false;
            lbl_RecordAddedBy.Text = username;
            lbl_RecordAddedOn.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            
        }
        

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void tvwRightSide_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string Checked;
            string logo;
            clear();
            bool isNum = Int32.TryParse(tvwRightSide.SelectedNode.Name, out Company_Id);
            if (isNum)
            {
                lbl_Company.Text = "EDIT COMPANY";
                pt.X=465;pt.Y=4; 
                lbl_Company.Location=pt;
                Hashtable hsforSP = new Hashtable();
                DataTable dt = new DataTable();
                hsforSP.Add("@Trans", "SELECTGRID");
                hsforSP.Add("@Company_Id", Company_Id);
                dt = dataaccess.ExecuteSP("Sp_Company", hsforSP);
                txt_companyname.Text = dt.Rows[0]["Company_Name"].ToString();
                txt_company_slogan.Text = dt.Rows[0]["Comp_slogan"].ToString();
                txt_company_registrationno.Text = dt.Rows[0]["Comp_RegistrationNo"].ToString();
                txt_company_address.Text = dt.Rows[0]["Comp_Address"].ToString();
                txt_company_Pincode.Text = dt.Rows[0]["Comp_Pincode"].ToString();
                txt_company_phono.Text = dt.Rows[0]["Comp_Phone"].ToString();
                txt_company_fax.Text = dt.Rows[0]["Comp_Fax"].ToString();
                txt_company_email.Text = dt.Rows[0]["Comp_Email"].ToString();
                txt_company_website.Text = dt.Rows[0]["Comp_Web"].ToString();
                txt_company_city.Text = dt.Rows[0]["Comp_City"].ToString();
                ddl_company_country.SelectedValue = dt.Rows[0]["Comp_Country"].ToString();
                ddl_company_state.SelectedValue = dt.Rows[0]["Comp_State"].ToString();
                ddl_company_district.SelectedValue = dt.Rows[0]["Comp_District"].ToString();
                // byte[] imageBytes = Convert.FromBase64String(dt.Rows[0]["Comp_Logo"].ToString()); 
                if (dt.Rows[0]["Comp_Logo"].ToString() != "")
                {
                    bimage = (Byte[])(dt.Rows[0]["Comp_Logo"]);
                    MemoryStream ms = new MemoryStream(bimage, 0, bimage.Length);
                    ms.Write(bimage, 0, bimage.Length);
                    cmp_Image.Image = Image.FromStream(ms, true);
                    textBoximage.Enabled = false;
                }
                else
                {
                    cmp_Image.Image = null;
                    textBoximage.Text = "";
                    textBoximage.Enabled = false;
                }
                if (dt.Rows[0]["Modifiedby"].ToString() != "")
                {
                    lbl_RecordAddedBy.Text = dt.Rows[0]["Modifiedby"].ToString();
                    lbl_RecordAddedOn.Text = dt.Rows[0]["Modified_Date"].ToString();
                }
                else if (dt.Rows[0]["Modifiedby"].ToString() == "")
                {
                    lbl_RecordAddedBy.Text = dt.Rows[0]["Insertedby"].ToString();
                    lbl_RecordAddedOn.Text = dt.Rows[0]["Instered_Date"].ToString();
                }


                Checked = dt.Rows[0]["SetDefault"].ToString();
                if (Checked == "True")
                {
                    ChkDefault.Checked = true;

                }
                else if (Checked == "False")
                {
                    ChkDefault.Checked = false;
                }
                if (Company_Id != 0)
                {
                    btn_Save.Text = "Edit Company";
                }
                else
                {
                    btn_Save.Text = "Add Company";
                }
            }
        }

        private void btn_image_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBoximage.Enabled = true;
                textBoximage.Text = open.FileName;
                string image = textBoximage.Text;
                Bitmap bmp = new Bitmap(image);
                if (textBoximage.Text != "")
                {
                    FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
                    bimage = new byte[fs.Length];
                    fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    cmp_Image.Image = GetDataToImage((byte[])bimage);
                }
            }
            else
            {
                textBoximage.Enabled = false;
            }
        }
        public Image GetDataToImage(byte[] bimage)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(bimage) as Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Image not uploaded");
                return null;
            }
        }
        private void ddl_company_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_company_country.SelectedIndex > 0)
            {
                dbc.BindState1(ddl_company_state, int.Parse(ddl_company_country.SelectedValue.ToString()));
            }
        }
        private void ddl_company_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_company_state.SelectedIndex > 0)
            {
                dbc.BindDistrict(ddl_company_district, int.Parse(ddl_company_state.SelectedValue.ToString()));
            }
        }

        private void tvwRightSide_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
              DialogResult dialog = MessageBox.Show("Do you want to Delete Record", "Delete Confirmation", MessageBoxButtons.YesNo);
              if (dialog == DialogResult.Yes)
              {
                  if (Company_Id != 0)
                  {
                      Hashtable hsforSP = new Hashtable();
                      DataTable dt = new DataTable();
                      //   Company_Id = int.Parse(tvwRightSide.SelectedNode.Text.Substring(0, 4).ToString());
                      hsforSP.Add("@Trans", "DELETE");
                      hsforSP.Add("@Company_Id", Company_Id);
                      dt = dataaccess.ExecuteSP("Sp_Company", hsforSP);
                      int count = dt.Rows.Count;
                      MessageBox.Show("Company Successfully Deleted");
                      clear();
                      AddParent();
                  }
                  else
                  {
                      string title = "Select!";
                      MessageBox.Show("Please Select Valid Company Name",title);
                      tvwRightSide.Focus();
                  }
              }
       }

        private void txt_company_email_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txt_company_Pincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (pinCode.IsMatch(txt_company_Pincode.Text) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("PinCode Should be 6 digits.");
            }

          
        }

        private void txt_company_phono_KeyPress(object sender, KeyPressEventArgs e)
        {
         //   e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (phoneno.IsMatch(txt_company_phono.Text) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Phone Number must be 10 digits");
            }

            
        }

        private void txt_company_fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (!(char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (FaxNum.IsMatch(txt_company_fax.Text) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                MessageBox.Show("Fax Number less then 20 digits.");
            }

            //if (txt_company_fax.Text.Length == 0)
            //{
            //    if (e.Handled = (e.KeyChar == (char)Keys.Space))
            //    {
            //        MessageBox.Show("space not allowed!");
            //    }
            //}
        }

        private void txt_company_email_Leave(object sender, EventArgs e)
        {
            Regex myRegularExpression = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            if (myRegularExpression.IsMatch(txt_company_email.Text))
            {
                //valid e-mail
            }
            else
            {
                MessageBox.Show("Email Address Not Valid");
            }
        }

        private void txt_companyname_Leave(object sender, EventArgs e)
        {
            

        }

        

        private void btn_treeview_Click(object sender, EventArgs e)
        {
            pt.X = 0; pt.Y = 0;
            pt1.X = 190; pt1.Y = 0;
            comp_pt.X = 5; comp_pt.Y = 50;
            add_pt.X = 5; add_pt.Y = 485;
            comp_pt1.X = 200; comp_pt1.Y = 50;
            add_pt1.X = 200; add_pt1.Y = 485;
            comp_lbl.X = 315; comp_lbl.Y = 20;
            comp_lbl1.X = 513; comp_lbl1.Y = 20;
            create_comp.X = 175; create_comp.Y = 601;
            create_comp1.X = 365; create_comp1.Y = 601;
            del_comp.X = 335; del_comp.Y = 601;
            del_comp1.X = 525; del_comp1.Y = 601;
            clear_btn.X = 495; clear_btn.Y = 601;
            clear_btn1.X = 685; clear_btn1.Y = 601;
            form_pt.X = 350; form_pt.Y = 20;
            form1_pt.X = 200; form1_pt.Y = 20;
            if (pnlSideTree.Visible == true)
            {
                //hide panel
                pnlSideTree.Visible = false;
                btn_treeview.Location = pt;
                lbl_Company.Location = comp_lbl;
                btn_Save.Location = create_comp;
                btn_Delete.Location = del_comp;
                btn_Cancel.Location = clear_btn;
                grp_Comp_det.Location = comp_pt;
                grp_Add_det.Location = add_pt;
                Create_Company.ActiveForm.Width = 750;
                Create_Company.ActiveForm.Location = form_pt;
         
                btn_treeview.Image = Image.FromFile(@"\\192.168.12.33\Oms-Image-Files\right.png");
            }
            else
            {

                //show panel
                pnlSideTree.Visible = true;
                btn_treeview.Location = pt1;
                lbl_Company.Location = comp_lbl1;
                btn_Save.Location = create_comp1;
                btn_Delete.Location = del_comp1;
                btn_Cancel.Location = clear_btn1;
                grp_Comp_det.Location = comp_pt1;
                grp_Add_det.Location = add_pt1;
                Create_Company.ActiveForm.Width = 950;
                Create_Company.ActiveForm.Location = form1_pt;
                btn_treeview.Image = Image.FromFile(@"\\192.168.12.33\Oms-Image-Files\left.png");

            }
            AddParent();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txt_companyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (txt_companyname.Text.Length == 0)
            //{
            //    if (e.Handled = (e.KeyChar == (char)Keys.Space))
            //   {
            //       MessageBox.Show("space not allowed!");
            //   }  
            //}
            //if (CompName.IsMatch(txt_companyname.Text) && e.KeyChar != (char)Keys.Back)
            //{
            //    e.Handled = true;
            //    MessageBox.Show("Numbers not allowed");
            //}

            if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != (char)Keys.Back && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt_company_slogan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != (char)Keys.Back && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
          
        }

        private void txt_company_city_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && e.KeyChar != (char)Keys.Back && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
            
        }

       
       
    }
}
