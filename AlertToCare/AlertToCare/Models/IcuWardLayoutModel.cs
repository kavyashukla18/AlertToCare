namespace AlertToCare.Models
{
    public class IcuWardLayoutModel
    {
        public string WardNumber { get; set; }
        public int NumberOfBed { get; set; }
        
        public int NumberOfRow { get; set; }
        public int NumberOfColumn { get; set; }
        
        public string Department { get; set; }
    }
}
