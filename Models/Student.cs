using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp23.Models
{
    public class Student
    {
        private static int _idCounter;


        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        private static int GetLastUserID()
        {
            List<Student> students = new List<Student>();
            var lines = Program.ReadFiles("dataBase");

            try
            {
                foreach (var item in lines)
                {
                    Student student = JsonSerializer.Deserialize<Student>(item);
                    students.Add(student);
                }

                return students[^1].Id;

            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        private Student()
        {
            Id = ++_idCounter;
        }
        public Student(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return $"{Id} {Name} {Surname}";
        }

        public string GetFullName()
        {
            return $"{Name} {Surname}";
        }

    }
}
