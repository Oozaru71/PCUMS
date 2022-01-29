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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement));
            this.label1 = new System.Windows.Forms.Label();
            this.goBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.delall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(404, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Management";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // goBack
            // 
            this.goBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("goBack.BackgroundImage")));
            this.goBack.Enabled = false;
            this.goBack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.goBack.Location = new System.Drawing.Point(35, 32);
            this.goBack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(138, 34);
            this.goBack.TabIndex = 5;
            this.goBack.Text = "Go Back";
            this.goBack.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.goBack.UseVisualStyleBackColor = true;
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(45, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Id,Username,Password,";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(43, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "0 Users Found:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(35, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 430);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // delall
            // 
            this.delall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delall.BackgroundImage")));
            this.delall.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.delall.Location = new System.Drawing.Point(933, 32);
            this.delall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delall.Name = "delall";
            this.delall.Size = new System.Drawing.Size(138, 34);
            this.delall.TabIndex = 8;
            this.delall.Text = "Delete All";
            this.delall.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.delall.UseVisualStyleBackColor = true;
            this.delall.Click += new System.EventHandler(this.delall_Click);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1121, 653);
            this.Controls.Add(this.delall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.goBack);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "UserManagement";
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button delall;
    }
}