using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class ClinicViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название клиники")]
        public string Name { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; }
    }
}
