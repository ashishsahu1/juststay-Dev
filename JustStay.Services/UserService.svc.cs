using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using JustStay.Services.DTO;
using JustStay.Repo;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
// NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
public class UserService : IUserService
{
    UserRepository userRepository;
    public UserService()
    {
        userRepository = new UserRepository();
    }

    public int InsertUser(UserDto user)
    {
        User objUser = new User();
        objUser.Address = user.Address;
        objUser.Email = user.Email;
        objUser.InsertedOn = user.InsertedOn;
        objUser.IsActive = user.IsActive;
        objUser.IsPaid = user.IsPaid;
        objUser.Mobile = user.Mobile;
        objUser.Name = user.Name;
        objUser.Password = user.Password;
        objUser.Username = user.Username;
        objUser.UserTypeId = user.UserTypeId;
        objUser.RoleId = user.RoleId;
        objUser.IsAdmin = user.IsAdmin;
        objUser.Google_Id = user.Google_Id;

        return userRepository.InsertUser(objUser);
    }

    public UserDto GetUserDetails(string username, string password, int usertypeid)
    {
        var user = userRepository.GetUserDetails(username, password, usertypeid);
        if (user == null) return null;
        return FillUserDto(user);
    }

    public UserDto GetUserbyId(int uid)
    {
        var user = userRepository.GetUserbyId(uid);
        if (user == null) return null;
        return FillUserDto(user);
    }

    public UserDto GetGoogleUser(string googleId)
    {
        var user = userRepository.GetGoogleUser(googleId);
        return (user != null) ? FillUserDto(user) : null;
    }

    public int UpdateUserPwd(UserDto user)
    {
        return userRepository.UpdateUserPwd(user.UserId, user.Password);
    }
    public int UpdateUser(int id, string Name, string mobile, string email, string isactive)
    {
        return userRepository.UpdateUser(id, Name, mobile, email, isactive);
    }
    public void UpdateUserGoogleId(int userId, string googleId)
    {
        userRepository.UpdateUserGoogleId(userId, googleId);
    }

    private UserDto FillUserDto(User user)
    {
        UserDto userinfo = new UserDto();

        userinfo.UserId = user.UserId;
        userinfo.Name = user.Name;
        userinfo.Address = user.Address;
        userinfo.Mobile = user.Mobile;
        userinfo.Email = user.Email;
        userinfo.Username = user.Username;
        userinfo.Password = user.Password;
        userinfo.UserTypeId = user.UserTypeId;
        userinfo.IsPaid = user.IsPaid;
        userinfo.IsActive = user.IsActive;
        userinfo.InsertedOn = user.InsertedOn;
        userinfo.UpdatedOn = user.UpdatedOn;
        userinfo.IsAdmin = user.IsAdmin;
        userinfo.RoleId = user.RoleId;

        return userinfo;
    }

    public List<UserDto> UserList()
    {
        var ulist = userRepository.getAllUser().ToList();
        if (ulist == null) return null;

        List<UserDto> udtolist =
        ulist.ConvertAll(x => new UserDto
        {
            Address = x.Address,
            Email = x.Email,
            InsertedOn = x.InsertedOn,
            IsActive = x.IsActive,
            IsAdmin = x.IsAdmin,
            IsPaid = x.IsPaid,
            Mobile = x.Mobile,
            Name = x.Name,
            Password = x.Password,
            RoleId = x.RoleId,
            UpdatedOn = x.UpdatedOn,
            UserId = x.UserId,
            Username = x.Username,
            UserTypeId = x.UserTypeId,
            UserType = x.UserType,
            Role = x.Role
        });
        return udtolist;
    }

    public int DeleteUser(int id)
    {
        return userRepository.DeleteUser(id);
    }

    public bool IsEmailExist(string email, int userTypeId)
    {
        return userRepository.IsEmailExist(email, userTypeId);
    }

    public int GetUserIdByEmailAndUserType(string email, string userType)
    {
        return userRepository.GetUserIdByEmailAndUserType(email, userType);
    }

    //public UserDto GetUserByUsernameAndType(string userName, int usertypeid)
    //{
    //    var user= userRepository.GetUserByUsernameAndType(userName, usertypeid);
    //    if (user == null) return null;
    //    return FillUserDto(user);
    //}

    public UserDto GetCustUserByUsernameOrMobile(string userName)
    {
        userRepository = new UserRepository();
        var user = userRepository.GetCustUserByUsernameOrMobile(userName);
        if (user == null) return null;
        return FillUserDto(user);
    }

    public string GetAutoCompleteEmailList(string userName, string mode)
    {
        userRepository = new UserRepository();
        var lst = userRepository.GetEmailList(userName, mode);

        string name = "", strEmails = "";
        for (int i = 0; i < lst.Count; i++)
        {
            if (lst[i].Name != null)
                name = lst[i].Name;
            else
                name = lst[i].Email;

            if (strEmails == "")
                strEmails = "\"<" + name + " (" + lst[i].UserType + ")>" + lst[i].Email + "\"";
            else
                strEmails = strEmails + ",\"<" + name + " (" + lst[i].UserType + ")>" + lst[i].Email + "\""; ;
        }
        strEmails = "[" + strEmails + "]";

        return strEmails;
    }

    public bool IsMobileExist(string mobile, int userTypeId)
    {
        return userRepository.IsMobileExist(mobile, userTypeId);
    }

    public bool ChangeUserPassword(int userId, string newpass, string cnfpass)
    {
        return userRepository.ChangeUserPassword(userId, newpass, cnfpass);
    }
    public int UpdateAdmin(UserDto usrdto)
    {
        User u = userRepository.GetUserbyId(usrdto.UserId);
        u.Name = usrdto.Name;
        u.Email = usrdto.Email;
        u.Mobile = usrdto.Mobile;
        u.Address = usrdto.Address;
        u.UserId = usrdto.UserId;
       int uid = userRepository.UpdateUser(u);
        return uid;
    }
}

