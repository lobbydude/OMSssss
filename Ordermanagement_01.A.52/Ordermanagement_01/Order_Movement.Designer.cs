namespace Ordermanagement_01
{
    partial class Order_Movement
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
            this.grd_order = new System.Windows.Forms.DataGridView();
            this.Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Number = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Client_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATECOUNTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Order_number = new System.Windows.Forms.TextBox();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.rbtn_Move_Tier2_Inhouse = new System.Windows.Forms.RadioButton();
            this.Rb_Move_To_Tier1Abs = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_Move_To_Abstractor = new System.Windows.Forms.RadioButton();
            this.rbtn_Move_to_research = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grd_order
            // 
            this.grd_order.AllowDrop = true;
            this.grd_order.AllowUserToAddRows = false;
            this.grd_order.AllowUserToDeleteRows = false;
            this.grd_order.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grd_order.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_order.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_order.ColumnHeadersHeight = 30;
            this.grd_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chk,
            this.SNo,
            this.Order_Number,
            this.Client_Name,
            this.Sub_ProcessName,
            this.Order_Type,
            this.STATECOUNTY,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Date,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column1,
            this.Column2});
            this.grd_order.Location = new System.Drawing.Point(6, 19);
            this.grd_order.Name = "grd_order";
            this.grd_order.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grd_order.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grd_order.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.grd_order.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grd_order.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grd_order.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_order.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_order.RowTemplate.Height = 25;
            this.grd_order.Size = new System.Drawing.Size(1231, 237);
            this.grd_order.TabIndex = 136;
            this.grd_order.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_order_CellClick);
            // 
            // Chk
            // 
            this.Chk.HeaderText = "";
            this.Chk.Name = "Chk";
            this.Chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chk.Width = 19;
            // 
            // SNo
            // 
            this.SNo.HeaderText = "S. No";
            this.SNo.Name = "SNo";
            this.SNo.ReadOnly = true;
            this.SNo.Width = 67;
            // 
            // Order_Number
            // 
            this.Order_Number.HeaderText = "ORDER NUMBER";
            this.Order_Number.Name = "Order_Number";
            this.Order_Number.ReadOnly = true;
            this.Order_Number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Order_Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Order_Number.Width = 135;
            // 
            // Client_Name
            // 
            this.Client_Name.HeaderText = "CLIENT";
            this.Client_Name.Name = "Client_Name";
            this.Client_Name.ReadOnly = true;
            this.Client_Name.Width = 78;
            // 
            // Sub_ProcessName
            // 
            this.Sub_ProcessName.HeaderText = "SUB CLIENT";
            this.Sub_ProcessName.Name = "Sub_ProcessName";
            this.Sub_ProcessName.ReadOnly = true;
            this.Sub_ProcessName.Width = 106;
            // 
            // Order_Type
            // 
            this.Order_Type.HeaderText = "ORDER TYPE";
            this.Order_Type.Name = "Order_Type";
            this.Order_Type.ReadOnly = true;
            this.Order_Type.Width = 112;
            // 
            // STATECOUNTY
            // 
            this.STATECOUNTY.HeaderText = "STATE & COUNTY";
            this.STATECOUNTY.Name = "STATECOUNTY";
            this.STATECOUNTY.ReadOnly = true;
            this.STATECOUNTY.Width = 145;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "COUNTY TYPE";
            this.Column3.Name = "Column3";
            this.Column3.Width = 122;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "TASK";
            this.Column4.Name = "Column4";
            this.Column4.Width = 66;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "STATUS";
            this.Column5.Name = "Column5";
            this.Column5.Width = 82;
            // 
            // Date
            // 
            this.Date.HeaderText = "RECEIVED DATE";
            this.Date.Name = "Date";
            this.Date.Width = 132;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            this.Column7.Width = 89;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            this.Column8.Width = 89;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            this.Column9.Width = 89;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Column10";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            this.Column10.Width = 96;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 89;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 137;
            this.label1.Text = "Order Number :";
            // 
            // txt_Order_number
            // 
            this.txt_Order_number.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Order_number.Location = new System.Drawing.Point(130, 64);
            this.txt_Order_number.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Order_number.Name = "txt_Order_number";
            this.txt_Order_number.Size = new System.Drawing.Size(214, 25);
            this.txt_Order_number.TabIndex = 138;
            this.txt_Order_number.TextChanged += new System.EventHandler(this.txt_Order_number_TextChanged);
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit.Location = new System.Drawing.Point(585, 376);
            this.btn_Submit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(89, 35);
            this.btn_Submit.TabIndex = 141;
            this.btn_Submit.Text = "Move";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.White;
            this.btn_Refresh.BackgroundImage = global::Ordermanagement_01.Properties.Resources.refresh1;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.ForeColor = System.Drawing.Color.SeaShell;
            this.btn_Refresh.Location = new System.Drawing.Point(12, 12);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(37, 40);
            this.btn_Refresh.TabIndex = 142;
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // rbtn_Move_Tier2_Inhouse
            // 
            this.rbtn_Move_Tier2_Inhouse.AutoSize = true;
            this.rbtn_Move_Tier2_Inhouse.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_Move_Tier2_Inhouse.Location = new System.Drawing.Point(746, 12);
            this.rbtn_Move_Tier2_Inhouse.Name = "rbtn_Move_Tier2_Inhouse";
            this.rbtn_Move_Tier2_Inhouse.Size = new System.Drawing.Size(189, 28);
            this.rbtn_Move_Tier2_Inhouse.TabIndex = 144;
            this.rbtn_Move_Tier2_Inhouse.Text = "Move To Tier2 Inhouse";
            this.rbtn_Move_Tier2_Inhouse.UseVisualStyleBackColor = true;
            this.rbtn_Move_Tier2_Inhouse.CheckedChanged += new System.EventHandler(this.rbtn_Move_Tier2_Inhouse_CheckedChanged);
            // 
            // Rb_Move_To_Tier1Abs
            // 
            this.Rb_Move_To_Tier1Abs.AutoSize = true;
            this.Rb_Move_To_Tier1Abs.Checked = true;
            this.Rb_Move_To_Tier1Abs.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rb_Move_To_Tier1Abs.Location = new System.Drawing.Point(354, 12);
            this.Rb_Move_To_Tier1Abs.Name = "Rb_Move_To_Tier1Abs";
            this.Rb_Move_To_Tier1Abs.Size = new System.Drawing.Size(208, 28);
            this.Rb_Move_To_Tier1Abs.TabIndex = 143;
            this.Rb_Move_To_Tier1Abs.TabStop = true;
            this.Rb_Move_To_Tier1Abs.Text = "Move To Tier1 Abstractor";
            this.Rb_Move_To_Tier1Abs.UseVisualStyleBackColor = true;
            this.Rb_Move_To_Tier1Abs.CheckedChanged += new System.EventHandler(this.Rb_Move_To_Tier1Abs_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grd_order);
            this.groupBox1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1250, 269);
            this.groupBox1.TabIndex = 145;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Info";
            // 
            // rbtn_Move_To_Abstractor
            // 
            this.rbtn_Move_To_Abstractor.AutoSize = true;
            this.rbtn_Move_To_Abstractor.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_Move_To_Abstractor.Location = new System.Drawing.Point(572, 12);
            this.rbtn_Move_To_Abstractor.Name = "rbtn_Move_To_Abstractor";
            this.rbtn_Move_To_Abstractor.Size = new System.Drawing.Size(168, 28);
            this.rbtn_Move_To_Abstractor.TabIndex = 146;
            this.rbtn_Move_To_Abstractor.Text = "Move To Abstractor";
            this.rbtn_Move_To_Abstractor.UseVisualStyleBackColor = true;
            // 
            // rbtn_Move_to_research
            // 
            this.rbtn_Move_to_research.AutoSize = true;
            this.rbtn_Move_to_research.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_Move_to_research.Location = new System.Drawing.Point(941, 12);
            this.rbtn_Move_to_research.Name = "rbtn_Move_to_research";
            this.rbtn_Move_to_research.Size = new System.Drawing.Size(156, 28);
            this.rbtn_Move_to_research.TabIndex = 147;
            this.rbtn_Move_to_research.Text = "Move To Research";
            this.rbtn_Move_to_research.UseVisualStyleBackColor = true;
            // 
            // Order_Movement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 414);
            this.Controls.Add(this.rbtn_Move_to_research);
            this.Controls.Add(this.rbtn_Move_To_Abstractor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbtn_Move_Tier2_Inhouse);
            this.Controls.Add(this.Rb_Move_To_Tier1Abs);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Order_number);
            this.Name = "Order_Movement";
            this.Text = "Order_Movement";
            this.Load += new System.EventHandler(this.Order_Movement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_order)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd_order;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Order_number;
        private System.Windows.Forms.Button btn_Submit;
        internal System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.RadioButton rbtn_Move_Tier2_Inhouse;
        private System.Windows.Forms.RadioButton Rb_Move_To_Tier1Abs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewButtonColumn Order_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub_ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATECOUNTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.RadioButton rbtn_Move_To_Abstractor;
        private System.Windows.Forms.RadioButton rbtn_Move_to_research;
    }
}