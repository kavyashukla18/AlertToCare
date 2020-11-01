using AlertToCare.Models;
using System;

namespace AlertToCare.BusinessLogic
{
    public interface IPatientBusinessLogic
    {
        public PatientDataModel InsertPatient(Models.PatientDataModel patient);
        public Tuple<PatientDataModel, BedInformation> AllotBedToPatient(Models.BedAllotmentModel allotBed);
        public void FreeTheBed(int patientId);
        public PatientDataModel FetchPatientInfoFromBedId(string bedId);
        public PatientDataModel FetchPatientInfo(int patientId);
    }
}
