namespace ChromoSolve;

public class DifferentialEvolution
{
    private readonly DifferentialEvolutionSettings _settings;
    private readonly Random _random;

    public DifferentialEvolution(DifferentialEvolutionSettings settings)
    {
        _settings = settings;
        _random = settings.RandomNumberGenerator;
    }

    public double[] Optimize(int generations)
    {
        var popSize = _settings.PopulationSize;
        var chromosomeLen = _settings.ChromosomeLength;
        var lowerBound = _settings.LowerBound;
        var upperBound = _settings.UpperBound;
        var fitnessFn = _settings.FitnessFunction;
        var stopThreshold = _settings.FitnessFunction.StopThreshold;
        
        var population = new double[popSize][];
        var fitness = new double[popSize];
        
        // Create the first (totally random) generation and evaluate it
        for (var i = 0; i < popSize; i++)
        {
            var chromosome = new double[chromosomeLen];
            
            for (var j = 0; j < chromosomeLen; j++)
            {
                chromosome[j] = lowerBound + _random.NextDouble() * (upperBound - lowerBound);
            }

            population[i] = chromosome;
            fitness[i] = fitnessFn.Evaluate(chromosome);
        }
        
        var f = _settings.ScalingFactor;
        var cr = _settings.CrossRate;

        for (var g = 0; g < generations; g++)
        {
            for (var i = 0; i < popSize; i++)
            {
                // Select three distinct random indices
                var (a, b, c) = PickThreeChromosomes(ref population);

                // Create mutant vector
                var mutant = new double[chromosomeLen];
                for (var j = 0; j < chromosomeLen; j++)
                    mutant[j] = a[j] + f * (b[j] - c[j]);

                // Create trial vector through crossover
                var trial = new double[chromosomeLen];
                var x = _random.Next(chromosomeLen);

                for (var j = 0; j < chromosomeLen; j++)
                {
                    trial[j] = (_random.NextDouble() <= cr || j == x) ? mutant[j] : population[i][j];
                    
                    // Reflective bounds (makes the gene value stay within the bounds)
                    if (trial[j] < lowerBound)
                    {
                        var excess = lowerBound - trial[j];
                        trial[j] = lowerBound + excess;
                    }
                    else if (trial[j] > upperBound)
                    {
                        var excess = trial[j] - upperBound;
                        trial[j] = upperBound - excess;
                    }
                }

                // Selection
                var trialFitness = fitnessFn.Evaluate(trial);
                
                if (trialFitness < fitness[i])
                {
                    population[i] = trial;
                    fitness[i] = trialFitness;
                }
                
                // End the evolution right here if we have found an ideal solution
                if (trialFitness <= stopThreshold)
                {
                    // TODO: Remove
                    Console.WriteLine($"Gen {g}; Best Fitness: {fitness.Min()}");
                    
                    return trial;
                }
            }
            
            // TODO: Remove
            Console.WriteLine($"Gen {g}; Best Fitness: {fitness.Min()}");
        }

        // Return the best individual
        var bestIndex = Array.IndexOf(fitness, fitness.Min());
        return population[bestIndex];
    }

    private (double[], double[], double[]) PickThreeChromosomes(ref double[][] population)
    {
        // Ugly but fast
        var popSize = _settings.PopulationSize;
        
        var a = _random.Next(0, popSize);
        int b;
        int c;
        
        do
        {
            b = _random.Next(0, popSize);
        } while (a == b);

        do
        {
            c = _random.Next(0, popSize);
        } while (a == c || b == c);

        return (population[a], population[b], population[c]);
    }
}