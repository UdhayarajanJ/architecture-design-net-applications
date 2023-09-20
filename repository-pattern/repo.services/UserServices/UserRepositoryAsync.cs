using Dapper;
using repo.contracts.UserContracts;
using repo.contracts.UtitlityContracts;
using repo.entities.UserModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.services.UserServices
{
    internal class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly IDapperContext dapperContext;

        public UserRepositoryAsync(IDapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }
        public async Task<int> SaveUpdateUserInformation(UserInformationModel userInformationModel)
        {
            using (IDbConnection dbConnection = await dapperContext.CreateConnection())
            {
                dbConnection.Open();
                IDbTransaction dbTransaction = dbConnection.BeginTransaction();
                try
                {
                    int userAddressId = 0;
                    if (userInformationModel.addressInfo is not null)
                        userAddressId = await dbConnection.QuerySingleOrDefaultAsync<int>("usp_SaveUpdateUserAddressInformation", userInformationModel.addressInfo, commandType: System.Data.CommandType.StoredProcedure, transaction: dbTransaction);

                    int userIdentificationId = 0;
                    if (userInformationModel.identityInfo is not null)
                        userIdentificationId = await dbConnection.QuerySingleOrDefaultAsync<int>("usp_SaveUpdateUserIdentityInformation", userInformationModel.identityInfo, commandType: System.Data.CommandType.StoredProcedure, transaction: dbTransaction);

                    int userQualificationId = 0;
                    if (userInformationModel.qualificationInfo is not null)
                        userQualificationId = await dbConnection.QuerySingleOrDefaultAsync<int>("usp_SaveUpdateUserQualification", userInformationModel.qualificationInfo, commandType: System.Data.CommandType.StoredProcedure, transaction: dbTransaction);

                    var objParam = new
                    {
                        id = userInformationModel.id,
                        userName = userInformationModel.userName,
                        password = userInformationModel.password,
                        addressId = userAddressId,
                        identificationInformationId = userIdentificationId,
                        qualificationId = userQualificationId,
                    };

                    int userMasterId = 0;
                    userMasterId = await dbConnection.QuerySingleOrDefaultAsync<int>("usp_SaveUpdateUserInformation", objParam, commandType: System.Data.CommandType.StoredProcedure, transaction: dbTransaction);

                    if (userInformationModel.favoritueHobbies.Any())
                    {
                        foreach (var item in userInformationModel.favoritueHobbies)
                        {
                            var objParamHobbies = new
                            {
                                id = item.id,
                                nameOfHobbies = item.nameOfHobbies,
                                userId = userMasterId,
                            };
                          int result=  await dbConnection.QuerySingleOrDefaultAsync<int>("usp_SaveUpdateUserHobbies", objParamHobbies, commandType: System.Data.CommandType.StoredProcedure, transaction: dbTransaction);
                        }
                    }
                    dbTransaction.Commit();
                    dbConnection.Close();
                    return userMasterId;
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw ex;
                }

            }
        }
    }
}
