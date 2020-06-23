using System.ComponentModel;

namespace ClinicBisinessLogic.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [DisplayName("Телефон")]
        public long Telephone { get; set; }
    }
}
