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
    public class SpecialistLogic : ISpecialistLogic
    {
        private readonly ClinicDatabase source;

        public static string connStr;

        public SpecialistLogic()
        {
            source = ClinicDatabase.GetInstance();
            connStr = source.GetConnectionString();
        }

        public void Create(SpecialistBindingModel model)
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
                    using (var command = new NpgsqlCommand("INSERT INTO specialist(id, lastname, firstname, middlename, experience_work, qualification) " +
                        "VALUES (@id, @lastname, @firstname, @middlename, @experienceWork, @qualification)", conn))
                    {
                        command.Parameters.AddWithValue("id", maxId);
                        command.Parameters.AddWithValue("lastname", model.Lastname);
                        command.Parameters.AddWithValue("firstname", model.Firstname);
                        command.Parameters.AddWithValue("middlename", model.Middlename);
                        command.Parameters.AddWithValue("experienceWork", model.ExperienceWork);
                        command.Parameters.AddWithValue("qualification", model.Qualification);
                        command.ExecuteNonQuery();
                    }
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
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM specialist WHERE id = @id", conn))
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

        public void Update(SpecialistBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("UPDATE specialist " +
                        "SET lastname=@lastname, firstname=@firstname, middlename=@middlename, " +
                        "experience_work=@experienceWork, qualification=@qualification WHERE id = @id", conn))
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SpecialistViewModel> Read(SpecialistBindingModel model)
        {
            List<SpecialistViewModel> list = new List<SpecialistViewModel>();
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
                                ExperienceWork = reader.GetInt32(4),
                                Qualification = reader.GetString(3)
                            });
                    }
                }

                // выбираем услуги из областей данной клиники
                var joinFieldOnService = (from cf in clinicField
                                          join s in services
                                          on cf.FieldId equals s.FieldId
                                          select new
                                          {
                                              ServiceId = s.Id
                                          })
                                          .Distinct();

                // соединяем специалистов и услуги
                var joinServiceOnSpecialistService = from fs in joinFieldOnService
                                                     join ss in specialistService
                                                     on fs.ServiceId equals ss.ServiceId
                                                     select new
                                                     {
                                                         ServiceId = ss.ServiceId,
                                                         SpecialistId = ss.SpecialistId
                                                     };

                // выбираем специалистов из данной клиники
                list = ((from sss in joinServiceOnSpecialistService
                         join s in specialists
                         on sss.SpecialistId equals s.Id
                         select new
                         {
                             SpecialistId = sss.SpecialistId,
                             Lastname = s.Lastname,
                             Firstname = s.Firstname,
                             Middlename = s.Middlename,
                             ExperienceWork = s.ExperienceWork,
                             Qualification = s.Qualification
                         })
                         .Distinct())
                         .Select(x => new SpecialistViewModel
                         {
                             Id = x.SpecialistId,
                             Lastname = x.Lastname,
                             Firstname = x.Firstname,
                             Middlename = x.Middlename,
                             ExperienceWork = x.ExperienceWork,
                             Qualification = x.Qualification
                         })
                          .ToList();

                // добавляем тех специалистов, которые не оказывают услуги ни в одной клинике
                foreach (var e in specialistService)
                    for (int i = 0; i < specialists.Count(); i++)
                        if (specialists[i].Id == e.SpecialistId)
                        {
                            specialists.RemoveAt(i);
                            i--;
                        }

                foreach (var e in specialists)
                    list.Add(new SpecialistViewModel
                    {
                        Id = e.Id,
                        Lastname = e.Lastname,
                        Firstname = e.Firstname,
                        Middlename = e.Middlename,
                        ExperienceWork = e.ExperienceWork,
                        Qualification = e.Qualification
                    });
            }
            else
            {
                // читаем данные конкретного специалиста
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand($"SELECT * FROM specialist WHERE id={model.Id}", conn))
                    {
                        var reader = command.ExecuteReader();
                        reader.Read();
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

        public List<SpecialistBindingModel> ReadAllId()
        {
            List<SpecialistBindingModel> list = new List<SpecialistBindingModel>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT * FROM specialist", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        list.Add(new SpecialistBindingModel
                        {
                            Id = reader.GetInt32(0)
                        });
                }
            }
            return list;
        }
    }
}
