using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlertToCare.Models
{
    public class BedInformation
    {
        [Key]
        public string BedId { get; set; }
        public string WardNumber { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public int BedInRow { get; set; }
        public int BedInColumn { get; set; }
    }
}
