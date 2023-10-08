// ReSharper disable PropertyCanBeMadeInitOnly.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable RedundantDefaultMemberInitializer
namespace ChromoSolve;

/// <summary>
/// Represents the settings used to configure the Differential Evolution (DE) algorithm.
/// This class holds properties that influence the evolutionary computation, such as the 
/// population size, chromosome length, and bounds for the DE algorithm.
/// </summary>
public class DifferentialEvolutionSettings<TIndividual>
{
    /// <summary>
    /// Gets or sets the fitness function used to evaluate the quality of solutions in the population.
    /// The fitness function is critical in Differential Evolution, as it helps in selecting potential 
    /// candidate solutions for the next generation.
    /// </summary>
    public IFitnessFunction<TIndividual> FitnessFunction { get; set; } = null!;

    /// <summary>
    /// Gets or sets the phenotype mapper used to convert chromosome representations into individual phenotypes
    /// (candidate solutions).
    /// </summary>
    public IPhenotypeMapper<TIndividual> PhenotypeMapper { get; set; } = null!;

    public Action<EvolutionResult<TIndividual>>? OnProgress { get; set; } = null;
    
    /// <summary>
    /// Gets or sets the random number generator used for various stochastic processes in Differential Evolution, 
    /// such as mutation and crossover.
    /// </summary>
    /// <remarks>
    /// Typically doesn't need to be changed except for unit tests where you might want to provide one 
    /// that returns predictable sequences.
    /// </remarks>
    public Random RandomNumberGenerator { get; set; } = Random.Shared;
    
    /// <summary>
    /// Gets or sets the size of the population in each generation.
    /// Larger populations may offer more diverse solutions but will be more computationally intensive.
    /// </summary>
    public int PopulationSize { get; set; } = 200;
    
    /// <summary>
    /// Gets or sets the length of the chromosome representing a candidate solution in the population.
    /// It represents the dimensionality of the problem space.
    /// </summary>
    public int ChromosomeLength { get; set; } = 10;
    
    /// <summary>
    /// Gets or sets the lower bound for the values of elements in a candidate solution.
    /// It affects the range of possible solutions in the search space.
    /// </summary>
    public double LowerBound { get; set; } = 0.0;
    
    /// <summary>
    /// Gets or sets the upper bound for the values of elements in a candidate solution.
    /// Like the lower bound, it determines the range of possible solutions in the search space.
    /// </summary>
    public double UpperBound { get; set; } = 1.0;
    
    /// <summary>
    /// Gets or sets the scaling factor used in mutation.
    /// The scaling factor influences the magnitude of the differences between the vectors in mutation.
    /// </summary>
    public double ScalingFactor { get; set; } = 0.8;
    
    /// <summary>
    /// Gets or sets the crossover rate, determining the likelihood of elements being exchanged between 
    /// candidate solutions during the recombination process.
    /// It influences the generation of trial vectors in the DE algorithm.
    /// </summary>
    public double CrossRate { get; set; } = 0.9;
}