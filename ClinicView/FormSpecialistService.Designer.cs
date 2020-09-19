namespace ClinicView
{
    partial class FormSpecialistService
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
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.comboBoxSpecialist = new System.Windows.Forms.ComboBox();
            this.labelService = new System.Windows.Forms.Label();
            this.labelSpecialist = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(103, 29);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(287, 21);
            this.comboBoxService.TabIndex = 23;
            // 
            // comboBoxSpecialist
            // 
            this.comboBoxSpecialist.FormattingEnabled = true;
            this.comboBoxSpecialist.Location = new System.Drawing.Point(103, 69);
            this.comboBoxSpecialist.Name = "comboBoxSpecialist";
            this.comboBoxSpecialist.Size = new System.Drawing.Size(287, 21);
            this.comboBoxSpecialist.TabIndex = 24;
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Location = new System.Drawing.Point(27, 32);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(46, 13);
            this.labelService.TabIndex = 25;
            this.labelService.Text = "Услуга:";
            // 
            // labelSpecialist
            // 
            this.labelSpecialist.AutoSize = true;
            this.labelSpecialist.Location = new System.Drawing.Point(27, 72);
            this.labelSpecialist.Name = "labelSpecialist";
            this.labelSpecialist.Size = new System.Drawing.Size(70, 13);
            this.labelSpecialist.TabIndex = 26;
            this.labelSpecialist.Text = "Специалист:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(242, 113);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 33);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(124, 113);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 33);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormSpecialistService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 158);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelSpecialist);
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.comboBoxSpecialist);
            this.Controls.Add(this.comboBoxService);
            this.Name = "FormSpecialistService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление услуги к специалисту";
            this.Load += new System.EventHandler(this.FormSpecialistService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.ComboBox comboBoxSpecialist;
        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelSpecialist;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}