using System.ComponentModel.DataAnnotations;

namespace AlertToCare.Models
{
    public class IcuWardInformation
    {
        [Key]
        public string WardNumber { get; set; }
        public int TotalBed { get; set; }
        public string Department { get; set; }
    }
}
