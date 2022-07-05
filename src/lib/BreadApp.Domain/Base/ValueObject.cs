using System;

namespace BreadApp.Domain.Base
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public bool Equals(ValueObject other)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
