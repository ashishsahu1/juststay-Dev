using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace JustStay.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AndroUserService
    {
        UserRepository userRepository;
        CustomerRepository custRepository;
        public AndroUserService()
        {
            userRepository = new UserRepository();
            custRepository = new CustomerRepository();
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
            UriTemplate = "InsertUser/{name}/{mobile}/{email}/{username}/{password}/{isactive}/{ispaid}/{usertypeid}/{isadmin}/{roleid}/{insertedon}")]
        public int InsertUser(string name, string mobile, string email, string username, string password,
             string isactive, string ispaid, string usertypeid, string isadmin, string roleid, string insertedon)
        {
            userRepository = new UserRepository();
            User objUser = new User();
            objUser.Email = Convert.ToString(email);
            objUser.InsertedOn = Convert.ToDateTime(insertedon);
            objUser.IsActive = Convert.ToBoolean(isactive);
            objUser.IsPaid = Convert.ToBoolean(ispaid);
            objUser.Mobile = mobile;
            objUser.Name = name;
            objUser.Password = password;
            objUser.Username = username;
            objUser.UserTypeId = Convert.ToInt32(usertypeid);
            objUser.RoleId = Convert.ToInt32(roleid);
            objUser.IsAdmin = Convert.ToBoolean(isadmin);

            return userRepository.InsertUser(objUser);
        }


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUserDetails/{username}/{password}/{usertypeid}")]
        public UserDto GetUserDetails(string username, string password, string usertypeid)
        {
            userRepository = new UserRepository();
            custRepository = new CustomerRepository();
            var user = userRepository.GetUserDetails(username, password, Convert.ToInt32(usertypeid));
            int customerid = custRepository.GetCustomerIdByUserId(Convert.ToInt32(user.UserId));
            CustomerDetail custdetails = custRepository.GetCustomerDetail(Convert.ToInt32(customerid));
            if (user == null) return null;
            return FillUserDto(user, customerid, custdetails);
        }
        private UserDto FillUserDto(User user,int customerid,CustomerDetail cust)
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
            userinfo.CustomerId = customerid;
            userinfo.Gender = cust.Gender;
            userinfo.DOB = cust.DOB != null ? Convert.ToString(cust.DOB.Value.Date) : "";
            userinfo.NewDOB = Convert.ToString(cust.NewDOB);

            return userinfo;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
           UriTemplate = "InsertCustomer/{userid}/{isguest}")]
        public int InsertCustomer(string userid,string isguest)
        {
            custRepository = new CustomerRepository();
            Customer cust = new Customer()
            {
                UserId = Convert.ToInt32(userid),
                IsGuest = Convert.ToBoolean(isguest)
            };

            return custRepository.InsertCustomer(cust);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
         UriTemplate = "UpdateCustomerProfile/{custid}/{userid}/{DOB}/{gender}/{name}/{email}/{mobile}/{address}")]
        public int UpdateCustomerProfile(string custid,string userid, string DOB,string gender,string name,string email,string mobile, string address)
        {
            custRepository = new CustomerRepository();
            Customer customer = custRepository.GetCustomerById(Convert.ToInt32(custid));
            customer.DOB = Convert.ToDateTime(DOB).Date;
            customer.Gender = gender;
            custRepository.UpdateCustomer();

            UserRepository userRepo = new UserRepository();
            User u = userRepo.GetUserbyId(Convert.ToInt32(userid));
            u.Name = name;
            u.Email = email;
            u.Mobile = mobile;
            u.Address = address;
            userRepo.UpdateUser();
            return 1;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
        UriTemplate = "IsMobileExist/{mobile}/{userTypeId}")]
        private bool IsMobileExist(string mobile, string userTypeId)
        {
            userRepository = new UserRepository();
            return userRepository.IsMobileExist(mobile, Convert.ToInt32(userTypeId));
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json,
         UriTemplate = "IsEmailExist/{email}/{userTypeId}")]
        private bool IsEmailExist(string email, string userTypeId)
        {
            userRepository = new UserRepository();
            return userRepository.IsEmailExist(email, Convert.ToInt32(userTypeId));
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCustomerDetail/{custId}")]
        public CustomerDetail GetCustomerDetail(string custId)
        {
            CustomerRepository custRepository = new CustomerRepository();
            return custRepository.GetCustomerDetail(Convert.ToInt32(custId));
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCustomerIdByUserId/{userId}")]
        public int GetCustomerIdByUserId(string userId)
        {
            CustomerRepository custRepository = new CustomerRepository();
            return custRepository.GetCustomerIdByUserId(Convert.ToInt32(userId));
        }
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ChangeUserPassword/{userId}/{newpass}/{cnfpass}")]
        public bool ChangeUserPassword(string userId, string newpass, string cnfpass)
        {
            userRepository = new UserRepository();
            return userRepository.ChangeUserPassword(Convert.ToInt32(userId), newpass, cnfpass);
        }

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCustByUsernameOrMobile/{username}")]
        public User GetCustByUsernameOrMobile(string username)
        {
            userRepository = new UserRepository();
            User user = userRepository.GetCustUserByUsernameOrMobile(username);
            if (user == null) return null;
            return user;
        }

    }
}
