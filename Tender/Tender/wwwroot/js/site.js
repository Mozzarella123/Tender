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

////////////////////////////////////////////////////////////////// вынести в файл для менеджера мета полей ///////////////////////////////////////////////////////

$('#SubGroupCreaterButton').bind('click', function () {
    var button = document.getElementById('SubGroupCreaterButton');
    if (button.innerText == 'Скрыть')
        button.innerText = 'Добавить группу полей';
    else
        button.innerText = 'Скрыть';
        //jQuery.ajax({
        //url: '/Admin/CreateSubGroup',
        //dataType: 'html',
        //success: function (data) {
        //    jQuery('#SubGroupCreater').append(data);
        //    var button = document.getElementById('SubGroupCreaterButton');
        //    $('#SubGroupCreaterButton').unbind('click');
        //    button.innerText = 'Скрыть';
        //    $('#SubGroupCreaterButton').click(function () {
        //        if (button.innerText == 'Скрыть')
        //            button.innerText = 'Добавить группу полей';
        //        else
        //            button.innerText = 'Скрыть';
        //    });
        //    button.setAttribute('data-toggle', 'collapse');
        //    button.setAttribute('data-target', '#SubGroupCreater');
        //    button.setAttribute('aria-expanded', 'false');
        //    button.setAttribute('aria-controls', 'SubGroupCreater');
        //    $('#SubGroupCreater').collapse().show();
        //},
        //error: function () {
        //    alert('Error');
        //}
    //});
    
});

$('.CreateSubButton').click(function (e) {
    var button = document.getElementsByClassName('CreateSubButton');
    if (button.innerText == 'Скрыть')
    {
        button.innerText = 'Добавить поле';
        

        var Value = $(this).closest(".SubGroupIdHidden").attr('value');
        $('#SubParentId').attr('value',Value);
    }
    else
        button.innerText = 'Скрыть';

    $('#SubId').attr('value', 0);
    $('#Subname').attr('value', 0);
    $('#SubType').attr('value', '');
    $('#SubPriority').attr('value', 0);
});


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function Ajax(method, url, data) {

}

