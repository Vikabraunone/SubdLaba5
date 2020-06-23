using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface ISpecialistServiceLogic
    {
        List<SpecialistServiceViewModel> Read(SpecialistServiceBindingModel model);

        void Create(SpecialistServiceBindingModel model);

        void Delete(SpecialistServiceBindingModel model);
    }
}
