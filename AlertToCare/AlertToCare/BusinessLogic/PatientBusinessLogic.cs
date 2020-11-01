using AlertToCare.Models;
using AlertToCare.Repository;
using System;

namespace AlertToCare.BusinessLogic
{
    public class PatientBusinessLogic : IPatientBusinessLogic
    {
        readonly IPatientDataRepository _patientDataRepository;
        public PatientBusinessLogic(IPatientDataRepository repo)
        {
            this._patientDataRepository = repo;
        }

        public PatientDataModel InsertPatient(PatientDataModel patient)
        {
            _patientDataRepository.AddPatient(patient);
            return patient;
        }

        public PatientDataModel FetchPatientInfoFromBedId(string bedId)
        {
            var patientResult = _patientDataRepository.FetchPatientInfoFromBedId(bedId);
            return patientResult;
        }
        public void FreeTheBed(int patientId)
        {
            _patientDataRepository.RemovePatientFromBed(patientId);
        }

        public Tuple<PatientDataModel, BedInformation> AllotBedToPatient(BedAllotmentModel allotBed)
        {
            _patientDataRepository.AllotBedToPatient(allotBed);
            var objPatientInfo = _patientDataRepository.FetchPatientFromPatientId(allotBed.PatientId);
            var objBedInfo = _patientDataRepository.FetchBedInfoFromPatientId(allotBed.PatientId);
            return new Tuple<PatientDataModel, BedInformation>(objPatientInfo,objBedInfo); 
        }
        public PatientDataModel FetchPatientInfo(int patientId)
        {
            var patientInfo = _patientDataRepository.FetchPatientFromPatientId(patientId);
            return patientInfo;
        }

    }
}
