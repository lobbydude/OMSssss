namespace Ordermanagement_01
{
    partial class Typing_Task_Confirmation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.Gv_Question_Bind = new System.Windows.Forms.DataGridView();
            this.S_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.grp_Order_TypeTask = new System.Windows.Forms.GroupBox();
            this.ddl_GroupName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddl_Order_Type = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ddl_Next_Question_N = new System.Windows.Forms.ComboBox();
            this.ddl_Next_Question_Y = new System.Windows.Forms.ComboBox();
            this.lbl_Question_No = new System.Windows.Forms.Label();
            this.Txt_Question = new System.Windows.Forms.TextBox();
            this.ddl_Status = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Search_clear = new System.Windows.Forms.Button();
            this.btn_Search_Submit = new System.Windows.Forms.Button();
            this.ddl_Status_Search = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddl_OrderType_Search = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.Gv_Question = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Question_Bind)).BeginInit();
            this.grp_Order_TypeTask.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Question)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Submit
            // 
            this.btn_Submit.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Submit.Location = new System.Drawing.Point(371, 231);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(80, 30);
            this.btn_Submit.TabIndex = 11;
            this.btn_Submit.Text = "Submit";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Cancel.Location = new System.Drawing.Point(466, 231);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(74, 30);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Gv_Question_Bind
            // 
            this.Gv_Question_Bind.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gv_Question_Bind.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Gv_Question_Bind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gv_Question_Bind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S_No,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Q_id});
            this.Gv_Question_Bind.Location = new System.Drawing.Point(12, 7);
            this.Gv_Question_Bind.Name = "Gv_Question_Bind";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gv_Question_Bind.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Gv_Question_Bind.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Gv_Question_Bind.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.Gv_Question_Bind.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.Gv_Question_Bind.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Gv_Question_Bind.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.Gv_Question_Bind.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Gv_Question_Bind.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gv_Question_Bind.Size = new System.Drawing.Size(289, 394);
            this.Gv_Question_Bind.TabIndex = 18;
            this.Gv_Question_Bind.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_CellClick);
            this.Gv_Question_Bind.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_Bind_CellContentClick);
            this.Gv_Question_Bind.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Gv_Question_Bind_RowHeaderMouseClick);
            this.Gv_Question_Bind.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Gv_Question_Bind_RowHeaderMouseDoubleClick);
            // 
            // S_No
            // 
            this.S_No.HeaderText = "Q.No";
            this.S_No.Name = "S_No";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Q.No";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            this.Column10.Width = 40;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Questions";
            this.Column11.Name = "Column11";
            this.Column11.Width = 250;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Group_Name";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Q_id
            // 
            this.Q_id.HeaderText = "Column14";
            this.Q_id.Name = "Q_id";
            this.Q_id.Visible = false;
            // 
            // btn_Up
            // 
            this.btn_Up.BackgroundImage = global::Ordermanagement_01.Properties.Resources.Up;
            this.btn_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Up.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.btn_Up.Location = new System.Drawing.Point(303, 155);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(32, 34);
            this.btn_Up.TabIndex = 19;
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.BackgroundImage = global::Ordermanagement_01.Properties.Resources.Down;
            this.btn_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Down.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.btn_Down.Location = new System.Drawing.Point(303, 212);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(32, 34);
            this.btn_Down.TabIndex = 20;
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // grp_Order_TypeTask
            // 
            this.grp_Order_TypeTask.Controls.Add(this.ddl_GroupName);
            this.grp_Order_TypeTask.Controls.Add(this.label5);
            this.grp_Order_TypeTask.Controls.Add(this.ddl_Order_Type);
            this.grp_Order_TypeTask.Controls.Add(this.label16);
            this.grp_Order_TypeTask.Controls.Add(this.label14);
            this.grp_Order_TypeTask.Controls.Add(this.label6);
            this.grp_Order_TypeTask.Controls.Add(this.label7);
            this.grp_Order_TypeTask.Controls.Add(this.label9);
            this.grp_Order_TypeTask.Controls.Add(this.btn_Cancel);
            this.grp_Order_TypeTask.Controls.Add(this.label10);
            this.grp_Order_TypeTask.Controls.Add(this.btn_Submit);
            this.grp_Order_TypeTask.Controls.Add(this.ddl_Next_Question_N);
            this.grp_Order_TypeTask.Controls.Add(this.ddl_Next_Question_Y);
            this.grp_Order_TypeTask.Controls.Add(this.lbl_Question_No);
            this.grp_Order_TypeTask.Controls.Add(this.Txt_Question);
            this.grp_Order_TypeTask.Controls.Add(this.ddl_Status);
            this.grp_Order_TypeTask.Enabled = false;
            this.grp_Order_TypeTask.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.grp_Order_TypeTask.Location = new System.Drawing.Point(339, 123);
            this.grp_Order_TypeTask.Name = "grp_Order_TypeTask";
            this.grp_Order_TypeTask.Size = new System.Drawing.Size(919, 275);
            this.grp_Order_TypeTask.TabIndex = 123;
            this.grp_Order_TypeTask.TabStop = false;
            this.grp_Order_TypeTask.Text = "Check list Questions";
            this.grp_Order_TypeTask.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ddl_GroupName
            // 
            this.ddl_GroupName.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.ddl_GroupName.FormattingEnabled = true;
            this.ddl_GroupName.Items.AddRange(new object[] {
            "Select",
            "Preliminary Steps",
            "Deed",
            "Probate/Will",
            "Mortgage",
            "Judgment/Liens",
            "Taxes",
            "Bankruptcy",
            "Legal Description",
            "Easements & CCRs",
            "Final Steps"});
            this.ddl_GroupName.Location = new System.Drawing.Point(140, 116);
            this.ddl_GroupName.Name = "ddl_GroupName";
            this.ddl_GroupName.Size = new System.Drawing.Size(175, 28);
            this.ddl_GroupName.TabIndex = 138;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 137;
            this.label5.Text = "Group Name:";
            // 
            // ddl_Order_Type
            // 
            this.ddl_Order_Type.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.ddl_Order_Type.FormattingEnabled = true;
            this.ddl_Order_Type.Location = new System.Drawing.Point(140, 86);
            this.ddl_Order_Type.Name = "ddl_Order_Type";
            this.ddl_Order_Type.Size = new System.Drawing.Size(175, 28);
            this.ddl_Order_Type.TabIndex = 136;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(417, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(190, 20);
            this.label16.TabIndex = 133;
            this.label16.Text = "Next Question Number for No:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(417, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 20);
            this.label14.TabIndex = 132;
            this.label14.Text = "Next Question Number for Yes:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 131;
            this.label6.Text = "Qusetion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 130;
            this.label7.Text = "Order Type:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 20);
            this.label9.TabIndex = 129;
            this.label9.Text = "Status:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 128;
            this.label10.Text = "Question No:";
            // 
            // ddl_Next_Question_N
            // 
            this.ddl_Next_Question_N.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.ddl_Next_Question_N.FormattingEnabled = true;
            this.ddl_Next_Question_N.Location = new System.Drawing.Point(628, 91);
            this.ddl_Next_Question_N.Name = "ddl_Next_Question_N";
            this.ddl_Next_Question_N.Size = new System.Drawing.Size(103, 28);
            this.ddl_Next_Question_N.TabIndex = 127;
            // 
            // ddl_Next_Question_Y
            // 
            this.ddl_Next_Question_Y.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.ddl_Next_Question_Y.FormattingEnabled = true;
            this.ddl_Next_Question_Y.Location = new System.Drawing.Point(628, 53);
            this.ddl_Next_Question_Y.Name = "ddl_Next_Question_Y";
            this.ddl_Next_Question_Y.Size = new System.Drawing.Size(103, 28);
            this.ddl_Next_Question_Y.TabIndex = 126;
            // 
            // lbl_Question_No
            // 
            this.lbl_Question_No.AutoSize = true;
            this.lbl_Question_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Question_No.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Question_No.Location = new System.Drawing.Point(140, 25);
            this.lbl_Question_No.Name = "lbl_Question_No";
            this.lbl_Question_No.Size = new System.Drawing.Size(41, 22);
            this.lbl_Question_No.TabIndex = 124;
            this.lbl_Question_No.Text = "Q no";
            // 
            // Txt_Question
            // 
            this.Txt_Question.Location = new System.Drawing.Point(140, 150);
            this.Txt_Question.Multiline = true;
            this.Txt_Question.Name = "Txt_Question";
            this.Txt_Question.Size = new System.Drawing.Size(770, 71);
            this.Txt_Question.TabIndex = 123;
            // 
            // ddl_Status
            // 
            this.ddl_Status.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.ddl_Status.FormattingEnabled = true;
            this.ddl_Status.Location = new System.Drawing.Point(140, 53);
            this.ddl_Status.Name = "ddl_Status";
            this.ddl_Status.Size = new System.Drawing.Size(175, 28);
            this.ddl_Status.TabIndex = 122;
            this.ddl_Status.SelectedIndexChanged += new System.EventHandler(this.ddl_Status_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Search_clear);
            this.groupBox2.Controls.Add(this.btn_Search_Submit);
            this.groupBox2.Controls.Add(this.ddl_Status_Search);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ddl_OrderType_Search);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(342, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(916, 81);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Typing Task Master";
            // 
            // btn_Search_clear
            // 
            this.btn_Search_clear.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Search_clear.Location = new System.Drawing.Point(679, 34);
            this.btn_Search_clear.Name = "btn_Search_clear";
            this.btn_Search_clear.Size = new System.Drawing.Size(74, 30);
            this.btn_Search_clear.TabIndex = 134;
            this.btn_Search_clear.Text = "Clear";
            this.btn_Search_clear.UseVisualStyleBackColor = true;
            this.btn_Search_clear.Click += new System.EventHandler(this.btn_Search_clear_Click);
            // 
            // btn_Search_Submit
            // 
            this.btn_Search_Submit.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Search_Submit.Location = new System.Drawing.Point(587, 34);
            this.btn_Search_Submit.Name = "btn_Search_Submit";
            this.btn_Search_Submit.Size = new System.Drawing.Size(80, 30);
            this.btn_Search_Submit.TabIndex = 134;
            this.btn_Search_Submit.Text = "Search";
            this.btn_Search_Submit.UseVisualStyleBackColor = true;
            this.btn_Search_Submit.Click += new System.EventHandler(this.btn_Search_Submit_Click);
            // 
            // ddl_Status_Search
            // 
            this.ddl_Status_Search.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.ddl_Status_Search.FormattingEnabled = true;
            this.ddl_Status_Search.Location = new System.Drawing.Point(371, 34);
            this.ddl_Status_Search.Name = "ddl_Status_Search";
            this.ddl_Status_Search.Size = new System.Drawing.Size(175, 28);
            this.ddl_Status_Search.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 133;
            this.label2.Text = "Status:";
            // 
            // ddl_OrderType_Search
            // 
            this.ddl_OrderType_Search.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.ddl_OrderType_Search.FormattingEnabled = true;
            this.ddl_OrderType_Search.Location = new System.Drawing.Point(120, 34);
            this.ddl_OrderType_Search.Name = "ddl_OrderType_Search";
            this.ddl_OrderType_Search.Size = new System.Drawing.Size(175, 28);
            this.ddl_OrderType_Search.TabIndex = 132;
            this.ddl_OrderType_Search.SelectedIndexChanged += new System.EventHandler(this.ddl_OrderType_Search_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 131;
            this.label1.Text = "Order Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(612, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 31);
            this.label4.TabIndex = 125;
            this.label4.Text = "TYPING TASK CONFIRMATION";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.White;
            this.btn_Refresh.BackgroundImage = global::Ordermanagement_01.Properties.Resources.refresh1;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Refresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.ForeColor = System.Drawing.Color.SeaShell;
            this.btn_Refresh.Location = new System.Drawing.Point(303, 7);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(32, 32);
            this.btn_Refresh.TabIndex = 126;
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // Gv_Question
            // 
            this.Gv_Question.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Gv_Question.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.Gv_Question.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ebrima", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gv_Question.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Gv_Question.ColumnHeadersHeight = 32;
            this.Gv_Question.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column9,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column13});
            this.Gv_Question.Location = new System.Drawing.Point(8, 440);
            this.Gv_Question.Name = "Gv_Question";
            this.Gv_Question.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Gv_Question.RowHeadersVisible = false;
            this.Gv_Question.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Gv_Question.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.Gv_Question.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gv_Question.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Gv_Question.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.Gv_Question.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Gv_Question.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gv_Question.RowTemplate.Height = 25;
            this.Gv_Question.Size = new System.Drawing.Size(1250, 223);
            this.Gv_Question.TabIndex = 122;
            this.Gv_Question.AllowUserToAddRowsChanged += new System.EventHandler(this.Gv_Question_AllowUserToAddRowsChanged);
            this.Gv_Question.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_CellClick);
            this.Gv_Question.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_CellEndEdit);
            this.Gv_Question.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_CellEnter);
            this.Gv_Question.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_CellLeave);
            this.Gv_Question.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_CellMouseEnter);
            this.Gv_Question.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.Gv_Question_CellStateChanged);
            this.Gv_Question.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_CellValueChanged);
            this.Gv_Question.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.Gv_Question_CellValuePushed);
            this.Gv_Question.CurrentCellDirtyStateChanged += new System.EventHandler(this.Gv_Question_CurrentCellDirtyStateChanged);
            this.Gv_Question.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gv_Question_RowEnter);
            this.Gv_Question.Enter += new System.EventHandler(this.Gv_Question_Enter);
            this.Gv_Question.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gv_Question_KeyDown);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 0.6526248F;
            this.Column1.HeaderText = "Q.No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 5.708369F;
            this.Column2.HeaderText = "Order Type";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 23.32232F;
            this.Column3.HeaderText = "Order Status";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 140.8967F;
            this.Column4.HeaderText = "Confirmation Message";
            this.Column4.Name = "Column4";
            this.Column4.Width = 550;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Group Name";
            this.Column9.Name = "Column9";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 58.21359F;
            this.Column5.HeaderText = "Yes";
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 77.94975F;
            this.Column6.HeaderText = "No";
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 188.6881F;
            this.Column7.HeaderText = "View";
            this.Column7.Name = "Column7";
            this.Column7.Visible = false;
            this.Column7.Width = 75;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 304.5685F;
            this.Column8.HeaderText = "Delete";
            this.Column8.Name = "Column8";
            this.Column8.Width = 75;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Status_ID";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_Save.Location = new System.Drawing.Point(1116, 404);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(133, 30);
            this.btn_Save.TabIndex = 139;
            this.btn_Save.Text = "Save All Changes";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Typing_Task_Confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 678);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grp_Order_TypeTask);
            this.Controls.Add(this.Gv_Question);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.Gv_Question_Bind);
            this.MaximizeBox = false;
            this.Name = "Typing_Task_Confirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typing_Task_Confirmation";
            this.Load += new System.EventHandler(this.Typing_Task_Confirmation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Question_Bind)).EndInit();
            this.grp_Order_TypeTask.ResumeLayout(false);
            this.grp_Order_TypeTask.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Question)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DataGridView Gv_Question_Bind;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.GroupBox grp_Order_TypeTask;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddl_Next_Question_N;
        private System.Windows.Forms.ComboBox ddl_Next_Question_Y;
        private System.Windows.Forms.Label lbl_Question_No;
        private System.Windows.Forms.TextBox Txt_Question;
        private System.Windows.Forms.ComboBox ddl_Status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Search_clear;
        private System.Windows.Forms.Button btn_Search_Submit;
        private System.Windows.Forms.ComboBox ddl_Status_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddl_OrderType_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddl_Order_Type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddl_GroupName;
        internal System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn S_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q_id;
        private System.Windows.Forms.DataGridView Gv_Question;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}