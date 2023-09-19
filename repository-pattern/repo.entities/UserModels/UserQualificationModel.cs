using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.entities.UserModels
{
    public class UserQualificationModel : BaseModel
    {
      public int id { get; set; }
      public string highestQualification { get; set; }
      public int highestQualificationPassOut { get; set; }
      public string school_collegeName { get; set; }
    }

}
