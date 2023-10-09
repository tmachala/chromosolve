using ChromoSolve;

namespace Knapsack;

public class PhenotypeMapper : IPhenotypeMapper<Individual>
{
    private readonly ProblemDefinition _problem;

    public PhenotypeMapper(ProblemDefinition problem)
    {
        _problem = problem;
    }

    public Individual CreateIndividual(double[] chromosome)
    {
        var expectedEnvelopeValues = _problem.ExpectedEnvelopeValues;
        var envelopeCount = _problem.ExpectedEnvelopeValues.Length;
        var cashToSplit = _problem.CashToSplit;
        var remainingQuantities = cashToSplit.Select(s => s.Quantity).ToArray();
        var individual = new Individual();
        var chromosomeIndex = 0;

        // e .. envelope index
        // c .. cash-to-split index
        for (var e = 0; e < envelopeCount; e++)
        {
            var expected = expectedEnvelopeValues[e];
            var actual = 0;
            var envelope = new Envelope(expected);
            
            for (var c = 0; c < cashToSplit.Length; c++)
            {
                var cts = cashToSplit[c];
                var remainingQty = remainingQuantities[c];
                var gene = chromosome[chromosomeIndex++];
                
                // How many pieces the gene suggests we should put into the envelope
                var naiveQty = EvolutionUtils.ScaleToRange(gene, 0, cts.Quantity);

                // The same quantity but lowered by two constraints:
                //
                // 1. The remaining quantity (if we had 100 pieces but 30 are already in envelope 1
                //    then envelope 2 can't have more than 70).
                //
                // 2. The remaining envelope value to fill (e.g., we can't add a 1000 CZK banknote
                //    to an envelope that is only missing 970 CZK.
                var remainingValueToFill = expected - actual;
                var maxQty = remainingValueToFill / cts.Value;
                
                var cappedQty = Math.Min(Math.Min(remainingQty, naiveQty), maxQty);

                if (cappedQty > 0)
                {
                    remainingQuantities[c] -= cappedQty;
                    actual += cts.Value * cappedQty;
                    envelope.Cash.Add(new Cash(cts.Type, cts.Value, cappedQty));
                }
            }
            
            individual.Envelopes.Add(envelope);
        }
        
        return individual;
    }
    
    public int GetRequiredChromosomeLength()
    {
        var denominationCount = _problem.CashToSplit.Length;
        var envelopeCount = _problem.ExpectedEnvelopeValues.Length;

        return denominationCount * envelopeCount;
    }
}