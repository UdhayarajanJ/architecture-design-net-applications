using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class ComplaintDetails : BaseModel
    {
        public int complaintId { get; set; }
        public int complaintTypeId { get; set; }
        public string remark { get; set; }
        public int statusTypeId { get; set; }
    }

    public class ComplaintDetailsList : ComplaintDetails
    {
        public string statusType { get; set; }
        public string complaintType { get; set; }
    }


}
