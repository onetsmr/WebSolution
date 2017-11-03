// Focus on first input when open modal dialog (Vue + Bootstrap)
$(document).on("shown.bs.modal", function (e) {
    $("[autofocus]:first", e.target).focus();
})