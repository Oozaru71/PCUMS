
namespace PCUMS
{
    partial class Login1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.passWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.save1 = new System.Windows.Forms.Button();
            this.Continue = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.createS = new System.Windows.Forms.Button();
            this.numTemp = new System.Windows.Forms.NumericUpDown();
            this.numCPU = new System.Windows.Forms.NumericUpDown();
            this.numSess = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSess)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to PC-UMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hello Administrator, let us get started.";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(107, 237);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 20);
            this.userName.TabIndex = 3;
            // 
            // passWord
            // 
            this.passWord.Location = new System.Drawing.Point(107, 294);
            this.passWord.Name = "passWord";
            this.passWord.PasswordChar = '*';
            this.passWord.Size = new System.Drawing.Size(100, 20);
            this.passWord.TabIndex = 4;
            this.passWord.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Credentials";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(501, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Session Rules";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(415, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Temperature Cap:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(415, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "CPU Cap:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(415, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Session Time:";
            // 
            // save1
            // 
            this.save1.Location = new System.Drawing.Point(67, 337);
            this.save1.Name = "save1";
            this.save1.Size = new System.Drawing.Size(75, 23);
            this.save1.TabIndex = 15;
            this.save1.Text = "Save";
            this.save1.UseVisualStyleBackColor = true;
            this.save1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(305, 365);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(143, 58);
            this.Continue.TabIndex = 16;
            this.Continue.Text = "Begin Session";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(631, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "degrees F (higher than 50).";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(631, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "% (higher than 60).";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(631, 314);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "hrs (higher than 0).";
            // 
            // createS
            // 
            this.createS.Location = new System.Drawing.Point(535, 337);
            this.createS.Name = "createS";
            this.createS.Size = new System.Drawing.Size(75, 23);
            this.createS.TabIndex = 21;
            this.createS.Text = "Set Rules";
            this.createS.UseVisualStyleBackColor = true;
            this.createS.Click += new System.EventHandler(this.createS_Click);
            // 
            // numTemp
            // 
            this.numTemp.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTemp.Location = new System.Drawing.Point(525, 235);
            this.numTemp.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTemp.Name = "numTemp";
            this.numTemp.Size = new System.Drawing.Size(100, 20);
            this.numTemp.TabIndex = 22;
            this.numTemp.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numCPU
            // 
            this.numCPU.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numCPU.Location = new System.Drawing.Point(525, 272);
            this.numCPU.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numCPU.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numCPU.Name = "numCPU";
            this.numCPU.Size = new System.Drawing.Size(100, 20);
            this.numCPU.TabIndex = 23;
            this.numCPU.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numSess
            // 
            this.numSess.Location = new System.Drawing.Point(525, 307);
            this.numSess.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSess.Name = "numSess";
            this.numSess.Size = new System.Drawing.Size(100, 20);
            this.numSess.TabIndex = 24;
            this.numSess.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Login1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numSess);
            this.Controls.Add(this.numCPU);
            this.Controls.Add(this.numTemp);
            this.Controls.Add(this.createS);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.save1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passWord);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login1";
            this.Text = "Login1";
            ((System.ComponentModel.ISupportInitialize)(this.numTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox passWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button save1;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button createS;
        private System.Windows.Forms.NumericUpDown numTemp;
        private System.Windows.Forms.NumericUpDown numCPU;
        private System.Windows.Forms.NumericUpDown numSess;
    }
}