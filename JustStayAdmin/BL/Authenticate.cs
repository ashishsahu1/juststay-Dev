using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JustStayAdmin.UserServiceReference;
using JustStay.Services.DTO;

public class Authenticate
    {
        public static int IsAuthenticated(string username, string password)
        {
            int UserId = 0;
            UserDto udto = new UserDto();
            UserServiceClient userclient = new UserServiceClient();
            udto = userclient.GetUserDetails(username, password,1);
            if (udto != null)
            {
                UserId = udto.UserId;
                if (UserId !=0)
                {
                    HttpContext.Current.Session["User"] = udto;                   
                }
            }
            return UserId;
        }
    }
