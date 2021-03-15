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
        var DeviceName = $("#DeviceName");
        var Model = $("#Model");
        var ScortCode = $("#ScortCode");
        var VendorName = $("#VendorName");
        var Qty = $("#Qty");
        var DeviceGroup = $("#DeviceGroup");
        var Remark = $("#Remark");
        var Location = $("#Location");
        var Image1 = $("#Image1");
        var DevicePrice = $("#DevicePrice");
        var Installtime = $("#Installtime");
        var Status = $('input[name=Status]:checked').val();
        $.ajax({
            type: "POST",
            url: "/Home/Insert_device",
            data: '{DeviceName:"' + DeviceName.val() + '",Model:"' + Model.val() + '",ScortCode:"' + ScortCode.val() + '",VendorName:"' + VendorName.val() + '",Qty:"' + Qty.val() + '",DeviceGroup:"' + DeviceGroup.val() + '",Remark:"' + Remark.val() + '",Location:"' + Location.val() + '",DevicePrice:"' + DevicePrice.val() + '",Installtime:"' + Installtime.val() + '",Image1:"' + Image1.val() + '",Status:"' + Status + '"}',
            contentType: "application/json charset=utf-8",
            datatype: "json",
            success: function () {
                var newrow = $("#dataTable tr:last-child");
                location.reload();
                DeviceName.val() = "";
                Model.val() = "";
                ScortCode.val() = "";
                VendorName.val() = "";
                Qty.val() = "";
                DeviceGroup.val() = "";
                Remark.val() = "";
                Location.val() = "";
                DevicePrice.val() = "";
                Installtime.val() = "";
                Image1.val() = "";
                Status.val() = "";
            }
        });
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
    $("#btn_Add").hide();
    var Id = el.parentNode.parentNode.cells[1].textContent;
    $.ajax({
        url: "/Home/Get_device/?Id=" + Id,
        type: "GET",
        dataType: 'json',
        success: function (data) {
            var json = JSON.parse(JSON.stringify(data));
            var date = json.Installtime;
            const d = new Date(parseInt((json.Installtime).substr(6)));
            const time = d.getFullYear() + '-' + ("0" + (d.getMonth() + 1)).slice(-2) + '-' + ("0" + d.getDate()).slice(-2);
            $("#Id").val(json.Id);
            $("#DeviceName").val(json.DeviceName);
            $("#Model").val(json.Model);
            $("#ScortCode").val(json.ScortCode);
            $("#VendorName").val(json.VendorName);
            $("#Qty").val(json.Qty);
            $("#DeviceGroup").val(json.DeviceGroup);
            $("#Remark").val(json.Remark);
            $("#Location").val(json.Location);
            $("#Installtime").val(time);
            $("#DevicePrice").val(json.DevicePrice);
            $("#Image1").val(json.Image1);
            $('input[type="radio"][value="1"]').val();
            if (json.Status == $('input[type="radio"][value="1"]').val()) {
                $('[name=Status][value="1"]').prop('checked', true);
            }
            else {
                $('[name=Status][value="0"]').prop('checked', true);
            }
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}