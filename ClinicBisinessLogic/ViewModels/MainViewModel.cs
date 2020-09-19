using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class MainViewModel
    {
        [DisplayName("Область медицины")]
        public string FieldName { get; set; }

        [DisplayName("Фио сотрудников")]
        public string FIO { get; set; }
    }
}
