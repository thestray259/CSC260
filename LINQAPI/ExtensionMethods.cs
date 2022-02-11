using System;
using System.Collections.Generic;
using System.Linq;
using LINQRefresher_v3.Enums;
using LINQRefresher_v3.Models;

namespace LINQRefresher_v3.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /*
         * Using the method names and comments below, implement each extension method.
         * You will receive a grade based on how your implementation functions
         * during a series of automated tests. You may implement the methods
         * using any combination of comprehension, extension, or desugarized
         * syntax.
         */

        /// <summary>
        /// Returns a collection of students based on the indicated Gender
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <param name="gender">The Gender value requested</param>
        /// <returns>The collection of Students with the same gender as the parameter</returns>
        public static IEnumerable<Student> GetStudentsByGender(this IEnumerable<Student> students, Genders gender)
        {
            return students.Where(s => s.Gender == gender); 
        }

        /// <summary>
        /// Returns a collection of students where the ages fall between the inclusive min and max values
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <param name="minYearsOld">Inclusive minimum age</param>
        /// <param name="maxYearsOld">Inclusive maximum age</param>
        /// <returns>The collection of Students that match the criteria</returns>
        public static IEnumerable<Student> GetStudentsByAgeRange(this IEnumerable<Student> students, int minYearsOld, int maxYearsOld)
        {
            return students.Where(s => s.Age >= minYearsOld && s.Age <= maxYearsOld); 
        }

        /// <summary>
        /// Gets the Students with a GPA below 2.0
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>The collection of students not currently passing</returns>
        public static IEnumerable<Student> GetTheFailingStudents(this IEnumerable<Student> students)
        {
            return students.Where(s => s.GPA > 2.0f); 
        }

        /// <summary>
        /// Reports the number of students in each ClassLevel designation
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>A Dictionary where the key is the ClassLevel and the value is the number of students in that level</returns>
        public static Dictionary<ClassLevel, int> StudentsPerClassLevel(this IEnumerable<Student> students)
        {
            return students.GroupBy(st => st.Level).Select(s =>
            new { ClassLevel = s.Key, Count = s.Count() }).
            ToDictionary(t => t.ClassLevel, t => t.Count);
        }

        /// <summary>
        /// Determines which MaritalStatus has the highest average GPA
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>The MaritalStatus value with the highest average GPA</returns>
        public static MaritalStatus MaritalStatusWithHighestAverageGPA(this IEnumerable<Student> students)
        {
            return students.GroupBy(s => s.Relationship).Select(group =>
            new { Status = group.Key, AverageGPA = group.Average(g => g.GPA) })
                .OrderByDescending(g => g.AverageGPA).FirstOrDefault().Status; 

            // David's code
            // return students.GroupBy(student => student.Relationship).OrderByDescending(status => status.Average(p => p.GPA)).First().Key; 
        }

        /// <summary>
        /// Creates a collection containing the top students in each ClassLevel designation.
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <param name="count">The number of top students per ClassLevel being requested</param>
        /// <returns>The collection of the top students</returns>
        public static IEnumerable<Student> TopOfTheClass(this IEnumerable<Student> students, int count)
        {
            //throw new NotImplementedException();

            return students.GroupBy(lev => lev.Level).Select(group =>
            new { Level = group.Key, Students = group.OrderByDescending(s => s.GPA).Take(count) })
                .SelectMany(x => x.Students);

            // David's code
            //return students.GroupBy(student => student.Level).Select(s => s.OrderByDescending(stu => stu.GPA).Take(count)).SelectMany(x => x); 
        }

        /// <summary>
        /// Determines which students are still not legal adults. NOTE: this query should work every year that it is run.
        /// </summary>
        /// <param name="students">The original collection of students</param>
        /// <returns>The collection of students that are under the age of 18</returns>
        public static IEnumerable<Student> UnderageStudents(this IEnumerable<Student> students)
        {
            return students.Where(s => s.Age > 18.0f); 
        }

        /// <summary>
        /// Takes in a collection of Person objects and returns a collection of those that are Student objects
        /// </summary>
        /// <param name="people">The original collection of Person objects</param>
        /// <returns>The collection of Person objects that are actually Students</returns>
        public static IEnumerable<Student> FindTheStudents(this IEnumerable<Person> people)
        {
            //return people.Where(s => s.GetType() == typeof(Student)).Cast<Student>().ToList();
            return people.OfType<Student>(); 
        }

        /// <summary>
        /// Determines the percantage of Person objects that are Students
        /// </summary>
        /// <param name="people">The original collection of people</param>
        /// <returns>The percentage of Person objects that are also Students expressed as a float less than or equal to 1.0</returns>
        public static float CurrentPercentageOfPeopleInSchool(this IEnumerable<Person> people) // used 3 lines
        {
            //throw new NotImplementedException();

            float percentage = (people.FindTheStudents().Count() / people.Count()) * 100;
            return percentage; 
        }

        /// <summary>
        /// Analyses a collection of Person objects and reports how many people are born under each sign of the zodiac
        /// </summary>
        /// <param name="people">The original collection or Person objects</param>
        /// <returns>A Dictionary where the key is the sign and the value is the number of people born under it</returns>
        public static Dictionary<ZodiacSign, int> NumberOfPeopleByBirthSign(this IEnumerable<Person> people)
        {
            return people.GroupBy(BirthSign).Select(signs => 
            new { Sign = signs.Key, Count = signs.Count() }).
            ToDictionary(t => t.Sign, t => t.Count); 
        }

        //HELPER METHOD - You do not need to use LINQ for this.
		/// <summary>
        /// Derives the Zodiac sign for an instance of Person based on its Birthdate property
        /// </summary>
        /// <param name="p">The target Person object whose Zodiac sign will be derived</param>
        /// <returns>The ZodiacSign enum value for the target Person object</returns>
        public static ZodiacSign BirthSign(this Person p)
        {
            int year = p.Birthdate.Year;
            DateTime birthday = p.Birthdate; 

            if (birthday >= new DateTime(year, 3, 21) && birthday <= new DateTime(year, 4, 19))
            {
                return ZodiacSign.Aries; 
            }
            else if (birthday >= new DateTime(year, 4, 20) && birthday <= new DateTime(year, 5, 20))
            {
                return ZodiacSign.Taurus;
            }
            else if (birthday >= new DateTime(year, 5, 21) && birthday <= new DateTime(year, 6, 20))
            {
                return ZodiacSign.Gemini;
            }
            else if (birthday >= new DateTime(year, 6, 21) && birthday <= new DateTime(year, 7, 22))
            {
                return ZodiacSign.Cancer;
            }
            else if (birthday >= new DateTime(year, 7, 23) && birthday <= new DateTime(year, 8, 22))
            {
                return ZodiacSign.Leo;
            }
            else if (birthday >= new DateTime(year, 8, 23) && birthday <= new DateTime(year, 9, 22))
            {
                return ZodiacSign.Virgo;
            }
            else if (birthday >= new DateTime(year, 9, 23) && birthday <= new DateTime(year, 10, 22))
            {
                return ZodiacSign.Libra;
            }
            else if (birthday >= new DateTime(year, 10, 23) && birthday <= new DateTime(year, 11, 21))
            {
                return ZodiacSign.Scorpio;
            }
            else if (birthday >= new DateTime(year, 11, 22) && birthday <= new DateTime(year, 12, 21))
            {
                return ZodiacSign.Saggitarius;
            }
            else if (birthday >= new DateTime(year, 12, 22) && birthday <= new DateTime(year, 1, 19))
            {
                return ZodiacSign.Capricorn;
            }
            else if (birthday >= new DateTime(year, 1, 20) && birthday <= new DateTime(year, 2, 18))
            {
                return ZodiacSign.Aquarius;
            }
            else
            {
                Console.WriteLine(birthday.ToShortDateString()); 
                return ZodiacSign.Pisces; 
            }
        }
    }
}
