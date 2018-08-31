using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Classes;
namespace DailyExpenseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthentication" in both code and config file together.
    [ServiceContract]
    public interface IAuthentication
    {
        [OperationContract]
        void SaveUser(User user);
        [OperationContract]
        bool IsUserExist(string emailId);
        [OperationContract]
        bool IsProfileCompleted(string emailId);
        [OperationContract]
        AuthenticationResult AuthenticateUser(User user);
        [OperationContract]
        List<Classes.Country> CountrtyList();
        [OperationContract]
        bool IsFriendRequestExist(int userId);
        [OperationContract]
        List<Notification> FriendRequest(int userId);
        [OperationContract]
        void FriendRequestAccept(int notificationId, int friendId);
        [OperationContract]
        void FriendRequestReject(int notificationId, int friendId);
        [OperationContract]
        List<Classes.IncomeDetail> GetIncome(int userId);
        [OperationContract]
        void SaveIncome(int userId, string Amount);
        [OperationContract]
        void UpdateProfile(int userId,string firstname, string lastname, int countryId, string mobileNo, string status);
        [OperationContract]
        List<User> GetUserProfile(int UserId);
        [OperationContract]
        void SaveImage(byte[] image, int userId);

        [OperationContract]
        void Inviteuser(string emailId, int UserId);
        [OperationContract]
        int UserProfileExist(string emailId);

        [OperationContract]
        void SendInviteEmail(string emailId, string currentUser);
        [OperationContract]
        void RemoveFriend(int userId, int friendId);
    }
}
