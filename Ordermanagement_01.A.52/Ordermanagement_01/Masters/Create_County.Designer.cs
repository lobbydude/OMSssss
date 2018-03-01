namespace Ordermanagement_01.Masters
{
    partial class Create_County
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Import = new System.Windows.Forms.Button();
            this.lbl_ErrorInfo = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ddl_State = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grd_County = new System.Windows.Forms.DataGridView();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_County = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddl_CountyType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddl_searchCounty = new System.Windows.Forms.ComboBox();
            this.btn_searchClear = new System.Windows.Forms.Button();
            this.btn_searchSub = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ddl_SearchbyState = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblRecordsStatus = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Total_Orders = new System.Windows.Forms.Label();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grd_County)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Import
            // 
            this.btn_Import.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Import.Location = new System.Drawing.Point(711, 16);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(154, 39);
            this.btn_Import.TabIndex = 19;
            this.btn_Import.Text = "Import County Excel";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // lbl_ErrorInfo
            // 
            this.lbl_ErrorInfo.AutoSize = true;
            this.lbl_ErrorInfo.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ErrorInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(156)))));
            this.lbl_ErrorInfo.Location = new System.Drawing.Point(364, 12);
            this.lbl_ErrorInfo.Name = "lbl_ErrorInfo";
            this.lbl_ErrorInfo.Size = new System.Drawing.Size(92, 31);
            this.lbl_ErrorInfo.TabIndex = 100;
            this.lbl_ErrorInfo.Text = "COUNTY";
            this.lbl_ErrorInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Red;
            this.label45.Location = new System.Drawing.Point(631, 121);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(200, 19);
            this.label45.TabIndex = 222;
            this.label45.Text = "(Fields with * Mark are Mandatory)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(295, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 220;
            this.label5.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(601, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 20);
            this.label16.TabIndex = 217;
            this.label16.Text = "County :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddl_State
            // 
            this.ddl_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_State.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_State.FormattingEnabled = true;
            this.ddl_State.Location = new System.Drawing.Point(103, 67);
            this.ddl_State.Name = "ddl_State";
            this.ddl_State.Size = new System.Drawing.Size(189, 28);
            this.ddl_State.TabIndex = 2;
            this.ddl_State.SelectedIndexChanged += new System.EventHandler(this.ddl_State_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 215;
            this.label1.Text = "State Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(590, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 223;
            this.label2.Text = "*";
            // 
            // grd_County
            // 
            this.grd_County.AllowUserToAddRows = false;
            this.grd_County.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_County.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_County.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grd_County.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_County.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_County.ColumnHeadersHeight = 30;
            this.grd_County.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column11,
            this.Column12,
            this.Column3,
            this.Column5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_County.DefaultCellStyle = dataGridViewCellStyle3;
            this.grd_County.Location = new System.Drawing.Point(18, 231);
            this.grd_County.Name = "grd_County";
            this.grd_County.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_County.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grd_County.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_County.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grd_County.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grd_County.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grd_County.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_County.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grd_County.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grd_County.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_County.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_County.RowTemplate.Height = 25;
            this.grd_County.ShowCellToolTips = false;
            this.grd_County.Size = new System.Drawing.Size(847, 328);
            this.grd_County.TabIndex = 12;
            this.grd_County.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_County_CellClick);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Submit.Location = new System.Drawing.Point(335, 113);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(70, 32);
            this.btn_Submit.TabIndex = 5;
            this.btn_Submit.Text = "Save";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Cancel.Location = new System.Drawing.Point(443, 113);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(77, 32);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Clear";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_County
            // 
            this.txt_County.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_County.Location = new System.Drawing.Point(662, 71);
            this.txt_County.Name = "txt_County";
            this.txt_County.Size = new System.Drawing.Size(189, 25);
            this.txt_County.TabIndex = 4;
            this.txt_County.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_County_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 228;
            this.label3.Text = "County Type :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ddl_CountyType
            // 
            this.ddl_CountyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_CountyType.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_CountyType.FormattingEnabled = true;
            this.ddl_CountyType.Items.AddRange(new object[] {
            "Select",
            "Tier 1",
            "Tier 2"});
            this.ddl_CountyType.Location = new System.Drawing.Point(400, 68);
            this.ddl_CountyType.Name = "ddl_CountyType";
            this.ddl_CountyType.Size = new System.Drawing.Size(189, 28);
            this.ddl_CountyType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(854, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 230;
            this.label4.Text = "*";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.White;
            this.btn_Refresh.BackgroundImage = global::Ordermanagement_01.Properties.Resources.refresh1;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.ForeColor = System.Drawing.Color.SeaShell;
            this.btn_Refresh.Location = new System.Drawing.Point(18, 16);
            this.btn_Refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(32, 32);
            this.btn_Refresh.TabIndex = 1;
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddl_searchCounty);
            this.groupBox1.Controls.Add(this.btn_searchClear);
            this.groupBox1.Controls.Add(this.btn_searchSub);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ddl_SearchbyState);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 73);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // ddl_searchCounty
            // 
            this.ddl_searchCounty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_searchCounty.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_searchCounty.FormattingEnabled = true;
            this.ddl_searchCounty.Location = new System.Drawing.Point(398, 31);
            this.ddl_searchCounty.Name = "ddl_searchCounty";
            this.ddl_searchCounty.Size = new System.Drawing.Size(189, 28);
            this.ddl_searchCounty.TabIndex = 9;
            this.ddl_searchCounty.SelectedIndexChanged += new System.EventHandler(this.ddl_searchCounty_SelectedIndexChanged);
            // 
            // btn_searchClear
            // 
            this.btn_searchClear.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_searchClear.Location = new System.Drawing.Point(740, 31);
            this.btn_searchClear.Name = "btn_searchClear";
            this.btn_searchClear.Size = new System.Drawing.Size(77, 34);
            this.btn_searchClear.TabIndex = 11;
            this.btn_searchClear.Text = "Clear";
            this.btn_searchClear.UseVisualStyleBackColor = true;
            this.btn_searchClear.Click += new System.EventHandler(this.btn_searchClear_Click);
            // 
            // btn_searchSub
            // 
            this.btn_searchSub.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_searchSub.Location = new System.Drawing.Point(645, 31);
            this.btn_searchSub.Name = "btn_searchSub";
            this.btn_searchSub.Size = new System.Drawing.Size(77, 34);
            this.btn_searchSub.TabIndex = 10;
            this.btn_searchSub.Text = "Submit";
            this.btn_searchSub.UseVisualStyleBackColor = true;
            this.btn_searchSub.Click += new System.EventHandler(this.btn_searchSub_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(291, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 233;
            this.label9.Text = "County Name:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddl_SearchbyState
            // 
            this.ddl_SearchbyState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_SearchbyState.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_SearchbyState.FormattingEnabled = true;
            this.ddl_SearchbyState.Location = new System.Drawing.Point(90, 30);
            this.ddl_SearchbyState.Name = "ddl_SearchbyState";
            this.ddl_SearchbyState.Size = new System.Drawing.Size(189, 28);
            this.ddl_SearchbyState.TabIndex = 8;
            this.ddl_SearchbyState.SelectedIndexChanged += new System.EventHandler(this.ddl_SearchbyState_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 232;
            this.label10.Text = "State Name :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Controls.Add(this.lblRecordsStatus);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbl_Total_Orders);
            this.panel1.Location = new System.Drawing.Point(17, 557);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 43);
            this.panel1.TabIndex = 13;
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFirst.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(107, 8);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 24);
            this.btnFirst.TabIndex = 14;
            this.btnFirst.Text = "|< First";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lblRecordsStatus
            // 
            this.lblRecordsStatus.AutoSize = true;
            this.lblRecordsStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecordsStatus.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.lblRecordsStatus.Location = new System.Drawing.Point(344, 7);
            this.lblRecordsStatus.Name = "lblRecordsStatus";
            this.lblRecordsStatus.Size = new System.Drawing.Size(38, 22);
            this.lblRecordsStatus.TabIndex = 16;
            this.lblRecordsStatus.Text = "0 / 0";
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(222, 7);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 24);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "< Pervious";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLast.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(558, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 24);
            this.btnLast.TabIndex = 18;
            this.btnLast.Text = "Last >|";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(433, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 24);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(681, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 19);
            this.label8.TabIndex = 25;
            this.label8.Text = "Total Records :";
            // 
            // lbl_Total_Orders
            // 
            this.lbl_Total_Orders.AutoSize = true;
            this.lbl_Total_Orders.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total_Orders.ForeColor = System.Drawing.Color.Red;
            this.lbl_Total_Orders.Location = new System.Drawing.Point(792, 11);
            this.lbl_Total_Orders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Total_Orders.Name = "lbl_Total_Orders";
            this.lbl_Total_Orders.Size = new System.Drawing.Size(14, 17);
            this.lbl_Total_Orders.TabIndex = 26;
            this.lbl_Total_Orders.Text = "T";
            // 
            // Column6
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.FillWeight = 33.50254F;
            this.Column6.HeaderText = "S.No";
            this.Column6.Name = "Column6";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 162.0766F;
            this.Column1.HeaderText = "State";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 243.3686F;
            this.Column2.HeaderText = "County";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 71.89055F;
            this.Column4.HeaderText = "County Type";
            this.Column4.Name = "Column4";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "State_id";
            this.Column11.Name = "Column11";
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "County_id";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 45.31154F;
            this.Column3.HeaderText = "View";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 43.85018F;
            this.Column5.HeaderText = "Delete";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Create_County
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 598);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddl_CountyType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_County);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.grd_County);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ddl_State);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_ErrorInfo);
            this.Controls.Add(this.btn_Import);
            this.MaximizeBox = false;
            this.Name = "Create_County";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create_County";
            this.Load += new System.EventHandler(this.Create_County_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_County)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.Label lbl_ErrorInfo;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox ddl_State;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grd_County;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_County;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddl_CountyType;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddl_SearchbyState;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_searchClear;
        private System.Windows.Forms.Button btn_searchSub;
        private System.Windows.Forms.ComboBox ddl_searchCounty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblRecordsStatus;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Total_Orders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
    }
}