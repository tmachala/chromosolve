namespace ChromoSolve;

public class DifferentialEvolution<TIndividual>
{
    private readonly DifferentialEvolutionSettings<TIndividual> _settings;
    private readonly Random _random;

    public DifferentialEvolution(DifferentialEvolutionSettings<TIndividual> settings)
    {
        _settings = settings;
        _random = settings.RandomNumberGenerator;
    }

    public EvolutionResult<TIndividual> Optimize(int generations)
    {
        var fitnessFn = _settings.FitnessFunction;
        var stopThreshold = _settings.FitnessFunction.StopThreshold;
        var mapper = _settings.PhenotypeMapper;
        
        var chromosomeLen = _settings.ChromosomeLength;
        var popSize = _settings.PopulationSize;
        var lowerBound = _settings.LowerBound;
        var upperBound = _settings.UpperBound;
        
        var population = new double[popSize][];
        var fitness = new double[popSize];

        EvolutionResult<TIndividual>? bestSolution = null;
        var bestFitnessFound = double.MaxValue;
        var bestFitnessReported = double.MaxValue;
        
        // Create the first (totally random) generation and evaluate it
        for (var i = 0; i < popSize; i++)
        {
            var chromosome = new double[chromosomeLen];
            
            for (var j = 0; j < chromosomeLen; j++)
            {
                chromosome[j] = lowerBound + _random.NextDouble() * (upperBound - lowerBound);
            }
            
            var individual = mapper.CreateIndividual(chromosome);
            
            fitness[i] = fitnessFn.Evaluate(individual);
            population[i] = chromosome;
        }
        
        var f = _settings.ScalingFactor;
        var cr = _settings.CrossRate;
        
        for (var gen = 1; gen <= generations; gen++)
        {
            for (var i = 0; i < popSize; i++)
            {
                // Select three distinct random indices
                var (a, b, c) = PickThreeChromosomes(ref population);

                // Create mutant vector
                var mutant = new double[chromosomeLen];
                for (var j = 0; j < chromosomeLen; j++)
                {
                    mutant[j] = a[j] + f * (b[j] - c[j]);
                }

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
                var trialIndividual = mapper.CreateIndividual(trial);
                var trialFitness = fitnessFn.Evaluate(trialIndividual);
                
                if (trialFitness < fitness[i])
                {
                    population[i] = trial;
                    fitness[i] = trialFitness;
                }

                if (trialFitness < bestFitnessFound)
                {
                    bestSolution = new EvolutionResult<TIndividual>(gen, trialFitness, trialIndividual);
                    bestFitnessFound = trialFitness;
                }
                
                // End the evolution right here if we have found a good enough solution
                if (trialFitness <= stopThreshold)
                {
                    return bestSolution!;
                }
            }
            
            // Report the progress once per generation only and only when there has been an improvement
            if (bestFitnessReported > bestFitnessFound && _settings.OnProgress != null)
            {
                _settings.OnProgress(bestSolution!);
                bestFitnessReported = bestFitnessFound;
            }
        }
        
        // The final phenotype is going to be the same as in bestSolution but the generation number might have increased
        // since then so we can't return the bestSolution directly.
        return new EvolutionResult<TIndividual>(generations, bestSolution!.Fitness, bestSolution.Individual);
    }

    private (double[], double[], double[]) PickThreeChromosomes(ref double[][] population)
    {
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