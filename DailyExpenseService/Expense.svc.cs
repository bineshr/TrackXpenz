using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Classes;
using System.ServiceModel.Web;
using System.Net;

namespace DailyExpenseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Expense" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Expense.svc or Expense.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Expense : IExpense
    {
        readonly DailyExpenseBL.Expense.Expense _expense = new DailyExpenseBL.Expense.Expense();
        public List<Classes.Product> ProductList()
        {
            try
            {
                return _expense.ProductList();
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public void SavePersonelExpense(PersonelExpense expense)
        {
            try
            {
                _expense.SavePersonelExpense(expense);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public List<ExpenseData> PersonelExpensebyDateList(DateTime fromDate, DateTime toDate, int userId)
        {
            try
            {
                return _expense.PersonelExpensebyDateList(fromDate, toDate, userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<ExpenseData> PersonelExpensebyProductList(int productId, int userId)
        {
            try
            {
                return _expense.PersonelExpensebyProductList(productId, userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<ChartData> resultOverallChart(int userId)
        {
            try
            {
                return _expense.resultOverallChart(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<ChartData> chartOverallbyProductList(int productId, int userId)
        {
            try
            {
                return _expense.chartOverallbyProductList(productId, userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<ChartData> chartOverallbyDateList(DateTime fromDate, DateTime toDate, int userId)
        {
            try
            {
                return _expense.chartOverallbyDateList(fromDate, toDate, userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<ExpenseData> resultOverallData(int userId)
        {
            try
            {
                return _expense.resultOverallData(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public void UpdateStatus(string emailId, int userId)
        {
            try
            {
                _expense.UpdateStatus(emailId, userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public List<FriendList> GetFriendsList(int UserId)
        {
            try
            {
                return _expense.GetFriendsList(UserId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public int SaveTripDetails(TripDetails tripDetails)
        {
            try
            {
                return _expense.SaveTripDetails(tripDetails);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return 0;
            }
        }
        public void FriendTripMapping(int tripId, string friendId, int userId)
        {
            try
            {
                _expense.FriendTripMapping(tripId, friendId, userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public void SaveFriendsTripExpenseEntry(SaveTripExpense saveTripExp)
        {
            try
            {
                _expense.SaveFriendsTripExpenseEntry(saveTripExp);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
            }
        }
        public List<TripExpenseItem> TripItemList()
        {
            try
            {
                return _expense.TripItemList();
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<TripFriends> GetTripFriends(int tripId)
        {
            try
            {
                return _expense.GetTripFriends(tripId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<TripHistoryList> GetTripHistory(int UserId)
        {
            try
            {
                return _expense.GetTripHistory(UserId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<UserList> GetUserList(int UserId)
        {
            try
            {
                return _expense.GetUserList(UserId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<TripHistoryList> GetUserTrips(int UserId)
        {
            try
            {
                return _expense.GetUserTrips(UserId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<ExpenseData> GetExpenseCurrentMonth(int userId)
        {
            try
            {
                return _expense.GetExpenseCurrentMonth(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public double GetTotalExpenseCurrentMonth(int userId)
        {
            try
            {
                return _expense.GetTotalExpenseCurrentMonth(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return 0;
            }
        }
        public double GetTotalExpenseLastMonth(int userId)
        {
            try
            {
                return _expense.GetTotalExpenseLastMonth(userId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return 0;
            }
        }
        public List<TripDetails> GetTripExpenseByTotal(int tripId)
        {
            try
            {
                return _expense.GetTripExpenseByTotal(tripId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<FriendList> GetNonTripFriend(int UserId, int tripId)
        {
            try
            {
                return _expense.GetNonTripFriend(UserId,tripId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<TripDetails> GetTripExpenseByUser(int tripId)
        {
            try
            {
                return _expense.GetTripExpenseByUser(tripId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
        public List<TripDetails> GetTripDetails(int tripId)
        {
            try
            {
                return _expense.GetTripDetails(tripId);
            }
            catch (Exception e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.PreconditionFailed;
                WebOperationContext.Current.OutgoingResponse.StatusDescription = e.Message;
                return null;
            }
        }
    }
}
