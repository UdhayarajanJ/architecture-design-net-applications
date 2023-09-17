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
    public class ComplaintStatusAsyncRepository : IComplaintStatusAsyncRepository
    {
        private readonly IDapperContext _dapperContext;
        public ComplaintStatusAsyncRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<BaseResponseModel> DeleteComplaintStatus(int statusId)
        {
            BaseResponseModel baseResponseModel = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
                baseResponseModel = await dbConnection.QuerySingleOrDefaultAsync<BaseResponseModel>("usp_complaint_status_delete", new { statusId }, commandType: CommandType.StoredProcedure);
            return baseResponseModel;
        }

        public async Task<BaseResponseModel> GetComplaintStatus()
        {
            BaseResponseModel baseResponseModel = null;
            List<ComplaintStatus> complaintTypesResult = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                complaintTypesResult = (await dbConnection.QueryAsync<ComplaintStatus>("usp_complaint_status_get", null, commandType: CommandType.StoredProcedure)).ToList();
            }
            return new BaseResponseModel()
            {
                responseData = complaintTypesResult
            };
        }

        public async Task<BaseResponseModel> SaveUpdateComplaintStatus(ComplaintStatus complaintStatus)
        {
            BaseResponseModel baseResponseModel = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                var objParam = new
                {
                    statusId = complaintStatus.statusId,
                    statusName = complaintStatus.statusType
                };
                baseResponseModel = await dbConnection.QuerySingleOrDefaultAsync<BaseResponseModel>("usp_complaint_status_save_update", objParam, commandType: CommandType.StoredProcedure);
            }
            return baseResponseModel;
        }
    }
}
