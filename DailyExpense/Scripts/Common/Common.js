$(document).ready(function () {
    $("#comSignInUp").on('click', function () {
        //alert("hii");
        if ($(this).text() == "Sign Up") {
            window.location = "../Home/SignUp";
        } else {
            window.location = "../Home/SignIn";
        }
    });
    $(".dash_board").on('click', function () {
        window.location = "../Home/Dashboard";
    });
    //$("#notifiCount").html($("#notificationCount").attr("data-value"));
    $(".sidebar-menu li").on('click', function () {
        $(this).addClass('active').siblings('li').removeClass('active');
    });
    //$("body").prepend('<div id="preloader"><div class="spinner-sm spinner-sm-1" id="status"> </div></div>');
    $(window).on('load', function () { // makes sure the whole site is loaded 
        $('#status').fadeOut(); // will first fade out the loading animation 
        $('#preloader').delay(350).fadeOut('slow'); // will fade out the white DIV that covers the website. 
        $('body').delay(350).css({ 'overflow': 'visible' });
    })
});

$(document).on('click', '.btn_acpt', function (e) {
    //alert("a");
    var notificationId = $(this).attr("data-value");
    //$(this).parents('li').remove();
    acceptFriendRequst(notificationId);
});

$(document).on('click', '.btn_rjct', function (e) {
    //alert("ss");
    var notificationId = $('.btn_rjct').attr("data-value");
    rejectFriendRequst(notificationId);
});

$("#notifyModal").on('click', function () {
    $("#modal-notification").modal('show');
    
});

    window.setInterval(function getNotifications() {
        $.ajax({
            url: "/Home/Notification",
            type: "POST",
            //data: JSON.stringify({ 'notificationId': notificationId }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                //debugger;
                //alert(data);
                var notificationCount = data.notification.length;
                if (notificationCount != 0) {
                    $('.notification-menu li').remove();
                    $('.notifications-menu').find('.menu-bell').remove();
                    $('.notifications-menu').find('.not-numdisplay').append('<span class="label label-warning menu-bell">' + notificationCount + '</span>');
                    $(".notification-menu").append('<li data-toggle="modal" data-target="#modal-notification"><a href="#"><i class="fa fa-user text-red"></i>You have ' + notificationCount + ' Friend Request</a></li>');
                    $('.modalfrndReq li').remove();
                    for (i = 0; i < notificationCount; i++) {
                        $('.modalfrndReq').append('<li style="list-style-type:none;"><p><i class="fa fa-user text-red"></i> ' + data.notification[0].friendUserName + ' send to you Friend Request.</p><button type="button" class="btn btn-block btn-success btn-sm btn_acpt" data-value="' + data.notification[0].notificationId + '"><i class="fa fa-thumbs-up text-white" aria-hidden="true"></i>&nbsp;&nbsp;Accept</button><button type="button" class="btn btn-block btn-danger btn-sm btn_rjct" data-value="' + data.notification[0].notificationId + '"><i class="fa fa-thumbs-down text-white" aria-hidden="true"></i>&nbsp;&nbsp;Reject</button></li>')
                    }

                } else {
                    $('.notification-menu li').remove();
                    $('.notifications-menu').find('.menu-bell').remove();
                    $(".notification-menu").append('<li data-toggle="modal" data-target="#modal-notification"><a href="#"><i class="fa fa-user text-red"></i>You have no Notifications</a></li>');
                }

            },
            error: function () {
                //alert("An error has occured!!!");
            }
        });
    }, 5000);



//function getNotificationContent() {
//    $.ajax({
//        url: "/Home/Notification",
//        type: "POST",
//        //data: JSON.stringify({ 'notificationId': notificationId }),
//        dataType: "json",
//        traditional: true,
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            //debugger;
//            var notificationCount = data.notification.length;
//            //$('.notification-menu li').remove();
//            //$('.notifications-menu').find('.menu-bell').remove();
//            //$('.notifications-menu').find('.not-numdisplay').append('<span class="label label-warning menu-bell">' + notificationCount + '</span>');
//            //$(".notification-menu").append('<li data-toggle="modal" data-target="#modal-notification"><a href="#"><i class="fa fa-user text-red"></i>You have ' + notificationCount + ' Friend Request</a></li>');
//            $('.modalfrndReq li').remove();
//            for (i = 0; i < notificationCount; i++) {
//                $('.modalfrndReq').append('<li style="list-style-type:none;"><p><i class="fa fa-user text-red"></i> ' + data.notification[0].friendUserName + ' send to you Friend Request.</p><button type="button" class="btn btn-block btn-success btn-sm btn_acpt" data-value="' + data.notification[0].notificationId + '"><i class="fa fa-thumbs-up text-black" aria-hidden="true"></i>&nbsp;&nbsp;Accept</button><button type="button" class="btn btn-block btn-danger btn-sm btn_rjct" data-value="' + data.notification[0].notificationId + '"><i class="fa fa-thumbs-down text-black" aria-hidden="true"></i>&nbsp;&nbsp;Reject</button></li>')
//            }
//            $("#modal-notification").modal('show');
//        },
//        error: function () {
//            alert("An error has occured!!!");
//        }
//    });
//}


