using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherRecordServer.Models
{
    public class HomeViewModel
    {

        public HomeViewModel(int daynum)
        {
            DateTime now = DateTime.Now;
            days = new DateTime[daynum];
            for (int i = 0; i < daynum; i++)
            {
                days[i] = now.AddDays(-(i + 1));// init date array for past {daynum} days
            }
            daysAvgOutSideTemp = new double[days.Length];
            daysAvgInDoorTemp = new double[days.Length];
            daysAvgOutSideHum = new double[days.Length];
            daysAvgInDoorHum = new double[days.Length];
        }
        public DateTime [] days{ get; set; }
        public double [] daysAvgOutSideTemp { get; set; }
        public double[] daysAvgInDoorTemp { get; set; }
        public double[] daysAvgOutSideHum { get; set; }

        public double[] daysAvgInDoorHum { get; set; }

    }
}
