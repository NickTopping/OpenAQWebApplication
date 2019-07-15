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

    $("#btnFilter").click(function () {
        getMeasurementsInfo();
        $('#filterModal').hide();
    });

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

            $("#cityModel_selectedCityName").empty();
            $.each(response, function (i, item) {
                $("#cityModel_selectedCityName").append($('<option></option>').text(item.city).val(item.city));
            });

            getMeasurementsInfo()
        },
        error: function (response) {
            console.log(response);
        }
    })
}

function getMeasurementsInfo() {

    var cityName = $("#cityModel_selectedCityName option:selected").val();
    var rowLimit = $("#txtRows").val();
    var table = $('#gridView > tbody');

    var parameters = filterMeasurements();

    return $.ajax({
        url: '/Home/GetMeasurementsRequest',
        data: {
            cityName: cityName,
            queryParameters: parameters,
            limit: rowLimit
        },
        type: 'GET',
        success: function (response) {

            $("#gridContainer").html(response);
        },
        error: function (response) {
            console.log(response);
        }
    })
}

function filterMeasurements() {

    var dateFrom = "";
    var dateTo = "";
    var airParameters = "";

    if ($("#dtpFrom").val() != "") {
        dateFrom = 'date_from=' + $("#dtpFrom").val() + 'T00:00:00&';
    }

    if ($("#dtpFrom").val() != "") {
        dateTo = 'date_to=' + $("#dtpTo").val() + 'T23:59:59&';
    }
    
    if ($('#cbParametersPm25').is(":checked")) { 
        airParameters += 'parameter[]=' + $("#cbParametersPm25").attr("name") + '&';
    }

    if ($('#cbParametersPm10').is(":checked")) {
        airParameters += 'parameter[]=' + $("#cbParametersPm10").attr("name") + '&';
    }

    if ($('#cbParametersSo2').is(":checked")) {
        airParameters += 'parameter[]=' + $("#cbParametersSo2").attr("name") + '&';
    }

    if ($('#cbParametersNo2').is(":checked")) {
        airParameters += 'parameter[]=' + $("#cbParametersNo2").attr("name") + '&';
    }

    if ($('#cbParametersO3').is(":checked")) {
        airParameters += 'parameter[]=' + $("#cbParametersO3").attr("name") + '&';
    }

    if ($('#cbParametersCo').is(":checked")) {
        airParameters += 'parameter[]=' + $("#cbParametersCo").attr("name") + '&';
    }

    if ($('#cbParametersBc').is(":checked")) {
        airParameters += 'parameter[]=' + $("#cbParametersBc").attr("name") + '&';
    }

    var parametersString = dateFrom + dateTo + airParameters;

    return parametersString;
}