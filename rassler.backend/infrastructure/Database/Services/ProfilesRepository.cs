﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rassler.backend.domain.Data.Models;
using rassler.backend.infrastructure.Database.Services.Base;

namespace rassler.backend.infrastructure.Database.Services
{
    public class ProfilesRepository : SecuredRepository<Context, Profile>
    {
        protected override bool CanDelete(object id)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanDeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        protected override bool CanFind(Profile item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanFindAsync(Profile item)
        {
            throw new NotImplementedException();
        }

        protected override bool CanGet(out IQueryable<Profile> list)
        {
            throw new NotImplementedException();
        }

        protected override bool CanInsert(Profile item)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CanInsertAsync(Profile item)
        {
            throw new NotImplementedException();
        }
    }
}