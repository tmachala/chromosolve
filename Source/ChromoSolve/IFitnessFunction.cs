namespace ChromoSolve;

/// <summary>
/// Represents the contract for a fitness function in an evolutionary algorithm.
/// It defines the method to evaluate the fitness of a candidate solution (chromosome) 
/// and a stopping criterion value for the algorithm.
/// </summary>
/// <typeparam name="TIndividual">The type representing an individual (a candidate solution to the problem).</typeparam>
public interface IFitnessFunction<in TIndividual>
{
    /// <summary>
    /// Gets the fitness value at which the evolutionary algorithm should stop evolving.
    /// This property can be used to set a threshold, indicating that a sufficiently optimal solution has been found.
    /// </summary>
    public double StopThreshold { get; }
    
    /// <summary>
    /// Evaluates the fitness of the given individual in the context of the evolutionary algorithm.
    /// </summary>
    /// <param name="individual">
    /// An instance representing a candidate solution within the problem space that the DE algorithm is exploring.
    /// </param>
    /// <returns>
    /// A double representing the fitness value of the given individual. Lower values represent better solutions.
    /// </returns>
    public double Evaluate(TIndividual individual);
}