using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.entities.UserModels
{
    public class UserInformationModel : BaseModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public UserAddressModel addressInfo { get; set; }
        public UserIdentityModel identityInfo { get; set; }
        public UserQualificationModel qualificationInfo { get; set; }
        public List<UserFavoriteHobbiesModel> favoritueHobbies { get; set; }
    }
}
