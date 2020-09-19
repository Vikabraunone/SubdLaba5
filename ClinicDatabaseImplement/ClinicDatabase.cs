using Npgsql;
using System;

namespace ClinicDatabaseImplement
{
    public class ClinicDatabase
    {
        private static ClinicDatabase instance;

        public NpgsqlConnection npgsqlConnection;

        public static ClinicDatabase GetInstance()
        {
            if (instance == null)
                instance = new ClinicDatabase();
            return instance;
        }

        public static void OpenСonnection(string host, string port, string password, string database)
        {
            instance = GetInstance();
            instance.Open(host, port, password, database);
        }

        public void Open(string host, string port, string password, string database)
        {
            //Server=localhost;Port=5432;Password=;Database=clinic_db;
            var connectionString = $"Server={host};Port={port};Password={password};Database={database};";
            try
            {
                npgsqlConnection = new NpgsqlConnection(connectionString);
                npgsqlConnection.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        ~ClinicDatabase()
        {
            if (npgsqlConnection != null)
                npgsqlConnection.Close();
        }
    }
}