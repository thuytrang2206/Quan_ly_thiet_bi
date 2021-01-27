$("body").on("click", "#btn_Add", function () {

    var Id_device = $("#Id_device");
    var Classifymaintenance = $('input[name=Classifymaintenance]:checked').val();
    var Checkmaintenance = $('input[name=Checkmaintenance]:checked').val();
    var Personmaintenance = $("#Personmaintenance");
    //var FrequencyCheck = $("#FrequencyCheck");
    var DatePlan = $("#DatePlan");
    $.ajax({
        type: "POST",
        url: "/Home/Insert_maintenance",
        data: '{Id_device:"' + Id_device.val() + '",Classifymaintenance:"' + Classifymaintenance + '",Checkmaintenance:"' + Checkmaintenance + '",Personmaintenance:"' + Personmaintenance.val() + '",DatePlan:"' + DatePlan.val() + '"}',
        contentType: "application/json charset=utf-8",
        datatype: "json",
        success: function () {
            var newrow = $("#dataTable1 tr:last-child");
            location.reload();
            Classifymaintenance.val() = "";
            Checkmaintenance.val() = "";
            Personmaintenance.val() = "";
            DatePlan.val() = "";
        }
    });
});
$(document).ready(function () {
    $('input[type="radio"]').click(function () {
        if ($('input:radio[name=Classifymaintenance]:checked').val() == "Bảo dưỡng lớn") {
            $('input:radio[name=Checkmaintenance][value=""]:checked').val().show();
        }
        else if ($('input:radio[name=Classifymaintenance]:checked').val() == "Bảo dưỡng nhỏ") {
            $("#classify1").hide();
            $("#classify2").show();
            $("#classify3").hide();
        }
        else if ($('input:radio[name=Classifymaintenance]:checked').val() == "Bảo dưỡng toàn bộ") {
            $("#classify1").hide();
            $("#classify2").hide();
            $("#classify3").show();
        }
        else {
            $("#classify1").hide();
            $("#classify2").hide();
            $("#classify3").hide();
        }
    });
});
//$(document).ready(function () {
//    $('input[type="radio"]').click(function () {
//        if ($('input:radio[name=Classifymaintenance]:checked').val() == "Bảo dưỡng lớn") {
//            $("#classify1").show();
//            $("#classify2").hide();
//            $("#classify3").hide();
//        }
//        else if ($('input:radio[name=Classifymaintenance]:checked').val() == "Bảo dưỡng nhỏ") {
//            $("#classify1").hide();
//            $("#classify2").show();
//            $("#classify3").hide();
//        }
//        else if ($('input:radio[name=Classifymaintenance]:checked').val() == "Bảo dưỡng toàn bộ") {
//            $("#classify1").hide();
//            $("#classify2").hide();
//            $("#classify3").show();
//        }
//        else {
//            $("#classify1").hide();
//            $("#classify2").hide();
//            $("#classify3").hide();
//        }
//    });
//});