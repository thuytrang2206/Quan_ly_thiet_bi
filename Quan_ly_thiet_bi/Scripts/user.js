
$("body").on("click", "#btn_Add", function () {

    if ($("#NAME").val() == "" || $("#EMAIL").val() == "" || $("#PASSWORD").val() == "") {
        alert("Hãy nhập giá trị!");
    }
    else {
        var NAME = $("#NAME");
        var EMAIL = $("#EMAIL");
        var PASSWORD = $("#PASSWORD");
        var ID_RULE = $("#ID_RULE");
        $.ajax({
            type: "POST",
            url: "/User/Insert_user",
            data: '{NAME:"' + NAME.val() + '",EMAIL:"' + EMAIL.val() + '",PASSWORD:"' + PASSWORD.val() + '",ID_RULE:"' + ID_RULE.val() + '"}',
            contentType: "application/json charset=utf-8",
            datatype: "json",
            success: function (data) {
                var newrow = $("#dataTable tr:last-child");
                window.location.reload();
                NAME.val() = "";
                EMAIL.val() = "";
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
