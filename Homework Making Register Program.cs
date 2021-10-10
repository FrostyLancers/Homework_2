using System;
using System.Collections.Generic;

namespace Register
{
    class Person
    {
        protected string name;
        protected string id;


        public Person(string Name, string ID)
        {
            this.name = Name;
            this.id = ID;
        }
    }
    class Program
    {
        static Person student;
        static Person teacher;
        static List<string> subject;
        static char Grade = 'z';

        static void Main(string[] args)
        {
            Program.subject = new List<string>();
            DistinguishJobMenu();
        }

        static void DistinguishJobMenu()
        {
            Console.Clear();
            Console.WriteLine("Are you a Student or a Tracher?");
            Console.WriteLine("1 = Student, 2 = Teacher, 3 = Exit Program");
            InputJob();
        }

        static void InputJob()
        {
            Console.Write("Input: ");
            int job = int.Parse(Console.ReadLine());
            switch (job)
            {
                case 1:
                    YouAreStudent();
                    break;
                case 2:
                    YouAreTeacher();
                    break;
                case 3:
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please input the available menu.");
                    Console.WriteLine("1 = Student, 2 = Teacher, 3 = Exit Program");
                    InputJob();
                    break;
            }
        }

        static void YouAreStudent()
        {
            Console.Clear();
            Console.WriteLine("1. Register Student Information");
            Console.WriteLine("2. Register Subject");
            Console.WriteLine("3. Show Grade");
            Console.WriteLine("4. Back");
            Console.Write("Input: ");
            int StudentMenu = int.Parse(Console.ReadLine());

            switch (StudentMenu)
            {
                case 1:
                    RegisterStudentInformation();
                    break;
                case 2:
                    RegisterStudentSubject();
                    break;
                case 3:
                    ShowGrade();
                    break;
                case 4:
                    DistinguishJobMenu();
                    break;
                default:
                    Console.WriteLine("Please input the available menu.Press to Continue.");
                    Console.ReadLine();
                    YouAreStudent();
                    break;
            }
        }

        static void RegisterStudentInformation()
        {
            Console.Clear();
            Console.WriteLine("Please Input your Information.");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("ID: ");
            string id = Console.ReadLine();

            AddStudentInformationToList(name, id);
        }

        static void AddStudentInformationToList(string name, string id)
        {
            Program.student = new Person(name, id);
            Console.WriteLine("Register student Done. Press to Continue.");
            Console.ReadLine();
            YouAreStudent();
        }

        static void RegisterStudentSubject()
        {
            Console.Clear();
            Console.WriteLine("Please select 3 subjects you want to register in this year from the list below.");
            Console.WriteLine("MDT, MAT, GDM, GEN, LNG");

            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Input Subject: ");
                string Subject = Console.ReadLine();

                if (Subject == "MDT" || Subject == "MAT" || Subject == "GDM" || Subject == "GEN" || Subject == "LNG")
                {
                    subject.Add(Subject);
                }
                else
                {
                    subject.Clear();
                    Console.WriteLine("Please input the available subject. Press to Continue.");
                    Console.ReadLine();
                    RegisterStudentSubject();
                }
            }

            Console.WriteLine("Register Subject Done. Press to Continue.");
            Console.ReadLine();
            YouAreStudent();
        }

        static void ShowGrade()
        {
            if (Grade == 'z')
            {
                Console.WriteLine("The teacher hasn't submitted your grade yet. Press to Continue.");
            }
            else
            {
                Console.WriteLine("Your Grade is: {0}. Press to Continue.", Grade);
            }

            Console.ReadLine();
            YouAreStudent();
        }

        static void YouAreTeacher()
        {
            Console.Clear();

            Console.WriteLine("1. Register Teacher Information");
            Console.WriteLine("2. Submit the student Grade");
            Console.WriteLine("3. Show the registered subject of your student.");
            Console.WriteLine("4. Back");
            Console.Write("Input: ");
            int TeacherMenu = int.Parse(Console.ReadLine());

            switch(TeacherMenu)
            {
                case 1:
                    RegisterTeacherInformation();
                break;
                case 2:
                    RegisterGrade();
                break;
                case 3:
                    ShowRegisteredSubject();
                    break;
                case 4:
                    DistinguishJobMenu();
                    break;
                default:
                    Console.WriteLine("Please input the available menu. Press to Continue.");
                    Console.ReadLine();
                    YouAreTeacher();
                    break;
            }
        }

        static void RegisterTeacherInformation()
        {
            Console.Clear();

            Console.WriteLine("Please Input your Information.");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("ID: ");
            string id = Console.ReadLine();

            AddTeacherInformationToList(name, id);
        }

        static void AddTeacherInformationToList(string name, string id)
        {
            Program.teacher = new Person(name, id);
            Console.WriteLine("Register teacher Done. Press to Continue.");
            Console.ReadLine();
            YouAreTeacher();
        }

        static void RegisterGrade()
        {
            Console.Write("Please input the student grade: ");
            Grade = char.Parse(Console.ReadLine());
            Console.WriteLine("You submitted the student grade. Press to Continue.");
            Console.ReadLine();
            YouAreTeacher();
        }

        static void ShowRegisteredSubject()
        {
            if (subject.Count == 0)
            {
                Console.WriteLine("They haven't registered any subject yet. Press to Continue.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("They enrolled in these subjects below this year. Press to Continue.");
                foreach (string Subject in subject)
                {
                    Console.WriteLine(Subject);
                }
            }

            Console.ReadLine();
            YouAreTeacher();
        }
    }
}
