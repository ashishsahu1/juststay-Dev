using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JustStay.Web.CustomerServiceReference;
using JustStay.Web.UserServiceReference;
using JustStay.Services.DTO;

namespace JustStay.Web.BusinessLogic
{
    public class Authenticate
    {
        public static int IsAuthenticated(string username, string password)
        {
            int UserId = 0;
            UserDto udto = new UserDto();
            UserServiceClient userclient = new UserServiceClient();
            CustomerServiceClient custClient = new CustomerServiceClient();
            udto = userclient.GetUserDetails(username, password, 3);
            if (udto != null)
            {
                UserId = udto.UserId;
                if (UserId != 0)
                {
                    udto.CustomerId = custClient.GetCustomerIdByUserId(UserId);
                    HttpContext.Current.Session["User"] = udto;
                }
            }
            userclient.Close();
            custClient.Close();
            return UserId;
        }

        public static int IsGoogleUserAutheticated(GoogleUser gUser)
        {
            int UserId = 0;
            UserDto udto = new UserDto();
            UserServiceClient userclient = new UserServiceClient();
            udto = userclient.GetGoogleUser(gUser.id);
            if (udto != null)
            {
                UserId = udto.UserId;
                SetUserSesion(udto);
            }
            else
            {
                udto = userclient.GetCustUserByUsernameOrMobile(gUser.email);
                if (udto != null)
                {
                    UserId = udto.UserId;
                    userclient.UpdateUserGoogleId(UserId, gUser.id);
                    SetUserSesion(udto);
                }
                else
                {
                    AddCustomer(gUser);
                    UserId = IsGoogleUserAutheticated(gUser);
                }
            }
            userclient.Close();
            return UserId;
        }

        private static void SetUserSesion(UserDto udto)
        {
            CustomerServiceClient csclient = new CustomerServiceClient();
            udto.CustomerId = csclient.GetCustomerIdByUserId(udto.UserId);
            HttpContext.Current.Session["User"] = udto;
            csclient.Close();
        }

        private static void AddCustomer(GoogleUser gUser)
        {
            Random num = new Random();
            UserServiceClient userserviceClient = new UserServiceClient();
            UserDto user = new UserDto();
            user.Name = gUser.name;
            user.Mobile = "";
            user.Username = user.Email = gUser.email;
            user.Password = Convert.ToString(num.Next(1000, 1000000)); 
            user.IsActive = true;
            user.IsPaid = user.IsAdmin = false;
            user.UserTypeId = 3;
            user.InsertedOn = DateTime.Now;
            user.RoleId = 0;
            user.Google_Id = gUser.id;
            int userid = userserviceClient.InsertUser(user);

            CustomerServiceClient custClient = new CustomerServiceClient();
            CustomerDto cust = new CustomerDto()
            {
                UserId = userid,
                IsGuest = false
            };

            custClient.InsertCustomer(cust);
            userserviceClient.Close();
            custClient.Close();
        }
    }
}