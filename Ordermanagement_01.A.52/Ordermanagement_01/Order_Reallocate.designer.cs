namespace Ordermanagement_01
{
    partial class Order_Reallocate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.grd_order = new System.Windows.Forms.DataGridView();
            this.OrderNumber = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rb_Status = new System.Windows.Forms.RadioButton();
            this.Rb_Task = new System.Windows.Forms.RadioButton();
            this.btn_deallocate = new System.Windows.Forms.Button();
            this.btn_Reallocate = new System.Windows.Forms.Button();
            this.ddl_Order_Status_Reallocate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Order_number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddl_UserName = new System.Windows.Forms.ComboBox();
            this.group_Task = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Order_Status_Order_Number = new System.Windows.Forms.TextBox();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.ddl_Order_Progress = new System.Windows.Forms.ComboBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.group_Status = new System.Windows.Forms.GroupBox();
            this.rbtn_Move_To_Tax = new System.Windows.Forms.RadioButton();
            this.grp_Vendor = new System.Windows.Forms.GroupBox();
            this.btn_Vendor_Submit = new System.Windows.Forms.Button();
            this.ddl_Vendor_Name = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Vendor_Order_Number = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).BeginInit();
            this.group_Task.SuspendLayout();
            this.group_Status.SuspendLayout();
            this.grp_Vendor.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(515, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "ORDER REALLOCATION";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // grd_order
            // 
            this.grd_order.AllowUserToAddRows = false;
            this.grd_order.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.grd_order.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.grd_order.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_order.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grd_order.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_order.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_order.ColumnHeadersHeight = 36;
            this.grd_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.Column13,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column12,
            this.Column10,
            this.Column11,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order.DefaultCellStyle = dataGridViewCellStyle3;
            this.grd_order.Location = new System.Drawing.Point(9, 263);
            this.grd_order.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd_order.Name = "grd_order";
            this.grd_order.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grd_order.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grd_order.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Ebrima", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grd_order.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grd_order.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grd_order.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.grd_order.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grd_order.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grd_order.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_order.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order.RowTemplate.Height = 35;
            this.grd_order.Size = new System.Drawing.Size(1243, 153);
            this.grd_order.TabIndex = 9;
            this.grd_order.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_order_CellClick);
            // 
            // OrderNumber
            // 
            this.OrderNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.OrderNumber.HeaderText = "ORDER NUMBER";
            this.OrderNumber.MinimumWidth = 2;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderNumber.Text = "";
            this.OrderNumber.Width = 135;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "DRN_ORDER_NO";
            this.Column13.Name = "Column13";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "CLIENT";
            this.Column1.Name = "Column1";
            this.Column1.Width = 97;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "SUB CLIENT";
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "RECEIVED DATE";
            this.Column3.Name = "Column3";
            this.Column3.Width = 127;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ORDER TYPE";
            this.Column4.Name = "Column4";
            this.Column4.Width = 96;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 130F;
            this.Column5.HeaderText = "ORDER REF. NO";
            this.Column5.Name = "Column5";
            this.Column5.Width = 124;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "SEARCH TYPE";
            this.Column6.Name = "Column6";
            this.Column6.Width = 117;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "COUNTY";
            this.Column7.Name = "Column7";
            this.Column7.Width = 97;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "STATE";
            this.Column8.Name = "Column8";
            this.Column8.Width = 97;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "TASK";
            this.Column9.Name = "Column9";
            this.Column9.Width = 135;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "STATUS";
            this.Column12.Name = "Column12";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "USER";
            this.Column10.Name = "Column10";
            this.Column10.Width = 97;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ORDER ID";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Client_Id";
            this.Column14.Name = "Column14";
            this.Column14.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Sub_Client_Id";
            this.Column15.Name = "Column15";
            this.Column15.Visible = false;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Order_Type_Id";
            this.Column16.Name = "Column16";
            this.Column16.Visible = false;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "TAX STATUS";
            this.Column17.Name = "Column17";
            // 
            // Column18
            // 
            this.Column18.HeaderText = "TAX TEAM STATUS";
            this.Column18.Name = "Column18";
            // 
            // Column19
            // 
            this.Column19.HeaderText = "TAX TASK STATUS";
            this.Column19.Name = "Column19";
            // 
            // Column20
            // 
            this.Column20.HeaderText = "TAX TASK USER";
            this.Column20.Name = "Column20";
            // 
            // rb_Status
            // 
            this.rb_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_Status.AutoSize = true;
            this.rb_Status.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Status.Location = new System.Drawing.Point(586, 63);
            this.rb_Status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb_Status.Name = "rb_Status";
            this.rb_Status.Size = new System.Drawing.Size(137, 28);
            this.rb_Status.TabIndex = 134;
            this.rb_Status.TabStop = true;
            this.rb_Status.Text = "Move To Status";
            this.rb_Status.UseVisualStyleBackColor = true;
            this.rb_Status.CheckedChanged += new System.EventHandler(this.rb_Status_CheckedChanged);
            // 
            // Rb_Task
            // 
            this.Rb_Task.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Rb_Task.AutoSize = true;
            this.Rb_Task.Checked = true;
            this.Rb_Task.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rb_Task.Location = new System.Drawing.Point(453, 63);
            this.Rb_Task.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Rb_Task.Name = "Rb_Task";
            this.Rb_Task.Size = new System.Drawing.Size(125, 28);
            this.Rb_Task.TabIndex = 133;
            this.Rb_Task.TabStop = true;
            this.Rb_Task.Text = "Move To Task";
            this.Rb_Task.UseVisualStyleBackColor = true;
            this.Rb_Task.CheckedChanged += new System.EventHandler(this.Rb_Task_CheckedChanged);
            // 
            // btn_deallocate
            // 
            this.btn_deallocate.Location = new System.Drawing.Point(977, 15);
            this.btn_deallocate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_deallocate.Name = "btn_deallocate";
            this.btn_deallocate.Size = new System.Drawing.Size(100, 36);
            this.btn_deallocate.TabIndex = 5;
            this.btn_deallocate.Text = "DeAllocate";
            this.btn_deallocate.UseVisualStyleBackColor = true;
            this.btn_deallocate.Click += new System.EventHandler(this.btn_deallocate_Click);
            // 
            // btn_Reallocate
            // 
            this.btn_Reallocate.Location = new System.Drawing.Point(836, 15);
            this.btn_Reallocate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Reallocate.Name = "btn_Reallocate";
            this.btn_Reallocate.Size = new System.Drawing.Size(100, 36);
            this.btn_Reallocate.TabIndex = 4;
            this.btn_Reallocate.Text = "ReAllocate";
            this.btn_Reallocate.UseVisualStyleBackColor = true;
            this.btn_Reallocate.Click += new System.EventHandler(this.btn_Reallocate_Click);
            // 
            // ddl_Order_Status_Reallocate
            // 
            this.ddl_Order_Status_Reallocate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Order_Status_Reallocate.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Order_Status_Reallocate.FormattingEnabled = true;
            this.ddl_Order_Status_Reallocate.Location = new System.Drawing.Point(636, 22);
            this.ddl_Order_Status_Reallocate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddl_Order_Status_Reallocate.Name = "ddl_Order_Status_Reallocate";
            this.ddl_Order_Status_Reallocate.Size = new System.Drawing.Size(147, 28);
            this.ddl_Order_Status_Reallocate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(584, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Task :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name :";
            // 
            // txt_Order_number
            // 
            this.txt_Order_number.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Order_number.Location = new System.Drawing.Point(116, 22);
            this.txt_Order_number.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Order_number.Name = "txt_Order_number";
            this.txt_Order_number.Size = new System.Drawing.Size(191, 25);
            this.txt_Order_number.TabIndex = 1;
            this.txt_Order_number.TextChanged += new System.EventHandler(this.txt_Order_number_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Number :";
            // 
            // ddl_UserName
            // 
            this.ddl_UserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_UserName.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_UserName.FormattingEnabled = true;
            this.ddl_UserName.Location = new System.Drawing.Point(407, 21);
            this.ddl_UserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddl_UserName.Name = "ddl_UserName";
            this.ddl_UserName.Size = new System.Drawing.Size(160, 28);
            this.ddl_UserName.TabIndex = 6;
            // 
            // group_Task
            // 
            this.group_Task.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Task.Controls.Add(this.ddl_UserName);
            this.group_Task.Controls.Add(this.label1);
            this.group_Task.Controls.Add(this.txt_Order_number);
            this.group_Task.Controls.Add(this.label2);
            this.group_Task.Controls.Add(this.label3);
            this.group_Task.Controls.Add(this.ddl_Order_Status_Reallocate);
            this.group_Task.Controls.Add(this.btn_Reallocate);
            this.group_Task.Controls.Add(this.btn_deallocate);
            this.group_Task.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.group_Task.Location = new System.Drawing.Point(8, 84);
            this.group_Task.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.group_Task.Name = "group_Task";
            this.group_Task.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.group_Task.Size = new System.Drawing.Size(1243, 58);
            this.group_Task.TabIndex = 135;
            this.group_Task.TabStop = false;
            this.group_Task.Text = "Move To Task";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Order Number :";
            // 
            // txt_Order_Status_Order_Number
            // 
            this.txt_Order_Status_Order_Number.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Order_Status_Order_Number.Location = new System.Drawing.Point(119, 24);
            this.txt_Order_Status_Order_Number.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Order_Status_Order_Number.Name = "txt_Order_Status_Order_Number";
            this.txt_Order_Status_Order_Number.Size = new System.Drawing.Size(191, 25);
            this.txt_Order_Status_Order_Number.TabIndex = 2;
            this.txt_Order_Status_Order_Number.TextChanged += new System.EventHandler(this.txt_Order_Status_Order_Number_TextChanged);
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.Location = new System.Drawing.Point(313, 27);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(47, 20);
            this.lbl_Status.TabIndex = 4;
            this.lbl_Status.Text = "Status:";
            // 
            // ddl_Order_Progress
            // 
            this.ddl_Order_Progress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Order_Progress.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Order_Progress.FormattingEnabled = true;
            this.ddl_Order_Progress.Location = new System.Drawing.Point(359, 23);
            this.ddl_Order_Progress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddl_Order_Progress.Name = "ddl_Order_Progress";
            this.ddl_Order_Progress.Size = new System.Drawing.Size(281, 28);
            this.ddl_Order_Progress.TabIndex = 8;
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(645, 19);
            this.btn_Submit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(100, 36);
            this.btn_Submit.TabIndex = 9;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // group_Status
            // 
            this.group_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.group_Status.Controls.Add(this.btn_Submit);
            this.group_Status.Controls.Add(this.ddl_Order_Progress);
            this.group_Status.Controls.Add(this.lbl_Status);
            this.group_Status.Controls.Add(this.txt_Order_Status_Order_Number);
            this.group_Status.Controls.Add(this.label5);
            this.group_Status.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.group_Status.Location = new System.Drawing.Point(8, 137);
            this.group_Status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.group_Status.Name = "group_Status";
            this.group_Status.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.group_Status.Size = new System.Drawing.Size(1243, 64);
            this.group_Status.TabIndex = 136;
            this.group_Status.TabStop = false;
            this.group_Status.Text = "Move To Status";
            // 
            // rbtn_Move_To_Tax
            // 
            this.rbtn_Move_To_Tax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtn_Move_To_Tax.AutoSize = true;
            this.rbtn_Move_To_Tax.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_Move_To_Tax.Location = new System.Drawing.Point(726, 63);
            this.rbtn_Move_To_Tax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtn_Move_To_Tax.Name = "rbtn_Move_To_Tax";
            this.rbtn_Move_To_Tax.Size = new System.Drawing.Size(118, 28);
            this.rbtn_Move_To_Tax.TabIndex = 137;
            this.rbtn_Move_To_Tax.TabStop = true;
            this.rbtn_Move_To_Tax.Text = "Move To Tax";
            this.rbtn_Move_To_Tax.UseVisualStyleBackColor = true;
            this.rbtn_Move_To_Tax.CheckedChanged += new System.EventHandler(this.rbtn_Move_To_Tax_CheckedChanged);
            // 
            // grp_Vendor
            // 
            this.grp_Vendor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grp_Vendor.Controls.Add(this.btn_Vendor_Submit);
            this.grp_Vendor.Controls.Add(this.ddl_Vendor_Name);
            this.grp_Vendor.Controls.Add(this.label6);
            this.grp_Vendor.Controls.Add(this.txt_Vendor_Order_Number);
            this.grp_Vendor.Controls.Add(this.label7);
            this.grp_Vendor.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.grp_Vendor.Location = new System.Drawing.Point(8, 205);
            this.grp_Vendor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grp_Vendor.Name = "grp_Vendor";
            this.grp_Vendor.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grp_Vendor.Size = new System.Drawing.Size(1242, 54);
            this.grp_Vendor.TabIndex = 138;
            this.grp_Vendor.TabStop = false;
            this.grp_Vendor.Text = "Move To Vendor";
            // 
            // btn_Vendor_Submit
            // 
            this.btn_Vendor_Submit.Location = new System.Drawing.Point(690, 17);
            this.btn_Vendor_Submit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Vendor_Submit.Name = "btn_Vendor_Submit";
            this.btn_Vendor_Submit.Size = new System.Drawing.Size(100, 36);
            this.btn_Vendor_Submit.TabIndex = 9;
            this.btn_Vendor_Submit.Text = "Submit";
            this.btn_Vendor_Submit.UseVisualStyleBackColor = true;
            this.btn_Vendor_Submit.Click += new System.EventHandler(this.btn_Vendor_Submit_Click);
            // 
            // ddl_Vendor_Name
            // 
            this.ddl_Vendor_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Vendor_Name.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Vendor_Name.FormattingEnabled = true;
            this.ddl_Vendor_Name.Location = new System.Drawing.Point(404, 23);
            this.ddl_Vendor_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddl_Vendor_Name.Name = "ddl_Vendor_Name";
            this.ddl_Vendor_Name.Size = new System.Drawing.Size(281, 28);
            this.ddl_Vendor_Name.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(313, 27);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Vendor Name:";
            // 
            // txt_Vendor_Order_Number
            // 
            this.txt_Vendor_Order_Number.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Vendor_Order_Number.Location = new System.Drawing.Point(119, 24);
            this.txt_Vendor_Order_Number.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Vendor_Order_Number.Name = "txt_Vendor_Order_Number";
            this.txt_Vendor_Order_Number.Size = new System.Drawing.Size(191, 25);
            this.txt_Vendor_Order_Number.TabIndex = 2;
            this.txt_Vendor_Order_Number.TextChanged += new System.EventHandler(this.txt_Vendor_Order_Number_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Order Number :";
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(848, 63);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(144, 28);
            this.radioButton1.TabIndex = 138;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Move To Vendor";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Order_Reallocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 430);
            this.Controls.Add(this.grp_Vendor);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rbtn_Move_To_Tax);
            this.Controls.Add(this.group_Status);
            this.Controls.Add(this.group_Task);
            this.Controls.Add(this.rb_Status);
            this.Controls.Add(this.Rb_Task);
            this.Controls.Add(this.grd_order);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Order_Reallocate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order_Reallocate";
            this.Load += new System.EventHandler(this.Order_Reallocate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).EndInit();
            this.group_Task.ResumeLayout(false);
            this.group_Task.PerformLayout();
            this.group_Status.ResumeLayout(false);
            this.group_Status.PerformLayout();
            this.grp_Vendor.ResumeLayout(false);
            this.grp_Vendor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grd_order;
        private System.Windows.Forms.RadioButton rb_Status;
        private System.Windows.Forms.RadioButton Rb_Task;
        private System.Windows.Forms.Button btn_deallocate;
        private System.Windows.Forms.Button btn_Reallocate;
        private System.Windows.Forms.ComboBox ddl_Order_Status_Reallocate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Order_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddl_UserName;
        private System.Windows.Forms.GroupBox group_Task;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Order_Status_Order_Number;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.ComboBox ddl_Order_Progress;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.GroupBox group_Status;
        private System.Windows.Forms.RadioButton rbtn_Move_To_Tax;
        private System.Windows.Forms.GroupBox grp_Vendor;
        private System.Windows.Forms.Button btn_Vendor_Submit;
        private System.Windows.Forms.ComboBox ddl_Vendor_Name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Vendor_Order_Number;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DataGridViewButtonColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
    }
}