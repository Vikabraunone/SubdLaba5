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

        private readonly int limit = 5;

        private int offset = 0;

        public FormSpecialistServices(ISpecialistServiceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormSpecialistServices_Load(object sender, EventArgs e)
        {
            GetPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSpecialistService>();
            if (form.ShowDialog() == DialogResult.OK)
                GetPage();
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
                        GetPage();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonBackward_Click(object sender, EventArgs e)
        {
            if (offset >= limit)
            {
                offset -= limit;
                GetPage();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            offset += limit;
            GetPage();
        }

        private void GetPage()
        {
            try
            {
                var list = logic.Read(limit, offset);
                if (list.Count != 0)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    int totalRowHeight = dataGridView.ColumnHeadersHeight;
                    foreach (DataGridViewRow row in dataGridView.Rows)
                        totalRowHeight += row.Height;
                    dataGridView.Height = totalRowHeight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
