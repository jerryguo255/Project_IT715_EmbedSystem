using System;
using System.Collections.Generic;

namespace WeatherRecordServer.Models
{
    public partial class WeatherRecords
    {
        public int Id { get; set; }
        public DateTime DateCollection { get; set; }
        public double TempOutside { get; set; }
        public double TempIndoor { get; set; }
        public double HumOutside { get; set; }
        public double HumIndoor { get; set; }
    }
}
