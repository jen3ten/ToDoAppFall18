﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppFall18.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDoCategory> ToDoCategories { get; set; }
    }
}
