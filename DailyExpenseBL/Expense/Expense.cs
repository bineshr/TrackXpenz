using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace DailyExpenseBL.Expense
{
    public class Expense
    {
        readonly ExpenseDataAccess dataAccess = new ExpenseDataAccess();
        public List<Product> ProductList()
        {
            return dataAccess.ProductList();
        }
        public void SavePersonelExpense(PersonelExpense expense)
        {
            dataAccess.SavePersonelExpense(expense);
        }
        public List<ExpenseData> PersonelExpensebyDateList(DateTime fromDate, DateTime toDate, int userId)
        {
            return dataAccess.PersonelExpensebyDateList(fromDate, toDate, userId);
        }
        public List<ExpenseData> PersonelExpensebyProductList(int productId, int userId)
        {
            return dataAccess.PersonelExpensebyProductList(productId, userId);
        }
        public List<ChartData> resultOverallChart(int userId)
        {
            return dataAccess.resultOverallChart(userId);
        }
        public List<ChartData> chartOverallbyProductList(int productId, int userId)
        {
            return dataAccess.chartOverallbyProductList(productId, userId);
        }
        public List<ChartData> chartOverallbyDateList(DateTime fromDate, DateTime toDate, int userId)
        {
            return dataAccess.chartOverallbyDateList(fromDate, toDate, userId);
        }
        public List<ExpenseData> resultOverallData(int userId)
        {
            return dataAccess.resultOverallData(userId);
        }
        public void UpdateStatus(string emailId, int userId)
        {
            dataAccess.UpdateStatus(emailId, userId);
        }
        public List<FriendList> GetFriendsList(int UserId)
        {
            return dataAccess.GetFriendsList(UserId);
        }
        public int SaveTripDetails(TripDetails tripDetails)
        {
            return dataAccess.SaveTripDetails(tripDetails);
        }
        public void FriendTripMapping(int tripId, string friendId, int userId)
        {
            dataAccess.FriendTripMapping(tripId, friendId, userId);
        }
        public void SaveFriendsTripExpenseEntry(SaveTripExpense saveTripExp)
        {
            dataAccess.SaveFriendsTripExpenseEntry(saveTripExp);
        }
        public List<TripExpenseItem> TripItemList()
        {
            return dataAccess.TripItemList();
        }
        public List<TripFriends> GetTripFriends(int tripId)
        {
            return dataAccess.GetTripFriends(tripId);
        }
        public List<TripHistoryList> GetTripHistory(int UserId)
        {
            return dataAccess.GetTripHistory(UserId);
        }
        public List<UserList> GetUserList(int UserId)
        {
            return dataAccess.GetUserList(UserId);
        }
        public List<TripHistoryList> GetUserTrips(int UserId)
        {
            return dataAccess.GetUserTrips(UserId);
        }
        public List<ExpenseData> GetExpenseCurrentMonth(int userId)
        {
            return dataAccess.GetExpenseCurrentMonth(userId);
        }
        public double GetTotalExpenseCurrentMonth(int userId)
        {
            return dataAccess.GetTotalExpenseCurrentMonth(userId);
        }
        public double GetTotalExpenseLastMonth(int userId)
        {
            return dataAccess.GetTotalExpenseLastMonth(userId);
        }
        public List<TripDetails> GetTripExpenseByTotal(int tripId)
        {
            return dataAccess.GetTripExpenseByTotal(tripId);
        }
        public List<FriendList> GetNonTripFriend(int UserId, int tripId)
        {
            return dataAccess.GetNonTripFriend(UserId, tripId);
        }
        public List<TripDetails> GetTripExpenseByUser(int tripId)
        {
            return dataAccess.GetTripExpenseByUser(tripId);
        }
        public List<TripDetails> GetTripDetails(int tripId)
        {
            return dataAccess.GetTripDetails(tripId);
        }
    }
}

