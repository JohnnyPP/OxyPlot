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
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2_Disconnect = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Temperature data";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 486);
            this.Controls.Add(this.button2_Disconnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1_Connect);
            this.Controls.Add(this.plot1);
            this.Name = "Form1";
            this.Text = "OxyPlot in Windows Forms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Plot plot1;
        private System.Windows.Forms.Button button1_Connect;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button2_Disconnect;
    }
}