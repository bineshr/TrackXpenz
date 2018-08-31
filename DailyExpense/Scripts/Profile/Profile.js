$(document).ready(function () {
    $('#status').fadeOut();
    $('#preloader').fadeOut();
    $("#btnProUpdate").on("click", function () {
        //alert("hhhh");
        //debugger;
        $('#status').fadeIn();
        $('#preloader').fadeIn();
        var firstName = $("#txtFName").val();
        var lastName = $("#txtLNane").val();
        var Country = $("#ddlcntry").find(":selected").text();
        var countryId = $("#ddlcntry").find(":selected").val();
        var MobileNo = $("#txtMobNo").val();
        var status = $("#txtStatus").val();
        if (firstName.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#errMsgText").html("* Please enter first name");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else if (lastName.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#errMsgText").html("* Please enter last name");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else if (Country.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#errMsgText").html("* Please choose country");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else if (MobileNo.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#errMsgText").html("* Please enter mobile no");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else {
            updateProfile(firstName, lastName, countryId, MobileNo, status);
            return true;
        }
    });


    

    //Invite button in Popup
    $("#btnInvitefriends").on('click', function () {
        var emailId = $("#txtinviteEmailid").val();

        if (emailId.replace(/^\s+|\s+$/g, "").length == 0) {
            $("#errinvite").text("* Please enter emailId");
            return false;
        } else if (!ValidateEmail(emailId)) {
            $("#errinvite").text("* Please enter valid emailId");
            return false;
        } else {
            if (isUserExist(emailId) == 1) {
                addFirend(emailId);
                return true;
            } else if (isUserExist(emailId) == 2) {
                sendEmailNotification(emailId);
                return true;
            } else {
                InviteUser(emailId);
                return true;
            }
        }
    });


    function ValidateEmail(emailId) {
        var reg = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return reg.test(emailId);
    }

    function InviteUser(emailId) {
        Common.ajaxsync({
            url: "/Home/InviteUser",
            data: { 'emailId': emailId },
            success: function (response) {
                $("#inviteFriend").modal('hide');
                $("#commonMsg").text("Email sent Sucessfully");
                $("#modalCommon").modal('show');

            },
            error: function (err) {
            }
        });
    }

    function addFirend(emailId) {
        Common.ajaxsync({
            url: "/Home/AddFriends",
            data: { 'emailId': emailId },
            success: function (response) {
                $("#inviteFriend").modal('hide');
                $("#commonMsg").text("Send Friend Request Sucessfully");
                $("#modalCommon").modal('show');

            },
            error: function (err) {
            }
        });
    }

    function sendEmailNotification(emailId) {
        Common.ajaxsync({
            url: "/Home/SendEmailNotification",
            data: { 'emailId': emailId },
            success: function (response) {
                $("#inviteFriend").modal('hide');
                $("#commonMsg").text("Email sent Sucessfully");
                $("#modalCommon").modal('show');

            },
            error: function (err) {
            }
        });
    }




    function isUserExist(emailId) {
        var statusId = 0;
        Common.ajaxsync({
            url: "/Home/IsUserProfileExist",
            data: { 'emailId': emailId },
            success: function (response) {
                statusId = response;
            },
            error: function (err) {
            }
        });
        return statusId;
    }


    function bytesToSize(bytes) {
        var sizes = ['Bytes', 'KB', 'MB'];
        if (bytes == 0) return 'n/a';
        var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
        return (bytes / Math.pow(1024, i)).toFixed(1) + ' ' + sizes[i];
    };
    // check for selected crop region
    function checkForm() {
        if (parseInt($('#w').val())) return true;
        $('.error').html('Please select a crop region and then press Upload').show();
        return false;
    };
    // update info by cropping (onChange and onSelect events handler)
    function updateInfo(e) {
        $('#x1').val(e.x);
        $('#y1').val(e.y);
        $('#x2').val(e.x2);
        $('#y2').val(e.y2);
        $('#w').val(e.w);
        $('#h').val(e.h);
    };
    // clear info by cropping (onRelease event handler)
    function clearInfo() {
        $('.info #w').val('');
        $('.info #h').val('');
    };
    // Create variables (in this scope) to hold the Jcrop API and image size
    var jcrop_api, boundx, boundy;
    function fileSelectHandler() {
        //debugger;
        // get selected file
        var oFile = $('#image_file')[0].files[0];
        // hide all errors
        $('.error').hide();
        // check for image type (jpg and png are allowed)
        var rFilter = /^(image\/jpeg|image\/png)$/i;
        if (!rFilter.test(oFile.type)) {
            $('.error').html('Please select a valid image file (jpg and png are allowed)').show();
            return;
        }
        // check for file size
        if (oFile.size > 250 * 1024) {
            $('.error').html('You have selected too big file, please select a one smaller image file').show();
            return;
        }
        // preview element
        var oImage = document.getElementById('preview');
        // prepare HTML5 FileReader
        var oReader = new FileReader();
        oReader.onload = function (e) {
            // e.target.result contains the DataURL which we can use as a source of the image
            oImage.src = e.target.result;
            oImage.onload = function () { // onload event handler
                // display step 2
                $('.step2').fadeIn(500);
                // display some basic image info
                var sResultFileSize = bytesToSize(oFile.size);
                $('#filesize').val(sResultFileSize);
                $('#filetype').val(oFile.type);
                $('#filedim').val(oImage.naturalWidth + ' x ' + oImage.naturalHeight);
                // destroy Jcrop if it is existed
                if (typeof jcrop_api != 'undefined') {
                    jcrop_api.destroy();
                    jcrop_api = null;
                    $('#preview').width(oImage.naturalWidth);
                    $('#preview').height(oImage.naturalHeight);
                }
                setTimeout(function () {
                    // initialize Jcrop
                    $('#preview').Jcrop({
                        minSize: [32, 32], // min crop size
                        aspectRatio: 1, // keep aspect ratio 1:1
                        bgFade: true, // use fade effect
                        bgOpacity: .3, // fade opacity
                        onChange: updateInfo,
                        onSelect: updateInfo,
                        onRelease: clearInfo
                    }, function () {
                        // use the Jcrop API to get the real image size
                        var bounds = this.getBounds();
                        boundx = bounds[0];
                        boundy = bounds[1];
                        // Store the Jcrop API in the jcrop_api variable
                        jcrop_api = this;
                    });
                }, 3000);
            };
        };
        // read selected file as DataURL
        return oReader.readAsDataURL(oFile);
    }
    $("#btnUploadImg").on('click', function () {
        $('#status').fadeIn();
        $('#preloader').fadeIn();
        var imgSrc = $('.cropped').find('img').attr('src');
        //alert(imgSrc);
        if (imgSrc == "") {
            $('.error').html('Please choose a image file').show();
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else {
            uploadImage(imgSrc);
            return true;
        }
    });


//    $('#FileUpload1').change(function () {
//        $('#Image1').hide();
//        var reader = new FileReader();
//        reader.onload = function (e) {
//            $('#Image1').show();
//            $('#Image1').attr("src", e.target.result);
//            $('#Image1').Jcrop({
//                onChange: SetCoordinates,
//                onSelect: SetCoordinates
//            });
//        }
//        reader.readAsDataURL($(this)[0].files[0]);
//    });

//    $('#btnCrop').click(function () {
//        var x1 = $('#imgX1').val();
//        var y1 = $('#imgY1').val();
//        var width = $('#imgWidth').val();
//        var height = $('#imgHeight').val();
//        var canvas = $("#canvas")[0];
//        var context = canvas.getContext('2d');
//        var img = new Image();
//        img.onload = function () {
//            canvas.height = height;
//            canvas.width = width;
//            context.drawImage(img, x1, y1, width, height, 0, 0, width, height);
//            $('#imgCropped').val(canvas.toDataURL());
//            $('[id*=btnUpload]').show();
//        };
//        img.src = $('#Image1').attr("src");
//    });
//    $("#btnUpload").on('click', function () {
//        //debugger;
//        var data = $('#imgCropped').val();
//        uploadImage(data);
//    });
//});
//function SetCoordinates(c) {
//    $('#imgX1').val(c.x);
//    $('#imgY1').val(c.y);
//    $('#imgWidth').val(c.w);
//    $('#imgHeight').val(c.h);
//    $('#btnCrop').show();
//};
//function uploadImage(data) {
//    $.ajax({
//        url: "/Home/ImageUpload",
//        type: "POST",
//        data: JSON.stringify({ 'data': data}),
//        dataType: "json",
//        traditional: true,
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            //$("#commonMsg").text("Saved Successfully")
//            //$("#modalCommon").modal('show');
//        },
//        error: function () {
//            alert("An error has occured!!!");
//        }
//    });





    function updateProfile(firstName, lastName, countryId, MobileNo, status) {
        //debugger;
        $.ajax({
            url: "/Home/UpdateProfile",
            type: "POST",
            data: JSON.stringify({ 'firstname': firstName, 'lastname': lastName, 'countryId': parseInt(countryId), 'mobileNo': MobileNo, 'status': status }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                window.location = "../Home/ProfileView";
                
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    }
    function uploadImage(imgSrc) {
        $.ajax({
            url: "/Home/ImageUpload",
            type: "POST",
            data: JSON.stringify({ 'imgSrc': imgSrc }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                window.location = "../Home/ProfileView";
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    }
});