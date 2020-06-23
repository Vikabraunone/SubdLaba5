using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class FieldViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название области медицины")]
        public string Name { get; set; }
    }
}
