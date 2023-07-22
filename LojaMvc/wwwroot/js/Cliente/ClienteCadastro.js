document.getElementById("campo-cep").addEventListener("focusout", () => buscarDados());

function buscarDados() {
    let cep = document.getElementById("campo-cep").value.trim().replace("-", "");
    //89070-260
    if (cep.length != 8) {
        return;
    }

    fetch(`https://viacep.com.br/ws/${cep}/json/`)
        .then((response) => response.json())
        .then((json) => {
            document.getElementById("campo-cidade").value = json.localidade;
            document.getElementById("campo-logradouro").value = json.logradouro;
            document.getElementById("campo-bairro").value = json.bairro;
            document.getElementById("campo-estado").value = json.uf;
            document.getElementById("campo-numero").focus();
        });
}