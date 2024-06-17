namespace ExemploIntegracaoApiControlPay.Objects
{
   /// <summary>
   /// Objeto formatado para Terminais, a serem usados
   /// como DataSource para a ComboBox de terminais.
   /// Terminais são a representação  dentro do ControlPay
   /// dos terminais usados para a realização de vendas.
   /// <br/><br/>
   /// Atenção: este objeto não contém todas as propriedades
   /// de um objeto Terminal do ControlPay. Para o objeto completo,
   /// verifique o retorno da API relacionada.
   /// </summary>
   public class ComboBoxTerminal
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
