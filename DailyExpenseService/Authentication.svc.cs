using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using DailyExpenseDL;
using Classes;
using System.Net;

namespace DailyExpenseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Authentication" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Authentication.svc or Authentication.svc.cs at the Solution Explorer and start debugging.
    public class Authentication : IAuthentication
    {
        readonly DailyExpenseBL.Authentication.Authentication _authentication = new DailyExpenseBL.Authentication.Authentication();
        public void SaveUser(User user)
        {
            try
            {
                _authentication.Register(user);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public bool IsUserExist(string emailId)
        {
            try
            {
                return _authentication.UserExist(emailId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return false;
            }
        }

        public bool IsProfileCompleted(string emailId)
        {
            try
            {
                return _authentication.IsProfileCompleted(emailId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return false;
            }
        }

        public AuthenticationResult AuthenticateUser(User user)
        {
            try
            {
                return _authentication.AuthenticateUser(user);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<Classes.Country> CountrtyList()
        {
            try
            {
                return _authentication.CountrtyList();
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public bool IsFriendRequestExist(int userId)
        {
            try
            {
                return _authentication.friendRequestExist(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return false;
            }
        }
        public List<Notification> FriendRequest(int userId)
        {
            try
            {
                return _authentication.friendRequest(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public void FriendRequestAccept(int notificationId, int friendId)
        {
            try
            {
                _authentication.friendRequestAccept(notificationId, friendId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public void FriendRequestReject(int notificationId, int friendId)
        {
            try
            {
                _authentication.friendRequestReject(notificationId, friendId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public List<Classes.IncomeDetail> GetIncome(int userId)
        {
            try
            {
                return _authentication.GetIncome(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public void SaveIncome(int userId, string Amount)
        {
            try
            {
                _authentication.SaveIncome(userId, Amount);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public void UpdateProfile(int userId, string firstname, string lastname, int countryId, string mobileNo, string status)
        {
            try
            {
                _authentication.UpdateProfile(userId, firstname, lastname, countryId, mobileNo, status);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public List<User> GetUserProfile(int UserId)
        {
            try
            {
                return _authentication.GetUserProfile(UserId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public void SaveImage(byte[] image, int userId)
        {
            try
            {
                _authentication.SaveImage(image, userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }

        public void Inviteuser(string emailId, int UserId)
        {
            try
            {
                _authentication.Inviteuser(emailId, UserId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }

        public int UserProfileExist(string emailId)
        {
            try
            {
                return _authentication.UserProfileExist(emailId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return 0;
            }
        }

        public void SendInviteEmail(string emailId, string currentUser)
        {
            try
            {
                _authentication.SendInviteEmail(emailId, currentUser);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
    }
}
