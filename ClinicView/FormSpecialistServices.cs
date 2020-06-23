using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormSpecialistServices : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ISpecialistServiceLogic logic;

        public FormSpecialistServices(ISpecialistServiceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormSpecialistServices_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(new SpecialistServiceBindingModel { ClinicId = Program.ClinicId });
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Width = 100;
                    dataGridView.Columns[2].Width = 200;
                    dataGridView.Columns[3].Width = 200;
                    dataGridView.Columns[4].Width = 200;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSpecialistService>();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int serviceId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    int specialistId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[1].Value);
                    try
                    {
                        logic.Delete(new SpecialistServiceBindingModel { ServiceId = serviceId, SpecialistId = specialistId });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
