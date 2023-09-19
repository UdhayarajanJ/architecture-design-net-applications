using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.entities.UserModels
{
    public class UserFavoriteHobbiesModel : BaseModel
    {
        public int id { get; set; }
        public string nameOfHobbies { get; set; }
        public int userId { get; set; }
    }
}
