using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.QueryObjects
{
    public class TravelTimeApiQuery
    {
        public string app_id { get; set; }
        public string app_key { get; set; }
        public double[] origin { get; set; }
        public Dictionary<string, double[]> points { get; set; }
        public string[] modes { get; set; }
        public string start_time { get; set; }
        public int travel_time { get; set; }
        public string[] properties { get; set; }
    }
}
