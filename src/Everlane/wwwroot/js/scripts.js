$(document).ready(function () {
    $('.translate').click(function () {
        console.log("Inside ajax");
        $.ajax({
            type: 'GET',
            dataType: 'json',
            //data: $(this).serialize(),
            url: '/Home/ReturnTranslation',
            success: function (result) {
                console.log(result);
                //result = result.replace("/[^a-zA-Z0-9]/g", "")
                $('.translate-results').html(result);
            }
        });
    });
});