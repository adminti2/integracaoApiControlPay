/**
 * Chave de integração.
 */
var apiKey = "";

/**
 * ID da Pessoa (usuário).
 */
var personId = 0;

/**
 * ID do Terminal usado para transacionar.
 */
var terminalId = 0;

/**
 * Função anônima que roda quando a página carrega.
 */
(function () {
  //Adicionando toggle para algumas áreas da página.
  ToggleButtonLogin();
  ToggleExplanationText();

  //Adiocionando evento de keyup para Enter.
  KeyUpOnInputToSubmit("#personIdInput", "#addKeyBtn");
  KeyUpOnInputToSubmit("#accessKeyInput", "#addKeyBtn");
  KeyUpOnInputToSubmit("#userCpfCnpjInput", "#loginBtn");
  KeyUpOnInputToSubmit("#userPasswordInput", "#loginBtn");
})();

/**
 * Guarda a chave de integração e o
 * ID de Pessoa fornecidos para uso
 * em chamadas de API posteriores.
 */
function AddKey() {
  var personIdInput = document.getElementById("personIdInput").value;
  var accessKeyInput = document.getElementById("accessKeyInput").value;

  if (!personIdInput || !accessKeyInput) {
    alert(
      "Preencha o ID da pessoa e a chave de integração antes de adicionar a chave a ser usada pela aplicação!"
    );
    return;
  }

  personId = personIdInput;
  apiKey = accessKeyInput;

  alert(
    "ID " +
      personId +
      " de pessoa e chave " +
      apiKey +
      " prontos para uso nas outras secções desta aplicação."
  );

  //Populando o select de Terminais Físicos caso
  //seja necessária a criação de um novo terminal.
  PopulateTerminalFisicoSelect();

  //Populando o select de Terminais para uso nas
  //outras secções da aplicação.
  PopulateTerminalSelect();
}

/**
 * Função para criação de novos terminais
 * no ControlPay. Cria um terminal genérico
 * de exemplo com base nas informações fornecidas
 * anteriormente.
 */
function CreateTerminal() {
  if (!personId) {
    alert(
      "Faça login ou adicione uma chave de integração antes de criar um Terminal!"
    );
    return;
  }

  var tfId = document.getElementById("terminalFisicoSelect").value;

  if (tfId == 0 || tfId == "undefined") {
    alert(
      "Para criar um Terminal, é preciso primeiro ter um Terminal Físico cadastrado. Requisite a criação de um Terminal Físico."
    );
    return;
  }

  //Endpoint para criação/modificação de terminais
  const apiUrl =
    "https://sandbox.controlpay.com.br/webapi/Terminal/Insert?key=" + apiKey;

  console.log("URL da chamada: " + apiUrl);

  //Body da requisição de Login
  const terminalBody = {
    nome: "TerminalExemplo",
    pessoaId: personId,
    terminalFisicoId: tfId,
    habilitarPDV: true,
    vendaPorValor: true,
    vendaPorProduto: true,
    habilitarPedidos: true,
    permiteVendaParcelada: true,
    parcelamentopadrao: "admin",
    aguardaTef: true,
    permiteDesconto: false,
    permiteAcrescimo: false,
    solicitarCliente: false,
    solicitarReferencia: false,

    //Identificador TEF é uma propriedade referente
    //a configurações de multi-EC. Sendo assim, não
    //é necessária para este exemplo.
    //identificadorTef: "01234567890",

    //As configurações de impressão não
    //foram adicionadas neste exemplo.
    //impressoraId: 8,
    //imprimirProdutos: false,
    //imprimirCupomLojista: false,
    //imprimirCupomCliente: false
  };

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(terminalBody),
  };

  console.log("Body da chamada: " + requestOptions.body);

  //Chamada para a API Terminal/Insert.
  fetch(apiUrl, requestOptions)
    .then((response) => {
      if (!response.ok) {
        alert(
          'Não foi possível realizar a chamada de criação de Terminal. Verifique a aba "Network" das ferramentas do desenvolvedor para mais informações sobre o erro retornadas pela API.'
        );

        throw new Error(
          "A chamada retornou status: " +
            response.status +
            '. É possível verificar mais informações da chamada na aba "Network" da janela de ferramentas do desenvolvedor do navegador.'
        );
      }

      return response.json();
    })
    .then((data) => {
      //Logando informações no console para que o usuário
      //possa visualizar as respostas da API.
      console.log(data);

      //Salvando informações do terminal (ID).
      terminalId = data.terminal.id;

      alert(
        "Terminal " +
          data.terminal.nome +
          " [ID: " +
          data.terminal.id +
          "] criado e salvo com sucesso!"
      );

      PopulateTerminalSelect(data.terminal.id);
    })
    .catch((error) => {
      throw new Error(error);
    });
}

