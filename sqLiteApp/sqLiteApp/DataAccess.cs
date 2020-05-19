using Microsoft.Data.Sqlite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqLiteApp
{
    class DataAccess
    {
        public  static void InitializeDatabase()
        {                      
            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customer (UID INTEGER PRIMARY KEY, " +
                    "first_name NVARCHAR(30) NOT NULL,"+
                    "last_name NVARCHAR(30) NOT NULL,"+
                    "email NVARCHAR(50) NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
        public static void addData(string UID,string first_name,string last_name,string email)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand insertcommand = new SqliteCommand();
                insertcommand.Connection = db;

                insertcommand.CommandText = "INSERT INTO Customer VALUES (@UID, @first_name, @last_name,@email);";
                insertcommand.Parameters.AddWithValue("@UID", UID);
                insertcommand.Parameters.AddWithValue("@first_name", first_name);
                insertcommand.Parameters.AddWithValue("@last_name", last_name);
                insertcommand.Parameters.AddWithValue("@email", email);

                insertcommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<string> getData()
        {
            List<String> data = new List<string>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("select * from Customer",db);
                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                   data.Add(query.GetString(0));
                   data.Add(query.GetString(1));
                   data.Add(query.GetString(2));
                   data.Add(query.GetString(3));
                }

                db.Close();
            }

            return data;
        }
                
        
    }
}
