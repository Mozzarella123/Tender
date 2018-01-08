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
        $('#' + $(this).attr('id')).submit();
    });
    //$('#register-new').click(
    //    function () {
    //        $.ajax({
    //            method: 'GET',
    //            url: '/Account/Register',
    //            success:
    //            function (data) {
    //                $('#adminmodal .modal-body').empty().append(data);
    //                $('#adminmodal').modal('show');
    //                $("#adminmodal button#register").click(function (e) {
    //                    debugger;
    //                    e.preventDefault();
    //                    $.ajax({
    //                        method: 'POST',
    //                        url: '/Account/Register',
    //                        data: $(this).closest('form').serialize(),
    //                        success: function (data) {
    //                            $('#adminmodal .modal-body').empty().append(data);
    //                        }
    //                    });
    //                });
    //            }
    //        })
    //    });

});
function Ajax(method, url, data) {

}