/**
 * Loga o usuário no ControlPay, retornando um JSON
 * com as informações da Pessoa. Essas informações
 * são repassadas para as variáveis locais de chave
 * de acesso "apiKey" e de ID de Pessoa "personId"
 * para uso posterior.
 */
function DoLogin() {
  //Inputs para Login
  var cpfCnpj = document.getElementById("userCpfCnpjInput").value;
  var userPassword = document.getElementById("userPasswordInput").value;

  if (!cpfCnpj || !userPassword) {
    alert("Preencha o CPF/CNPJ e a senha antes de realizar o Login!");
    return;
  }

  //Endpoint de Login
  const apiUrl = "https://sandbox.controlpay.com.br/webapi/Login/Login";

  console.log("URL da chamada: " + apiUrl);

  //Body da requisição de Login
  const loginBody = {
    cpfCnpj: cpfCnpj,
    senha: userPassword,
  };

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(loginBody),
  };

  console.log("Body da chamada: " + requestOptions.body);

  //Chamada para a API Login/Login
  fetch(apiUrl, requestOptions)
    .then((response) => {
      alert(
        "A requisição retornou status: " +
          response.status +
          ". A resposta completa pode ser visualizada utilizando o console de seu navegador."
      );

      if (!response.ok) {
        throw new Error("Login não foi realizado com sucesso.");
      }

      return response.json();
    })
    .then((data) => {
      //Logando informações no console para que o usuário
      //possa visualizar as respostas da API.
      console.log(data);

      apiKey = data.pessoa.key;
      console.log("Chave da pessoa a ser usada nas chamadas: " + apiKey);

      personId = data.pessoa.id;
      console.log("ID da pessoa a ser usado nas chamadas: " + personId);

      //Populando o select de Terminais Físicos caso
      //seja necessária a criação de um novo terminal.
      PopulateTerminalFisicoSelect();

      //Populando o select de Terminais para uso nas
      //outras secções da aplicação.
      PopulateTerminalSelect();
    })
    .catch((error) => {
      throw new Error(error);
    });
}

/**
 * Chamada de transação administrativa
 * no ControlPay.
 */
