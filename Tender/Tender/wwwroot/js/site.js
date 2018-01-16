// Write your JavaScript code.
$(function () {

    $('.needconfirm').click(function (e) {
        debugger;
        e.preventDefault();
        $(this).addClass('inconfirm');
        $('#confirmationModal').modal('show');
    });
    $('.confirm-modal').click(function () {
        var elem = $('.needconfirm.inconfirm');
        if (elem.is('button'))
            elem.closest('form').submit();
        else
            location.href = elem.attr('href');
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

////////////////////////////////////////////////////////////////// вынести в файл для менеджера мета полей ///////////////////////////////////////////////////////

$('#SubGroupCreaterButton').bind('click', function () {
    jQuery.ajax({
        url: '/Admin/CreateSubGroup',
        dataType: 'html',
        success: function (data) {
            jQuery('#SubGroupCreater').append(data);
            var button = document.getElementById('SubGroupCreaterButton');
            $('#SubGroupCreaterButton').unbind('click');
            button.innerText = 'Скрыть';
            $('#SubGroupCreaterButton').click(function () {
                if (button.innerText == 'Скрыть')
                    button.innerText = 'Добавить группу полей';
                else
                    button.innerText = 'Скрыть';
            });
            button.setAttribute('data-toggle', 'collapse');
            button.setAttribute('data-target', '#SubGroupCreater');
            button.setAttribute('aria-expanded', 'false');
            button.setAttribute('aria-controls', 'SubGroupCreater');
            $('#SubGroupCreater').collapse().show();
        },
        error: function () {
            alert('Error');
        }
    });

});


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function Ajax(method, url, data) {

}

