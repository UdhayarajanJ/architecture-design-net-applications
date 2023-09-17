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
    public class ComplaintTypeAsyncRepository : IComplaintTypeAsyncRepository
    {
        private readonly IDapperContext _dapperContext;
        public ComplaintTypeAsyncRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }
        public async Task<BaseResponseModel> DeleteComplaintType(int typeId)
        {
            BaseResponseModel baseResponseModel = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
                baseResponseModel = await dbConnection.QuerySingleOrDefaultAsync<BaseResponseModel>("usp_complainttype_delete", new { typeId }, commandType: CommandType.StoredProcedure);
            return baseResponseModel;
        }

        public async Task<BaseResponseModel> GetComplaintType()
        {
            BaseResponseModel baseResponseModel = null;
            List<ComplaintType> complaintTypesResult = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                complaintTypesResult = (await dbConnection.QueryAsync<ComplaintType>("usp_complainttype_get", null, commandType: CommandType.StoredProcedure)).ToList();
            }
            return new BaseResponseModel()
            {
                responseData = complaintTypesResult
            };
        }

        public async Task<BaseResponseModel> SaveUpdateComplaintType(ComplaintType complaintType)
        {
            BaseResponseModel baseResponseModel = null;
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                var objParam = new
                {
                    typeId = complaintType.typeId,
                    complaintTypeName = complaintType.complaintType
                };
                baseResponseModel = await dbConnection.QuerySingleOrDefaultAsync<BaseResponseModel>("usp_complainttype_save_update", objParam, commandType: CommandType.StoredProcedure);
            }
            return baseResponseModel;
        }
    }
}
