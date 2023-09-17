using domain.Common;
using domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface IComplaintDetailsAsyncRepository
    {
        Task<BaseResponseModel> SaveUpdateComplaintDetails(ComplaintDetails complaintDetails);
        Task<BaseResponseModel> DeleteComplaintDetails(int complaintId);
        Task<BaseResponseModel> GetComplaintDetails();
    }
}
