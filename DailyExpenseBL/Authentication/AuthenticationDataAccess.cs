using System;
using System.Collections.Generic;
using System.Linq;
using DailyExpenseDL;
using Classes;
using System.Net.Mail;
using Country = Classes.Country;
using System.Configuration;
using System.Net;

namespace DailyExpenseBL.Authentication
{
    public class AuthenticationDataAccess
    {
        //readonly ExpenseEntities _db = new ExpenseEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["ExpenseEntities"].ConnectionString;
        private ExpenseEntities _db = ExpenseEntities.CreateEntitiesForSpecificDatabaseName(connectionString);
        public void Register(User user)
        {
            var usr = new UsersInfo();
            var UserDetails = _db.UsersInfoes.FirstOrDefault(a => a.EmailId == user.EmailId);
            Guid uniqueId;
            uniqueId = Guid.NewGuid();
            if (UserDetails != null)
            {
                if (UserDetails.Status_Flag == false)
                {
                    UserDetails.FirstName = user.FirstName;
                    UserDetails.LastName = user.LastName;
                    UserDetails.Password = user.Password;
                    UserDetails.MobileNo = user.MobileNo;
                    UserDetails.Gender = user.Gender;
                    UserDetails.CountryId = user.CountryId;
                    UserDetails.Created_On = DateTime.Now;
                    UserDetails.IsActive = true;
                    UserDetails.Status_Flag = true;
                    UserDetails.UniqueId = uniqueId.ToString();
                    using (_db)
                    {
                        _db.SaveChanges();
                    }
                }
            }
            else
            {
                usr.EmailId = user.EmailId;
                usr.Password = user.Password;
                usr.FirstName = user.FirstName;
                usr.LastName = user.LastName;
                usr.MobileNo = user.MobileNo;
                usr.Gender = user.Gender;
                usr.CountryId = user.CountryId;
                usr.Created_On = DateTime.Now;
                usr.IsActive = true;
                usr.Status_Flag = true;
                usr.UniqueId = uniqueId.ToString();
                using (_db)
                {
                    _db.UsersInfoes.Add(usr);
                    _db.SaveChanges();
                }
            }

        }
        public AuthenticationResult AuthenticateUser(User user)
        {
            var authResult = new AuthenticationResult();
            try
            {
                //var userss = _db.UsersInfoes.FirstOrDefault(a => a.EmailId == user.EmailId && a.Password == user.Password);
                var UserDetails = _db.UsersInfoes.FirstOrDefault(a => a.EmailId == user.EmailId && a.Password == user.Password);
                var tripHistory = _db.TripDetails.Count(a => a.UserId == UserDetails.Id);
                if (UserDetails != null)
                {
                    var profile = new User
                    {
                        FirstName = UserDetails.FirstName,
                        LastName = UserDetails.LastName,
                        UserId = UserDetails.Id,
                        EmailId = UserDetails.EmailId
                    };
                    triphistoryUpdate(UserDetails.Id);
                    authResult.IsAuthenticated = true;
                    authResult.CurrentUser = profile;
                }
            }
            catch (Exception ex)
            {

            }
            return authResult;
        }
        public bool UserExist(string emailId)
        {
            var userExists = _db.UsersInfoes.Any(a => a.EmailId == emailId);
            return (userExists);
        }

        public bool IsProfileCompleted(string emailId)
        {
            var userExists = _db.UsersInfoes.Any(a => a.EmailId == emailId && a.Status_Flag == true);
            return (userExists);
        }

