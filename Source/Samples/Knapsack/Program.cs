using ChromoSolve;
using Knapsack;

/*
 * Knapsack Problem Solver Sample
 *
 * Problem Definition:
 *
 * There is a certain amount of cash (various denominations) that we want
 * to put into multiple envelopes so that ideally, each envelope contains cash
 * that is worth 100% of the envelope's declared value.
 *
 * When not possible (not enough cash to split or a mix of cash that cannot be
 * split exactly as required) then we can leave an envelope filled-up to less
 * than 100% but we can never overfill it over 100%.
 *
 *                                 ENVELOPES
 *      (1)            (2)            (3)            (4)            (5)
 *  ____________   ____________   ____________   ____________   ____________
 * |\ 998 CZK /|  |\ 1000 CZK/|  |\ 3002 CZK/|  |\ 2000 CZK/|  |\10000 CZK/|  
 * | \_______/ |  | \_______/ |  | \_______/ |  | \_______/ |  | \_______/ |
 * |___________|  |___________|  |___________|  |___________|  |___________|
 *
 *                     CASH TO SPLIT AMONGST THE ENVELOPES
 *
 * Banknote   200 CZK    20 pcs.
 * Banknote   500 CZK     6 pcs.
 * Banknote  1000 CZK     2 pcs.
 * Coin        20 CZK   100 pcs.
 * Coin        10 CZK   100 pcs.
 * Coin         2 CZK  2500 pcs.
 * 
 */

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
    PopulationSize = 100,
    
    // A custom action that logs the evolution progress into console
    OnProgress = i => Console.WriteLine($"Generation: {i.Generation}; Fitness: {i.Fitness}")
};

var evolution = new DifferentialEvolution<Individual>(settings);

var result = evolution.Optimize(10000);

Console.WriteLine("---------------------------------------------------");
Console.WriteLine($"Generation: {result.Generation}");
Console.WriteLine($"Fitness: {result.Fitness}");

Console.WriteLine(result.Individual);