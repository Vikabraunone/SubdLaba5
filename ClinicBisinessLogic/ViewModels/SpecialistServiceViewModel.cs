using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class SpecialistServiceViewModel
    {
        public int ServiceId { get; set; }

        [DisplayName("Id специалиста")]
        public int SpecialistId { get; set; }

        [DisplayName("Название услуги")]
        public string ServiceName { get; set; }

        [DisplayName("Фамилия")]
        public string Lastname { get; set; }

        [DisplayName("Имя")]
        public string Firstname { get; set; }

        [DisplayName("Отчество")]
        public string Middlename { get; set; }
    }
}
