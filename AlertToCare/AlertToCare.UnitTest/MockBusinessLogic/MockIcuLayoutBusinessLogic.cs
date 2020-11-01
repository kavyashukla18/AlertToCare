using System;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockIcuLayoutBusinessLogic: IIcuLayoutBusinessLogic
    {
        public void AddLayoutInformation(IcuWardLayoutModel objLayout)
        {
            if(objLayout.Department == "radonc")
                throw new Exception("");
        }
    }
}
