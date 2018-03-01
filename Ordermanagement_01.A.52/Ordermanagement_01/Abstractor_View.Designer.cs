namespace Ordermanagement_01
{
    partial class Abstractor_View
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grd_Admin_orders = new System.Windows.Forms.DataGridView();
            this.link_Search_Order_Allocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SearchOrdernumber = new System.Windows.Forms.TextBox();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Admin_orders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_Admin_orders
            // 
            this.grd_Admin_orders.AllowUserToAddRows = false;
            this.grd_Admin_orders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_Admin_orders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grd_Admin_orders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_Admin_orders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grd_Admin_orders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Admin_orders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column12,
            this.Column13});
            this.grd_Admin_orders.Location = new System.Drawing.Point(12, 64);
            this.grd_Admin_orders.Name = "grd_Admin_orders";
            this.grd_Admin_orders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grd_Admin_orders.RowHeadersVisible = false;
            this.grd_Admin_orders.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.grd_Admin_orders.Size = new System.Drawing.Size(1240, 563);
            this.grd_Admin_orders.TabIndex = 2;
            this.grd_Admin_orders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Admin_orders_CellClick);
            this.grd_Admin_orders.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grd_Admin_orders_CellMouseClick);
            // 
            // link_Search_Order_Allocation
            // 
            this.link_Search_Order_Allocation.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_Search_Order_Allocation.Location = new System.Drawing.Point(1101, 640);
            this.link_Search_Order_Allocation.Name = "link_Search_Order_Allocation";
            this.link_Search_Order_Allocation.Size = new System.Drawing.Size(124, 30);
            this.link_Search_Order_Allocation.TabIndex = 3;
            this.link_Search_Order_Allocation.Text = "Reallocate";
            this.link_Search_Order_Allocation.UseVisualStyleBackColor = true;
            this.link_Search_Order_Allocation.Click += new System.EventHandler(this.link_Search_Order_Allocation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(531, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "ABSTRACTOR VIEW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_SearchOrdernumber
            // 
            this.txt_SearchOrdernumber.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchOrdernumber.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_SearchOrdernumber.Location = new System.Drawing.Point(974, 25);
            this.txt_SearchOrdernumber.Name = "txt_SearchOrdernumber";
            this.txt_SearchOrdernumber.Size = new System.Drawing.Size(275, 28);
            this.txt_SearchOrdernumber.TabIndex = 149;
            this.txt_SearchOrdernumber.Text = "Search by order number...";
            this.txt_SearchOrdernumber.Click += new System.EventHandler(this.txt_SearchOrdernumber_Click);
            this.txt_SearchOrdernumber.TextChanged += new System.EventHandler(this.txt_SearchOrdernumber_TextChanged);
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
            // Column12
            // 
            this.Column12.HeaderText = "Sub_Client_Id";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "State_Id";
            this.Column13.Name = "Column13";
            this.Column13.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.YellowGreen;
            this.pictureBox1.Location = new System.Drawing.Point(31, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 13);
            this.pictureBox1.TabIndex = 150;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 17);
            this.label2.TabIndex = 151;
            this.label2.Text = "Record are belongs to NA State 11000 Client";
            // 
            // Abstractor_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_SearchOrdernumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.link_Search_Order_Allocation);
            this.Controls.Add(this.grd_Admin_orders);
            this.MaximizeBox = false;
            this.Name = "Abstractor_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abstractor_View";
            this.Load += new System.EventHandler(this.Abstractor_View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Admin_orders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grd_Admin_orders;
        private System.Windows.Forms.Button link_Search_Order_Allocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SearchOrdernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}