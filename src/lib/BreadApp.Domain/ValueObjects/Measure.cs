using BreadApp.Domain.Base;
using System.Collections.Generic;

namespace BreadApp.Domain.ValueObjects
{
    public class Measure : ValueObject
    {
        public Measure(Unit unit, int quantity)
        {
            Unit = unit;
            Quantity = quantity;
        }


        public Unit Unit { get; private set; }

        public int Quantity { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Unit;
            yield return Quantity;
        }
    }
}
