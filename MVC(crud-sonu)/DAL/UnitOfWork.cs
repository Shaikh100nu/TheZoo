using System;
using Microsoft.EntityFrameworkCore;
using MVC_crud_sonu_.Context;
using MVC_crud_sonu_.Controllers;
using MVC_crud_sonu_.Models;

namespace MVC_crud_sonu_.DAL
{
    public class UnitOfWork : IDisposable
    {

        private readonly AnimaMvcContext _context;
        private GenericAnimalRepository<Animal> _genericAnimalRepository;
        private GenericAnimalRepository<Zookeeper> _genericZookeeperRepository;
        private GenericAnimalRepository<GuestServiceAgent> _genericGuestServiceAgentRepository;


        public UnitOfWork(
            AnimaMvcContext context,
            GenericAnimalRepository<Animal> genericAnimalRepository,
            GenericAnimalRepository<Zookeeper> genericZookeeperRepository
            )
        {
            _context = context;
            _genericAnimalRepository = genericAnimalRepository;
            _genericZookeeperRepository = genericZookeeperRepository;
        }
        public GenericAnimalRepository<Animal> AnimalRepository
        {
            get
            {
                if (this._genericAnimalRepository == null)
                {
                    this._genericAnimalRepository = new GenericAnimalRepository<Animal>(_context);
                }
                return _genericAnimalRepository;
            }
        }


        public GenericAnimalRepository<Zookeeper> ZookeeperRepository
        {
            get
            {
                if (this._genericZookeeperRepository == null)
                {
                    this._genericZookeeperRepository = new GenericAnimalRepository<Zookeeper>(_context);
                }
                return _genericZookeeperRepository;
            }
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
