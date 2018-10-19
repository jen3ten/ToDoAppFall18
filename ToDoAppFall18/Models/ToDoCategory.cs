using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppFall18.Models
{
    public class ToDoCategory
    {
        public int Id { get; set; }
        public int ToDoId { get; set; }
        public virtual ToDo ToDo { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
