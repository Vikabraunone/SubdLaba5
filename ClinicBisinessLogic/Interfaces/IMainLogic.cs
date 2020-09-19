using ClinicBisinessLogic.ViewModels;
using System.Collections.Generic;

namespace ClinicBisinessLogic.Interfaces
{
    public interface IMainLogic
    {
        List<MainViewModel> Read();
    }
}
