using System;
using System.Collections.Generic;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.BusinessLogic
{
    public class MedicalDeviceBusinessLogic : IMedicalDeviceBusinessLogic
    {
        private readonly IMedicalDeviceDataRepository _medicalDeviceDataRepository;

        public MedicalDeviceBusinessLogic(IMedicalDeviceDataRepository repo)
        {
            this._medicalDeviceDataRepository = repo;
        }
        public IEnumerable<string> Alert(MedicalStatusDataModel medicalStatus)
        {
            var alertingDevice = new List<string>();
            foreach (var medicalDevice in medicalStatus.MedicalDevice)
            {
                var values= _medicalDeviceDataRepository.FetchMedicalDevice(medicalDevice.Key);
                if (values == null)
                {
                    throw new ArgumentException("Invalid medical device");
                }
                if (IsAlert(values.MinValue,values.MaxValue, medicalDevice.Value))
                {
                    BedOnAlert bed = new BedOnAlert
                    {
                        BedId = medicalStatus.BedId, 
                        DeviceName = medicalDevice.Key, 
                        Value = medicalDevice.Value
                    };
                    TurnOnAlert(bed);
                    alertingDevice.Add(medicalDevice.Key);
                }

            }
            
            return alertingDevice;
        }

        public int[] FetchBedLayoutInfo(string statusBedId)
        {
            var layout = _medicalDeviceDataRepository.FetchBedLayoutInfo(statusBedId);
            int[] bedLayout = {layout.BedInRow, layout.BedInColumn};
            return bedLayout;
        }

        public void AlertOff(string bedId)
        {
            _medicalDeviceDataRepository.TurnOffAlert(bedId);
        }

        public void InsertDevice(MedicalDevice device)
        {
            _medicalDeviceDataRepository.InsertMedicalDevice(device);
        }

        
    

    private void TurnOnAlert(BedOnAlert bed)
        {
            try
            {
                _medicalDeviceDataRepository.TurnOnAlert(bed);
            }
            catch
            {
                // ignored
            }
        }

        private bool IsAlert(int minValue, int maxValue, int medicalDeviceValue)
        {
            if(medicalDeviceValue >maxValue || medicalDeviceValue<minValue)
                return true;
            return false;
        }
    }
}
