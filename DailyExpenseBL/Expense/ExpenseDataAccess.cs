using DailyExpenseDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Product = Classes.Product;
using System.Configuration;

namespace DailyExpenseBL.Expense
{
    public class ExpenseDataAccess
    {
        //readonly ExpenseEntities _db = new ExpenseEntities();
        static string connectionString = ConfigurationManager.ConnectionStrings["ExpenseEntities"].ConnectionString;
        private ExpenseEntities _db = ExpenseEntities.CreateEntitiesForSpecificDatabaseName(connectionString);
        public List<Product> ProductList()
        {
            var products = new List<Product>();
            var product = _db.Products;
            products.AddRange(product.Select(a => new Product
            {
                Id = a.Id,
                Name = a.ProductName
            }));
            return products;
        }
        public void SavePersonelExpense(PersonelExpense expense)
        {
            var entry = new ExpenseEntry
            {
                UserId = expense.UserId,
                ProductId = expense.ProductId,
                Description = expense.Description,
                Date = expense.Date,
                Amount = expense.Amount,
                Created_On = DateTime.Now
            };
            _db.ExpenseEntries.Add(entry);
            _db.SaveChanges();
        }
        public List<ExpenseData> PersonelExpensebyDateList(DateTime fromDate, DateTime toDate, int userId)
        {
            var prods = new List<ExpenseData>();
            var prodsQuery = (from exp in _db.ExpenseEntries
                              join prod in _db.Products on exp.ProductId equals prod.Id
                              where exp.Date >= fromDate && exp.Date <= toDate && exp.UserId == userId
                              select new { prod.ProductName, exp.Description, exp.Date, exp.Amount });
            prods.AddRange(prodsQuery.Select(a => new ExpenseData
            {
                ProductName = a.ProductName,
                Description = a.Description,
                Date = (DateTime)a.Date,
                Amount = (float)a.Amount
            }));
            return prods;
        }
        public List<ExpenseData> PersonelExpensebyProductList(int productId, int userId)
        {
            var prodcts = new List<ExpenseData>();
            var prodQuery = (from exp in _db.ExpenseEntries
                             join prod in _db.Products on exp.ProductId equals prod.Id
                             where prod.Id == productId && exp.UserId == userId
                             select new { prod.ProductName, exp.Description, exp.Date, exp.Amount });
            prodcts.AddRange(prodQuery.Select(a => new ExpenseData
            {
                ProductName = a.ProductName,
                Description = a.Description,
                Date = (DateTime)a.Date,
                Amount = (float)a.Amount
            }));

            return prodcts;
        }
        public List<ExpenseData> GetExpenseCurrentMonth(int userId)
        {
            var prodcts = new List<ExpenseData>();
            var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var currentMonth = startOfTthisMonth.ToString();
            var firstDay = startOfTthisMonth.AddMonths(-1);
            var lastDay = startOfTthisMonth.AddDays(-1);
            var prodQuery = (from exp in _db.ExpenseEntries
                             join prod in _db.Products on exp.ProductId equals prod.Id
                             where exp.Date >= startOfTthisMonth && exp.UserId == userId
                             select new { prod.ProductName, exp.Description, exp.Date, exp.Amount });
            prodcts.AddRange(prodQuery.Select(a => new ExpenseData
            {
                ProductName = a.ProductName,
                Description = a.Description,
                Date = (DateTime)a.Date,
                Amount = (float)a.Amount
            }));

            return prodcts;
        }
        public double GetTotalExpenseCurrentMonth(int userId)
        {
            var prodcts = new List<ExpenseData>();
            var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var currentMonth = startOfTthisMonth.ToString();
            var firstDay = startOfTthisMonth.AddMonths(-1);
            var lastDay = startOfTthisMonth.AddDays(-1);
            var prodQuery = (from exp in _db.ExpenseEntries
                             join prod in _db.Products on exp.ProductId equals prod.Id
                             where exp.Date >= startOfTthisMonth && exp.UserId == userId
                             select new { exp.Amount });

            if (prodQuery.Sum(a => a.Amount) == 0 || prodQuery.Sum(a => a.Amount) == null)
            {
                return 0;
            }
            return (double)prodQuery.Sum(a => a.Amount);
        }
        public double GetTotalExpenseLastMonth(int userId)
        {
            var prodcts = new List<ExpenseData>();
            var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var currentMonth = startOfTthisMonth.ToString();
            var firstDay = startOfTthisMonth.AddMonths(-1);
            var lastDay = startOfTthisMonth.AddDays(-1);
            var prodQuery = (from exp in _db.ExpenseEntries
                             join prod in _db.Products on exp.ProductId equals prod.Id
                             where exp.Date >= firstDay && exp.Date <= lastDay && exp.UserId == userId
                             select new { exp.Amount });

            if (prodQuery.Sum(a => a.Amount) == 0 || prodQuery.Sum(a => a.Amount) == null)
            {
                return 0;
            }
            return (double)prodQuery.Sum(a => a.Amount);
        }
        public List<ChartData> resultOverallChart(int userId)
        {
            var overallChart = new List<ChartData>();
            var overallChartQuery = (from exp in _db.ExpenseEntries
                                     join prod in _db.Products on exp.ProductId equals prod.Id
                                     where exp.UserId == userId
                                     select new { prod.ProductName, exp.Amount });
            var chartdata = overallChartQuery.GroupBy(a => a.ProductName);
            foreach (var product in chartdata)
            {
                var results = new ChartData();
                results.ProductName = product.Key;
                float amount = 0;
                foreach (var amounts in product)
                {
                    amount = amount + (float)(amounts.Amount);
                }
                results.Amount = amount.ToString();
                overallChart.Add(results);
            }
            return overallChart;
        }
        public List<ChartData> chartOverallbyProductList(int productId, int userId)
        {
            var prodcts = new List<ChartData>();
            var prodQuery = (from exp in _db.ExpenseEntries
                             join prod in _db.Products on exp.ProductId equals prod.Id
                             where prod.Id == productId && exp.UserId == userId
                             select new { prod.ProductName, exp.Description, exp.Date, exp.Amount });
            var productData = prodQuery.GroupBy(a => a.ProductName);
            foreach (var prodctsList in productData)
            {
                var prodctsData = new ChartData();
                prodctsData.ProductName = prodctsList.Key;
                float amount = 0;
                foreach (var amounts in prodctsList)
                {
                    amount = amount + (float)(amounts.Amount);
                }
                prodctsData.Amount = amount.ToString();
                prodcts.Add(prodctsData);
            }

            return prodcts;
        }
        public List<ChartData> chartOverallbyDateList(DateTime fromDate, DateTime toDate, int userId)
        {
            var prods = new List<ChartData>();
            var pross = (from exp in _db.ExpenseEntries
                         join prod in _db.Products on exp.ProductId equals prod.Id
                         where exp.Date >= fromDate && exp.Date <= toDate && exp.UserId == userId
                         select new { prod.ProductName, exp.Description, exp.Date, exp.Amount });
            var dateData = pross.GroupBy(a => a.ProductName);
            foreach (var dateByData in dateData)
            {
                var getDateData = new ChartData();
                getDateData.ProductName = dateByData.Key;
                float amount = 0;
                foreach (var amounts in dateByData)
                {
                    amount = amount + (float)(amounts.Amount);
                }
                getDateData.Amount = amount.ToString();
                prods.Add(getDateData);
            }
            return prods;
        }
        public List<ExpenseData> resultOverallData(int userId)
        {
            var overallData = new List<ExpenseData>();
            var overallDataQuery = (from exp in _db.ExpenseEntries
                                    join prod in _db.Products on exp.ProductId equals prod.Id
                                    where exp.UserId == userId
                                    select new { prod.ProductName, exp.Description, exp.Date, exp.Amount });
            overallData.AddRange(overallDataQuery.Select(a => new ExpenseData
            {
                ProductName = a.ProductName,
                Description = a.Description,
                Date = (DateTime)a.Date,
                Amount = (float)a.Amount
            }));

            return overallData;
        }
        public void UpdateStatus(string emailId, int userId)
        {
            var friendId = (from usr in _db.UsersInfoes
                            where usr.EmailId == emailId
                            select new { usr.Id }).FirstOrDefault().Id;

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
                _db.FriendsLists.Add(frndList);
                _db.SaveChanges();
            }
        }
        public List<FriendList> GetFriendsList(int UserId)
        {
            var getFriends = (from frndsList in _db.FriendsLists
                              join usr in _db.UsersInfoes on frndsList.FriendId equals usr.Id
                              join cntry in _db.Countries on usr.CountryId equals cntry.Id
                              where frndsList.UserId == UserId && frndsList.Active == 2
                              select new { usr.Id, usr.EmailId, usr.FirstName, usr.LastName, usr.Image, cntry.Name });
            var getfriendsList = new List<FriendList>();
            if (getFriends != null)
            {
                foreach (var friend in getFriends)
                {
                    var frnds = new FriendList
                    {
                        Id = friend.Id,
                        EmailId = friend.EmailId,
                        Name = friend.FirstName + " " + friend.LastName,
                        picture = friend.Image != null ? Convert.ToBase64String(friend.Image) : null,
                        Location = friend.Name
                    };
                    getfriendsList.Add(frnds);
                }

            }
            
            return getfriendsList;
        }
        public List<FriendList> GetNonTripFriend(int UserId, int tripId)
        {
            var tripFriends = from frnds in _db.FriendTripMappings
                              where frnds.TripId == tripId && frnds.Active == true && frnds.UserId == UserId
                              select new { frnds.FriendId };
            //select* from friendslist where FriendId not in (select FriendId from FriendTripMapping where tripid = 10) and UserId = 2
            //var notfriends= select 
            var getFriends = from frndsList in _db.FriendsLists
                             join usr in _db.UsersInfoes on frndsList.FriendId equals usr.Id
                             where frndsList.UserId == UserId && frndsList.Active == 2 && !(from trip in _db.FriendTripMappings where trip.TripId == tripId select trip.FriendId).Contains(frndsList.FriendId)
                             select new { usr.Id, usr.EmailId, usr.FirstName, usr.LastName, usr.Image };
            var getfriendsList = new List<FriendList>();
            getfriendsList.AddRange(getFriends.Select(a => new FriendList
            {
                Id = a.Id,
                Name = a.FirstName + " " + a.LastName,
                EmailId = a.EmailId,
                //picture= (a.Image != null) ? Convert.ToBase64String(a.Image) : ""
            }));
            return getfriendsList;

        }
        public int SaveTripDetails(TripDetails tripDetails)
        {
            var trip = new TripDetail
            {
                TripTitle = tripDetails.TripTitle,
                Description = tripDetails.Description,
                StartDate = tripDetails.fromDate,
                EndDate = tripDetails.toDate,
                UserId = tripDetails.UserId,
                Created_On = DateTime.Now,
                Status = true
            };
            _db.TripDetails.Add(trip);
            _db.SaveChanges();
            return trip.Id;
        }
        public void FriendTripMapping(int tripId, string friendId, int userId)
        {
            var splitfriendsIds = friendId.Split(',');
            foreach (var friendsId in splitfriendsIds)
            {
                int frndsId = Convert.ToInt32(friendsId);
                var friendTripMap = new FriendTripMapping
                {
                    TripId = tripId,
                    FriendId = frndsId,
                    Created_On = DateTime.Now,
                    Active = true,
                    UserId = userId
                };
                _db.FriendTripMappings.Add(friendTripMap);
                _db.SaveChanges();
            }
        }
        public void SaveFriendsTripExpenseEntry(SaveTripExpense saveTripExp)
        {
            var saveTripExpense = new TripExpense
            {
                TripId = saveTripExp.tripId,
                FriendId = saveTripExp.friendId,
                UserId = saveTripExp.UserId,
                ExpenseOnId = saveTripExp.ExpenseOnId,
                Descriptions = saveTripExp.Description,
                Dates = saveTripExp.Dates,
                Amount = saveTripExp.Amount,
                Created_On = DateTime.Now,
                Status = 1
            };
            _db.TripExpenses.Add(saveTripExpense);
            _db.SaveChanges();
        }
        public List<TripExpenseItem> TripItemList()
        {
            var item = new List<TripExpenseItem>();
            var items = _db.TripItems;
            item.AddRange(items.Select(a => new TripExpenseItem
            {
                Id = a.Id,
                Name = a.ItemName
            }));
            return item;
        }
        public List<TripFriends> GetTripFriends(int tripId)
        {
            var getFriends = from frnds in _db.FriendTripMappings
                             join usr in _db.UsersInfoes on frnds.FriendId equals usr.Id
                             where frnds.TripId == tripId && frnds.Active == true
                             select new { usr.Id, usr.EmailId, usr.FirstName, usr.LastName };
            var getfrndsList = new List<TripFriends>();
            getfrndsList.AddRange(getFriends.Select(a => new TripFriends
            {
                Id = a.Id,
                Name = a.FirstName + " " + a.LastName,
                EmailId = a.EmailId
            }));
            return getfrndsList;
        }
        //public List<TripHistoryList> GetTripHistory(int UserId)
        //{
        //    var tripsHist = from trips in _db.TripDetails
        //                    join frnd in _db.FriendTripMappings on trips.Id equals frnd.TripId
        //                    //join usr in _db.UsersInfoes on frnd.FriendId equals usr.Id
        //                    where trips.UserId == UserId 
        //                    select new { trips.Id, trips.TripTitle, trips.StartDate, trips.EndDate, trips.Status, trips.Created_On, trips.Description };
        //    var tripList = new List<TripHistoryList>();
        //    var tripsId = tripsHist.GroupBy(a => a.Id);
        //    foreach(var tripsgroup in tripsId)
        //    {
        //        var trip = new TripHistoryList();
        //        trip.TripId = tripsgroup.Key;
        //    }
        //    //var trip = new TripHistoryList();
        //    //var tripComId = tripsHist.GroupBy(a => a.Id);
        //    //foreach (var tripByDetails in tripComId)
        //    //{
        //    //    trip.TripId = tripByDetails.Key;
        //    //    foreach (var history in tripByDetails)
        //    //    {
        //    //        trip.Title = history.TripTitle;
        //    //        trip.StartDate = history.StartDate;
        //    //        trip.EndDate = history.EndDate;
        //    //        trip.CreatedOn = history.Created_On.ToString();
        //    //        //trip.Name = history.FirstName + " " + history.LastName;
        //    //        //trip.EmailId = history.EmailId;                   
        //    //    }
        //    //    tripList.Add(trip);
        //    //}

