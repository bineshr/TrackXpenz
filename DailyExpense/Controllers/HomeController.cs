using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Classes;
//using DailyExpenseBL.Authentication;
using DailyExpense.Models.Home;
using DailyExpense.Authentication;
using DailyExpense.Expense;

namespace DailyExpense.Controllers
{
    public class HomeController : Controller
    {
        private JsonResult JsonResponse(object s)
        {
            if (Request.RequestType == "GET")
                return Json(s, JsonRequestBehavior.AllowGet);
            return Json(s);
        }
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            Session.Clear();
            ViewBag.page = "Sign Up";

            AuthenticationClient authentication = new AuthenticationClient();
            var login = new Login();
            login.Country = authentication.CountrtyList().ToList();
            return View(login);
        }
        [HttpPost]
        public ActionResult SignIn(Login login)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            if (ModelState.IsValid)
            {
                var user = new User();
                user.EmailId = login.EmailId;
                user.Password = login.Password;
                var authenticate = authentication.AuthenticateUser(user);
                var loggedInUser = authenticate.CurrentUser;
                if (authenticate.IsAuthenticated)
                {
                    Session["UserId"] = loggedInUser.UserId;
                    Session["UserName"] = loggedInUser.FirstName + " " + loggedInUser.LastName;
                    Session["EmailId"] = loggedInUser.EmailId;
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ViewBag.LoginError = "* Incorrect Email or Password";
                    Session["Password"] = null;
                }
            }
            else
            {
                ViewBag.LoginError = "* Please Enter Email and Password";
                Session["Password"] = null;

            }
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            AuthenticationClient authentication = new AuthenticationClient();
            Session.Clear();
            ViewBag.page = "Sign In";
            var user = new User();
            user.Country = authentication.CountrtyList().ToList();
            return View(user);
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            if (ModelState.IsValid)
            {
                authentication.SaveUser(user);
            }
            else
            {
                user.Country = authentication.CountrtyList().ToList();
            }
            return View(user);
        }
        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("SignIn", "Home");
        }
        public JsonResult IsUserExist(string emailId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            var response = authentication.IsUserExist(emailId);
            return JsonResponse(response);
        }

        public JsonResult IsProfileCompleted(string emailId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            return JsonResponse(authentication.IsProfileCompleted(emailId));
        }

        public JsonResult SaveUserProfile(string emailId, string firstName, string lastName, string password, string mobileNo, string gender, int country)
        {
            AuthenticationClient authentication = new AuthenticationClient();

            var user = new User()
            {
                EmailId = emailId,
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                MobileNo = mobileNo,
                Gender = gender,
                CountryId = country
            };
            authentication.SaveUser(user);
            return JsonResponse(true);
        }

        public ActionResult HomePage()
        {
            AuthenticationClient authentication = new AuthenticationClient();

            var homepage = new Homepage()
            {
                notification = authentication.FriendRequest(Convert.ToInt32(Session["UserId"].ToString())).ToList()
            };
            Session["NotificationCount"] = homepage.notification.Count();
            Session["Notifications"] = homepage.notification;
            return View(homepage);
        }
        public ActionResult Dashboard()
        {
            AuthenticationClient authentication = new AuthenticationClient();
            ExpenseClient _exp = new ExpenseClient();

            var homepage = new Homepage();
            homepage.notification = authentication.FriendRequest(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            //homepage.IncomeDetails = authentication.GetIncome(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            homepage.UserProfile = authentication.GetUserProfile(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            homepage.GetFriendslist = _exp.GetFriendsList(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            homepage.amount = _exp.GetTotalExpenseCurrentMonth(Convert.ToInt32(Session["UserId"].ToString()));
            homepage.LastmonthAmount = _exp.GetTotalExpenseLastMonth(Convert.ToInt32(Session["UserId"].ToString()));
            homepage.chartByProd = _exp.resultOverallChart(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            Session["Profile"] = homepage.UserProfile;
            Session["NotificationCount"] = homepage.notification.Count();
            Session["Notifications"] = homepage.notification;
            return View(homepage);
        }
        [FilterConfig.SessionExpireFilter]
        public JsonResult Notification()
        {
            AuthenticationClient authentication = new AuthenticationClient();
            var homepage = new Homepage();
            if (Session["UserId"].ToString() != null)
            {
                homepage.notification = authentication.FriendRequest(Convert.ToInt32(Session["UserId"].ToString())).ToList();
                homepage.UserProfile = authentication.GetUserProfile(Convert.ToInt32(Session["UserId"].ToString())).ToList();
                Session["Profile"] = homepage.UserProfile;
                Session["NotificationCount"] = homepage.notification.Count();
                Session["Notifications"] = homepage.notification;
            }
            //Response.AddHeader("Refresh", "5");
            return JsonResponse(homepage);
        }
        public JsonResult IsFriendRequestExists()
        {
            AuthenticationClient authentication = new AuthenticationClient();
            return JsonResponse(authentication.IsFriendRequestExist(Convert.ToInt32(Session["UserId"].ToString())));
        }
        public JsonResult SaveIncome(string amount)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            authentication.SaveIncome(Convert.ToInt32(Session["UserId"].ToString()), amount);
            return JsonResponse(true);
        }
        public JsonResult AcceptFriendRequest(int notificationId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            authentication.FriendRequestAccept(notificationId, Convert.ToInt32(Session["UserId"].ToString()));
            authentication.FriendRequest(Convert.ToInt32(Session["UserId"].ToString()));
            return JsonResponse(true);
        }
        public JsonResult RejectFriendRequest(int notificationId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            authentication.FriendRequestReject(notificationId, Convert.ToInt32(Session["UserId"].ToString()));
            authentication.FriendRequest(Convert.ToInt32(Session["UserId"].ToString()));
            return JsonResponse(true);
        }
        public JsonResult ImageUpload(string imgSrc)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            byte[] bytes = Convert.FromBase64String(imgSrc.Split(',')[1]);
            authentication.SaveImage(bytes, Convert.ToInt32(Session["UserId"].ToString()));
            return JsonResponse(true);
        }
        public ActionResult ProfileView()
        {
            AuthenticationClient authentication = new AuthenticationClient();
            ExpenseClient _exp = new ExpenseClient();
            var profile = new Userprofile();
            profile.UserProfile = authentication.GetUserProfile(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            profile.Country = authentication.CountrtyList().ToList();
            profile.Friends=_exp.GetFriendsList(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            return View(profile);
        }
        public JsonResult UpdateProfile(string firstname, string lastname, int countryId, string mobileNo, string status)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            authentication.UpdateProfile(Convert.ToInt32(Session["UserId"].ToString()), firstname, lastname, countryId, mobileNo, status);
            return JsonResponse(true);
        }
        public JsonResult RemoveFriend(int friendId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            authentication.RemoveFriend(Convert.ToInt32(Session["UserId"].ToString()), friendId);
            return JsonResponse(true);
        }
        public JsonResult GetChartByProductName()
        {
           
            ExpenseClient _exp = new ExpenseClient();
            return JsonResponse(_exp.resultOverallChart(Convert.ToInt32(Session["UserId"].ToString())));
        }

        public JsonResult InviteUser(string emailId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            authentication.Inviteuser(emailId, Convert.ToInt32(Session["UserId"].ToString()));
            return JsonResponse(true);
        }

        public JsonResult IsUserProfileExist(string emailId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            var statusId = authentication.UserProfileExist(emailId);
            return JsonResponse(statusId);
        }

        public JsonResult AddFriends(string emailId)
        {
            ExpenseClient _exp = new ExpenseClient();
            _exp.UpdateStatus(emailId, Convert.ToInt32(Session["UserId"].ToString()));
            return JsonResponse(true);
        }

        public JsonResult SendEmailNotification(string emailId)
        {
            AuthenticationClient authentication = new AuthenticationClient();
            authentication.SendInviteEmail(emailId, Session["EmailId"].ToString());
            return JsonResponse(true);
        }
    }
}