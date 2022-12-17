LoadTable();

function LoadTable() {
    $.get("/Admin/Roles/GetRoles", function (result) {
        $("#table-body").html(result);
    });
}

function OpenCreateModal() {
    $.get("/Admin/Roles/Create", function (result) {
        $("#default").modal();
        $("#myModalLabel1").html("افزودن نقش جدید");
        $(".modal-body").html(result);
    });
}

function EditRole(id) {
    $.get("/Admin/Roles/Edit/" + id, function (result) {
        $("#default").modal();
        $("#myModalLabel1").html("ویرایش نقش");
        $(".modal-body").html(result);
    });
}

function ConfirmEditRole() {
    swal({
        title: 'مطمئن هستید؟',
        text: "آیا از ویرایش این نقش مطمئن هستید ؟",
        type: 'question',
        showCancelButton: true,
        confirmButtonColor: '#0CC27E',
        cancelButtonColor: '#FF586B',
        confirmButtonText: 'بله',
        cancelButtonText: "خیر"
    }).then(function (isConfirm) {
        if (isConfirm) {
            $("#EditRoleForm").submit();
        }
    }).catch(swal.noop);
}

function DeleteRole(id) {
    swal({
        title: 'مطمئن هستید؟',
        text: "آیا از حذف این نقش مطمئن هستید ؟ این عمل غیر قابل بازگشت است!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#0CC27E',
        cancelButtonColor: '#FF586B',
        confirmButtonText: 'بله',
        cancelButtonText: "خیر"
    }).then(function (isConfirm) {
        if (isConfirm) {
            DeleteRoleConfirm(id);
        }
    }).catch(swal.noop);
}

function DeleteRoleConfirm(id) {
    $.get("/Admin/Roles/Delete/" + id, function (result) {
        if (result == true) {
            LoadTable();
            swal("موفق", "نقش مورد نظر با موفقیت حذف شد.", "success").done();
        }
        else {
            swal("خطا", "مشگلی در حذف این نقش یش آمد.", "error").done();
        }
    });
}