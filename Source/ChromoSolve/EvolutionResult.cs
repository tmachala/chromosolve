namespace ChromoSolve;

/// <summary>
/// Represents the result of an evolution step in an evolutionary algorithm.
/// It includes information such as the generation number, the fitness of the individual,
/// and the individual itself.
/// </summary>
/// <typeparam name="TIndividual">The type representing an individual (a candidate solution to the problem).</typeparam>
public class EvolutionResult<TIndividual>
{
    /// <summary>
    /// Gets the generation number at which this result was obtained.
    /// </summary>
    public int Generation { get; }
    
    /// <summary>
    /// Gets the fitness value of the individual in this result.
    /// </summary>
    public double Fitness { get; }
    
    /// <summary>
    /// Gets the problem solution represented by this result.
    /// </summary>
    public TIndividual Individual { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EvolutionResult{TIndividual}"/> class.
    /// </summary>
    /// <param name="generation">The generation number at which this result was obtained.</param>
    /// <param name="fitness">The fitness value of the individual in this result.</param>
    /// <param name="individual">The individual represented by this result.</param>
    public EvolutionResult(int generation, double fitness, TIndividual individual)
    {
        Generation = generation;
        Fitness = fitness;
        Individual = individual;
    }
}