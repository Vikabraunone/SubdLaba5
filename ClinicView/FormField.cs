using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormField : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IFieldLogic logic;

        private int? id;

        public FormField(IFieldLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormField_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new FieldBindingModel { Id = id.Value })?[0];
                    if (view != null)
                        textBoxName.Text = view.Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                    logic.Update(new FieldBindingModel
                    {
                        Id = id.Value,
                        Name = textBoxName.Text
                    });
                else
                    logic.Create(new FieldBindingModel
                    {
                        Name = textBoxName.Text
                    });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
