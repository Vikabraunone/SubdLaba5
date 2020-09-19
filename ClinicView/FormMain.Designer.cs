namespace ClinicView
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.областиМедициныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.услугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокУслугToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.услугиИСпециалистыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специалистыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контактыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Size = new System.Drawing.Size(651, 410);
            this.dataGridView.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.областиМедициныToolStripMenuItem,
            this.услугиToolStripMenuItem,
            this.специалистыToolStripMenuItem,
            this.контактыToolStripMenuItem,
            this.обновитьСписокToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(679, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // областиМедициныToolStripMenuItem
            // 
            this.областиМедициныToolStripMenuItem.Name = "областиМедициныToolStripMenuItem";
            this.областиМедициныToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.областиМедициныToolStripMenuItem.Text = "Области медицины";
            this.областиМедициныToolStripMenuItem.Click += new System.EventHandler(this.областиМедициныToolStripMenuItem_Click);
            // 
            // услугиToolStripMenuItem
            // 
            this.услугиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокУслугToolStripMenuItem,
            this.услугиИСпециалистыToolStripMenuItem});
            this.услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
            this.услугиToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.услугиToolStripMenuItem.Text = "Услуги";
            // 
            // списокУслугToolStripMenuItem
            // 
            this.списокУслугToolStripMenuItem.Name = "списокУслугToolStripMenuItem";
            this.списокУслугToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.списокУслугToolStripMenuItem.Text = "Список услуг";
            this.списокУслугToolStripMenuItem.Click += new System.EventHandler(this.списокУслугToolStripMenuItem_Click);
            // 
            // услугиИСпециалистыToolStripMenuItem
            // 
            this.услугиИСпециалистыToolStripMenuItem.Name = "услугиИСпециалистыToolStripMenuItem";
            this.услугиИСпециалистыToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.услугиИСпециалистыToolStripMenuItem.Text = "Услуги и специалисты";
            this.услугиИСпециалистыToolStripMenuItem.Click += new System.EventHandler(this.услугиИСпециалистыToolStripMenuItem_Click);
            // 
            // специалистыToolStripMenuItem
            // 
            this.специалистыToolStripMenuItem.Name = "специалистыToolStripMenuItem";
            this.специалистыToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.специалистыToolStripMenuItem.Text = "Специалисты";
            this.специалистыToolStripMenuItem.Click += new System.EventHandler(this.специалистыToolStripMenuItem_Click);
            // 
            // контактыToolStripMenuItem
            // 
            this.контактыToolStripMenuItem.Name = "контактыToolStripMenuItem";
            this.контактыToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.контактыToolStripMenuItem.Text = "Контакты";
            this.контактыToolStripMenuItem.Click += new System.EventHandler(this.контактыToolStripMenuItem_Click);
            // 
            // обновитьСписокToolStripMenuItem
            // 
            this.обновитьСписокToolStripMenuItem.Name = "обновитьСписокToolStripMenuItem";
            this.обновитьСписокToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.обновитьСписокToolStripMenuItem.Text = "Обновить список";
            this.обновитьСписокToolStripMenuItem.Click += new System.EventHandler(this.обновитьСписокToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Приложение \"Клиника\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem областиМедициныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem услугиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специалистыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокУслугToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem услугиИСпециалистыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контактыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьСписокToolStripMenuItem;
    }
}