using repo.entities.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.contracts.UserContracts
{
    public interface IUserRepositoryAsync
    {
        Task<int> SaveUpdateUserInformation(UserInformationModel userInformationModel);
        Task<UserInformationModel> GetUserInformationById(int id);
        Task<List<GetUserDetails>> GetUserInformation();
        Task<int> DeleteUserInformation(int id);
    }
}
