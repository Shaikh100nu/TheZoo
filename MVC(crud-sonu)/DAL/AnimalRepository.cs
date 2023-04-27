using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MVC_crud_sonu_.Models;
using MVC_crud_sonu_.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace MVC_crud_sonu_.DAL
{
    public class AnimalRepository : IAnimalRepository, IDisposable
    {
        private readonly AnimaMvcContext _context;
       public AnimalRepository(AnimaMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> GetAnimalList(int pageNumber , int rowsOfPage)
        {
            var parameters = new List<SqlParameter>();
            var _pageNumber = new SqlParameter("@PageNumber", pageNumber);
            var _rowsOfPage = new SqlParameter("@RowsOfPage", rowsOfPage);
            parameters.Add(_pageNumber);
            parameters.Add(_rowsOfPage);
            List<Animal>  data = await _context.Animals.FromSqlRaw($"exec _customPagiantion @PageNumber,@RowsOfPage", parameters: parameters.ToArray()).ToListAsync();

            return data;
        }

        public async Task DeleteAnimal(int id)
        {
            var record = await _context.Animals.FindAsync(id);
            if (record != null)
            {
                _context.Animals.Remove(record);
            }
            await _context.SaveChangesAsync();

        }

        public async Task SaveAnimal(Animal modal)
        {
            if (modal.Id == 0)
            {
                await _context.Animals.AddAsync(modal);
            }
            else
            {
                var animalRecord = await _context.Animals.FindAsync(modal.Id);
                animalRecord.FirstName = modal.FirstName;
                animalRecord.LastName = modal.LastName;
                animalRecord.Age = modal.Age;
            }
            await _context.SaveChangesAsync();

        }

        public async Task<Animal> ShowEditRecord(int id)
        {
            Animal record = await _context.Animals.FindAsync(id);
            if (record == null)
            {
                record = new Animal();
            }

            return record;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
