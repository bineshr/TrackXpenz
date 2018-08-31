using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Classes;
namespace DailyExpenseService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExpense" in both code and config file together.
    [ServiceContract]
    public interface IExpense
    {
        [OperationContract]
        List<Classes.Product> ProductList();
        [OperationContract]
        void SavePersonelExpense(PersonelExpense expense);
        [OperationContract]
        List<ExpenseData> PersonelExpensebyDateList(DateTime fromDate, DateTime toDate, int userId);
        [OperationContract]
        List<ExpenseData> PersonelExpensebyProductList(int productId, int userId);
        [OperationContract]
        List<ChartData> resultOverallChart(int userId);
        [OperationContract]
        List<ChartData> chartOverallbyProductList(int productId, int userId);
        [OperationContract]
        List<ChartData> chartOverallbyDateList(DateTime fromDate, DateTime toDate, int userId);
        [OperationContract]
        List<ExpenseData> resultOverallData(int userId);
        [OperationContract]
        void UpdateStatus(string emailId, int userId);
        [OperationContract]
        List<FriendList> GetFriendsList(int UserId);
        [OperationContract]
        int SaveTripDetails(TripDetails tripDetails);
        [OperationContract]
        void FriendTripMapping(int tripId, string friendId, int userId);
        [OperationContract]
        void SaveFriendsTripExpenseEntry(SaveTripExpense saveTripExp);
        [OperationContract]
        List<TripExpenseItem> TripItemList();
        [OperationContract]
        List<TripFriends> GetTripFriends(int tripId);
        [OperationContract]
        List<TripHistoryList> GetTripHistory(int UserId);
        [OperationContract]
        List<UserList> GetUserList(int UserId);
        [OperationContract]
        List<TripHistoryList> GetUserTrips(int UserId);
        [OperationContract]
        List<ExpenseData> GetExpenseCurrentMonth(int userId);
        [OperationContract]
        double GetTotalExpenseCurrentMonth(int userId);
        [OperationContract]
        double GetTotalExpenseLastMonth(int userId);
        [OperationContract]
        List<TripDetails> GetTripExpenseByTotal(int tripId);
        [OperationContract]
        List<FriendList> GetNonTripFriend(int UserId, int tripId);
        [OperationContract]
        List<TripDetails> GetTripExpenseByUser(int tripId);
        [OperationContract]
        List<TripDetails> GetTripDetails(int tripId);
    }
}