function InsertAdmin() {

  if (!apiKey || !personId || !terminalId) {
    alert(
      "Realize as etapas anteriores deste exemplo primeiro para que a chave de integração, ID da Pessoa e ID do terminal possam ser preenchidos."
    );
    return;
  }

  var startAdminAuto = document.getElementById("startAdminSwitch").checked;
  var techPassword = document.getElementById("technicalPassword").value;

  //A senha técnica não é necessária nessa chamada caso ela
  //não tenha sido cadastrada. Contudo, é padrão do nosso
  //relacionamento com desenvolvedor cadastrar esta como
  //uma senha padrão: "314159". Sendo assim, caso não tenha
  //sido cadastrada uma nova senha, este valor será usado para esta chamada.
  if(!techPassword) {
    techPassword = "314159";
  }

  //Endpoint de Login
  const apiUrl =
    "https://sandbox.controlpay.com.br/webapi/PagamentoExterno/InsertPagamentoExternoTipoAdmin?key=" + apiKey;

  console.log("URL da chamada: " + apiUrl);

  //Body da requisição de Login
  const adminBody = {
    terminalId: terminalId,
    senhaTecnica: techPassword,
    aguardarTefIniciarTransacao: startAdminAuto
  };

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(adminBody),
  };

  console.log("Body da chamada: " + requestOptions.body);

  //Chamada para a API Terminal/Insert.
  fetch(apiUrl, requestOptions)
    .then((response) => {
      if (!response.ok) {
        alert(
          'Não foi possível realizar uma administrativa. Verifique a aba "Network" das ferramentas do desenvolvedor para mais informações sobre o erro retornadas pela API.'
        );

        throw new Error(
          "A chamada retornou status: " +
            response.status +
            '. É possível verificar mais informações da chamada na aba "Network" da janela de ferramentas do desenvolvedor do navegador.'
        );
      }

      return response.json();
    })
    .then((data) => {

      //Logando informações no console para que o usuário
      //possa visualizar as respostas da API.
      console.log(data);

      alert("Transação administrativa iniciada!\r\nVerifique o PayGo Windows instalado e continue a transação nele.");

      //Logando no console informações da venda
      //para facilitar a visualização pelo usuário.
      console.log("Administrativa criada com ID: " + data.pagamentoExterno.id);

      //Como administrativas não são consideradas vendas, elas não possuem intencaoVenda,
      //sendo consideradas apenas como pagamentoExterno (representando uma ação fora do
      //ControlPay que é realizada com base nesse Pagamento Externo).
    })
    .catch((error) => {
      throw new Error(error);
    });
}

/**
 * Adiciona um evento de keyup para um elemento input.
 * Este evento, caso a tecla seja "Enter", irá acionar
 * o clique do botão fornecido.
 * @param {string} input ID de um input (Exemplo: "#nomeInput").
 * @param {string} button ID de um botão (Exemplo: "#nomeBtn")
 */
function KeyUpOnInputToSubmit(input, button) {
  document.querySelector(input).addEventListener("keyup", (event) => {
    if (event.key !== "Enter") return;
    document.querySelector(button).click();
    event.preventDefault();
  });
}

/**
 * Popula o select de Terminal
 * usado para escolher o terminal
 * que será usado para transações.
 * @param {number} selectedTerminalId ID do Terminal que deve
 * constar como escolhido (caso esteja dentro do select). Esta
 * propriedade só é enviada no caso de ter ocorrido a criação de
 * um novo Terminal.
 */
function PopulateTerminalSelect(selectedTerminalId) {
  var selectTerminal = document.getElementById("terminalSelect");

  //Removendo as opções que o select já tinha anteriormente.
  selectTerminal.innerHTML = "";

  //Populando o select com os terminais da Pessoa no ControlPay
  const apiUrl =
    "https://sandbox.controlpay.com.br/webapi/Terminal/GetByPessoaId?key=" +
    apiKey +
    "&pessoaId=" +
    personId;

    console.log("URL da chamada: " + apiUrl);

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  };

  //Chamada para a API Terminal/GetByPessoaId.
  fetch(apiUrl, requestOptions)
    .then((response) => {
      if (!response.ok) {
        alert(
          "Não foi possível realizar a chamada para encontrar os terminais disponíveis. Verifique se o Login ou a adição da chave de integração foi realizada corretamente."
        );

        throw new Error(
          "A chamada retornou status: " +
            response.status +
            '. É possível verificar mais informações da chamada na aba "Network" da janela de ferramentas do desenvolvedor do navegador.'
        );
      }

      return response.json();
    })
    .then((data) => {
      //Logando informações no console para que o usuário
      //possa visualizar as respostas da API.
      console.log(data);

      if (!data.terminais.length) {
        let opt = document.createElement("option");
        opt.value = 0;
        opt.innerHTML = "Nenhum terminal disponível";
        selectTerminal.append(opt);

        return;
      }

      //Mapeando as informações de Terminal Físico (PdC)
      //para escolha e crição de Terminal
      data.terminais.map((terminal) => {
        let opt = document.createElement("option");
        opt.value = terminal.id;
        opt.innerHTML = "[ID: " + terminal.id + "] " + terminal.nome;
        selectTerminal.append(opt);
      });

      return selectTerminal;
    })
    .then((select) => {
      //Caso a chamada desta função tenha se originado da criação de um
      //terminal, coloca o terminal como o escolhido (na variável global
      //e no select de Terminal).
      if (select && selectedTerminalId) {
        terminalId = selectedTerminalId;
        document.getElementById("terminalSelect").value = selectedTerminalId;
      } else {
        terminalId = document.getElementById("terminalSelect").value;
      }
    })
    .catch((error) => {
      let opt = document.createElement("option");
      opt.value = 0;
      opt.innerHTML = "Nenhum terminal disponível";
      selectTerminal.append(opt);

      throw new Error(error);
    });
}

