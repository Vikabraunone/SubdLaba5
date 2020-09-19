using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormContact : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IContactLogic logic;

        public FormContact(IContactLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTelephone.Text))
            {
                MessageBox.Show("Впишите номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!long.TryParse(textBoxTelephone.Text, out long telephone))
            {
                MessageBox.Show("Неправильный номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logic.Create(new ContactBindingModel { Telephone = telephone });
            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}