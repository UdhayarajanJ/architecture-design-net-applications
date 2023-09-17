using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class ComplaintType : BaseModel
    {
        public int typeId { get; set; }
        public string complaintType { get; set; }
    }
}
