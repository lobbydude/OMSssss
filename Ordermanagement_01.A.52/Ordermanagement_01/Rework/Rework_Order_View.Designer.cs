﻿namespace Ordermanagement_01
{
    partial class Rework_Order_View
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddl_UserName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.link_Search_Order_Allocation = new System.Windows.Forms.Button();
            this.grd_Admin_orders = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddl_Order_Status_Reallocate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblRecordsStatus = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_Total_Orders = new System.Windows.Forms.Label();
            this.txt_Order_Number = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Admin_orders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(481, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "REWORK ORDER VIEW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ddl_UserName
            // 
            this.ddl_UserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_UserName.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_UserName.FormattingEnabled = true;
            this.ddl_UserName.Location = new System.Drawing.Point(616, 515);
            this.ddl_UserName.Margin = new System.Windows.Forms.Padding(4);
            this.ddl_UserName.Name = "ddl_UserName";
            this.ddl_UserName.Size = new System.Drawing.Size(239, 28);
            this.ddl_UserName.TabIndex = 134;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(531, 519);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.TabIndex = 133;
            this.label6.Text = "User Name :";
            // 
            // link_Search_Order_Allocation
            // 
            this.link_Search_Order_Allocation.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_Search_Order_Allocation.Location = new System.Drawing.Point(1124, 515);
            this.link_Search_Order_Allocation.Name = "link_Search_Order_Allocation";
            this.link_Search_Order_Allocation.Size = new System.Drawing.Size(124, 30);
            this.link_Search_Order_Allocation.TabIndex = 132;
            this.link_Search_Order_Allocation.Text = "Reallocate";
            this.link_Search_Order_Allocation.UseVisualStyleBackColor = true;
            this.link_Search_Order_Allocation.Click += new System.EventHandler(this.link_Search_Order_Allocation_Click);
            // 
            // grd_Admin_orders
            // 
            this.grd_Admin_orders.AllowUserToAddRows = false;
            this.grd_Admin_orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_Admin_orders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grd_Admin_orders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_Admin_orders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grd_Admin_orders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Admin_orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_Admin_orders.ColumnHeadersHeight = 30;
            this.grd_Admin_orders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column11,
            this.Column5,
            this.Column6,
            this.Column12,
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column13});
            this.grd_Admin_orders.Location = new System.Drawing.Point(5, 43);
            this.grd_Admin_orders.Name = "grd_Admin_orders";
            this.grd_Admin_orders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grd_Admin_orders.RowHeadersVisible = false;
            this.grd_Admin_orders.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.grd_Admin_orders.Size = new System.Drawing.Size(1240, 417);
            this.grd_Admin_orders.TabIndex = 131;
            this.grd_Admin_orders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Admin_orders_CellClick);
            // 
            // Column8
            // 
            this.Column8.FillWeight = 39.77002F;
            this.Column8.HeaderText = "S. No";
            this.Column8.Name = "Column8";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 67.16708F;
            this.Column1.HeaderText = "CLIENT";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 132.2441F;
            this.Column2.HeaderText = "SUB CLIENT";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 103.8503F;
            this.Column3.HeaderText = "ORDER NUMBER";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 91.25575F;
            this.Column4.HeaderText = "ORDER TYPE";
            this.Column4.Name = "Column4";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "STATECOUNTY";
            this.Column11.Name = "Column11";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 57.71303F;
            this.Column5.HeaderText = "USER";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.FillWeight = 86.96323F;
            this.Column6.HeaderText = "RECEIVED DATE";
            this.Column6.Name = "Column6";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "TASK";
            this.Column12.Name = "Column12";
            // 
            // Column7
            // 
            this.Column7.FillWeight = 92.61018F;
            this.Column7.HeaderText = "PROGRESS";
            this.Column7.Name = "Column7";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 228.4264F;
            this.Column10.HeaderText = "";
            this.Column10.Name = "Column10";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Allocated_User_Id";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // ddl_Order_Status_Reallocate
            // 
            this.ddl_Order_Status_Reallocate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_Order_Status_Reallocate.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Order_Status_Reallocate.FormattingEnabled = true;
            this.ddl_Order_Status_Reallocate.Location = new System.Drawing.Point(925, 516);
            this.ddl_Order_Status_Reallocate.Margin = new System.Windows.Forms.Padding(4);
            this.ddl_Order_Status_Reallocate.Name = "ddl_Order_Status_Reallocate";
            this.ddl_Order_Status_Reallocate.Size = new System.Drawing.Size(192, 28);
            this.ddl_Order_Status_Reallocate.TabIndex = 136;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(869, 520);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 135;
            this.label5.Text = "Task :";
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
            this.panel1.Location = new System.Drawing.Point(5, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 43);
            this.panel1.TabIndex = 137;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFirst.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.Location = new System.Drawing.Point(237, 10);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 24);
            this.btnFirst.TabIndex = 16;
            this.btnFirst.Text = "|< First";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lblRecordsStatus
            // 
            this.lblRecordsStatus.AutoSize = true;
            this.lblRecordsStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecordsStatus.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.lblRecordsStatus.Location = new System.Drawing.Point(543, 9);
            this.lblRecordsStatus.Name = "lblRecordsStatus";
            this.lblRecordsStatus.Size = new System.Drawing.Size(38, 22);
            this.lblRecordsStatus.TabIndex = 15;
            this.lblRecordsStatus.Text = "0 / 0";
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(382, 8);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 24);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Text = "< Pervious";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLast.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.Location = new System.Drawing.Point(829, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 24);
            this.btnLast.TabIndex = 14;
            this.btnLast.Text = "Last >|";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(679, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 24);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1114, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 19);
            this.label8.TabIndex = 25;
            this.label8.Text = "Total Orders:";
            // 
            // lbl_Total_Orders
            // 
            this.lbl_Total_Orders.AutoSize = true;
            this.lbl_Total_Orders.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total_Orders.ForeColor = System.Drawing.Color.Red;
            this.lbl_Total_Orders.Location = new System.Drawing.Point(1209, 13);
            this.lbl_Total_Orders.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Total_Orders.Name = "lbl_Total_Orders";
            this.lbl_Total_Orders.Size = new System.Drawing.Size(14, 17);
            this.lbl_Total_Orders.TabIndex = 26;
            this.lbl_Total_Orders.Text = "T";
            // 
            // txt_Order_Number
            // 
            this.txt_Order_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Order_Number.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Order_Number.ForeColor = System.Drawing.Color.SlateGray;
            this.txt_Order_Number.Location = new System.Drawing.Point(975, 10);
            this.txt_Order_Number.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Order_Number.Name = "txt_Order_Number";
            this.txt_Order_Number.Size = new System.Drawing.Size(269, 28);
            this.txt_Order_Number.TabIndex = 138;
            this.txt_Order_Number.Text = "Search Order number.....";
            this.txt_Order_Number.TextChanged += new System.EventHandler(this.txt_Order_Number_TextChanged);
            this.txt_Order_Number.MouseEnter += new System.EventHandler(this.txt_Order_Number_MouseEnter);
            // 
            // Rework_Order_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 549);
            this.Controls.Add(this.txt_Order_Number);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ddl_Order_Status_Reallocate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddl_UserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.link_Search_Order_Allocation);
            this.Controls.Add(this.grd_Admin_orders);
            this.Controls.Add(this.label1);
            this.Name = "Rework_Order_View";
            this.Text = "Rework_Order_View";
            this.Load += new System.EventHandler(this.Rework_Order_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Admin_orders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddl_UserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button link_Search_Order_Allocation;
        private System.Windows.Forms.DataGridView grd_Admin_orders;
        private System.Windows.Forms.ComboBox ddl_Order_Status_Reallocate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblRecordsStatus;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_Total_Orders;
        private System.Windows.Forms.TextBox txt_Order_Number;
    }
}