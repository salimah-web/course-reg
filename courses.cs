using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
namespace course_reg
{
    class AddCourses
    {
        Database SchoolDatabase = new Database();
        public string course;
        public bool course_exists;
        public AddCourses(string course_name)
        {
            course = course_name;
        }
        public void AddToDatabase()
        {
            //Checks if course exists first, if it does not exists, it is added to the database
            var query = string.Format("SELECT * FROM courses WHERE name = '{0}'", course);
            SQLiteCommand mycommand = new SQLiteCommand(query, SchoolDatabase.myconn);
            SchoolDatabase.Openconn();
            var result = Convert.ToInt32(mycommand.ExecuteScalar());
            if (result > 0)
            {
                course_exists = true;
            }
            else
            {
                course_exists = false;
                var query_5 = string.Format("INSERT INTO courses('name') VALUES ('{0}')", course);
                SQLiteCommand mycommand_3 = new SQLiteCommand(query_5, SchoolDatabase.myconn);
                
                var ress = mycommand_3.ExecuteNonQuery();
                SchoolDatabase.closeconn();
                Console.WriteLine("Course successfully added to database");

            }
        }
    }
}