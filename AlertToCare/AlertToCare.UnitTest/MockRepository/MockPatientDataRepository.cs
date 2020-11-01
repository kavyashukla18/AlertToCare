using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockPatientDataRepository: IPatientDataRepository
    {
        public void AddPatient(PatientDataModel patient)
        {

        }

        public PatientDataModel FetchPatientInfoFromBedId(string bedId)
        {
            var patient = new PatientDataModel();
            return patient;
        }

        public void RemovePatientFromBed(int patientId)
        {

        }

        public void AllotBedToPatient(BedAllotmentModel allotBed)
        {

        }

        public PatientDataModel FetchPatientFromPatientId(int patientId)
        {
            return new PatientDataModel();
        }

        public BedInformation FetchBedInfoFromPatientId(int patientId)
        {
            return new BedInformation();
        }
    }
}
