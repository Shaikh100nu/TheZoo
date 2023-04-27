using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using  MVC_crud_sonu_.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MVC_crud_sonu_.Context;
using System.Security.Cryptography.X509Certificates;

namespace MVC_crud_sonu_.DAL
{
    public class GenericAnimalRepository<TEntity> where TEntity : class
    {
        internal AnimaMvcContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericAnimalRepository(AnimaMvcContext context)
        {
             _context = context;
             _dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetData()
        {
              return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> SaveData(TEntity  record)
        {
            await _dbSet.AddAsync(record);
            await _context.SaveChangesAsync();
           return record;

        }

        public async Task DeleteAnimalData(int id)
        {
            var record = await _dbSet.FindAsync(id);
            if (record != null)
            {
                _dbSet.Remove(record);
            }
            await _context.SaveChangesAsync();
        }
    }
}
