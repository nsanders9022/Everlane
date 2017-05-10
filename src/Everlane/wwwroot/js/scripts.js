$(document).ready(function () {
    $('.translate').submit(function (event) {
        event.preventDefault();
        console.log("Inside ajax");
        var text = $("#textInput").val();
        console.log(text)
        
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            url: '/Home/ReturnTranslation',
            success: function (result) {
                console.log(result);
                //result = result.replace("/[^a-zA-Z0-9]/g", "")
                $('.translate-results').html(result);
            }
        });
    });
});