/**
 * Popula o select de Terminal Físico
 * usado para criação de Terminal.
 */
function PopulateTerminalFisicoSelect() {
  var selectPdC = document.getElementById("terminalFisicoSelect");

  //Removendo as opções que o select já tinha anteriormente.
  selectPdC.innerHTML = "";

  //Populando o select com as representações do PdC no ControlPay (chamadas Terminal Físico)
  const apiUrl =
    "https://sandbox.controlpay.com.br/webapi/TerminalFisico/GetByPessoaId?key=" +
    apiKey +
    "&pessoaId=" +
    personId;

  console.log("URL da chamada: " + apiUrl);

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
  };

  //Chamada para a API TerminalFisico/GetByPessoaId.
  //Esta é uma API não necessária para implementações
  //e só se encontra neste exemplo para facilitar seu
  //uso e não exigir que o usuário tenha que pedir que
  //configurem seu terminal para ele.
  fetch(apiUrl, requestOptions)
    .then((response) => {
      if (!response.ok) {
        alert(
          "Não foi possível realizar a chamada para encontrar os pontos de captura disponíveis. Verifique se o Login ou a adição da chave de integração foi realizada corretamente."
        );

        throw new Error(
          "A chamada retornou status: " +
            response.status +
            '. É possível verificar mais informações da chamada na aba "Network" da janela de ferramentas do desenvolvedor do navegador.'
        );
      }

      return response.json();
    })
    .then((data) => {
      //Logando informações no console para que o usuário
      //possa visualizar as respostas da API.
      console.log(data);

      if (!data.terminaisFisicos.length) {
        let opt = document.createElement("option");
        opt.value = 0;
        opt.innerHTML = "Nenhum terminal disponível";
        selectPdC.append(opt);

        return;
      }

      //Mapeando as informações de Terminal Físico (PdC)
      //para escolha e crição de Terminal
      data.terminaisFisicos.map((terminalFisico) => {
        let opt = document.createElement("option");
        opt.value = terminalFisico.id;
        opt.innerHTML =
          terminalFisico.nome +
          " (PdC: " +
          terminalFisico.pontoCaptura +
          ") [ID de instalação: " +
          terminalFisico.instalacaoId +
          "]";
        selectPdC.append(opt);
      });
    })
    .catch((error) => {
      let opt = document.createElement("option");
      opt.value = 0;
      opt.innerHTML = "Nenhum PdC disponível";
      selectPdC.append(opt);

      throw new Error(error);
    });
}

/**
 * Função que ocorre a cada mudança (OnChange)
 * no select de Terminal, permitindo mudar a global
 * terminalId.
 */
function TerminalSelectOptionSelected() {
  terminalId = document.getElementById("terminalSelect").value;
}

/**
 * Alterna o login entre a necessidade
 * de realizar o login e o simples input
 * das informações que a API retornaria
 * (caso o usuário já as possua).
 */
