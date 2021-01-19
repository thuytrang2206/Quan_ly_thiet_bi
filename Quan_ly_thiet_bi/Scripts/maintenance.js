$("body").on("click", "#btn_Add", function () {

    var Id_device = $("#Id_device");
    var Classifymaintenance = $('input[name=Classifymaintenance]:checked').val();
    var Checkmaintenance = $('input[name=Checkmaintenance]:checked').val();
    var Personmaintenance = $("#Personmaintenance");
    var FrequencyCheck = $("#FrequencyCheck");
    $.ajax({
        type: "POST",
        url: "/Home/Insert_maintenance",
        data: '{Id_device:"' + Id_device.val() + '",Classifymaintenance:"' + Classifymaintenance + '",Checkmaintenance:"' + Checkmaintenance + '",Personmaintenance:"' + Personmaintenance.val() + '",FrequencyCheck:"' + FrequencyCheck.val() + '"}',
        contentType: "application/json charset=utf-8",
        datatype: "json",
        success: function () {
            var newrow = $("#dataTable1 tr:last-child");
            location.reload();
            Classifymaintenance.val() = "";
            Checkmaintenance.val() = "";
            Personmaintenance.val() = "";
            FrequencyCheck.val() = "";
        }
    });
});

$(document).ready(function () {
    $('input[type="radio"]').click(function () {
        if ($('input:radio[name=Classifymaintenance]:checked').val() == "1") {
            $("#classify1").show();
            $("#classify2").hide();
            $("#classify3").hide();
        }
        else if ($('input:radio[name=Classifymaintenance]:checked').val() == "2") {
            $("#classify1").hide();
            $("#classify2").show();
            $("#classify3").hide()
        }

        else {
            $("#classify1").hide();
            $("#classify2").hide();
            $("#classify3").show()
        }
    });
});