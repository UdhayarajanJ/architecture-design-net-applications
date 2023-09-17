using domain.Common;
using domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface IComplaintTypeAsyncRepository
    {
        Task<BaseResponseModel> SaveUpdateComplaintType(ComplaintType complaintType);
        Task<BaseResponseModel> DeleteComplaintType(int typeId);
        Task<BaseResponseModel> GetComplaintType();
    }
}
