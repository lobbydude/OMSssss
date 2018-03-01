namespace Ordermanagement_01.Masters
{
    partial class Client_Template
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
            this.tree_Subprocess = new System.Windows.Forms.TreeView();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddl_Order_Type = new System.Windows.Forms.ComboBox();
            this.grd_Template = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Header = new System.Windows.Forms.TextBox();
            this.txt_Content = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Header_Template = new System.Windows.Forms.Button();
            this.btn_Content_Template = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Template)).BeginInit();
            this.SuspendLayout();
            // 
            // tree_Subprocess
            // 
            this.tree_Subprocess.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tree_Subprocess.Location = new System.Drawing.Point(3, 0);
            this.tree_Subprocess.Name = "tree_Subprocess";
            this.tree_Subprocess.Size = new System.Drawing.Size(190, 514);
            this.tree_Subprocess.TabIndex = 9;
            this.tree_Subprocess.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_Subprocess_AfterSelect);
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(104)))), ((int)(((byte)(156)))));
            this.lbl_Header.Location = new System.Drawing.Point(478, 9);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(152, 31);
            this.lbl_Header.TabIndex = 87;
            this.lbl_Header.Text = "Client Template";
            this.lbl_Header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 89;
            this.label2.Text = "Order Type:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ddl_Order_Type
            // 
            this.ddl_Order_Type.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Order_Type.FormattingEnabled = true;
            this.ddl_Order_Type.Location = new System.Drawing.Point(422, 57);
            this.ddl_Order_Type.Name = "ddl_Order_Type";
            this.ddl_Order_Type.Size = new System.Drawing.Size(277, 28);
            this.ddl_Order_Type.TabIndex = 1;
            // 
            // grd_Template
            // 
            this.grd_Template.AllowUserToAddRows = false;
            this.grd_Template.AllowUserToResizeRows = false;
            this.grd_Template.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Template.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_Template.ColumnHeadersHeight = 28;
            this.grd_Template.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column8,
            this.Column3,
            this.Column5,
            this.Column11,
            this.Column12,
            this.Column6,
            this.Column9,
            this.Column10});
            this.grd_Template.Location = new System.Drawing.Point(199, 250);
            this.grd_Template.Name = "grd_Template";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Template.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grd_Template.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Template.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grd_Template.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grd_Template.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grd_Template.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_Template.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grd_Template.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grd_Template.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_Template.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Template.RowTemplate.Height = 25;
            this.grd_Template.Size = new System.Drawing.Size(889, 264);
            this.grd_Template.TabIndex = 8;
            this.grd_Template.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_Template_CellClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 43.83677F;
            this.Column1.HeaderText = "S.No";
            this.Column1.Name = "Column1";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Order Type";
            this.Column7.Name = "Column7";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 218.0215F;
            this.Column2.HeaderText = "Header Template";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Content_Template";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 106.599F;
            this.Column3.HeaderText = "UPLOADED BY";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 66.79855F;
            this.Column5.HeaderText = "DELETE";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Header_Path";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Footer_Path";
            this.Column12.Name = "Column12";
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Template_id";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Userid";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Subprocess_id";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "Upload  Header Template:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "Upload Content Template:";
            // 
            // txt_Header
            // 
            this.txt_Header.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Header.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Header.Location = new System.Drawing.Point(422, 106);
            this.txt_Header.Name = "txt_Header";
            this.txt_Header.ReadOnly = true;
            this.txt_Header.Size = new System.Drawing.Size(277, 25);
            this.txt_Header.TabIndex = 3;
            // 
            // txt_Content
            // 
            this.txt_Content.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Content.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Content.Location = new System.Drawing.Point(422, 158);
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.ReadOnly = true;
            this.txt_Content.Size = new System.Drawing.Size(277, 25);
            this.txt_Content.TabIndex = 5;
            // 
            // btn_Save
            // 
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Save.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(422, 198);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(93, 30);
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Submit";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(521, 198);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 30);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Clear";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Header_Template
            // 
            this.btn_Header_Template.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Header_Template.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Header_Template.Location = new System.Drawing.Point(705, 103);
            this.btn_Header_Template.Name = "btn_Header_Template";
            this.btn_Header_Template.Size = new System.Drawing.Size(100, 30);
            this.btn_Header_Template.TabIndex = 2;
            this.btn_Header_Template.Text = "Upload";
            this.btn_Header_Template.UseVisualStyleBackColor = true;
            this.btn_Header_Template.Click += new System.EventHandler(this.btn_Header_Template_Click);
            // 
            // btn_Content_Template
            // 
            this.btn_Content_Template.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Content_Template.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Content_Template.Location = new System.Drawing.Point(705, 153);
            this.btn_Content_Template.Name = "btn_Content_Template";
            this.btn_Content_Template.Size = new System.Drawing.Size(100, 30);
            this.btn_Content_Template.TabIndex = 4;
            this.btn_Content_Template.Text = "Upload";
            this.btn_Content_Template.UseVisualStyleBackColor = true;
            this.btn_Content_Template.Click += new System.EventHandler(this.btn_Content_Template_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(705, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 20);
            this.label14.TabIndex = 222;
            this.label14.Text = "*";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.Red;
            this.label45.Location = new System.Drawing.Point(869, 198);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(200, 19);
            this.label45.TabIndex = 233;
            this.label45.Text = "(Fields with * Mark are Mandatory)";
            // 
            // Client_Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 516);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_Content_Template);
            this.Controls.Add(this.btn_Header_Template);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txt_Content);
            this.Controls.Add(this.txt_Header);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grd_Template);
            this.Controls.Add(this.ddl_Order_Type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.tree_Subprocess);
            this.Name = "Client_Template";
            this.Text = "Client_Template";
            this.Load += new System.EventHandler(this.Client_Template_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Template)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree_Subprocess;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddl_Order_Type;
        private System.Windows.Forms.DataGridView grd_Template;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Header;
        private System.Windows.Forms.TextBox txt_Content;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Header_Template;
        private System.Windows.Forms.Button btn_Content_Template;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}