$(document).ready(function () {
    $('#status').fadeOut();
    $('#preloader').fadeOut();
    $("#txtFromdate").datepicker();
    $("#txtTodate").datepicker();
    //$('#tbleViewDate').DataTable()
    $('#tbleViewDate').DataTable({
        'paging': true,
        'lengthChange': false,
        'searching': false,
        'ordering': true,
        'info': true,
        'autoWidth': false
    })
    $('#tbleViewPro').DataTable({
        'paging': true,
        'lengthChange': false,
        'searching': false,
        'ordering': true,
        'info': true,
        'autoWidth': false
    })
    $("#tileSrchDate").on('click', function () {
        $('.date-view').show();
        $('.prod-view').hide();
    });
    $("#tileSrchPro").on('click', function () {
        $('.prod-view').show();
        $('.date-view').hide();
    });
    $("#btnSubmitPro").on('click', function () {
        var productId = $("#ddlproduct").val();
        if (productId == "") {
            $("#srchErr").text("* Please select the product");
            return false;
        } else {
            viewSearchByProduct(productId);
        }
    });

    $("#btnSubmitDate").on('click', function () {
        var fromDate = $("#txtFromdate").val();
        var toDate = $("#txtTodate").val();
        if (fromDate == "") {
            $("#srchErrDate").text("* Please select the from date");
            return false;
        } else if (toDate == "") {
            $("#srchErrDate").text("* Please select the to date");
            return false;
        } else {
            $("#srchErrDate").text(" ");
            viewExpenseByDate(fromDate, toDate);
        }

    });
    function viewSearchByProduct(productId) {
        $("#loadExpbyProduct").load("../Expense/GetExpenseByProduct?proudctId=" + productId, function () {

        });
    }
    function viewExpenseByDate(fromDate, toDate) {
        $("#loadExpbyDate").load("../Expense/GetExpenseByDate?fromDate=" + fromDate + "&toDate=" + toDate, function () {

        });
    }

    //function viewExpenseByDate(fromDate, toDate) {
    //    $.ajax({
    //        url: "/Expense/GetExpenseByDate",
    //        type: "POST",
    //        data: JSON.stringify({ 'fromDate': fromDate, 'toDate': toDate }),
    //        dataType: "json",
    //        traditional: true,
    //        contentType: "application/json; charset=utf-8",
    //        success: function (data) {
    //            //var countDateExp = data.length;
    //            //if (countDateExp > 0) {
    //            //    var tr;
    //            //    $('#tbleViewDate td').remove();
    //            //    for (var i = 0; i < data.length; i++) {
    //            //        tr = $('<tr/>');
    //            //        tr.append("<td>" + data[i].ProductName + "</td>");
    //            //        tr.append("<td>" + data[i].Description + "</td>");
    //            //        tr.append("<td>" + data[i].Date + "</td>");
    //            //        tr.append("<td>" + data[i].Amount + "</td>");
    //            //        $('#tbleViewDate').append(tr);
    //            //    }
    //            //} else {
    //            //    $("#comErrMsg").text("Expense doesn't exists");
    //            //    $("#modalExpense").modal('show');
    //            //}
    //        },
    //        error: function () {
    //        }
    //    });
    //}
});