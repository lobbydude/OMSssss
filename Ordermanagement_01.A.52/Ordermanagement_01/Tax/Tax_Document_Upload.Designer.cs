namespace Ordermanagement_01.Tax
{
    partial class Tax_Document_Upload
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Tax_Upload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Grid_Tax_Upload = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_Tax_Dscription = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.lbl_Header = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Tax_Upload)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Tax_Upload
            // 
            this.btn_Tax_Upload.BackColor = System.Drawing.Color.Transparent;
            this.btn_Tax_Upload.BackgroundImage = global::Ordermanagement_01.Properties.Resources.button;
            this.btn_Tax_Upload.FlatAppearance.BorderSize = 0;
            this.btn_Tax_Upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tax_Upload.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tax_Upload.ForeColor = System.Drawing.Color.White;
            this.btn_Tax_Upload.Location = new System.Drawing.Point(481, 58);
            this.btn_Tax_Upload.Name = "btn_Tax_Upload";
            this.btn_Tax_Upload.Size = new System.Drawing.Size(160, 40);
            this.btn_Tax_Upload.TabIndex = 19;
            this.btn_Tax_Upload.Text = "Upload";
            this.btn_Tax_Upload.UseVisualStyleBackColor = false;
            this.btn_Tax_Upload.Click += new System.EventHandler(this.btn_Tax_Upload_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "Description";
            // 
            // Grid_Tax_Upload
            // 
            this.Grid_Tax_Upload.AllowUserToAddRows = false;
            this.Grid_Tax_Upload.AllowUserToResizeRows = false;
            this.Grid_Tax_Upload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_Tax_Upload.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(223)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Ebrima", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Tax_Upload.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Grid_Tax_Upload.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.FileSize,
            this.Column3,
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.Grid_Tax_Upload.Location = new System.Drawing.Point(15, 104);
            this.Grid_Tax_Upload.Name = "Grid_Tax_Upload";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Ebrima", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Tax_Upload.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Grid_Tax_Upload.RowHeadersVisible = false;
            this.Grid_Tax_Upload.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Tax_Upload.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.Grid_Tax_Upload.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.Grid_Tax_Upload.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Grid_Tax_Upload.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.Grid_Tax_Upload.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Grid_Tax_Upload.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Tax_Upload.RowTemplate.Height = 25;
            this.Grid_Tax_Upload.Size = new System.Drawing.Size(1005, 291);
            this.Grid_Tax_Upload.TabIndex = 16;
            this.Grid_Tax_Upload.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Tax_Upload_CellClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "Document Size";
            this.FileSize.Name = "FileSize";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Uploaded By";
            this.Column3.Name = "Column3";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Task";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Date";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "View";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Edit";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Delete";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Tax_Document_Id";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Path";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // txt_Tax_Dscription
            // 
            this.txt_Tax_Dscription.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tax_Dscription.Location = new System.Drawing.Point(96, 65);
            this.txt_Tax_Dscription.Name = "txt_Tax_Dscription";
            this.txt_Tax_Dscription.Size = new System.Drawing.Size(379, 28);
            this.txt_Tax_Dscription.TabIndex = 18;
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.Transparent;
            this.btn_Update.BackgroundImage = global::Ordermanagement_01.Properties.Resources.button;
            this.btn_Update.FlatAppearance.BorderSize = 0;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Location = new System.Drawing.Point(481, 58);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(160, 40);
            this.btn_Update.TabIndex = 21;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.Transparent;
            this.btn_clear.BackgroundImage = global::Ordermanagement_01.Properties.Resources.button;
            this.btn_clear.FlatAppearance.BorderSize = 0;
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(647, 59);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(160, 40);
            this.btn_clear.TabIndex = 22;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lbl_Header
            // 
            this.lbl_Header.BackColor = System.Drawing.Color.White;
            this.lbl_Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Header.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Header.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_Header.Location = new System.Drawing.Point(309, 3);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.ReadOnly = true;
            this.lbl_Header.Size = new System.Drawing.Size(536, 25);
            this.lbl_Header.TabIndex = 23;
            this.lbl_Header.TabStop = false;
            // 
            // Tax_Document_Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::Ordermanagement_01.Properties.Resources.Background005;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1045, 421);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Tax_Upload);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Grid_Tax_Upload);
            this.Controls.Add(this.txt_Tax_Dscription);
            this.DoubleBuffered = true;
            this.Name = "Tax_Document_Upload";
            this.Text = "Tax_Document_Upload";
            this.Load += new System.EventHandler(this.Tax_Document_Upload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Tax_Upload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Tax_Upload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView Grid_Tax_Upload;
        private System.Windows.Forms.TextBox txt_Tax_Dscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.TextBox lbl_Header;
    }
}