namespace Knapsack;

public struct Cash
{
    public DenominationType Type { get; }
    public int Value { get; }
    public int Quantity { get; }
    public int Total => Value * Quantity;

    public Cash(DenominationType type, int value, int quantity)
    {
        Type = type;
        Value = value;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Type} {Value} x {Quantity} pcs.";
    }
}