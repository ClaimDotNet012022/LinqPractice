using System;
using System.Collections.Generic;

namespace LinqPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var courses = new List<Course>
            {
                new Course {Id = 1, Name = "Calculus", Credits = 3 },
                new Course {Id = 2, Name = "Physics", Credits = 4 },
                new Course {Id = 3, Name = "Psychology", Credits = 1 },
                new Course {Id = 4, Name = "Underwater Basketweaving", Credits = 0 },
            };

            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Alice",
                    Age = 20,
                    EnrolledCourseId = 3
                },
                new Student
                {
                    Id = 2,
                    Name = "Bob",
                    Age = 23,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Charlie",
                    Age = 19,
                    EnrolledCourseId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Diane",
                    Age = 20,
                    EnrolledCourseId = 4
                },
                new Student
                {
                    Id = 5,
                    Name = "Elliot",
                    Age = 21,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 6,
                    Name = "Frank",
                    Age = 18,
                    EnrolledCourseId = 3
                },
            };

        }
    }
}
