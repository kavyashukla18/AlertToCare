using AlertToCare.UnitTest.MockRepository;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using Xunit;

namespace AlertToCare.UnitTest.BussinessLogic
{
    
    public class PatientBusinessLogicTest
    {
        readonly MockPatientDataRepository _repo = new MockPatientDataRepository();

        [Fact]
        public void TestInsertPatientSuccessful()
        {
            var patient = new PatientDataModel();
            var patientLogic = new PatientBusinessLogic(_repo);
            patientLogic.InsertPatient(patient);
        }
        [Fact]
        public void TestFetchPatientInfoFromBedId()
        {
            var patientLogic = new PatientBusinessLogic(_repo);
            patientLogic.FetchPatientInfoFromBedId("1A1");
        }

        [Fact]
        public void TestFreeTheBed()
        {
            var patientLogic = new PatientBusinessLogic(_repo);
            patientLogic.FreeTheBed(1);
        }
        [Fact]
        public void TestAllotBedToPatient()
        {
            var patientLogic = new PatientBusinessLogic(_repo);
            var bed = new BedAllotmentModel();
            var response = patientLogic.AllotBedToPatient(bed);
            Assert.NotNull(response);
        }
    }
}
