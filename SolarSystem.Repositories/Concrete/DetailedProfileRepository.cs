﻿using SolarSystem.Data.Abstract;
using SolarSystem.Models;
using SolarSystem.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SolarSystem.Repositories.Concrete
{
    public class DetailedProfileRepository : IDetailedProfileRepository
    {
        private readonly IRepository<DetailedProfile> repository;

        public DetailedProfileRepository(IRepository<DetailedProfile> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddOrUpdateDetailedProfileAsync(DetailedProfile entity)
        {
            if (entity.Id == 0)
            {
                return (await repository.AddAsync(entity));
            }

            return (await repository.AttachAsync(entity, Data.EntityStatus.Modified));
        }

        public async Task<bool> DeleteDetailedProfileAsync(DetailedProfile entity)
        {
            return (await repository.DeleteAsync(entity));
        }

        public async Task<DetailedProfile> GetDetailedProfileAsync(int id, string type)
        {
            return (await repository.SingleOrDefaultAsync(s => s.TypeId == id && s.TypeName == type));
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
