using System;
using System.Collections.Generic;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockRepository;
using Xunit;

namespace AlertToCare.UnitTest.BussinessLogic
{
    
    public class MedicalDeviceBusinessLogicTest
    {
        readonly MockMedicalDeviceDataRepository _repo = new MockMedicalDeviceDataRepository();

        [Fact]
        public void TestInsertDevice()
        {
            var device = new MedicalDevice();
            var medicalDeviceBusinessLogic = new MedicalDeviceBusinessLogic(_repo);
            medicalDeviceBusinessLogic.InsertDevice(device);
        }

        [Fact]
        public void TestAlertInvalidMedicalDeviceThrowException()
        {
            var medicalDeviceBusinessLogic = new MedicalDeviceBusinessLogic(_repo);
            var status = new MedicalStatusDataModel
            {
                BedId = "1", MedicalDevice = new Dictionary<string, int> {{"BP", 29}}
            };

            Assert.Throws<ArgumentException>(() => medicalDeviceBusinessLogic.Alert(status));
        }
        [Fact]
        public void TestAlertIfValueInRange()
        {
            var medicalDeviceBusinessLogic = new MedicalDeviceBusinessLogic(_repo);
            var status = new MedicalStatusDataModel
            {
                BedId = "1", MedicalDevice = new Dictionary<string, int> {{"Oxymeter", 40}}
            };
            var alertingDevice = medicalDeviceBusinessLogic.Alert(status);
            Assert.Empty(alertingDevice);
        }
        [Fact]
        public void TestAlertIfValueExceedRange()
        {
            var medicalDeviceBusinessLogic = new MedicalDeviceBusinessLogic(_repo);
            var status = new MedicalStatusDataModel
            {
                BedId = "1", MedicalDevice = new Dictionary<string, int> {{"Oxymeter", 100}}
            };
            var alertingDevice = medicalDeviceBusinessLogic.Alert(status);
            Assert.NotNull(alertingDevice);
        }

        [Fact]
        public void TestFetchBedLayoutInfo()
        {
            var medicalDeviceBusinessLogic = new MedicalDeviceBusinessLogic(_repo);
            var layout = medicalDeviceBusinessLogic.FetchBedLayoutInfo("1A1");
            int[] expectedResult = {2, 2};
            Assert.Equal(expectedResult, layout);
        }

        [Fact]
        public void TestTurnOffAlert()
        {
            var medicalDeviceBusinessLogic = new MedicalDeviceBusinessLogic(_repo);
            medicalDeviceBusinessLogic.AlertOff("1Z1");
        }
    }
}
