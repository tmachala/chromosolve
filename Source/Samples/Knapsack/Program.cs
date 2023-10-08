using ChromoSolve;
using Knapsack;

var cashToSplit = new Cash[]
{
    new(DenominationType.Banknote, 200, 20),
    new(DenominationType.Banknote, 500, 6),
    new(DenominationType.Banknote, 1000, 2),
    new(DenominationType.Coin, 20, 100),
    new(DenominationType.Coin, 10, 100),
    new(DenominationType.Coin, 2, 2500)
};

var expectedEnvelopeValues = new[] { 998, 1000, 3002, 2000, 10000 };

var problem = new ProblemDefinition(cashToSplit, expectedEnvelopeValues);
var mapper = new PhenotypeMapper(problem);
var fitnessFn = new FitnessFunction();

var settings = new DifferentialEvolutionSettings<Individual>
{
    FitnessFunction = fitnessFn,
    PhenotypeMapper = mapper,
    ChromosomeLength = mapper.GetRequiredChromosomeLength(),
    PopulationSize = 200
};

var evolution = new DifferentialEvolution<Individual>(settings);

var result = evolution.Optimize(10000);

Console.WriteLine();
Console.WriteLine(result.Individual);