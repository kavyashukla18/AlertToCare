using System;
using System.Collections.Generic;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using AlertToCare.Validator;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PatientDataController : ControllerBase
    {
        readonly IPatientBusinessLogic _patientBusinessLogic;
        public PatientDataController(IPatientBusinessLogic operation)
        {
            this._patientBusinessLogic = operation;
        }


        [HttpPost("PatientInfo")]
        public ActionResult<IEnumerable<dynamic>> InsertPatient([FromBody] PatientDataModel patient)
        {
            PatientDataModel patientInfo;
            if (!PatientValidator.ValidatePatient(patient))
                return BadRequest("Please enter valid input");
            try
            {
                patientInfo = _patientBusinessLogic.InsertPatient(patient);
            }
            catch
            {
                return StatusCode(500, "unable to insert patient information");
            }

            var responseData = new Dictionary<string, dynamic>
            {
                {"patientId", patientInfo.PatientId},
                {"patientName", patientInfo.PatientName},
                {"email", patientInfo.Email},
                {"address", patientInfo.Address},
                {"mobile", patientInfo.Mobile},
            };
            return Ok(responseData);
           }

        [HttpPost("BedAllocation")]
        public IActionResult AllotBedToPatient([FromBody] BedAllotmentModel bedAllotment)
        {
            Tuple<PatientDataModel, BedInformation> response;
              AllotedBedValidator bedValidator = new AllotedBedValidator();
            bool isDataValid = bedValidator.ValidateBedAlloted(bedAllotment);
            if (!isDataValid)
                return BadRequest("Please Enter Valid Input");
            try
            {
                response = _patientBusinessLogic.AllotBedToPatient(bedAllotment);
            }
            catch
            {
                return StatusCode(500);
            }
            string bedLayout = "R"+response.Item2.BedInRow.ToString() + "C" + response.Item2.BedInColumn.ToString();
            var responseData = new Dictionary<string, dynamic>
            {
                {"patientId", response.Item1.PatientId},
                {"patientName", response.Item1.PatientName},
                {"email", response.Item1.Email},
                {"address",response.Item1.Address},
                {"mobile", response.Item1.Mobile},
                {"bedId", response.Item2.BedId },
                {"wardInfo", response.Item2.WardNumber },
                {"bedLayout", bedLayout }
            };
            return Ok(responseData);
        }
        [HttpDelete("BedAllocation/{patientId}")]
        public IActionResult DischargePatient(int patientId)
        {
            try
            {
                _patientBusinessLogic.FreeTheBed(patientId);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet("GetPatientInfo/{patientId}")]
        public IActionResult GetPatientInformation(int patientId)
        {
            PatientDataModel patientInfo;
            try
            {
                patientInfo = _patientBusinessLogic.FetchPatientInfo(patientId);
            }
            catch
            {
                return StatusCode(500);
            }
            if (patientInfo != null)
            {
                var responseData = new Dictionary<string, dynamic>
                {
                    {"patientId", patientInfo.PatientId},
                    {"patientName", patientInfo.PatientName},
                    {"email", patientInfo.Email},
                    {"address", patientInfo.Address},
                    {"mobile", patientInfo.Mobile},
                };
                return StatusCode(500);
            }
            return BadRequest("Invalid PatientId");
        }
    }
}
