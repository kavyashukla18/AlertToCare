using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlertToCare.Models
{
    public class BedOnAlert
    {
        [Key]
        public string BedId { get; set; }
        [ForeignKey("DeviceName")]
        public string DeviceName { get; set; }
        public int Value { get; set; }
    }
}
