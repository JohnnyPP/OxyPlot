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
using MathNet.Numerics.Statistics;
using System.IO;

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {

        private readonly LineSeries lineSeries1, lineSeries2Mean, lineSeries3Median;

        private int i;

        private List<double> listdTemperature = new List<double>();
       
        public Form1()
        {
            InitializeComponent();
            button2_Disconnect.Enabled = false;
            checkBox2MedianChart.Checked = true;
            textBox1Delay.Text = "1000";                            //microcontroller default sampling interval 1000 ms



            PlotVariables.linearAxisX.Title = "Sample number";
            PlotVariables.linearAxisX.Position = AxisPosition.Bottom;
            PlotVariables.linearAxisX.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            PlotVariables.linearAxisX.MajorGridlineStyle = LineStyle.Solid;
            PlotVariables.linearAxisX.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            PlotVariables.linearAxisX.MinorGridlineStyle = LineStyle.Solid;
            PlotVariables.linearAxisX.Maximum = 40;
            PlotVariables.linearAxisX.Minimum = 0;
            //PlotVariables.linearAxisX.IsZoomEnabled = false;
            //PlotVariables.linearAxisX.IsPanEnabled = false;

            PlotVariables.pm.Axes.Add(PlotVariables.linearAxisX);

           
            PlotVariables.linearAxisY.Title = "Temperature [°C]";
            PlotVariables.linearAxisY.Position = AxisPosition.Left;
            PlotVariables.linearAxisY.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            PlotVariables.linearAxisY.MajorGridlineStyle = LineStyle.Solid;
            PlotVariables.linearAxisY.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            PlotVariables.linearAxisY.MinorGridlineStyle = LineStyle.Solid;
            PlotVariables.linearAxisY.Maximum = 35;
            PlotVariables.linearAxisY.Minimum = 15;
            //PlotVariables.linearAxisY.IsZoomEnabled = false;
            //PlotVariables.linearAxisY.IsPanEnabled = false;

            PlotVariables.pm.Axes.Add(PlotVariables.linearAxisY);

            PlotVariables.areaSeries1.DataFieldX2 = "Sample number";
            PlotVariables.areaSeries1.DataFieldY2 = "3*Standard deviation-Current temperature";
            PlotVariables.areaSeries1.Fill = OxyColors.LightBlue;
            PlotVariables.areaSeries1.Color = OxyColors.Red;
            PlotVariables.areaSeries1.StrokeThickness = 0;
            PlotVariables.areaSeries1.DataFieldX = "Sample number";
            PlotVariables.areaSeries1.DataFieldY = "3*Standard deviation+Current temperature";
            PlotVariables.areaSeries1.Title = "± 3*\u03C3 area";                                //http://www.fileformat.info/info/unicode/char/03c3/index.htm
            
            PlotVariables.pm.Series.Add(PlotVariables.areaSeries1);


            //temperature
            this.lineSeries1 = new LineSeries();
            this.lineSeries1.Color = OxyColor.FromArgb(255, 78, 154, 6);
            this.lineSeries1.MarkerFill = OxyColor.FromArgb(255, 255, 255, 255);
            this.lineSeries1.MarkerStroke = OxyColors.ForestGreen;
            this.lineSeries1.MarkerStrokeThickness = 2;
            this.lineSeries1.MarkerType = MarkerType.Square;
            this.lineSeries1.MarkerSize = 2;
            this.lineSeries1.StrokeThickness = 2;
            this.lineSeries1.DataFieldX = "Sample";
            this.lineSeries1.DataFieldY = "Value";
            this.lineSeries1.Title = "Current temperature";
            PlotVariables.pm.Series.Add(this.lineSeries1);

            //mean
            this.lineSeries2Mean = new LineSeries();
            this.lineSeries2Mean.Color = OxyColor.FromArgb(255, 255, 0, 0);
            this.lineSeries2Mean.MarkerFill = OxyColor.FromArgb(255, 255, 255, 255);
            this.lineSeries2Mean.MarkerStroke = OxyColors.ForestGreen;
            this.lineSeries2Mean.MarkerStrokeThickness = 2;
            this.lineSeries2Mean.MarkerType = MarkerType.None;
            this.lineSeries2Mean.MarkerSize = 1;
            this.lineSeries2Mean.StrokeThickness = 1;
            this.lineSeries2Mean.DataFieldX = "Sample";
            this.lineSeries2Mean.DataFieldY = "Value";
            this.lineSeries2Mean.Title = "Mean temperature";
            PlotVariables.pm.Series.Add(this.lineSeries2Mean);

            //median
            this.lineSeries3Median = new LineSeries();
            this.lineSeries3Median.Color = OxyColor.FromArgb(255, 0, 0, 255);
            this.lineSeries3Median.MarkerFill = OxyColor.FromArgb(255, 255, 255, 255);
            this.lineSeries3Median.MarkerStroke = OxyColors.ForestGreen;
            this.lineSeries3Median.MarkerStrokeThickness = 2;
            this.lineSeries3Median.MarkerType = MarkerType.None;
            this.lineSeries3Median.MarkerSize = 1;
            this.lineSeries3Median.StrokeThickness = 1;
            this.lineSeries3Median.DataFieldX = "Sample";
            this.lineSeries3Median.DataFieldY = "Value";
            this.lineSeries3Median.Title = "Median temperature";
            PlotVariables.pm.Series.Add(this.lineSeries3Median);

            plot1.Model = PlotVariables.pm;
        
        }



        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            serialPort1.Open();
            serialPort1.DataReceived += serialPort1_DataReceived;

            if (serialPort1.IsOpen)
            {
                button1_Connect.Enabled = false;
                button2_Disconnect.Enabled = true;
            }
        }

        private void button2_Disconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                button1_Connect.Enabled = true;
                button2_Disconnect.Enabled = false;
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
            double dTemperature, dTemperatureRound, dTemperatureMean;
            try
            {
                dTemperature = double.Parse(line, CultureInfo.InvariantCulture);
                dTemperatureRound = Math.Round(dTemperature, 4);
               
                listdTemperature.Add(dTemperatureRound);
                DescriptiveStatistics descrStat = new DescriptiveStatistics(listdTemperature);
                double dKurtosis = descrStat.Kurtosis;
                double dSkewness = descrStat.Skewness;
                dTemperatureMean = Math.Round(listdTemperature.Mean(), 4);


                if (dTemperatureRound == dTemperatureMean)
                {
                    label1Temperature.Text = "Temperature: " + String.Format("{0:0.0000}", dTemperature) + " [°C] ▸";
                }

                if (dTemperatureRound < dTemperatureMean)
                {
                    label1Temperature.Text = "Temperature: " + String.Format("{0:0.0000}", dTemperature) + " [°C] ▾";
                }

                if (dTemperatureRound > dTemperatureMean)
                {
                    label1Temperature.Text = "Temperature: " + String.Format("{0:0.0000}", dTemperature) + " [°C] ▴";
                }


                label2TempStats.Text =
                    "Mean: " + String.Format("{0:0.0000}", dTemperatureMean) + " [°C]" + Environment.NewLine +
                    "Median: " + String.Format("{0:0.0000}", listdTemperature.Median()) + " [°C]" + Environment.NewLine +
                    "Standard deviation: " + String.Format("{0:0.0000}", listdTemperature.StandardDeviation()) + " [°C]" + Environment.NewLine +
                    "3x Standard deviation: " + String.Format("{0:0.0000}", 3*listdTemperature.StandardDeviation()) + " [°C]" + Environment.NewLine +
                    "Max: " + String.Format("{0:0.0000}", listdTemperature.Max()) + " [°C]" + Environment.NewLine +
                    "Min: " + String.Format("{0:0.0000}", listdTemperature.Min()) + " [°C]" + Environment.NewLine +
                    "Kurtosis: " + String.Format("{0:0.0000}", descrStat.Kurtosis) + "\r\n" +
                    "Skewness: " + String.Format("{0:0.0000}", descrStat.Skewness) + "\r\n" +
                    "Sample number: " + Convert.ToString(i);

                //PlotVariables.linearAxisX.AbsoluteMaximum = this.i;
                PlotVariables.linearAxisX.AbsoluteMinimum = -0.1;
                //PlotVariables.linearAxisX.AxisChanged += xAxisDateTime_AxisChanged;

                PlotVariables.linearAxisY.AbsoluteMaximum = listdTemperature.Max()+0.5;
                PlotVariables.linearAxisY.AbsoluteMinimum = listdTemperature.Min()-0.5;

                PlotVariables.areaSeries1.Points.Add(new DataPoint(this.i, dTemperatureRound + (3 * listdTemperature.StandardDeviation())));
                PlotVariables.areaSeries1.Points2.Add(new DataPoint(this.i, dTemperatureRound - (3 * listdTemperature.StandardDeviation())));

                //PlotVariables.areaSeries1.Points.Add(new DataPoint(this.i, dTemperatureMean + (3 * listdTemperature.StandardDeviation())));
                //PlotVariables.areaSeries1.Points2.Add(new DataPoint(this.i, dTemperatureMean - (3 * listdTemperature.StandardDeviation())));

                if (checkBox2MedianChart.Checked)
                {
                    //this.lineSeries3Median.Title = "Median temperature";
                    this.lineSeries3Median.Points.Add(new DataPoint(this.i, listdTemperature.Median()));
                    plot1.RefreshPlot(true);
                }




                this.lineSeries2Mean.Points.Add(new DataPoint(this.i, dTemperatureMean));
                this.lineSeries1.Points.Add(new DataPoint(this.i, dTemperatureRound));
                plot1.InvalidatePlot(false);
                //plot1.RefreshPlot(true);
               


                if (checkBox1Save.Checked)
                {
                    TextWriter file = new StreamWriter("c:\\TemperatureLogger.txt", true);
                    // write a line of text to the file
                    file.WriteLine(DateTime.Now + " Sample: " + Convert.ToString(i) +
                    " Temperature: " + String.Format("{0:0.0000}", dTemperature) + " [C]" +
                    " Mean: " + String.Format("{0:0.0000}", dTemperatureMean) + " [C]" +
                    " Standard deviation: " + String.Format("{0:0.0000}", listdTemperature.StandardDeviation()) + " [C]");
                    // close the stream
                    file.Close();
                }
                
                
                
                this.i++;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            
        }

        private void textBox1Delay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    serialPort1.WriteLine(textBox1Delay.Text + "#");              //microcontroller reads serial port until '#' comes up and serial data is avaible
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        void xAxisDateTime_AxisChanged(object sender, AxisChangedEventArgs e)
        {

            //PlotVariables.linearAxisY.Zoom(listdTemperature.Min(), listdTemperature.Max());
            //plot1.RefreshPlot(true);
        }
    }
}