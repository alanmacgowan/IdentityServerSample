var successMessage = $('#SuccessMessage').val();

$(document).ready(function () {
    if (successMessage != "" && successMessage != undefined ) {
        $.notify({
            icon: 'ti-user',
            message: successMessage
        }, { type: 'success', timer: 2000 });
    }
});