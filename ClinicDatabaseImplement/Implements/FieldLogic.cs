using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ClinicDatabaseImplement.Implements
{
    public class FieldLogic : IFieldLogic
    {
        private readonly ClinicDatabase source;

        public FieldLogic()
        {
            source = ClinicDatabase.GetInstance();
        }

        public void Create(FieldBindingModel model)
        {
            try
            {
                int? maxId = null;
                using (var command = new NpgsqlCommand("select max(id) from field_medicine", source.npgsqlConnection))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    maxId = reader.GetInt32(0);
                }
                if (!maxId.HasValue)
                    maxId = 300;
                using (var command = new NpgsqlCommand("INSERT INTO field_medicine (id, name) VALUES (@id, @name)", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("id", maxId + 1);
                    command.Parameters.AddWithValue("name", model.Name);
                    command.ExecuteNonQuery();
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
                using (var command = new NpgsqlCommand("DELETE FROM field_medicine WHERE id = @id", source.npgsqlConnection))
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

        public List<FieldViewModel> Read(FieldBindingModel model)
        {
            List<FieldViewModel> list = new List<FieldViewModel>();
            if (model == null)
            {
                using (var command = new NpgsqlCommand($"select * from field_medicine", source.npgsqlConnection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        list.Add(new FieldViewModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    reader.Close();
                }
            }
            else
            {
                using (var command = new NpgsqlCommand($"select * from field_medicine where id={model.Id}", source.npgsqlConnection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        list.Add(new FieldViewModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    reader.Close();
                }
            }
            return list;
        }

        public void Update(FieldBindingModel model)
        {
            try
            {
                using (var command = new NpgsqlCommand("UPDATE field_medicine SET name=@name WHERE id = @id", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("name", model.Name);
                    command.Parameters.AddWithValue("id", model.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}