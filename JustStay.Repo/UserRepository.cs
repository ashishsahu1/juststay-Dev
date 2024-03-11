using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace JustStay.Repo
{
    public class UserRepository
    {
        juststayDbEntities entities;
        public UserRepository()
        {
            entities = new juststayDbEntities();
        }

        public User GetUserbyId(int uid)
        {
            return entities.Users.FirstOrDefault(u => u.UserId == uid);
        }
        public int GetUserIdByEmailAndUserType(string email, string userType)
        {
            User user = (from u in entities.Users
                         join ut in entities.UserTypes on u.UserTypeId equals ut.UserTypeId
                         where u.Email == email && (ut.UserType1 == userType || "" == userType)
                         select u).FirstOrDefault();

            return (user != null ? user.UserId : 0);
        }

        //public User GetUserByUsernameAndType(string userName, int usertypeid)
        //{
        //    return entities.Users.FirstOrDefault(u => u.Username == userName && u.UserTypeId == usertypeid);
        //}

        public User GetCustUserByUsernameOrMobile(string userName)
        {
            return entities.Users.FirstOrDefault(u => (u.Username == userName || u.Mobile == userName) && u.UserTypeId == 3);
        }

        public int InsertUser(User user)
        {
            entities.Users.Add(user);
            entities.SaveChanges();
            return user.UserId;
        }

        public void UpdateUser()
        {
            entities.SaveChanges();
        }

        public int UpdateUserPwd(int id, string pwd)
        {
            User uu = entities.Users.FirstOrDefault(info => info.UserId == id);
            if (uu == null) return 0;

            uu.Password = pwd;
            entities.SaveChanges();
            return uu.UserId;
        }
        public int UpdateUser(int id, string Name,string mobile,string email,string isactive)
        {
            User uu = entities.Users.FirstOrDefault(info => info.UserId == id);
            if (uu == null) return 0;

            uu.Name = Name;
            uu.Mobile = mobile;
            uu.Email = email;
            uu.IsActive = Convert.ToBoolean(isactive);
            entities.SaveChanges();
            return uu.UserId;
        }

        public User GetUserDetails(string username, string password, int usertypeid)
        {
            return entities.Users.FirstOrDefault(u =>
                  (u.Username == username || (u.Mobile == username && usertypeid == 3)) && u.Password == password && u.UserTypeId == usertypeid);

        }
        public List<UserDetail> getAllUser()
        {
            return entities.GetUserDetail().ToList();
        }

        public int DeleteUser(int id)
        {
            var x = entities.Users.FirstOrDefault(i => i.UserId == id);
            entities.Users.Remove(x);
            return entities.SaveChanges();
        }

        public bool IsEmailExist(string email, int userTypeId)
        {
            return entities.Users.Any(e => e.Email == email && e.UserTypeId == userTypeId); //(from e in entities.Users where e.Email == email select e.UserId).FirstOrDefault();
        }

        public List<EmailInfo> GetEmailList(string userName, string mode)
        {
            return entities.GetEmailsList(userName, mode).ToList();
        }

        public bool IsMobileExist(string mobile, int userTypeId)
        {
            return entities.Users.Any(u => u.Mobile == mobile && u.UserTypeId == userTypeId);
        }

        public User GetGoogleUser(string googleId)
        {
            return entities.Users.FirstOrDefault(u => u.Google_Id == googleId);
        }

        public void UpdateUserGoogleId(int userId,string googleId)
        {
            User uu = entities.Users.FirstOrDefault(info => info.UserId == userId);
            uu.Google_Id = googleId;
            entities.SaveChanges();
        }

        public bool ChangeUserPassword(int userId, string newpass, string cnfpass)
        {
            bool response=false;
            if (newpass == cnfpass)
            {
                User uu = entities.Users.FirstOrDefault(info => info.UserId == userId);
                uu.Password = newpass;
                entities.SaveChanges();
                response = true;
            }
            return response;
        }
        public int UpdateUser(User usr)
        {
            User uu = entities.Users.FirstOrDefault(info => info.UserId == usr.UserId);
            if (uu == null) return 0;

            uu.Name = usr.Name;
            uu.Mobile = usr.Mobile;
            uu.Email = usr.Email;
            uu.Address = usr.Address;
            entities.SaveChanges();
            return uu.UserId;
        }
    }
}
