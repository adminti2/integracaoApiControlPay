using ExemploIntegracaoApiControlPay.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ExemploIntegracaoApiControlPay.Helpers
{
   /// <summary>
   /// Classe de chamada às APIs do ControlPay.
   /// </summary>
   public static class ApiHelper
   {
      #region HttpClient

      /// <summary>
      /// Http Client usado para chamadas de
      /// API usadas na aplicação.
      /// </summary>
      public static HttpClient ApiClient = new HttpClient();

      /// <summary>
      /// Inicializa o Http Client com as
      /// informações necessárias para realizar
      /// as chamadas usadas na aplicação, adicionando
      /// o endereço base das APIs e o Content-Type
      /// application/json aos headers.
      /// </summary>
      public static void CreateApiClient()
      {
         ApiClient.BaseAddress = new Uri("https://sandbox.controlpay.com.br/webapi/");
         ApiClient.DefaultRequestHeaders.Accept.Clear();
         ApiClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
      }

      #endregion HttpClient

      #region Public methods

      /// <summary>
      /// Criação de um novo terminal para a pessoa
      /// que está sendo usada.
      /// </summary>
      /// <param name="key">
      /// Chave de integração.
      /// </param>
      /// <param name="personId">
      /// ID da Pessoa.
      /// </param>
      /// <param name="terminalFisicoId">
      /// ID de Terminal Físico (PdC) ao qual
      /// o terminal deverá ser atrelado.
      /// </param>
      /// <param name="statusCode">
      /// Código de status da requisição
      /// HTTP que será realizada.
      /// </param>
      /// <param name="errorMessage">
      /// Possível mensagem de erro a ser
      /// retornada pela API.
      /// </param>
      /// <param name="createdTerminalId">
      /// ID do terminal que será criado.
      /// </param>
      /// <returns>
      /// Booleano indicando se o terminal foi
      /// ou não criado com sucesso.
      /// </returns>
      public static bool CreateTerminal(string key,
                                        string personId,
                                        int terminalFisicoId,
                                        out string statusCode,
                                        out string errorMessage,
                                        out string createdTerminalId)
      {
         errorMessage = string.Empty;
         statusCode = string.Empty;
         createdTerminalId = string.Empty;

         string url = $"Terminal/Insert?key={key}";

         var terminalBody = new
         {
            nome = "TerminalExemploCSharp",
            pessoaId = personId,
            terminalFisicoId = terminalFisicoId,
            habilitarPDV = true,
            vendaPorValor = true,
            vendaPorProduto = true,
            habilitarPedidos = true,
            permiteVendaParcelada = true,
            parcelamentopadrao = "admin",
            aguardaTef = true,
            permiteDesconto = false,
            permiteAcrescimo = false,
            solicitarCliente = false,
            solicitarReferencia = false,

            //Identificador TEF é uma propriedade referente
            //a configurações de multi-EC. Sendo assim, não
            //é necessária para este exemplo.
            //identificadorTef = "01234567890",

            //As configurações de impressão não
            //foram adicionadas neste exemplo.
            //impressoraId = 8,
            //imprimirProdutos = false,
            //imprimirCupomLojista = false,
            //imprimirCupomCliente = false
         };

         string json = JsonConvert.SerializeObject(terminalBody);
         var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

         //Escrevendo a chamada no console para facilitar
         //a leitura do usuário que estiver debuggando.
         Debug.WriteLine($"Chamada (URL) -> {url}");
         Debug.WriteLine($"Chamada (body) -> {terminalBody}");

         HttpResponseMessage response = CallPostApi(url,
                                                    httpContent,
                                                    out statusCode,
                                                    out string responseString,
                                                    out errorMessage);

         if(response == null)
            return false;

         var terminalResult = JsonConvert.DeserializeObject<dynamic>(responseString);

         if(!response.IsSuccessStatusCode)
         {
            errorMessage = terminalResult.message;
            return false;
         }

         if(terminalResult.terminal == null)
         {
            errorMessage = "Houve um erro ao criar o terminal. Tente novamente.";
            return false;
         }

         createdTerminalId = terminalResult.terminal.id;

         return true;
      }

      /// <summary>
      /// Realiza o Login para o usuário através da
      /// API Login/Login do ControlPay.
      /// </summary>
      /// <param name="cpfCnpj">
      /// String com o CPF/CNPJ do usuário vinda da
      /// <see cref="PrincipalScreen.textBoxCpfCnpjInput"/>.
      /// </param>
      /// <param name="password">
      /// String com a senha do usuário vinda da
      /// <see cref="PrincipalScreen.textBoxLoginPasswordInput"/>.
      /// </param>
      /// <param name="statusCode">
      /// Código de status retornado pela API.
      /// É um <see cref="HttpStatusCode"/> em formato string.
      /// </param>
      /// <param name="errorMessage">
      /// String com a mensagem de erro retornada
      /// pela API caso haja algum erro no processamento.
      /// </param>
      /// <param name="personId">
      /// ID da Pessoa retornado pela API de login.
      /// </param>
      /// <param name="key">
      /// Chave de integração da Pessoa retornada pela API de login.
      /// </param>
      /// <returns>
      /// Booleano indicando se o Login foi
      /// ou não realizado com sucesso.
      /// </returns>
      public static bool DoLogin(string cpfCnpj,
                                 string password,
                                 out string statusCode,
                                 out string errorMessage,
                                 out string personId,
                                 out string key)
      {
         errorMessage = string.Empty;
         key = string.Empty;
         personId = string.Empty;
         statusCode = string.Empty;

         var loginBody = new
         {
            cpfCnpj = cpfCnpj,
            senha = password,
         };

         string json = JsonConvert.SerializeObject(loginBody);
         var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

         string url = "Login/Login";

         //Escrevendo a chamada no console para facilitar
         //a leitura do usuário que estiver debuggando.
         Debug.WriteLine($"Chamada (URL) -> {url}");
         Debug.WriteLine($"Chamada (body) -> {loginBody}");

         HttpResponseMessage response = CallPostApi(url,
                                                    httpContent,
                                                    out statusCode,
                                                    out string responseString,
                                                    out errorMessage);

         //Erro durante o processamento da API.
         if(response == null)
            return false;

         var loginResult = JsonConvert.DeserializeObject<dynamic>(responseString);

         if(!response.IsSuccessStatusCode)
         {
            errorMessage = loginResult.message;
            return false;
         }

         if(loginResult.pessoa == null)
         {
            errorMessage = "Houve um erro ao realizar o login. Confira as credenciais e tente novamente.";
            return false;
         }

         personId = loginResult.pessoa.id;
         key = loginResult.pessoa.key;

         return true;
      }

      /// <summary>
      /// Pesquisa terminais físicos de
      /// uma pessoa dado o ID desta pessoa.
      /// </summary>
      /// <param name="key">
      /// Chave de integração.
      /// </param>
      /// <param name="personId">
      /// ID de uma Pessoa.
      /// </param>
      /// <param name="statusCode">
      /// Código de status da requisição
      /// HTTP que será realizada.
      /// </param>
      /// <param name="errorMessage">
      /// Possível mensagem de erro a ser
      /// retornada pela API.
      /// </param>
      /// <param name="pdcTerminals">
      /// Dicionário com informações de ID
      /// e nome de terminais.
      /// </param>
      /// <returns>
      /// Booleano indicando se a pesquisa foi
      /// ou não realizada com sucesso.
      /// </returns>
      public static bool GetTerminaisFisicos(string key,
                                             string personId,
                                             out string statusCode,
                                             out string errorMessage,
                                             out IList<ComboBoxTerminalFisico> pdcTerminals)
      {
         statusCode = string.Empty;
         errorMessage = string.Empty;
         pdcTerminals = new List<ComboBoxTerminalFisico>();

         string url = $"TerminalFisico/GetByPessoaId?key={key}&pessoaId={personId}";

         //Escrevendo a chamada no console para facilitar
         //a leitura do usuário que estiver debuggando.
         Debug.WriteLine($"Chamada (URL) -> {url}");

         HttpResponseMessage response = CallPostApi(url,
                                                    null,
                                                    out statusCode,
                                                    out string responseString,
                                                    out errorMessage);

         if(response == null)
            return false;

         var pdcTerminaisResult = JsonConvert.DeserializeObject<dynamic>(responseString);

         if(!response.IsSuccessStatusCode)
         {
            errorMessage = pdcTerminaisResult.message;
            return false;
         }

         if(pdcTerminaisResult.terminaisFisicos == null)
         {
            errorMessage = "Houve um erro ao recuperar os terminais físicos (representações dos PdCs) do usuário. Tente novamente.";
            return false;
         }

         //Retorna null para pessoa que não tem
         //terminais físicos cadastrados.
         if(pdcTerminaisResult.terminaisFisicos.Count < 1)
         {
            pdcTerminals = null;
            return true;
         }

         //Preenche o dictionary para uso da combobox.
         foreach(var terminalFisico in pdcTerminaisResult.terminaisFisicos)
         {
            ComboBoxTerminalFisico terf = new ComboBoxTerminalFisico()
            {
               Id = terminalFisico.id,
               Nome = terminalFisico.nome,
               InstalacaoId = terminalFisico.instalacaoId,
               PontoCaptura = terminalFisico.pontoCaptura
            };

            pdcTerminals.Add(terf);
         }

         return true;
      }

      /// <summary>
      /// Pesquisa terminais de uma pessoa
      /// dado o ID desta pessoa.
      /// </summary>
      /// <param name="key">
      /// Chave de integração.
      /// </param>
      /// <param name="personId">
      /// ID de uma Pessoa.
      /// </param>
      /// <param name="statusCode">
      /// Código de status da requisição
      /// HTTP que será realizada.
      /// </param>
      /// <param name="errorMessage">
      /// Possível mensagem de erro a ser
      /// retornada pela API.
      /// </param>
      /// <param name="terminals">
      /// Dicionário com informações de ID
      /// e nome de terminais.
      /// </param>
      /// <returns>
      /// Booleano indicando se a pesquisa foi
      /// ou não realizada com sucesso.
      /// </returns>
      public static bool GetTerminais(string key,
                                      string personId,
                                      out string statusCode,
                                      out string errorMessage,
                                      out IList<ComboBoxTerminal> terminals)
      {
         statusCode = string.Empty;
         errorMessage = string.Empty;
         terminals = new List<ComboBoxTerminal>();

         string url = $"Terminal/GetByPessoaId?key={key}&pessoaId={personId}";

         //Escrevendo a chamada no console para facilitar
         //a leitura do usuário que estiver debuggando.
         Debug.WriteLine($"Chamada (URL) -> {url}");

         HttpResponseMessage response = CallPostApi(url,
                                                    null,
                                                    out statusCode,
                                                    out string responseString,
                                                    out errorMessage);

         if(response == null)
            return false;

         var terminaisResult = JsonConvert.DeserializeObject<dynamic>(responseString);

         if(!response.IsSuccessStatusCode)
         {
            errorMessage = terminaisResult.message;
            return false;
         }

         if(terminaisResult.terminais == null)
         {
            errorMessage = "Houve um erro ao recuperar os terminais do usuário. Tente novamente.";
            return false;
         }

         //Retorna null para pessoa que não tem
         //terminais cadastrados.
         if(terminaisResult.terminais.Count < 1)
         {
            terminals = null;
            return true;
         }

         //Preenche o dictionary para uso da combobox.
         foreach(var terminal in terminaisResult.terminais)
         {
            ComboBoxTerminal term = new ComboBoxTerminal()
            {
               Id = terminal.id,
               Nome = terminal.nome
            };

            terminals.Add(term);
         }

         return true;
      }

      /// <summary>
      /// Realiza uma transação administrativa através da API
      /// PagamentoExterno/InsertPagamentoExternoTipoAdmin.
      /// </summary>
      /// <param name="key">
      /// Chave de integração.
      /// </param>
      /// <param name="terminalId">
      /// ID do terminal que realizará
      /// a transação administrativa.
      /// </param>
      /// <param name="techPassword">
      /// Senha técnica da pessoa.
      /// </param>
      /// <param name="startAdminAuto">
      /// Se a transação deve ou não ser
      /// iniciada automaticamente.
      /// </param>
      /// <param name="statusCode">
      /// Código de status da requisição
      /// HTTP que será realizada.
      /// </param>
      /// <param name="errorMessage">
      /// Possível mensagem de erro a ser
      /// retornada pela API.
      /// </param>
      /// <param name="adminTransacId">
      /// ID do pagamento externo que representa
      /// a transação administrativa criada.
      /// </param>
      /// <returns>
      /// Booleano indicando se a administrativa
      /// foi ou não criada com sucesso.
      /// </returns>
      public static bool TransacAdmin(string key,
                                      int terminalId,
                                      string techPassword,
                                      bool startAdminAuto,
                                      out string statusCode,
                                      out string errorMessage,
                                      out string adminTransacId)
      {
         statusCode = string.Empty;
         errorMessage = string.Empty;
         adminTransacId = string.Empty;

         string url = $"PagamentoExterno/InsertPagamentoExternoTipoAdmin?key={key}";

         var adminBody = new
         {
            terminalId = terminalId,
            senhaTecnica = techPassword,
            aguardarTefIniciarTransacao = startAdminAuto
         };

         string json = JsonConvert.SerializeObject(adminBody);
         var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

         //Escrevendo a chamada no console para facilitar
         //a leitura do usuário que estiver debuggando.
         Debug.WriteLine($"Chamada (URL) -> {url}");
         Debug.WriteLine($"Chamada (body) -> {adminBody}");

         HttpResponseMessage response = CallPostApi(url,
                                                    httpContent,
                                                    out statusCode,
                                                    out string responseString,
                                                    out errorMessage);

         if(response == null)
            return false;

         var adminResult = JsonConvert.DeserializeObject<dynamic>(responseString);

         if(!response.IsSuccessStatusCode)
         {
            errorMessage = adminResult.message;
            return false;
         }

         if(adminResult.pagamentoExterno != null)
            adminTransacId = adminResult.pagamentoExterno.id;

         return true;
      }

      /// <summary>
      /// Realiza uma venda no ControlPay
      /// através da API Venda/Vender.
      /// </summary>
      /// <param name="key">
      /// Chave de integração.
      /// </param>
      /// <param name="terminalId">
      /// ID do terminal que realizará a venda.
      /// </param>
      /// <param name="paymentMethod">
      /// Forma de pagamento usada na venda.
      /// </param>
      /// <param name="transacValue">
      /// Valor da transação.
      /// </param>
      /// <param name="startAuto">
      /// Se a transação deve ou não ser
      /// iniciada automaticamente.
      /// </param>
      /// <param name="statusCode">
      /// Código de status da requisição
      /// HTTP que será realizada.
      /// </param>
      /// <param name="errorMessage">
      /// Possível mensagem de erro a ser
      /// retornada pela API.
      /// </param>
      /// <param name="intencaoVendaId">
      /// ID da intenção de venda gerada
      /// pelo uso da API.
      /// </param>
      /// <returns>
      /// Booleano indicando se a intenção de
      /// venda foi ou não criada com sucesso.
      /// </returns>
      public static bool Vender(string key,
                                int terminalId,
                                int paymentMethod,
                                string transacValue,
                                bool startAuto,
                                out string statusCode,
                                out string errorMessage,
                                out string intencaoVendaId)
      {
         statusCode = string.Empty;
         errorMessage = string.Empty;
         intencaoVendaId = string.Empty;

         string url = $"Venda/Vender?key={key}";

         var vendaBody = new
         {
            formaPagamentoId = paymentMethod,
            terminalId = terminalId,
            valorTotalVendido = transacValue,
            observacao = "Esta venda foi realizada usando a aplicação exemplo fornecida pelo time de desenvolvimento do ControlPay.",
            aguardarTefIniciarTransacao = startAuto,

            //Exemplo de body acima:
            // formaPagamentoId = 21,
            // terminalId = 1234,
            // valorTotalVendido = "10,00",
            // observacao = "Obs. atrelada à venda para uso de quem realizou a venda.",
            // aguardarTefIniciarTransacao = true,

            //Propriedades opcionais (exemplos):
            // pedidoId = 123,            //Utilizado para Pedidos no ControlPay.
            // preDatado = true,          //Para transações pré-datadas.
            // aVista = true,             //Para transações à vista.
            // parcelamentoAdmin = true,  //Tipo de parcelamento (booleano indicando admin/emissor ou loja/estabelecimento)
            // quantidadeParcelas = 1     //Quantidade de parcelas quando há parcelamento.
         };

         string json = JsonConvert.SerializeObject(vendaBody);
         var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

         //Escrevendo a chamada no console para facilitar
         //a leitura do usuário que estiver debuggando.
         Debug.WriteLine($"Chamada (URL) -> {url}");
         Debug.WriteLine($"Chamada (body) -> {vendaBody}");

         HttpResponseMessage response = CallPostApi(url,
                                                    httpContent,
                                                    out statusCode,
                                                    out string responseString,
                                                    out errorMessage);

         if(response == null)
            return false;

         var vendaResult = JsonConvert.DeserializeObject<dynamic>(responseString);

         if(!response.IsSuccessStatusCode)
         {
            errorMessage = vendaResult.message;
            return false;
         }

         if(vendaResult.intencaoVenda != null)
            intencaoVendaId = vendaResult.intencaoVenda.id;

         return true;
      }

      #endregion Public methods

      #region Private methods

      /// <summary>
      /// Método genérico para chamadas POST
      /// de APIs do ControlPay.
      /// </summary>
      /// <param name="url">
      /// URL da chamada.
      /// </param>
      /// <param name="httpContent">
      /// HTTP Content da chamada.
      /// </param>
      /// <param name="statusCode">
      /// Código de retorno.
      /// </param>
      /// <param name="responseString">
      /// Resposta da API após realizado
      /// o ReadAsStringAsync do conteúdo.
      /// </param>
      /// <param name="errorMessage">
      /// Mensagem de erro, caso ocorra um
      /// erro durante o processamento do
      /// método.
      /// </param>
      /// <returns>
      /// Resposta da API completa.
      /// </returns>
      private static HttpResponseMessage CallPostApi(string url,
                                                     StringContent httpContent,
                                                     out string statusCode,
                                                     out string responseString,
                                                     out string errorMessage)
      {
         statusCode = string.Empty;
         responseString = string.Empty;
         errorMessage = string.Empty;

         try
         {
            HttpResponseMessage response = ApiClient.PostAsync(url, httpContent).Result;

            statusCode = response.StatusCode.ToString();

            responseString = response.Content.ReadAsStringAsync().Result;

            //Escrevendo a resposta no console para facilitar
            //a leitura do usuário que estiver debuggando.
            Debug.WriteLine($"Resposta (body) <- {responseString}");

            return response;
         }
         catch(Exception ex)
         {
            //Exception colocada no console para
            //facilitar ao usuário verificar erros.
            Debug.WriteLine($"CallPostApi: {ex}");

            errorMessage = ex.Message;
            return null;
         }
      }

      #endregion Private methods
   }
}
