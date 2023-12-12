// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CheckCep() {
    $.ajax({
        type: "GET",
        url: "ValidateCep",
        contentType: "application/json; charset=utf-8",
        data: {
            cep: $('#Cep').val()
        },
        success: function (result) {
            $("#statusDiv").html("<i class='fa-light fa-circle-check fa-2x'></i>");
            $("#dataDiv").html("<b>Logradouro:</b> " + result.logradouro + " <b>Bairro:</b> " + result.bairro + " <b>Localidade:</b> " + result.localidade);
        },
        error: function (xhr, status, error) {
            $("#statusDiv").html("<i class='fa-light fa-circle-exclamation fa-2x'></i>");
            $("#dataDiv").html("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
        }
    });
}
