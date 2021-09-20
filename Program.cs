using System;
using System.Data.SQLite;
using System.IO;
namespace course_reg
{
    class Program
    {
        static void Main(string[] args)
        {

            bool IsOption = false;
            while (IsOption == false)
            {
                Database std = new Database();
                Console.Write("Choose an option\n1. Register student\n2. Add course\n3. Student course registration.\n=>");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    IsOption = true;
                    std.Openconn();
                    Console.Write("Student name: ");
                    string name = Console.ReadLine();
                    Console.Write("Age : ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Register st = new Register(name, email);
                    st.check_student();
                    if (st.student_exists == true)
                    {
                        Console.Write("Student already exists ");
                        std.closeconn();                                
                        
                    }
                    else
                    {
                        st.AddToDatabase(age);
                        std.closeconn();
                        break;
                    }

                }
                else if (option == "2")
                {
                    
                    std.Openconn();
                    Console.Write("Course name: ");
                    string name = Console.ReadLine();
                    AddCourses mt = new AddCourses(name);
                    mt.AddToDatabase();
                    if (mt.course_exists == true)
                    {
                        Console.WriteLine("course already exists");
                    }
                    std.closeconn();
                    break;                          
                }
                else if (option == "3")
                {
                    IsOption = true;
                    std.Openconn();
                    Console.Write("Student name: ");
                    string name = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Course : ");
                    string Course = Console.ReadLine();

                    Register st = new Register(name, email);
                    st.check_student();


                    AddCourses mn = new AddCourses(Course);
                    mn.AddToDatabase();

                    if (st.student_exists == true && mn.course_exists==true)
                    {
                        CourseReg mo = new CourseReg(name, email, Course);
                        mo.RegisterCourse();            
                               
                        std.closeconn();

                        break;
                    }
                    else
                    {
                        Console.Write("Student does not exists ");
                        std.closeconn();
                        
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    
                }
                Console.WriteLine("\nDo you want to still carry out an operation?\n");
                Console.Write("1. yes\n2. no\n =>");
                string opt = Console.ReadLine();
                if (opt == "1")
                {
                    IsOption = false;
                }
                else
                {
                    IsOption = true;

                }
            }
            


        }
        }
}
