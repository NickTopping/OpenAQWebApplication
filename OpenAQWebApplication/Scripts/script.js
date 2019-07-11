$(document).ready(function () {
    loadHooks();
});

function loadHooks() {
    $("#countryModel_selectedCountryCode").change(function () {
        getCityInfo()
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
            //loadHooks(); use if button added
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

    return $.ajax({
        url: 'Home/GetMeasurementsRequest',
        data: {
            cityName: cityName
        },
        type: 'GET',
        success: function (response) {
            //loadHooks(); use if button added
            $("#cityModel_selectedCityName").empty();
            $.each(response, function (i, item) {
                $("#cityModel_selectedCityName").append($('<option></option>').text(item.city).val(item.city));
            });           
        },
        error: function (response) {
            console.log(response);
        }
    })
}