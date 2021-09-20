using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;


namespace course_reg
{
    class Register
    {
        Database SchoolDatabase = new Database();
        public string Name;
        public int Age;
        public string Email;
        public bool student_exists;

        public Register(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void check_student()
        {
            //checks if student exists
            var query = string.Format("SELECT * FROM students WHERE name = '{0}' AND email= '{1}'", Name, Email);
            SQLiteCommand mycommand = new SQLiteCommand(query, SchoolDatabase.myconn);
            SchoolDatabase.Openconn();
            var result = Convert.ToInt32(mycommand.ExecuteScalar());
            if (result > 0)
            {
                student_exists = true;
            }
            else
            {
                student_exists = false;
            }
        }
        
        public void AddToDatabase(int age)
        {
            //Adds students to database
            Age = age;
            
            student_exists = false;
            var query_1 = string.Format("INSERT INTO students('name','age','email') VALUES ('{0}','{1}','{2}')", Name, Age, Email);
            SQLiteCommand mycommand_1 = new SQLiteCommand(query_1, SchoolDatabase.myconn);
            SchoolDatabase.Openconn();
            var res = mycommand_1.ExecuteNonQuery();
            SchoolDatabase.closeconn();

            Console.WriteLine("student successfully added to database");
            
        }
    }
    
}
