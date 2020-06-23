using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface IContactLogic
    {
        List<ContactViewModel> Read(ContactBindingModel model);

        List<ContactBindingModel> ReadAllId();

        void Create(ContactBindingModel model);

        void Delete(ContactBindingModel model);
    }
}
