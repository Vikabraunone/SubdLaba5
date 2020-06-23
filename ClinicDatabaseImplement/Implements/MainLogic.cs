using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using ClinicDatabaseImplement.Models;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace ClinicDatabaseImplement.Implements
{
    public class MainLogic : IMainLogic
    {
        private readonly ClinicDatabase source;

        public static string connStr;

        public MainLogic()
        {
            source = ClinicDatabase.GetInstance();
            connStr = source.GetConnectionString();
        }

        public List<MainViewModel> Read(int clinicId)
        {
            // считываем id областей, которые привязаны к данной клинике
            var clinicField = new List<ClinicField>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand($"select * from clinic_field WHERE clinic_id = {clinicId}", conn))
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

            // считываем таблицу соответствия специалиста к услугам
            var specialistServices = new List<SpecialistService>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select * from specialist_service", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        specialistServices.Add(new SpecialistService
                        {
                            SpecialistId = reader.GetInt32(0),
                            ServiceId = reader.GetInt32(1)
                        });
                }
            }

            // считываем данные всех специалистов
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
                            Qualification = reader.GetString(5)
                        });
                }
            }

            // соединяем id областей данной клиники c наименованием областей 
            var joinClinicOnFields = from cf in clinicField
                                     join f in fields
                                     on cf.FieldId equals f.Id
                                     select new
                                     {
                                         FieldId = f.Id,
                                         Name = f.Name
                                     };

            // соединяем области и услуги в них
            var joinFieldOnServices = from cf in joinClinicOnFields
                                      join s in services
                                      on cf.FieldId equals s.FieldId
                                      select new
                                      {
                                          ServiceId = s.Id,
                                          FieldName = cf.Name
                                      };

            // соединяем id специалиста с каждой областью через оказываемые им услугах
            var joinFieldOnSpecialist = from fs in joinFieldOnServices
                                        join ss in specialistServices
                                        on fs.ServiceId equals ss.ServiceId
                                        select new
                                        {
                                            SpecialistId = ss.SpecialistId,
                                            FieldName = fs.FieldName
                                        };

            // соединяем информацию о специалисте с областью
            List<MainViewModel> result = ((from fs in joinFieldOnSpecialist
                                           join s in specialists
                                           on fs.SpecialistId equals s.Id
                                           select new
                                           {
                                               FieldName = fs.FieldName,
                                               LastName = s.Lastname,
                                               FirstName = s.Firstname,
                                               MiddleName = s.Middlename,
                                               ExperienceWork = s.ExperienceWork,
                                               Qualification = s.Qualification
                                           }).Distinct())
                                          .Select(x => new MainViewModel
                                          {
                                              FieldName = x.FieldName,
                                              Lastname = x.LastName,
                                              Firstname = x.FirstName,
                                              Middlename = x.MiddleName,
                                              ExperienceWork = x.ExperienceWork,
                                              Qualification = x.Qualification
                                          })
                                          .ToList();
            result.OrderBy(x => x.FieldName);
            return result;
        }
    }
}