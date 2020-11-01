using System.Linq;
using AlertToCare.Models;
using AlertToCare.Repository;
using Xunit;

namespace AlertToCare.UnitTest.Repository
{
    public class PatientDataRepositoryTest: InMemoryContext
    {
        [Fact]
        public void TestAddPatientSuccessful()
        {
            var dummyPatient = new PatientDataModel
            {
                PatientName = "Patient1", 
                Address = "Address", 
                Mobile = "98989898989",
                Email = "P1@mail.com"
            };
            var patientData  = new PatientDataRepository(Context);
            patientData.AddPatient(dummyPatient);
            var patientDataInDb = Context.PatientInfo.First
                (p => p.PatientName == "Patient1");
            Assert.NotNull(patientDataInDb);
        }
        [Fact]
        public void TestFetchPatientInfoFromBedIdReturnsNullForBedIdNotExists()
        {
            var patientData = new PatientDataRepository(Context);
            var response = patientData.FetchPatientInfoFromBedId("1B1");
            Assert.Null(response);
        }
        [Fact]
        public void TestFetchPatientInfoFromBedIdReturnsBedObjectForBedIdExists()
        {
            var patientData = new PatientDataRepository(Context);
            var response = patientData.FetchPatientInfoFromBedId("1A1");
            Assert.NotNull(response);
        }

        [Fact]
        public void TestFreeTheBedRemovePatientEntry()
        {
            var patientData = new PatientDataRepository(Context);
            var bed = Context.BedInformation.First
                (p => p.PatientId == 1);
            patientData.RemovePatientFromBed(1);
            Assert.Null(bed.PatientId);
        }
        [Fact]

        public void TestAllotBedToPatientSuccessful()
        {
            var patientData = new PatientDataRepository(Context);
            var allotBed = new BedAllotmentModel {Department = "Dept", PatientId = 10};
            patientData.AllotBedToPatient(allotBed);
            var patientDataInDb = Context.BedInformation.First(bed => bed.WardNumber == "1B");
            Assert.Equal(10, patientDataInDb.PatientId);

        }
        [Fact]
        public void TestFetchPatientFromPatientIdSuccessful()
        {
            var patientData = new PatientDataRepository(Context);
            patientData.FetchPatientFromPatientId(1);
            Assert.NotNull(patientData);
        }
        
        [Fact]
        public void TestFetchBedInfoFromPatientIdSuccessful()
        {
            var patientData = new PatientDataRepository(Context);
            patientData.FetchBedInfoFromPatientId(1);
            Assert.NotNull(patientData);
        }
        
    }
}
