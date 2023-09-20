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
    }
}
