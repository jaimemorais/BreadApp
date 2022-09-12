using System;

namespace BreadApp.Domain.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();





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