function acceptFriendRequst(notificationId) {
    debugger;
    $.ajax({
        url: "/Home/AcceptFriendRequest",
        type: "POST",
        data: JSON.stringify({ 'notificationId': notificationId }),
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
}
function rejectFriendRequst(notificationId) {
    debugger;
    $.ajax({
        url: "/Home/RejectFriendRequest",
        type: "POST",
        data: JSON.stringify({ 'notificationId': notificationId }),
        dataType: "json",
        traditional: true,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
}

var Common = {
    ajax: function (option) {
        try {
            // cross origin problem (basically IE)
            $.support.cors = true;

            // ajax request
            $.ajax({
                cache: false,
                type: 'GET',
                url: (option.url) ? option.url : '',
                data: (option.data) ? option.data : null,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (typeof option.success == 'function') {
                        option.success(data);
                    }
                },
                error: function (err) {
                    if (typeof option.error == 'function') {
                        option.error(err);
                    }
                }
            });
        } catch (e) {
            //            alert('Not able to complete your request!');
        }
    },
    ajaxsync: function (option) {
        try {
            // cross origin problem (basically IE)
            $.support.cors = true;

            // ajax request
            $.ajax({
                cache: false,
                type: 'GET',
                async: false,
                url: (option.url) ? option.url : '',
                data: (option.data) ? option.data : null,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (typeof option.success == 'function') {
                        option.success(data);
                    }
                },
                error: function (err) {
                    if (typeof option.error == 'function') {
                        option.error(err);
                    }
                }
            });
        } catch (e) {
            //            alert('Not able to complete your request!');
        }
    },
    ajaxnocache: function (option) {
        try {
            // cross origin problem (basically IE)
            $.support.cors = true;

            // ajax request
            $.ajax({
                cache: false,
                type: 'GET',

                url: (option.url) ? option.url : '',
                data: (option.data) ? option.data : null,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (typeof option.success == 'function') {
                        option.success(data);
                    }
                },
                error: function (err) {
                    if (typeof option.error == 'function') {
                        option.error(err);
                    }
                }
            });
        } catch (e) {
            //            alert('Not able to complete your request!');
        }
    },
    ajaxPost: function (option) {
        try {
            // cross origin problem (basically IE)
            $.support.cors = true;

            // ajax request
            $.ajax({
                type: 'POST',
                async: false,
                url: (option.url) ? option.url : '',
                data: JSON.stringify(option.data),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (typeof option.success == 'function') {
                        option.success(data);
                    }
                },
                error: function (err) {
                    if (typeof option.error == 'function') {
                        option.error(err);
                    }
                }
            });
        } catch (e) {
            //            alert('Not able to complete your request!');
        }
    },
    ajaxSyncPost: function (option) {
        try {
            // cross origin problem (basically IE)
            $.support.cors = true;

            // ajax request
            $.ajax({
                type: 'POST',
                url: (option.url) ? option.url : '',
                data: JSON.stringify(option.data),
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (typeof option.success == 'function') {
                        option.success(data);
                    }
                },
                error: function (err) {
                    if (typeof option.error == 'function') {
                        option.error(err);
                    }
                }
            });
        } catch (e) {
            //            alert('Not able to complete your request!');
        }
    },
    ajaxBlog: function (option) {
        try {
            // cross origin problem (basically IE)
            $.support.cors = true;

            // ajax request
            $.ajax({
                type: 'GET',
                cache: false,
                url: (option.url) ? option.url : '',
                dataType: "jsonp",
                //contentType: "application/json; charset=utf-8",
                crossDomain: true,
                success: function (data) {
                    if (typeof option.success == 'function') {
                        option.success(data);
                    }
                },
                error: function (e) {
                    if (typeof option.error == 'function') {
                        option.error(e);
                    }
                }
            });
        } catch (e) {
            //            alert('Not able to complete your request!');
        }
    },
    ajaxtxt: function (option) {
        try {
            // cross origin problem (basically IE)
            $.support.cors = true;

            // ajax request
            $.ajax({
                cache: false,
                type: 'GET',
                url: (option.url) ? option.url : '',
                data: (option.data) ? option.data : null,
                //  dataType: "json",
                //contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (typeof option.success == 'function') {
                        option.success(data);
                    }
                },
                error: function (err) {
                    if (typeof option.error == 'function') {
                        option.error(err);
                    }
                }
            });
        } catch (e) {
            //            alert('Not able to complete your request!');
        }
    }
};
