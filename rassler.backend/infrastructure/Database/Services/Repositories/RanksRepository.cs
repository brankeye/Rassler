﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Database.Interfaces.Repositories;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services.Repositories
{
    public class RanksRepository : SecuredRepository<Rank>, IRanksRepository
    {
        public RanksRepository(DbContext context) : base(context)
        {

        }

        protected override bool CanDelete(object id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        protected override bool CanFind(Rank item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(Rank item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<Rank> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(Rank item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(Rank item)
        {
            throw new NotImplementedException();
        }
    }
}
