using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApi
{
    public static class SqlConnector
    {
        //public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection)
        //{
        //    while (reader.Read())
        //    {
        //        yield return projection(reader);
        //    }
        //}

        public static void ReadCarData()
        {
            string connectionString = "Data Source=VMWM\\SQLEXPRESS;Initial Catalog=restDB;Integrated Security=SSPI";
            string queryString = "SELECT ID, Name FROM dbo.Cars;";

            IList<Car>? cars = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    var data = (IDataRecord) reader;
                    System.Diagnostics.Debug.WriteLine(String.Format("{0}, {1}", data[0], data[1]));
                    //ReadSingleRow(data);

                    cars = reader.Select(r =>
                    {
                        return new Car
                        {
                            ID = r["id"] is DBNull ? null : (in)r["ID"],
                            Name = r["name"] is DBNull ? null : r["name"].ToString()
                        };
                    }).ToList();
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            //Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
            System.Diagnostics.Debug.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }

    public class Car
    {
        public static int ID;
        public static string Name;
    }
}
