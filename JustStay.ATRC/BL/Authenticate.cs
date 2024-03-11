using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JustStay.ATRC.UserServiceReference;
using JustStay.ATRC.ATRCServiceReference;

public class Authenticate
{
    public static int IsAuthenticated(string username, string password)
    {
        int UserId = 0;
        UserDto udto = new UserDto();
        UserServiceClient userclient = new UserServiceClient();
        udto = userclient.GetUserDetails(username, password, 2);
        if (udto != null)
        {
            UserId = udto.UserId;
            if (UserId != 0)
            {
                ATRCDto dto = new ATRCServiceClient().GetATRCByUserId(UserId);
                if (dto != null)
                {
                    udto.ATRCId = dto.ATRCId;
                    udto.ATRCStatus = dto.Status.Value;
                    udto.ATRCName = dto.ATRCName;
                }
                HttpContext.Current.Session["User"] = udto;
            }
        }
        return UserId;
    }
}
