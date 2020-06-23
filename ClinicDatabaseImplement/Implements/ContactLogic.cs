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
    public class ContactLogic : IContactLogic
    {
        private readonly ClinicDatabase source;

        public static string connStr;

        public ContactLogic()
        {
            source = ClinicDatabase.GetInstance();
            connStr = source.GetConnectionString();
        }

        public void Create(ContactBindingModel model)
        {
            int maxId = ReadAllId().Max(x => x.Id.Value) + 1;
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("INSERT INTO contact (id, clinic_id, telephone) VALUES (@id, @clinicId, @telephone)", conn))
                {
                    command.Parameters.AddWithValue("id", maxId);
                    command.Parameters.AddWithValue("clinicId", model.ClinicId);
                    command.Parameters.AddWithValue("telephone", model.Telephone);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(ContactBindingModel model)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("DELETE FROM contact WHERE id = @id", conn))
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

        public List<ContactViewModel> Read(ContactBindingModel model)
        {
            List<ContactViewModel> list = new List<ContactViewModel>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select * from contact WHERE clinic_id = @clinicId", conn))
                {
                    command.Parameters.AddWithValue("clinicId", model.ClinicId);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        list.Add(new ContactViewModel
                        {
                            Id = reader.GetInt32(0),
                            Telephone = reader.GetInt64(2)
                        });
                }
            }
            return list;
        }

        public List<Contact> ReadAllId()
        {
            List<Contact> list = new List<Contact>();
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("select * from contact", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        list.Add(new Contact
                        {
                            Id = reader.GetInt32(0),
                            Telephone = reader.GetInt64(2)
                        });
                }
            }
            return list;
        }
    }
}