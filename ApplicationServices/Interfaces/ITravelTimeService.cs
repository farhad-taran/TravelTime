using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.QueryObjects;

namespace ApplicationServices.Interfaces
{
    public interface ITravelTimeService
    {
        Task<string> GetTravelTime(TravelTimeQuery travelTimeQuery);
    }
}
