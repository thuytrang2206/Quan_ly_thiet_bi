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

$("body").on("click", "#btn_Add", function () {

    if ($("#NAME").val() == "" || $("#PASSWORD").val() == "") {
        alert("Hãy nhập giá trị!");
    }
    else {
        var NAME = $("#NAME");
        var PASSWORD = $("#PASSWORD");
        var ID_RULE = $("#ID_RULE");
        $.ajax({
            type: "POST",
            url: "/User/Insert_user",
            data: '{NAME:"' + NAME.val() + '",PASSWORD:"' + PASSWORD.val() + '",ID_RULE:"' + ID_RULE.val() + '"}',
            contentType: "application/json charset=utf-8",
            datatype: "json",
            success: function (data) {
                //if (data == 1) {
                //    $("#valiable").html('<font color="Red">Tên nhân viên đã tồn tại</font>');
                //    $("#NAME").css("border-color", "Red");
                //}
                var newrow = $("#dataTable tr:last-child");
                window.location.reload();
                NAME.val() = "";
                PASSWORD.val() = "";
                ID_RULE.val() = "";
            }
        });
    }
});
function Sua(el) {
    event.preventDefault();
    $("#btn_sua").show();

    var ID_USER = el.parentNode.parentNode.cells[1].textContent;
    $.ajax({
        url: "/User/Getuser/?ID_USER=" + ID_USER,
        type: "GET",
        dataType: 'json',
        success: function (data) {
            var json = JSON.parse(data);
            $("#ID_USER").val(json.ID_USER);
            $("#NAME").val(json.NAME);
            $("#PASSWORD").val(json.PASSWORD);
            $("#ID_RULE").val(json.ID_RULE)
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
