using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.entities.UserModels
{
    public class UserIdentityModel : BaseModel
    {
       public int id { get; set; }
       public string adhaarNumber { get; set; }
       public string panNumber { get; set; }
       public string drivingLicenceNumber { get; set; }
       public string passportNumber { get; set; }
       public string voterId { get; set; }
    }
}
