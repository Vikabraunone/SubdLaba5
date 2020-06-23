using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class SpecialistViewModel
    {
        [DisplayName("Id специалиста")]
        public int? Id { get; set; }

        [DisplayName("Фамилия")]
        public string Lastname { get; set; }

        [DisplayName("Имя")]
        public string Firstname { get; set; }

        [DisplayName("Отчество")]
        public string Middlename { get; set; }

        [DisplayName("Опыт работы")]
        public int ExperienceWork { get; set; }

        [DisplayName("Квалификация")]
        public string Qualification { get; set; }

        [DisplayName("Область медицины")]
        public string FieldMedicine { get; set; }
    }
}
