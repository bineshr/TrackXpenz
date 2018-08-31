﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DailyExpense.Expense {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Expense.IExpense")]
    public interface IExpense {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/ProductList", ReplyAction="http://tempuri.org/IExpense/ProductListResponse")]
        Classes.Product[] ProductList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/ProductList", ReplyAction="http://tempuri.org/IExpense/ProductListResponse")]
        System.Threading.Tasks.Task<Classes.Product[]> ProductListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/SavePersonelExpense", ReplyAction="http://tempuri.org/IExpense/SavePersonelExpenseResponse")]
        void SavePersonelExpense(Classes.PersonelExpense expense);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/SavePersonelExpense", ReplyAction="http://tempuri.org/IExpense/SavePersonelExpenseResponse")]
        System.Threading.Tasks.Task SavePersonelExpenseAsync(Classes.PersonelExpense expense);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/PersonelExpensebyDateList", ReplyAction="http://tempuri.org/IExpense/PersonelExpensebyDateListResponse")]
        Classes.ExpenseData[] PersonelExpensebyDateList(System.DateTime fromDate, System.DateTime toDate, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/PersonelExpensebyDateList", ReplyAction="http://tempuri.org/IExpense/PersonelExpensebyDateListResponse")]
        System.Threading.Tasks.Task<Classes.ExpenseData[]> PersonelExpensebyDateListAsync(System.DateTime fromDate, System.DateTime toDate, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/PersonelExpensebyProductList", ReplyAction="http://tempuri.org/IExpense/PersonelExpensebyProductListResponse")]
        Classes.ExpenseData[] PersonelExpensebyProductList(int productId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/PersonelExpensebyProductList", ReplyAction="http://tempuri.org/IExpense/PersonelExpensebyProductListResponse")]
        System.Threading.Tasks.Task<Classes.ExpenseData[]> PersonelExpensebyProductListAsync(int productId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/resultOverallChart", ReplyAction="http://tempuri.org/IExpense/resultOverallChartResponse")]
        Classes.ChartData[] resultOverallChart(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/resultOverallChart", ReplyAction="http://tempuri.org/IExpense/resultOverallChartResponse")]
        System.Threading.Tasks.Task<Classes.ChartData[]> resultOverallChartAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/chartOverallbyProductList", ReplyAction="http://tempuri.org/IExpense/chartOverallbyProductListResponse")]
        Classes.ChartData[] chartOverallbyProductList(int productId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/chartOverallbyProductList", ReplyAction="http://tempuri.org/IExpense/chartOverallbyProductListResponse")]
        System.Threading.Tasks.Task<Classes.ChartData[]> chartOverallbyProductListAsync(int productId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/chartOverallbyDateList", ReplyAction="http://tempuri.org/IExpense/chartOverallbyDateListResponse")]
        Classes.ChartData[] chartOverallbyDateList(System.DateTime fromDate, System.DateTime toDate, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/chartOverallbyDateList", ReplyAction="http://tempuri.org/IExpense/chartOverallbyDateListResponse")]
        System.Threading.Tasks.Task<Classes.ChartData[]> chartOverallbyDateListAsync(System.DateTime fromDate, System.DateTime toDate, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/resultOverallData", ReplyAction="http://tempuri.org/IExpense/resultOverallDataResponse")]
        Classes.ExpenseData[] resultOverallData(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/resultOverallData", ReplyAction="http://tempuri.org/IExpense/resultOverallDataResponse")]
        System.Threading.Tasks.Task<Classes.ExpenseData[]> resultOverallDataAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/UpdateStatus", ReplyAction="http://tempuri.org/IExpense/UpdateStatusResponse")]
        void UpdateStatus(string emailId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/UpdateStatus", ReplyAction="http://tempuri.org/IExpense/UpdateStatusResponse")]
        System.Threading.Tasks.Task UpdateStatusAsync(string emailId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetFriendsList", ReplyAction="http://tempuri.org/IExpense/GetFriendsListResponse")]
        Classes.FriendList[] GetFriendsList(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetFriendsList", ReplyAction="http://tempuri.org/IExpense/GetFriendsListResponse")]
        System.Threading.Tasks.Task<Classes.FriendList[]> GetFriendsListAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/SaveTripDetails", ReplyAction="http://tempuri.org/IExpense/SaveTripDetailsResponse")]
        int SaveTripDetails(Classes.TripDetails tripDetails);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/SaveTripDetails", ReplyAction="http://tempuri.org/IExpense/SaveTripDetailsResponse")]
        System.Threading.Tasks.Task<int> SaveTripDetailsAsync(Classes.TripDetails tripDetails);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/FriendTripMapping", ReplyAction="http://tempuri.org/IExpense/FriendTripMappingResponse")]
        void FriendTripMapping(int tripId, string friendId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/FriendTripMapping", ReplyAction="http://tempuri.org/IExpense/FriendTripMappingResponse")]
        System.Threading.Tasks.Task FriendTripMappingAsync(int tripId, string friendId, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/SaveFriendsTripExpenseEntry", ReplyAction="http://tempuri.org/IExpense/SaveFriendsTripExpenseEntryResponse")]
        void SaveFriendsTripExpenseEntry(Classes.SaveTripExpense saveTripExp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/SaveFriendsTripExpenseEntry", ReplyAction="http://tempuri.org/IExpense/SaveFriendsTripExpenseEntryResponse")]
        System.Threading.Tasks.Task SaveFriendsTripExpenseEntryAsync(Classes.SaveTripExpense saveTripExp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/TripItemList", ReplyAction="http://tempuri.org/IExpense/TripItemListResponse")]
        Classes.TripExpenseItem[] TripItemList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/TripItemList", ReplyAction="http://tempuri.org/IExpense/TripItemListResponse")]
        System.Threading.Tasks.Task<Classes.TripExpenseItem[]> TripItemListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripFriends", ReplyAction="http://tempuri.org/IExpense/GetTripFriendsResponse")]
        Classes.TripFriends[] GetTripFriends(int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripFriends", ReplyAction="http://tempuri.org/IExpense/GetTripFriendsResponse")]
        System.Threading.Tasks.Task<Classes.TripFriends[]> GetTripFriendsAsync(int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripHistory", ReplyAction="http://tempuri.org/IExpense/GetTripHistoryResponse")]
        Classes.TripHistoryList[] GetTripHistory(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripHistory", ReplyAction="http://tempuri.org/IExpense/GetTripHistoryResponse")]
        System.Threading.Tasks.Task<Classes.TripHistoryList[]> GetTripHistoryAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetUserList", ReplyAction="http://tempuri.org/IExpense/GetUserListResponse")]
        Classes.UserList[] GetUserList(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetUserList", ReplyAction="http://tempuri.org/IExpense/GetUserListResponse")]
        System.Threading.Tasks.Task<Classes.UserList[]> GetUserListAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetUserTrips", ReplyAction="http://tempuri.org/IExpense/GetUserTripsResponse")]
        Classes.TripHistoryList[] GetUserTrips(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetUserTrips", ReplyAction="http://tempuri.org/IExpense/GetUserTripsResponse")]
        System.Threading.Tasks.Task<Classes.TripHistoryList[]> GetUserTripsAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetExpenseCurrentMonth", ReplyAction="http://tempuri.org/IExpense/GetExpenseCurrentMonthResponse")]
        Classes.ExpenseData[] GetExpenseCurrentMonth(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetExpenseCurrentMonth", ReplyAction="http://tempuri.org/IExpense/GetExpenseCurrentMonthResponse")]
        System.Threading.Tasks.Task<Classes.ExpenseData[]> GetExpenseCurrentMonthAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTotalExpenseCurrentMonth", ReplyAction="http://tempuri.org/IExpense/GetTotalExpenseCurrentMonthResponse")]
        double GetTotalExpenseCurrentMonth(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTotalExpenseCurrentMonth", ReplyAction="http://tempuri.org/IExpense/GetTotalExpenseCurrentMonthResponse")]
        System.Threading.Tasks.Task<double> GetTotalExpenseCurrentMonthAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTotalExpenseLastMonth", ReplyAction="http://tempuri.org/IExpense/GetTotalExpenseLastMonthResponse")]
        double GetTotalExpenseLastMonth(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTotalExpenseLastMonth", ReplyAction="http://tempuri.org/IExpense/GetTotalExpenseLastMonthResponse")]
        System.Threading.Tasks.Task<double> GetTotalExpenseLastMonthAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripExpenseByTotal", ReplyAction="http://tempuri.org/IExpense/GetTripExpenseByTotalResponse")]
        Classes.TripDetails[] GetTripExpenseByTotal(int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripExpenseByTotal", ReplyAction="http://tempuri.org/IExpense/GetTripExpenseByTotalResponse")]
        System.Threading.Tasks.Task<Classes.TripDetails[]> GetTripExpenseByTotalAsync(int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetNonTripFriend", ReplyAction="http://tempuri.org/IExpense/GetNonTripFriendResponse")]
        Classes.FriendList[] GetNonTripFriend(int UserId, int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetNonTripFriend", ReplyAction="http://tempuri.org/IExpense/GetNonTripFriendResponse")]
        System.Threading.Tasks.Task<Classes.FriendList[]> GetNonTripFriendAsync(int UserId, int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripExpenseByUser", ReplyAction="http://tempuri.org/IExpense/GetTripExpenseByUserResponse")]
        Classes.TripDetails[] GetTripExpenseByUser(int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripExpenseByUser", ReplyAction="http://tempuri.org/IExpense/GetTripExpenseByUserResponse")]
        System.Threading.Tasks.Task<Classes.TripDetails[]> GetTripExpenseByUserAsync(int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripDetails", ReplyAction="http://tempuri.org/IExpense/GetTripDetailsResponse")]
        Classes.TripDetails[] GetTripDetails(int tripId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpense/GetTripDetails", ReplyAction="http://tempuri.org/IExpense/GetTripDetailsResponse")]
        System.Threading.Tasks.Task<Classes.TripDetails[]> GetTripDetailsAsync(int tripId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExpenseChannel : DailyExpense.Expense.IExpense, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExpenseClient : System.ServiceModel.ClientBase<DailyExpense.Expense.IExpense>, DailyExpense.Expense.IExpense {
        
        public ExpenseClient() {
        }
        
        public ExpenseClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExpenseClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Classes.Product[] ProductList() {
            return base.Channel.ProductList();
        }
        
        public System.Threading.Tasks.Task<Classes.Product[]> ProductListAsync() {
            return base.Channel.ProductListAsync();
        }
        
        public void SavePersonelExpense(Classes.PersonelExpense expense) {
            base.Channel.SavePersonelExpense(expense);
        }
        
        public System.Threading.Tasks.Task SavePersonelExpenseAsync(Classes.PersonelExpense expense) {
            return base.Channel.SavePersonelExpenseAsync(expense);
        }
        
        public Classes.ExpenseData[] PersonelExpensebyDateList(System.DateTime fromDate, System.DateTime toDate, int userId) {
            return base.Channel.PersonelExpensebyDateList(fromDate, toDate, userId);
        }
        
        public System.Threading.Tasks.Task<Classes.ExpenseData[]> PersonelExpensebyDateListAsync(System.DateTime fromDate, System.DateTime toDate, int userId) {
            return base.Channel.PersonelExpensebyDateListAsync(fromDate, toDate, userId);
        }
        
        public Classes.ExpenseData[] PersonelExpensebyProductList(int productId, int userId) {
            return base.Channel.PersonelExpensebyProductList(productId, userId);
        }
        
        public System.Threading.Tasks.Task<Classes.ExpenseData[]> PersonelExpensebyProductListAsync(int productId, int userId) {
            return base.Channel.PersonelExpensebyProductListAsync(productId, userId);
        }
        
        public Classes.ChartData[] resultOverallChart(int userId) {
            return base.Channel.resultOverallChart(userId);
        }
        
        public System.Threading.Tasks.Task<Classes.ChartData[]> resultOverallChartAsync(int userId) {
            return base.Channel.resultOverallChartAsync(userId);
        }
        
        public Classes.ChartData[] chartOverallbyProductList(int productId, int userId) {
            return base.Channel.chartOverallbyProductList(productId, userId);
        }
        
        public System.Threading.Tasks.Task<Classes.ChartData[]> chartOverallbyProductListAsync(int productId, int userId) {
            return base.Channel.chartOverallbyProductListAsync(productId, userId);
        }
        
        public Classes.ChartData[] chartOverallbyDateList(System.DateTime fromDate, System.DateTime toDate, int userId) {
            return base.Channel.chartOverallbyDateList(fromDate, toDate, userId);
        }
        
        public System.Threading.Tasks.Task<Classes.ChartData[]> chartOverallbyDateListAsync(System.DateTime fromDate, System.DateTime toDate, int userId) {
            return base.Channel.chartOverallbyDateListAsync(fromDate, toDate, userId);
        }
        
        public Classes.ExpenseData[] resultOverallData(int userId) {
            return base.Channel.resultOverallData(userId);
        }
        
        public System.Threading.Tasks.Task<Classes.ExpenseData[]> resultOverallDataAsync(int userId) {
            return base.Channel.resultOverallDataAsync(userId);
        }
        
        public void UpdateStatus(string emailId, int userId) {
            base.Channel.UpdateStatus(emailId, userId);
        }
        
        public System.Threading.Tasks.Task UpdateStatusAsync(string emailId, int userId) {
            return base.Channel.UpdateStatusAsync(emailId, userId);
        }
        
        public Classes.FriendList[] GetFriendsList(int UserId) {
            return base.Channel.GetFriendsList(UserId);
        }
        
        public System.Threading.Tasks.Task<Classes.FriendList[]> GetFriendsListAsync(int UserId) {
            return base.Channel.GetFriendsListAsync(UserId);
        }
        
        public int SaveTripDetails(Classes.TripDetails tripDetails) {
            return base.Channel.SaveTripDetails(tripDetails);
        }
        
        public System.Threading.Tasks.Task<int> SaveTripDetailsAsync(Classes.TripDetails tripDetails) {
            return base.Channel.SaveTripDetailsAsync(tripDetails);
        }
        
        public void FriendTripMapping(int tripId, string friendId, int userId) {
            base.Channel.FriendTripMapping(tripId, friendId, userId);
        }
        
        public System.Threading.Tasks.Task FriendTripMappingAsync(int tripId, string friendId, int userId) {
            return base.Channel.FriendTripMappingAsync(tripId, friendId, userId);
        }
        
        public void SaveFriendsTripExpenseEntry(Classes.SaveTripExpense saveTripExp) {
            base.Channel.SaveFriendsTripExpenseEntry(saveTripExp);
        }
        
        public System.Threading.Tasks.Task SaveFriendsTripExpenseEntryAsync(Classes.SaveTripExpense saveTripExp) {
            return base.Channel.SaveFriendsTripExpenseEntryAsync(saveTripExp);
        }
        
        public Classes.TripExpenseItem[] TripItemList() {
            return base.Channel.TripItemList();
        }
        
        public System.Threading.Tasks.Task<Classes.TripExpenseItem[]> TripItemListAsync() {
            return base.Channel.TripItemListAsync();
        }
        
        public Classes.TripFriends[] GetTripFriends(int tripId) {
            return base.Channel.GetTripFriends(tripId);
        }
        
        public System.Threading.Tasks.Task<Classes.TripFriends[]> GetTripFriendsAsync(int tripId) {
            return base.Channel.GetTripFriendsAsync(tripId);
        }
        
        public Classes.TripHistoryList[] GetTripHistory(int UserId) {
            return base.Channel.GetTripHistory(UserId);
        }
        
        public System.Threading.Tasks.Task<Classes.TripHistoryList[]> GetTripHistoryAsync(int UserId) {
            return base.Channel.GetTripHistoryAsync(UserId);
        }
        
        public Classes.UserList[] GetUserList(int UserId) {
            return base.Channel.GetUserList(UserId);
        }
        
        public System.Threading.Tasks.Task<Classes.UserList[]> GetUserListAsync(int UserId) {
            return base.Channel.GetUserListAsync(UserId);
        }
        
        public Classes.TripHistoryList[] GetUserTrips(int UserId) {
            return base.Channel.GetUserTrips(UserId);
        }
        
        public System.Threading.Tasks.Task<Classes.TripHistoryList[]> GetUserTripsAsync(int UserId) {
            return base.Channel.GetUserTripsAsync(UserId);
        }
        
        public Classes.ExpenseData[] GetExpenseCurrentMonth(int userId) {
            return base.Channel.GetExpenseCurrentMonth(userId);
        }
        
        public System.Threading.Tasks.Task<Classes.ExpenseData[]> GetExpenseCurrentMonthAsync(int userId) {
            return base.Channel.GetExpenseCurrentMonthAsync(userId);
        }
        
        public double GetTotalExpenseCurrentMonth(int userId) {
            return base.Channel.GetTotalExpenseCurrentMonth(userId);
        }
        
        public System.Threading.Tasks.Task<double> GetTotalExpenseCurrentMonthAsync(int userId) {
            return base.Channel.GetTotalExpenseCurrentMonthAsync(userId);
        }
        
        public double GetTotalExpenseLastMonth(int userId) {
            return base.Channel.GetTotalExpenseLastMonth(userId);
        }
        
        public System.Threading.Tasks.Task<double> GetTotalExpenseLastMonthAsync(int userId) {
            return base.Channel.GetTotalExpenseLastMonthAsync(userId);
        }
        
        public Classes.TripDetails[] GetTripExpenseByTotal(int tripId) {
            return base.Channel.GetTripExpenseByTotal(tripId);
        }
        
        public System.Threading.Tasks.Task<Classes.TripDetails[]> GetTripExpenseByTotalAsync(int tripId) {
            return base.Channel.GetTripExpenseByTotalAsync(tripId);
        }
        
        public Classes.FriendList[] GetNonTripFriend(int UserId, int tripId) {
            return base.Channel.GetNonTripFriend(UserId, tripId);
        }
        
        public System.Threading.Tasks.Task<Classes.FriendList[]> GetNonTripFriendAsync(int UserId, int tripId) {
            return base.Channel.GetNonTripFriendAsync(UserId, tripId);
        }
        
        public Classes.TripDetails[] GetTripExpenseByUser(int tripId) {
            return base.Channel.GetTripExpenseByUser(tripId);
        }
        
        public System.Threading.Tasks.Task<Classes.TripDetails[]> GetTripExpenseByUserAsync(int tripId) {
            return base.Channel.GetTripExpenseByUserAsync(tripId);
        }
        
        public Classes.TripDetails[] GetTripDetails(int tripId) {
            return base.Channel.GetTripDetails(tripId);
        }
        
        public System.Threading.Tasks.Task<Classes.TripDetails[]> GetTripDetailsAsync(int tripId) {
            return base.Channel.GetTripDetailsAsync(tripId);
        }
    }
}