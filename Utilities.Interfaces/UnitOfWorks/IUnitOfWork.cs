﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Utilities.Interfaces.Repositories;

namespace Utilities.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
        void SyncObjectsStatePreCommit();
        void SyncObjectsStatePostCommit();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class;
    }
}
