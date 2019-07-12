$(document).ready(function () {
    loadHooks();
});

function loadHooks() {
    $("#countryModel_selectedCountryCode").change(function () {
        getCityInfo()
    });

    $("#cityModel_selectedCityName").change(function () {
        getMeasurementsInfo()
    });

    //$(".searchButton").click(function () {
    //    var roomId = $(this).parent().attr("roomId");
    //    getRoomInfo(roomId);
    //});

    $(".close").click(function () {
        $(this).closest('.modal').hide();
        $("#filterModal").hide();
    });

    $("#filterBtn").click(function () {
        $("#filterModal").show();
    });
}

function getCityInfo() {

    var countryCode = $("#countryModel_selectedCountryCode option:selected").val();

    return $.ajax({
        url: '/Home/GetCitiesRequest',
        data: {
            countryCode: countryCode
        },
        contentType: "application/json; charset=utf-8",
        type: 'GET',
        success: function (response) {
            //loadHooks(); //use if button added
            $("#cityModel_selectedCityName").empty();
            $.each(response, function (i, item) {
                $("#cityModel_selectedCityName").append($('<option></option>').text(item.city).val(item.city));
            });
            
            console.log(response);
        },
        error: function (response) {
            console.log(response);
        }
    })
}

function getMeasurementsInfo() {

    var cityName = $("#cityModel_selectedCityName option:selected").val();
    var table = $('#gridView > tbody');

    return $.ajax({
        url: '/Home/GetMeasurementsRequest',
        data: {
            cityName: cityName
        },
        type: 'GET',
        success: function (response) {

            console.log(response);
            //loadHooks(); //use if button added
            $(table).empty();
            $.each(response, function (a, b) {
                $('tr:odd').css('background-color', '#afdeee');
                (table).append("<tr><td>" + b.location + "</td>" +
                                   "<td>" + b.parameter + "</td>" +
                                   "<td>" + b.value + "</td>" +
                                   "<td>" + b.unit + "</td>" +
                                   "<td>" + b.utc + "</td>" +
                                   "<td>" + b.local + "</td>" +
                                   "<td>" + b.latitude + "</td>" +
                                   "<td>" + b.longitude + "</td></tr>");                                   
            });           
        },
        error: function (response) {
            console.log(response);
        }
    })
}

function filterMeasurements() {
    var number = $("#txtRoomNumber").val();
    var type = $("#ddlType option:selected").val();
    var status = $("#ddlStatus option:selected").val();

    $.ajax({
        url: '/Room/FilterRooms',
        data: {
            roomNumber: number,
            type: type,
            status: status
        },
        type: 'GET',
        success: function (response) {
            $("#roomContainer").html(response);
        },
        error: function (response) {
            alert(response);
        }
    })
}