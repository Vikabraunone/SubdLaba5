namespace ClinicView
{
    partial class FormSpecialist
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelMiddleName = new System.Windows.Forms.Label();
            this.labelExperienceWork = new System.Windows.Forms.Label();
            this.labelQualification = new System.Windows.Forms.Label();
            this.textBoxMiddleName = new System.Windows.Forms.TextBox();
            this.textBoxExperienceWork = new System.Windows.Forms.TextBox();
            this.textBoxQualification = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(226, 175);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 33);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(136, 175);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(84, 33);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(126, 27);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(204, 20);
            this.textBoxLastName.TabIndex = 9;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(36, 30);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(59, 13);
            this.labelLastName.TabIndex = 8;
            this.labelLastName.Text = "Фамилия:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(126, 53);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(204, 20);
            this.textBoxFirstName.TabIndex = 13;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(36, 56);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(32, 13);
            this.labelFirstName.TabIndex = 12;
            this.labelFirstName.Text = "Имя:";
            // 
            // labelMiddleName
            // 
            this.labelMiddleName.AutoSize = true;
            this.labelMiddleName.Location = new System.Drawing.Point(36, 82);
            this.labelMiddleName.Name = "labelMiddleName";
            this.labelMiddleName.Size = new System.Drawing.Size(57, 13);
            this.labelMiddleName.TabIndex = 14;
            this.labelMiddleName.Text = "Отчество:";
            // 
            // labelExperienceWork
            // 
            this.labelExperienceWork.AutoSize = true;
            this.labelExperienceWork.Location = new System.Drawing.Point(36, 109);
            this.labelExperienceWork.Name = "labelExperienceWork";
            this.labelExperienceWork.Size = new System.Drawing.Size(77, 13);
            this.labelExperienceWork.TabIndex = 15;
            this.labelExperienceWork.Text = "Опыт работы:";
            // 
            // labelQualification
            // 
            this.labelQualification.AutoSize = true;
            this.labelQualification.Location = new System.Drawing.Point(36, 138);
            this.labelQualification.Name = "labelQualification";
            this.labelQualification.Size = new System.Drawing.Size(85, 13);
            this.labelQualification.TabIndex = 16;
            this.labelQualification.Text = "Квалификация:";
            // 
            // textBoxMiddleName
            // 
            this.textBoxMiddleName.Location = new System.Drawing.Point(126, 79);
            this.textBoxMiddleName.Name = "textBoxMiddleName";
            this.textBoxMiddleName.Size = new System.Drawing.Size(204, 20);
            this.textBoxMiddleName.TabIndex = 17;
            // 
            // textBoxExperienceWork
            // 
            this.textBoxExperienceWork.Location = new System.Drawing.Point(126, 106);
            this.textBoxExperienceWork.Name = "textBoxExperienceWork";
            this.textBoxExperienceWork.Size = new System.Drawing.Size(204, 20);
            this.textBoxExperienceWork.TabIndex = 18;
            // 
            // textBoxQualification
            // 
            this.textBoxQualification.Location = new System.Drawing.Point(126, 135);
            this.textBoxQualification.Name = "textBoxQualification";
            this.textBoxQualification.Size = new System.Drawing.Size(204, 20);
            this.textBoxQualification.TabIndex = 19;
            // 
            // FormSpecialist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 231);
            this.Controls.Add(this.textBoxQualification);
            this.Controls.Add(this.textBoxExperienceWork);
            this.Controls.Add(this.textBoxMiddleName);
            this.Controls.Add(this.labelQualification);
            this.Controls.Add(this.labelExperienceWork);
            this.Controls.Add(this.labelMiddleName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.labelLastName);
            this.Name = "FormSpecialist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Специалист";
            this.Load += new System.EventHandler(this.FormSpecialist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelMiddleName;
        private System.Windows.Forms.Label labelExperienceWork;
        private System.Windows.Forms.Label labelQualification;
        private System.Windows.Forms.TextBox textBoxMiddleName;
        private System.Windows.Forms.TextBox textBoxExperienceWork;
        private System.Windows.Forms.TextBox textBoxQualification;
    }
}