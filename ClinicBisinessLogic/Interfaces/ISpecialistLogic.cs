using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Enums;
using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface ISpecialistLogic
    {
        void Update(SpecialistBindingModel model);

        void Create(SpecialistBindingModel model);

        void Delete(SpecialistBindingModel model);

        SpecialistViewModel Read(SpecialistBindingModel model);

        List<SpecialistViewModel> Read(int? limit, int? offset);
    }
}
