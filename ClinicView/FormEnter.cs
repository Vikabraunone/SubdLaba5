using System;
using System.Windows.Forms;
using Unity;

namespace ClinicView
{
    public partial class FormEnter : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormEnter()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Program.ClinicDatabase.ConnectToDatabase(textBoxHost.Text, textBoxPort.Text, textBoxUser.Text,
                    textBoxPassword.Text, textBoxBD.Text);
                this.Visible = false;
                var form = Container.Resolve<FormChooseClinic>();
                form.ShowDialog();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Соединение с БД не удалось установить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
