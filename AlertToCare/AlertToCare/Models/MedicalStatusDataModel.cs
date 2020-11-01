using System.Collections.Generic;

namespace AlertToCare.Models
{
    public class MedicalStatusDataModel
    {
        public string BedId { get; set; }
        public IDictionary<string, int> MedicalDevice { get; set; }
    }
}
