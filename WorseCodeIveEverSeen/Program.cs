using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Web;

namespace WorseCodeIveEverSeen
{
    internal class Program
    {
        string ConnectionString = "Server=localhost;Port=5432;Database=demo;User Id=postgres;Password=postgres;";
        string queryString = "SELECT DISTINCT(passenger_id) FROM tickets WHERE passenger_name = 'ADELINA ANDREEVA'";
        List<string> results = new List<string>();

        static void Main(string[] args)
        {

            NpgsqlConnection Connection = new NpgsqlConnection(ConnectionString);
            NpgsqlCommand command = new NpgsqlCommand(queryString, Connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string passangerId = reader.GetValue(0);
                results.Add(passangerId);
            }


            TextWriter writer = new StreamWriter("result.txt");
            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    string r = results[i];
                    writer.WriteLine(r);
                }
            }
        }
    }
}
