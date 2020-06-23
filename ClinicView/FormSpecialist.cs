using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormSpecialist : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly ISpecialistLogic logic;

        private int? id;

        public FormSpecialist(ISpecialistLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormSpecialist_Load(object sender, EventArgs e)
        {
            try
            {
                if (id.HasValue)
                {
                    var view = logic.Read(new SpecialistBindingModel { Id = id.Value, ClinicId = Program.ClinicId })?[0];
                    if (view != null)
                    {
                        textBoxLastName.Text = view.Lastname;
                        textBoxFirstName.Text = view.Firstname;
                        textBoxMiddleName.Text = view.Middlename;
                        textBoxExperienceWork.Text = view.ExperienceWork.ToString();
                        textBoxQualification.Text = view.Qualification;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLastName.Text)
                || string.IsNullOrEmpty(textBoxFirstName.Text)
                || string.IsNullOrEmpty(textBoxMiddleName.Text)
                || string.IsNullOrEmpty(textBoxExperienceWork.Text))
            {
                MessageBox.Show("Поля ФИО и опыт работы должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxExperienceWork.Text, out int ew))
            {
                MessageBox.Show("Неккоректно введен опыт работы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id.HasValue)
                logic.Update(new SpecialistBindingModel
                {
                    Id = id.Value,
                    Lastname = textBoxLastName.Text,
                    Firstname = textBoxFirstName.Text,
                    Middlename = textBoxMiddleName.Text,
                    ExperienceWork = ew,
                    Qualification = textBoxQualification.Text
                });
            else
                logic.Create(new SpecialistBindingModel
                {
                    Lastname = textBoxLastName.Text,
                    Firstname = textBoxFirstName.Text,
                    Middlename = textBoxMiddleName.Text,
                    ExperienceWork = ew,
                    Qualification = textBoxQualification.Text
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
