namespace Ordermanagement_01.Employee
{
    partial class Employee_Order_Information
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
            this.lbl_Header = new System.Windows.Forms.Label();
            this.Grid_Tax = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Order_Instructions = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Statue_of_Info = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Tax)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbl_Header.Location = new System.Drawing.Point(9, 9);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(293, 31);
            this.lbl_Header.TabIndex = 95;
            this.lbl_Header.Text = "U.S State Tax Office Due Dates :";
            // 
            // Grid_Tax
            // 
            this.Grid_Tax.AllowUserToAddRows = false;
            this.Grid_Tax.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_Tax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Tax.Location = new System.Drawing.Point(12, 43);
            this.Grid_Tax.Name = "Grid_Tax";
            this.Grid_Tax.RowHeadersVisible = false;
            this.Grid_Tax.Size = new System.Drawing.Size(1206, 57);
            this.Grid_Tax.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(9, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 31);
            this.label1.TabIndex = 97;
            this.label1.Text = "Special Instructions :";
            // 
            // txt_Order_Instructions
            // 
            this.txt_Order_Instructions.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Order_Instructions.Location = new System.Drawing.Point(13, 222);
            this.txt_Order_Instructions.Multiline = true;
            this.txt_Order_Instructions.Name = "txt_Order_Instructions";
            this.txt_Order_Instructions.ReadOnly = true;
            this.txt_Order_Instructions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Order_Instructions.Size = new System.Drawing.Size(1205, 444);
            this.txt_Order_Instructions.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(8, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 31);
            this.label2.TabIndex = 99;
            this.label2.Text = "Statute of limitation for Full Search :";
            // 
            // txt_Statue_of_Info
            // 
            this.txt_Statue_of_Info.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Statue_of_Info.Location = new System.Drawing.Point(12, 138);
            this.txt_Statue_of_Info.Multiline = true;
            this.txt_Statue_of_Info.Name = "txt_Statue_of_Info";
            this.txt_Statue_of_Info.ReadOnly = true;
            this.txt_Statue_of_Info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Statue_of_Info.Size = new System.Drawing.Size(1206, 42);
            this.txt_Statue_of_Info.TabIndex = 100;
            // 
            // Employee_Order_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 678);
            this.Controls.Add(this.txt_Statue_of_Info);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Order_Instructions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Grid_Tax);
            this.Controls.Add(this.lbl_Header);
            this.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Employee_Order_Information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee_Order_Information";
            this.Load += new System.EventHandler(this.Employee_Order_Information_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Tax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.DataGridView Grid_Tax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Order_Instructions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Statue_of_Info;
    }
}