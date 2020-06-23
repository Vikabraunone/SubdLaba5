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
    public class ClinicLogic : IClinicLogic
    {
        private readonly ClinicDatabase source;

        public static string connStr;

        public ClinicLogic()
        {
            source = ClinicDatabase.GetInstance();
            connStr = source.GetConnectionString();
        }

        public void Create(ClinicBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM clinic WHERE name =  @name", conn))
                    {
                        command.Parameters.AddWithValue("name", model.Name);
                        if (command.ExecuteNonQuery() > 0)
                            throw new Exception("Клиника с таким названием существует");
                    }
                }
                int maxId = ReadAllId().Max(x => x.Id.Value) + 1;
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO clinic (id, name, address) VALUES (@id, @name, @address)", conn))
                    {
                        command.Parameters.AddWithValue("id", maxId);
                        command.Parameters.AddWithValue("name", model.Name);
                        command.Parameters.AddWithValue("address", model.Address);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(ClinicBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM clinic WHERE id = @id", conn))
                    {
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

        public void Update(ClinicBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("UPDATE clinic SET name=@name, address=@address WHERE id = @id", conn))
                    {
                        command.Parameters.AddWithValue("name", model.Name);
                        command.Parameters.AddWithValue("address", model.Address);
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

        public List<ClinicViewModel> Read(ClinicBindingModel model)
        {
            List<ClinicViewModel> list = new List<ClinicViewModel>();
            if (model == null)
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("SELECT * FROM CLINIC", conn))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                            list.Add(new ClinicViewModel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2)
                            });
                    }
                }
            }
            else
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand($"SELECT * FROM clinic WHERE id={model.Id}", conn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        list.Add(new ClinicViewModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2)
                        });
                    }
                }
            }
            return list;
        }

        public List<Clinic> ReadAllId()
        {
            List<Clinic> list = new List<Clinic>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM CLINIC", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        list.Add(new Clinic
                        {
                            Id = reader.GetInt32(0)
                        });
                }
            }
            return list;
        }
    }
}