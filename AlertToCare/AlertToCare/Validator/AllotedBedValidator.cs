using AlertToCare.Models;

namespace AlertToCare.Validator
{
    public class AllotedBedValidator
    {
        public bool IsDepartmentNull(string department)
        {
            return department != null;
        }
        public bool IsPatientIdIsNull(int? patientId)
        {
            return patientId.HasValue;
        }
        public bool ValidateBedAlloted(BedAllotmentModel allotedBed)
        {
            bool isDepartmentNull = IsDepartmentNull(allotedBed.Department);
            bool isPatientIdIsNull = IsPatientIdIsNull(allotedBed.PatientId);

            if (isDepartmentNull == isPatientIdIsNull == true)
                return true;
            return false;
        }
    }
}
