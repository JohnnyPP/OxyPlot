using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OxyPlot;

namespace WindowsFormsDemo
{
    class PlotVariables
    {

        public static PlotModel pm = new PlotModel("Texas Instruments TMP102 digital temperature sensor")
        {
            PlotType = PlotType.Cartesian,
            Background = OxyColors.White
        };

        public static LinearAxis linearAxisX = new LinearAxis();
        public static LinearAxis linearAxisXTop = new LinearAxis();
        public static LinearAxis linearAxisY = new LinearAxis();
        public static AreaSeries areaSeries1 = new AreaSeries();

        //public static LineSeries lineSeries1 = new LineSeries();
        
    }


}
