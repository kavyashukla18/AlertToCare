using AlertToCare.AutomationTesting.Models;
using AlertToCare.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;

namespace AlertToCare.AutomationTesting
{
    [TestClass]
    public class PatientDataInegrationTestion
    {
        private static string url = "http://localhost:64868/PatientData";
        [TestMethod]
        public void TestInsertPatientValidInput()
        {
            string patientInfoUrl = url + "/PatientInfo";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = patientInfoUrl
            };
            var patientInfo = new PatientDataModel()
            {
                PatientName = "hariram",
                Email = "g@123",
                Mobile = "7773233423",
                Address = "45mss"
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(patientInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void TestInsertPatientInvalidInput()
        {
            string patientInfoUrl = url + "/PatientInfo";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = patientInfoUrl
            };
            var patientInfo = new PatientDataModel()
            {
                PatientName = "hariram",
                Email = "g@123",
                Mobile = "777323343",
                Address = "45mss"
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(patientInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.BadRequest);
        }
        [TestMethod]
        public void TestDischargePatient()
        {
            string patientInfoUrl = url + "/DischargePatient/";
            int patientId = 4;
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = patientInfoUrl + patientId
            };
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void TestAllotBedToPatientWithValidInput()
        {
            string bedAllotmentUrl = url + "/AllotBedToPatient";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = bedAllotmentUrl
            };
            var bedAllotmentInfo = new BedAllotmentModel()
            {
                PatientId = 3,
                Department = "cancer"
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(bedAllotmentInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void TestAllotBedToPatientWithInvalidInput()
        {
            string bedAllotmentUrl = url + "/AllotBedToPatient";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = bedAllotmentUrl
            };
            var bedAllotmentInfo = new BedAllotmentModel()
            {
                PatientId = null,
                Department = null
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(bedAllotmentInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.BadRequest);
        }
        [TestMethod]
        public void TestGetPatientInformationWithValidPatientId()
        {
            string patientInfoUrl = url + "/GetPatientInfo/";
            int patientId = 13;
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = patientInfoUrl + patientId
            };
            IRestResponse restResponse = restClient.Get(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void TestGetPatientInformationWithInvalidPatientId()
        {
            string patientInfoUrl = url + "/GetPatientInfo/";
            int patientId = 1;
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = patientInfoUrl + patientId
            };
            IRestResponse restResponse = restClient.Get(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
