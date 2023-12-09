﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineLibrary.Domain.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T entity);
        void Read(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> FindOrCreateAsync(T e);
        Task<T> FindByIdAsync(int id);
        Task<List<T>> FindAllAsync();
    }
}