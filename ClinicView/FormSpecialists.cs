using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Enums;
using ClinicBisinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormSpecialists : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ISpecialistLogic logic;

        public FormSpecialists(ISpecialistLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormSpecialists_Load(object sender, EventArgs e)
        {
            GetPage(Page.Current);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSpecialist>();
            if (form.ShowDialog() == DialogResult.OK)
                GetPage(Page.Current);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSpecialist>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                    GetPage(Page.Current);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new SpecialistBindingModel { Id = id });
                        GetPage(Page.Current);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            GetPage(Page.Current);
        }

        private void FormSpecialists_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
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
                    dataGridView.Columns[1].Width = 150;
                    dataGridView.Columns[2].Width = 150;
                    dataGridView.Columns[3].Width = 150;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[6].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
