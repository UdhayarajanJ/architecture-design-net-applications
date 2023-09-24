using domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.entities.UserModels
{
    public class UserInformationModel : BaseModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public UserAddressModel addressInfo { get; set; }
        public UserIdentityModel identityInfo { get; set; }
        public UserQualificationModel qualificationInfo { get; set; }
        public List<UserFavoriteHobbiesModel> favoritueHobbies { get; set; }
    }
    /*
        tui.id as 'userId',
        tui.userName as 'userName',
        tui.createdDate as 'userCreeatedDate',
        tui.updatedDate as 'userUpdatedDate',
        
        tua.id as 'addressId',
        tua.houseNo_flatNo as 'houseNo_flatNo',
        tua.streetName as 'streetName',
        tua.landmark_AreaName as 'landmark_AreaName',
        tua.circleName as 'circleName',
        tua.cityName as 'cityName',
        tua.districtName as 'districtName',
        tua.stateName as 'stateName',
        
		tuii.id as 'identificationId',
        tuii.adhaarNumber as 'adhaarNumber',
        tuii.panNumber as 'panNumber',
        tuii.drivingLicenceNumber as 'drivingLicenceNumber',
        tuii.passportNumber as 'passportNumber',
        tuii.voterId as 'voterId',
        
        tuq.id as 'qualificationId',
        tuq.highestQualification as 'highestQualification',
        tuq.highestQualificationPassOut as 'highestQualificationPassOut',
        tuq.school_collegeName as 'school_collegeName'
     */
    public class GetUserDetailsById
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public DateTime userCreatedDate { get; set; }
        public DateTime userUpdatedDate { get; set; }

        public int addressId { get; set; }
        public string houseNo_flatNo { get; set; }
        public string streetName { get; set; }
        public string landmark_AreaName { get; set; }
        public string circleName { get; set; }
        public string cityName { get; set; }
        public long pinCode { get; set; }
        public string districtName { get; set; }
        public string stateName { get; set; }


        public int identificationId { get; set; }
        public string adhaarNumber { get; set; }
        public string panNumber { get; set; }
        public string drivingLicenceNumber { get; set; }
        public string passportNumber { get; set; }
        public string voterId { get; set; }

        public int qualificationId { get; set; }
        public string highestQualification { get; set; }
        public int highestQualificationPassOut { get; set; }
        public string school_collegeName { get; set; }
    }

    public class GetUserDetails
    {
        public int id { get; set; }
        public string userName { get; set; }
    }
}
