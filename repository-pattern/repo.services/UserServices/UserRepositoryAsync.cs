using Dapper;
using repo.contracts.UserContracts;
using repo.contracts.UtitlityContracts;
using repo.entities.UserModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<int> DeleteUserInformation(int id)
        {
            using (IDbConnection dbConnection = await dapperContext.CreateConnection())
            {
                int result = await dbConnection.ExecuteAsync("usp_User_DeleteById", new { id }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<GetUserDetails>> GetUserInformation()
        {
            using (IDbConnection dbConnection = await dapperContext.CreateConnection())
            {
                List<GetUserDetails> result = (await dbConnection.QueryAsync<GetUserDetails>("usp_User_GetAll", commandType: CommandType.StoredProcedure))?.ToList();
                return result;
            }
        }

        public async Task<UserInformationModel> GetUserInformationById(int id)
        {
            UserInformationModel userInformationModel = null;
            using (IDbConnection dbConnection = await dapperContext.CreateConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_User_GetDetails_ById", new { id }, commandType: CommandType.StoredProcedure);
                GetUserDetailsById getUserDetails = await result.ReadSingleOrDefaultAsync<GetUserDetailsById>();
                List<UserFavoriteHobbiesModel> userFavoriteHobbiesModel = (await result.ReadAsync<UserFavoriteHobbiesModel>())?.ToList();

                if (getUserDetails is null) return null;

                UserAddressModel addressModel = new UserAddressModel()
                {
                    id = getUserDetails.addressId,
                    houseNo_flatNo = getUserDetails.houseNo_flatNo,
                    circleName = getUserDetails.circleName,
                    landmark_AreaName = getUserDetails.landmark_AreaName,
                    districtName = getUserDetails.districtName,
                    stateName = getUserDetails.stateName,
                    pinCode = getUserDetails.pinCode,
                    cityName = getUserDetails.cityName,
                    streetName = getUserDetails.streetName
                };

                UserIdentityModel identityModel = new UserIdentityModel()
                {
                    id = getUserDetails.identificationId,
                    adhaarNumber = getUserDetails.adhaarNumber,
                    drivingLicenceNumber = getUserDetails.drivingLicenceNumber,
                    panNumber = getUserDetails.panNumber,
                    passportNumber = getUserDetails.passportNumber,
                    voterId = getUserDetails.voterId
                };

                UserQualificationModel userQualificationModel = new UserQualificationModel()
                {
                    id = getUserDetails.qualificationId,
                    highestQualification = getUserDetails.highestQualification,
                    highestQualificationPassOut = getUserDetails.highestQualificationPassOut,
                    school_collegeName = getUserDetails.school_collegeName,
                };


                userInformationModel = new UserInformationModel()
                {
                    id = getUserDetails.userId,
                    addressInfo = addressModel,
                    favoritueHobbies = userFavoriteHobbiesModel,
                    identityInfo = identityModel,
                    qualificationInfo = userQualificationModel,
                    userName = getUserDetails.userName,
                    createdDate = getUserDetails.userCreatedDate,
                    updatedDate = getUserDetails.userUpdatedDate,
                };
                return userInformationModel;
            }
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
                            int result = await dbConnection.QuerySingleOrDefaultAsync<int>("usp_SaveUpdateUserHobbies", objParamHobbies, commandType: System.Data.CommandType.StoredProcedure, transaction: dbTransaction);
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
