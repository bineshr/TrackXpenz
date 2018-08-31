$(document).ready(function () {
    $('#status').fadeOut();
    $('#preloader').fadeOut();


    $("#btnLogin").on('click', function () {
        //debugger;
        var returnText = false;
        $('#status').fadeIn();
        $('#preloader').fadeIn();
        var emailId = $("#txtUsername").val();
        var password = $("#txtPassword").val();
        if (!$('.passwordarea').is(':visible')) {
            if (emailId == "") {
                $(".email-Id").addClass('has-error');
                $("#errMsgLogin").text("* Please enter the emailId");
                $('#status').fadeOut();
                $('#preloader').fadeOut();
                return returnText = false;
            } else if (!ValidateEmail(emailId)) {
                $(".email-Id").addClass('has-error');
                $("#errMsgLogin").text("* Please enter the valid emailId");
                $('#status').fadeOut();
                $('#preloader').fadeOut();
                return returnText = false;
            } else if (!checkemailId(emailId)) {
                $(".email-Id").addClass('has-error');
                $("#errMsgLogin").text("* This email is not valid");
                $('#status').fadeOut();
                $('#preloader').fadeOut();
                return returnText = false;
            } else {
                if (!isUserProfileCompletion(emailId)) {
                    $("#txtproemail").val(emailId);
                    $("#profileModal").modal('show');
                    $('#status').fadeOut();
                    $('#preloader').fadeOut();
                    return returnText = false;
                } else {
                    $('.passwordarea').show();
                    $('.link-page').show();
                    $("#btnLogin").text('Sign In');
                    $('#status').fadeOut();
                    $('#preloader').fadeOut();
                    return returnText = false;
                }
            }
        } else {
            if (password == "") {
                $(".email-Id").removeClass('has-error');
                $(".pwd-txt").addClass('has-error');
                $("#errMsgLogin").text("* Please enter the password");
                $('#status').fadeOut();
                $('#preloader').fadeOut();
                return returnText = false;
            } else {
                $(".pwd-txt").removeClass('has-error');
                $("#errMsgLogin").text("");
                $('#status').fadeOut();
                $('#preloader').fadeOut();
                return returnText = true;
            }
        }
    });

    $("#btnSubFrgPwd").on('click', function () {
        var emailId = $("#txtInputEmail").val();
        if (emailId == "") {
            $("#frgErrMsg").text("* Please enter the emailId");
            return false;
        } else if (!ValidateEmail(emailId)) {
            $("#frgErrMsg").text("* Please enter the valid emailId");
            return false;
        } else {
            $("#frgErrMsg").text("");
        }
    });

    //Complete Profile PopUp
    $("#btnproComplete").on('click', function () {
        //debugger;
        var emailId = $("#txtproemail").val();
        var firstName = $("#txtprofname").val();
        var lastName = $("#txtprolname").val();
        var password = $("#txtpropassword").val();
        var confirmpassword = $("#txtproconpassword").val();
        var mobileNo = $("#txtpromobileno").val();       
        var gender = $(".genderradio").prop('checked');
        var genderValue = $("input[name='Gender']:checked").val()
        var country = $("#ddlcountry :selected").attr('value');

        if (firstName.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#proerrMsg").text("* Please enter first name");
            return false;
        } else if (lastName.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#proerrMsg").text("* Please enter last name");
            return false;
        } else if (password.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#proerrMsg").text("* Please enter password");
            return false;
        } else if (password != confirmpassword) {
            $("#proerrMsg").text("* Password and confirm password should be same");
            return false;
        } else if (mobileNo.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#proerrMsg").text("* Please enter mobile number");
            return false;
        } else if (gender == false) {
            $("#proerrMsg").text("* Please select gender");
            return false;
        } else if (country == -1) {
            $("#proerrMsg").text("* Please select country");
            return false;
        } else {
            saveUserProfile(emailId, firstName, lastName, password, mobileNo, genderValue, country);
            //return true;
            $("#proerrMsg").text("");
        }
    });
});

function ValidateEmail(emailId) {
    var reg = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return reg.test(emailId);
}


function isUserProfileCompletion(emailId) {
    var text = false;
    Common.ajaxsync({
        url: "/Home/IsProfileCompleted",
        data: { 'emailId': emailId },
        success: function (response) {
            text = response;
        },
        error: function (err) {
        }
    });
    return text;
}


function checkemailId(emailId) {
    var text = false;
    Common.ajaxsync({
        url: "/Home/IsUserExist",
        data: { 'emailId': emailId },
        success: function (response) {
            text = response;
        },
        error: function (err) {
        }
    });
    return text;
}

function saveUserProfile(emailId, firstName, lastName, password, mobileNo, genderValue, country) {
    
    Common.ajaxsync({
        url: "/Home/SaveUserProfile",
        data: { 'emailId': emailId, 'firstName': firstName, 'lastName': lastName, 'password': password, 'mobileNo': mobileNo, 'gender': genderValue, 'country': parseInt(country) },
        success: function (response) {
            $("#txtUsername").val(emailId);
            $('.passwordarea').show();
            $('.link-page').show();
            $("#btnLogin").text('Sign In');
            $('#status').fadeOut();
            $('#preloader').fadeOut();
        },
        error: function (err) {
        }
    });   
}

