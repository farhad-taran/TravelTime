using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.QueryObjects;

namespace ApplicationServices.QueryMapper
{
    public class TravelTimeApiQueryMapper:IMapper<TravelTimeQuery,TravelTimeApiQuery>
    {
        public TravelTimeApiQuery Map(TravelTimeQuery input)
        {
            return new TravelTimeApiQuery()
            {
                app_id = "862d758e",
                app_key = "4395aeaaf774689ac064b827ab4c7a1e",
                origin = input.JobLocationPoint,
                points = input.CandidatePostCodePoints.ToDictionary(x => x.Key.ToString(), x => x.Value),
                modes = new string[] {"public_transport"},
                start_time = DateTime.Today.AddHours(9).ToString(@"yyyy-MM-ddTHH\:mm\:ss.fffffffzzz"),
                travel_time = 7200,
                properties = new string[] {"time", "distance", "distance_breakdown"}
            };
        }
    }

    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn input);
    }
}
