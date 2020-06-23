namespace ClinicView
{
    partial class FormEnter
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxBD = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelBD = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(70, 223);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(153, 25);
            this.buttonConnect.TabIndex = 21;
            this.buttonConnect.Text = "Подключиться";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(128, 186);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(151, 20);
            this.textBoxPassword.TabIndex = 20;
            // 
            // textBoxBD
            // 
            this.textBoxBD.Location = new System.Drawing.Point(128, 146);
            this.textBoxBD.Name = "textBoxBD";
            this.textBoxBD.Size = new System.Drawing.Size(151, 20);
            this.textBoxBD.TabIndex = 19;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(128, 105);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(151, 20);
            this.textBoxUser.TabIndex = 18;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(128, 63);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(151, 20);
            this.textBoxPort.TabIndex = 17;
            // 
            // textBoxHost
            // 
            this.textBoxHost.Location = new System.Drawing.Point(128, 25);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(151, 20);
            this.textBoxHost.TabIndex = 16;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(23, 189);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 15;
            this.labelPassword.Text = "Пароль:";
            // 
            // labelBD
            // 
            this.labelBD.AutoSize = true;
            this.labelBD.Location = new System.Drawing.Point(23, 149);
            this.labelBD.Name = "labelBD";
            this.labelBD.Size = new System.Drawing.Size(75, 13);
            this.labelBD.TabIndex = 14;
            this.labelBD.Text = "База данных:";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(23, 108);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(83, 13);
            this.labelUser.TabIndex = 13;
            this.labelUser.Text = "Пользователь:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(23, 66);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(35, 13);
            this.labelPort.TabIndex = 12;
            this.labelPort.Text = "Порт:";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(23, 27);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(34, 13);
            this.labelHost.TabIndex = 11;
            this.labelHost.Text = "Хост:";
            // 
            // FormEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 269);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxBD);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxHost);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelBD);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelHost);
            this.Name = "FormEnter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxBD;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelBD;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelHost;
    }
}

