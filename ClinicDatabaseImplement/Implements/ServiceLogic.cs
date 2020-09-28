using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ClinicDatabaseImplement.Implements
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly ClinicDatabase source;

        public ServiceLogic()
        {
            source = ClinicDatabase.GetInstance();
        }

        public void Create(ServiceBindingModel model)
        {
            try
            {
                int? maxId = null;
                using (var command = new NpgsqlCommand("select max(id) from field_medicine", source.npgsqlConnection))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    maxId = reader.GetInt32(0);
                    reader.Close();
                }
                if (!maxId.HasValue)
                    maxId = 400;
                using (var command = new NpgsqlCommand("INSERT INTO service (id, field_id, name, price) VALUES (@id, @field_id, @name, @price)", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("id", maxId + 1);
                    command.Parameters.AddWithValue("field_id", model.FieldId);
                    command.Parameters.AddWithValue("name", model.ServiceName);
                    command.Parameters.AddWithValue("price", model.Price);
                    command.ExecuteNonQuery();
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
                using (var command = new NpgsqlCommand("DELETE FROM service WHERE id = @id", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("id", model.Id);
                    command.ExecuteNonQuery();
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
                using (var command = new NpgsqlCommand("UPDATE service SET name=@name, price=@price WHERE id = @id", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("name", model.ServiceName);
                    command.Parameters.AddWithValue("price", model.Price);
                    command.Parameters.AddWithValue("id", model.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ServiceViewModel Read(ServiceBindingModel model)
        {
            ServiceViewModel service;
            using (var command = new NpgsqlCommand($"SELECT id, name, price FROM service WHERE id={model.Id}", source.npgsqlConnection))
            {
                var reader = command.ExecuteReader();
                reader.Read();
                service = new ServiceViewModel
                {
                    Id = reader.GetInt32(0),
                    ServiceName = reader.GetString(1),
                    Price = reader.GetInt32(2)
                };
                reader.Close();
            }
            return service;
        }

        public List<ServiceViewModel> Read(int? limit, int? offset)
        {
            List<ServiceViewModel> list = new List<ServiceViewModel>();
            if (limit == null || offset == null)
            {
                using (var command = new NpgsqlCommand("select id, name from service;", source.npgsqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                list.Add(new ServiceViewModel
                                {
                                    Id = reader.GetInt32(0),
                                    ServiceName = reader.GetString(1)
                                });
                    }
                }
            }
            else
            {
                using (var command = new NpgsqlCommand($"select service.id, service.name, service.price, field_medicine.name " +
                    $"from service join field_medicine " +
                    $"on service.field_id = field_medicine.id " +
                    $"order by field_medicine.name asc, service.name asc " +
                    $"limit {limit} offset {offset};", source.npgsqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                list.Add(new ServiceViewModel
                                {
                                    Id = reader.GetInt32(0),
                                    ServiceName = reader.GetString(1),
                                    Price = reader.GetInt32(2),
                                    FieldName = reader.GetString(3)
                                });
                    }
                }
            }
            return list;
        }
    }
}