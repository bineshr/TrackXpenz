$(document).ready(function () {
    //isFriendRequstExists();
    
    $("#expenseDiv").on('click', function () {
        window.location = "../Expense/ExpenseHome";
    });
    $("#searchDiv").on('click', function () {
        window.location = "../Expense/SearchHome";
    });
    
    //function isFriendRequstExists() {
    //    debugger;
    //    $.ajax({
    //        url: "/Home/IsFriendRequestExists",
    //        type: "POST",
    //        dataType: "json",
    //        traditional: true,
    //        contentType: "application/json; charset=utf-8",
    //        success: function (data) {
    //           alert(data)
    //            //if (data == true) {
    //            //    $("#commonMsg").text("One Friend request")
    //            //    $("#modalCommon").modal('show');
    //            //} else {
    //            //    $("#commonMsg").text("No Friend request")
    //            //    $("#modalCommon").modal('show');
    //            //}
                
    //        },
    //        error: function () {
    //            alert("An error has occured!!!");
    //        }            
    //    });
    //    return result;
    //}
});