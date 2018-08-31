$(document).ready(function () {
    $('#status').fadeOut();
    $('#preloader').fadeOut();
    $('.select2').select2()
    $("#txtdate").datepicker();
    $("#txtamount").val("");


    //$('#tbleUser').DataTable({
    //    'paging': true,
    //    'lengthChange': false,
    //    'searching': false,
    //    'ordering': true,
    //    'info': true,
    //    'autoWidth': false
    //});.
    $('#tbleUser').DataTable();
    $('#tbleTotal').DataTable({
        'paging': true,
        'lengthChange': false,
        'searching': false,
        'ordering': true,
        'info': true,
        'autoWidth': false
    });

    var friendId = "";
    var optionLength = "";
    $('.select2').on('change', function () {
        friendId = "";
        optionLength = $(this).find('option:selected').length;
        //alert(optionLength);
    });

    $("#btnAddnonTrip").on('click', function () {
        debugger;
        var currentUserId = $("#hiddenUserId").val();
        if (optionLength == 0) {
            $("#errMsgFr").text("* Please select the friends");
            return false;
        } else {
            $(".select2 option:selected").each(function () {
                friendId = friendId + $(this).attr('data-value') + ",";
            });
            //friendId = friendId + ",";
            addFriendsInTrip(friendId)
        }
    });

    $("#btnSaveTripExp").on('click', function () {
        debugger;
        var friends = $("#ddlfriends").val();
        var items = $("#ddlItems").val();
        var description = $("#txtdescription").val();
        var date = $("#txtdate").val();
        var amount = $("#txtamount").val();
        var numberregex = /^[0-9]*$/;
        if (friends == "") {
            $("#perExpErrmsg").text("* Please select the Friends");
            return false;
        } else if (items == "") {
            $("#perExpErrmsg").text("* Please select the Items");
            return false;
        } else if (description == "") {
            $("#perExpErrmsg").text("* Please enter the description");
            return false;
        } else if (date == "") {
            $("#perExpErrmsg").text("* Please select the date");
            return false;
        } else if (amount == "") {
            $("#perExpErrmsg").text("* Please enter the amount");
            return false;
        } else if (!numberregex.test(amount)) {
            $("#perExpErrmsg").text("* Amount accepts number only");
            return false;
        } else {
            saveTripExpense(friends, items, description, date, amount);
            $("#perExpErrmsg").text("");

        }
    });

    $("#btnmodalExpenseOK").on('click', function () {
        window.location = "../Expense/TripExpenseEntry";
    });

    function saveTripExpense(friends, items, description, date, amount) {
        $.ajax({
            url: "/Expense/SaveTripExpense",
            type: "POST",
            data: JSON.stringify({ 'friendsId': parseInt(friends), 'expenseOnId': parseInt(items), 'description': description, 'dates': date, 'amount': amount }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#msgSuccess").text("Saved Successfully")
                $("#modalExpense").modal('show');
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    }
    function addFriendsInTrip(friendId) {
        $.ajax({
            url: "/Expense/AddFriendsInTrip",
            type: "POST",
            data: JSON.stringify({ 'friendsIds': friendId }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#msgSuccess").text("Friend Added Successfully")
                $("#modalExpense").modal('show');
            },
            error: function () {
                //alert("An error has occured!!!");
            }
        });
    }
});

