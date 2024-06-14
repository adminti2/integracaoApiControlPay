using Newtonsoft.Json;
using System;
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
      /// <returns></returns>
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

         try
         {
            HttpResponseMessage response = ApiClient.PostAsync("Login/Login", httpContent).Result;

            statusCode = response.StatusCode.ToString();

            var responseString = response.Content.ReadAsStringAsync();

            var loginResult = JsonConvert.DeserializeObject<dynamic>(responseString.Result);

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
         catch(Exception ex)
         {
            errorMessage = ex.Message;
            return false;
         }
      }

      public static void GetTerminals(string key, string personId)
      {
         //TODO TerminalGetByPessoaId
         
         //var response = await ApiClient.GetAsync($"Terminal/GetByPessoaId?key={key}&pessoaId={personId}");

         return;
      }
   }
}
