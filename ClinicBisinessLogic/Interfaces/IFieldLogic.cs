using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface IFieldLogic
    {
        void Update(FieldBindingModel model);

        void Create(FieldBindingModel model);

        void Delete(FieldBindingModel model);

        List<FieldViewModel> Read(FieldBindingModel model);
    }
}
