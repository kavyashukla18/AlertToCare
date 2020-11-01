using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockMedicalDeviceDataRepository: IMedicalDeviceDataRepository
    {
        public MedicalDevice FetchMedicalDevice(string deviceName)
        {
            if (deviceName != "Oxymeter")
                return null;
            var device = new MedicalDevice {DeviceName = "Oxymeter", MaxValue = 60, MinValue = 20};
            return device;
        }

        public void InsertMedicalDevice(MedicalDevice medicalDevice)
        {
            
        }

        public void TurnOnAlert(BedOnAlert bed)
        {
            
        }

        public BedInformation FetchBedLayoutInfo(string bedId)
        {
            var bedInfo = new BedInformation
            {
                BedId = "1A1",
                WardNumber = "1A",
                PatientId = 10,
                BedInRow = 2,
                BedInColumn = 2
            };
            return bedInfo;
        }

        public void TurnOffAlert(string bedId)
        {
            
        }
    }
}
