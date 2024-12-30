using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace assignment
{
    public class Courses
    {
        public string course_title { get; set; }
        public int course_duration { get; set; }
        public decimal course_fee { get; set; }
        public Courses(string ct,int cd,decimal cf)
        {
            course_title=ct;
            course_duration=cd;
            course_fee=cf;
        }
    }
    public class person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int NIDCardNumber { get; set; }
        public string Email { get; set; }
        public person(string name,DateTime birthdate,string address,int nid,string email)
        {
            Name = name;
            DateOfBirth = birthdate;
            Address = address;
            NIDCardNumber = nid;
            Email = email;
        }
    }

    public class Student : person
    {
        public DateTime Admission_date { get; set; }
        public string Completed_course { get; set; }
        public Student(string name,DateTime birthdate,string address,int nid,string email,DateTime admission,string course):base(name,birthdate,address,nid,email)
        {
            Admission_date = admission;
            Completed_course = course;
        }
        public int Age(DateTime dateofbirth)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - dateofbirth.Year;
            if (dateofbirth.Date > today.AddYears(-age)) age--;
            return age;
        }
        public static int Avg_age(int[] age, int students)
        {
            int total_age = 0;
            for (int i = 0; i < age.Length; i++)
            {
                total_age += age[i];
            }
            return total_age / students;
        }
    }
    public class Tutor : person
    {
        public int Salary { get; set; }
        public Courses[] Course_teach { get; set; }
        public Tutor(string name, DateTime birthdate, string address, int nid, string email, int salary, Courses [] course_teach) : base(name, birthdate, address, nid, email)
        {
            Salary = salary;
            Course_teach = course_teach;
        }
    }
    public class Staff : person
    {
        public int salary { get; set; }
        public Staff(string name, DateTime birthdate, string address, int nid, string email, int salary) : base(name, birthdate, address, nid, email)
        {
            this.salary = salary;
        }
    }
    class program
    {
        static void Main(string[] args)
        { 
            Courses courses1 = new Courses("c# fundamentals",3,1000m);
            Courses courses2 = new Courses("java basics",4,2000m);
            Courses courses3 = new Courses("python",2,500m);
            Courses[] course = { courses1, courses2, courses3 };

            Student stu1 = new Student("Riya", new DateTime(2004, 1, 20), "ctg", 220431, "u201@gmail.com", new DateTime(2020, 1, 31), "c# fundamental");
            Student stu2 = new Student("Haya", new DateTime(2000, 1, 4), "ctg", 240378, "haya@gmail.com", new DateTime(2022, 3, 5), "java basics");
            Student stu3 = new Student("Sharmila", new DateTime(2003, 5, 3), "ctg", 223893, "sharmila@gmail.com", new DateTime(2023, 6, 7), "python");

            Tutor tu1 = new Tutor("Murad", new DateTime(1997, 4, 5), "dhaka", 289345, "murad@gmail.com", 12000,new Courses[] { courses1, courses2 });
            Tutor tu2 = new Tutor("Hasan", new DateTime(1990, 2, 3), "narayanganj", 349800, "hasan@gmail.com", 13000, new Courses[] { courses2 });
            Tutor tu3 = new Tutor("Animesh", new DateTime(1996, 4, 7), "sylhet", 348642, "animesh@gmail.com", 34000, new Courses[] { courses2, courses3 });

            Staff staff1 = new Staff("Enum", new DateTime(1956, 2, 5), "ctg", 234893, "enum@gmail.com", 230);
            Staff staff2 = new Staff("Karim", new DateTime(1987, 3, 5), "noakhali", 348689, "karim@gmail.com", 340);
            Staff staff3 = new Staff("Jashim", new DateTime(1985, 5, 3), "ctg", 348678, "jashim@gmail.com", 324);

            List<person> persons = new List<person>{ stu1, stu2, stu3, tu1, tu2, tu3, staff1, staff2, staff3 };
            int student_count = persons.OfType<Student>().Count();
            Console.WriteLine($"no. of students : {student_count}");
            Console.WriteLine($"no. of tutors : {persons.OfType<Tutor>().Count()}");
            Console.WriteLine($"no. of staffs : {persons.OfType<Staff>().Count()}");
            Console.WriteLine($"no. of total persons : {persons.Count()}");
            Console.WriteLine($"no. of courses: {course.Length}");

            int[] age = new int[]
            {
                stu1.Age(stu1.DateOfBirth),stu2.Age(stu2.DateOfBirth),stu3.Age(stu3.DateOfBirth)
            };
            Console.WriteLine($"average age is: {Student.Avg_age(age, student_count)}");
        }
    }
}
