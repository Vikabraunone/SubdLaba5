using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormCreateService : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IFieldLogic fieldLogic;

        private readonly IServiceLogic serviceLogic;

        public FormCreateService(IFieldLogic fieldLogic, IServiceLogic serviceLogic)
        {
            InitializeComponent();
            this.fieldLogic = fieldLogic;
            this.serviceLogic = serviceLogic;
        }

        private void FormCreateService_Load(object sender, EventArgs e)
        {
            List<FieldViewModel> list = fieldLogic.Read(null);
            if (list != null)
            {
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";
                comboBox.DataSource = list;
                comboBox.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите область медицины", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Впишите название услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxPrice.Text, out int res))
            {
                MessageBox.Show("Неверный формат цены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            serviceLogic.Create(new ServiceBindingModel
            {
                FieldId = Convert.ToInt32(comboBox.SelectedValue),
                ServiceName = textBoxName.Text,
                Price = res
            });
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
