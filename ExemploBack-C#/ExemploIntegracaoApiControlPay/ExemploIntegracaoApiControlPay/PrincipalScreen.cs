using ExemploIntegracaoApiControlPay.Helpers;
using ExemploIntegracaoApiControlPay.Objects;
using ExemploIntegracaoApiControlPay.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
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
         ClearPropValues();

         //Criando HttpClient.
         ApiHelper.CreateApiClient();

         //Inicializando os componentes da tela.
         InitializeComponent();

         //Adicionando KeyPress de Enter para os inputs.
         this.textBoxCpfCnpjInput.KeyPress += new KeyPressEventHandler(CheckEnterKeyPressLogin);
         this.textBoxLoginPasswordInput.KeyPress += new KeyPressEventHandler(CheckEnterKeyPressLogin);

         //Adicionando formas de pagamento à sua ComboBox.
         Dictionary<int, string> formasPagamento = new Dictionary<int, string>();
         foreach(Enums.FormaPagamento fpg in Enum.GetValues(typeof(Enums.FormaPagamento)))
         {
            formasPagamento.Add((int)fpg, fpg.GetDescription());
         }
         comboBoxFormaPagamento.DataSource = formasPagamento.ToArray();
         comboBoxFormaPagamento.DisplayMember = "Value";
         comboBoxFormaPagamento.ValueMember = "Key";
         comboBoxFormaPagamento.DropDownStyle = ComboBoxStyle.DropDownList;

         //Selecionando TEF Crédito como a opção default
         comboBoxFormaPagamento.SelectedValue = (int)Enums.FormaPagamento.TefCredito;
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

      #region Button Click

      /// <summary>
      /// Clique do botão para adicionar
      /// chave de integração. Adiciona
      /// a chave e o ID da Pessoa a serem
      /// usados nas chamadas de APIs subsequentes.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonAddKey_Click(object sender, EventArgs e)
      {
         ClearPropValues();

         string personId = textBoxPersonIdInput.Text;
         string key = textBoxKeyInput.Text;

         if(string.IsNullOrEmpty(personId) || string.IsNullOrEmpty(key))
         {
            MessageBox.Show("Para adicionar a chave de integração, é necessário preencher os campos de ID da Pessoa e da própria chave. Preencha-os e tente novamente.",
                            "Chave de integração");
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

         MessageBox.Show("Chave de integração adicionada com sucesso! Ela será usada para as chamadas da aplicação. Agora, usaremos estas informações para recuperar terminais e pontos de captura do usuário. Por favor, aguarde.",
                         "Chave de integração");

         //Populando as combos da tela de terminais.
         PopulateComboboxes(key, personId);

         return;
      }

      /// <summary>
      /// Clique do botão para criar um novo terminal atrelado ao
      /// terminal físico (PdC) selecionado na lista.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonCreateTerminal_Click(object sender, EventArgs e)
      {
         if(string.IsNullOrEmpty(ApiKey) || string.IsNullOrEmpty(PersonId))
         {
            MessageBox.Show("Para criar um terminal, é preciso primeiro ter uma chave de integração cadastrada na aplicação. Realize o login ou adicione uma chave.");

            return;
         }

         //Valor de terminal físico a ser usado para o terminal.
         string termFisIdString = comboBoxTerminaisFisicos.SelectedValue.ToString();
         bool resultOk = int.TryParse(termFisIdString, out int termFisId);

         if(!resultOk || termFisId == 0)
         {
            MessageBox.Show("Para criar um terminal, é preciso selecionar um terminal físico (PdC) antes. Selecione-o e tente novamente.");

            return;
         }

         //Terminal/Insert
         bool didCreateTerminal = ApiHelper.CreateTerminal(ApiKey,
                                                           PersonId,
                                                           termFisId,
                                                           out string termStatusCode,
                                                           out string termErrorMessage,
                                                           out string createdTerminalId);

         //Erro
         if(!didCreateTerminal)
         {
            MessageBox.Show($"Ocorreu um erro durante a criação do terminal. A API de criação de terminais retornou {termStatusCode}, com a seguinte mensagem: {termErrorMessage}",
                            "Erro ao criar terminal");

            return;
         }

         //Repopulando as combos para
         //apresentar os terminais atualizados.
         PopulateComboboxes(ApiKey, PersonId);

         //ID do terminal criado.
         bool parseTermId = int.TryParse(createdTerminalId, out int termId);
         if(string.IsNullOrEmpty(createdTerminalId) || !parseTermId)
         {
            MessageBox.Show("Ocorreu um erro ao verificar o ID do terminal criado. Verifique a lista de terminais e procure pelo terminal criado ou crie um novo terminal.",
                            "Erro ao verificar o ID do terminal criado");
         }
         else
         {
            //Terminal a ser usado nas chamadas.
            TerminalId = termId;

            MessageBox.Show($"Terminal (ID: {termId}) criado com sucesso! Iremos recarregar as listas de terminais para refletir o novo terminal criado. Aguarde, por favor.",
                            "Criar terminal");
         }

         //Seta o valor atual do TerminalId
         //como sendo usado na UI.
         SetCboxTerminalValue();

         return;
      }

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
         ClearPropValues();

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
                                           out string loginStatusCode,
                                           out string loginErrorMessage,
                                           out string personId,
                                           out string key);

         //Erro
         if(!didLogin)
         {
            //Erro de aplicação.
            if(string.IsNullOrEmpty(loginStatusCode))
            {
               MessageBox.Show($"Houve um erro durante o processamento do Login pela aplicação: {loginErrorMessage}",
                               "Erro");
               return;
            }

            //Erro retornado da API.
            MessageBox.Show($"A API retornou {loginStatusCode} para a chamada de login, com a seguinte mensagem: {loginErrorMessage}",
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

         MessageBox.Show("Login realizado com sucesso! ID de Pessoa e Chave de Integração salvos. Agora, usaremos estas informações para recuperar terminais e pontos de captura do usuário. Por favor, aguarde.",
                         "Login");

         //Populando as combos da tela de terminais.
         PopulateComboboxes(key, personId);

         return;
      }

      /// <summary>
      /// Clique do botão de transacionar. Cria uma
      /// intenção de venda no ControlPay.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void buttonTransacionar_Click(object sender, EventArgs e)
      {
         if(string.IsNullOrEmpty(ApiKey) || string.IsNullOrEmpty(PersonId) || TerminalId < 1)
         {
            MessageBox.Show("Para realizar uma venda, é preciso primeiro ter uma chave de integração cadastrada na aplicação e um terminal válido. Realize o login ou adicione uma chave, e escolha um terminal para transacionar.",
                            "Venda");

            return;
         }

         //FormaPagamento
         string paymentMethodString = comboBoxFormaPagamento.SelectedValue.ToString();
         if(!int.TryParse(paymentMethodString, out int paymentMethod))
         {
            MessageBox.Show("Método de pagamento necessita ser escolhido antes de realizar uma transação.",
                            "Venda");

            return;
         }

         //Valor
         string transacValue = textBoxValorTransacao.Text;
         if(string.IsNullOrEmpty(transacValue))
         {
            MessageBox.Show("Método de pagamento necessita ser escolhido antes de realizar uma transação.",
                            "Venda");

            return;
         }

         //IniciarAutomaticamente
         bool startAuto = checkBoxStartAuto.Checked;

         MessageBox.Show("Sua intenção de venda será criada agora."
                              + Environment.NewLine + "Atente-se ao fato de que, para transações TEF, o PayGo Windows deve estar aberto e rodando antes de prosseguir."
                              + Environment.NewLine + "Caso não esteja, a API terá um tempo de resposta mais alto, por estar esperando o PayGo Windows, e então a intenção de venda expirará.",
                         "Venda");

         //Venda/Vender
         bool didCreateIntencaoVenda = ApiHelper.Vender(ApiKey,
                                                        TerminalId,
                                                        paymentMethod,
                                                        transacValue,
                                                        startAuto,
                                                        out string vendaStatusCode,
                                                        out string vendaErrorMessage,
                                                        out string intencaoVendaId);

         //Erro
         if(!didCreateIntencaoVenda)
         {
            MessageBox.Show($"Ocorreu um erro criar uma intenção de venda. A API de venda retornou {vendaStatusCode}, com a seguinte mensagem: {vendaErrorMessage}",
                            "Erro ao intenção de venda");

            return;
         }

         string okMessage = "Intenção de venda";
         
         if(!string.IsNullOrEmpty(intencaoVendaId))
            okMessage += $" [ID {intencaoVendaId}]";

         okMessage += " criada com sucesso!"
            + Environment.NewLine + "Caso tenha realizado uma transação TEF, verifique o PayGo Windows instalado e continue a transação nele."
            + Environment.NewLine + "Caso tenha realizado uma transação com Gateway, verifique o output de Debug da aplicação para recuperar o link de redirecionamento para o Gateway.";

         MessageBox.Show(okMessage,
                         "Venda");

         return;
      }

      #endregion Button Click

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

      #region ComboBox

      /// <summary>
      /// Evento para quando a comboBoxTerminais é modificada,
      /// fechada ou tem seu valor alterado. Este método garante
      /// que o valor atual da combo será o usado para o ID de
      /// Terminal, caso seja válido.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void CboxTerminalSelected(object sender, EventArgs e)
      {
         try
         {
            string termIdString = comboBoxTerminais.SelectedValue.ToString();

            bool resultOk = int.TryParse(termIdString, out int termId);

            if(resultOk)
            {
               TerminalId = termId;
               textBoxTerminalUsado.Text = termIdString;
            }
         }
         catch(Exception)
         {
            TerminalId = 0;
            textBoxTerminalUsado.Text = "...";
         }
      }

      /// <summary>
      /// Popula as ComboBoxes de Terminais
      /// e PdCs (Terminais Físicos) da aplicação
      /// de acordo com as informações do usuário.
      /// </summary>
      /// <param name="key">
      /// Chave de integração.
      /// </param>
      /// <param name="personId">
      /// ID da Pessoa.
      /// </param>
      private void PopulateComboboxes(string key, string personId)
      {
         //Terminal/GetByPessoaId: Pesquisa os terminais
         //para incluí-los na combobox de terminais.
         bool gotTerminals = ApiHelper.GetTerminais(key,
                                                    personId,
                                                    out string terminalStatusCode,
                                                    out string terminalErrorMessage,
                                                    out IList<ComboBoxTerminal> terminals);

         //TerminalFisico/GetByPessoaId: Pesquisa os terminais
         //físicos para incluí-los na combobox de terminais físicos.
         bool gotFisicos = ApiHelper.GetTerminaisFisicos(key,
                                                         personId,
                                                         out string fisicoStatusCode,
                                                         out string fisicoErrorMessage,
                                                         out IList<ComboBoxTerminalFisico> pdcTerminals);

         //Popula a combobox de terminais.
         PopulateTerminalsComboBox(gotTerminals, terminals);

         //Popula a combobox de PdCs/Terminais Físicos.
         PopulateFisicosComboBox(gotFisicos, pdcTerminals);

         if(gotTerminals && gotFisicos)
         {
            MessageBox.Show("Terminais e pontos de captura recuperados com sucesso!",
                            "Terminais");

            return;
         }

         if(!gotTerminals)
         {
            MessageBox.Show($"A API de pesquisa de terminais retornou {terminalStatusCode}, com a seguinte mensagem: {terminalErrorMessage}",
                            "Erro ao recuperar terminais");
         }

         if(!gotFisicos)
         {
            MessageBox.Show($"A API de pesquisa de terminais físicos (PdCs) retornou {fisicoStatusCode}, com a seguinte mensagem: {fisicoErrorMessage}",
                            "Erro ao recuperar terminais físicos");
         }

         return;
      }

      /// <summary>
      /// Popula a ComboBox de Terminais com as informações
      /// de Terminais retornadas pela API de Terminais do
      /// ControlPay.
      /// </summary>
      /// <param name="gotTerminals">
      /// Se a API de terminais retornou OK ou não à requisição.
      /// </param>
      /// <param name="terminals">
      /// Dicionário com ID e Nome dos Terminais retornados pela API.
      /// </param>
      private void PopulateTerminalsComboBox(bool gotTerminals,
                                             IList<ComboBoxTerminal> terminals)
      {
         if(gotTerminals && terminals != null && terminals.Count > 1)
         {
            comboBoxTerminais.DataSource = null;
            comboBoxTerminais.Items.Clear();

            //Preenche a combobox de terminais.
            var terminalDataSource = terminals;

            comboBoxTerminais.DataSource = terminalDataSource;
            comboBoxTerminais.DisplayMember = "Nome";
            comboBoxTerminais.ValueMember = "Id";

            comboBoxTerminais.DropDownStyle = ComboBoxStyle.DropDownList;
         }
         else
         {
            comboBoxTerminais.DataSource = null;
            comboBoxTerminais.Items.Clear();

            //Preenche a combobox com "Nenhum terminal disponível"
            comboBoxTerminais.Items.AddRange(new object[] { "Nenhum terminal disponível" });
            comboBoxTerminais.DropDownStyle = ComboBoxStyle.DropDownList;
         }
      }

      /// <summary>
      /// Popula a ComboBox de Terminais Físicos com as informações
      /// de Terminais Físicos retornadas pela API de Terminais
      /// Físicos do ControlPay.
      /// </summary>
      /// <param name="gotFisicos">
      /// Se a API de terminais físicos retornou OK ou não à requisição.
      /// </param>
      /// <param name="pdcTerminals">
      /// Dicionário com ID, Nome, PDC e ID de instalação dos Terminais
      /// Físicos retornados pela API.
      /// </param>
      private void PopulateFisicosComboBox(bool gotFisicos, IList<ComboBoxTerminalFisico> pdcTerminals)

      {
         if(gotFisicos && pdcTerminals != null && pdcTerminals.Count > 1)
         {
            comboBoxTerminaisFisicos.DataSource = null;
            comboBoxTerminaisFisicos.Items.Clear();

            //Preenche a combobox de terminais físicos.
            var terminalDataSource = pdcTerminals;

            comboBoxTerminaisFisicos.DataSource = terminalDataSource;
            comboBoxTerminaisFisicos.DisplayMember = "TerminalFisicoString";
            comboBoxTerminaisFisicos.ValueMember = "Id";

            comboBoxTerminaisFisicos.DropDownStyle = ComboBoxStyle.DropDownList;
         }
         else
         {
            comboBoxTerminaisFisicos.DataSource = null;
            comboBoxTerminaisFisicos.Items.Clear();

            //Preenche a combobox com "Nenhum PdC disponível"
            comboBoxTerminaisFisicos.Items.AddRange(new object[] { "Nenhum PdC disponível" });
            comboBoxTerminaisFisicos.DropDownStyle = ComboBoxStyle.DropDownList;
         }
      }

      /// <summary>
      /// Seta o valor atual da ComboBox de
      /// Terminais como o valor atual do ID
      /// de Terminal a ser usado nas chamadas.
      /// </summary>
      private void SetCboxTerminalValue()
      {
         try
         {
            comboBoxTerminais.SelectedValue = TerminalId.ToString();
            textBoxTerminalUsado.Text = TerminalId.ToString();
         }
         catch(Exception ex)
         {
            //Exception colocada no console para
            //facilitar ao usuário verificar erros.
            Debug.WriteLine($"SetCboxTerminalValue: {ex}");

            TerminalId = 0;
            textBoxTerminalUsado.Text = "...";
         }
      }

      #endregion ComboBox

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

      #region TextBox

      /// <summary>
      /// Formatação para a textBoxValorTransacao,
      /// deixando seu texto em formato de moeda
      /// (porém sem o símbolo "R$").
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void textBoxValorTransacao_Leave(object sender, EventArgs e)
      {
         //Retira o "R$" para facilitar no envio para API.
         NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
         nfi = (NumberFormatInfo)nfi.Clone();
         nfi.CurrencySymbol = "";

         //Formatação em moeda.
         double value;
         if(double.TryParse(textBoxValorTransacao.Text, out value))
            textBoxValorTransacao.Text = string.Format(nfi, "{0:C2}", value).Trim();
         else
            textBoxValorTransacao.Text = string.Empty;
      }

      #endregion TextBox

      #region Private methods

      private void ClearPropValues()
      {
         //Estado inicial da propriedades.
         ApiKey = string.Empty;
         PersonId = string.Empty;
         TerminalId = 0;
      }

      #endregion Private methods
   }
}
