function ChangePage(id, form) {
    $("#pageId").val(id);
    $("#" + form).submit();
}

function ToggleSlide(id) {
    $("#" + id).slideToggle();
}