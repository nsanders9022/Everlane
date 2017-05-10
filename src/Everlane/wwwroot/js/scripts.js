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
                var translation = $('#newTranslation').val();
                var language = $('#newLanguage').val();
                console.log(translation);
                console.log(language);
                var translationText = Translator.GetTranslation(translation, language);
                $('.translate-results').html(translationText);
            }
        });
    });
});