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
        //dataType: "json",
        type: 'GET',
        success: function (response) {
            //alert("Success");
            //$("#ddlCityModel").html(response);
            //loadHooks(); use if button added
            $("#ddlCityModel").empty();
            $.each(response, function (i, item) {
                $("#ddlCityModel").append($("<option>").text(item.text).val(item.Value));
            });
            
            console.log(response);
        },
        error: function (response) {
            //alert(response);
            console.log(response);
        }
    })
}

function getMeasurementsInfo() {

    var cityName = $("#countryModel_selectedCountryCode option:selected").val();

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