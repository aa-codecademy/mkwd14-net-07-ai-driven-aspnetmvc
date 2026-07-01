using System;

namespace Avenga.Asp.Net.Mvc.Class04.Views.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Course ActiveCourse { get; set; }
    }
}
