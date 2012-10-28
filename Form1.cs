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
        string sGlobalLine;
        double dTemperatureGlobal;

        private int i = 0;
        private DateTime dtStarttime;

        private TimeSpan tsTimespent;

        private List<double> listdTimespent = new List<double>();
        private List<double> listdTemperature = new List<double>();


        public Form1()
        {
            InitializeComponent();

            
           /*
            var pm = new PlotModel("Trigonometric functions test", "Example using the FunctionSeries")
                         {
                             PlotType = PlotType.Cartesian,
                             Background = OxyColors.White,
                             Title = "Test"
                       
                         };

            var linearAxisX = new LinearAxis();
            linearAxisX.Title = "Time [s]";
            linearAxisX.Position = AxisPosition.Bottom;
            linearAxisX.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            linearAxisX.MajorGridlineStyle = LineStyle.Solid;
            linearAxisX.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            linearAxisX.MinorGridlineStyle = LineStyle.Solid;
            pm.Axes.Add(linearAxisX);

            var linearAxisY = new LinearAxis();
            linearAxisY.Title = "Temperature [°C]";
            linearAxisY.Position = AxisPosition.Left;
            linearAxisY.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
            linearAxisY.MajorGridlineStyle = LineStyle.Solid;
            linearAxisY.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
            linearAxisY.MinorGridlineStyle = LineStyle.Solid;
            pm.Axes.Add(linearAxisY);

            var lineSeries1 = new LineSeries();

            lineSeries1.Color = OxyColor.FromArgb(255, 78, 154, 6);
            lineSeries1.MarkerFill = OxyColor.FromArgb(255, 78, 154, 6);
            lineSeries1.MarkerStroke = OxyColors.ForestGreen;
            lineSeries1.MarkerType = MarkerType.Circle;
            lineSeries1.StrokeThickness = 2;
            lineSeries1.DataFieldX = "Date";
            lineSeries1.DataFieldY = "Value";

            lineSeries1.Points.Add(new DataPoint(-8,0));
            lineSeries1.Points.Add(new DataPoint(-7.5,1));
            lineSeries1.Points.Add(new DataPoint(-7.0,-2));
            pm.Series.Add(lineSeries1);



         
            

            //pm.Series.Add(new FunctionSeries(Math.Sin, -10, 10, 0.1, "sin(x)"));
            //pm.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 0.1, "cos(x)"));
            //pm.Series.Add(new FunctionSeries(t => 5 * Math.Cos(t), t => 5 * Math.Sin(t), 0, 2 * Math.PI, 0.1, "cos(t),sin(t)"));
            plot1.Model = pm;
             */
        }

        //Observable.Interval(TimeSpan.FromSeconds(0.1)).Where( x => x < 100).Subscribe( x =>


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
            sGlobalLine = line;

        }

        private delegate void LineReceivedEvent(string line);
        private void LineReceived(string line)
        {
            double dTemperature, dTemperatureRound, dTemperatureStd;


            try
            {
                

                //DateTime dtStart = DateTime.Now;

                label1.Text = line; //receives line with point 21.45 to make it to double one needs to use
                //CultureInfo.InvariantCulture
                dTemperature = double.Parse(line, CultureInfo.InvariantCulture);
                dTemperatureRound = Math.Round(dTemperature, 4);

                label1.Text = Convert.ToString(dTemperatureRound);
                dTemperatureGlobal = dTemperatureRound;

                //chart1.Series[0].BorderWidth = 2;
                //chart1.Series[0].ChartType = SeriesChartType.Line;

                tsTimespent = DateTime.Now - dtStarttime;
                listdTimespent.Add(i);

                listdTemperature.Add(dTemperatureRound);


                var pm = new PlotModel("Trigonometric functions test", "Example using the FunctionSeries")
                {
                    PlotType = PlotType.Cartesian,
                    Background = OxyColors.White,
                    Title = "Test"

                };

                var linearAxisX = new LinearAxis();
                linearAxisX.Title = "Time [s]";
                linearAxisX.Position = AxisPosition.Bottom;
                linearAxisX.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
                linearAxisX.MajorGridlineStyle = LineStyle.Solid;
                linearAxisX.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
                linearAxisX.MinorGridlineStyle = LineStyle.Solid;
                pm.Axes.Add(linearAxisX);

                var linearAxisY = new LinearAxis();
                linearAxisY.Title = "Temperature [°C]";
                linearAxisY.Position = AxisPosition.Left;
                linearAxisY.MajorGridlineColor = OxyColor.FromArgb(40, 0, 0, 139);
                linearAxisY.MajorGridlineStyle = LineStyle.Solid;
                linearAxisY.MinorGridlineColor = OxyColor.FromArgb(20, 0, 0, 139);
                linearAxisY.MinorGridlineStyle = LineStyle.Solid;
                pm.Axes.Add(linearAxisY);

                var lineSeries1 = new LineSeries();

                lineSeries1.Color = OxyColor.FromArgb(255, 78, 154, 6);
                lineSeries1.MarkerFill = OxyColor.FromArgb(255, 78, 154, 6);
                lineSeries1.MarkerStroke = OxyColors.ForestGreen;
                lineSeries1.MarkerType = MarkerType.Circle;
                lineSeries1.StrokeThickness = 2;
                lineSeries1.DataFieldX = "Date";
                lineSeries1.DataFieldY = "Value";

                lineSeries1.Points.Add(new DataPoint(i, dTemperatureRound));
                //lineSeries1.Points.Add(new DataPoint(-7.5, 1));
               // lineSeries1.Points.Add(new DataPoint(-7.0, -2));
              
                pm.Series.Add(lineSeries1);






                //pm.Series.Add(new FunctionSeries(Math.Sin, -10, 10, 0.1, "sin(x)"));
                //pm.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 0.1, "cos(x)"));
                //pm.Series.Add(new FunctionSeries(t => 5 * Math.Cos(t), t => 5 * Math.Sin(t), 0, 2 * Math.PI, 0.1, "cos(t),sin(t)"));
                plot1.Model = pm;
             


                /*
                DescriptiveStatistics descrStat = new DescriptiveStatistics(listdTemperature);
                double dKurtosis = descrStat.Kurtosis;
                double dSkewness = descrStat.Skewness;

                dTemperatureStd = Math.Round(listdTemperature.StandardDeviation(), 4);
                label4Std.Text = Convert.ToString(dTemperatureStd);
                label5Mittel.Text = Convert.ToString(Math.Round(listdTemperature.Mean(), 4));
                label6Zentral.Text = Convert.ToString(Math.Round(listdTemperature.Median(), 4));
                label73xStd.Text = Convert.ToString(3 * dTemperatureStd);
                label9Min.Text = Convert.ToString(Math.Round(listdTemperature.Min(), 4));
                label9Max.Text = Convert.ToString(Math.Round(listdTemperature.Max(), 4));
                label11Schiefe.Text = Convert.ToString(Math.Round(dSkewness, 4));
                label11Wolbung.Text = Convert.ToString(Math.Round(dKurtosis, 4));




                chart1.Series[0].Points.AddXY(tsTimespent.TotalSeconds, dTemperatureRound);
                //chart1.Series[0].Points.AddXY(i, dTemperatureRound);

                chart1.ChartAreas["ChartArea1"].AxisX.Minimum = listdTimespent[0];
                chart1.ChartAreas["ChartArea1"].AxisY.Minimum = (listdTemperature.Min() - 0.5);
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = (listdTemperature.Max() + 0.5);
                //chart1.ChartAreas["ChartArea1"].AxisX = new Axis { LabelStyle = new LabelStyle() { Font = new Font("Verdana", 7.5f) } };
                //chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = "Verdana";

                //chart1.ChartAreas["ChartArea1"].AxisX.Title = "Zeit [s]";
                //chart1.ChartAreas["ChartArea1"].AxisY.Title = "Temparature [C]";

                DateTime time = DateTime.Now;
                //string format = "MMM ddd d HH:mm yyyy";
                string format = "yyyyMMddHHmmssffff";

                //label2.Text = time.ToString(format);

               
                */
                //comment
                i++;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}