        public List<Country> CountrtyList()
        {
            var countries = new List<Country>();
            var country = _db.Countries.ToList();
            countries.AddRange(country.Select(a => new Country
            {
                Id = a.Id,
                Name = a.Name
            }));
            return countries;
        }
        public bool friendRequestExist(int userId)
        {
            var request = (from frndList in _db.FriendsLists
                           where frndList.FriendId == userId && frndList.Active == 1
                           select new { frndList.Id });

            if (request.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<Notification> friendRequest(int userId)
        {
            var notify = new List<Notification>();
            var notification = from frndList in _db.FriendsLists
                               join usr in _db.UsersInfoes on frndList.UserId equals usr.Id
                               where frndList.FriendId == userId && frndList.Active == 1
                               select new { usr.FirstName, usr.LastName, usr.EmailId, frndList.Id, frndList.Created_On };
            if (notification.Count() != 0)
            {

                notify.AddRange(notification.Select(a => new Notification
                {
                    friendUserName = a.FirstName + " " + a.LastName,
                    friendEmailId = a.EmailId,
                    notificationId = a.Id,
                    requestDate = a.Created_On.ToString()
                }));
            }
            return notify;
        }
        public void friendRequestAccept(int notificationId, int friendId)
        {
            var acceptReq = _db.FriendsLists.FirstOrDefault(a => a.Id == notificationId && a.FriendId == friendId);
            acceptReq.Active = 2;
            acceptReq.Updated_on = DateTime.Now;
            _db.SaveChanges();
        }
        public void friendRequestReject(int notificationId, int friendId)
        {
            var acceptReq = _db.FriendsLists.FirstOrDefault(a => a.Id == notificationId && a.FriendId == friendId);
            acceptReq.Active = 0;
            acceptReq.Updated_on = DateTime.Now;
            _db.SaveChanges();
        }
        public void triphistoryUpdate(int userId)
        {
            var history = from hist in _db.TripDetails
                          where hist.UserId == userId
                          select hist;
            if (history.Count() != 0)
            {
                foreach (var hist in history)
                {
                    if (Convert.ToDateTime(hist.EndDate) < DateTime.Now || Convert.ToDateTime(hist.EndDate) == DateTime.Now)
                    {
                        hist.Status = false;
                    }
                }
            }
            _db.SaveChanges();
        }
        public List<Classes.IncomeDetail> GetIncome(int userId)
        {
            var income = new List<Classes.IncomeDetail>();
            var usrIncome = from inc in _db.IncomeDetails
                            where inc.UserId == userId
                            select new { inc.Amount, inc.Created_On };
            income.AddRange(usrIncome.Select(a => new Classes.IncomeDetail
            {
                amount = a.Amount,
                createdOn = (DateTime)a.Created_On
            }));
            return income;
        }
        public void SaveIncome(int userId, string Amount)
        {
            var saveInc = new DailyExpenseDL.IncomeDetail();
            saveInc.UserId = userId;
            saveInc.Amount = Amount;
            saveInc.Amount = DateTime.Now.ToString();
            _db.IncomeDetails.Add(saveInc);
            _db.SaveChanges();
        }
        public void UpdateProfile(int userId, string firstname, string lastname, int countryId, string mobileNo, string status)
        {
            var users = (from usr in _db.UsersInfoes.Where(a => a.Id == userId) select usr).FirstOrDefault();
            if (users != null)
            {
                users.FirstName = firstname;
                users.LastName = lastname;
                users.MobileNo = mobileNo;
                users.CountryId = countryId;
                users.Created_On = DateTime.Now;
                users.Status = status;
            }
            _db.SaveChanges();
        }
        public List<User> GetUserProfile(int UserId)
        {
            List<User> usrProfile = new List<User>();
            var users = (from usr in _db.UsersInfoes
                         join cntry in _db.Countries on usr.CountryId equals cntry.Id
                         where usr.Id == UserId
                         select new { usr.FirstName, usr.LastName, usr.MobileNo, usr.Status, usr.CountryId, cntry.Name, usr.Image }).FirstOrDefault();
            if (users != null)
            {
                var usr = new User
                {
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    CountryId = (int)users.CountryId,
                    CountryName = users.Name,
                    MobileNo = users.MobileNo,
                    Status = users.Status,
                    picture = (users.Image != null) ? Convert.ToBase64String(users.Image) : null,
                };
                usrProfile.Add(usr);

            }
            return usrProfile;
        }
        public void SaveImage(byte[] image, int userId)
        {
            var users = (from usr in _db.UsersInfoes.Where(a => a.Id == userId) select usr).FirstOrDefault();
            if (users != null)
            {
                users.Image = image;
            }
            _db.SaveChanges();
            //var saveImg = new UsersInfo();
            //saveImg.Image = image;
            //_db.UsersInfoes.Add(saveImg);
            //_db.SaveChanges();
        }


        public int UserProfileExist(string emailId)
        {
            var userExists = _db.UsersInfoes.FirstOrDefault(a => a.EmailId == emailId);
            if (userExists != null)
            {
                if (userExists.Status_Flag == true)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 3;
            }
        }

        public void Inviteuser(string emailId, int UserId)
        {
            var userDetails = _db.UsersInfoes.FirstOrDefault(a => a.EmailId == emailId);
            Guid uniqueId;
            uniqueId = Guid.NewGuid();
            if (userDetails == null)
            {
                var user = new UsersInfo
                {
                    EmailId = emailId,
                    UniqueId = uniqueId.ToString(),
                    Status_Flag = false,
                    IsActive = false
                };
                using (_db)
                {
                    _db.UsersInfoes.Add(user);
                    _db.SaveChanges();
                }
            }

            UpdateStatus(emailId, UserId);
            //SendEmailInvite(emailId);
        }

        public void UpdateStatus(string emailId, int userId)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseEntities"].ConnectionString;
            ExpenseEntities _dbcontext1 = ExpenseEntities.CreateEntitiesForSpecificDatabaseName(connectionString);

            var currentUser = (from usr in _dbcontext1.UsersInfoes
                               where usr.EmailId == emailId
                               select new { usr.Id, usr.EmailId });
            if (currentUser != null)
            {
                var friendId = currentUser.FirstOrDefault().Id;
                if (friendId != 0)
                {
                    var frndList = new FriendsList()
                    {
                        FriendId = friendId,
                        UserId = userId,
                        Active = 1,
                        Created_On = DateTime.Now,
                        Updated_on = DateTime.Now
                    };
                    _dbcontext1.FriendsLists.Add(frndList);
                    _dbcontext1.SaveChanges();
                }
                SendInviteEmail(emailId, currentUser.FirstOrDefault().EmailId);
            }



        }

        public void SendInviteEmail(string emailId, string currentUser)
        {
            var senderEmail = new MailAddress("trackerxpenz@gmail.com", "Expense");
            var receiverEmail = new MailAddress(emailId, "Receiver");
            var password = "tracker@123";
            var sub = "Notification";

            var body = "<!doctype html> <html> <head> <meta name='viewport' content='width=device-width'> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <title>Notifications</title> <style> </style> </head> <body class='' style='background-color: #f6f6f6; font-family: sans-serif;'> <table border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background-color: #f6f6f6;'> <tr> <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>&nbsp;</td> <td class='container' style='font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; Margin: 0 auto; max-width: 580px; padding: 10px; width: 580px;'> <div class='content' style='box-sizing: border-box; display: block; Margin: 0 auto; max-width: 580px; padding: 10px;'> <table class='main' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #ffffff; border-radius: 3px;'> <tr> <td class='wrapper' style='font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;'> <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'> <tr> <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'> <p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>Hi,</p> <p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>Welcome to Expense Tracker! You have been invited by " + currentUser + " to become a user of Expense Tracker</p> <p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>Use the link below to activate your user account</p> <table border='0' cellpadding='0' cellspacing='0' class='btn btn-primary' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; box-sizing: border-box;'> <tbody> <tr> <td align='left' style='font-family: sans-serif; font-size: 14px; vertical-align: top; padding-bottom: 15px;'> <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: auto;'> <tbody> <tr> <td style='font-family: sans-serif; font-size: 14px; vertical-align: top; background-color: #3498db; border-radius: 5px; text-align: center;'> <a href='http://localhost:21721/Home/Login' target='_blank' style='display: inline-block; color: #ffffff; background-color: #3498db; border: solid 1px #3498db; border-radius: 5px; box-sizing: border-box; cursor: pointer; text-decoration: none; font-size: 14px; font-weight: bold; margin: 0; padding: 12px 25px; text-transform: capitalize; border-color: #3498db;'>Sign Up Here</a> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> <p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 10px;'>Thanks,</p> <p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 10px;'>Expense Tracker Team.</p> </td> </tr> </table> </td> </tr> </table> <div class='footer' style='clear: both; Margin-top: 10px; text-align: center; width: 100%;'> <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'> <tr> <td class='content-block' style='font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;'> <span class='apple-link' style='color: #999999; font-size: 12px; text-align: center;'>Copyright &copy; 2017-2018 ll rights reserved.</span> </td> </tr> <tr> <td class='content-block powered-by' style='font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;'> Powered by <a href='http://localhost:21721/Home/Login' style='color: #999999; font-size: 12px; text-align: center; text-decoration: none;'>Expense Tracker</a>. </td> </tr> </table> </div> </div> </td> <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>&nbsp;</td> </tr> </table> </body> </html>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {

                Subject = sub,
                Body = body
            })

            {
                mess.IsBodyHtml = true;
                smtp.Send(mess);
            }

        }
    }
}
