namespace Ordermanagement_01.Matrix
{
    partial class Category
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Category = new System.Windows.Forms.TextBox();
            this.txt_Salary_From = new System.Windows.Forms.TextBox();
            this.txt_Salary_To = new System.Windows.Forms.TextBox();
            this.Grd_Emp_Efficiency = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Emp_Efficiency)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.label1.Location = new System.Drawing.Point(61, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.label2.Location = new System.Drawing.Point(60, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Salary From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.label3.Location = new System.Drawing.Point(61, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Salary To";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(356, 186);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(79, 35);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Save.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(253, 186);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(86, 35);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Submit";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Category
            // 
            this.txt_Category.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Category.Location = new System.Drawing.Point(207, 39);
            this.txt_Category.Name = "txt_Category";
            this.txt_Category.Size = new System.Drawing.Size(275, 28);
            this.txt_Category.TabIndex = 1;
            // 
            // txt_Salary_From
            // 
            this.txt_Salary_From.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Salary_From.Location = new System.Drawing.Point(207, 87);
            this.txt_Salary_From.Name = "txt_Salary_From";
            this.txt_Salary_From.Size = new System.Drawing.Size(275, 28);
            this.txt_Salary_From.TabIndex = 2;
            // 
            // txt_Salary_To
            // 
            this.txt_Salary_To.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Salary_To.Location = new System.Drawing.Point(207, 136);
            this.txt_Salary_To.Name = "txt_Salary_To";
            this.txt_Salary_To.Size = new System.Drawing.Size(275, 28);
            this.txt_Salary_To.TabIndex = 3;
            // 
            // Grd_Emp_Efficiency
            // 
            this.Grd_Emp_Efficiency.AllowUserToAddRows = false;
            this.Grd_Emp_Efficiency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grd_Emp_Efficiency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grd_Emp_Efficiency.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Emp_Efficiency.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grd_Emp_Efficiency.ColumnHeadersHeight = 35;
            this.Grd_Emp_Efficiency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column7,
            this.Column2,
            this.Column6,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Emp_Efficiency.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grd_Emp_Efficiency.Location = new System.Drawing.Point(2, 236);
            this.Grd_Emp_Efficiency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Grd_Emp_Efficiency.Name = "Grd_Emp_Efficiency";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Emp_Efficiency.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grd_Emp_Efficiency.RowHeadersVisible = false;
            this.Grd_Emp_Efficiency.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Grd_Emp_Efficiency.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.Grd_Emp_Efficiency.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grd_Emp_Efficiency.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Grd_Emp_Efficiency.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.Grd_Emp_Efficiency.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Grd_Emp_Efficiency.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grd_Emp_Efficiency.RowTemplate.Height = 25;
            this.Grd_Emp_Efficiency.ShowCellToolTips = false;
            this.Grd_Emp_Efficiency.Size = new System.Drawing.Size(769, 312);
            this.Grd_Emp_Efficiency.TabIndex = 6;
            this.Grd_Emp_Efficiency.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_Emp_Efficiency_CellClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 18.53489F;
            this.Column1.HeaderText = "Sl.No";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 40F;
            this.Column5.HeaderText = "Category_ID";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.Visible = false;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 70.20377F;
            this.Column7.HeaderText = "Category";
            this.Column7.Name = "Column7";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 75.76038F;
            this.Column2.HeaderText = "Salary From";
            this.Column2.Name = "Column2";
            // 
            // Column6
            // 
            this.Column6.FillWeight = 75.24811F;
            this.Column6.HeaderText = "Salary To";
            this.Column6.Name = "Column6";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50.74622F;
            this.Column3.HeaderText = "VIEW/EDIT";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Text = "";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 39.50667F;
            this.Column4.HeaderText = "DELETE";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(486, 44);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 20);
            this.label21.TabIndex = 227;
            this.label21.Text = "*";
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 550);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Grd_Emp_Efficiency);
            this.Controls.Add(this.txt_Salary_To);
            this.Controls.Add(this.txt_Salary_From);
            this.Controls.Add(this.txt_Category);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Category";
            this.Text = "Category";
            this.Load += new System.EventHandler(this.Category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Emp_Efficiency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_Category;
        private System.Windows.Forms.TextBox txt_Salary_From;
        private System.Windows.Forms.TextBox txt_Salary_To;
        private System.Windows.Forms.DataGridView Grd_Emp_Efficiency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.Label label21;
    }
}