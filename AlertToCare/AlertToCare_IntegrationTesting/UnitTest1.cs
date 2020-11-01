using AlertToCare.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace AlertToCare_IntegrationTesting
{
    [TestClass]
    public class UnitTest1
    {
        private static string url = "http://localhost:64868/IcuLayout";

        [TestMethod]
        public void IfWardInfoIsNotThereInsertIcuWardInfo()
        {
            string icuLayoutUrl = url + "IcuWardInfo";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = icuLayoutUrl
            };
            var insertWardInfo = new IcuWardLayoutModel()
            {
                WardNumber = "1B",
                NumberOfBed = 30,
                NumberOfRow = 2,
                NumberOfColumn = 15,
                Department = "cardiac"

            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(insertWardInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            NUnit.Framework.Assert.AreEqual(restResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Console.WriteLine(restResponse.StatusCode);
            Console.ReadLine();
        }
    }
}
