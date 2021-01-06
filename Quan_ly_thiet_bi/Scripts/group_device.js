
$("body").on("click", "#btn_close", function () {
    var NAME = $("#NAME");
    $.ajax({
        type: "POST",
        url: "/Group_device/Index",
        contentType: "application/json charset=utf-8",
        datatype: "json",
        success: function () {
            window.location.reload();
            NAME.val() = "";
        }
    });
});

$("body").on("click", "#btn_Add", function () {

    if ($("#NAME").val() == "" || $("#DESCIPTION").val() == "") {
        alert("Hãy nhập giá trị!");
    }
    else {
        var NAME = $("#NAME");
        var DESCIPTION = $("#DESCIPTION");
        $.ajax({
            type: "POST",
            url: "/Group_device/Insert_groupdevice",
            data: '{NAME:"' + NAME.val() + '",DESCIPTION:"' + DESCIPTION.val() + '"}',
            contentType: "application/json charset=utf-8",
            datatype: "json",
            success: function () {
                var newrow = $("#dataTable tr:last-child");
                window.location.reload();
                NAME.val() = "";
                DESCIPTION.val() = "";
            }
        });
    }
});
function Xoa(el) {
    var id = el.parentNode.parentNode.cells[1].textContent;
    $.ajax({
        url: '/Group_device/Delete_group_device/?id=' + id,
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
        url: "/Group_device/Get_groupdevice/?Id=" + id,
        type: "GET",
        dataType: 'json',
        success: function (data) {
            var json = JSON.parse(data);
            $("#ID_GROUP").val(json.ID_GROUP)
            $("#NAME").val(json.NAME);
            $("#DESCIPTION").val(json.DESCIPTION);
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}