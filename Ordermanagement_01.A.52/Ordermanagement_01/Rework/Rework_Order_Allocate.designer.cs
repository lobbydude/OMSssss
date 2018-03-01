namespace Ordermanagement_01
{
    partial class Rework_Order_Allocate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.btn_Export = new System.Windows.Forms.Button();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.lbl_help = new System.Windows.Forms.Label();
            this.txt_Order_Number = new System.Windows.Forms.TextBox();
            this.lbl_From_Date = new System.Windows.Forms.Label();
            this.lbl_Todate = new System.Windows.Forms.Label();
            this.txt_Fromdate = new System.Windows.Forms.DateTimePicker();
            this.txt_To_Date = new System.Windows.Forms.DateTimePicker();
            this.grd_order = new System.Windows.Forms.DataGridView();
            this.Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Number = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Order_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATECOUNTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grd_Export = new System.Windows.Forms.DataGridView();
            this.btn_Allocate = new System.Windows.Forms.Button();
            this.lbl_allocated_user = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ddl_Order_Status_Reallocate = new System.Windows.Forms.ComboBox();
            this.ddl_UserName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Reallocate = new System.Windows.Forms.Button();
            this.grd_order_Allocated = new System.Windows.Forms.DataGridView();
            this.Chk_Allocate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SNo_allocate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client_Name_All = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordertype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.lbl_Total_Orders = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Task = new System.Windows.Forms.Label();
            this.ddl_Task = new System.Windows.Forms.ComboBox();
            this.ddl_County_Type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ddl_State = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ddl_Client_SubProcess = new System.Windows.Forms.ComboBox();
            this.ddl_Client_Name = new System.Windows.Forms.ComboBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Export)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_order_Allocated)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "USER NAME";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TreeView1
            // 
            this.TreeView1.AllowDrop = true;
            this.TreeView1.BackColor = System.Drawing.Color.Honeydew;
            this.TreeView1.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TreeView1.Indent = 15;
            this.TreeView1.ItemHeight = 20;
            this.TreeView1.Location = new System.Drawing.Point(9, 33);
            this.TreeView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.Size = new System.Drawing.Size(210, 335);
            this.TreeView1.TabIndex = 2;
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Export.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Export.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Export.Location = new System.Drawing.Point(274, 2);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(83, 36);
            this.btn_Export.TabIndex = 112;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_Header.Location = new System.Drawing.Point(538, -1);
            this.lbl_Header.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(350, 31);
            this.lbl_Header.TabIndex = 111;
            this.lbl_Header.Text = "REWORK ORDER ALLOCATION QUEUE";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Header.Click += new System.EventHandler(this.lbl_Header_Click);
            // 
            // lbl_help
            // 
            this.lbl_help.AutoSize = true;
            this.lbl_help.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_help.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_help.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_help.ForeColor = System.Drawing.Color.Black;
            this.lbl_help.Location = new System.Drawing.Point(995, 4);
            this.lbl_help.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_help.Name = "lbl_help";
            this.lbl_help.Size = new System.Drawing.Size(49, 21);
            this.lbl_help.TabIndex = 110;
            this.lbl_help.Text = "HELP";
            // 
            // txt_Order_Number
            // 
            this.txt_Order_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Order_Number.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Order_Number.ForeColor = System.Drawing.Color.SlateGray;
            this.txt_Order_Number.Location = new System.Drawing.Point(1048, 2);
            this.txt_Order_Number.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Order_Number.Name = "txt_Order_Number";
            this.txt_Order_Number.Size = new System.Drawing.Size(215, 25);
            this.txt_Order_Number.TabIndex = 113;
            this.txt_Order_Number.Text = "Search Order.....";
            this.txt_Order_Number.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_Order_Number_MouseClick);
            this.txt_Order_Number.TextChanged += new System.EventHandler(this.txt_Order_Number_TextChanged);
            this.txt_Order_Number.MouseEnter += new System.EventHandler(this.txt_Order_Number_MouseEnter);
            this.txt_Order_Number.MouseLeave += new System.EventHandler(this.txt_Order_Number_MouseLeave);
            // 
            // lbl_From_Date
            // 
            this.lbl_From_Date.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_From_Date.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_From_Date.ForeColor = System.Drawing.Color.Black;
            this.lbl_From_Date.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_From_Date.Location = new System.Drawing.Point(406, 34);
            this.lbl_From_Date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_From_Date.Name = "lbl_From_Date";
            this.lbl_From_Date.Size = new System.Drawing.Size(79, 21);
            this.lbl_From_Date.TabIndex = 115;
            this.lbl_From_Date.Text = "From Date:";
            this.lbl_From_Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Todate
            // 
            this.lbl_Todate.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Todate.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Todate.ForeColor = System.Drawing.Color.Black;
            this.lbl_Todate.Location = new System.Drawing.Point(629, 35);
            this.lbl_Todate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Todate.Name = "lbl_Todate";
            this.lbl_Todate.Size = new System.Drawing.Size(81, 21);
            this.lbl_Todate.TabIndex = 114;
            this.lbl_Todate.Text = "To Date";
            this.lbl_Todate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Fromdate
            // 
            this.txt_Fromdate.CustomFormat = "MM/DD/YYYY";
            this.txt_Fromdate.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_Fromdate.Location = new System.Drawing.Point(483, 30);
            this.txt_Fromdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Fromdate.Name = "txt_Fromdate";
            this.txt_Fromdate.Size = new System.Drawing.Size(141, 25);
            this.txt_Fromdate.TabIndex = 116;
            this.txt_Fromdate.Value = new System.DateTime(2014, 11, 11, 0, 0, 0, 0);
            // 
            // txt_To_Date
            // 
            this.txt_To_Date.CustomFormat = "MM/DD/YYYY";
            this.txt_To_Date.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_To_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txt_To_Date.Location = new System.Drawing.Point(708, 34);
            this.txt_To_Date.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_To_Date.Name = "txt_To_Date";
            this.txt_To_Date.Size = new System.Drawing.Size(141, 25);
            this.txt_To_Date.TabIndex = 117;
            this.txt_To_Date.Value = new System.DateTime(2014, 11, 11, 0, 0, 0, 0);
            // 
            // grd_order
            // 
            this.grd_order.AllowDrop = true;
            this.grd_order.AllowUserToAddRows = false;
            this.grd_order.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grd_order.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_order.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_order.ColumnHeadersHeight = 30;
            this.grd_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chk,
            this.SNo,
            this.Client_Name,
            this.Sub_ProcessName,
            this.Order_Number,
            this.Order_Type,
            this.STATECOUNTY,
            this.Column11,
            this.Date,
            this.Order_ID,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column12});
            this.grd_order.Location = new System.Drawing.Point(223, 109);
            this.grd_order.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grd_order.Name = "grd_order";
            this.grd_order.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grd_order.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grd_order.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.grd_order.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grd_order.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grd_order.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_order.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order.RowTemplate.Height = 25;
            this.grd_order.Size = new System.Drawing.Size(1040, 259);
            this.grd_order.TabIndex = 118;
            this.grd_order.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_order_CellClick);
            // 
            // Chk
            // 
            this.Chk.HeaderText = "Chk";
            this.Chk.Name = "Chk";
            this.Chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chk.Width = 110;
            // 
            // SNo
            // 
            this.SNo.HeaderText = "S. No";
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            this.SNo.Width = 111;
            // 
            // Client_Name
            // 
            this.Client_Name.HeaderText = "CLIENT";
            this.Client_Name.Name = "Client_Name";
            this.Client_Name.ReadOnly = true;
            this.Client_Name.Width = 110;
            // 
            // Sub_ProcessName
            // 
            this.Sub_ProcessName.HeaderText = "SUB CLIENT";
            this.Sub_ProcessName.Name = "Sub_ProcessName";
            this.Sub_ProcessName.ReadOnly = true;
            this.Sub_ProcessName.Width = 111;
            // 
            // Order_Number
            // 
            this.Order_Number.HeaderText = "ORDER NUMBER";
            this.Order_Number.Name = "Order_Number";
            this.Order_Number.ReadOnly = true;
            this.Order_Number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Order_Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Order_Number.Width = 110;
            // 
            // Order_Type
            // 
            this.Order_Type.HeaderText = "ORDER TYPE";
            this.Order_Type.Name = "Order_Type";
            this.Order_Type.ReadOnly = true;
            this.Order_Type.Width = 111;
            // 
            // STATECOUNTY
            // 
            this.STATECOUNTY.HeaderText = "STATE & COUNTY";
            this.STATECOUNTY.Name = "STATECOUNTY";
            this.STATECOUNTY.ReadOnly = true;
            this.STATECOUNTY.Width = 110;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "COUNTY TYPE";
            this.Column11.Name = "Column11";
            this.Column11.Width = 111;
            // 
            // Date
            // 
            this.Date.HeaderText = "RECEIVED DATE";
            this.Date.Name = "Date";
            this.Date.Width = 110;
            // 
            // Order_ID
            // 
            this.Order_ID.HeaderText = "Order_ID";
            this.Order_ID.Name = "Order_ID";
            this.Order_ID.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Column10";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "State";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Grd_Export
            // 
            this.Grd_Export.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Export.Location = new System.Drawing.Point(918, 370);
            this.Grd_Export.Name = "Grd_Export";
            this.Grd_Export.Size = new System.Drawing.Size(240, 38);
            this.Grd_Export.TabIndex = 122;
            this.Grd_Export.Visible = false;
            // 
            // btn_Allocate
            // 
            this.btn_Allocate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Allocate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Allocate.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Allocate.ForeColor = System.Drawing.Color.White;
            this.btn_Allocate.Location = new System.Drawing.Point(483, 372);
            this.btn_Allocate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Allocate.Name = "btn_Allocate";
            this.btn_Allocate.Size = new System.Drawing.Size(136, 32);
            this.btn_Allocate.TabIndex = 121;
            this.btn_Allocate.Text = "Allocate";
            this.btn_Allocate.UseVisualStyleBackColor = false;
            this.btn_Allocate.Click += new System.EventHandler(this.btn_Allocate_Click);
            // 
            // lbl_allocated_user
            // 
            this.lbl_allocated_user.AutoSize = true;
            this.lbl_allocated_user.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_allocated_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_allocated_user.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_allocated_user.ForeColor = System.Drawing.Color.Black;
            this.lbl_allocated_user.Location = new System.Drawing.Point(100, 375);
            this.lbl_allocated_user.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_allocated_user.Name = "lbl_allocated_user";
            this.lbl_allocated_user.Size = new System.Drawing.Size(44, 21);
            this.lbl_allocated_user.TabIndex = 120;
            this.lbl_allocated_user.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 374);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 22);
            this.label4.TabIndex = 119;
            this.label4.Text = "Allocate To :";
            // 
            // ddl_Order_Status_Reallocate
            // 
            this.ddl_Order_Status_Reallocate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Order_Status_Reallocate.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Order_Status_Reallocate.FormattingEnabled = true;
            this.ddl_Order_Status_Reallocate.Location = new System.Drawing.Point(467, 580);
            this.ddl_Order_Status_Reallocate.Margin = new System.Windows.Forms.Padding(4);
            this.ddl_Order_Status_Reallocate.Name = "ddl_Order_Status_Reallocate";
            this.ddl_Order_Status_Reallocate.Size = new System.Drawing.Size(192, 28);
            this.ddl_Order_Status_Reallocate.TabIndex = 129;
            // 
            // ddl_UserName
            // 
            this.ddl_UserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_UserName.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_UserName.FormattingEnabled = true;
            this.ddl_UserName.Location = new System.Drawing.Point(118, 577);
            this.ddl_UserName.Margin = new System.Windows.Forms.Padding(4);
            this.ddl_UserName.Name = "ddl_UserName";
            this.ddl_UserName.Size = new System.Drawing.Size(239, 28);
            this.ddl_UserName.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(401, 583);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 127;
            this.label5.Text = "Task :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(23, 580);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.TabIndex = 126;
            this.label6.Text = "User Name :";
            // 
            // btn_Reallocate
            // 
            this.btn_Reallocate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Reallocate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Reallocate.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reallocate.ForeColor = System.Drawing.Color.White;
            this.btn_Reallocate.Location = new System.Drawing.Point(684, 574);
            this.btn_Reallocate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Reallocate.Name = "btn_Reallocate";
            this.btn_Reallocate.Size = new System.Drawing.Size(150, 32);
            this.btn_Reallocate.TabIndex = 124;
            this.btn_Reallocate.Text = "Reallocate";
            this.btn_Reallocate.UseVisualStyleBackColor = false;
            this.btn_Reallocate.Click += new System.EventHandler(this.btn_Reallocate_Click);
            // 
            // grd_order_Allocated
            // 
            this.grd_order_Allocated.AllowUserToAddRows = false;
            this.grd_order_Allocated.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grd_order_Allocated.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_order_Allocated.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grd_order_Allocated.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order_Allocated.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grd_order_Allocated.ColumnHeadersHeight = 30;
            this.grd_order_Allocated.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chk_Allocate,
            this.SNo_allocate,
            this.Client_Name_All,
            this.Column1,
            this.Column2,
            this.Column3,
            this.ordertype,
            this.Column4,
            this.orderid,
            this.user1,
            this.Column6,
            this.Userid,
            this.Status_Id,
            this.Column5});
            this.grd_order_Allocated.Location = new System.Drawing.Point(6, 412);
            this.grd_order_Allocated.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grd_order_Allocated.Name = "grd_order_Allocated";
            this.grd_order_Allocated.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grd_order_Allocated.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grd_order_Allocated.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grd_order_Allocated.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.grd_order_Allocated.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grd_order_Allocated.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grd_order_Allocated.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_order_Allocated.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order_Allocated.RowTemplate.Height = 25;
            this.grd_order_Allocated.Size = new System.Drawing.Size(1249, 156);
            this.grd_order_Allocated.TabIndex = 123;
            // 
            // Chk_Allocate
            // 
            this.Chk_Allocate.FillWeight = 159.8985F;
            this.Chk_Allocate.Name = "Chk_Allocate";
            this.Chk_Allocate.Width = 214;
            // 
            // SNo_allocate
            // 
            this.SNo_allocate.FillWeight = 92.51269F;
            this.SNo_allocate.HeaderText = "S. No";
            this.SNo_allocate.Name = "SNo_allocate";
            this.SNo_allocate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SNo_allocate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SNo_allocate.Width = 124;
            // 
            // Client_Name_All
            // 
            this.Client_Name_All.FillWeight = 92.51269F;
            this.Client_Name_All.HeaderText = "CLIENT";
            this.Client_Name_All.Name = "Client_Name_All";
            this.Client_Name_All.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Client_Name_All.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Client_Name_All.Width = 124;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 92.51269F;
            this.Column1.HeaderText = "SUB CLIENT";
            this.Column1.Name = "Column1";
            this.Column1.Width = 124;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 92.51269F;
            this.Column2.HeaderText = "ORDER NUMBER";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 124;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 92.51269F;
            this.Column3.HeaderText = "STATE & COUNTY";
            this.Column3.Name = "Column3";
            this.Column3.Width = 124;
            // 
            // ordertype
            // 
            this.ordertype.HeaderText = "ORDER TYPE";
            this.ordertype.Name = "ordertype";
            this.ordertype.Visible = false;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 92.51269F;
            this.Column4.HeaderText = "RECEIVED DATE";
            this.Column4.Name = "Column4";
            this.Column4.Width = 124;
            // 
            // orderid
            // 
            this.orderid.HeaderText = "orderid";
            this.orderid.Name = "orderid";
            this.orderid.Visible = false;
            // 
            // user1
            // 
            this.user1.FillWeight = 92.51269F;
            this.user1.HeaderText = "USER";
            this.user1.Name = "user1";
            this.user1.Width = 124;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 92.51269F;
            this.Column6.HeaderText = "TASK";
            this.Column6.Name = "Column6";
            this.Column6.Width = 124;
            // 
            // Userid
            // 
            this.Userid.HeaderText = "Column8";
            this.Userid.Name = "Userid";
            this.Userid.Visible = false;
            // 
            // Status_Id
            // 
            this.Status_Id.HeaderText = "Status_Id";
            this.Status_Id.Name = "Status_Id";
            this.Status_Id.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Countyid";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // btn_Submit
            // 
            this.btn_Submit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Submit.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.ForeColor = System.Drawing.Color.White;
            this.btn_Submit.Location = new System.Drawing.Point(876, 33);
            this.btn_Submit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(82, 27);
            this.btn_Submit.TabIndex = 132;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = false;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // lbl_Total_Orders
            // 
            this.lbl_Total_Orders.AutoSize = true;
            this.lbl_Total_Orders.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total_Orders.ForeColor = System.Drawing.Color.Red;
            this.lbl_Total_Orders.Location = new System.Drawing.Point(1129, 39);
            this.lbl_Total_Orders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Total_Orders.Name = "lbl_Total_Orders";
            this.lbl_Total_Orders.Size = new System.Drawing.Size(14, 17);
            this.lbl_Total_Orders.TabIndex = 134;
            this.lbl_Total_Orders.Text = "T";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1044, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 19);
            this.label8.TabIndex = 133;
            this.label8.Text = "Total Orders:";
            // 
            // lbl_Task
            // 
            this.lbl_Task.AutoSize = true;
            this.lbl_Task.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Task.ForeColor = System.Drawing.Color.Black;
            this.lbl_Task.Location = new System.Drawing.Point(225, 377);
            this.lbl_Task.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Task.Name = "lbl_Task";
            this.lbl_Task.Size = new System.Drawing.Size(48, 22);
            this.lbl_Task.TabIndex = 135;
            this.lbl_Task.Text = "Task :";
            // 
            // ddl_Task
            // 
            this.ddl_Task.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Task.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Task.FormattingEnabled = true;
            this.ddl_Task.Location = new System.Drawing.Point(277, 374);
            this.ddl_Task.Margin = new System.Windows.Forms.Padding(4);
            this.ddl_Task.Name = "ddl_Task";
            this.ddl_Task.Size = new System.Drawing.Size(199, 28);
            this.ddl_Task.TabIndex = 136;
            // 
            // ddl_County_Type
            // 
            this.ddl_County_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_County_Type.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_County_Type.FormattingEnabled = true;
            this.ddl_County_Type.Location = new System.Drawing.Point(934, 79);
            this.ddl_County_Type.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddl_County_Type.Name = "ddl_County_Type";
            this.ddl_County_Type.Size = new System.Drawing.Size(195, 28);
            this.ddl_County_Type.TabIndex = 144;
            this.ddl_County_Type.SelectedIndexChanged += new System.EventHandler(this.ddl_County_Type_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label7.Location = new System.Drawing.Point(940, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 21);
            this.label7.TabIndex = 143;
            this.label7.Text = "TIER TYPE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddl_State
            // 
            this.ddl_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_State.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_State.FormattingEnabled = true;
            this.ddl_State.Location = new System.Drawing.Point(735, 79);
            this.ddl_State.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddl_State.Name = "ddl_State";
            this.ddl_State.Size = new System.Drawing.Size(195, 28);
            this.ddl_State.TabIndex = 142;
            this.ddl_State.SelectedIndexChanged += new System.EventHandler(this.ddl_State_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label10.Location = new System.Drawing.Point(740, 61);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 21);
            this.label10.TabIndex = 141;
            this.label10.Text = "STATE:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label11.Location = new System.Drawing.Point(231, 51);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 21);
            this.label11.TabIndex = 140;
            this.label11.Text = "CLIENT :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(479, 55);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 21);
            this.label12.TabIndex = 139;
            this.label12.Text = "SUB CLIENT :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddl_Client_SubProcess
            // 
            this.ddl_Client_SubProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Client_SubProcess.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Client_SubProcess.FormattingEnabled = true;
            this.ddl_Client_SubProcess.Location = new System.Drawing.Point(476, 79);
            this.ddl_Client_SubProcess.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddl_Client_SubProcess.Name = "ddl_Client_SubProcess";
            this.ddl_Client_SubProcess.Size = new System.Drawing.Size(255, 28);
            this.ddl_Client_SubProcess.TabIndex = 138;
            this.ddl_Client_SubProcess.SelectedIndexChanged += new System.EventHandler(this.ddl_Client_SubProcess_SelectedIndexChanged);
            this.ddl_Client_SubProcess.SelectionChangeCommitted += new System.EventHandler(this.ddl_Client_SubProcess_SelectionChangeCommitted);
            // 
            // ddl_Client_Name
            // 
            this.ddl_Client_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Client_Name.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Client_Name.FormattingEnabled = true;
            this.ddl_Client_Name.Location = new System.Drawing.Point(226, 78);
            this.ddl_Client_Name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddl_Client_Name.Name = "ddl_Client_Name";
            this.ddl_Client_Name.Size = new System.Drawing.Size(230, 28);
            this.ddl_Client_Name.TabIndex = 137;
            this.ddl_Client_Name.SelectedIndexChanged += new System.EventHandler(this.ddl_Client_Name_SelectedIndexChanged);
            this.ddl_Client_Name.SelectionChangeCommitted += new System.EventHandler(this.ddl_Client_Name_SelectionChangeCommitted);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.White;
            this.btn_Refresh.BackgroundImage = global::Ordermanagement_01.Properties.Resources.refresh1;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.ForeColor = System.Drawing.Color.SeaShell;
            this.btn_Refresh.Location = new System.Drawing.Point(226, 4);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(36, 34);
            this.btn_Refresh.TabIndex = 145;
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // Rework_Order_Allocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 613);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.ddl_County_Type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ddl_State);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ddl_Client_SubProcess);
            this.Controls.Add(this.ddl_Client_Name);
            this.Controls.Add(this.ddl_Task);
            this.Controls.Add(this.lbl_Task);
            this.Controls.Add(this.lbl_Total_Orders);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.ddl_Order_Status_Reallocate);
            this.Controls.Add(this.ddl_UserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Reallocate);
            this.Controls.Add(this.grd_order_Allocated);
            this.Controls.Add(this.Grd_Export);
            this.Controls.Add(this.btn_Allocate);
            this.Controls.Add(this.lbl_allocated_user);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grd_order);
            this.Controls.Add(this.txt_To_Date);
            this.Controls.Add(this.txt_Fromdate);
            this.Controls.Add(this.lbl_From_Date);
            this.Controls.Add(this.lbl_Todate);
            this.Controls.Add(this.txt_Order_Number);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.lbl_help);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TreeView1);
            this.Name = "Rework_Order_Allocate";
            this.Text = "Completed_Order_Allocate";
            this.Load += new System.EventHandler(this.Completed_Order_Allocate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Export)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_order_Allocated)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView TreeView1;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Label lbl_help;
        private System.Windows.Forms.TextBox txt_Order_Number;
        private System.Windows.Forms.Label lbl_From_Date;
        private System.Windows.Forms.Label lbl_Todate;
        private System.Windows.Forms.DateTimePicker txt_Fromdate;
        private System.Windows.Forms.DateTimePicker txt_To_Date;
        private System.Windows.Forms.DataGridView grd_order;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub_ProcessName;
        private System.Windows.Forms.DataGridViewButtonColumn Order_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATECOUNTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridView Grd_Export;
        private System.Windows.Forms.Button btn_Allocate;
        private System.Windows.Forms.Label lbl_allocated_user;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddl_Order_Status_Reallocate;
        private System.Windows.Forms.ComboBox ddl_UserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Reallocate;
        private System.Windows.Forms.DataGridView grd_order_Allocated;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chk_Allocate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo_allocate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_Name_All;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordertype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderid;
        private System.Windows.Forms.DataGridViewTextBoxColumn user1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Label lbl_Total_Orders;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Task;
        private System.Windows.Forms.ComboBox ddl_Task;
        private System.Windows.Forms.ComboBox ddl_County_Type;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddl_State;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ddl_Client_SubProcess;
        private System.Windows.Forms.ComboBox ddl_Client_Name;
        internal System.Windows.Forms.Button btn_Refresh;
    }
}