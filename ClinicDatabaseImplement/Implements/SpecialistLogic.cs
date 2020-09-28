using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ClinicDatabaseImplement.Implements
{
    public class SpecialistLogic : ISpecialistLogic
    {
        private readonly ClinicDatabase source;

        public SpecialistLogic()
        {
            source = ClinicDatabase.GetInstance();
        }

        public void Create(SpecialistBindingModel model)
        {
            try
            {
                int? maxId = null;
                using (var command = new NpgsqlCommand("select max(id) from specialist", source.npgsqlConnection))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    maxId = reader.GetInt32(0);
                    reader.Close();
                }
                if (!maxId.HasValue)
                    maxId = 500;
                using (var command = new NpgsqlCommand("INSERT INTO specialist(id, lastname, firstname, middlename, experience_work, qualification) " +
                    "VALUES (@id, @lastname, @firstname, @middlename, @experienceWork, @qualification)", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("id", maxId + 1);
                    command.Parameters.AddWithValue("lastname", model.Lastname);
                    command.Parameters.AddWithValue("firstname", model.Firstname);
                    command.Parameters.AddWithValue("middlename", model.Middlename);
                    command.Parameters.AddWithValue("experienceWork", model.ExperienceWork);
                    command.Parameters.AddWithValue("qualification", model.Qualification);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(SpecialistBindingModel model)
        {
            try
            {
                using (var command = new NpgsqlCommand("DELETE FROM specialist WHERE id = @id", source.npgsqlConnection))
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

        public void Update(SpecialistBindingModel model)
        {
            try
            {
                using (var command = new NpgsqlCommand("UPDATE specialist " +
                    "SET lastname=@lastname, firstname=@firstname, middlename=@middlename, " +
                    "experience_work=@experienceWork, qualification=@qualification WHERE id = @id", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("id", model.Id);
                    command.Parameters.AddWithValue("lastname", model.Lastname);
                    command.Parameters.AddWithValue("firstname", model.Firstname);
                    command.Parameters.AddWithValue("middlename", model.Middlename);
                    command.Parameters.AddWithValue("experienceWork", model.ExperienceWork);
                    command.Parameters.AddWithValue("qualification", model.Qualification);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SpecialistViewModel Read(SpecialistBindingModel model)
        {
            SpecialistViewModel specialist;
            using (var command = new NpgsqlCommand($"SELECT * FROM specialist WHERE id={model.Id}", source.npgsqlConnection))
            {
                var reader = command.ExecuteReader();
                reader.Read();
                specialist = new SpecialistViewModel
                {
                    Id = reader.GetInt32(0),
                    Lastname = reader.GetString(1),
                    Firstname = reader.GetString(2),
                    Middlename = reader.GetString(3),
                    ExperienceWork = reader.GetInt32(4),
                    Qualification = reader.GetString(5)
                };
                reader.Close();
            }
            return specialist;
        }

        public List<SpecialistViewModel> Read(int? limit, int? offset)
        {
            List<SpecialistViewModel> list = new List<SpecialistViewModel>();
            if (limit == null || offset == null)
            {
                using (var command = new NpgsqlCommand("select id, lastname, firstname, middlename from specialist;", source.npgsqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                list.Add(new SpecialistViewModel
                                {
                                    Id = reader.GetInt32(0),
                                    Firstname = string.Join(" ", reader.GetString(1), reader.GetString(2), reader.GetString(3))
                                });
                    }
                }
            }
            else
            {
                using (var command = new NpgsqlCommand($"select * from specialist " +
                    $"order by lastname asc, firstname asc, middlename asc " +
                    $"limit {limit} offset {offset};", source.npgsqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                list.Add(new SpecialistViewModel
                                {
                                    Id = reader.GetInt32(0),
                                    Lastname = reader.GetString(1),
                                    Firstname = reader.GetString(2),
                                    Middlename = reader.GetString(3),
                                    ExperienceWork = reader.GetInt32(4),
                                    Qualification = reader.GetString(5)
                                });
                    }
                }
            }
            return list;
        }
    }
}
