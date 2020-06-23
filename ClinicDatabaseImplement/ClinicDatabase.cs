using Npgsql;
using System;

namespace ClinicDatabaseImplement
{
    public class ClinicDatabase
    {
        private static ClinicDatabase instance;

        private static string connectionString;

        public static ClinicDatabase GetInstance()
        {
            if (instance == null)
                instance = new ClinicDatabase();
            return instance;
        }

        public void ConnectToDatabase(string host, string port, string user, string password, string database)
        {
            connectionString = "Server=localhost;Port=5432;Password=;Database=clinic_db;";
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}