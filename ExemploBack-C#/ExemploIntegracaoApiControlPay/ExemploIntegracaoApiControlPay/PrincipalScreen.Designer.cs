
namespace ExemploIntegracaoApiControlPay
{
   partial class PrincipalScreen
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if(disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalScreen));
         this.tabControlPages = new System.Windows.Forms.TabControl();
         this.tabPageInfo = new System.Windows.Forms.TabPage();
         this.groupBoxLinks = new System.Windows.Forms.GroupBox();
         this.linkLabelDocs = new System.Windows.Forms.LinkLabel();
         this.linkLabelSandboxControlPay = new System.Windows.Forms.LinkLabel();
         this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
         this.textBoxExplainingText = new System.Windows.Forms.TextBox();
         this.tabPageLogin = new System.Windows.Forms.TabPage();
         this.tabPageTerminal = new System.Windows.Forms.TabPage();
         this.tabPageTransacoes = new System.Windows.Forms.TabPage();
         this.tabPageAdmin = new System.Windows.Forms.TabPage();
         this.tabControlPages.SuspendLayout();
         this.tabPageInfo.SuspendLayout();
         this.groupBoxLinks.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
         this.SuspendLayout();
         // 
         // tabControlPages
         // 
         this.tabControlPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControlPages.Controls.Add(this.tabPageInfo);
         this.tabControlPages.Controls.Add(this.tabPageLogin);
         this.tabControlPages.Controls.Add(this.tabPageTerminal);
         this.tabControlPages.Controls.Add(this.tabPageTransacoes);
         this.tabControlPages.Controls.Add(this.tabPageAdmin);
         this.tabControlPages.Location = new System.Drawing.Point(-4, -1);
         this.tabControlPages.Name = "tabControlPages";
         this.tabControlPages.SelectedIndex = 0;
         this.tabControlPages.Size = new System.Drawing.Size(816, 516);
         this.tabControlPages.TabIndex = 0;
         // 
         // tabPageInfo
         // 
         this.tabPageInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.tabPageInfo.Controls.Add(this.groupBoxLinks);
         this.tabPageInfo.Controls.Add(this.pictureBoxLogo);
         this.tabPageInfo.Controls.Add(this.textBoxExplainingText);
         this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
         this.tabPageInfo.Name = "tabPageInfo";
         this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageInfo.Size = new System.Drawing.Size(808, 490);
         this.tabPageInfo.TabIndex = 0;
         this.tabPageInfo.Text = "Informações";
         // 
         // groupBoxLinks
         // 
         this.groupBoxLinks.Controls.Add(this.linkLabelDocs);
         this.groupBoxLinks.Controls.Add(this.linkLabelSandboxControlPay);
         this.groupBoxLinks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBoxLinks.ForeColor = System.Drawing.Color.White;
         this.groupBoxLinks.Location = new System.Drawing.Point(578, 365);
         this.groupBoxLinks.Name = "groupBoxLinks";
         this.groupBoxLinks.Size = new System.Drawing.Size(219, 113);
         this.groupBoxLinks.TabIndex = 2;
         this.groupBoxLinks.TabStop = false;
         this.groupBoxLinks.Text = "Links úteis";
         // 
         // linkLabelDocs
         // 
         this.linkLabelDocs.AutoSize = true;
         this.linkLabelDocs.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
         this.linkLabelDocs.Location = new System.Drawing.Point(6, 71);
         this.linkLabelDocs.Name = "linkLabelDocs";
         this.linkLabelDocs.Size = new System.Drawing.Size(198, 13);
         this.linkLabelDocs.TabIndex = 1;
         this.linkLabelDocs.TabStop = true;
         this.linkLabelDocs.Text = "Documentação do ControlPay e APIs";
         this.linkLabelDocs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDocs_LinkClicked);
         // 
         // linkLabelSandboxControlPay
         // 
         this.linkLabelSandboxControlPay.AutoSize = true;
         this.linkLabelSandboxControlPay.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
         this.linkLabelSandboxControlPay.Location = new System.Drawing.Point(6, 32);
         this.linkLabelSandboxControlPay.Name = "linkLabelSandboxControlPay";
         this.linkLabelSandboxControlPay.Size = new System.Drawing.Size(148, 13);
         this.linkLabelSandboxControlPay.TabIndex = 0;
         this.linkLabelSandboxControlPay.TabStop = true;
         this.linkLabelSandboxControlPay.Text = "Portal ControlPay Sandbox";
         this.linkLabelSandboxControlPay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSandboxControlPay_LinkClicked);
         // 
         // pictureBoxLogo
         // 
         this.pictureBoxLogo.Image = global::ExemploIntegracaoApiControlPay.Properties.Resources.ControlPayColorLogo;
         this.pictureBoxLogo.InitialImage = global::ExemploIntegracaoApiControlPay.Properties.Resources.ControlPayColorLogo;
         this.pictureBoxLogo.Location = new System.Drawing.Point(12, 6);
         this.pictureBoxLogo.Name = "pictureBoxLogo";
         this.pictureBoxLogo.Size = new System.Drawing.Size(259, 71);
         this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this.pictureBoxLogo.TabIndex = 1;
         this.pictureBoxLogo.TabStop = false;
         // 
         // textBoxExplainingText
         // 
         this.textBoxExplainingText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.textBoxExplainingText.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBoxExplainingText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBoxExplainingText.ForeColor = System.Drawing.Color.White;
         this.textBoxExplainingText.Location = new System.Drawing.Point(12, 94);
         this.textBoxExplainingText.Multiline = true;
         this.textBoxExplainingText.Name = "textBoxExplainingText";
         this.textBoxExplainingText.ReadOnly = true;
         this.textBoxExplainingText.Size = new System.Drawing.Size(505, 327);
         this.textBoxExplainingText.TabIndex = 0;
         this.textBoxExplainingText.Text = resources.GetString("textBoxExplainingText.Text");
         // 
         // tabPageLogin
         // 
         this.tabPageLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
         this.tabPageLogin.Name = "tabPageLogin";
         this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageLogin.Size = new System.Drawing.Size(808, 490);
         this.tabPageLogin.TabIndex = 1;
         this.tabPageLogin.Text = "Login";
         this.tabPageLogin.UseVisualStyleBackColor = true;
         // 
         // tabPageTerminal
         // 
         this.tabPageTerminal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.tabPageTerminal.Location = new System.Drawing.Point(4, 22);
         this.tabPageTerminal.Name = "tabPageTerminal";
         this.tabPageTerminal.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageTerminal.Size = new System.Drawing.Size(808, 490);
         this.tabPageTerminal.TabIndex = 2;
         this.tabPageTerminal.Text = "Terminal";
         this.tabPageTerminal.UseVisualStyleBackColor = true;
         // 
         // tabPageTransacoes
         // 
         this.tabPageTransacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.tabPageTransacoes.Location = new System.Drawing.Point(4, 22);
         this.tabPageTransacoes.Name = "tabPageTransacoes";
         this.tabPageTransacoes.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageTransacoes.Size = new System.Drawing.Size(808, 490);
         this.tabPageTransacoes.TabIndex = 3;
         this.tabPageTransacoes.Text = "Transações";
         this.tabPageTransacoes.UseVisualStyleBackColor = true;
         // 
         // tabPageAdmin
         // 
         this.tabPageAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.tabPageAdmin.Location = new System.Drawing.Point(4, 22);
         this.tabPageAdmin.Name = "tabPageAdmin";
         this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAdmin.Size = new System.Drawing.Size(808, 490);
         this.tabPageAdmin.TabIndex = 4;
         this.tabPageAdmin.Text = "Administrativas";
         this.tabPageAdmin.UseVisualStyleBackColor = true;
         // 
         // PrincipalScreen
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(809, 511);
         this.Controls.Add(this.tabControlPages);
         this.MaximumSize = new System.Drawing.Size(825, 550);
         this.MinimumSize = new System.Drawing.Size(825, 550);
         this.Name = "PrincipalScreen";
         this.Text = "Exemplo: API ControlPay";
         this.Load += new System.EventHandler(this.PrincipalScreen_Load);
         this.tabControlPages.ResumeLayout(false);
         this.tabPageInfo.ResumeLayout(false);
         this.tabPageInfo.PerformLayout();
         this.groupBoxLinks.ResumeLayout(false);
         this.groupBoxLinks.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
         this.ResumeLayout(false);

      }

      private System.Windows.Forms.TabControl tabControlPages;
      private System.Windows.Forms.TabPage tabPageInfo;
      private System.Windows.Forms.TabPage tabPageLogin;
      private System.Windows.Forms.PictureBox pictureBoxLogo;
      private System.Windows.Forms.TextBox textBoxExplainingText;
      private System.Windows.Forms.TabPage tabPageTerminal;
      private System.Windows.Forms.TabPage tabPageTransacoes;
      private System.Windows.Forms.TabPage tabPageAdmin;
      private System.Windows.Forms.GroupBox groupBoxLinks;
      private System.Windows.Forms.LinkLabel linkLabelSandboxControlPay;
      private System.Windows.Forms.LinkLabel linkLabelDocs;
   }
}

