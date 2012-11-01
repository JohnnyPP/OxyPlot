// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="OxyPlot">
//   http://oxyplot.codeplex.com, license: Ms-PL
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System;
using System.Windows.Forms;
using OxyPlot;
using System.Globalization;    

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {

        private readonly LineSeries lineSeries1;

        private int i;
       
        public Form1()
        {
            InitializeComponent();

            var pm = new PlotModel("TMP102 digital temperature sensor", "Temperature data stream") 
            { 
                PlotType = PlotType.Cartesian, Background = OxyColors.White 
            };

            var linearAxisX = new LinearAxis();
            linearAxisX.Title = "Sample number";
            linearAxisX.Position = AxisPosition.Bottom;
            linearAxisX.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            linearAxisX.MajorGridlineStyle = LineStyle.Solid;
            linearAxisX.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            linearAxisX.MinorGridlineStyle = LineStyle.Solid;
            linearAxisX.Maximum = 40;
            linearAxisX.Minimum = 0;
            pm.Axes.Add(linearAxisX);

            var linearAxisY = new LinearAxis();
            linearAxisY.Title = "Temperature [°C]";
            linearAxisY.Position = AxisPosition.Left;
            linearAxisY.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            linearAxisY.MajorGridlineStyle = LineStyle.Solid;
            linearAxisY.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            linearAxisY.MinorGridlineStyle = LineStyle.Solid;
            linearAxisY.Maximum = 35;
            linearAxisY.Minimum = 15;
            pm.Axes.Add(linearAxisY);

            this.lineSeries1 = new LineSeries();
            this.lineSeries1.Color = OxyColor.FromArgb(255, 78, 154, 6);
            this.lineSeries1.MarkerFill = OxyColor.FromArgb(255, 255, 255, 255);
            this.lineSeries1.MarkerStroke = OxyColors.ForestGreen;
            this.lineSeries1.MarkerStrokeThickness = 2;
            this.lineSeries1.MarkerType = MarkerType.Square;
            this.lineSeries1.MarkerSize = 2;
            this.lineSeries1.StrokeThickness = 2;
            this.lineSeries1.DataFieldX = "Date";
            this.lineSeries1.DataFieldY = "Value";
            //this.lineSeries1.LabelFormatString = "{1}";         //prints Y value on the plot
            pm.Series.Add(this.lineSeries1);
            plot1.Model = pm;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            serialPort1.Open();
            serialPort1.DataReceived += serialPort1_DataReceived;
        }

        private void button2_Disconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string line = serialPort1.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), line);
        }


        private delegate void LineReceivedEvent(string line);

        private void LineReceived(string line)
        {
            double dTemperature, dTemperatureRound;
            try
            {
                dTemperature = double.Parse(line, CultureInfo.InvariantCulture);
                dTemperatureRound = Math.Round(dTemperature, 4);
                label1.Text = Convert.ToString(dTemperatureRound);
                this.lineSeries1.Points.Add(new DataPoint(this.i, dTemperatureRound));
                plot1.InvalidatePlot(true);
                this.i++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}