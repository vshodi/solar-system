﻿using SolarSystem.Data;
using SolarSystem.Data.Abstract;
using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Concrete
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly IRepository<Planet> repository;

        public PlanetRepository(IRepository<Planet> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddPlanetAsync(Planet entity)
        {
            return (await repository.AddAsync(entity));
        }

        public async Task<bool> UpdatePlanetAsync(Planet entity, EntityStatus status)
        {
            return (await repository.AttachAsync(entity, status));
        }

        public async Task<bool> DeletePlanetAsync(Planet entity)
        {
            return (await repository.DeleteAsync(entity));
        }

        public async Task<IEnumerable<Planet>> FindPlanetAsync(Expression<Func<Planet, bool>> where)
        {
            return (await repository.FindAsync(where));
        }

        public async Task<Planet> GetPlanetAsync(int id)
        {
            return (await repository.SingleOrDefaultAsync(s => s.Id == id));
        }

        public async Task<IEnumerable<Planet>> GetPlanetsAsync()
        {
            return (await repository.GetAllAsync()).OrderBy(s => s.Ordinal);
        }

        #region "disposing methods"

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (repository != null)
                    {
                        repository.Dispose();
                    }
                }

                disposed = true;
            }
        }

        #endregion
    }
}