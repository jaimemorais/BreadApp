using System;
using System.Collections.Generic;

namespace BreadApp.Domain.Base
{
    public abstract class Entity
    {
        protected Guid Id { get; set; } = Guid.NewGuid();


        private List<IDomainEvent> _domainEvents;

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents ??= new List<IDomainEvent>();

            this._domainEvents.Add(domainEvent);
        }



        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }



        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

    }
}
