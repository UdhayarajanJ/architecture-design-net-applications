using application.Interfaces;
using Dapper;
using domain.Common;
using domain.Models;
using infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Services
{
    public class ComplaintDetailsAsyncRepository : IComplaintDetailsAsyncRepository
    {
        private readonly IDapperContext _dapperContext;
        public ComplaintDetailsAsyncRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<BaseResponseModel> DeleteComplaintDetails(int complaintId)
        {
            BaseResponseModel baseResponseModel = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
                baseResponseModel = await dbConnection.QuerySingleOrDefaultAsync<BaseResponseModel>("usp_complaint_details_delete", new { complaintId }, commandType: CommandType.StoredProcedure);
            return baseResponseModel;
        }

        public async Task<BaseResponseModel> GetComplaintDetails()
        {
            BaseResponseModel baseResponseModel = null;
            List<ComplaintDetailsList> complaintDetailsResult = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                complaintDetailsResult = (await dbConnection.QueryAsync<ComplaintDetailsList>("usp_complaint_details_get", null, commandType: CommandType.StoredProcedure)).ToList();
            }
            return new BaseResponseModel()
            {
                responseData = complaintDetailsResult
            };
        }

        public async Task<BaseResponseModel> SaveUpdateComplaintDetails(ComplaintDetails complaintDetails)
        {
            BaseResponseModel baseResponseModel = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                var objParam = new
                {
                    complaintId = complaintDetails.complaintId,
                    complaintTypeId = complaintDetails.complaintTypeId,
                    remark = complaintDetails.remark,
                    statusTypeId = complaintDetails.statusTypeId,
                };
                baseResponseModel = await dbConnection.QuerySingleOrDefaultAsync<BaseResponseModel>("usp_complaint_details_save_update", objParam, commandType: CommandType.StoredProcedure);
            }
            return baseResponseModel;
        }
    }
}
