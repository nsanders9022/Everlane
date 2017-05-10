$(document).ready(function () {
    $('.translate').submit(function (event) {
        event.preventDefault();
        console.log("Inside ajax");
        $.ajax({
            type: 'POST',
            dataType: 'json',
            //data: $(this).serialize(),
            url: '/Home/ReturnTranslation',
            success: function (result) {
                console.log(result);
                $('.translate-results').html(result);
            }
        });
    });
});