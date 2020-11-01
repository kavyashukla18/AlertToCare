using System.ComponentModel.DataAnnotations;

namespace AlertToCare.Models
{
    public class MedicalDevice
    {
        [Key]
        public string DeviceName { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
