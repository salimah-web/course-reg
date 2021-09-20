using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace course_reg
{
    class CourseReg
    {
        Database SchoolDatabase = new Database();
        public string Name;
        public string Email;
        public string Course;

        public CourseReg(string name, string email, string course)
        {
            Name = name;
            Email = email;
            Course = course;
        }

        public void RegisterCourse()
        {
           
                //the values of course id and student id are added to the database
                var Course_id = string.Format("SELECT id FROM courses WHERE name = '{0}'",Course);
                SQLiteCommand mycommand_1 = new SQLiteCommand(Course_id, SchoolDatabase.myconn);
                SchoolDatabase.Openconn();
                SQLiteDataReader reader = mycommand_1.ExecuteReader();
                reader.Read();

                int ID = Convert.ToInt32(reader[0]);

                var Student_id = string.Format("SELECT id FROM students WHERE name = '{0}'", Name);
                SQLiteCommand mycommand_2 = new SQLiteCommand(Student_id, SchoolDatabase.myconn);
                SchoolDatabase.Openconn();
                SQLiteDataReader reader_1 = mycommand_2.ExecuteReader();
                reader_1.Read();
                int std_Id = Convert.ToInt32(reader_1[0]);

                var query_7 = string.Format("SELECT * FROM RegisteredCourses WHERE course_id = '{0}' AND student_id= '{1}'", ID, std_Id);
                SQLiteCommand mycommand_4 = new SQLiteCommand(query_7, SchoolDatabase.myconn);
                SchoolDatabase.Openconn();
                var result = Convert.ToInt32(mycommand_4.ExecuteScalar());
                if (result > 0)
                {
                    Console.WriteLine("This student has registered for this course");
                }
                else
                {
                    var query = string.Format("INSERT INTO RegisteredCourses('course_id','student_id') VALUES ('{0}','{1}')", ID, std_Id);
                    SQLiteCommand mycommand = new SQLiteCommand(query, SchoolDatabase.myconn);               
                    var res = mycommand.ExecuteNonQuery();
                    SchoolDatabase.closeconn();
                    Console.WriteLine("registration completed");
                }
                
            
            
        }
    }
}
