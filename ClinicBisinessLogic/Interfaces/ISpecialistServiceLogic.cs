using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Enums;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface ISpecialistServiceLogic
    {
        List<SpecialistServiceViewModel> Read(Page page);

        void Create(SpecialistServiceBindingModel model);

        void Delete(SpecialistServiceBindingModel model);
    }
}
