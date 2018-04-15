
function GetChoice(carID) {

    var start = $("#dateStart").val();
    var end = $("#dateEnd").val();
    var manufactur = $("#getManufatur").val();

    var dataToSend = {
        id: carID,
        manufactur: manufactur,
        start: start,
        end: end
    };
    $.get("/Work/DoCalculation", dataToSend, function (response) {

        $("#container").empty().html(response);
    }).error(function (error) { alert(error = "הזן ערך חוקי"); });
};

//הצג כל הרכבים
function TTTT() {
    $.get("/Work/AllCarsByPV", "", function (result) {
        $("#container").empty().html(result);
    });
}



//הצג רכבים לפי תאריך רצוי
$(function () {

    $("#getCarsByDate").click(function () {

        var start = $("#dateStart").val();
        var end = $("#dateEnd").val();
        var manufactur = $("#getManufatur").val();
        var model = $("#getModel").val();
        var year = $("#getYear").val();

        var dataToSend = {

            start: start,
            end: end,
            manufactur: manufactur,
            model: model,
            year: year
        };
        $.get("/Work/GetCarsByFilter", dataToSend, function (response) {
            $("#container").html(response);
        }).error(function (error) { alert(error = "הזן ערך חוקי"); });
    });

});