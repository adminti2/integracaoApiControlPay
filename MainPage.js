/**
 * Chave de integração.
 */
var apiKey = "";

/**
 * ID da Pessoa (usuário).
 */
var personId = 0;

/**
 * Função anônima que roda quando a página carrega.
 */
(function () {
    toggleButtonLogin();
    toggleExplanationText();
})();

/**
 * Guarda a chave de integração e o
 * ID de Pessoa fornecidos para uso
 * em chamadas de API posteriores.
 * @returns 
 */
function addKey() {
    var personIdInput = document.getElementById("personIdInput").value;
    var accessKeyInput = document.getElementById("accessKeyInput").value;

    if(!personIdInput || !accessKeyInput) {
        alert("Preencha o ID da pessoa e a chave de integração antes de adicionar a chave a ser usada pela aplicação!");
        return;
    }

    personId = personIdInput;
    apiKey = accessKeyInput;

    alert("ID " + personId + " de pessoa e chave " + apiKey + " prontos para uso nas outras secções desta aplicação.");
}

/**
 * Loga o usuário no ControlPay, retornando um JSON
 * com as informações da Pessoa. Essas informações 
 * são repassadas para as variáveis locais de chave
 * de acesso "apiKey" e de ID de Pessoa "personId"
 * para uso posterior.
 * @returns N/A
 */
function doLogin() {

    var cpfCnpj = document.getElementById("userCpfCnpjInput").value;
    var userPassword = document.getElementById("userPasswordInput").value;

    if(!cpfCnpj || !userPassword) {
        alert("Preencha o CPF/CNPJ e a senha antes de realizar o Login!");
        return;
    }

    const apiUrl = "https://sandbox.controlpay.com.br/webapi/Login/Login";

    const loginBody = {
        "cpfCnpj": cpfCnpj,
        "senha": userPassword
    }

    const requestOptions = {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(loginBody),
      };

    fetch(apiUrl, requestOptions)
      .then(response => {
        
        alert("A requisição retornou status: " + response.status + ". A resposta completa pode ser visualizada utilizando o console de seu navegador.")

        if(!response.ok) {
            throw new Error('Login não foi realizado com sucesso.');
        }
        
        return response.json();;
      })
      .then(data => {
        //Logging on console so the user can see what was returned.
        console.log(data);

        apiKey = data.pessoa.key;
        console.log("Chave da pessoa a ser usada nas chamadas: " + apiKey);

        personId = data.pessoa.id;
        console.log("ID da pessoa a ser usado nas chamadas: " + personId);
      })
}

/**
 * Alterna o login entre a necessidade
 * de realizar o login e o simples input
 * das informações que a API retornaria
 * (caso o usuário já as possua).
 */
function toggleButtonLogin() {
    var switchButtonLogin = document.getElementById("loginToggleSwitch");
    var hasApiKey = document.getElementById("hasApiKey");

    if (switchButtonLogin.checked) {
        doesntHaveApiKey.style.display = "none";
        hasApiKey.style.display = "block";
    } else {
        doesntHaveApiKey.style.display = "inline-block";
        hasApiKey.style.display = "none";
    }
}

/**
 * Alterna entre mostrar ou não a
 * explicação sobre a aplicação que
 * está no topo da página principal.
 */
function toggleExplanationText() {
    const toggleButton = document.getElementById('toggleExplanationBtn');
    const collapsibleText = document.getElementById('explanationText');

    toggleButton.addEventListener('click', function() {
        if (collapsibleText.style.display === 'none') {
            collapsibleText.style.display = 'block';
            toggleButton.textContent = 'Esconder texto';
        } else {
            collapsibleText.style.display = 'none';
            toggleButton.textContent = 'Mostrar texto explicativo';
        }
    });
}