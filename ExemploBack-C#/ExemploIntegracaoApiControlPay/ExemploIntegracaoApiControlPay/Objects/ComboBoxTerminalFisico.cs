namespace ExemploIntegracaoApiControlPay.Objects
{
   /// <summary>
   /// Objeto formatado para Terminais Físicos a serem usados
   /// como DataSource para a ComboBox de terminais.
   /// Terminais Físicos são as representações de pontos de
   /// captura dentro do ControlPay.
   /// <br/><br/>
   /// Atenção: este objeto não contém todas as propriedades
   /// de um objeto TerminalFisico do ControlPay. Para o objeto completo,
   /// verifique o retorno da API relacionada.
   /// </summary>
   public class ComboBoxTerminalFisico
   {
      /// <summary>
      /// ID de um Terminal Físico no ControlPay.
      /// </summary>
      public string Id { get; set; }

      /// <summary>
      /// Nome de um Terminal Físico no ControlPay.
      /// </summary>
      public string Nome { get; set; }

      /// <summary>
      /// ID de instalação de um Terminal Físico,
      /// usado para instalações de PayGo Windows.
      /// </summary>
      public string InstalacaoId { get; set; }

      /// <summary>
      /// Ponto de captura (PdC) que está atrelado
      /// a este Terminal Físico.
      /// </summary>
      public string PontoCaptura { get; set; }

      /// <summary>
      /// String com informações do terminal a ser
      /// mostrada na ComboBox.
      /// </summary>
      public string TerminalFisicoString
      {
         get
         {
            return Nome + " (PDC: " + PontoCaptura + ") [ID de instalação: " + InstalacaoId + "]";
         }
      }
   }
}
