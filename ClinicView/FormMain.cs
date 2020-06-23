using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IMainLogic mainLogic;

        public FormMain(IMainLogic mainLogic)
        {
            InitializeComponent();
            this.mainLogic = mainLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = mainLogic.Read(Program.ClinicId);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Width = 200;
                    dataGridView.Columns[1].Width = 200;
                    dataGridView.Columns[2].Width = 200;
                    dataGridView.Columns[3].Width = 200;
                    dataGridView.Columns[4].Width = 150;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void областиМедициныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFields>();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void списокУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServices>();
            form.ShowDialog();
        }

        private void услугиИСпециалистыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSpecialistServices>();
            form.ShowDialog();
        }

        private void специалистыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSpecialists>();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormContacts>();
            form.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
