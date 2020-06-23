using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormChooseClinic : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IClinicLogic logic;

        public FormChooseClinic(IClinicLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormChooseClinic_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<ClinicViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Id";
                comboBox.DataSource = list;
                comboBox.SelectedItem = null;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите клинику", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.ClinicId = Convert.ToInt32(comboBox.SelectedValue);
            var form = Container.Resolve<FormMain>();
            form.ShowDialog();
        }

        private void редакторКлиникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClinics>();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }
    }
}