using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Enums;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface IServiceLogic
    {
        void Update(ServiceBindingModel model);

        void Create(ServiceBindingModel model);

        void Delete(ServiceBindingModel model);

        ServiceViewModel Read(ServiceBindingModel model);

        List<ServiceViewModel> Read(Page page);
    }
}
