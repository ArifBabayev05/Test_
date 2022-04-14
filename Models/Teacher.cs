using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace ConsoleApp23.Models
{
    public class Teacher
    {
        private static int _idCounter;


        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        static Teacher()
        {
            List<Teacher> teachers = new List<Teacher>();
            var lines = Program.ReadFiles("dataBase");


            foreach (var item in lines)
            {
                Teacher teacher = JsonSerializer.Deserialize<Teacher>(item);
                teachers.Add(teacher);
            }

            _idCounter = teachers[^1].Id;
        }
        private Teacher()
        {
            Id = ++_idCounter;
        }
        public Teacher(string name, string surname) : this()
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
