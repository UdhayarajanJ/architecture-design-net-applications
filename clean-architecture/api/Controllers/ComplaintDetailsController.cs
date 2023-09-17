using application.Interfaces;
using domain.Common;
using domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers
{
    [Route("api/complaintdetails")]
    [ApiController]
    public class ComplaintDetailsController : ControllerBase
    {
        private readonly ILogger<ComplaintDetailsController> _logger;
        private readonly IComplaintDetailsAsyncRepository _complaintDetailsAsyncRepository;
        public ComplaintDetailsController(ILogger<ComplaintDetailsController> _logger, IComplaintDetailsAsyncRepository _complaintDetailsAsyncRepository)
        {
            this._logger = _logger;
            this._complaintDetailsAsyncRepository = _complaintDetailsAsyncRepository;
        }

        [HttpPost("save-update-complaintdetails")]
        public async Task<IActionResult> SaveUpdateComplaintDetails([FromBody] ComplaintDetails complaintDetails)
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [save-update-complaintdetails]");
            if (complaintDetails == null)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.NoContent;
                model.message = "No such data found. From complaint type.";
                _logger.LogInformation("[save-update-complaintdetails] action receive empty request body.");
            }
            else
            {
                model = await _complaintDetailsAsyncRepository.SaveUpdateComplaintDetails(complaintDetails);
                if (model is null)
                {
                    model.responseData = null;
                    model.statusCode = (int)HttpStatusCode.OK;
                    model.message = "Request doesn't processed anything. Empty response.";
                    _logger.LogInformation("[save-update-complaintdetails] action doesn't get any acknowledge from database");
                }
                else
                {
                    model.statusCode = (int)HttpStatusCode.Created;
                    _logger.LogInformation("[save-update-complaintdetails] action successfully created or updated resources : {0}", model.responseData);
                }
            }
            return Ok(model);
        }

        [HttpGet("get-complaintdetails")]
        public async Task<IActionResult> GetComplaintDetails()
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [get-complaintdetails]");
            model = await _complaintDetailsAsyncRepository.GetComplaintDetails();
            if (model is null)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.NoContent;
                model.message = "Not found any data from complaint type.";
                _logger.LogInformation("[get-complaintdetails] action doesn't return any result");
            }
            else
            {
                model.statusCode = (int)HttpStatusCode.OK;
                model.message = "Successfully fetch complaints type details.";
                _logger.LogInformation("[get-complaintdetails] action successfully fetch complaints details.");
            }

            return Ok(model);
        }

        [HttpDelete("delete-complaintdetails")]
        public async Task<IActionResult> DeleteComplaintType([FromQuery] int complaintId)
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [delete-complaintdetails]");
            if (complaintId == 0)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.BadRequest;
                model.message = "Must be enter the complaint id greater than 0.";
                _logger.LogInformation("[delete-complaintdetails] action receive status id equal to 0.");
            }
            else
            {
                model = await _complaintDetailsAsyncRepository.DeleteComplaintDetails(complaintId);
                if (model is null)
                {
                    model.responseData = null;
                    model.statusCode = (int)HttpStatusCode.OK;
                    model.message = "Request doesn't processed anything. Empty response.";
                    _logger.LogInformation("[delete-complaintdetails] action doesn't get any acknowledge from database");
                }
                else
                {
                    model.statusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation("[delete-complaintdetails] action successfully deleted resources : {0}", model.responseData);
                }
            }
            return Ok(model);
        }
    }
}
