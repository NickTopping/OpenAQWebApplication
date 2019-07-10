$(document).ready(function () {
    loadHooks();
});

function loadHooks() {
    $("#CountryModel_SelectedCountryCode").change(function () {
        getCityInfo()
    });
}

function getCityInfo() {

    var countryCode = $("#CountryModel_SelectedCountryCode option:selected").val();

    return $.ajax({
        url: 'Home/GetCitiesRequest',
        data: {
            countryCode: countryCode
        },
        type: 'GET',
        success: function (response) {
            $("#ddlCityModel").html(response);
            //loadHooks(); use if button added
        },
        error: function (response) {
            alert(response);
        }
    })
}

function getMeasurementsInfo() {

    var cityName = $("#CountryModel_SelectedCountryCode option:selected").val();

    return $.ajax({
        url: 'Home/GetCitiesRequest',
        data: {
            countryCode: countryCode
        },
        type: 'GET',
        success: function (response) {
            $("#ddlCityModel").html(response);
            //loadHooks(); use if button added
        },
        error: function (response) {
            alert(response);
        }
    })
}