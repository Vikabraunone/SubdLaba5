using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ClinicDatabaseImplement.Implements
{
    public class MainLogic : IMainLogic
    {
        private readonly ClinicDatabase source;

        public MainLogic()
        {
            source = ClinicDatabase.GetInstance();
        }

        public List<MainViewModel> Read()
        {
            var list = new List<MainViewModel>();
            try
            {
                using (var command = new NpgsqlCommand(
                    $"select field_medicine.name, string_agg(distinct specialist.lastname || ' ' || " +
                    $"specialist.firstname || ' ' || specialist.middlename, ',') from field_medicine " +
                    $"join service on service.field_id = field_medicine.id " +
                    $"join specialist_service on specialist_service.service_id = service.id " +
                    $"join specialist on specialist_service.specialist_id = specialist.id " +
                    $"group by field_medicine.name",
                    source.npgsqlConnection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        list.Add(new MainViewModel
                        {
                            FieldName = reader.GetString(0),
                            FIO = reader.GetString(1)
                        });
                    reader.Close();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}