function ToggleButtonLogin() {
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
function ToggleExplanationText() {
  const toggleButton = document.getElementById("toggleExplanationBtn");
  const collapsibleText = document.getElementById("explanationText");

  toggleButton.addEventListener("click", function () {
    if (collapsibleText.style.display === "none") {
      collapsibleText.style.display = "block";
      toggleButton.textContent = "Esconder texto";
    } else {
      collapsibleText.style.display = "none";
      toggleButton.textContent = "Mostrar texto explicativo";
    }
  });
}

/**
 * Chamada de venda no ControlPay.
 */
function Vender() {

  if (!apiKey || !personId || !terminalId) {
    alert(
      "Realize as etapas anteriores deste exemplo primeiro para que a chave de integração, ID da Pessoa e ID do terminal possam ser preenchidos."
    );
    return;
  }

  //Variáveis para a chamada.
  var paymentMethod = document.getElementById("paymentMethodSelect").value;
  var inputValue = document.getElementById("transactionValueInput").value;
  var startAuto = document.getElementById("startAutoSwitch").checked;

  //Formatando o valor informado no input de Valor
  //para a moeda brasileira.
  let realBr = new Intl.NumberFormat('pt-br')
  var transactionValue = realBr.format(inputValue);

  //Endpoint de Login
  const apiUrl =
    "https://sandbox.controlpay.com.br/webapi/Venda/Vender?key=" + apiKey;

  console.log("URL da chamada: " + apiUrl);

  //Body da requisição de Login
  const venderBody = {
    formaPagamentoId: paymentMethod,
    terminalId: terminalId,
    valorTotalVendido: transactionValue,
    observacao:
      "Esta venda foi realizada usando a aplicação exemplo fornecida pelo time de desenvolvimento do ControlPay.",
    aguardarTefIniciarTransacao: startAuto,

    //Exemplo de body acima:
    // formaPagamentoId: 21,
    // terminalId: 1234,
    // valorTotalVendido: "10,00",
    // observacao: "Obs. atrelada à venda para uso de quem realizou a venda.",
    // aguardarTefIniciarTransacao: true,

    //Propriedades opcionais (exemplos):
    // pedidoId: 123,            //Utilizado para Pedidos no ControlPay.
    // preDatado: true,          //Para transações pré-datadas.
    // aVista: true,             //Para transações à vista.
    // parcelamentoAdmin: true,  //Tipo de parcelamento (booleano indicando admin/emissor ou loja/estabelecimento)
    // quantidadeParcelas: 1     //Quantidade de parcelas quando há parcelamento.
  };

  const requestOptions = {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(venderBody),
  };

  console.log("Body da chamada: " + requestOptions.body);

  //Chamada para a API Terminal/Insert.
  fetch(apiUrl, requestOptions)
    .then((response) => {
      if (!response.ok) {
        alert(
          'Não foi possível realizar uma venda. Verifique a aba "Network" das ferramentas do desenvolvedor para mais informações sobre o erro retornadas pela API.'
        );

        throw new Error(
          "A chamada retornou status: " +
            response.status +
            '. É possível verificar mais informações da chamada na aba "Network" da janela de ferramentas do desenvolvedor do navegador.'
        );
      }

      return response.json();
    })
    .then((data) => {

      //Logando informações no console para que o usuário
      //possa visualizar as respostas da API.
      console.log(data);

      alert("Intenção de venda criada!\r\nCaso tenha realizado uma transação TEF, verifique o PayGo Windows instalado e continue a transação nele.\r\nCaso tenha realizado uma transação com Gateway, verifique a janela de ferramentas do desenvolvedor para recuperar o link de redirecionamento para o Gateway.");

      //Logando no console informações da venda
      //para facilitar a visualização pelo usuário.
      console.log("Intenção de venda criada com ID: " + data.intencaoVenda.id);

      //Vendas geram intenções de venda e pagamentos externos.
      
      //Intenções de venda (intencaoVenda) são objetos que representam a
      //venda em si dentro do ControlPay como plataforma.
      
      //Pagamentos externos (pagamentoExterno) são objetos que representam
      //as operações fora do ControlPay atreladas à venda (uma intenção pode
      //ter vários pagametos: um para a venda em crédito à vista e um, em seguida,
      //para um cancelamento da primeira venda, por exemplo. Ambos os pagamentoExterno
      //estarão vinculado à mesma intencaoVenda).
    })
    .catch((error) => {
      throw new Error(error);
    });
}
