using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace DailyExpenseBL.Authentication
{
    public class Authentication
    {
        AuthenticationDataAccess dataAccess = new AuthenticationDataAccess();
        public void Register(User user)
        {
            dataAccess.Register(user);
        }
        public AuthenticationResult AuthenticateUser(User user)
        {
            return dataAccess.AuthenticateUser(user);
        }
        public bool UserExist(String emailId)
        {
            return dataAccess.UserExist(emailId);
        }
        public bool IsProfileCompleted(string emailId)
        {
            return dataAccess.IsProfileCompleted(emailId);
        }
        public List<Country> CountrtyList()
        {
            return dataAccess.CountrtyList();
        }
        public bool friendRequestExist(int userId)
        {
            return dataAccess.friendRequestExist(userId);
        }
        public List<Notification> friendRequest(int userId)
        {
            return dataAccess.friendRequest(userId);
        }
        public void friendRequestAccept(int notificationId, int friendId)
        {
            dataAccess.friendRequestAccept(notificationId, friendId);
        }
        public void friendRequestReject(int notificationId, int friendId)
        {
            dataAccess.friendRequestReject(notificationId, friendId);
        }
        public List<Classes.IncomeDetail> GetIncome(int userId)
        {
            return dataAccess.GetIncome(userId);
        }
        public void SaveIncome(int userId, string Amount)
        {
            dataAccess.SaveIncome(userId, Amount);
        }
        public void UpdateProfile(int userId, string firstname, string lastname, int countryId, string mobileNo, string status)
        {
            dataAccess.UpdateProfile(userId, firstname, lastname, countryId, mobileNo, status);
        }
        public List<User> GetUserProfile(int UserId)
        {
            return dataAccess.GetUserProfile(UserId);
        }
        public void SaveImage(byte[] image, int userId)
        {
            dataAccess.SaveImage(image, userId);
        }
        public void Inviteuser(string emailId, int UserId)
        {
            dataAccess.Inviteuser(emailId, UserId);
        }
        public int UserProfileExist(string emailId)
        {
            return dataAccess.UserProfileExist(emailId);
        }
        public void SendInviteEmail(string emailId, string currentUser)
        {
            dataAccess.SendInviteEmail(emailId, currentUser);
        }
    }
}
