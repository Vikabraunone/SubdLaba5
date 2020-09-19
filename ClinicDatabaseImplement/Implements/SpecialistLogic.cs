using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Enums;
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

        private int firstId, minValue = 500; // первая запись текущей страницы в бд

        private int endId = 505; // последняя запись текущей страницы в бд

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

        public List<SpecialistViewModel> Read(Page page)
        {
            List<SpecialistViewModel> list = new List<SpecialistViewModel>();
            if (page == Page.Current)
            {
                using (var command = new NpgsqlCommand($"select * from specialist where " +
                       $"id >= {firstId} order by id asc limit 5;", source.npgsqlConnection))
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
            else if (page == Page.Next)
            {
                using (var command = new NpgsqlCommand($"select * from specialist where " +
                    $"id > {endId} order by id asc limit 5;", source.npgsqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
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
                            firstId = list[0].Id.Value;
                            endId = list[list.Count - 1].Id.Value;
                        }
                    }
                }
            }
            else if (page == Page.Last)
            {
                if (firstId > minValue)
                {
                    using (var command = new NpgsqlCommand($"select * from specialist where " +
                        $"id < {firstId} order by id desc limit 5;", source.npgsqlConnection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                    list.Insert(0, (new SpecialistViewModel
                                    {
                                        Id = reader.GetInt32(0),
                                        Lastname = reader.GetString(1),
                                        Firstname = reader.GetString(2),
                                        Middlename = reader.GetString(3),
                                        ExperienceWork = reader.GetInt32(4),
                                        Qualification = reader.GetString(5)
                                    }));
                                firstId = list[0].Id.Value;
                                endId = list[list.Count - 1].Id.Value;
                            }
                        }
                    }
                }
            }
            else if (page == Page.All)
            {
                using (var command = new NpgsqlCommand($"select id, lastname, firstname, middlename from specialist;", source.npgsqlConnection))
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
            return list;
        }
    }
}
