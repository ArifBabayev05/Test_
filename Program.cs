using System;
using System.IO;
using ConsoleApp23.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace ConsoleApp23
{
    public class Program
    {
        static void Main(string[] args)
        {

            //CreateNewStudent();


            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();

            var Lines = ReadFiles("Student-dataBase");
            var Lines2 = ReadFiles("Teacher-dataBase");

            foreach (var item in Lines)
            {
                Student student1 = JsonSerializer.Deserialize<Student>(item);

                foreach (var childs in students)
                {
                    Console.WriteLine(childs.ToString());
                }

            }
            foreach (var item in Lines2)
            {
                Teacher student1 = JsonSerializer.Deserialize<Teacher>(item);

                foreach (var childs in teachers)
                {
                    Console.WriteLine(childs.ToString());
                }

            }


        }
        public static IEnumerable<string> ReadFiles(string fileName)
        {
            string fileDirectary = GetFileDirectory(fileName);
            return File.ReadLines(fileDirectary);
        }

        public static void PrintFile(string fileName, string Info)
        {
            string textFileForStudents = GetFileDirectory(fileName);

            StreamWriter streamWriter = new(textFileForStudents);

            streamWriter.WriteLine(Info);
            streamWriter.Dispose();
        }
        public static void PrintFileTeacher(string fileName, string Info)
        {
            string textFileForTeachers = GetFileDirectoryForTeacher(fileName);

            StreamWriter streamWriter = new(textFileForTeachers);

            streamWriter.WriteLine(Info);
            streamWriter.Dispose();
        }
        //Create Folder And File

        //For Students
        public static string GetFileDirectory(string fileName)
        {
            string root = @"/Users/babayev_/Desktop/ConsoleApp23/";

            string modelsFolderForStudent = Path.Combine(root, "SchoolInfo");
            if (!Directory.Exists(modelsFolderForStudent))
            {
                Directory.CreateDirectory(modelsFolderForStudent);
            }

            string textFileForStudents = Path.Combine(modelsFolderForStudent, $"{fileName}.txt");
            if (!File.Exists(textFileForStudents))
            {
                File.Create(textFileForStudents);
            }
            return textFileForStudents;
        }

        //For Teachers
        public static string GetFileDirectoryForTeacher(string teacherFileName)
        {
            string root = @"/Users/babayev_/Desktop/";

            string modelsFolderForTeacher = Path.Combine(root, "Teacher");
            if (!Directory.Exists(modelsFolderForTeacher))
            {
                Directory.CreateDirectory(modelsFolderForTeacher);
            }

            string textFileForTeachers = Path.Combine(modelsFolderForTeacher, $"{teacherFileName}.txt");
            if (!File.Exists(textFileForTeachers))
            {
                File.Create(textFileForTeachers);
            }
            return textFileForTeachers;
        }

        //All Infos(Both of)
        public static string GetAllInfos(string output)
        {
            TryAgain:
            Console.Write($"Please Enter Your {output}: ");
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"{output} Can't Be Empty!");
                goto TryAgain;
            }
            return input;
        }


        //Create

        //For Students
        public static Student CreateNewStudent()
        {
            string name = GetAllInfos("name");
            string surname = GetAllInfos("surname");
            Student student = new Student(name, surname);
            var ser = JsonSerializer.Serialize(student);

            PrintFile("dataBase", ser);
            return student;

        }
        //For Teachers
        public static Teacher CreateNewTeacher()
        {
            string name = GetAllInfos("name");
            string surname = GetAllInfos("surname");
            Teacher teacher = new Teacher(name, surname);
            var ser = JsonSerializer.Serialize(teacher);

            PrintFile("dataBase", ser);
            return teacher;

        }




    }

}

 
