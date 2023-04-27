using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_crud_sonu_.Models;

namespace MVC_crud_sonu_.DAL
{
    public interface IAnimalRepository : IDisposable
    {
        Task<List<Animal>> GetAnimalList(int pageNumber, int rowsOfPage);
        Task DeleteAnimal(int id);

        Task SaveAnimal(Animal entity);
        Task<Animal> ShowEditRecord(int id);

    }
}
