using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Enums;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ClinicDatabaseImplement.Implements
{
    public class SpecialistServiceLogic : ISpecialistServiceLogic
    {
        private readonly ClinicDatabase source;

        private int firstId, minValue = 400; // первая запись текущей страницы в бд

        private int endId = 405; // последняя запись текущей страницы в бд

        public SpecialistServiceLogic()
        {
            source = ClinicDatabase.GetInstance();
        }

        public void Create(SpecialistServiceBindingModel model)
        {
            try
            {
                using (var command = new NpgsqlCommand("INSERT INTO specialist_service(specialist_id, service_id)" +
                    "VALUES (@specialistId, @serviceId)", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("specialistId", model.SpecialistId);
                    command.Parameters.AddWithValue("serviceId", model.ServiceId);
                    command.ExecuteNonQuery();
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
                using (var command = new NpgsqlCommand("DELETE FROM specialist_service WHERE specialist_id=@specialistId AND service_id=@serviceId", source.npgsqlConnection))
                {
                    command.Parameters.AddWithValue("specialistId", model.SpecialistId);
                    command.Parameters.AddWithValue("serviceId", model.ServiceId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<SpecialistServiceViewModel> Read(SpecialistServiceBindingModel model)
        {
            List<SpecialistServiceViewModel> list = new List<SpecialistServiceViewModel>();
            using (var command = new NpgsqlCommand("select service.id, specialist.id, service.name, specialist.lastname, " +
                "specialist.firstname, specialist.middlename from service " +
                "join specialist_service on specialist_service.service_id = service.id " +
                "join specialist on specialist_service.specialist_id = specialist.id;", source.npgsqlConnection))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(new SpecialistServiceViewModel
                    {
                        ServiceId = reader.GetInt32(0),
                        SpecialistId = reader.GetInt32(1),
                        ServiceName = reader.GetString(2),
                        Lastname = reader.GetString(3),
                        Firstname = reader.GetString(4),
                        Middlename = reader.GetString(5)
                    });
                reader.Close();
            }
            return list;
        }

        public List<SpecialistServiceViewModel> Read(Page page)
        {
            List<SpecialistServiceViewModel> list = new List<SpecialistServiceViewModel>();
            if (page == Page.Current)
            {
                using (var command = new NpgsqlCommand($"select service.id, specialist.id, service.name, specialist.lastname, " +
                    $"specialist.firstname, specialist.middlename from service " +
                    $"join specialist_service on specialist_service.service_id = service.id " +
                    $"join specialist on specialist_service.specialist_id = specialist.id " +
                    $"where service.id >= {firstId} order by service.id asc limit 5;", source.npgsqlConnection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                        while (reader.Read())
                            list.Add(new SpecialistServiceViewModel
                            {
                                ServiceId = reader.GetInt32(0),
                                SpecialistId = reader.GetInt32(1),
                                ServiceName = reader.GetString(2),
                                Lastname = reader.GetString(3),
                                Firstname = reader.GetString(4),
                                Middlename = reader.GetString(5)
                            });
                }
            }
            else if (page == Page.Next)
            {
                using (var command = new NpgsqlCommand($"select service.id, specialist.id, service.name, specialist.lastname, " +
                    $"specialist.firstname, specialist.middlename from service " +
                    $"join specialist_service on specialist_service.service_id = service.id " +
                    $"join specialist on specialist_service.specialist_id = specialist.id " +
                    $"where service.id > {endId} order by service.id asc limit 5;", source.npgsqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                                list.Add(new SpecialistServiceViewModel
                                {
                                    ServiceId = reader.GetInt32(0),
                                    SpecialistId = reader.GetInt32(1),
                                    ServiceName = reader.GetString(2),
                                    Lastname = reader.GetString(3),
                                    Firstname = reader.GetString(4),
                                    Middlename = reader.GetString(5)
                                });
                            firstId = list[0].ServiceId;
                            endId = list[list.Count - 1].ServiceId;
                        }
                    }
                }
            }
            else if (page == Page.Last)
            {
                if (firstId > minValue)
                {
                    using (var command = new NpgsqlCommand($"select service.id, specialist.id, service.name, specialist.lastname, " +
                    $"specialist.firstname, specialist.middlename from service " +
                    $"join specialist_service on specialist_service.service_id = service.id " +
                    $"join specialist on specialist_service.specialist_id = specialist.id " +
                    $"where service.id < {firstId} order by service.id desc limit 5;", source.npgsqlConnection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                    list.Insert(0, (new SpecialistServiceViewModel
                                    {
                                        ServiceId = reader.GetInt32(0),
                                        SpecialistId = reader.GetInt32(1),
                                        ServiceName = reader.GetString(2),
                                        Lastname = reader.GetString(3),
                                        Firstname = reader.GetString(4),
                                        Middlename = reader.GetString(5)
                                    }));
                                firstId = list[0].ServiceId;
                                endId = list[list.Count - 1].ServiceId;
                            }
                        }
                    }
                }
            }
            return list;
        }
    }
}
