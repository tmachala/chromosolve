using ChromoSolve;
using Knapsack;

// The denominations (and their quantities) that we need to split amongst the envelopes
var cashToSplit = new Cash[]
{
    new(DenominationType.Banknote, 200, 20),
    new(DenominationType.Banknote, 500, 6),
    new(DenominationType.Banknote, 1000, 2),
    new(DenominationType.Coin, 20, 100),
    new(DenominationType.Coin, 10, 100),
    new(DenominationType.Coin, 2, 2500)
};

// How we want to split the cash amongst the individual envelopes
var expectedEnvelopeValues = new[] { 998, 1000, 3002, 2000, 10000 };

var problem = new ProblemDefinition(cashToSplit, expectedEnvelopeValues);
var mapper = new PhenotypeMapper(problem);
var fitnessFn = new FitnessFunction();

var settings = new DifferentialEvolutionSettings<Individual>
{
    // The function that guides the DE algorithm by telling it how good each
    // individual (a candidate solution) is
    FitnessFunction = fitnessFn,
    
    // The mapper that can turn chromosome (the genetic information) into
    // an individual (a candidate solution to the knapsack problem)
    PhenotypeMapper = mapper,
    
    // How long the genetic information needs to be so that the mapper can
    // construct an individual
    ChromosomeLength = mapper.GetRequiredChromosomeLength(),
    
    // How many individuals should the evolution create in each generation
    PopulationSize = 200
};

var evolution = new DifferentialEvolution<Individual>(settings);

var result = evolution.Optimize(10000);

Console.WriteLine(result.Individual);