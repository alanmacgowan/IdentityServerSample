var successMessage = $('#SuccessMessage').val();

$(document).ready(function () {

    if (successMessage != "" && successMessage != undefined ) {
        $.notify({
            icon: 'ti-user',
            message: successMessage
        }, { type: 'success', timer: 2000 });
    }

});

function deleteItem(id) {
    BootstrapDialog.show({
        title: 'Delete Item',
        message: 'Do you want to delete this Item?',
        buttons: [{
            label: 'Yes',
            cssClass: 'btn-success',
            action: function (dialog) {
                $('#Id').val(id);
                $("#deleteForm").submit();
                dialog.close();
            }
        }, {
            label: 'No',
            cssClass: 'btn-danger',
            action: function (dialog) {
                dialog.close();
            }
        }]
    });
};