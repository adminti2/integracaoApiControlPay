using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExemploIntegracaoApiControlPay
{
   public partial class PrincipalScreen : Form
   {
      public PrincipalScreen()
      {
         InitializeComponent();
      }

      //TODO Comentar métodos

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

         panelDoesntHaveKey.Show();
         panelHasKey.Hide();
         checkBoxHasKey.Checked = false;
      }

      private void linkLabelSandboxControlPay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(e.Link.LinkData as string);
      }

      private void linkLabelDocs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(e.Link.LinkData as string);
      }

      private void checkBoxHasKey_CheckedChanged(object sender, EventArgs e)
      {
         panelDoesntHaveKey.Visible = !panelDoesntHaveKey.Visible;
         panelHasKey.Visible = !panelHasKey.Visible;
      }
   }
}
