using System;
using System.Collections.Generic;
using System.Linq;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using AlertToCare.Validator;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]

    public class MedicalDeviceController : ControllerBase
    {
        readonly IMedicalDeviceBusinessLogic _deviceDataRepository;
        readonly IPatientBusinessLogic _patientDataRepository;
        public MedicalDeviceController(IMedicalDeviceBusinessLogic deviceRepo,
            IPatientBusinessLogic patientRepo)
        {
            this._deviceDataRepository = deviceRepo;
            this._patientDataRepository = patientRepo;
        }


        [Microsoft.AspNetCore.Mvc.HttpPost("MedicalDevice")]
        public IActionResult InsertDevice([Microsoft.AspNetCore.Mvc.FromBody] MedicalDevice device)
        {
            if (!DeviceValidator.ValidateDevice(device))
                return BadRequest("Please enter valid input");
            try
            {
                _deviceDataRepository.InsertDevice(device);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to insert device information");
            }

            return Ok("Insertion successful");
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("Alert")]
        public ActionResult<IEnumerable<dynamic>> IsAlert([Microsoft.AspNetCore.Mvc.FromBody] MedicalStatusDataModel status)
        {
            PatientDataModel patientInfo;
            IEnumerable<string> alertingDevice;
            int[] layout;
            try
            {
                patientInfo = _patientDataRepository.FetchPatientInfoFromBedId(status.BedId);
                CheckPatientValid(patientInfo);

                alertingDevice = _deviceDataRepository.Alert(status);
                layout = _deviceDataRepository.FetchBedLayoutInfo(status.BedId);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid Request Body");
            }

            var responseData = new Dictionary<string, dynamic>
            {
                {"patientId", patientInfo.PatientId},
                {"email", patientInfo.Email},
                {"address", patientInfo.Address},
                {"mobile", patientInfo.Mobile},
                {"Bed Id", status.BedId},
                {"Alert Device", alertingDevice},
                {"Row", layout[0]},
                {"Column", layout[1]}
            };
            return !alertingDevice.Any() ? Ok("Patient Condition OK") : Ok(responseData);
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("Alert/{bedId}")]
        public IActionResult AlertOff(string bedId)
        {
            if (bedId == null)
                return BadRequest("Invalid bed id");
            try
            {
                _deviceDataRepository.AlertOff(bedId);
            }
            catch
            {
                return StatusCode(500);
            }

            return Ok();


        }
        private static void CheckPatientValid(PatientDataModel patientInfo)
        {
            if(patientInfo == null)
                throw  new ArgumentException("Invalid bed id");
        }
    }
}
