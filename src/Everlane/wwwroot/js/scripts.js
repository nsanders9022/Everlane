$(document).ready(function () {
    $('.translate').click(function () {
        console.log("Inside ajax");
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/Home/ReturnTranslation',
            success: function (result) {
                console.log(result);
                $('.translate-results').html(result);
            }
        });
    });
});