using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Academy
{
    class Exam
    {
        public string LessonName { get; set; }
        public int Score { get; set; }
        public Exam() { }
        public Exam(string lesson,int score)
        {
            LessonName = lesson;
            Score = score;
        }
        public void Show()
        {
            Console.WriteLine($"Lesson: {LessonName}");
            Console.WriteLine($"Score: {Score}");
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();
        public Student() { }
        public Student(string name,string email)
        {
            Name = name;
            Email = email;
        }
        public void AddExam(Exam exam)
        {
            Exams.Add(exam);
        }
        public void Show()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            for (int i = 0; i < Exams.Count; i++)
            {
                Console.Write($"[{i + 1}]  ");
                Console.WriteLine($"{Exams[i].LessonName}");
            }
        }
    }
    class Group
    {
        public string GroupName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Group() { }
        public Group(string groupname)
        {
            GroupName = groupname;
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void ShowGroup()
        {
            Console.WriteLine($"Group name: {GroupName}\n");
            for (int i = 0; i < Students.Count; i++)
            {
                Console.Write($"[{i+1}]  ");
                Console.WriteLine($"{Students[i].Name}");
            }
        }
    }
    class Teacher
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public Teacher() { }
        public Teacher(string name)
        {
            Name = name;
        }
        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }
        public void ShowTeacher()
        {
            Console.WriteLine($"Teacher name: {Name}\n");
            for (int i = 0; i < Groups.Count; i++)
            {
                Console.Write($"[{i + 1}]  ");
                Console.WriteLine($"{Groups[i].GroupName}");
            }
        }
    }
    class Academy
    {
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public Academy() { }
        public Academy(string name)
        {
            Name = name;
        }
        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
        public void ShowAcademy()
        {
            Console.WriteLine($@"                <<<<<<< {Name} >>>>>>>>>>");
            Console.WriteLine("\nTeachers");
            for (int i = 0; i < Teachers.Count; i++)
            {
                Console.Write($"[{i + 1}]  ");
                Console.WriteLine($"{Teachers[i].Name}");
            }
        }
    }
    class Run
    {
        public void CreatObject()
        {
            Exam exam1 = new Exam
            {
                LessonName = "mathematics",
                Score = 70
            };
            Exam exam2 = new Exam
            {
                LessonName = "mathematics",
                Score = 50
            };
            Exam exam3 = new Exam
            {
                LessonName = "mathematics",
                Score = 90
            };
            Exam exam4 = new Exam
            {
                LessonName = "physics",
                Score = 95
            };
            Exam exam5 = new Exam
            {
                LessonName = "physics",
                Score = 58
            };
            Exam exam6 = new Exam
            {
                LessonName = "chemistry",
                Score = 90
            };
            Student s1 = new Student
            {
                Name = "Aynur",
                Email = "Aynur@gmail.com"
            };
            s1.AddExam(exam1);
            s1.AddExam(exam6);
            s1.AddExam(exam5);
            Student s2 = new Student
            {
                Name = "Nuran",
                Email = "Nuran@gmail.com"
            };
            s2.AddExam(exam2);
            s2.AddExam(exam4);
            Student s3 = new Student
            {
                Name = "Elcin",
                Email = "Elcin@gmail.com"
            };
            s3.AddExam(exam3);

            Student s4 = new Student
            {
                Name = "Aydan",
                Email = "Aydan@gmail.com"
            };
            s4.AddExam(exam2);
            s4.AddExam(exam4);
            Student s5 = new Student
            {
                Name = "Miri",
                Email = "Miri@gmail.com"
            };
            s5.AddExam(exam3);

            Group gr1 = new Group
            {
                GroupName = "751"
            };
            gr1.AddStudent(s1);
            gr1.AddStudent(s2);
            gr1.AddStudent(s3);
            Group gr2 = new Group
            {
                GroupName = "769"
            };
            gr2.AddStudent(s4);
            gr2.AddStudent(s5);

            Group gr3 = new Group
            {
                GroupName = "887"
            };
            gr3.AddStudent(s3);
            gr3.AddStudent(s5);
            gr3.AddStudent(s1);

            Teacher teacher1 = new Teacher
            {
                Name = "Vaqif"
            };
            teacher1.AddGroup(gr1);
            teacher1.AddGroup(gr2);
            Teacher teacher2 = new Teacher
            {
                Name = "Turxan"
            };
            teacher2.AddGroup(gr3);

            Academy academy = new Academy
            {
                Name = "Step IT Academy"
            };
            academy.AddTeacher(teacher1);
            academy.AddTeacher(teacher2);
            Display(academy);
        }
        public void Display(Academy academy)
        {
            academy.ShowAcademy();
            Console.Write("Choose teacher: ");
            string ch = Console.ReadLine();
            Console.Clear();
            if (ch == "1")
            {
                Display1(academy);
            }
            else if (ch == "2")
            {
                Display2(academy);
            }
            else
            {
                Console.WriteLine("Wrong entered");
                Display(academy);
            }
        }
        public void Display1(Academy academy)
        {
            academy.Teachers[0].ShowTeacher();
            Console.WriteLine("[0] Back");
            Console.Write("Choose : ");
            string ch = Console.ReadLine();
            Console.Clear();
            int c = int.Parse(ch);
            var group = academy.Teachers[0].Groups;

            if (c > 0 && c <= group.Count) 
            {
                var gr = group[c - 1];
                Display3(gr,academy,1);
            }
            else if (c == 0)
            {
                 Display(academy);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong entered");
                Display1(academy);
            }
        }
        public void Display2(Academy academy)
        {
            academy.Teachers[1].ShowTeacher();
            Console.WriteLine("[0] Back");
            Console.Write("Choose : ");
            string ch = Console.ReadLine();
            Console.Clear();
            int c = int.Parse(ch);
            var group = academy.Teachers[1].Groups;

            if (c > 0 && c <= group.Count)
            {
                var gr = group[c - 1];
                Display3(gr, academy, 1);
            }
            else if (c == 0) 
            {
                Display(academy);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong entered");
                Display2(academy);
            }
        }
        public void Display3(Group group,Academy academy,int disp)
        {
            group.ShowGroup();
            Console.WriteLine("[0] Back");
            Console.Write("Choose : ");
            string ch = Console.ReadLine();
            Console.Clear();
            int c = int.Parse(ch);
            var st = group.Students;

            if (c > 0 && c <= st.Count)
            {
                var stud = st[c - 1];
                Display4(stud, academy, disp, group);
            }
            else if (c == 0) 
            {
                if (disp == 1)
                {
                    Display1(academy);
                }
                else
                {
                    Display2(academy);
                }
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong entered");
                Display3(group,academy,disp);
            }

        }
        public void Display4(Student st, Academy academy, int disp,Group gr)
        {
            st.Show();
            Console.WriteLine("[0] Back");
            Console.Write("Choose : ");
            string ch = Console.ReadLine();
            Console.Clear();
            int c = int.Parse(ch);
            var ex = st.Exams;

            if (c > 0 && c <= ex.Count)
            {
                var exam = ex[c - 1];
                Display5(exam, academy, disp,gr,st);
            }
            else if (c == 0)
            {
                Display3(gr, academy, disp);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong entered");
                Display4(st,academy,disp,gr);
            }

        }
        public void Display5(Exam exam, Academy a, int d, Group g,Student s)
        {
            exam.Show();

            Console.WriteLine("[1] Send e-mail");
            Console.WriteLine("[0] Back");
            Console.Write("Choose : ");
            string ch = Console.ReadLine();
            Console.Clear();

            if (ch == "1") 
            {
                SendMail(exam,a);
            }
            else if (ch == "0")
            {
                Display4(s,a,d,g);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Wrong entered");
                Display5(exam, a, d, g, s);
            }
        
        }
        public void SendMail(Exam exam,Academy a)
        {
            Console.Write("Enter mail: ");
            string mail = Console.ReadLine();

            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            client.Credentials = new NetworkCredential("lalamuradova2021@outlook.com", "lala1995");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            message.To.Add(mail);
            message.From = new MailAddress("lalamuradova2021@outlook.com", "Step IT Academy");
            message.Subject = "Exam score";
            message.Body = "Your score = " + exam.Score;
            client.Send(message);
            Console.Clear();
            Console.WriteLine("Score sent\n");
            Display6(a);
            
        }
        public void Display6(Academy a)
        {
            Console.WriteLine("[0] Back");
            Console.Write("Choose : ");
            string ch = Console.ReadLine();
            Console.Clear();

            if (ch == "0")
            {
                Display(a);
            }
            else
            {
                Console.WriteLine("Wrong entered");
                Display6(a);
            }
        }
    }
    class Program
    {
     
        static void Main(string[] args)
        {
            Run run = new Run();
            run.CreatObject();




        }
    }
}
