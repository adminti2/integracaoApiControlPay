using System.ComponentModel;
using System.Reflection;

namespace ExemploIntegracaoApiControlPay.ValueObjects
{
   /// <summary>
   /// Enums usados na aplicação.
   /// </summary>
   public static class Enums
   {
      /// <summary>
      /// Formas de pagamento aceitas
      /// pelas APIs do ControlPay.
      /// </summary>
      public enum FormaPagamento
      {
         /// <summary>
         /// Crédito a ser usado em
         /// conjunto com o PayGo Windows.
         /// </summary>
         [Description("TEF Crédito")]
         TefCredito = 21,

         /// <summary>
         /// Débito a ser usado em
         /// conjunto com o PayGo Windows.
         /// </summary>
         [Description("TEF Débito")]
         TefDebito = 22,

         /// <summary>
         /// Voucher a ser usado em
         /// conjunto com o PayGo Windows.
         /// </summary>
         [Description("TEF Voucher")]
         TefVoucher = 23,

         /// <summary>
         /// Outras modalidades a serem usadas em
         /// conjunto com o PayGo Windows (diferentes
         /// das outras presentes aqui). Esta forma é
         /// usada principalmente em formas de pagamento
         /// específicas de adquirentes que não estão na
         /// mesma categoria das outras formas TEF aqui
         /// descritas.
         /// </summary>
         [Description("TEF Outros")]
         TefOutros = 24,

         /// <summary>
         /// PIX/Carteira Digital a ser usada em
         /// conjunto com o PayGo Windows.
         /// </summary>
         [Description("TEF Carteira Digital")]
         TefCarteiraDigital = 25,

         /// <summary>
         /// Pagamento no Gateway PayGo usando Crédito.
         /// </summary>
         [Description("Link de pagamento Crédito")]
         LinkCredito = 51,

         /// <summary>
         /// Pagamento no Gateway PayGo usando Débito.
         /// </summary>
         [Description("Link de pagamento Débito")]
         LinkDebito = 52,

         /// <summary>
         /// Pagamento no Gateway PayGo usando Boleto.
         /// </summary>
         [Description("Boleto")]
         LinkBoleto = 53,

         /// <summary>
         /// Transação fora do ControlPay usando Crédito.
         /// Apenas salva os valores no ControlPay, sem
         /// realizar transações.
         /// </summary>
         [Description("POS Crédito")]
         PosCredito = 11,

         /// <summary>
         /// Transação fora do ControlPay usando Débito.
         /// Apenas salva os valores no ControlPay, sem
         /// realizar transações.
         /// </summary>
         [Description("POS Débito")]
         PosDebito = 12,

         /// <summary>
         /// Transação fora do ControlPay usando Voucher.
         /// Apenas salva os valores no ControlPay, sem
         /// realizar transações.
         /// </summary>
         [Description("POS Voucher")]
         PosVoucher = 13,

         /// <summary>
         /// Transação fora do ControlPay usando dinheiro físico.
         /// Apenas salva os valores no ControlPay, sem
         /// realizar transações.
         /// </summary>
         [Description("Dinheiro")]
         Dinheiro = 41,
      }

      /// <summary>
      /// Recupera a descrição de um dado Enum.
      /// </summary>
      /// <typeparam name="TEnum">
      /// Enum.
      /// </typeparam>
      /// <param name="value">
      /// Valor dentro de um enum.
      /// </param>
      /// <returns></returns>
      public static string GetDescription<TEnum>(this TEnum value)
      {
         FieldInfo fi = value.GetType().GetField(value.ToString());
         if(fi == null)
            return "";
         DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
         return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
      }
   }
}
