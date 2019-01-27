using System;
using System.Collections.Generic;

namespace Mediater
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediater mediater = new Mediater();

            Teacher can = new Teacher(mediater);
            can.Name = "Can";

            mediater.can = can;

            Student asım = new Student(mediater);

        }
    }

    abstract class CourseMember
    {
        private Mediater _mediater;

        protected CourseMember(Mediater mediater)
        {
            _mediater = mediater;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediater mediater) : base(mediater)
        {

        }

        public void ReciveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question form {0},{1}", student.Name, question);
        }

        public void SendNewImageUrlstri)
    }

    class Student : CourseMember
    {
        public Student(Mediater mediater) : base(mediater)
        {
        }

        public void ReciceImage(string url)
        {
            Console.WriteLine("Student received image : {0}", url);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student received answer : {0}", answer);
        }

        public string Name { get; set; }
    }

    class Mediater
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReciceImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReciveQuestion(question, student);
        }

        public void SendAnswer(string name, Student student)
        {
            student.ReceiveAnswer(answer);
        }

        public void SendNewImage(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            
        }
    }
}
