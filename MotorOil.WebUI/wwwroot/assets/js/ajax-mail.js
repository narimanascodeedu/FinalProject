$(document).ready(function () {
    $('#contact-form').submit(function (ev) {
        ev.preventDefault();

        let fd = new FormData(ev.currentTarget);

        $.ajax({
            url: '@Url.Action("Contact")',
            type: 'POST',
            data: fd,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response, 'SUCCESS')

                ev.currentTarget.reset();
            },
            error: function (errorResponse) {
                console.log(errorResponse,'ERROR')
            }
        });
         
    });
});