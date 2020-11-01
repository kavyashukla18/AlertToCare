using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IcuLayoutController : Controller
    {
        private readonly IIcuLayoutBusinessLogic _icuLayoutManagement;

        public IcuLayoutController(IIcuLayoutBusinessLogic icuLayout)
        {
            _icuLayoutManagement = icuLayout;
        }

        [HttpPost("IcuWardInfo")]
        public IActionResult InsertIcuWardInfo([FromBody] IcuWardLayoutModel objLayoutModel)
        {
            try
            {
                _icuLayoutManagement.AddLayoutInformation(objLayoutModel);
                return Ok(200);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
