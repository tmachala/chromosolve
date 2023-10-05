namespace ChromoSolve;

/// <summary>
/// Represents the contract for a fitness function in the Differential Evolution (DE) algorithm.
/// It defines the method to evaluate the fitness of a candidate solution (chromosome) 
/// and a stopping criterion value for the algorithm.
/// </summary>
public interface IFitnessFunction
{
    /// <summary>
    /// Gets the fitness value at which the Differential Evolution (DE) algorithm should stop evolving.
    /// This property can be used to set a threshold, indicating that a sufficiently optimal solution has been found.
    /// </summary>
    public double StopThreshold { get; }
    
    /// <summary>
    /// Evaluates the fitness of the given chromosome in the context of the Differential Evolution (DE) algorithm.
    /// </summary>
    /// <param name="chromosome">
    /// An array representing a candidate solution within the problem space that the DE algorithm is exploring.
    /// </param>
    /// <returns>
    /// A double representing the fitness value of the given chromosome. Lower values represent better solutions.
    /// </returns>
    public double Evaluate(double[] chromosome);
}