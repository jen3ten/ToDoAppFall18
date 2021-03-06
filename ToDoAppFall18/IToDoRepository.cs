﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAppFall18.Models;

namespace ToDoAppFall18
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAll();
        ToDo GetById(int id);
        void Create(ToDo todo);
        void Delete(ToDo todo);
    }
}
