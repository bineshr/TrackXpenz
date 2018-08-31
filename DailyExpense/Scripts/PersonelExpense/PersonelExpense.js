$(document).ready(function () {
    $('#status').fadeOut();
    $('#preloader').fadeOut();
    $("#txtdate").datepicker();
    $("#txtdate").val("");
    $("#txtamount").val("");
    $("#btnSavePerExp").on('click', function () {
        $('#status').fadeIn();
        $('#preloader').fadeIn();
        var product = $("#ddlproduct").val();
        var description = $("#txtdescription").val();
        var date = $("#txtdate").val();
        var amount = $("#txtamount").val();
        var numberregex = /^[0-9]*$/;
        
        if (product == "") {
            $("#perExpErrmsg").text("* Please select the product");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else if (description == "") {
            $("#perExpErrmsg").text("* Please enter the description");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else if (date == "") {
            $("#perExpErrmsg").text("* Please select the date");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        } else if (amount == "") {
            $("#perExpErrmsg").text("* Please enter the amount");
            $('#status').fadeOut();
            $('#preloader').fadeOut();
            return false;
        //} else if (!numberregex.test(amount)) {
        //    $("#perExpErrmsg").text("* Amount accepts number only");
        //    return false;
        } else {
            saveExpensed(product, description, date, amount);
            $("#perExpErrmsg").text("");
            
        }
    });

    function saveExpensed(product, description, date, amount) {
        $.ajax({
            url: "/Expense/SavePersonelExpenses",
            type: "POST",
            data: JSON.stringify({ 'productId': parseInt(product), 'description': description, 'date': date, 'amount': amount }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#ddlproduct").text("Select Products");
                $("#ddlproduct").val("");
                $("#txtdescription").val("");
                $("#txtdate").val("");
                $("#txtamount").val("");
                $("#commonMsg").text("Saved Successfully")
                $("#modalCommon").modal('show');
                $('#status').fadeOut();
                $('#preloader').fadeOut();
            },
            error: function () {
                alert("An error has occured!!!");
            }
        });
    }   
});

