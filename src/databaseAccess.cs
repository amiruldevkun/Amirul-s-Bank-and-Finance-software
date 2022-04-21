using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace EATM
{
    public class databaseAccess
    {
        public SQLiteConnection CreateConnection() {
           
            SQLiteConnection conn = new SQLiteConnection("Data Source=EATM.db; Version=3; New=True; Compress=True;");

            try {
                
                conn.Open();
                
            } catch (Exception e) {
                
                Console.WriteLine(e.Message);
            
            }
            return conn;
        }
            static void MandatoryTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string CreateTable = "CREATE TABLE EATM(name VARCHAR(100), PIN INT, balance FLOAT)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = CreateTable;
            sqlite_cmd.ExecuteNonQuery();
            
        }

        static void UserBalanceHistoryTable(SQLiteConnection conn, string tableName) {
            SQLiteCommand sqlite_cmd;
            string CreateTable = "CREATE TABLE" + tableName + "(balancehistory FLOAT)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = CreateTable;
            sqlite_cmd.ExecuteNonQuery();
        }

        static void InsertData(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Test Text ', 1);";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Test1 Text1 ', 2);";
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES ('Test2 Text2 ', 3);";
            sqlite_cmd.ExecuteNonQuery();


            sqlite_cmd.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES ('Test3 Text3 ', 3);";
            sqlite_cmd.ExecuteNonQuery();

        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
    }
}
