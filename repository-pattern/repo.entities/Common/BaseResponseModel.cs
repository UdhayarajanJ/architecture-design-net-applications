using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common
{
    public class BaseResponseModel
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public object responseData { get; set; }
    }
}
