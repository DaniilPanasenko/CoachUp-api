﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoachUp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(string login);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(string login);
    }
}
