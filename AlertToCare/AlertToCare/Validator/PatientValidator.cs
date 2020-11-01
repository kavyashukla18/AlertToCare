using AlertToCare.Models;
using AlertToCare.Utility;

namespace AlertToCare.Validator
{
    public static class PatientValidator
    {   
        internal static bool ValidatePatient(PatientDataModel patient)
        {
            if (Utils.IsValueNull(patient.PatientName) == Utils.IsValueNull(patient.Email) ==
                Utils.IsValueNull(patient.Mobile) == Utils.IsLengthValid(patient.Mobile, 10) == false )
            {
                return true;
            }
            return false;
        }
    }
}