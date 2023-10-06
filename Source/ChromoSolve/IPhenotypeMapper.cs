namespace ChromoSolve;

/// <summary>
/// Represents an interface for mapping a chromosome representation to an individual (phenotype).
/// </summary>
/// <typeparam name="TIndividual">The type representing an individual (a candidate solution to the problem).</typeparam>
public interface IPhenotypeMapper<out TIndividual>
{
    /// <summary>
    /// Creates an individual (a candidate solution to the problem) from a given chromosome representation.
    /// </summary>
    /// <param name="chromosome">The array representing the chromosome of the individual.</param>
    /// <returns>An instance of <typeparamref name="TIndividual"/> representing the individual phenotype.</returns>
    TIndividual CreateIndividual(double[] chromosome);
}
