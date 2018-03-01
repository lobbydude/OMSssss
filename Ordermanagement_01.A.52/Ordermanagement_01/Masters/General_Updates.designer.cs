namespace Ordermanagement_01.Masters
{
    partial class General_Updates
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_Update_Mesg = new System.Windows.Forms.Label();
            this.txt_Update_Mesg = new System.Windows.Forms.TextBox();
            this.btn_General_Save = new System.Windows.Forms.Button();
            this.btn_General_Clear = new System.Windows.Forms.Button();
            this.grd_General_Update_Message = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grd_General_Update_Message)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Update_Mesg
            // 
            this.lbl_Update_Mesg.AutoSize = true;
            this.lbl_Update_Mesg.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Update_Mesg.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_Update_Mesg.Location = new System.Drawing.Point(28, 52);
            this.lbl_Update_Mesg.Name = "lbl_Update_Mesg";
            this.lbl_Update_Mesg.Size = new System.Drawing.Size(106, 20);
            this.lbl_Update_Mesg.TabIndex = 5;
            this.lbl_Update_Mesg.Text = "Enter Message :";
            // 
            // txt_Update_Mesg
            // 
            this.txt_Update_Mesg.BackColor = System.Drawing.Color.AliceBlue;
            this.txt_Update_Mesg.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Update_Mesg.Location = new System.Drawing.Point(173, 24);
            this.txt_Update_Mesg.Multiline = true;
            this.txt_Update_Mesg.Name = "txt_Update_Mesg";
            this.txt_Update_Mesg.Size = new System.Drawing.Size(865, 96);
            this.txt_Update_Mesg.TabIndex = 1;
            // 
            // btn_General_Save
            // 
            this.btn_General_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_General_Save.BackgroundImage = global::Ordermanagement_01.Properties.Resources.blueboxbutton;
            this.btn_General_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_General_Save.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_General_Save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_General_Save.Location = new System.Drawing.Point(475, 149);
            this.btn_General_Save.Name = "btn_General_Save";
            this.btn_General_Save.Size = new System.Drawing.Size(95, 34);
            this.btn_General_Save.TabIndex = 2;
            this.btn_General_Save.Text = "Save";
            this.btn_General_Save.UseVisualStyleBackColor = false;
            this.btn_General_Save.Click += new System.EventHandler(this.btn_General_Save_Click);
            // 
            // btn_General_Clear
            // 
            this.btn_General_Clear.BackColor = System.Drawing.Color.Transparent;
            this.btn_General_Clear.BackgroundImage = global::Ordermanagement_01.Properties.Resources.Redboxbutton;
            this.btn_General_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_General_Clear.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_General_Clear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_General_Clear.Location = new System.Drawing.Point(603, 149);
            this.btn_General_Clear.Name = "btn_General_Clear";
            this.btn_General_Clear.Size = new System.Drawing.Size(91, 34);
            this.btn_General_Clear.TabIndex = 3;
            this.btn_General_Clear.Text = "Clear";
            this.btn_General_Clear.UseVisualStyleBackColor = false;
            this.btn_General_Clear.Click += new System.EventHandler(this.btn_General_Clear_Click);
            // 
            // grd_General_Update_Message
            // 
            this.grd_General_Update_Message.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_General_Update_Message.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_General_Update_Message.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_General_Update_Message.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.grd_General_Update_Message.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grd_General_Update_Message.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_General_Update_Message.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grd_General_Update_Message.ColumnHeadersHeight = 35;
            this.grd_General_Update_Message.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Ebrima", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_General_Update_Message.DefaultCellStyle = dataGridViewCellStyle4;
            this.grd_General_Update_Message.GridColor = System.Drawing.SystemColors.ControlLight;
            this.grd_General_Update_Message.Location = new System.Drawing.Point(23, 210);
            this.grd_General_Update_Message.Name = "grd_General_Update_Message";
            this.grd_General_Update_Message.ReadOnly = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Ebrima", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_General_Update_Message.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grd_General_Update_Message.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Ebrima", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_General_Update_Message.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grd_General_Update_Message.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grd_General_Update_Message.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd_General_Update_Message.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grd_General_Update_Message.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.grd_General_Update_Message.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd_General_Update_Message.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_General_Update_Message.RowTemplate.Height = 25;
            this.grd_General_Update_Message.Size = new System.Drawing.Size(1001, 267);
            this.grd_General_Update_Message.TabIndex = 4;
            this.grd_General_Update_Message.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_General_Update_Message_CellClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 2.148257F;
            this.Column1.HeaderText = "Sl.No";
            this.Column1.MinimumWidth = 50;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Gen_Update_ID";
            this.Column5.MinimumWidth = 100;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.FillWeight = 0.166582F;
            this.Column2.HeaderText = "Message";
            this.Column2.MinimumWidth = 680;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 28.14204F;
            this.Column3.HeaderText = "VIEW/EDIT";
            this.Column3.MinimumWidth = 120;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Text = "";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 369.5432F;
            this.Column4.HeaderText = "DELETE";
            this.Column4.MinimumWidth = 182;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // General_Updates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 508);
            this.Controls.Add(this.grd_General_Update_Message);
            this.Controls.Add(this.btn_General_Clear);
            this.Controls.Add(this.btn_General_Save);
            this.Controls.Add(this.txt_Update_Mesg);
            this.Controls.Add(this.lbl_Update_Mesg);
            this.Name = "General_Updates";
            this.Text = "General_Updates";
            this.Load += new System.EventHandler(this.General_Updates_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.grd_General_Update_Message)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Update_Mesg;
        private System.Windows.Forms.TextBox txt_Update_Mesg;
        private System.Windows.Forms.Button btn_General_Save;
        private System.Windows.Forms.Button btn_General_Clear;
        private System.Windows.Forms.DataGridView grd_General_Update_Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}