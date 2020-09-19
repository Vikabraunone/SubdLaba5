using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Enums;
using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormServices : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IServiceLogic logic;

        public FormServices(IServiceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormServices_Load(object sender, EventArgs e)
        {
            GetPage(Page.Current);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateService>();
            if (form.ShowDialog() == DialogResult.OK)
                GetPage(Page.Current);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormUpdateService>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                    GetPage(Page.Current);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить услугу", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new ServiceBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    GetPage(Page.Current);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            GetPage(Page.Current);
        }

        private void buttonBackward_Click(object sender, EventArgs e)
        {
            GetPage(Page.Last);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            GetPage(Page.Next);
        }

        private void GetPage(Page page)
        {
            try
            {
                var list = logic.Read(page);
                if (list.Count != 0)
                {
                    dataGridView.DataSource = list;
                    int totalRowHeight = dataGridView.ColumnHeadersHeight;
                    foreach (DataGridViewRow row in dataGridView.Rows)
                        totalRowHeight += row.Height;
                    dataGridView.Height = totalRowHeight;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}