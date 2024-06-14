using ExemploIntegracaoApiControlPay.Helpers;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExemploIntegracaoApiControlPay
{
   /// <summary>
   /// Tela principal da aplicação.
   /// </summary>
   public partial class PrincipalScreen : Form
   {
      #region Public Properties

      /// <summary>
      /// Chave de integração do usuário.
      /// </summary>
      public static string ApiKey;

      /// <summary>
      /// ID de Pessoa do usuário.
      /// </summary>
      public static string PersonId;

      /// <summary>
      /// ID do Terminal do usuário.
      /// </summary>
      public static int TerminalId;

      #endregion Public Properties

      #region Constructor

      /// <summary>
      /// Construtor da tela principal.
      /// </summary>
      public PrincipalScreen()
      {
         //Estado inicial da propriedades.
         ApiKey = string.Empty;
         PersonId = string.Empty;
         TerminalId = 0;

         //Criando HttpClient.
         ApiHelper.CreateApiClient();

         //Inicializando os componentes da tela.
         InitializeComponent();

         //Adicionando KeyPress de Enter para os inputs.
         this.textBoxCpfCnpjInput.KeyPress += new KeyPressEventHandler(CheckEnterKeyPressLogin);
         this.textBoxLoginPasswordInput.KeyPress += new KeyPressEventHandler(CheckEnterKeyPressLogin);
      }

      #endregion Constructor

      #region Load Screen

      /// <summary>
      /// Carregamento da tela principal.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void PrincipalScreen_Load(object sender, EventArgs e)
      {
         //Link para o portal de Sandbox
         LinkLabel.Link linkSandbox = new LinkLabel.Link();
         linkSandbox.LinkData = "https://sandbox.controlpay.com.br/";
         linkLabelSandboxControlPay.Links.Add(linkSandbox);

         //Link para a documentação do ControlPay
         LinkLabel.Link linkDocs = new LinkLabel.Link();
         linkDocs.LinkData = "https://paygodev.readme.io/docs/o-que-é-controlpay/";
         linkLabelDocs.Links.Add(linkDocs);

         //Status inicial dos painéis condicionais
         //relacionados a login/chave de integração.
         panelDoesntHaveKey.Show();
         panelHasKey.Hide();
         checkBoxHasKey.Checked = false;
      }

      #endregion Load Screen

      #region Link Click

      /// <summary>
      /// Evento de clique para o link que
      /// redireciona o usuário para o portal
      /// sandbox do ControlPay.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void linkLabelSandboxControlPay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(e.Link.LinkData as string);
      }

      /// <summary>
      /// Evento de clique para o link que
      /// redireciona o usuário para a
      /// documentação do ControlPay.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void linkLabelDocs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(e.Link.LinkData as string);
      }

      #endregion Link Click

      #region Checkbox

      /// <summary>
      /// Evento da checkbox que muda o status
      /// dos painéis dependendo da necessidade
      /// do usuário (login ou uso de uma chave
      /// que ele já possua).
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void checkBoxHasKey_CheckedChanged(object sender, EventArgs e)
      {
         panelDoesntHaveKey.Visible = !panelDoesntHaveKey.Visible;
         panelHasKey.Visible = !panelHasKey.Visible;
      }

      #endregion Checkbox

      #region Button Click

      /// <summary>
      /// Clique do botão Login,
      /// usado para realizar um login
      /// e receber uma chave de integração
      /// do ControlPay através da API Login/Login.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonLogin_Click(object sender, EventArgs e)
      {
         string cpfCnpj = textBoxCpfCnpjInput.Text;
         string password = textBoxLoginPasswordInput.Text;

         if(string.IsNullOrEmpty(cpfCnpj) || string.IsNullOrEmpty(password))
         {
            MessageBox.Show("Para realizar o Login, é necessário preencher o CPF/CNPJ e a senha. Preencha-os e tente novamente.",
                            "Login");
            return;
         }

         //Login/Login
         bool didLogin = ApiHelper.DoLogin(cpfCnpj,
                                           password,
                                           out string statusCode,
                                           out string errorMessage,
                                           out string personId,
                                           out string key);

         //Erro
         if(!didLogin)
         {
            //Erro de aplicação.
            if(string.IsNullOrEmpty(statusCode))
            {
               MessageBox.Show($"Houve um erro durante o processamento do Login pela aplicação: {errorMessage}",
                               "Erro");
               return;
            }

            //Erro retornado da API.
            MessageBox.Show($"A API retornou {statusCode} para a chamada de login, com a seguinte mensagem: {errorMessage}",
                            "Erro de Login");
            return;
         }

         //Adiciona as informações
         //para uso posterior.
         ApiKey = key;
         PersonId = personId;

         //Muda os valores dos textos para
         //o usuário visualizar as infos.
         textBoxPersonIdValue.Text = PersonId;
         textBoxKeyValue.Text = ApiKey;

         MessageBox.Show("Login realizado com sucesso! ID de Pessoa e Chave de Integração salvos.",
                         "API de Login");
         return;
      }

      private void buttonAddKey_Click(object sender, EventArgs e)
      {
         //TODO adicionar valores de Key e PersonId
      }

      #endregion Button Click

      #region Key Press

      /// <summary>
      /// Checa se o evento de KeyPress foi uma
      /// tecla "Enter". Caso positivo, realiza
      /// o clique do botão de Login.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void CheckEnterKeyPressLogin(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Enter)
         {
            buttonLogin.PerformClick();
         }
      }

      #endregion Key Press
   }
}
