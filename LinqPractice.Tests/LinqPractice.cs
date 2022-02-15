using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice.Tests
{
    [TestClass]
    public class LinqPractice
    {
        private List<Course> _courses;
        private List<Student> _students;

        [TestInitialize]
        public void Setup()
        {
            _courses = new List<Course>
            {
                new Course {Id = 1, Name = "Calculus", Credits = 3 },
                new Course {Id = 2, Name = "Physics", Credits = 4 },
                new Course {Id = 3, Name = "Psychology", Credits = 1 },
                new Course {Id = 4, Name = "Underwater Basketweaving", Credits = 0 },
            };

            _students = new List<Student>
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


        [TestMethod]
        public void GetNames()
        {
            //1.Use LINQ to get just the names of all the students. Iterate over the result to print the names.
            IEnumerable<string> names = _students.Select(s => s.Name);

            // Within this test, don't change any code below this line.
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Assert.IsTrue(names.SequenceEqual(new[] { "Alice", "Bob", "Charlie", "Diane", "Elliot", "Frank" }));
        }

        [TestMethod]
        public void ModifyCollectionBeforeMaterializing()
        {
            // The point of this test is to show what happens if you modify a collection
            // before getting any results out of a LINQ query.
            // Remember: Until you do something that materializes values (e.g., do a foreach loop,
            //           call an aggregate method, convert to a List, call First(), etc.), the
            //           LINQ query is just an execution plan.

            // 2A. Use the SAME exact solution here that you used in GetNames()
            IEnumerable<string> names = _students.Select(s => s.Name);

            // Don't change any code below here, but DO look at the code to understand what it's doing)

            // 2B. Modify the underlying _students collection (in this case, I'm changing one name
            //     and appending another.
            _students[2].Name = "Chad";
            _students.Add(new Student { Name = "Gigi", Age = 20, EnrolledCourseId = 1 });

            // 2C: Materialize results
            List<string> namesList = names.ToList();

            foreach (string name in namesList)
            {
                Console.WriteLine(name);
            }

            Assert.IsFalse(namesList.SequenceEqual(new[] { "Alice", "Bob", "Charlie", "Diane", "Elliot", "Frank" }));
            Assert.IsTrue(namesList.SequenceEqual(new[] { "Alice", "Bob", "Chad", "Diane", "Elliot", "Frank", "Gigi" }));
        }

        [TestMethod]
        public void ModifyCollectionAfterMaterializing()
        {
            // The point of this test is to show what happens if you modify a collection
            // after materializing results out of a LINQ query.
            // Remember: Once you have an actual value (or a collection of values),
            //           that value is no longer connected to the underlying collection.

            // 2A. Use the SAME exact solution here that you used in GetNames()
            IEnumerable<string> names = _students.Select(s => s.Name);

            // Don't change any code below here, but DO look at the code to understand what it's doing)

            // 2B: Materialize results FIRST
            List<string> namesList = names.ToList();

            // 2C. THEN modify the underlying _students collection
            _students[2].Name = "Chad";
            _students.Add(new Student { Name = "Gigi", Age = 20, EnrolledCourseId = 1 });

            foreach (string name in namesList)
            {
                Console.WriteLine(name);
            }

            Assert.IsFalse(namesList.SequenceEqual(new[] { "Alice", "Bob", "Chad", "Diane", "Elliot", "Frank", "Gigi" }));
            Assert.IsTrue(namesList.SequenceEqual(new[] { "Alice", "Bob", "Charlie", "Diane", "Elliot", "Frank" }));
        }

        [TestMethod]
        public void WhereAndCount()
        {
            //4.Use LINQ to get all the students enrolled in Course ID 3.
            //(In other words, all the students where the EnrolledCourseId == 3)Print the count of the result(Count()).
            IEnumerable<Student> course3Students = _students.Where(s => s.EnrolledCourseId == 3);

            //4B. Now find how many students are in Course ID 3.
            int course3Count = course3Students.Count();

            Assert.AreEqual(2, course3Count);


            //4C. Do the same aa above, but using method chaining to combine the two steps
            //    into a single statement.
            //    Example: int count2 = _students.Method(params).OtherMethod(params)
            int count2 = _students.Where(s => s.EnrolledCourseId == 3).Count();

            Assert.AreEqual(2, count2);

            //4D. Do the same above, but pass a predicate into the Count() method, so
            //    you only need one method call.
            //    Example: int count3 = _students.Count(s => s.SomeProperty == SomeValue)
            int count3 = _students.Count(s => s.EnrolledCourseId == 3);

            Assert.AreEqual(2, count3);
        }


        [TestMethod]
        public void OldStudents()
        {
            //5A. Use LINQ to get all the students who are at least 21 years old.
            IEnumerable<Student> oldStudents = _students.Where(s => s.Age >= 21);

            //5B. Now get just the NAMES of those students.
            IEnumerable<string> oldNames = oldStudents.Select(s => s.Name);

            Console.WriteLine("oldNames:");
            foreach(string name in oldNames)
            {
                Console.WriteLine(name);
            }

            Assert.IsTrue(oldNames.SequenceEqual(new[] {"Bob", "Elliot" }));

            //5C. Do the same as above, but use method chaining to do it in one statement.
            IEnumerable<string> oldNames2 = _students.Where(s => s.Age >= 21).Select(s => s.Name);

            Console.WriteLine("oldNames2:");
            foreach (string name in oldNames2)
            {
                Console.WriteLine(name);
            }

            Assert.IsTrue(oldNames.SequenceEqual(new[] { "Bob", "Elliot" }));            
        }

        [TestMethod]
        public void CoursesWithAtLeast2Credits()
        {
            //6. Use LINQ to get JUST the NAMES of all the courses worth at least 2 credits.
            IEnumerable<string> goodCourseNames = _courses.Where(c => c.Credits >= 2).Select(c => c.Name);

            foreach(var courseName in goodCourseNames)
            {
                Console.WriteLine(courseName);
            }

            Assert.IsTrue(goodCourseNames.SequenceEqual(new[] { "Calculus", "Physics" }));
        }

        [TestMethod]
        public void Aggregates()
        {
            //7. Use LINQ to find the average age of the students (don't worry about casting to
            //float/double, just use the integer ages as they are).
            double averageAge = _students.Average(s => s.Age);

            Assert.AreEqual(20.166666666, averageAge, 0.000000001);

            //8. Use LINQ and method chaining to find the average age of the students
            //   enrolled in Course ID 1.
            double course1AverageAge = _students.Where(s => s.EnrolledCourseId == 1).Average(s => s.Age);

            Assert.AreEqual(22.0, course1AverageAge, 0.000000001);

            //9. Find the highest age from all the students
            int highestAge = _students.Max(s => s.Age);

            Assert.AreEqual(23, highestAge);

        }

        [TestMethod]
        public void Ordering()
        {
            //10. Use LINQ to order the students by age, youngest first.
            IEnumerable<Student> orderedStudents = _students.OrderBy(s => s.Age);

            foreach(Student student in orderedStudents)
            {
                Console.WriteLine(student.Name);
            }

            Assert.AreEqual(18, orderedStudents.First().Age);
            Assert.AreEqual(23, orderedStudents.Last().Age);

            //11. Use LINQ to order the students by age, oldest first.
            IEnumerable<Student> reversedStudents = _students.OrderByDescending(s => s.Age);

            foreach (Student student in reversedStudents)
            {
                Console.WriteLine(student.Name);
            }

            Assert.AreEqual(23, reversedStudents.First().Age);
            Assert.AreEqual(18, reversedStudents.Last().Age);


            //12. Use LINQ and method chaining to find the oldest student (not the oldest student's
            //    age, but the actual Student).
            Student oldest = _students.OrderByDescending(s => s.Age).First();

            Console.WriteLine("Oldest: " + oldest.Name);

            Assert.AreEqual(23, oldest.Age);
            Assert.AreEqual("Bob", oldest.Name);

            //13. Use LINQ and method chaining to find the NAMES of the TWO oldest students, with
            //    the oldest listed first.
            //    You will need to chain several methods together to do this.
            IEnumerable<string> twoOldest = _students.OrderByDescending(s => s.Age).Take(2).Select(s => s.Name);

            foreach (string name in twoOldest)
            {
                Console.WriteLine(name);
            }

            Assert.IsTrue(twoOldest.SequenceEqual(new[] { "Bob", "Elliot" }));

        }




    }
}
