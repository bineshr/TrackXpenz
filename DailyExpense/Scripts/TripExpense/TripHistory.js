$(document).ready(function () {
    $('#status').fadeOut();
    $('#preloader').fadeOut();
    $('.btn-trip-submit').on('click', function () {
        $('#status').fadeIn();
        $('#preloader').fadeIn();
        //alert($(this).attr('data-attr'));
        var tripId = $(this).attr('data-attr');
        window.location = "../Expense/TripExpenseEntry?tripId=" + tripId;      
    });
    $('.btn-trip-finished').on('click', function () {        
        $('#status').fadeIn();
        $('#preloader').fadeIn();
        //alert($(this).attr('data-attr'));
        var tripId = $(this).attr('data-attr');
        $("#loadTripHistory").load("../Expense/LoadTripHistory?tripId=" + tripId, function () {
            $("#modalTripHistory").modal('show');
            $('#status').fadeOut();
            $('#preloader').fadeOut();
        });
        //window.location = "../Expense/TripExpenseEntry?tripId=" + tripId;
    });

    $(".close_historyModal").on('click', function () {
        window.location = "../Expense/TripHistory";
    });
});