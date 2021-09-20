using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace course_reg
{
    class Database
    {
        public SQLiteConnection myconn;
        public bool condition;
        public Database()
        {
            //creates new database if database file doesn not exists
            myconn = new SQLiteConnection("Data Source=database.sqlite3");
            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                Console.WriteLine("database created");
            }
        }
        public void Openconn()
        {
            if (myconn.State != System.Data.ConnectionState.Open)
            {
                myconn.Open();
                condition = true;
            }
        }
        public void closeconn()
        {
            if (myconn.State != System.Data.ConnectionState.Closed)
            {
                myconn.Close();
            }
        }
    }
   
}
