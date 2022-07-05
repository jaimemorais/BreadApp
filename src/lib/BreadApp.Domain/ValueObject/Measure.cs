namespace BreadApp.Domain.ValueObject
{
    public readonly struct Measure
    {
        public Measure(string unit, int quantity)
        {
            Unit = unit;
            Quantity = quantity;
        }

        public string Unit { get; }

        public int Quantity { get; }
    }
}
