using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadApp.Infrastructure.Persistence.InMemory
{
    public class BreadDoneInMemoryRepository : IBreadDoneRepository
    {

        private static readonly List<BreadDone> _breadList = new();

        public void Add(BreadDone breadDone)
        {
            _breadList.Add(breadDone);
        }

        public BreadDone GetBreadDoneById(Guid id)
        {
            return _breadList.SingleOrDefault(b => b.Id.Equals(id));
        }

    }
}
