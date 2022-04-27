namespace PCUMS
{
    partial class Monitoring
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitoring));
            this.pRAM = new System.Diagnostics.PerformanceCounter();
            this.pCPU = new System.Diagnostics.PerformanceCounter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroProgressBarCPU = new MetroFramework.Controls.MetroProgressBar();
            this.metroProgressBarRAM = new MetroFramework.Controls.MetroProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new System.Windows.Forms.Label();
            this.metroLabel2 = new System.Windows.Forms.Label();
            this.lblCPU = new System.Windows.Forms.Label();
            this.lblRAM = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.showTemp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cLabel = new System.Windows.Forms.Label();
            this.countdown = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowTemperature = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Rules = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pRAM
            // 
            this.pRAM.CategoryName = "Memory";
            this.pRAM.CounterName = "% Committed Bytes in Use";
            // 
            // pCPU
            // 
            this.pCPU.CategoryName = "Processor Information";
            this.pCPU.CounterName = "% Processor Time";
            this.pCPU.InstanceName = "_Total";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // chart1
            // 
            this.chart1.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(146, 278);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "CPU";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "RAM";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(625, 280);
            this.chart1.TabIndex = 6;
            // 
            // metroProgressBarCPU
            // 
            this.metroProgressBarCPU.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroProgressBarCPU.Location = new System.Drawing.Point(213, 184);
            this.metroProgressBarCPU.Name = "metroProgressBarCPU";
            this.metroProgressBarCPU.Size = new System.Drawing.Size(497, 32);
            this.metroProgressBarCPU.TabIndex = 7;
            // 
            // metroProgressBarRAM
            // 
            this.metroProgressBarRAM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroProgressBarRAM.Location = new System.Drawing.Point(213, 240);
            this.metroProgressBarRAM.Name = "metroProgressBarRAM";
            this.metroProgressBarRAM.Size = new System.Drawing.Size(497, 32);
            this.metroProgressBarRAM.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::PCUMS.Properties.Resources.log_out;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(6, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 38);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.metroLabel1.Location = new System.Drawing.Point(143, 184);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(53, 20);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "CPU:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.metroLabel2.Location = new System.Drawing.Point(143, 240);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(55, 20);
            this.metroLabel2.TabIndex = 17;
            this.metroLabel2.Text = "RAM:";
            // 
            // lblCPU
            // 
            this.lblCPU.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCPU.AutoSize = true;
            this.lblCPU.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCPU.Location = new System.Drawing.Point(734, 184);
            this.lblCPU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(38, 20);
            this.lblCPU.TabIndex = 18;
            this.lblCPU.Text = "0%";
            // 
            // lblRAM
            // 
            this.lblRAM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRAM.AutoSize = true;
            this.lblRAM.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblRAM.Location = new System.Drawing.Point(734, 240);
            this.lblRAM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRAM.Name = "lblRAM";
            this.lblRAM.Size = new System.Drawing.Size(38, 20);
            this.lblRAM.TabIndex = 19;
            this.lblRAM.Text = "0%";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(143, 573);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "CPU Temperature:";
            // 
            // showTemp
            // 
            this.showTemp.AutoSize = true;
            this.showTemp.Location = new System.Drawing.Point(603, 439);
            this.showTemp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.showTemp.Name = "showTemp";
            this.showTemp.Size = new System.Drawing.Size(0, 13);
            this.showTemp.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cLabel);
            this.panel1.Controls.Add(this.countdown);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblCPU);
            this.panel1.Controls.Add(this.lblRAM);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ShowTemperature);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Controls.Add(this.metroLabel2);
            this.panel1.Controls.Add(this.Rules);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.metroProgressBarCPU);
            this.panel1.Controls.Add(this.metroProgressBarRAM);
            this.panel1.Location = new System.Drawing.Point(13, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 654);
            this.panel1.TabIndex = 36;
            // 
            // cLabel
            // 
            this.cLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cLabel.AutoSize = true;
            this.cLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cLabel.Location = new System.Drawing.Point(640, 573);
            this.cLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cLabel.Name = "cLabel";
            this.cLabel.Size = new System.Drawing.Size(252, 20);
            this.cLabel.TabIndex = 42;
            this.cLabel.Text = "Time before session ends:";
            // 
            // countdown
            // 
            this.countdown.AutoSize = true;
            this.countdown.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.countdown.Location = new System.Drawing.Point(676, 603);
            this.countdown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.countdown.Name = "countdown";
            this.countdown.Size = new System.Drawing.Size(80, 20);
            this.countdown.TabIndex = 41;
            this.countdown.Text = "0:00:00";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Log out";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(2, 269);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Rules";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1, 187);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PCUMS.Properties.Resources.PCUMS;
            this.pictureBox1.Location = new System.Drawing.Point(202, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // ShowTemperature
            // 
            this.ShowTemperature.AutoSize = true;
            this.ShowTemperature.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ShowTemperature.Location = new System.Drawing.Point(143, 606);
            this.ShowTemperature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ShowTemperature.Name = "ShowTemperature";
            this.ShowTemperature.Size = new System.Drawing.Size(124, 20);
            this.ShowTemperature.TabIndex = 0;
            this.ShowTemperature.Text = "Temperature";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(5, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 39);
            this.button2.TabIndex = 15;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Rules
            // 
            this.Rules.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Rules.BackColor = System.Drawing.Color.White;
            this.Rules.BackgroundImage = global::PCUMS.Properties.Resources.rules;
            this.Rules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Rules.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Rules.Location = new System.Drawing.Point(5, 297);
            this.Rules.Name = "Rules";
            this.Rules.Size = new System.Drawing.Size(40, 41);
            this.Rules.TabIndex = 14;
            this.Rules.UseVisualStyleBackColor = false;
            this.Rules.Click += new System.EventHandler(this.Rules_Click);
            // 
            // Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 697);
            this.Controls.Add(this.showTemp);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Monitoring";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Resizable = false;
            this.Text = "RAM && CPU";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter pRAM;
        private System.Diagnostics.PerformanceCounter pCPU;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarCPU;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarRAM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Rules;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label metroLabel1;
        private System.Windows.Forms.Label metroLabel2;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Label lblRAM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label showTemp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ShowTemperature;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label countdown;
        private System.Windows.Forms.Label cLabel;
    }
}

