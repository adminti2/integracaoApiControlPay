
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
         this.checkBoxHasKey = new System.Windows.Forms.CheckBox();
         this.panelDoesntHaveKey = new System.Windows.Forms.Panel();
         this.buttonLogin = new System.Windows.Forms.Button();
         this.textBoxLoginPasswordInput = new System.Windows.Forms.TextBox();
         this.labelPassword = new System.Windows.Forms.Label();
         this.textBoxCpfCnpjInput = new System.Windows.Forms.TextBox();
         this.labelCpfCnpj = new System.Windows.Forms.Label();
         this.textBoxInfoLogin = new System.Windows.Forms.TextBox();
         this.textBoxTitleLogin = new System.Windows.Forms.TextBox();
         this.panelHasKey = new System.Windows.Forms.Panel();
         this.buttonAddKey = new System.Windows.Forms.Button();
         this.textBoxKeyInput = new System.Windows.Forms.TextBox();
         this.labelKeyInput = new System.Windows.Forms.Label();
         this.textBoxPersonIdInput = new System.Windows.Forms.TextBox();
         this.labelPersonIdInput = new System.Windows.Forms.Label();
         this.tabPageTerminal = new System.Windows.Forms.TabPage();
         this.tabPageTransacoes = new System.Windows.Forms.TabPage();
         this.tabPageAdmin = new System.Windows.Forms.TabPage();
         this.textBoxPersonIdValue = new System.Windows.Forms.TextBox();
         this.labelPersonIdValue = new System.Windows.Forms.Label();
         this.labelKeyValue = new System.Windows.Forms.Label();
         this.textBoxKeyValue = new System.Windows.Forms.TextBox();
         this.tabControlPages.SuspendLayout();
         this.tabPageInfo.SuspendLayout();
         this.groupBoxLinks.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
         this.tabPageLogin.SuspendLayout();
         this.panelDoesntHaveKey.SuspendLayout();
         this.panelHasKey.SuspendLayout();
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
         this.tabPageLogin.Controls.Add(this.labelKeyValue);
         this.tabPageLogin.Controls.Add(this.textBoxKeyValue);
         this.tabPageLogin.Controls.Add(this.labelPersonIdValue);
         this.tabPageLogin.Controls.Add(this.textBoxPersonIdValue);
         this.tabPageLogin.Controls.Add(this.checkBoxHasKey);
         this.tabPageLogin.Controls.Add(this.panelDoesntHaveKey);
         this.tabPageLogin.Controls.Add(this.textBoxInfoLogin);
         this.tabPageLogin.Controls.Add(this.textBoxTitleLogin);
         this.tabPageLogin.Controls.Add(this.panelHasKey);
         this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
         this.tabPageLogin.Name = "tabPageLogin";
         this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageLogin.Size = new System.Drawing.Size(808, 490);
         this.tabPageLogin.TabIndex = 1;
         this.tabPageLogin.Text = "Login";
         // 
         // checkBoxHasKey
         // 
         this.checkBoxHasKey.AutoSize = true;
         this.checkBoxHasKey.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.checkBoxHasKey.ForeColor = System.Drawing.Color.White;
         this.checkBoxHasKey.Location = new System.Drawing.Point(138, 220);
         this.checkBoxHasKey.Name = "checkBoxHasKey";
         this.checkBoxHasKey.Size = new System.Drawing.Size(277, 29);
         this.checkBoxHasKey.TabIndex = 4;
         this.checkBoxHasKey.Text = "Possui chave de integração?";
         this.checkBoxHasKey.UseVisualStyleBackColor = true;
         this.checkBoxHasKey.CheckedChanged += new System.EventHandler(this.checkBoxHasKey_CheckedChanged);
         // 
         // panelDoesntHaveKey
         // 
         this.panelDoesntHaveKey.Controls.Add(this.buttonLogin);
         this.panelDoesntHaveKey.Controls.Add(this.textBoxLoginPasswordInput);
         this.panelDoesntHaveKey.Controls.Add(this.labelPassword);
         this.panelDoesntHaveKey.Controls.Add(this.textBoxCpfCnpjInput);
         this.panelDoesntHaveKey.Controls.Add(this.labelCpfCnpj);
         this.panelDoesntHaveKey.Location = new System.Drawing.Point(149, 277);
         this.panelDoesntHaveKey.Name = "panelDoesntHaveKey";
         this.panelDoesntHaveKey.Size = new System.Drawing.Size(222, 152);
         this.panelDoesntHaveKey.TabIndex = 3;
         // 
         // buttonLogin
         // 
         this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(48)))));
         this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonLogin.ForeColor = System.Drawing.Color.White;
         this.buttonLogin.Location = new System.Drawing.Point(75, 107);
         this.buttonLogin.Name = "buttonLogin";
         this.buttonLogin.Size = new System.Drawing.Size(75, 27);
         this.buttonLogin.TabIndex = 4;
         this.buttonLogin.Text = "Login";
         this.buttonLogin.UseVisualStyleBackColor = false;
         // 
         // textBoxLoginPasswordInput
         // 
         this.textBoxLoginPasswordInput.Location = new System.Drawing.Point(87, 59);
         this.textBoxLoginPasswordInput.Name = "textBoxLoginPasswordInput";
         this.textBoxLoginPasswordInput.Size = new System.Drawing.Size(110, 22);
         this.textBoxLoginPasswordInput.TabIndex = 3;
         // 
         // labelPassword
         // 
         this.labelPassword.AutoSize = true;
         this.labelPassword.ForeColor = System.Drawing.Color.White;
         this.labelPassword.Location = new System.Drawing.Point(40, 62);
         this.labelPassword.Name = "labelPassword";
         this.labelPassword.Size = new System.Drawing.Size(42, 13);
         this.labelPassword.TabIndex = 2;
         this.labelPassword.Text = "Senha:";
         // 
         // textBoxCpfCnpjInput
         // 
         this.textBoxCpfCnpjInput.Location = new System.Drawing.Point(87, 23);
         this.textBoxCpfCnpjInput.Name = "textBoxCpfCnpjInput";
         this.textBoxCpfCnpjInput.Size = new System.Drawing.Size(110, 22);
         this.textBoxCpfCnpjInput.TabIndex = 1;
         // 
         // labelCpfCnpj
         // 
         this.labelCpfCnpj.AutoSize = true;
         this.labelCpfCnpj.ForeColor = System.Drawing.Color.White;
         this.labelCpfCnpj.Location = new System.Drawing.Point(19, 26);
         this.labelCpfCnpj.Name = "labelCpfCnpj";
         this.labelCpfCnpj.Size = new System.Drawing.Size(57, 13);
         this.labelCpfCnpj.TabIndex = 0;
         this.labelCpfCnpj.Text = "CPF/CNPJ:";
         // 
         // textBoxInfoLogin
         // 
         this.textBoxInfoLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.textBoxInfoLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBoxInfoLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBoxInfoLogin.ForeColor = System.Drawing.Color.White;
         this.textBoxInfoLogin.Location = new System.Drawing.Point(12, 69);
         this.textBoxInfoLogin.Multiline = true;
         this.textBoxInfoLogin.Name = "textBoxInfoLogin";
         this.textBoxInfoLogin.ReadOnly = true;
         this.textBoxInfoLogin.Size = new System.Drawing.Size(403, 127);
         this.textBoxInfoLogin.TabIndex = 2;
         this.textBoxInfoLogin.Text = resources.GetString("textBoxInfoLogin.Text");
         // 
         // textBoxTitleLogin
         // 
         this.textBoxTitleLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.textBoxTitleLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBoxTitleLogin.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBoxTitleLogin.ForeColor = System.Drawing.Color.White;
         this.textBoxTitleLogin.Location = new System.Drawing.Point(6, 6);
         this.textBoxTitleLogin.Multiline = true;
         this.textBoxTitleLogin.Name = "textBoxTitleLogin";
         this.textBoxTitleLogin.ReadOnly = true;
         this.textBoxTitleLogin.Size = new System.Drawing.Size(125, 57);
         this.textBoxTitleLogin.TabIndex = 1;
         this.textBoxTitleLogin.Text = "Login";
         // 
         // panelHasKey
         // 
         this.panelHasKey.Controls.Add(this.buttonAddKey);
         this.panelHasKey.Controls.Add(this.textBoxKeyInput);
         this.panelHasKey.Controls.Add(this.labelKeyInput);
         this.panelHasKey.Controls.Add(this.textBoxPersonIdInput);
         this.panelHasKey.Controls.Add(this.labelPersonIdInput);
         this.panelHasKey.Location = new System.Drawing.Point(32, 277);
         this.panelHasKey.Name = "panelHasKey";
         this.panelHasKey.Size = new System.Drawing.Size(466, 152);
         this.panelHasKey.TabIndex = 4;
         // 
         // buttonAddKey
         // 
         this.buttonAddKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(48)))));
         this.buttonAddKey.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.buttonAddKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonAddKey.ForeColor = System.Drawing.Color.White;
         this.buttonAddKey.Location = new System.Drawing.Point(169, 107);
         this.buttonAddKey.Name = "buttonAddKey";
         this.buttonAddKey.Size = new System.Drawing.Size(122, 27);
         this.buttonAddKey.TabIndex = 5;
         this.buttonAddKey.Text = "Adicionar chave";
         this.buttonAddKey.UseVisualStyleBackColor = false;
         // 
         // textBoxKeyInput
         // 
         this.textBoxKeyInput.Location = new System.Drawing.Point(135, 59);
         this.textBoxKeyInput.Name = "textBoxKeyInput";
         this.textBoxKeyInput.Size = new System.Drawing.Size(307, 22);
         this.textBoxKeyInput.TabIndex = 3;
         // 
         // labelKeyInput
         // 
         this.labelKeyInput.AutoSize = true;
         this.labelKeyInput.ForeColor = System.Drawing.Color.White;
         this.labelKeyInput.Location = new System.Drawing.Point(20, 62);
         this.labelKeyInput.Name = "labelKeyInput";
         this.labelKeyInput.Size = new System.Drawing.Size(115, 13);
         this.labelKeyInput.TabIndex = 2;
         this.labelKeyInput.Text = "Chave de integração:";
         // 
         // textBoxPersonIdInput
         // 
         this.textBoxPersonIdInput.Location = new System.Drawing.Point(135, 23);
         this.textBoxPersonIdInput.Name = "textBoxPersonIdInput";
         this.textBoxPersonIdInput.Size = new System.Drawing.Size(110, 22);
         this.textBoxPersonIdInput.TabIndex = 1;
         // 
         // labelPersonIdInput
         // 
         this.labelPersonIdInput.AutoSize = true;
         this.labelPersonIdInput.ForeColor = System.Drawing.Color.White;
         this.labelPersonIdInput.Location = new System.Drawing.Point(55, 26);
         this.labelPersonIdInput.Name = "labelPersonIdInput";
         this.labelPersonIdInput.Size = new System.Drawing.Size(75, 13);
         this.labelPersonIdInput.TabIndex = 0;
         this.labelPersonIdInput.Text = "ID da Pessoa:";
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
         // 
         // textBoxPersonIdValue
         // 
         this.textBoxPersonIdValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.textBoxPersonIdValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBoxPersonIdValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBoxPersonIdValue.ForeColor = System.Drawing.Color.White;
         this.textBoxPersonIdValue.Location = new System.Drawing.Point(598, 104);
         this.textBoxPersonIdValue.Name = "textBoxPersonIdValue";
         this.textBoxPersonIdValue.ReadOnly = true;
         this.textBoxPersonIdValue.Size = new System.Drawing.Size(134, 18);
         this.textBoxPersonIdValue.TabIndex = 5;
         this.textBoxPersonIdValue.Text = "...";
         this.textBoxPersonIdValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // labelPersonIdValue
         // 
         this.labelPersonIdValue.AutoSize = true;
         this.labelPersonIdValue.ForeColor = System.Drawing.Color.White;
         this.labelPersonIdValue.Location = new System.Drawing.Point(595, 88);
         this.labelPersonIdValue.Name = "labelPersonIdValue";
         this.labelPersonIdValue.Size = new System.Drawing.Size(137, 13);
         this.labelPersonIdValue.TabIndex = 5;
         this.labelPersonIdValue.Text = "ID de Pessoa a ser usado:";
         // 
         // labelKeyValue
         // 
         this.labelKeyValue.AutoSize = true;
         this.labelKeyValue.ForeColor = System.Drawing.Color.White;
         this.labelKeyValue.Location = new System.Drawing.Point(574, 145);
         this.labelKeyValue.Name = "labelKeyValue";
         this.labelKeyValue.Size = new System.Drawing.Size(176, 13);
         this.labelKeyValue.TabIndex = 6;
         this.labelKeyValue.Text = "Chave de integração a ser usada:";
         // 
         // textBoxKeyValue
         // 
         this.textBoxKeyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(255)))));
         this.textBoxKeyValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.textBoxKeyValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBoxKeyValue.ForeColor = System.Drawing.Color.White;
         this.textBoxKeyValue.Location = new System.Drawing.Point(577, 161);
         this.textBoxKeyValue.Multiline = true;
         this.textBoxKeyValue.Name = "textBoxKeyValue";
         this.textBoxKeyValue.ReadOnly = true;
         this.textBoxKeyValue.Size = new System.Drawing.Size(173, 161);
         this.textBoxKeyValue.TabIndex = 7;
         this.textBoxKeyValue.Text = "...";
         this.textBoxKeyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // PrincipalScreen
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(809, 511);
         this.Controls.Add(this.tabControlPages);
         this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
         this.tabPageLogin.ResumeLayout(false);
         this.tabPageLogin.PerformLayout();
         this.panelDoesntHaveKey.ResumeLayout(false);
         this.panelDoesntHaveKey.PerformLayout();
         this.panelHasKey.ResumeLayout(false);
         this.panelHasKey.PerformLayout();
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
      private System.Windows.Forms.TextBox textBoxInfoLogin;
      private System.Windows.Forms.TextBox textBoxTitleLogin;
      private System.Windows.Forms.CheckBox checkBoxHasKey;
      private System.Windows.Forms.Panel panelDoesntHaveKey;
      private System.Windows.Forms.TextBox textBoxLoginPasswordInput;
      private System.Windows.Forms.Label labelPassword;
      private System.Windows.Forms.TextBox textBoxCpfCnpjInput;
      private System.Windows.Forms.Label labelCpfCnpj;
      private System.Windows.Forms.Panel panelHasKey;
      private System.Windows.Forms.TextBox textBoxKeyInput;
      private System.Windows.Forms.Label labelKeyInput;
      private System.Windows.Forms.TextBox textBoxPersonIdInput;
      private System.Windows.Forms.Label labelPersonIdInput;
      private System.Windows.Forms.Button buttonLogin;
      private System.Windows.Forms.Button buttonAddKey;
      private System.Windows.Forms.Label labelPersonIdValue;
      private System.Windows.Forms.TextBox textBoxPersonIdValue;
      private System.Windows.Forms.Label labelKeyValue;
      private System.Windows.Forms.TextBox textBoxKeyValue;
   }
}

