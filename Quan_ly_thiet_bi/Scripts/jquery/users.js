$(document).ready(function () {
    $("#btn_add_click").click(function () {
        $("#btn_sua").hide();
        $("#btn_Add").show();
    });
})
$("body").on("click", "#btn_Add", function () {
        var NAME = $("#NAME");
        var STAFF_CODE = $("#STAFF_CODE");
        var EMAIL = $("#EMAIL");
        var PASSWORD = $("#PASSWORD");
        var ID_RULE = $("#ID_RULE");
        $.ajax({
            type: "POST",
            url: "/User/Insert_user",
            data: '{NAME:"' + NAME.val() + '",EMAIL:"' + EMAIL.val() + '",PASSWORD:"' + PASSWORD.val() + '",ID_RULE:"' + ID_RULE.val() + '",STAFF_CODE:"' + STAFF_CODE.val() + '"}',
            contentType: "application/json charset=utf-8",
            datatype: "json",
            success: function (data) {
                var newrow = $("#dataTable tr:last-child");
                window.location.reload();
                NAME.val() = "";
                STAFF_CODE.val() = "";
                EMAIL.val() = "";
                PASSWORD.val() = "";
                ID_RULE.val() = "";
            }
        });
});
function Xoa(el) {
    var ID_USER = el.parentNode.parentNode.cells[1].textContent;
    $.ajax({
        url: '/User/Delete_User/?ID_USER=' + ID_USER,
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
    var ID_USER = el.parentNode.parentNode.cells[1].textContent;
    $.ajax({
        url: "/User/Getuser/?ID_USER=" + ID_USER,
        type: "GET",
        dataType: 'json',
        success: function (data) {
            var json = JSON.parse(JSON.stringify(data));
            $("#ID_USER").val(json.ID_USER);
            $("#NAME").val(json.NAME);
            $("#EMAIL").val(json.EMAIL);
            $("#PASSWORD").val(json.PASSWORD);
            $("#ID_RULE").val(json.ID_RULE)
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}