using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DailyExpenseBL.Expense;
using DailyExpense.Expense;
using Classes;

namespace DailyExpense.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        private JsonResult JsonResponse(object s)
        {
            if (Request.RequestType == "GET")
                return Json(s, JsonRequestBehavior.AllowGet);
            return Json(s);
        }
        public ActionResult ExpenseHome()
        {
            return View();
        }
        public ActionResult PersonelExpense()
        {
            ExpenseClient _exp = new ExpenseClient();
            var product = new PersonelExpense()
            {
                Product = _exp.ProductList().ToList()
            };
            return View(product);
        }
        public JsonResult SavePersonelExpenses(int productId, string description, string date, string amount)
        {
            ExpenseClient _exp = new ExpenseClient();
            var expesne = new PersonelExpense
            {
                UserId = int.Parse(Session["UserId"].ToString()),
                ProductId = productId,
                Description = description,
                Date = Convert.ToDateTime(date),
                Amount = float.Parse(amount)
            };
            _exp.SavePersonelExpense(expesne);
            return JsonResponse(true);
        }
        public ActionResult CreateTitle()
        {
            return View();
        }
        public ActionResult TripDetails()
        {

            ExpenseClient _exp = new ExpenseClient();
            var friendsList = new TripDetails
            {
                FriendList = _exp.GetFriendsList(Convert.ToInt32(Session["UserId"].ToString())).ToList()
            };
            return View(friendsList);
        }
        public JsonResult AddFriends(string emailId)
        {
            ExpenseClient _exp = new ExpenseClient();
            var userId = Convert.ToInt32(Session["UserId"].ToString());
            _exp.UpdateStatus(emailId, userId);
            return JsonResponse(true);
        }
        public JsonResult SaveTrips(string tripTitle, string description, string startDate, string endDate, string friendsIds)
        {
            ExpenseClient _exp = new ExpenseClient();
            var trips = new TripDetails
            {
                UserId = int.Parse(Session["UserId"].ToString()),
                TripTitle = tripTitle,
                Description = description,
                fromDate = startDate,
                toDate = endDate,
            };
            var tripId = _exp.SaveTripDetails(trips);
            Session["TripId"] = tripId;
            _exp.FriendTripMapping(Convert.ToInt32(Session["TripId"].ToString()), friendsIds, Convert.ToInt32(Session["UserId"].ToString()));
            return JsonResponse(true);
        }
        public JsonResult AddFriendsInTrip(string friendsIds)
        {
            ExpenseClient _exp = new ExpenseClient();
            _exp.FriendTripMapping(Convert.ToInt32(Session["TripId"].ToString()), friendsIds, Convert.ToInt32(Session["UserId"].ToString()));
            return JsonResponse(true);
        }
        public JsonResult SaveTripExpense(int friendsId, int expenseOnId, string description, string dates, int amount)
        {
            ExpenseClient _exp = new ExpenseClient();
            var saveExpense = new SaveTripExpense()
            {
                UserId = int.Parse(Session["UserId"].ToString()),
                friendId = friendsId,
                tripId = int.Parse(Session["TripId"].ToString()),
                ExpenseOnId = expenseOnId,
                Description = description,
                Dates = dates,
                Amount = amount
            };
            _exp.SaveFriendsTripExpenseEntry(saveExpense);
            return JsonResponse(true);
        }
        public ActionResult TripExpenseEntry(int? tripId)
        {
            ExpenseClient _exp = new ExpenseClient();
            var items = new SaveTripExpense();
            if (Session["TripId"] != null)
            {
                items.TripItems = _exp.TripItemList().ToList();
                items.FriendList = _exp.GetTripFriends(Convert.ToInt32(Session["TripId"].ToString())).ToList();

            }
            else
            {
                Session["TripId"] = tripId;
                items.TripItems = _exp.TripItemList().ToList();
                items.FriendList = _exp.GetTripFriends(Convert.ToInt32(tripId)).ToList();
            }
            foreach (var frnds in items.FriendList)
            {
                if (frnds.Id == int.Parse(Session["UserId"].ToString()))
                {
                    frnds.Name = "You";
                }
            }
            items.GetFriends = _exp.GetNonTripFriend(Convert.ToInt32(Session["UserId"].ToString()), Convert.ToInt32(Session["TripId"].ToString())).ToList();
            foreach (var frnds in items.GetFriends)
            {
                if (frnds.Id == int.Parse(Session["UserId"].ToString()))
                {
                    frnds.Name = "You";
                }
            }
            items.tripExpbyTotal = _exp.GetTripExpenseByTotal(Convert.ToInt32(Session["TripId"].ToString())).ToList();
            items.tripExpbyUser= _exp.GetTripExpenseByUser(Convert.ToInt32(Session["TripId"].ToString())).ToList();
            return View(items);
        }
        public ActionResult TripHistory()
        {
            ExpenseClient _exp = new ExpenseClient();
            var trips = new TripHistory();
            trips.tripHistoryList = _exp.GetTripHistory(Convert.ToInt32(Session["UserId"].ToString())).ToList();
            trips.tripDetails = _exp.GetTripDetails(0).ToList();
            return View(trips);
        }
        public ActionResult SearchHome()
        {
            return View();
        }
        public ActionResult SearchPersonelExpense()
        {
            ExpenseClient _exp = new ExpenseClient();
            var product = new SearchPersonelExpense()
            {
                Product = _exp.ProductList().ToList()
            };
            return View(product);
        }
        public ActionResult ViewPersonelExpense()
        {
            ExpenseClient _exp = new ExpenseClient();
            var product = new SearchPersonelExpense();
            product.Product = _exp.ProductList().ToList();
            product.expense = _exp.GetExpenseCurrentMonth(int.Parse(Session["UserId"].ToString())).ToList();
            return View(product);
        }
        public ActionResult SearchTourExpense()
        {
            ExpenseClient _exp = new ExpenseClient();
            var searchTour = new SearchTourExpense()
            {
                Product = _exp.ProductList().ToList(),
                UserList = _exp.GetUserList(int.Parse(Session["UserId"].ToString())).ToList(),
                TripList = _exp.GetUserTrips(int.Parse(Session["UserId"].ToString())).ToList()
            };
            return View(searchTour);
        }
        public ActionResult GetExpenseByProduct(int proudctId)
        {
            ExpenseClient _exp = new ExpenseClient();
            var product = new SearchPersonelExpense();
            var UserId = int.Parse(Session["UserId"].ToString());
            product.expense = _exp.PersonelExpensebyProductList(proudctId, UserId).ToList();
            return PartialView("_LoadExpenseByProduct", product.expense);
        }
        public ActionResult GetExpenseByDate(string fromDate, string toDate)
        {
            ExpenseClient _exp = new ExpenseClient();
            var product = new SearchPersonelExpense();
            var UserId = int.Parse(Session["UserId"].ToString());
            var frDate = Convert.ToDateTime(fromDate);
            var tDate = Convert.ToDateTime(toDate);
            product.expense = _exp.PersonelExpensebyDateList(frDate, tDate, UserId).ToList();
            return PartialView("_LoadExpenseByDate", product.expense);
        }
        public ActionResult LoadTripHistory(int tripId)
        {
            ExpenseClient _exp = new ExpenseClient();
            var trips = new TripHistory();
            trips.tripDetails = _exp.GetTripDetails(tripId).ToList();
            return PartialView("_LoadTripHistory", trips.tripDetails);
        }
    }
}