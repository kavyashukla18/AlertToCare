using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlertToCare.AutomationTesting.Models
{
    class MedicalStatusDataModel
    {

        public string BedId { get; set; }
        public IDictionary<string, int> MedicalDevice { get; set; }

        public string ToJsonString()
        {
            var str = new StringBuilder();
            str.Append("{");
            str.Append(" \"BedId\" : \"" + BedId + "\",");
            str.Append("\"MedicalDevice\" : {");
            var i = 0;
            var medicalDeviceArray = new string[MedicalDevice.Count];
            foreach (var medicalDevice in MedicalDevice)
            {
                medicalDeviceArray[i++] = " \"" + medicalDevice.Key+"\" : " + medicalDevice.Value ;
            }
            str.Append(string.Join(",", medicalDeviceArray));
            str.Append("}");
            str.Append("}");
            return str.ToString();
        }
    }
}
