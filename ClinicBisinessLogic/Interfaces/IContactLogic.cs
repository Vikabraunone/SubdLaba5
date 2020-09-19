using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface IContactLogic
    {
        List<ContactViewModel> Read();

        void Create(ContactBindingModel model);

        void Delete(ContactBindingModel model);
    }
}
