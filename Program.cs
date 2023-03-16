using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

/*namespace delegates_sharp
{
    internal class Program
    {
        // 1. Action<T> - обеспечивает вызов методов, которые ничего не возвращают void (принимают до 16-ти параметров) - List<T>, ForEach()
        // Используют при вызове различных методов стандартных классов имен System

        // 2. Func<TResult> - T (до 16-ти параметров) - Enumerable - Select<TSource, TResult>

        // 3. Predicate<T> bool (1 param) Array List<T> FindAll()

        // 4. Comparison<T> int (2 param) Sort(Comparison<T>)



        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName} {BirthDate.ToShortDateString()}";
            }
        }

        *//*static void FullName(Student st) // action
        {
            WriteLine($"{st.LastName} {st.FirstName}");
        }*/
       /* static string FullName(Student st) // func
        {
            return $"{st.LastName} {st.FirstName}";
        }*/

        /*static bool BD_Spring(Student st) // predicate
        {
            return st.BirthDate.Month >= 3 && st.BirthDate.Month <= 5;
        }*/

       /* static int SortBD(Student st1, Student st2) // comparison 
        {
            return st1.BirthDate.CompareTo(st2.BirthDate);
        }

        static int SortLN(Student st1, Student st2) // comparison 
        {
            return st1.LastName.CompareTo(st2.LastName);
        }*//*
        static void Main(string[] args)
        {

            *//*List<Student> group = new List<Student> {
                new Student {
                FirstName = "John",
                LastName = "Miller",
                BirthDate = new DateTime(1997,3,12)
                },
                new Student {
                FirstName = "Candice",
                LastName = "Leman",
                BirthDate = new DateTime(1998,7,22)
                },
                new Student {
                FirstName = "Joey",
                LastName = "Finch",
                BirthDate = new DateTime(1996,11,30)
                },
                new Student {
                FirstName = "Nicole",
                LastName = "Taylor",
                BirthDate = new DateTime(1996,5,10)
                }
            };*//*

            //group.ForEach(FullName); // action

            *//* IEnumerable<string> students = group.Select(FullName); // func
             foreach (string item in students)
             {
                 WriteLine(item);
             }*/

            /*List<Student> st_spring = group.FindAll(BD_Spring); // predicate

            foreach (Student item in st_spring)
            {
                WriteLine(item);
            }*/

            /*group.Sort(SortBD); // comparison
            foreach (Student item in group)
            {
                WriteLine(item);
            }

            group.Sort(SortLN); // comparison
            foreach (Student item in group)
            {
                WriteLine(item);
            }*//*



            // EVENT

            //[модификатор доступа] event NAmeDelegate NameEvent
        }
    }
}*/

namespace events_sharp
{
    // EVENT

    //[модификатор доступа] event NAmeDelegate NameEvent
    /*internal class Program
    {
        public delegate void ExamDelegate(string str); // 2 (те же сигнатуры что в методе студента)

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName} {BirthDate.ToShortDateString()}";
            }

            public void Exam(string task) // 1 (мы знаем событие и реакцию на него)
            {
                WriteLine($"{LastName} solved the {task}");
            }
        }

        class Teacher
        {
            public event ExamDelegate examEvent; // 3 создаём событие (типа делегата)

            public void Exam (string task) // 4
            {
                if(examEvent!= null) // 5 существует ли у нас обработчик полписавшийся на событие 
                {
                    examEvent(task); // 6
                }
            }
        }

       
        static void Main(string[] args)
        {

            List<Student> group = new List<Student> {
                new Student {
                FirstName = "John",
                LastName = "Miller",
                BirthDate = new DateTime(1997,3,12)
                },
                new Student {
                FirstName = "Candice",
                LastName = "Leman",
                BirthDate = new DateTime(1998,7,22)
                },
                new Student {
                FirstName = "Joey",
                LastName = "Finch",
                BirthDate = new DateTime(1996,11,30)
                },
                new Student {
                FirstName = "Nicole",
                LastName = "Taylor",
                BirthDate = new DateTime(1996,5,10)
                }
            };

            Teacher t = new Teacher();
            foreach (Student item in group)
            {
                t.examEvent += item.Exam; // 7 подписка на событие (мультикастинг делегат)
            }
            t.Exam("Task_1");

            // 
        }
    }
}*/

    // GENERIC EVENTS
    /*internal class Program
    {
        class ExamEventArguments : EventArgs // 1 (создали ради того чтобы создать task)
        {
            public string task { get; set; } 
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime BirthDate { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName} {BirthDate.ToShortDateString()}";
            }

            public void Exam(object sender, ExamEventArguments e) // 2 - реакция на событие у подписчика 
            {
                WriteLine($"{LastName} solved the {e.task}");
            }
        }

        class Teacher
        {
            public EventHandler<ExamEventArguments> examEvent; // 3

            public void Exam(ExamEventArguments task) // 4
            {
                if (examEvent != null) 
                {
                    examEvent(this, task); 
                }
            }
        }


        static void Main(string[] args)
        {

            List<Student> group = new List<Student> {
                new Student {
                FirstName = "John",
                LastName = "Miller",
                BirthDate = new DateTime(1997,3,12)
                },
                new Student {
                FirstName = "Candice",
                LastName = "Leman",
                BirthDate = new DateTime(1998,7,22)
                },
                new Student {
                FirstName = "Joey",
                LastName = "Finch",
                BirthDate = new DateTime(1996,11,30)
                },
                new Student {
                FirstName = "Nicole",
                LastName = "Taylor",
                BirthDate = new DateTime(1996,5,10)
                }
            };

            Teacher t = new Teacher();
            foreach (Student item in group)
            {
                t.examEvent += item.Exam; // 5 (генерирует Teacher, студенты подписываются, происходит мултькастинг делегат)
            }
            ExamEventArguments ea = new ExamEventArguments { task = "Task_1" }; 
            t.Exam(ea);

            
        }
    }*/



    // МНОГОАДРЕСНЫЙ ДЕЛЕГАТ 

    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public void Exam(string task)
        {
            WriteLine($"Student {LastName} solved the {task}");
        }
    }
    class Teacher
    {
        public event ExamDelegate examEvent;
        public void Exam(string task)
        {
            if (examEvent != null)
            {
                examEvent(task);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher();
            Student student = new Student();
            Student student2 = new Student();
            teacher.examEvent += student.Exam;
            teacher.examEvent += student2.Exam;
            teacher.Exam("Task_1");
            teacher.Exam("****************************************");
            teacher.examEvent -= student2.Exam;
            // teacher.examEvent = student.Exam; // Error
            teacher.Exam("Task_2");
        }
    }
}