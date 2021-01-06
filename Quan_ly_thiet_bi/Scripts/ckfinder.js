$(document).ready(function () {
    $("#selectImg").click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#Image1").val(fileUrl);
        };
        finder.popup();
    });
});