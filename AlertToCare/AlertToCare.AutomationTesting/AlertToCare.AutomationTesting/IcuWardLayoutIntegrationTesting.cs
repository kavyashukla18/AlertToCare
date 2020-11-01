using AlertToCare.AutomationTesting.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;

namespace AlertToCare.AutomationTesting
{
    [TestClass]
    public class IcuWardLayoutIntegrationTesting
    {
        private static string url = "http://localhost:64868/IcuLayout";

        [TestMethod]
        public void IfWardInfoIsNotThereInsertIcuWardInfo()
        {
            string icuLayoutUrl = url + "/IcuWardInfo";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = icuLayoutUrl
            };
            var insertWardInfo = new IcuWardLayoutModel()
            {
                WardNumber = "4E",
                NumberOfBed = 30,
                NumberOfRow = 2,
                NumberOfColumn = 15,
                Department = "cardiac"

            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(insertWardInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Console.WriteLine(restResponse.StatusCode);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void IfWardInfoIsThereInsertIcuWardInfo()
        {
            string icuLayoutUrl = url + "/IcuWardInfo";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = icuLayoutUrl
            };
            var insertWardInfo = new IcuWardLayoutModel()
            {
                WardNumber = "1E",
                NumberOfBed = 30,
                NumberOfRow = 2,
                NumberOfColumn = 15,
                Department = "cardiac"

            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(insertWardInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Console.WriteLine(restResponse.StatusCode);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.InternalServerError);
        }
    }
}
