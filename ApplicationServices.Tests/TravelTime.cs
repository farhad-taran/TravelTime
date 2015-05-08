using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            travelTimeQuery.JobLocation = "";
        }

        public void AndGivenTravelTimeQueryHasCandidatePostCodes()
        {
            travelTimeQuery.CandidatePostCodes = new List<string>() { "", "" };
        }

        public void AndGivenTravelTimeStartTimeJourneyIsNotInThePast()
        {
            travelTimeQuery.JourneyStartTime = new TimeSpan();
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
        public TravelTimeDto GetTravelTime(TravelTimeQuery travelTimeQuery)
        {
            return new TravelTimeDto();
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
