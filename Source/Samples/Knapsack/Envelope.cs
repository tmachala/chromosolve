using System.Text;

namespace Knapsack;

public class Envelope
{
    public int ExpectedValue { get; }
    public int ActualValue => Cash.Sum(c => c.Value * c.Quantity);
    
    public List<Cash> Cash { get; } = new();

    public Envelope(int expectedValue)
    {
        ExpectedValue = expectedValue;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Expected Value: {ExpectedValue}");
        sb.AppendLine($"Actual Value:   {ActualValue}");

        foreach (var c in Cash)
        {
            sb.AppendLine(c.ToString());
        }

        return sb.ToString();
    }
}