using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class ServiceViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Область медицины")]
        public string FieldName { get; set; }

        [DisplayName("Название")]
        public string ServiceName { get; set; }

        [DisplayName("Цена")]
        public int Price { get; set; }
    }
}
