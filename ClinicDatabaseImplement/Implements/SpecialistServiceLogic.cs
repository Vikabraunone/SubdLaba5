using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using ClinicDatabaseImplement.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClinicDatabaseImplement.Implements
{
    public class SpecialistServiceLogic : ISpecialistServiceLogic
    {
        private readonly ClinicDatabase source;

        public static string connStr;

        public SpecialistServiceLogic()
        {
            source = ClinicDatabase.GetInstance();
            connStr = source.GetConnectionString();
        }

        public void Create(SpecialistServiceBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM specialist_service WHERE specialist_id=@specialistId AND service_id=@serviceId", conn))
                    {
                        command.Parameters.AddWithValue("specialistId", model.SpecialistId);
                        command.Parameters.AddWithValue("serviceId", model.ServiceId);
                        if (command.ExecuteNonQuery() > 0)
                            throw new Exception("Этот специалист уже оказывает такую услугу");
                    }
                }
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO specialist_service (specialist_id, service_id) VALUES (@specialistId, @serviceId)", conn))
                    {
                        command.Parameters.AddWithValue("specialistId", model.SpecialistId);
                        command.Parameters.AddWithValue("serviceId", model.ServiceId);
                        command.ExecuteNonQuery();
                    }
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
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM specialist_service WHERE specialist_id=@specialistId AND service_id=@serviceId", conn))
                    {
                        command.Parameters.AddWithValue("specialistId", model.SpecialistId);
                        command.Parameters.AddWithValue("serviceId", model.ServiceId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SpecialistServiceViewModel> Read(SpecialistServiceBindingModel model)
        {
            List<SpecialistServiceViewModel> result = new List<SpecialistServiceViewModel>();

            // считываем id областей, которые привязаны к данной клинике
            var clinicField = new List<ClinicField>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($"select * from clinic_field WHERE clinic_id = {model.ClinicId}", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        clinicField.Add(new ClinicField
                        {
                            FieldId = reader.GetInt32(1)
                        });
                }
            }

            // считываем все услуги
            var services = new List<Service>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select * from service", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        services.Add(new Service
                        {
                            Id = reader.GetInt32(0),
                            FieldId = reader.GetInt32(1),
                            Name = reader.GetString(2),
                            Price = reader.GetInt32(3)
                        });
                }
            }

            // считываем таблицу соответствия специалиста к услугам
            var specialistService = new List<SpecialistService>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select * from specialist_service", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        specialistService.Add(new SpecialistService
                        {
                            SpecialistId = reader.GetInt32(0),
                            ServiceId = reader.GetInt32(1)
                        });
                }
            }

            // считываем всех специалистов
            var specialists = new List<Specialist>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM specialist", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        specialists.Add(new Specialist
                        {
                            Id = reader.GetInt32(0),
                            Lastname = reader.GetString(1),
                            Firstname = reader.GetString(2),
                            Middlename = reader.GetString(3),
                        });
                }
            }

            // выбираем услуги из областей данной клиники
            var joinFieldOnService = (from cf in clinicField
                                      join s in services
                                      on cf.FieldId equals s.FieldId
                                      select new
                                      {
                                          ServiceId = s.Id,
                                          ServiceName = s.Name
                                      })
                                      .Distinct();

            // соединяем id специалистов и услуги
            var joinServiceOnSpecialistService = from fs in joinFieldOnService
                                                 join ss in specialistService
                                                 on fs.ServiceId equals ss.ServiceId
                                                 select new
                                                 {
                                                     ServiceId = ss.ServiceId,
                                                     SpecialistId = ss.SpecialistId,
                                                     ServiceName = fs.ServiceName
                                                 };

            // соответствие специалиста к оказываемой им услуге
            result = ((from sss in joinServiceOnSpecialistService
                       join s in specialists
                       on sss.SpecialistId equals s.Id
                       select new
                       {
                           ServiceId = sss.ServiceId,
                           SpecialistId = sss.SpecialistId,
                           ServiceName = sss.ServiceName,
                           Lastname = s.Lastname,
                           Firstname = s.Firstname,
                           Middlename = s.Middlename
                       })
                       .Distinct())
                       .Select(x => new SpecialistServiceViewModel
                       {
                           ServiceId = x.ServiceId,
                           SpecialistId = x.SpecialistId,
                           ServiceName = x.ServiceName,
                           Lastname = x.Lastname,
                           Firstname = x.Firstname,
                           Middlename = x.Middlename
                       })
                       .ToList();
            return result;
        }
    }
}
