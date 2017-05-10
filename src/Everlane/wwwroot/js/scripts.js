$(document).ready(function () {
    $('.translate').submit(function (event) {
        event.preventDefault();
        var translation = $('#newTranslation').val();
        var language = $('#newLanguage').val();
        console.log(translation);
        console.log(language);
        console.log("Inside ajax");
        console.log($(this).serialize());
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            url: 'Home/GetTranslation',
            success: function (result) {
                $('.translate-results').html(result);
            }
        });
    });
});