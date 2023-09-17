using domain.Common;
using domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface IComplaintStatusAsyncRepository
    {
        Task<BaseResponseModel> SaveUpdateComplaintStatus(ComplaintStatus complaintStatus);
        Task<BaseResponseModel> DeleteComplaintStatus(int statusId);
        Task<BaseResponseModel> GetComplaintStatus();
    }
}