        //    //foreach (var dateByData in dateData)
        //    //{
        //    //    var getDateData = new ChartData();
        //    //    getDateData.ProductName = dateByData.Key;
        //    //    var amount = 0;
        //    //    foreach (var amounts in dateByData)
        //    //    {
        //    //        amount = amount + Int32.Parse(amounts.Amount);
        //    //    }
        //    //    getDateData.Amount = amount.ToString();
        //    //    prods.Add(getDateData);
        //    //}
        //    tripList.AddRange(tripsHist.Select(a => new TripHistoryList
        //    {
        //        Title = a.TripTitle,
        //        StartDate = a.StartDate,
        //        EndDate = a.EndDate,
        //        CreatedOn = a.Created_On.ToString(),
        //        //Name = a.FirstName + " " + a.LastName,
        //        //EmailId = a.EmailId
        //    }));
        //    return tripList;
        //}
        public List<TripHistoryList> GetTripHistory(int UserId)
        {
            var tripList = new List<TripHistoryList>();
            var tripsHist = from trips in _db.TripDetails
                            join frndTrip in _db.FriendTripMappings on trips.Id equals frndTrip.TripId
                            //join usr in _db.UsersInfoes on frndTrip.FriendId equals usr.Id
                            where frndTrip.FriendId == UserId
                            select new { trips.Id, trips.TripTitle, trips.StartDate, trips.EndDate, trips.Status, trips.Created_On, trips.Description };
            tripList.AddRange(tripsHist.Select(a => new TripHistoryList
            {
                TripId = a.Id,
                Title = a.TripTitle,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                CreatedOn = a.Created_On.ToString(),
                Status = a.Status.ToString(),
            }));

            return tripList;

        }
        public List<UserList> GetUserList(int UserId)
        {
            //var getUser = from trips in _db.TripDetails
            //                  join frndtrip in _db.FriendTripMappings on trips.Id equals frndtrip.TripId
            //                  join usr in _db.UsersInfoes on frndtrip.FriendId equals usr.Id
            //                  where trips.UserId == UserId
            //                  select new { usr.Id, usr.EmailId };
            //var getFriends = from frndsList in _db.FriendsLists
            //                 join usr in _db.UsersInfoes on frndsList.FriendId equals usr.Id                            
            //                 where frndsList.UserId == UserId && frndsList.Active == 2
            //                 select new { usr.Id, usr.EmailId };
            var getUser = from frndtrip in _db.FriendTripMappings
                          join usr in _db.UsersInfoes on frndtrip.FriendId equals usr.Id
                          where frndtrip.UserId == UserId && frndtrip.TripId == 8
                          select new { usr.Id, usr.EmailId };
            var getUserList = new List<UserList>();
            getUserList.AddRange(getUser.Select(a => new UserList
            {
                Id = a.Id,
                Name = a.EmailId,
            }));
            return getUserList;
        }
        public List<TripHistoryList> GetUserTrips(int UserId)
        {
            var userTrips = from trips in _db.TripDetails
                            join frndtrip in _db.FriendTripMappings on trips.Id equals frndtrip.TripId
                            where frndtrip.UserId == UserId || frndtrip.FriendId == UserId
                            select new { trips.Id, trips.TripTitle };
            var userTripsList = new List<TripHistoryList>();
            userTripsList.AddRange(userTrips.Select(a => new TripHistoryList
            {
                TripId = a.Id,
                Title = a.TripTitle
            }));
            return userTripsList;
        }
        public List<TripDetails> GetTripExpenseByTotal(int tripId)
        {
            var getTripUser = from trips in _db.TripDetails
                              join frndtrip in _db.FriendTripMappings on trips.Id equals frndtrip.TripId
                              join exp in _db.TripExpenses on frndtrip.FriendId equals exp.FriendId
                              join usr in _db.UsersInfoes on frndtrip.FriendId equals usr.Id
                              where trips.Id == tripId && exp.TripId == tripId
                              select new { trips.Id, trips.TripTitle, trips.StartDate, trips.EndDate, usr.FirstName, usr.LastName, usr.EmailId, exp.Amount, usr.Image };

            var tripDetail = new List<TripDetails>();
            var emailIdKey = getTripUser.GroupBy(a => a.EmailId);
            foreach (var tdList in emailIdKey)
            {
                var td = new TripDetails();
                td.EmailId = tdList.Key;
                td.Name = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).FirstName + " " + tdList.FirstOrDefault(a => a.EmailId == tdList.Key).LastName;
                td.TripTitle = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).TripTitle;
                td.fromDate = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).StartDate;
                td.toDate = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).EndDate;
                double amount = 0;
                foreach (var amt in tdList)
                {
                    amount = amount + (double)(amt.Amount);
                }
                td.Amount = amount;
                tripDetail.Add(td);

            }

            //tripDetail.AddRange(getTripUser.Select(a => new TripDetails()
            //{
            //    TripTitle=a.TripTitle,
            //    fromDate=a.StartDate,
            //    toDate=a.EndDate,
            //    //FriendList= frnList
            //}));

            return tripDetail;
        }
        public List<TripDetails> GetTripExpenseByUser(int tripId)
        {
            var getTripUser = from trips in _db.TripDetails
                              join frndtrip in _db.FriendTripMappings on trips.Id equals frndtrip.TripId
                              join exp in _db.TripExpenses on frndtrip.FriendId equals exp.FriendId
                              join tritem in _db.TripItems on exp.ExpenseOnId equals tritem.Id
                              join usr in _db.UsersInfoes on frndtrip.FriendId equals usr.Id
                              where trips.Id == tripId && exp.TripId == tripId
                              select new { trips.Id, trips.TripTitle, trips.StartDate, trips.EndDate, usr.FirstName, usr.LastName, usr.EmailId, exp.Amount, usr.Image, exp.Descriptions, exp.Dates, tritem.ItemName };

            var tripDetail = new List<TripDetails>();
            tripDetail.AddRange(getTripUser.Select(a => new TripDetails()
            {
                TripTitle = a.TripTitle,
                fromDate = a.StartDate,
                toDate = a.EndDate,
                Name = a.FirstName + " " + a.LastName,
                EmailId = a.EmailId,
                Description = a.Descriptions,
                Amount = (double)a.Amount,
                dates = a.Dates,
                itemName = a.ItemName
                //FriendList= frnList
            }));
            return tripDetail;
        }
        public List<TripDetails> GetTripDetails(int tripId)
        {
            var getTripUser = from trips in _db.TripDetails
                              join frndtrip in _db.FriendTripMappings on trips.Id equals frndtrip.TripId
                              join exp in _db.TripExpenses on frndtrip.FriendId equals exp.FriendId
                              join usr in _db.UsersInfoes on frndtrip.FriendId equals usr.Id
                              where trips.Id == tripId && exp.TripId == tripId
                              select new { trips.Id, trips.TripTitle, trips.StartDate, trips.EndDate, usr.FirstName, usr.LastName, usr.EmailId, exp.Amount, usr.Image };
            var tripDetail = new List<TripDetails>();
            var emailIdKey = getTripUser.GroupBy(a => a.EmailId);
            foreach (var tdList in emailIdKey)
            {
                var td = new TripDetails();
                td.EmailId = tdList.Key;
                td.Name = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).FirstName + " " + tdList.FirstOrDefault(a => a.EmailId == tdList.Key).LastName;
                td.TripTitle = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).TripTitle;
                td.fromDate = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).StartDate;
                td.toDate = tdList.FirstOrDefault(a => a.EmailId == tdList.Key).EndDate;
                double amount = 0;
                foreach (var amt in tdList)
                {
                    amount = amount + (double)(amt.Amount);
                }
                td.Amount = amount;
                tripDetail.Add(td);

            }

            return tripDetail;
        }

    }
}
