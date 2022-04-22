namespace PCUMS
{
    partial class UserManagement
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.delall = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.goBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.SaveChanges);
            this.panel2.Controls.Add(this.delall);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.goBack);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1218, 861);
            this.panel2.TabIndex = 19;
            // 
            // SaveChanges
            // 
            this.SaveChanges.BackColor = System.Drawing.Color.White;
            this.SaveChanges.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.SaveChanges.ForeColor = System.Drawing.Color.Black;
            this.SaveChanges.Location = new System.Drawing.Point(970, 805);
            this.SaveChanges.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(218, 47);
            this.SaveChanges.TabIndex = 16;
            this.SaveChanges.Text = "Save Changes";
            this.SaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.SaveChanges.UseVisualStyleBackColor = false;
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click_1);
            // 
            // delall
            // 
            this.delall.BackColor = System.Drawing.Color.White;
            this.delall.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.delall.ForeColor = System.Drawing.Color.Black;
            this.delall.Location = new System.Drawing.Point(1002, 134);
            this.delall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delall.Name = "delall";
            this.delall.Size = new System.Drawing.Size(186, 47);
            this.delall.TabIndex = 15;
            this.delall.Text = "Delete All";
            this.delall.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.delall.UseVisualStyleBackColor = false;
            this.delall.Click += new System.EventHandler(this.delall_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(37, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(321, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Id,Username,Password,";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(35, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "0 Users Found:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(27, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 599);
            this.panel1.TabIndex = 14;
            // 
            // goBack
            // 
            this.goBack.BackColor = System.Drawing.Color.White;
            this.goBack.Enabled = false;
            this.goBack.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.goBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.goBack.Location = new System.Drawing.Point(27, 19);
            this.goBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(151, 46);
            this.goBack.TabIndex = 12;
            this.goBack.Text = "Go Back";
            this.goBack.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.goBack.UseVisualStyleBackColor = false;
            this.goBack.Click += new System.EventHandler(this.goBack_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(455, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "User Management";
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1242, 879);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "UserManagement";
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.Button delall;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button goBack;
        private System.Windows.Forms.Label label1;
    }
}