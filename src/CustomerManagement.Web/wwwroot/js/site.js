// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

JQuery(function () {
    $("input[name=cep]").change(function () {
        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;
        $get("http://apps.widenet.com.br/busca-cep/api/cep.json", { code: cep_code }, function (result) {
            if (result.status != 1) {
                alert(result.message || "Houve um erro desconhecido");
                return;
            }
            alert(result);
            //$("input[name=cep]").val(result.code);
            //$("input[name=estado]").val(result.state);
            //$("input[name=cidade]").val(result.city);
            //$("input[name=bairro]").val(result.district);
            //$("input[name=endereco]").val(result.address);
            )
    }; 
          )}; 
        )}; 
