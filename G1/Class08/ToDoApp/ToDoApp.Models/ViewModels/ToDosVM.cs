using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models.ViewModels
{
    public class ToDosVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
