using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ClinicDatabaseImplement.Implements
{
    public class SpecialistServiceLogic : ISpecialistServiceLogic
    {
        private readonly ClinicDatabase source;

        public SpecialistServiceLogic()
        {
            source = ClinicDatabase.GetInstance();
        }

        public void Create(SpecialistServiceBindingModel model)
        {
            try
            {
                using (var command = new NpgsqlCommand("INSERT INTO specialist_service(specialist_id, service_id)" +
                    "VALUES (@specialistId, @serviceId)", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("specialistId", model.SpecialistId);
                    command.Parameters.AddWithValue("serviceId", model.ServiceId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(SpecialistServiceBindingModel model)
        {
            try
            {
                using (var command = new NpgsqlCommand("DELETE FROM specialist_service WHERE specialist_id=@specialistId AND service_id=@serviceId", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("specialistId", model.SpecialistId);
                    command.Parameters.AddWithValue("serviceId", model.ServiceId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SpecialistServiceViewModel> Read(int? limit, int? offset)
        {
            List<SpecialistServiceViewModel> list = new List<SpecialistServiceViewModel>();
            using (var command = new NpgsqlCommand($"select service.id, specialist.id, service.name, specialist.lastname, " +
                    $"specialist.firstname, specialist.middlename from service " +
                    $"join specialist_service " +
                    $"on specialist_service.service_id = service.id " +
                    $"join specialist " +
                    $"on specialist_service.specialist_id = specialist.id " +
                    $"order by service.name " +
                    $"limit {limit} offset {offset};", source.npgsqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            list.Add(new SpecialistServiceViewModel
                            {
                                ServiceId = reader.GetInt32(0),
                                SpecialistId = reader.GetInt32(1),
                                ServiceName = reader.GetString(2),
                                Lastname = reader.GetString(3),
                                Firstname = reader.GetString(4),
                                Middlename = reader.GetString(5)
                            });
                    }
                }
            }
            return list;
        }
    }
}
