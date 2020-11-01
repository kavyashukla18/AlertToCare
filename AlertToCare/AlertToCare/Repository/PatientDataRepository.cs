using System.Linq;
using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public class PatientDataRepository: IPatientDataRepository
    {
        private readonly DbContext _context;

        public PatientDataRepository(DbContext context)
        {
            _context = context;
        }

        public void AddPatient(PatientDataModel patient)
        {
            _context.PatientInfo.Add(patient);
            _context.SaveChanges();
        }

        public PatientDataModel FetchPatientInfoFromBedId(string bedId)
        {
            var query = (from patient in _context.PatientInfo
                join
                    bed in _context.BedInformation on
                    patient.PatientId equals bed.PatientId
                where bed.BedId == bedId
                select patient);
            var patientResult = query.FirstOrDefault();
            return patientResult;
        }

        public void RemovePatientFromBed(int patientId)
        {
            var patient = _context.BedInformation.First
                (p => p.PatientId == patientId);
            patient.PatientId = null;
            _context.SaveChanges();
        }

        public void AllotBedToPatient(BedAllotmentModel allotBed)
        {
            var bedInformation = (from wardInfo in _context.IcuWardInformation
                join
                    bedInfo in _context.BedInformation on
                    wardInfo.WardNumber equals bedInfo.WardNumber
                where bedInfo.PatientId == null &&  wardInfo.Department == allotBed.Department
                                  select bedInfo).FirstOrDefault();
            if (bedInformation != null) bedInformation.PatientId = allotBed.PatientId;
            _context.SaveChanges();

        }

        public PatientDataModel FetchPatientFromPatientId(int patientId)
        {
            var device = _context.PatientInfo.FirstOrDefault(m => m.PatientId == patientId);
            return device;
        }
        public BedInformation FetchBedInfoFromPatientId(int patientId)
        {
            var device = _context.BedInformation.FirstOrDefault(m => m.PatientId == patientId);
            return device;
        }
    }
}
