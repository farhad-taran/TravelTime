using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.BDDfy;

namespace ApplicationServices.Tests
{
    [TestFixture]
    public class TravelTime
    {
        TravelTimeQuery travelTimeQuery = new TravelTimeQuery();
        TravelTimeDto travelTimeDto;
        private TravelTimeService travelTimeService = new TravelTimeService();

        public void GivenTravelTimeQueryHasAJobLoaction()
        {
            travelTimeQuery.JobLocation = "W3 8pe";
        }

        public void AndGivenTravelTimeQueryHasValidCandidatePostCodes()
        {
            travelTimeQuery.CandidatePostCodes = new List<string>() { "w3 8pe", "w3 8pe" };
        }

        public void WhenTravelTimeQueryIsProcessedByTravelTimeService()
        {
            travelTimeDto = travelTimeService.GetTravelTime(travelTimeQuery);
        }

        public void ThenTravelTimeResultsShouldBeReturned()
        {
            Assert.IsNotNull(travelTimeDto);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }

    internal class TravelTimeService
    {
        Regex postCodeRegex =
                new Regex(
                    @"^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$");

        public class TravelTimeApiQuery
        {
            public string app_id { get; set; }
            public string app_key { get; set; }
            public int travel_time { get; set; }
            public double[] origin { get; set; }
            public double points { get; set; }
            public string[] modes { get; set; }
            public DateTime start_time { get; set; }
            public string[] properties { get; set; }
        }

        public TravelTimeDto GetTravelTime(TravelTimeQuery travelTimeQuery)
        {
            TravelTimeApiQuery apiQuery = new TravelTimeApiQuery();
            apiQuery.origin = GetJobLocationPoint(travelTimeQuery.JobLocation);
            apiQuery.points = GetCandidatePoints(travelTimeQuery.CandidatePostCodes);
        }

        private double GetCandidatePoints(List<string> candidatePostCodes)
        {
            var validPostcodes = candidatePostCodes.Where(x => postCodeRegex.IsMatch(x));
        }

        private double[] GetJobLocationPoint(string jobLocation)
        {
            return new double[]{51.50511021989938,-0.2666956743415083};
        }
    }

    internal class TravelTimeDto
    {
    }

    internal class TravelTimeQuery
    {
        public string JobLocation { get; set; }
        public List<string> CandidatePostCodes { get; set; }
        public TimeSpan JourneyStartTime { get; set; }
    }
}
