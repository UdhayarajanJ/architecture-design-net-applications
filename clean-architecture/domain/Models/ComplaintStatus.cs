using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class ComplaintStatus : BaseModel
    {
        public int statusId { get; set; }
        public string statusType { get; set; }
    }

}
