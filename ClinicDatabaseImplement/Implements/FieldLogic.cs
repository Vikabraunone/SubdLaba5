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
    public class FieldLogic : IFieldLogic
    {
        private readonly ClinicDatabase source;

        public static string connStr;

        public FieldLogic()
        {
            source = ClinicDatabase.GetInstance();
            connStr = source.GetConnectionString();
        }

        public void Create(FieldBindingModel model)
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
                    using (var command = new NpgsqlCommand("INSERT INTO field_medicine (id, name) VALUES (@id, @name)", conn))
                    {
                        command.Parameters.AddWithValue("id", maxId);
                        command.Parameters.AddWithValue("name", model.Name);
                        command.ExecuteNonQuery();
                    }
                }
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO clinic_field (clinic_id, field_id) VALUES (@clinicId, @fieldId)", conn))
                    {
                        command.Parameters.AddWithValue("clinicId", model.ClinicId);
                        command.Parameters.AddWithValue("fieldId", maxId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(FieldBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM field_medicine WHERE id = @id", conn))
                    {
                        command.Parameters.AddWithValue("id", model.Id);
                        command.ExecuteNonQuery();
                    }
                }
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM clinic_field WHERE field_id = @fieldId", conn))
                    {
                        command.Parameters.AddWithValue("fieldId", model.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FieldViewModel> Read(FieldBindingModel model)
        {
            List<FieldViewModel> result = new List<FieldViewModel>();
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
                    using (var command = new NpgsqlCommand("SELECT * FROM field_medicine", conn))
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

                // соединяем id области клиники с наименованием области
                result = ((from cf in clinicField
                           join f in fields
                           on cf.FieldId equals f.Id
                           select new
                           {
                               FieldId = f.Id,
                               Name = f.Name
                           }).Distinct())
                           .Select(x => new FieldViewModel
                           {
                               Id = x.FieldId,
                               Name = x.Name
                           })
                           .ToList();
            }
            else
            {
                // считываем конкретную область
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand($"SELECT * FROM field_medicine WHERE id={model.Id}", conn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
                        result.Add(new FieldViewModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
            return result;
        }

        public void Update(FieldBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("UPDATE field_medicine SET name=@name WHERE id = @id", conn))
                    {
                        command.Parameters.AddWithValue("name", model.Name);
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

        public List<FieldBindingModel> ReadAllId()
        {
            List<FieldBindingModel> result = new List<FieldBindingModel>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM field_medicine", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        result.Add(new FieldBindingModel
                        {
                            Id = reader.GetInt32(0)
                        });
                }
            }
            return result;
        }
    }
}