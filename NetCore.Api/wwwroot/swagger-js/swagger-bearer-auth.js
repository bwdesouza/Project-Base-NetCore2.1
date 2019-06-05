(function () {
    $(function () {
        $('#input_baseUrl')[0].value = '';
        $('#input_baseUrl').attr("placeholder", "Insira seu token bearer aqui...");
        $("#input_baseUrl").change(addApiKeyAuthorization);
    });

    function addApiKeyAuthorization() {
        var key = encodeURIComponent($('#input_baseUrl')[0].value);
        if (key && key.trim() !== "") {

            key = key.replace("Bearer%20", "");
            key = key.replace("bearer%20", "");
            key = key.replace("Bearer ", "");
            key = key.replace("bearer ", "");
            key = key.replace("Bearer", "");
            key = key.replace("bearer", "");

            var apiKeyAuth = new SwaggerClient.ApiKeyAuthorization("Authorization", "Bearer " + key, "header");
            window.swaggerUi.api.clientAuthorizations.add("bearer", apiKeyAuth);
        } 
    }
})();