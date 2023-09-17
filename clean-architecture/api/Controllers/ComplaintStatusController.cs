using application.Interfaces;
using domain.Common;
using domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintStatusController : ControllerBase
    {
        private readonly ILogger<ComplaintStatusController> _logger;
        private readonly IComplaintStatusAsyncRepository _complaintStatusAsyncRepository;
        public ComplaintStatusController(ILogger<ComplaintStatusController> _logger, IComplaintStatusAsyncRepository _complaintStatusAsyncRepository)
        {
            this._logger = _logger;
            this._complaintStatusAsyncRepository = _complaintStatusAsyncRepository;
        }

        [HttpPost("save-update-complaintstatus")]
        public async Task<IActionResult> SaveUpdateComplaintStatus([FromBody] ComplaintStatus complaintStatus)
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [save-update-complaintstatus]");
            if (complaintStatus == null)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.NoContent;
                model.message = "No such data found. From complaint type.";
                _logger.LogInformation("[save-update-complaintstatus] action receive empty request body.");
            }
            else
            {
                model = await _complaintStatusAsyncRepository.SaveUpdateComplaintStatus(complaintStatus);
                if (model is null)
                {
                    model.responseData = null;
                    model.statusCode = (int)HttpStatusCode.OK;
                    model.message = "Request doesn't processed anything. Empty response.";
                    _logger.LogInformation("[save-update-complaintstatus] action doesn't get any acknowledge from database");
                }
                else
                {
                    model.statusCode = (int)HttpStatusCode.Created;
                    _logger.LogInformation("[save-update-complaintstatus] action successfully created or updated resources : {0}", model.responseData);
                }
            }
            return Ok(model);
        }

        [HttpGet("get-complaintstatus")]
        public async Task<IActionResult> GetComplaintStatus()
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [get-complaintstatus]");
            model = await _complaintStatusAsyncRepository.GetComplaintStatus();
            if (model is null)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.NoContent;
                model.message = "Not found any data from complaint type.";
                _logger.LogInformation("[get-complaintstatus] action doesn't return any result");
            }
            else
            {
                model.statusCode = (int)HttpStatusCode.OK;
                model.message = "Successfully fetch complaints type details.";
                _logger.LogInformation("[get-complaintstatus] action successfully fetch complaints type details.");
            }

            return Ok(model);
        }

        [HttpDelete("delete-complaintstatus")]
        public async Task<IActionResult> DeleteComplaintType([FromQuery] int statusId)
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [delete-complaintstatus]");
            if (statusId == 0)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.BadRequest;
                model.message = "Must be enter the status type id greater than 0.";
                _logger.LogInformation("[delete-complaintstatus] action receive status id equal to 0.");
            }
            else
            {
                model = await _complaintStatusAsyncRepository.DeleteComplaintStatus(statusId);
                if (model is null)
                {
                    model.responseData = null;
                    model.statusCode = (int)HttpStatusCode.OK;
                    model.message = "Request doesn't processed anything. Empty response.";
                    _logger.LogInformation("[delete-complaintstatus] action doesn't get any acknowledge from database");
                }
                else
                {
                    model.statusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation("[delete-complaintstatus] action successfully deleted resources : {0}", model.responseData);
                }
            }
            return Ok(model);
        }
    }
}
