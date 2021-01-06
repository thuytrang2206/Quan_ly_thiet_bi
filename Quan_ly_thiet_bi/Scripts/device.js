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
        var Remark = $("#Remark");
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
                Remark.val() = "";
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
        var Remark = $("#Remark");
        var DateMaintenance = $("#DateMaintenance");
        var Image1 = $("#Image1");
        $.ajax({
            type: "POST",
            url: "/Home/Insert_device",
            data: '{DeviceName:"' + DeviceName.val() + '",Model:"' + Model.val() + '",Serial:"' + Serial.val() + '",VendorName:"' + VendorName.val() + '",Qty:"' + Qty.val() + '",DeviceGroup:"' + DeviceGroup.val() + '",Purpose:"' + Purpose.val() + '",Remark:"' + Remark.val() + '",DateMaintenance:"' + DateMaintenance.val() + '",Image1:"' + Image1.val() + '"}',
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
                Remark.val() = "";
                DateMaintenance.val() = "";
                Image1.val() = "";
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
            $("#Id").val(json.Id)
            $("#DeviceName").val(json.DeviceName);
            $("#Model").val(json.Model);
            $("#Serial").val(json.Serial);
            $("#VendorName").val(json.VendorName);
            $("#Qty").val(json.Qty);
            $("#DeviceGroup").val(json.DeviceGroup);
            $("#Purpose").val(json.Purpose);
            $("#Remark").val(json.Remark);
            $("#DateMaintenance").val(json.DateMaintenance);
           
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}