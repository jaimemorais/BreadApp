using BreadApp.Application.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadApp.Infrastructure.Persistence
{
    public class BreadRepository : IBreadRepository
    {

        // TODO temporalily in memory
        private static readonly List<Bread> _breadList = new();

        public void Add(Bread bread)
        {
            _breadList.Add(bread);
        }

        public Bread GetBreadById(Guid id)
        {
            return _breadList.SingleOrDefault(b => b.Id.Equals(id));
        }

        public Bread GetBreadByName(string name)
        {
            return _breadList.SingleOrDefault(b => b.Name.Equals(name));
        }

    }
}
