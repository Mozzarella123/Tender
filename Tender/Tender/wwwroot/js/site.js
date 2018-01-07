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
////////////////////////////////////////////////////////////////// вынести в файл для менеджера мета полей ///////////////////////////////////////////////////////
$('#SubGroupCreaterButton').bind('click',function () {
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
