document.getElementById("Cep").addEventListener("focusout", () => buscarDados());

function buscarDados() {
    let cep = document.getElementById("Cep").value.trim().replace("-", "");
    //89070-260
    if (cep.length != 8) {
        return;
    }

    fetch(`https://viacep.com.br/ws/${cep}/json/`)
        .then((response) => response.json())
        .then((json) => {
            document.getElementById("Cidade").value = json.localidade;
            document.getElementById("Logradouro").value = json.logradouro;
            document.getElementById("Bairro").value = json.bairro;
            document.getElementById("Estado").value = json.uf;
            document.getElementById("Numero").focus();
        });
}