﻿using System;
using System.Data;
using System.Data.SqlClient;
using WebApi.Model;

namespace WebApi
{
    public class SqlConnector
    {
        //public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection)
        //{
        //    while (reader.Read())
        //    {
        //        yield return projection(reader);
        //    }
        //}

        public List<Car> ReadCarData()
        {
            string connectionString = "Data Source=VMWM\\SQLEXPRESS;Initial Catalog=restDB;Integrated Security=SSPI";
            string queryString = "SELECT ID, Name FROM dbo.Cars;";

            List<Car> carList = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    carList.Add(new Car()
                    {
                        ID = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1)
                    });

                    /*
                    var data = (IDataRecord) reader;
                    System.Diagnostics.Debug.WriteLine(String.Format("{0}, {1}", data[0], data[1]));
                    */

                    //ReadSingleRow(data);
                }

                // Call Close when done reading.
                reader.Close();
            }

            return carList;
        }

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            //Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
            System.Diagnostics.Debug.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }
}
