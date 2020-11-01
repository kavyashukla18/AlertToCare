using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockRepository;
using Xunit;

namespace AlertToCare.UnitTest.BusinessLogic
{
    public class IcuLayoutBusinessLogicTest
    {
        readonly MockIcuLayoutDataRepository _repo = new MockIcuLayoutDataRepository();

        [Fact]
        public void TestAddLayoutInformationSuccess()
        {
            var patientLogic = new IcuLayoutBusinessLogic(_repo);
            var objLayout = new IcuWardLayoutModel
            {
                WardNumber = "1A1",
                NumberOfBed = 10,
                Department = "cancer",
                NumberOfColumn = 2,
                NumberOfRow = 5
            };
            patientLogic.AddLayoutInformation(objLayout);
        }
        [Fact]
        public void TestAddLayoutInformationBedLessThanRowCol()
        {
            var patientLogic = new IcuLayoutBusinessLogic(_repo);
            var objLayout = new IcuWardLayoutModel
            {
                WardNumber = "1A1",
                NumberOfBed = 1,
                Department = "cancer",
                NumberOfColumn = 2,
                NumberOfRow = 5
            };
            patientLogic.AddLayoutInformation(objLayout);
        }
    }
}
