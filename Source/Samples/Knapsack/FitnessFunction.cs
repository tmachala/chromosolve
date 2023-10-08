using ChromoSolve;

namespace Knapsack;

public class FitnessFunction : IFitnessFunction<Individual>
{
    public double StopThreshold { get; } = double.Epsilon;
    public double Evaluate(Individual individual)
    {
        var valueMissing = 0;

        foreach (var env in individual.Envelopes)
        {
            var diff = env.ExpectedValue - env.ActualValue;

            if (diff < 0)
            {
                throw new NotSupportedException("The envelope must not contain higher than the expected amount!");
            }

            valueMissing += diff;
        }

        return valueMissing;
    }
}