using ClinicBisinessLogic.Interfaces;
using ClinicDatabaseImplement;
using ClinicDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ClinicView
{
    static class Program
    {
        public static ClinicDatabase ClinicDatabase;
        public static int ClinicId;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            ClinicDatabase = ClinicDatabase.GetInstance();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormEnter>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IFieldLogic, FieldLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServiceLogic, ServiceLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISpecialistLogic, SpecialistLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainLogic, MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISpecialistServiceLogic, SpecialistServiceLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClinicLogic, ClinicLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IContactLogic, ContactLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
