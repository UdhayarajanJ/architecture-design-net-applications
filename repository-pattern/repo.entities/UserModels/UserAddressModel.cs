using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.entities.UserModels
{
    public class UserAddressModel : BaseModel
    {
        public int id { get; set; }
        public string houseNo_flatNo { get; set; }
        public string streetName { get; set; }
        public string landmark_AreaName { get; set; }
        public string circleName { get; set; }
        public string cityName { get; set; }
        public long pinCode { get; set; }
        public string districtName { get; set; }
        public string stateName { get; set; }
    }
}
