using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IGeoCodeService
    {
        Dictionary<int,double[]> GetGeoCodes(Dictionary<int,string> postcodes);
        double[] GetJobLocationGeoCode(string jobLocation);
    }
}
