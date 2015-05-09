using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IGeoCodeService
    {
        Task<Dictionary<int,double[]>> GetPostCodesGeoCodes(List<KeyValuePair<int,string>> postcodes);
        double[] GetJobLocationGeoCode(string jobLocation);
    }
}
