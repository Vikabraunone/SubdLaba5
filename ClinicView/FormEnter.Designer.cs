namespace ClinicView
{
    partial class FormEnter
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxBD = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelBD = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(71, 176);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(153, 25);
            this.buttonConnect.TabIndex = 32;
            this.buttonConnect.Text = "Подключиться";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(129, 139);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(151, 20);
            this.textBoxPassword.TabIndex = 31;
            // 
            // textBoxBD
            // 
            this.textBoxBD.Location = new System.Drawing.Point(129, 99);
            this.textBoxBD.Name = "textBoxBD";
            this.textBoxBD.Size = new System.Drawing.Size(151, 20);
            this.textBoxBD.TabIndex = 30;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(129, 60);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(151, 20);
            this.textBoxPort.TabIndex = 28;
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(129, 22);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(151, 20);
            this.textBoxHost.TabIndex = 27;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(24, 142);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 26;
            this.labelPassword.Text = "Пароль:";
            // 
            // labelBD
            // 
            this.labelBD.AutoSize = true;
            this.labelBD.Location = new System.Drawing.Point(24, 102);
            this.labelBD.Name = "labelBD";
            this.labelBD.Size = new System.Drawing.Size(75, 13);
            this.labelBD.TabIndex = 25;
            this.labelBD.Text = "База данных:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(24, 63);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(35, 13);
            this.labelPort.TabIndex = 23;
            this.labelPort.Text = "Порт:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(24, 24);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(34, 13);
            this.labelHost.TabIndex = 22;
            this.labelHost.Text = "Хост:";
            // 
            // FormEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 214);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxBD);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelBD);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelHost);
            this.Name = "FormEnter";
            this.Text = "Войти";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxBD;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelBD;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelHost;
    }
}