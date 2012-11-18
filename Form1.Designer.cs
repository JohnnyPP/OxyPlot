// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.Designer.cs" company="OxyPlot">
//   http://oxyplot.codeplex.com, license: Ms-PL
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using OxyPlot.WindowsForms;

namespace WindowsFormsDemo
{
    partial class Form1
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
            this.plot1 = new OxyPlot.WindowsForms.Plot();
            this.button1_Connect = new System.Windows.Forms.Button();
            this.label2TempStats = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2_Disconnect = new System.Windows.Forms.Button();
            this.checkBox1Save = new System.Windows.Forms.CheckBox();
            this.label1Temperature = new System.Windows.Forms.Label();
            this.textBox1Delay = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2MedianChart = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plot1
            // 
            this.plot1.KeyboardPanHorizontalStep = 0.1D;
            this.plot1.KeyboardPanVerticalStep = 0.1D;
            this.plot1.Location = new System.Drawing.Point(173, 12);
            this.plot1.Margin = new System.Windows.Forms.Padding(0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(854, 465);
            this.plot1.TabIndex = 0;
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // button1_Connect
            // 
            this.button1_Connect.Location = new System.Drawing.Point(12, 12);
            this.button1_Connect.Name = "button1_Connect";
            this.button1_Connect.Size = new System.Drawing.Size(104, 23);
            this.button1_Connect.TabIndex = 1;
            this.button1_Connect.Text = "Connect sensor";
            this.button1_Connect.UseVisualStyleBackColor = true;
            this.button1_Connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2TempStats
            // 
            this.label2TempStats.AutoSize = true;
            this.label2TempStats.Location = new System.Drawing.Point(9, 131);
            this.label2TempStats.Name = "label2TempStats";
            this.label2TempStats.Size = new System.Drawing.Size(110, 13);
            this.label2TempStats.TabIndex = 2;
            this.label2TempStats.Text = "Temperature statistics";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // button2_Disconnect
            // 
            this.button2_Disconnect.Location = new System.Drawing.Point(12, 52);
            this.button2_Disconnect.Name = "button2_Disconnect";
            this.button2_Disconnect.Size = new System.Drawing.Size(104, 23);
            this.button2_Disconnect.TabIndex = 3;
            this.button2_Disconnect.Text = "Disconnect sensor";
            this.button2_Disconnect.UseVisualStyleBackColor = true;
            this.button2_Disconnect.Click += new System.EventHandler(this.button2_Disconnect_Click);
            // 
            // checkBox1Save
            // 
            this.checkBox1Save.AutoSize = true;
            this.checkBox1Save.Location = new System.Drawing.Point(12, 432);
            this.checkBox1Save.Name = "checkBox1Save";
            this.checkBox1Save.Size = new System.Drawing.Size(103, 17);
            this.checkBox1Save.TabIndex = 4;
            this.checkBox1Save.Text = "Save data to file";
            this.checkBox1Save.UseVisualStyleBackColor = true;
            // 
            // label1Temperature
            // 
            this.label1Temperature.AutoSize = true;
            this.label1Temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1Temperature.Location = new System.Drawing.Point(9, 95);
            this.label1Temperature.Name = "label1Temperature";
            this.label1Temperature.Size = new System.Drawing.Size(97, 16);
            this.label1Temperature.TabIndex = 5;
            this.label1Temperature.Text = "Temperature";
            // 
            // textBox1Delay
            // 
            this.textBox1Delay.Location = new System.Drawing.Point(6, 19);
            this.textBox1Delay.Name = "textBox1Delay";
            this.textBox1Delay.Size = new System.Drawing.Size(114, 20);
            this.textBox1Delay.TabIndex = 6;
            this.textBox1Delay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1Delay_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1Delay);
            this.groupBox1.Location = new System.Drawing.Point(12, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sampling interval [ms]";
            // 
            // checkBox2MedianChart
            // 
            this.checkBox2MedianChart.AutoSize = true;
            this.checkBox2MedianChart.Location = new System.Drawing.Point(12, 308);
            this.checkBox2MedianChart.Name = "checkBox2MedianChart";
            this.checkBox2MedianChart.Size = new System.Drawing.Size(88, 17);
            this.checkBox2MedianChart.TabIndex = 8;
            this.checkBox2MedianChart.Text = "Median chart";
            this.checkBox2MedianChart.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 486);
            this.Controls.Add(this.checkBox2MedianChart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1Temperature);
            this.Controls.Add(this.checkBox1Save);
            this.Controls.Add(this.button2_Disconnect);
            this.Controls.Add(this.label2TempStats);
            this.Controls.Add(this.button1_Connect);
            this.Controls.Add(this.plot1);
            this.Name = "Form1";
            this.Text = "OxyPlot in Windows Forms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Plot plot1;
        private System.Windows.Forms.Button button1_Connect;
        private System.Windows.Forms.Label label2TempStats;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button2_Disconnect;
        private System.Windows.Forms.CheckBox checkBox1Save;
        private System.Windows.Forms.Label label1Temperature;
        private System.Windows.Forms.TextBox textBox1Delay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2MedianChart;
    }
}