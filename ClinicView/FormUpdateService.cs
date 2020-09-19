using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormUpdateService : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IServiceLogic logic;

        private int id;

        public FormUpdateService(IServiceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormService_Load(object sender, EventArgs e)
        {
            try
            {
                var view = logic.Read(new ServiceBindingModel { Id = id });
                if (view != null)
                {
                    textBoxName.Text = view.ServiceName;
                    textBoxPrice.Text = view.Price.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxPrice.Text, out int price))
            {
                MessageBox.Show("Неккоректно введена цена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logic.Update(new ServiceBindingModel
            {
                Id = id,
                ServiceName = textBoxName.Text,
                Price = price
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
