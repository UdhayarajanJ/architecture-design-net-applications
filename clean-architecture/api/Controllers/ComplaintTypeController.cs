using application.Interfaces;
using domain.Common;
using domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace api.Controllers
{
    [Route("api/complainttype")]
    [ApiController]
    public class ComplaintTypeController : ControllerBase
    {
        private readonly ILogger<ComplaintTypeController> _logger;
        private readonly IComplaintTypeAsyncRepository _complaintTypeAsyncRepository;
        public ComplaintTypeController(ILogger<ComplaintTypeController> _logger, IComplaintTypeAsyncRepository _complaintTypeAsyncRepository)
        {
            this._logger = _logger;
            this._complaintTypeAsyncRepository = _complaintTypeAsyncRepository;
        }

        [HttpPost("save-update-complainttype")]
        public async Task<IActionResult> SaveUpdateComplaintType([FromBody] ComplaintType complaintType)
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [save-update-complainttype]");
            if (complaintType == null)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.NoContent;
                model.message = "No such data found. From complaint type.";
                _logger.LogInformation("[save-update-complainttype] action receive empty request body.");
            }
            else
            {
                model = await _complaintTypeAsyncRepository.SaveUpdateComplaintType(complaintType);
                if (model is null)
                {
                    model.responseData = null;
                    model.statusCode = (int)HttpStatusCode.OK;
                    model.message = "Request doesn't processed anything. Empty response.";
                    _logger.LogInformation("[save-update-complainttype] action doesn't get any acknowledge from database");
                }
                else
                {
                    model.statusCode = (int)HttpStatusCode.Created;
                    _logger.LogInformation("[save-update-complainttype] action successfully created or updated resources : {0}", model.responseData);
                }
            }
            return Ok(model);
        }

        [HttpGet("get-complainttype")]
        public async Task<IActionResult> GetComplaintType()
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [get-complainttype]");
            model = await _complaintTypeAsyncRepository.GetComplaintType();
            if (model is null)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.NoContent;
                model.message = "Not found any data from complaint type.";
                _logger.LogInformation("[get-complainttype] action doesn't return any result");
            }
            else
            {
                model.statusCode = (int)HttpStatusCode.OK;
                model.message = "Successfully fetch complaints type details.";
                _logger.LogInformation("[get-complainttype] action successfully fetch complaints type details.");
            }

            return Ok(model);
        }

        [HttpDelete("delete-complainttype")]
        public async Task<IActionResult> DeleteComplaintType([FromQuery] int typeId)
        {
            BaseResponseModel model = new BaseResponseModel();
            _logger.LogInformation("calling [delete-complainttype]");
            if (typeId == 0)
            {
                model.responseData = null;
                model.statusCode = (int)HttpStatusCode.BadRequest;
                model.message = "Must be enter the complaint type id greater than 0.";
                _logger.LogInformation("[delete-complainttype] action receive type id equal to 0.");
            }
            else
            {
                model = await _complaintTypeAsyncRepository.DeleteComplaintType(typeId);
                if (model is null)
                {
                    model.responseData = null;
                    model.statusCode = (int)HttpStatusCode.OK;
                    model.message = "Request doesn't processed anything. Empty response.";
                    _logger.LogInformation("[delete-complainttype] action doesn't get any acknowledge from database");
                }
                else
                {
                    model.statusCode = (int)HttpStatusCode.OK;
                    _logger.LogInformation("[delete-complainttype] action successfully deleted resources : {0}", model.responseData);
                }
            }
            return Ok(model);
        }
    }
}
