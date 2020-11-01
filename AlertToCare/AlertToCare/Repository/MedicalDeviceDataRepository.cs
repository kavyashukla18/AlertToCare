using System.Linq;
using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public class MedicalDeviceDataRepository: IMedicalDeviceDataRepository
    {
        private readonly DbContext _context;

        public MedicalDeviceDataRepository(DbContext context)
        {
            _context = context;
        }

        public MedicalDevice FetchMedicalDevice(string medicalDevice)
        {
            var device = _context.MedicalDevice.FirstOrDefault(m => m.DeviceName == medicalDevice);
            return device;
        }

        public void InsertMedicalDevice(MedicalDevice device)
        {
            _context.MedicalDevice.Add(device);
            _context.SaveChanges();
        }

        public void TurnOnAlert(BedOnAlert bed)
        {
            _context.BedOnAlert.Add(bed);
            _context.SaveChanges();
        }

        public BedInformation FetchBedLayoutInfo(string bedId)
        {
            var layoutInfo = _context.BedInformation.FirstOrDefault(layout => layout.BedId == bedId);
            return layoutInfo;
        }

        public void TurnOffAlert(string bedId)
        {
            _context.BedOnAlert.RemoveRange(_context.BedOnAlert.Where(bed => bed.BedId == bedId));
            _context.SaveChanges();
        }
    }
}
