/*
 * This sample demonstrates how we can solve a Traveling Salesman Problem using
 * the Differential Evolution (DE).
 *
 * Problem Definition:  Bob is a salesman. He wants to visit all 10 cities
 *                      while traveling the minimum distance possible. In which
 *                      order should he visit these cities?
 */

using ChromoSolve;
using TravelingSalesman;

var settings = new DifferentialEvolutionSettings<Individual>
{
    // The function that guides the DE algorithm by telling it how good each
    // individual (a candidate solution) is
    FitnessFunction = new FitnessFunction(),
    
    // The mapper that can turn chromosome (the genetic information) into
    // an individual (a candidate solution to Bob's problem)
    PhenotypeMapper = new PhenotypeMapper(),
    
    // How long the genetic information needs to be so that the mapper can
    // construct an individual
    ChromosomeLength = PhenotypeMapper.RequiredChromosomeLength,
    
    // How many individuals should the evolution create in each generation
    PopulationSize = 100,
    
    // A custom action that logs the evolution progress into console
    OnProgress = i => Console.WriteLine($"Generation: {i.Generation}; Fitness: {i.Fitness}")
};

var evolution = new DifferentialEvolution<Individual>(settings);

var result = evolution.Optimize(generations: 1000);

Console.WriteLine("-----------------------------");
Console.WriteLine($"Best Route Found: {result.Individual}");
Console.WriteLine($"Total Distance:   {result.Fitness} km");
Console.WriteLine($"Generation:       {result.Generation}");