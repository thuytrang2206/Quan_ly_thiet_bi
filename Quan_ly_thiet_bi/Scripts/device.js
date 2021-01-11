$(document).ready(function () {
    $("#btn_edit").click(function () {
        $("#btn_Add").hide();
    });
})
$(document).ready(function () {
    $("#btn_add_click").click(function () {
        $("#btn_sua").hide();
    });
})
$("body").on("click", "#btn_close", function () {
        var DeviceName = $("#DeviceName");
        var Model = $("#Model");
        var Serial = $("#Serial");
        var VendorName = $("#VendorName");
        var Qty = $("#Qty");
        var DeviceGroup = $("#DeviceGroup");
        var Purpose = $("#Purpose");
        var Location = $("#Location");
        var DateMaintenance = $("#DateMaintenance");
        $.ajax({
            type: "POST",
            url: "/Home/Index",
            contentType: "application/json charset=utf-8",
            datatype: "json",
            success: function () {
                window.location.reload();
                DeviceName.val() = "";
                Model.val() = "";
                Serial.val() = "";
                VendorName.val() = "";
                Qty.val() = "";
                DeviceGroup.val() = "";
                Purpose.val() = "";
                Location.val() = "";
                DateMaintenance.val() = "";
            }
        });
});
$("body").on("click", "#btn_Add", function () {

    if ($("#DeviceName").val() == "" || $("#Model").val() == "") {
        alert("Hãy nhập giá trị!");
    }
    else {
        var DeviceName = $("#DeviceName");
        var Model = $("#Model");
        var Serial = $("#Serial");
        var VendorName = $("#VendorName");
        var Qty = $("#Qty");
        var DeviceGroup = $("#DeviceGroup");
        var Purpose = $("#Purpose");
        var Location = $("#Location");
        var DateMaintenance = $("#DateMaintenance");
        var Image1 = $("#Image1");
        var Status = $('input[name=Status]:checked').val();
        //var Status = $("#Status")
        $.ajax({
            type: "POST",
            url: "/Home/Insert_device",
            data: '{DeviceName:"' + DeviceName.val() + '",Model:"' + Model.val() + '",Serial:"' + Serial.val() + '",VendorName:"' + VendorName.val() + '",Qty:"' + Qty.val() + '",DeviceGroup:"' + DeviceGroup.val() + '",Purpose:"' + Purpose.val() + '",Location:"' + Location.val() + '",DateMaintenance:"' + DateMaintenance.val() + '",Image1:"' + Image1.val() + '",Status:"' + Status + '"}',
            contentType: "application/json charset=utf-8",
            datatype: "json",
            success: function () {
                var newrow = $("#dataTable tr:last-child");
                window.location.reload();
                DeviceName.val() = "";
                Model.val() = "";
                Serial.val() = "";
                VendorName.val() = "";
                Qty.val() = "";
                DeviceGroup.val() = "";
                Purpose.val() = "";
                Location.val() = "";
                DateMaintenance.val() = "";
                Image1.val() = "";
                Status.val() = "";
            }
        });
    }
});
function Xoa(el) {
    var id = el.parentNode.parentNode.cells[1].textContent;
    $.ajax({
        url: '/Home/Delete_Device/?id=' + id,
        type: 'POST',
        dataType: 'json',
        success: function () {
            alert("Xóa thành công");
            window.location.reload();
        },
        error: function () {
            alert("Xóa thất bại");
            window.location.reload();
        }
    });
}
function Sua(el) {
    event.preventDefault();
    $("#btn_sua").show();

    var id = el.parentNode.parentNode.cells[1].textContent;
    $.ajax({
        url: "/Home/Getdevice/?Id=" + id,
        type: "GET",
        dataType: 'json',
        success: function (data) {

            var json = JSON.parse(data);
            const d = new Date(json.DateMaintenance);
            const formattedDate = d.getFullYear() + '-' + ("0" + (d.getMonth() + 1)).slice(-2) + '-' + ("0" + d.getDate()).slice(-2);
            $("#Id").val(json.Id);
            $("#DeviceName").val(json.DeviceName);
            $("#Model").val(json.Model);
            $("#Serial").val(json.Serial);
            $("#VendorName").val(json.VendorName);
            $("#Qty").val(json.Qty);
            $("#DeviceGroup").val(json.DeviceGroup);
            $("#Purpose").val(json.Purpose);
            $("#Location").val(json.Location);
            $("#DateMaintenance").val(formattedDate);
            $("#Status").val($('input[name=Status]:checked').val(json.Status));
            $("#Image1").val(json.Image1);
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}