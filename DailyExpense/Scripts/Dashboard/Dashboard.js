$(document).ready(function () {
    getChartByProductName();
    //$("#btnSave").on('click', function () {
    //    //alert("W");
    //    var amount = $("#totalAmnt").val();
    //    if (amount == "") {
    //        $("#errToInc").html("* Please enter amount");
    //        return false;
    //    } else {
    //        saveIncome(amount);
    //        return true;
    //    }
    //});



    function getChartByProductName() {
        
        $.ajax({
            url: "/Home/GetChartByProductName",
            type: "POST",
            //data: JSON.stringify({ 'amount': amount }),
            dataType: "json",
            traditional: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger;
                var Data = [],
                 catog = [];

                for (var i = 0; i < data.length; i++) {
                    catog.push(data[i].ProductName);
                    Data.push(Number(data[i].Amount));
                }
                var area = new Morris.Area({
                    element: 'revenue-chart',
                    resize: true,
                    data: Data,

                    xkey: catog,
                    ykeys: Data,
                    //labels: ['Item 1', 'Item 2'],
                    lineColors: ['#a0d0e0', '#3c8dbc'],
                    hideHover: 'auto'
                });
            },
            error: function () {
                //alert("An error has occured!!!");
            }
        });
    }

});