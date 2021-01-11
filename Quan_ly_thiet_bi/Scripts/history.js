$(document).ready(function () {
    $("#btnsubmit").click(function () {
        $.ajax({
            type: "POST",
            url: "/PlaneRepair/Detail_plan_repair",
            data: {
                NOTE: $("NOTE").val(),
            }
        });
    });
});