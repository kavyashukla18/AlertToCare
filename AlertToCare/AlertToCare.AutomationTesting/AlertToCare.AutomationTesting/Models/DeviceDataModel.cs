using System.ComponentModel.DataAnnotations;

namespace AlertToCare.AutomationTesting.Models
{
    public class DeviceDataModel
    {
        [Key]
        public string DeviceName { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
