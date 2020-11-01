using AlertToCare.AutomationTesting.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace AlertToCare.AutomationTesting
{
    [TestClass]
    public class MedicalDeviceControllerIntegrationTesting
    {
        private static string url = "http://localhost:64868/MedicalDevice";

        [TestMethod]
        public void TestInsertDeviceIfDeviceIsNotInDB()
        {
            string medicalDeviceUrl = url + "/MedicalDevice";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = medicalDeviceUrl
            };
            var deviceInfo = new DeviceDataModel()
            {
                DeviceName = "BloodPressure",
                MinValue = 20,
                MaxValue = 50
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(deviceInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void TestInsertDeviceIfDeviceIsInDB()
        {
            string medicalDeviceUrl = url + "/MedicalDevice";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = medicalDeviceUrl
            };
            var deviceInfo = new DeviceDataModel()
            {
                DeviceName = "HeartMachine",
                MinValue = 20,
                MaxValue = 50
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(deviceInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual((int)restResponse.StatusCode, 500);
        }
        [TestMethod]
        public void TestInsertDeviceInvalidDataFormat()
        {
            string medicalDeviceUrl = url + "/MedicalDevice";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = medicalDeviceUrl
            };
            var deviceInfo = new DeviceDataModel()
            {
                DeviceName = "bp",
                MinValue = 70,
                MaxValue = 20
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(deviceInfo);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual((int)restResponse.StatusCode, 400);
        }

        [TestMethod]
        public void TestAlertIsGeneratedForInvalidData()
        {
            string alertUrl = url + "/Alert";
            var deviceInfo = new Dictionary<string, int>();
            deviceInfo.Add("HeartMachine", 60);
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = alertUrl
            };
            var isAlertGenerated = new MedicalStatusDataModel()
            {
                BedId = "8A3",
                MedicalDevice = deviceInfo
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(isAlertGenerated);
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.BadRequest);
        }
        [TestMethod]
        public void TestAlertIsGeneratedForValidData()
        {
            string alertUrl = url + "/Alert";
            var deviceInfo = new Dictionary<string, int>();
            deviceInfo.Add("Oxymeter", 190);
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = alertUrl
            };
            var isAlertGenerated = new MedicalStatusDataModel()
            {
                BedId = "1B1",
                MedicalDevice = deviceInfo
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(isAlertGenerated.ToJsonString());
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void TestAlertIsNotGenerated()
        {
            string alertUrl = url + "/Alert";
            var deviceInfo = new Dictionary<string, int>();
            deviceInfo.Add("device", 110);
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = alertUrl
            };
            var isAlertGenerated = new MedicalStatusDataModel()
            {
                BedId = "1A1",
                MedicalDevice = deviceInfo
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(isAlertGenerated.ToJsonString());
            IRestResponse restResponse = restClient.Post(restRequest);
            Assert.AreEqual((int)restResponse.StatusCode, 400);
        }
        [TestMethod]
        public void TestAlertOff()
        {
            string medicalDeviceUrl = url + "/Alert/";
            string bedId = "1B1";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = medicalDeviceUrl + bedId
            };
            IRestResponse restResponse = restClient.Delete(restRequest);
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
        }
    }
}
