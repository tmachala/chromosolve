namespace Knapsack;

public class ProblemDefinition
{
    public Cash[] CashToSplit { get; }
    public int[] ExpectedEnvelopeValues { get; }

    public ProblemDefinition(Cash[] cashToSplit, int[] expectedEnvelopeValues)
    {
        CashToSplit = cashToSplit;
        ExpectedEnvelopeValues = expectedEnvelopeValues;
    }
}