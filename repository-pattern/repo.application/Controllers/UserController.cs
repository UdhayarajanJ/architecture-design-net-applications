using domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repo.contracts.UserContracts;
using repo.entities.UserModels;

namespace repo.application.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryAsync userRepositoryAsync;
        private readonly ILogger<UserController> logger;

        public UserController(IUserRepositoryAsync userRepositoryAsync, ILogger<UserController> logger)
        {
            this.userRepositoryAsync = userRepositoryAsync;
            this.logger = logger;
        }

        [HttpPost("save-update-user")]
        public async Task<IActionResult> SaveUpdateUserInformation([FromBody] UserInformationModel userInformationModel)
        {
            BaseResponseModel model = new BaseResponseModel();
            logger.LogInformation("POST : [save-update-user] Call the action.");

            bool isUpdate = userInformationModel.id == 0 ? false : true;

            int result = await userRepositoryAsync.SaveUpdateUserInformation(userInformationModel);

            logger.LogInformation("POST : [save-update-user] database successfully return the processed user id {0}", result);

            model.statusCode = !isUpdate ? StatusCodes.Status201Created : StatusCodes.Status200OK;
            model.message = !isUpdate ? "User information created successfully." : "User information updated successfully";
            model.responseData = result;

            return Ok(model);
        }


        [HttpGet("get-user-details-by-id")]
        public async Task<IActionResult> GetUserInformationById([FromQuery]int id)
        {
            BaseResponseModel model = new BaseResponseModel();
            logger.LogInformation("GET : [get-user-details-by-id] Call the action.");

            UserInformationModel result = await userRepositoryAsync.GetUserInformationById(id);

            logger.LogInformation("GET : [get-user-details-by-id] database return the user id {0}", result?.id);

            model.statusCode = result is null ? StatusCodes.Status204NoContent : StatusCodes.Status200OK;
            model.message = result is null ? "User information not found." : "User information found.";
            model.responseData = result;

            return Ok(model);
        }

        [HttpGet("get-user-details")]
        public async Task<IActionResult> GetUserInformation()
        {
            BaseResponseModel model = new BaseResponseModel();
            logger.LogInformation("GET : [get-user-details] Call the action.");

            List<GetUserDetails> result = await userRepositoryAsync.GetUserInformation();

            logger.LogInformation("GET : [get-user-details] database return the users count {0}", result?.Count());

            model.statusCode = result is null ? StatusCodes.Status204NoContent : StatusCodes.Status200OK;
            model.message = result is null ? "User information not found." : "User information found.";
            model.responseData = result;

            return Ok(model);
        }

        [HttpDelete("delete-user-details")]
        public async Task<IActionResult> DeleteUserInformation([FromQuery]int id)
        {
            BaseResponseModel model = new BaseResponseModel();
            logger.LogInformation("DELETE : [delete-user-details] Call the action.");

            int result = await userRepositoryAsync.DeleteUserInformation(id);

            logger.LogInformation("DELETE : [delete-user-details] database return the acknowledgement {0}", result);

            model.statusCode = result ==0 ? StatusCodes.Status400BadRequest : StatusCodes.Status200OK;
            model.message = result == 0 ? "User details not deleted." : "User details deleted successfully.";
            model.responseData = result;

            return Ok(model);
        }
    }
}
