using Avenga.Asp.Net.Mvc.Class04.Views.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Avenga.Asp.Net.Mvc.Class04.Views.Models.ViewModels
{
    public class CreateStudentVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
