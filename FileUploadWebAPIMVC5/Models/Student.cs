using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadWebAPIMVC5.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Activity { get; set; }
    }
    public interface IStudentsGenerator
    {
        List<Student> GenerateStudents(int NoOfStudents);
    }
    public class GoodStudentsGenerator : IStudentsGenerator
    {
        public List<Student> GenerateStudents(int NoOfStudents)
        {
            List<Student> students = new List<Student>();
            Random rd = new Random();
            for (int i = 1; i <= NoOfStudents; i++)
            {
                Student student = new Student();
                student.ID = i;
                student.Name = "Name No." + i.ToString();

                // This generates integer scores between 80 - 100
                student.Score = Convert.ToInt16(80 + rd.NextDouble() * 20);
                student.Activity = "Working - Good";

                students.Add(student);
            }

            return students;
        }
    }
    public class BadStudentsGenerator : IStudentsGenerator
    {
        public List<Student> GenerateStudents(int NoOfStudents)
        {
            List<Student> students = new List<Student>();
            Random rd = new Random();
            for (int i = 1; i <= NoOfStudents; i++)
            {
                Student student = new Student();
                student.ID = i;
                student.Name = "Name No." + i.ToString();

                // This generates integer scores between 0 - 40
                student.Score = Convert.ToInt16(40 * rd.NextDouble());
                student.Activity = "Gambling - Bad";

                students.Add(student);
            }

            return students;
        }
    }
}