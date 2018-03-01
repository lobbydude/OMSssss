namespace Ordermanagement_01
{
    partial class Create_Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tree_Client = new System.Windows.Forms.TreeView();
            this.grp_Client_det = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.rbtn_Disable = new System.Windows.Forms.RadioButton();
            this.rbtn_Enable = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.grd_Email = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_CostTATExcel = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Client_Code = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_image = new System.Windows.Forms.Button();
            this.textBoximage = new System.Windows.Forms.TextBox();
            this.ddl_branchname = new System.Windows.Forms.ComboBox();
            this.ddl_Company = new System.Windows.Forms.ComboBox();
            this.Client_image = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Ddl_Client_State = new System.Windows.Forms.ComboBox();
            this.txt_Client_phono = new System.Windows.Forms.TextBox();
            this.txt_Client_city = new System.Windows.Forms.TextBox();
            this.txt_Client_email = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ddl_Client_district = new System.Windows.Forms.ComboBox();
            this.Ddl_Client_Country = new System.Windows.Forms.ComboBox();
            this.txt_Client_address = new System.Windows.Forms.TextBox();
            this.txt_ClientNumber = new System.Windows.Forms.TextBox();
            this.txt_Client_Pincode = new System.Windows.Forms.TextBox();
            this.txt_Client_website = new System.Windows.Forms.TextBox();
            this.txt_Client_fax = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_Add_det = new System.Windows.Forms.GroupBox();
            this.lbl_Record_AddedDate = new System.Windows.Forms.Label();
            this.lbl_Record_Addedby = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.pnlSideTree = new System.Windows.Forms.Panel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.grp_Client_det.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Client_image)).BeginInit();
            this.grp_Add_det.SuspendLayout();
            this.pnlSideTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(766, 595);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 32);
            this.btn_Cancel.TabIndex = 28;
            this.btn_Cancel.Text = "Clear";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Save.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(476, 595);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(130, 32);
            this.btn_Save.TabIndex = 26;
            this.btn_Save.Text = "Add New Client";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // tree_Client
            // 
            this.tree_Client.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree_Client.Location = new System.Drawing.Point(0, 0);
            this.tree_Client.Name = "tree_Client";
            this.tree_Client.Size = new System.Drawing.Size(190, 642);
            this.tree_Client.TabIndex = 68;
            this.tree_Client.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_Client_AfterSelect);
            // 
            // grp_Client_det
            // 
            this.grp_Client_det.Controls.Add(this.label29);
            this.grp_Client_det.Controls.Add(this.rbtn_Disable);
            this.grp_Client_det.Controls.Add(this.rbtn_Enable);
            this.grp_Client_det.Controls.Add(this.label28);
            this.grp_Client_det.Controls.Add(this.label26);
            this.grp_Client_det.Controls.Add(this.label45);
            this.grp_Client_det.Controls.Add(this.label23);
            this.grp_Client_det.Controls.Add(this.label22);
            this.grp_Client_det.Controls.Add(this.label20);
            this.grp_Client_det.Controls.Add(this.label21);
            this.grp_Client_det.Controls.Add(this.button1);
            this.grp_Client_det.Controls.Add(this.grd_Email);
            this.grp_Client_det.Controls.Add(this.txt_CostTATExcel);
            this.grp_Client_det.Controls.Add(this.label19);
            this.grp_Client_det.Controls.Add(this.txt_Client_Code);
            this.grp_Client_det.Controls.Add(this.label16);
            this.grp_Client_det.Controls.Add(this.btn_image);
            this.grp_Client_det.Controls.Add(this.textBoximage);
            this.grp_Client_det.Controls.Add(this.ddl_branchname);
            this.grp_Client_det.Controls.Add(this.ddl_Company);
            this.grp_Client_det.Controls.Add(this.Client_image);
            this.grp_Client_det.Controls.Add(this.label8);
            this.grp_Client_det.Controls.Add(this.Ddl_Client_State);
            this.grp_Client_det.Controls.Add(this.txt_Client_phono);
            this.grp_Client_det.Controls.Add(this.txt_Client_city);
            this.grp_Client_det.Controls.Add(this.txt_Client_email);
            this.grp_Client_det.Controls.Add(this.label18);
            this.grp_Client_det.Controls.Add(this.label15);
            this.grp_Client_det.Controls.Add(this.label9);
            this.grp_Client_det.Controls.Add(this.label7);
            this.grp_Client_det.Controls.Add(this.txt_ClientName);
            this.grp_Client_det.Controls.Add(this.label14);
            this.grp_Client_det.Controls.Add(this.ddl_Client_district);
            this.grp_Client_det.Controls.Add(this.Ddl_Client_Country);
            this.grp_Client_det.Controls.Add(this.txt_Client_address);
            this.grp_Client_det.Controls.Add(this.txt_ClientNumber);
            this.grp_Client_det.Controls.Add(this.txt_Client_Pincode);
            this.grp_Client_det.Controls.Add(this.txt_Client_website);
            this.grp_Client_det.Controls.Add(this.txt_Client_fax);
            this.grp_Client_det.Controls.Add(this.label17);
            this.grp_Client_det.Controls.Add(this.label11);
            this.grp_Client_det.Controls.Add(this.label10);
            this.grp_Client_det.Controls.Add(this.label6);
            this.grp_Client_det.Controls.Add(this.label5);
            this.grp_Client_det.Controls.Add(this.label4);
            this.grp_Client_det.Controls.Add(this.label3);
            this.grp_Client_det.Controls.Add(this.label2);
            this.grp_Client_det.Controls.Add(this.label1);
            this.grp_Client_det.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Client_det.Location = new System.Drawing.Point(196, 35);
            this.grp_Client_det.Name = "grp_Client_det";
            this.grp_Client_det.Size = new System.Drawing.Size(1023, 441);
            this.grp_Client_det.TabIndex = 71;
            this.grp_Client_det.TabStop = false;
            this.grp_Client_det.Text = "CLIENT DETAILS";
            this.grp_Client_det.Enter += new System.EventHandler(this.grp_Client_det_Enter);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(646, 158);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(103, 20);
            this.label29.TabIndex = 244;
            this.label29.Text = "Client Avilabality";
            // 
            // rbtn_Disable
            // 
            this.rbtn_Disable.AutoSize = true;
            this.rbtn_Disable.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.rbtn_Disable.Location = new System.Drawing.Point(824, 157);
            this.rbtn_Disable.Name = "rbtn_Disable";
            this.rbtn_Disable.Size = new System.Drawing.Size(70, 24);
            this.rbtn_Disable.TabIndex = 22;
            this.rbtn_Disable.Text = "Disable";
            this.rbtn_Disable.UseVisualStyleBackColor = true;
            // 
            // rbtn_Enable
            // 
            this.rbtn_Enable.AutoSize = true;
            this.rbtn_Enable.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.rbtn_Enable.Location = new System.Drawing.Point(752, 157);
            this.rbtn_Enable.Name = "rbtn_Enable";
            this.rbtn_Enable.Size = new System.Drawing.Size(66, 24);
            this.rbtn_Enable.TabIndex = 21;
            this.rbtn_Enable.Text = "Enable";
            this.rbtn_Enable.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(325, 309);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 20);
            this.label28.TabIndex = 241;
            this.label28.Text = "*";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(326, 343);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(15, 20);
            this.label26.TabIndex = 239;
            this.label26.Text = "*";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Red;
            this.label45.Location = new System.Drawing.Point(815, 407);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(200, 19);
            this.label45.TabIndex = 236;
            this.label45.Text = "(Fields with * Mark are Mandatory)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(627, 238);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 20);
            this.label23.TabIndex = 228;
            this.label23.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(626, 199);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(15, 20);
            this.label22.TabIndex = 227;
            this.label22.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(626, 159);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 20);
            this.label20.TabIndex = 226;
            this.label20.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(324, 130);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 20);
            this.label21.TabIndex = 225;
            this.label21.Text = "*";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(473, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "Import County Coverage Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grd_Email
            // 
            this.grd_Email.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_Email.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_Email.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column11});
            this.grd_Email.Location = new System.Drawing.Point(635, 24);
            this.grd_Email.Name = "grd_Email";
            this.grd_Email.Size = new System.Drawing.Size(382, 104);
            this.grd_Email.TabIndex = 20;
            this.grd_Email.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Email_CellClick);
            // 
            // Column12
            // 
            this.Column12.FillWeight = 5.076141F;
            this.Column12.HeaderText = "Client_Mail_Id";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 194.9239F;
            this.Column11.HeaderText = "Email Id";
            this.Column11.Name = "Column11";
            // 
            // txt_CostTATExcel
            // 
            this.txt_CostTATExcel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CostTATExcel.Location = new System.Drawing.Point(157, 408);
            this.txt_CostTATExcel.Name = "txt_CostTATExcel";
            this.txt_CostTATExcel.Size = new System.Drawing.Size(164, 25);
            this.txt_CostTATExcel.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(23, 409);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 20);
            this.label19.TabIndex = 114;
            this.label19.Text = "Order Cost Excel:";
            // 
            // txt_Client_Code
            // 
            this.txt_Client_Code.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_Code.Location = new System.Drawing.Point(156, 157);
            this.txt_Client_Code.Name = "txt_Client_Code";
            this.txt_Client_Code.Size = new System.Drawing.Size(164, 25);
            this.txt_Client_Code.TabIndex = 5;
            this.txt_Client_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_Code_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(26, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 113;
            this.label16.Text = "Client Code:";
            // 
            // btn_image
            // 
            this.btn_image.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_image.Location = new System.Drawing.Point(327, 372);
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(119, 28);
            this.btn_image.TabIndex = 10;
            this.btn_image.Text = "Upload Image";
            this.btn_image.UseVisualStyleBackColor = true;
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // textBoximage
            // 
            this.textBoximage.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoximage.Location = new System.Drawing.Point(157, 373);
            this.textBoximage.Name = "textBoximage";
            this.textBoximage.Size = new System.Drawing.Size(164, 25);
            this.textBoximage.TabIndex = 11;
            this.textBoximage.TextChanged += new System.EventHandler(this.textBoximage_TextChanged);
            // 
            // ddl_branchname
            // 
            this.ddl_branchname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_branchname.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_branchname.FormattingEnabled = true;
            this.ddl_branchname.Location = new System.Drawing.Point(156, 57);
            this.ddl_branchname.Name = "ddl_branchname";
            this.ddl_branchname.Size = new System.Drawing.Size(164, 28);
            this.ddl_branchname.TabIndex = 2;
            this.ddl_branchname.SelectedIndexChanged += new System.EventHandler(this.ddl_Company_SelectedIndexChanged);
            this.ddl_branchname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddl_branchname_KeyDown);
            // 
            // ddl_Company
            // 
            this.ddl_Company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Company.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Company.FormattingEnabled = true;
            this.ddl_Company.Location = new System.Drawing.Point(155, 24);
            this.ddl_Company.Name = "ddl_Company";
            this.ddl_Company.Size = new System.Drawing.Size(164, 28);
            this.ddl_Company.TabIndex = 1;
            this.ddl_Company.SelectedIndexChanged += new System.EventHandler(this.ddl_Company_SelectedIndexChanged);
            this.ddl_Company.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddl_Company_KeyDown);
            // 
            // Client_image
            // 
            this.Client_image.Location = new System.Drawing.Point(459, 24);
            this.Client_image.Name = "Client_image";
            this.Client_image.Size = new System.Drawing.Size(112, 120);
            this.Client_image.TabIndex = 110;
            this.Client_image.TabStop = false;
            this.Client_image.Click += new System.EventHandler(this.Client_image_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 109;
            this.label8.Text = "Client Image:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // Ddl_Client_State
            // 
            this.Ddl_Client_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ddl_Client_State.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ddl_Client_State.FormattingEnabled = true;
            this.Ddl_Client_State.Location = new System.Drawing.Point(459, 194);
            this.Ddl_Client_State.Name = "Ddl_Client_State";
            this.Ddl_Client_State.Size = new System.Drawing.Size(164, 28);
            this.Ddl_Client_State.TabIndex = 15;
            this.Ddl_Client_State.SelectedIndexChanged += new System.EventHandler(this.Ddl_Client_State_SelectedIndexChanged);
            this.Ddl_Client_State.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ddl_Client_State_KeyDown);
            // 
            // txt_Client_phono
            // 
            this.txt_Client_phono.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_phono.Location = new System.Drawing.Point(157, 304);
            this.txt_Client_phono.MaxLength = 15;
            this.txt_Client_phono.Name = "txt_Client_phono";
            this.txt_Client_phono.Size = new System.Drawing.Size(164, 25);
            this.txt_Client_phono.TabIndex = 8;
            this.txt_Client_phono.TextChanged += new System.EventHandler(this.txt_Client_phono_TextChanged);
            this.txt_Client_phono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_phono_KeyDown);
            this.txt_Client_phono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Client_phono_KeyPress);
            // 
            // txt_Client_city
            // 
            this.txt_Client_city.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_city.Location = new System.Drawing.Point(460, 270);
            this.txt_Client_city.Name = "txt_Client_city";
            this.txt_Client_city.Size = new System.Drawing.Size(164, 25);
            this.txt_Client_city.TabIndex = 17;
            this.txt_Client_city.TextChanged += new System.EventHandler(this.txt_Client_city_TextChanged);
            this.txt_Client_city.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_city_KeyDown);
            this.txt_Client_city.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Client_city_KeyPress);
            // 
            // txt_Client_email
            // 
            this.txt_Client_email.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_email.Location = new System.Drawing.Point(157, 340);
            this.txt_Client_email.Name = "txt_Client_email";
            this.txt_Client_email.Size = new System.Drawing.Size(164, 25);
            this.txt_Client_email.TabIndex = 9;
            this.txt_Client_email.TextChanged += new System.EventHandler(this.txt_company_phono_TextChanged);
            this.txt_Client_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_email_KeyDown);
            this.txt_Client_email.Leave += new System.EventHandler(this.txt_Client_email_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(367, 231);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 20);
            this.label18.TabIndex = 108;
            this.label18.Text = "District:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(24, 343);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 20);
            this.label15.TabIndex = 107;
            this.label15.Text = "Email:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 104;
            this.label9.Text = "Tel No:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(368, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 101;
            this.label7.Text = "State:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ClientName.Location = new System.Drawing.Point(157, 126);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(164, 25);
            this.txt_ClientName.TabIndex = 4;
            this.txt_ClientName.TextChanged += new System.EventHandler(this.txt_ClientName_TextChanged);
            this.txt_ClientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ClientName_KeyDown);
            this.txt_ClientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ClientName_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 20);
            this.label14.TabIndex = 99;
            this.label14.Text = "Client Name:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // ddl_Client_district
            // 
            this.ddl_Client_district.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Client_district.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Client_district.FormattingEnabled = true;
            this.ddl_Client_district.Location = new System.Drawing.Point(459, 231);
            this.ddl_Client_district.Name = "ddl_Client_district";
            this.ddl_Client_district.Size = new System.Drawing.Size(164, 28);
            this.ddl_Client_district.TabIndex = 16;
            this.ddl_Client_district.SelectedIndexChanged += new System.EventHandler(this.ddl_Client_district_SelectedIndexChanged);
            this.ddl_Client_district.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddl_Client_district_KeyDown);
            // 
            // Ddl_Client_Country
            // 
            this.Ddl_Client_Country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ddl_Client_Country.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ddl_Client_Country.FormattingEnabled = true;
            this.Ddl_Client_Country.Location = new System.Drawing.Point(459, 154);
            this.Ddl_Client_Country.Name = "Ddl_Client_Country";
            this.Ddl_Client_Country.Size = new System.Drawing.Size(164, 28);
            this.Ddl_Client_Country.TabIndex = 14;
            this.Ddl_Client_Country.SelectedIndexChanged += new System.EventHandler(this.Ddl_Client_Country_SelectedIndexChanged);
            this.Ddl_Client_Country.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ddl_Client_Country_KeyDown);
            // 
            // txt_Client_address
            // 
            this.txt_Client_address.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_address.Location = new System.Drawing.Point(156, 189);
            this.txt_Client_address.Multiline = true;
            this.txt_Client_address.Name = "txt_Client_address";
            this.txt_Client_address.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Client_address.Size = new System.Drawing.Size(192, 68);
            this.txt_Client_address.TabIndex = 6;
            this.txt_Client_address.TextChanged += new System.EventHandler(this.txt_Client_address_TextChanged);
            this.txt_Client_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_address_KeyDown);
            // 
            // txt_ClientNumber
            // 
            this.txt_ClientNumber.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ClientNumber.Location = new System.Drawing.Point(156, 92);
            this.txt_ClientNumber.Name = "txt_ClientNumber";
            this.txt_ClientNumber.Size = new System.Drawing.Size(164, 25);
            this.txt_ClientNumber.TabIndex = 3;
            this.txt_ClientNumber.TextChanged += new System.EventHandler(this.txt_ClientNumber_TextChanged);
            this.txt_ClientNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ClientNumber_KeyDown);
            this.txt_ClientNumber.Leave += new System.EventHandler(this.txt_ClientNumber_Leave);
            // 
            // txt_Client_Pincode
            // 
            this.txt_Client_Pincode.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_Pincode.Location = new System.Drawing.Point(157, 267);
            this.txt_Client_Pincode.MaxLength = 10;
            this.txt_Client_Pincode.Name = "txt_Client_Pincode";
            this.txt_Client_Pincode.Size = new System.Drawing.Size(164, 25);
            this.txt_Client_Pincode.TabIndex = 7;
            this.txt_Client_Pincode.TextChanged += new System.EventHandler(this.txt_company_fax_TextChanged);
            this.txt_Client_Pincode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_Pincode_KeyDown);
            this.txt_Client_Pincode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Client_Pincode_KeyPress);
            // 
            // txt_Client_website
            // 
            this.txt_Client_website.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_website.Location = new System.Drawing.Point(460, 337);
            this.txt_Client_website.Name = "txt_Client_website";
            this.txt_Client_website.Size = new System.Drawing.Size(164, 25);
            this.txt_Client_website.TabIndex = 19;
            this.txt_Client_website.TextChanged += new System.EventHandler(this.txt_Client_website_TextChanged);
            this.txt_Client_website.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_website_KeyDown);
            this.txt_Client_website.Leave += new System.EventHandler(this.txt_Client_website_Leave);
            // 
            // txt_Client_fax
            // 
            this.txt_Client_fax.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Client_fax.Location = new System.Drawing.Point(460, 306);
            this.txt_Client_fax.MaxLength = 15;
            this.txt_Client_fax.Name = "txt_Client_fax";
            this.txt_Client_fax.Size = new System.Drawing.Size(164, 25);
            this.txt_Client_fax.TabIndex = 18;
            this.txt_Client_fax.TextChanged += new System.EventHandler(this.txt_Client_fax_TextChanged);
            this.txt_Client_fax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Client_fax_KeyDown);
            this.txt_Client_fax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Client_fax_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(368, 340);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 20);
            this.label17.TabIndex = 97;
            this.label17.Text = "Website:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(368, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 20);
            this.label11.TabIndex = 89;
            this.label11.Text = "Fax:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 88;
            this.label10.Text = "Pin Code:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(368, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 20);
            this.label6.TabIndex = 80;
            this.label6.Text = "City:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(367, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 78;
            this.label5.Text = "Country:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 77;
            this.label4.Text = "Address:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 75;
            this.label3.Text = "Client Number:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "Branch Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "Company Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // grp_Add_det
            // 
            this.grp_Add_det.Controls.Add(this.lbl_Record_AddedDate);
            this.grp_Add_det.Controls.Add(this.lbl_Record_Addedby);
            this.grp_Add_det.Controls.Add(this.label13);
            this.grp_Add_det.Controls.Add(this.label12);
            this.grp_Add_det.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Add_det.Location = new System.Drawing.Point(196, 482);
            this.grp_Add_det.Name = "grp_Add_det";
            this.grp_Add_det.Size = new System.Drawing.Size(1023, 100);
            this.grp_Add_det.TabIndex = 72;
            this.grp_Add_det.TabStop = false;
            this.grp_Add_det.Text = "ADDITIONAL INFORMATION";
            this.grp_Add_det.Enter += new System.EventHandler(this.grp_Add_det_Enter);
            // 
            // lbl_Record_AddedDate
            // 
            this.lbl_Record_AddedDate.AutoSize = true;
            this.lbl_Record_AddedDate.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Record_AddedDate.Location = new System.Drawing.Point(293, 66);
            this.lbl_Record_AddedDate.Name = "lbl_Record_AddedDate";
            this.lbl_Record_AddedDate.Size = new System.Drawing.Size(51, 20);
            this.lbl_Record_AddedDate.TabIndex = 25;
            this.lbl_Record_AddedDate.Text = "label19";
            this.lbl_Record_AddedDate.Click += new System.EventHandler(this.lbl_Record_AddedDate_Click);
            // 
            // lbl_Record_Addedby
            // 
            this.lbl_Record_Addedby.AutoSize = true;
            this.lbl_Record_Addedby.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Record_Addedby.Location = new System.Drawing.Point(293, 33);
            this.lbl_Record_Addedby.Name = "lbl_Record_Addedby";
            this.lbl_Record_Addedby.Size = new System.Drawing.Size(51, 20);
            this.lbl_Record_Addedby.TabIndex = 24;
            this.lbl_Record_Addedby.Text = "label14";
            this.lbl_Record_Addedby.Click += new System.EventHandler(this.lbl_Record_Addedby_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 20);
            this.label13.TabIndex = 69;
            this.label13.Text = "Record Added On";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(24, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 20);
            this.label12.TabIndex = 68;
            this.label12.Text = "Record Added By";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // lbl_Client
            // 
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Client.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(156)))));
            this.lbl_Client.Location = new System.Drawing.Point(691, 9);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(78, 31);
            this.lbl_Client.TabIndex = 73;
            this.lbl_Client.Text = "CLIENT";
            this.lbl_Client.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Client.Click += new System.EventHandler(this.lbl_Client_Click);
            // 
            // pnlSideTree
            // 
            this.pnlSideTree.Controls.Add(this.tree_Client);
            this.pnlSideTree.Location = new System.Drawing.Point(-4, 0);
            this.pnlSideTree.Name = "pnlSideTree";
            this.pnlSideTree.Size = new System.Drawing.Size(190, 645);
            this.pnlSideTree.TabIndex = 74;
            this.pnlSideTree.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSideTree_Paint);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(621, 595);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(130, 32);
            this.btn_Delete.TabIndex = 27;
            this.btn_Delete.Text = "Delete Client";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // Create_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 639);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.pnlSideTree);
            this.Controls.Add(this.lbl_Client);
            this.Controls.Add(this.grp_Add_det);
            this.Controls.Add(this.grp_Client_det);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.MaximizeBox = false;
            this.Name = "Create_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create_Client";
            this.Load += new System.EventHandler(this.Create_Client_Load);
            this.grp_Client_det.ResumeLayout(false);
            this.grp_Client_det.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Client_image)).EndInit();
            this.grp_Add_det.ResumeLayout(false);
            this.grp_Add_det.PerformLayout();
            this.pnlSideTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox grp_Client_det;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ddl_Client_district;
        private System.Windows.Forms.TextBox txt_Client_address;
        private System.Windows.Forms.TextBox txt_ClientNumber;
        private System.Windows.Forms.TextBox txt_Client_Pincode;
        private System.Windows.Forms.TextBox txt_Client_website;
        private System.Windows.Forms.TextBox txt_Client_fax;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Ddl_Client_State;
        private System.Windows.Forms.TextBox txt_Client_phono;
        private System.Windows.Forms.TextBox txt_Client_city;
        private System.Windows.Forms.TextBox txt_Client_email;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grp_Add_det;
        private System.Windows.Forms.Label lbl_Record_AddedDate;
        private System.Windows.Forms.Label lbl_Record_Addedby;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox Client_image;
        private System.Windows.Forms.ComboBox ddl_Company;
        private System.Windows.Forms.ComboBox ddl_branchname;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.TextBox textBoximage;
        private System.Windows.Forms.Button btn_image;
        private System.Windows.Forms.TreeView tree_Client;
        private System.Windows.Forms.Panel pnlSideTree;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Client_Code;
        private System.Windows.Forms.TextBox txt_CostTATExcel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView grd_Email;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.RadioButton rbtn_Disable;
        private System.Windows.Forms.RadioButton rbtn_Enable;
        private System.Windows.Forms.ComboBox Ddl_Client_Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}