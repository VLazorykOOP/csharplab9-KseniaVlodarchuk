using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int GroupNumber { get; set; }
        public int[] Grades { get; set; }

        public Student(string lastName, string firstName, string middleName, int groupNumber, int[] grades)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            GroupNumber = groupNumber;
            Grades = grades;
        }
        public Student()
        {
            
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, Група: {GroupNumber}, Оцiнки: {string.Join(", ", Grades)}";
        }
        public void Run()
        {
                string filePath = "input.txt";
                Queue<Student> excellentStudents = new Queue<Student>();
                Queue<Student> otherStudents = new Queue<Student>();

                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            string[] name = parts[0].Split(" ");
                            string lastName = name[0];
                            string firstName = name[1];
                            string middleName = name[2];
                            int groupNumber = int.Parse(parts[1]);
                            int[] grades = Array.ConvertAll(parts[2].Split(' '), int.Parse);

                            Student student = new Student(lastName, firstName, middleName, groupNumber, grades);
                            if (student.Grades[0] >= 4 && student.Grades[1] >= 4 && student.Grades[2] >= 4)
                            {
                                excellentStudents.Enqueue(student);
                            }
                            else
                            {
                                otherStudents.Enqueue(student);
                            }
                        }
                    }

                    Console.WriteLine("Студенти, якi успiшно навчаються на 4 i 5:");
                    while (excellentStudents.Count > 0)
                    {
                        Console.WriteLine(excellentStudents.Dequeue());
                    }

                    Console.WriteLine("\nРешта студентiв:");
                    while (otherStudents.Count > 0)
                    {
                        Console.WriteLine(otherStudents.Dequeue());
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл не знайдено.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        public void RunArrayList()
        {
            string filePath = "input.txt";
            ArrayList excellentStudents = new ArrayList();
            ArrayList otherStudents = new ArrayList();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string[] name = parts[0].Split(" ");
                        string lastName = name[0];
                        string firstName = name[1];
                        string middleName = name[2];
                        int groupNumber = int.Parse(parts[1]);
                        int[] grades = Array.ConvertAll(parts[2].Split(' '), int.Parse);

                        Student student = new Student(lastName, firstName, middleName, groupNumber, grades);
                        if (student.Grades[0] >= 4 && student.Grades[1] >= 4 && student.Grades[2] >= 4)
                        {
                            excellentStudents.Add(student);
                        }
                        else
                        {
                            otherStudents.Add(student);
                        }
                    }
                }

                Console.WriteLine("Студенти, які успішно навчаються на 4 і 5:");
                foreach (Student student in excellentStudents)
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine("\nРешта студентів:");
                foreach (Student student in otherStudents)
                {
                    Console.WriteLine(student);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не знайдено.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка: {ex.Message}");
            }
        }

        }
    }
