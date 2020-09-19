using ClinicBisinessLogic.BindingModels;
using ClinicBisinessLogic.Interfaces;
using ClinicBisinessLogic.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ClinicDatabaseImplement.Implements
{
    public class ContactLogic : IContactLogic
    {
        private readonly ClinicDatabase source;

        public ContactLogic()
        {
            source = ClinicDatabase.GetInstance();
        }

        public void Create(ContactBindingModel model)
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
                maxId = 200;
            using (var command = new NpgsqlCommand("INSERT INTO contact (id, telephone) VALUES (@id, @telephone)", source.npgsqlConnection))
            {
                command.Parameters.AddWithValue("id", maxId + 1);
                command.Parameters.AddWithValue("telephone", model.Telephone);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(ContactBindingModel model)
        {
            try
            {
                using (var command = new NpgsqlCommand("DELETE FROM contact WHERE id = @id", source.npgsqlConnection))
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

        public List<ContactViewModel> Read()
        {
            var list = new List<ContactViewModel>();
            using (var command = new NpgsqlCommand("select * from contact", source.npgsqlConnection))
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(new ContactViewModel
                    {
                        Id = reader.GetInt32(0),
                        Telephone = reader.GetInt64(1)
                    });
                reader.Close();
            }
            return list;
        }
    }
}