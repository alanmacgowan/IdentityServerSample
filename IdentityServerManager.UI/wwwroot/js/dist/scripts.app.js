var successMessage = $('#SuccessMessage').val();

$(document).ready(function () {

    if (successMessage != "" && successMessage != undefined ) {
        $.notify({
            title: 'Success',
            icon: 'fa fa-check',
            message: successMessage
        }, { type: 'success', timer: 2000 });
    }

    $('form').bind('invalid-form.validate', function () {
        $.notify({
            title: 'Warning',
            icon: 'fa fa-exclamation-triangle',
            message: 'There are invalid fields.'
        }, { type: 'warning', timer: 2000 });
    });

    $('[data-toggle="tooltip"]').tooltip();

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

function showDetails(id, module) {
    $.ajax({ url: '/' + module + '/Details/' + id })
        .done(function (response) {
            if (response) {
                BootstrapDialog.show({
                    title: 'Details',
                    message: $('<div></div>').html(response),
                    buttons: [{
                        label: 'Close',
                        cssClass: 'btn-primary',
                        action: function (dialog) {
                            dialog.close();
                        }
                    }]
                });
            }
        });
};