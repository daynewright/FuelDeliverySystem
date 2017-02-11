using System;
using Microsoft.Data.Sqlite;


namespace FuelDeliverySystem.Data
{
    public class FuelDeliverySystemConnection
    {
        private string _path = "Data Source=" + System.Environment.GetEnvironmentVariable("FuelDeliverySystem_DB");

        public void insert(string query)
        {
            SqliteConnection dbcon = new SqliteConnection(_path);
            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();

            dbcmd.CommandText = query;
            dbcmd.ExecuteNonQuery();

            dbcmd.Dispose();
            dbcon.Close();
        }

        public void execute(string query, Action<SqliteDataReader> handler)
        {
            SqliteConnection dbcon = new SqliteConnection(_path);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}
