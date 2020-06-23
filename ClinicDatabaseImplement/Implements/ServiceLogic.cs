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
    public class ServiceLogic : IServiceLogic
    {
        private readonly ClinicDatabase source;

        public static string connStr;

        public ServiceLogic()
        {
            source = ClinicDatabase.GetInstance();
            connStr = source.GetConnectionString();
        }

        public void Create(ServiceBindingModel model)
        {
            try
            {
                var list = ReadAllId();
                int maxId = 0;
                if (list.Count > 0)
                    maxId = list.Max(x => x.Id.Value) + 1;
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO service (id, field_id, name, price) VALUES (@id, @field_id, @name, @price)", conn))
                    {
                        command.Parameters.AddWithValue("id", maxId);
                        command.Parameters.AddWithValue("field_id", model.FieldId);
                        command.Parameters.AddWithValue("name", model.ServiceName);
                        command.Parameters.AddWithValue("price", model.Price);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(ServiceBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM service WHERE id = @i", conn))
                    {
                        command.Parameters.AddWithValue("i", model.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ServiceBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("UPDATE service SET name=@name, price=@price WHERE id = @id", conn))
                    {
                        command.Parameters.AddWithValue("name", model.ServiceName);
                        command.Parameters.AddWithValue("price", model.Price);
                        command.Parameters.AddWithValue("id", model.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ServiceViewModel> Read(ServiceBindingModel model)
        {
            List<ServiceViewModel> result = new List<ServiceViewModel>();
            if (model.Id == null)
            {
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

                // считываем все области
                var fields = new List<Field>();
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("select * from field_medicine", conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                            fields.Add(new Field
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
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

                // соединяем id областей данной клиники c наименованием областей 
                var joinFieldOnClinic = ((from cf in clinicField
                                          join f in fields
                                          on cf.FieldId equals f.Id
                                          select new
                                          {
                                              FieldId = f.Id,
                                              Name = f.Name
                                          }).Distinct());

                // соединяем области и услуги в них
                result = ((from fc in joinFieldOnClinic
                           join s in services
                           on fc.FieldId equals s.FieldId
                           select new
                           {
                               Id = s.Id,
                               FieldName = fc.Name,
                               ServiceName = s.Name,
                               Price = s.Price
                           }).Distinct())
                           .Select(x => new ServiceViewModel
                           {
                               Id = x.Id,
                               FieldName = x.FieldName,
                               ServiceName = x.ServiceName,
                               Price = x.Price
                           })
                           .ToList();
            }
            else
            {
                //  считываем конкретную услугу
                result = new List<ServiceViewModel>();
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand($"SELECT * FROM service WHERE id={model.Id}", conn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        result.Add(new ServiceViewModel
                        {
                            Id = reader.GetInt32(0),
                            ServiceName = reader.GetString(2),
                            Price = reader.GetInt32(3)
                        });
                    }
                }
            }
            return result;
        }

        public List<ServiceBindingModel> ReadAllId()
        {
            List<ServiceBindingModel> result = new List<ServiceBindingModel>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select * from service", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        result.Add(new ServiceBindingModel
                        {
                            Id = reader.GetInt32(0)
                        });
                }
            }
            return result;
        }
    }
}