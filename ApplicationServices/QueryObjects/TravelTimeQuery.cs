using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.QueryObjects
{
    public class TravelTimeQuery
    {
        public string JobLocation { get; set; }
        public Dictionary<int,string> CandidatePostCodes { get; set; }
        public TimeSpan JourneyStartTime { get; set; }
    }
}
