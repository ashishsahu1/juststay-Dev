using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using JustStay.Services.DTO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
[ServiceContract]
public interface IUserService
{
    [OperationContract]
    UserDto GetUserbyId(int uid);

    [OperationContract]
    int InsertUser(UserDto userdto);

    [OperationContract]
    int UpdateUserPwd(UserDto user);

    [OperationContract]
    UserDto GetUserDetails(string username, string password, int usertypeid);

    [OperationContract]
    List<UserDto> UserList();

    [OperationContract]
    int DeleteUser(int id);

    [OperationContract]
    bool IsEmailExist(string email, int userTypeId);

    [OperationContract]
    string GetAutoCompleteEmailList(string userName, string mode);

    [OperationContract]
    int GetUserIdByEmailAndUserType(string email, string userType);

    [OperationContract]
    bool IsMobileExist(string mobile, int userTypeId);

    [OperationContract]
    UserDto GetCustUserByUsernameOrMobile(string userName);
    // UserDto GetUserByUsernameAndType(string userName, int usertypeid);

    [OperationContract]
    UserDto GetGoogleUser(string googleId);

    [OperationContract]
    void UpdateUserGoogleId(int userId, string googleId);

    [OperationContract]
    bool ChangeUserPassword(int id, string newpass, string cnfpass);

    [OperationContract]
    int UpdateUser(int id, string Name, string mobile, string email, string isactive);

    [OperationContract]
    int UpdateAdmin(UserDto usrdto);
}

