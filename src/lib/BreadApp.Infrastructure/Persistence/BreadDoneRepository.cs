using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadApp.Infrastructure.Persistence
{
    public class BreadDoneRepository : IBreadDoneRepository
    {

        // TODO temporalily in memory
        private static readonly List<BreadDone> _breadList = new();

        public void Add(BreadDone bread)
        {
            _breadList.Add(bread);
        }

        public BreadDone GetBreadDoneById(Guid id)
        {
            return _breadList.SingleOrDefault(b => b.Id.Equals(id));
        }

    }
}
