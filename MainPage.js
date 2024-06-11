
/**
 * API access key.
 */
var apiKey = "";

/**
 * User ID.
 */
var personId = 0;

/**
 * Anonymous function running when the page loads.
 */
(function () {
    toggleButtonLogin();
    toggleExplanationText();
})();

function doLogin() {

    var cpfCnpj = document.getElementById("userCpfCnpjInput").value;
    var userPassword = document.getElementById("userPasswordInput").value;


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
 * Toggle for the Login button.
 * Indicates if the user has or not
 * an API Key to use in the API calls
 * inside this application.
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
 * Toggle for the explanation on the
 * top of the web page.
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