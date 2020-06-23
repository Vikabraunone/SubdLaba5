using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface IClinicLogic
    {
        List<ClinicViewModel> Read(ClinicBindingModel model);

        List<ClinicBindingModel> ReadAllId();

        void Update(ClinicBindingModel model);

        void Create(ClinicBindingModel model);

        void Delete(ClinicBindingModel model);
    }
}
