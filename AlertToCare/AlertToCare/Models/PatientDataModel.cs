using System.ComponentModel.DataAnnotations;

namespace AlertToCare.Models
{
    public class PatientDataModel
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
