// Write your JavaScript code.
$(function () {

    $('.needconfirm').click(function (e) {
        debugger;
        e.preventDefault();
        var id = $(this).closest('form').attr('id');
        var sucsess = $(this).data('sucsess');
        $('#confirmationModal').modal('show');
        $('#confirmationModal .confirm-modal').attr('id', id);
    });
    $('.confirm-modal').click(function () {
        $('#'+$(this).attr('id')).submit();
    })
});
