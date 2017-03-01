﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using rassler.backend.infrastructure.Database.Objects;

namespace rassler.backend.infrastructure.Database.Interfaces
{
    public interface ISecuredRepository<T> : IRepository<T>
        where T : class
    {
        void Initialize(string username);
    }
}