using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class MainViewModel
    {
        [DisplayName("Область медицины")]
        public string FieldName { get; set; }

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
    }
}
