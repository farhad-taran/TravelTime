using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApplicationServices.Dtos;
using ApplicationServices.QueryMapper;
using ApplicationServices.QueryObjects;
using ApplicationServices.Services;
using NUnit.Framework;
using TestStack.BDDfy;

namespace ApplicationServices.Tests
{
    [TestFixture]
    public class TravelTime
    {
        TravelTimeQuery travelTimeQuery = new TravelTimeQuery();
        Task<string> travelTimeJson;
        private TravelTimeService travelTimeService = new TravelTimeService(new GeoCodeService(new HttpClient()), new HttpClient(), new TravelTimeApiQueryMapper());

        //[SetUp]
        //public void setUp()
        //{
        //    var fakeResponseHandler = new FakeResponseHandler();
        //    var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
        //    responseMessage.Content = new StringContent(@"{}");
        //    fakeResponseHandler.AddFakeResponse(new Uri("http://api.traveltimeapp.com/v2/time_filter"), responseMessage);
        //    var httpClient = new HttpClient(fakeResponseHandler);
        //    travelTimeService = new TravelTimeService(new GeoCodeService(), new AppSettingsService(),  httpClient);
        //}

        public void GivenTravelTimeQueryHasAJobLoaction()
        {
            travelTimeQuery.JobLocation = "W3 8pe";
        }

        public void AndGivenTravelTimeQueryHasValidCandidatePostCodes()
        {
            travelTimeQuery.CandidatePostCodes = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1,"wc2b5lx"),
                new KeyValuePair<int, string>(5,"e32qh"),
                new KeyValuePair<int, string>(4,"sw1w8el"),
                new KeyValuePair<int, string>(3,"ec2m5up"),
                new KeyValuePair<int, string>(2,"sg138eb")
            };
        }

        public void WhenTravelTimeQueryIsProcessedByTravelTimeService()
        {
            travelTimeJson = travelTimeService.GetTravelTime(travelTimeQuery);
        }

        public void ThenTravelTimeResultsShouldBeReturned()
        {
            Assert.IsNotNull(travelTimeJson.Result);
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }

   }
