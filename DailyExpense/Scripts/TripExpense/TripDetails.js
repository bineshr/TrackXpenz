$(document).ready(function () {
    $('#status').fadeOut();
    $('#preloader').fadeOut();
    $('.select2').select2()
    $("#txtfromDate").datepicker();
    $("#txttoDate").datepicker();
    
    
    var friendId = "";
    var optionLength = "";
    $('.select2').on('change', function () {
        friendId = "";
        optionLength = $(this).find('option:selected').length;
        //alert(optionLength);
    });



    $("#btnAddFriend").on('click', function () {
        //debugger;
        var emailID = $("#txtfriend").val();
        var userExist = isUserExist();
        if (emailID == "") {
            $("#frndErrMsg").text("* Please enter email address");
            return false;
        } else if (!ValidateEmail(emailID)) {
            $("#frndErrMsg").text("* Please enter valid email address");
            return false;
        } else if (!isUserExist()) {
            $("#frndErrMsg").text("* Not valid user");
            return false;
        } else {
            $("#frndErrMsg").text("");
            friendRequst(emailID);
        }
    });
    $("#btnTripsubmit").on('click', function () {
        //debugger;
        var tripTitle = $("#txttitle").val();
        var description = $("#txtdesc").val();
        var journeyStart = $("#txtfromDate").val();
        var joureyEnd = $("#txttoDate").val();
        var currentUserId = $("#hiddenUserId").val();
        var frndsList = $('.mutliSelect input[type="checkbox"]').is(':checked');
        //var frndsList = $('.mutliSelect input[type="checkbox"]').is(':checked');
        
        if (tripTitle == "") {
            $("#tripErrMsg").text("* Please enter the trip name");
            return false;
        } else if (description == "") {
            $("#tripErrMsg").text("* Please enter the description");
            return false;
        } else if (journeyStart == "") {
            $("#tripErrMsg").text("* Please select the start date");
            return false;
        } else if (joureyEnd == "") {
            $("#tripErrMsg").text("* Please select the end date");
            return false;
        } else if (optionLength == 0) {
            $("#tripErrMsg").text("* Please select the friends");
            return false;
        } else {
            $("#tripErrMsg").text("");
            $(".select2 option:selected").each(function () {
                friendId = friendId + $(this).attr('data-value') + ",";
            });           
            friendId = friendId + currentUserId + ",";
            //alert(friendId);
            saveTrips(tripTitle, description, journeyStart, joureyEnd, friendId);
            return true;
        }
    });

    //function isUserExist() {
    //    var text = false;
    //    Common.ajaxsync({
    //        url: "/Home/IsUserExist",
    //        data: { 'emailId': $("#txtfriend").val() },
    //        success: function (response) {
    //            text = response;
    //        },
    //        error: function (err) {
    //        }
    //    });
    //    return text;
    //}
    
    function saveTrips(tripTitle, description, journeyStart, joureyEnd, friendId) {
        //debugger;
        $.ajax({
            url: "/Expense/SaveTrips",
            type: "POST",
            data: JSON.stringify({ 'tripTitle': tripTitle, 'description': description, 'startDate': journeyStart, 'endDate': joureyEnd, 'friendsIds': friendId.substring(0, friendId.length - 1) }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                window.location = "../Expense/TripHistory";
                //$("#commonMsg").text("Saved Successfully")
                //$("#modalCommon").modal('show');
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    }
    function friendRequst(emailID) {
        //debugger;
        $.ajax({
            url: "/Expense/AddFriends",
            type: "POST",
            data: JSON.stringify({ 'emailId': emailID }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //$("#commonMsg").text("Saved Successfully")
                //$("#modalCommon").modal('show');
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    }
    function isUserExist() {
        //debugger;
        var text;
        $.ajax({
            url: "/Home/IsUserExist",
            type: "POST",
            data: JSON.stringify({ 'emailId': $("#txtfriend").val() }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                //alert(data);
                text = response;
                //alert(text);
                //$("#commonMsg").text("Saved Successfully")
                //$("#modalCommon").modal('show');
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
        //alert(text);
        return text;
    }
    function ValidateEmail(emailID) {
        var reg = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return reg.test(emailID);
    }
});