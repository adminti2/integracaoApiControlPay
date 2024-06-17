namespace ExemploIntegracaoApiControlPay.Objects
{
   /// <summary>
   /// Objeto formatado para Terminais, a serem usados
   /// como DataSource para a ComboBox de terminais.
   /// </summary>
   class ComboBoxTerminal
   {
      /// <summary>
      /// ID de um Terminal no ControlPay.
      /// </summary>
      public string Id { get; set; }

      /// <summary>
      /// Nome de um Terminal no ControlPay.
      /// </summary>
      public string Nome { get; set; }
   }
}
