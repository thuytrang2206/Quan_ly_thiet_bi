$("body").on("click", "#btn_Add", function () {

    var Type_Device = $("#Type_Device");
    var Classifymaintenance = $("#Classifymaintenance");
    var Checkmaintenace = $("#Checkmaintenace");
    var FrequencyCheck = $("#FrequencyCheck");
    
    $.ajax({
        type: "POST",
        url: "/Maintenance/Insert_maintenance",
        data: '{Classifymaintenance:"' + Classifymaintenance.val() + '",Checkmaintenace:"' + Checkmaintenace.val() + '",FrequencyCheck:"' + FrequencyCheck.val() + '",Type_Device:"' + Type_Device.val() + '"}',
        contentType: "application/json charset=utf-8",
        datatype: "json",
        success: function () {
            var newrow = $("#dataTable tr:last-child");
            window.location.reload();
            Classifymaintenance.val() = "";
            Checkmaintenace.val() = "";
            FrequencyCheck.val() = "";
            Type_Device.val() = "";
        }
    });
});