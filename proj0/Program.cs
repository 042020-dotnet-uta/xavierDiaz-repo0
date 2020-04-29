using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace proj0
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Connection
            var cStrBuilder = new SqliteConnectionStringBuilder();
            cStrBuilder.DataSource = "./myDb.db";

            using(var Connection = new SqliteConnection(cStrBuilder.ConnectionString)){
                //want to use using so it closes after it's done
                Connection.Open();
                //create table
                var tableCmd = Connection.CreateCommand();  
                tableCmd.CommandText = "CREATE TABLE stores(name VARCHAR(50));"; 
                tableCmd.ExecuteNonQuery();
                //Insert Some Records    
                using(var transaction = Connection.BeginTransaction()){
                    var insertCmd = Connection.CreateCommand();
                    insertCmd.CommandText = "INSERT INTO stores VALUES('chico books')";
                    insertCmd.ExecuteNonQuery();

                    insertCmd.CommandText = "INSERT INTO stores VALUES('Santa Cruz books')";
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                }   
                var selectCmd = Connection.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM stores";
                using(var reader = selectCmd.ExecuteReader()){
                    while(reader.Read()){
                        var result = reader.GetString(0);// getting the first column data[0]
                        Console.WriteLine(result);
                    }
                }
            }

            // Insert records

            // Read Records
        }
    }
}
