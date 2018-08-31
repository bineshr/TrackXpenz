$(document).ready(function () {
    $("#btnSignUp").on('click', function () {
        debugger;
        var emailId = $("#txtUsername").val();
        var password = $("#txtPassword").val();
        var conPassword = $("#txtconPassword").val();
        var genMale = $("#rdmale").prop('checked');
        var genFemale = $("#rdFemale").prop('checked');
        var firstName = $("#txtfirsttname").val();
        var lastName = $("#txtlasttname").val();
        var phoneNo = $("#txtmobileno").val();
        var country = $("#ddlcntry").val();
        //var reg = /^[0-9@!#\$\^%&*()+=\-\[\]\\\';,\.\/\{\}\|\":<>\? ]+$/;
        
        if (firstName == "") {
            $(".first-name").addClass('has-error');
            $("#errMsgsignUp").text("* Please enter the first name");
            $("#txtfirsttname").focus();
            return false;
        } else if (lastName == "") {
            $(".first-name").removeClass('has-error');           
            $(".last-name").addClass('has-error');
            $("#errMsgsignUp").text("* Please enter the last name");
            $("#txtlasttname").focus();
            return false;
        } else if (emailId == "") {
            $(".last-name").removeClass('has-error');           
            $(".email-Id").addClass('has-error');
            $("#errMsgsignUp").text("* Please enter the emailId");
            $("#txtUsername").focus();
            return false;
        } else if (!ValidateEmail(emailId)) {
            $(".last-name").removeClass('has-error');                      
            $(".email-Id").addClass('has-error');
            $("#errMsgsignUp").text("* Please enter the valid emailId");
            $("#txtUsername").focus();
            return false;
        } else if (isUserExist()) {
            $(".last-name").removeClass('has-error');                      
            $(".email-Id").addClass('has-error');
            $("#errMsgsignUp").text("* EmailID is already exists");
            $("#txtUsername").focus();
            return false;
        } else if (password == "") {
            $(".email-Id").removeClass('has-error');
            $(".pwd-text").addClass('has-error');
            $("#errMsgsignUp").text("* Please enter the password");
            $("#txtPassword").focus();
            return false;
        } else if (password.length < 6) {
            $(".email-Id").removeClass('has-error');           
            $(".pwd-text").addClass('has-error');
            $("#errMsgsignUp").text("* Password should have minimum 6 characters");
            $("#txtPassword").focus();
            return false;
        } else if (password != conPassword) {
            $(".pwd-text").removeClass('has-error');            
            $(".conf-pwd").addClass('has-error');
            $("#errMsgsignUp").text("* Password does not match");
            $("#txtconPassword").focus();
            return false;
        } else if (phoneNo == "") {
            $(".conf-pwd").removeClass('has-error');            
            $(".mobile-No").addClass('has-error');
            $("#errMsgsignUp").text("* Please enter the phone number");
            $("#txtmobileno").focus();
            return false;
        //} else if (!reg.test(mobNo)) {
        //    $(".conf-pwd").removeClass('has-error');            
        //    $(".mobile-No").addClass('has-error');
        //    $("#errMsgsignUp").text("* Phone number allows only numbers and characters");
        //    $("#txtmobileno").focus();
        //    return false;
        } else if (genMale == false && genFemale == false) {            
            $("#errMsgsignUp").text("* Please select the gender");
            return false;        
        } else if (country == "") {
            $(".country-ddl").addClass('has-error');
            $("#errMsgsignUp").text("* Please select the country");
            return false;
        } else {
            $("#modal-default").modal('show');
            $("#errMsgsignUp").text(" ");
            return true;
        }
    });
    $("#btnSuccess").on('click', function () {
        window.location = "../Home/SignIn";
    });
    function isUserExist() {
        var text = false;
        Common.ajaxsync({
            url: "/Home/IsUserExist",
            data: { 'emailId': $("#txtUsername").val() },
            success: function (response) {
                text = response;
            },
            error: function (err) {
            }
        });
        return text;
    }
});
function ValidateEmail(emailId) {
    var reg = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return reg.test(emailId);
}