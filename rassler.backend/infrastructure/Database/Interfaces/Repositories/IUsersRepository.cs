﻿using rassler.backend.domain.Model;

namespace rassler.backend.infrastructure.Database.Interfaces.Repositories
{
    public interface IUsersRepository : ISecuredRepository<User>
    {
    }
}
