using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public interface IMedicalDeviceDataRepository
    {
        public MedicalDevice FetchMedicalDevice(string deviceName);
        public void InsertMedicalDevice(MedicalDevice medicalDevice);
        public void TurnOnAlert(BedOnAlert bed);
        BedInformation FetchBedLayoutInfo(string bedId);
        void TurnOffAlert(string bedId);
    }
}
