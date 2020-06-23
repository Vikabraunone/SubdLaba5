using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormSpecialistService : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ISpecialistLogic specialistLogic;

        private readonly IServiceLogic serviceLogic;

        private readonly ISpecialistServiceLogic logic;

        public FormSpecialistService(ISpecialistLogic specialistLogic, IServiceLogic serviceLogic,
            ISpecialistServiceLogic logic)
        {
            InitializeComponent();
            this.specialistLogic = specialistLogic;
            this.serviceLogic = serviceLogic;
            this.logic = logic;
        }

        private void FormSpecialistService_Load(object sender, EventArgs e)
        {
            List<ServiceViewModel> services = serviceLogic.Read(new ServiceBindingModel { ClinicId = Program.ClinicId });
            if (services != null)
            {
                comboBoxService.DisplayMember = "ServiceName";
                comboBoxService.ValueMember = "Id";
                comboBoxService.DataSource = services;
                comboBoxService.SelectedItem = null;
            }

            List<SpecialistViewModel> specialists = specialistLogic.Read(new SpecialistBindingModel { ClinicId = Program.ClinicId });
            if (specialists != null)
            {
                comboBoxSpecialist.DisplayMember = "Id";
                comboBoxSpecialist.ValueMember = "Id";
                comboBoxSpecialist.DataSource = specialists;
                comboBoxSpecialist.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxService.SelectedValue == null)
            {
                MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSpecialist.SelectedValue == null)
            {
                MessageBox.Show("Выберите специалиста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            logic.Create(new SpecialistServiceBindingModel
            {
                ServiceId = Convert.ToInt32(comboBoxService.SelectedValue),
                SpecialistId = Convert.ToInt32(comboBoxSpecialist.SelectedValue)
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
