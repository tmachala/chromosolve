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

Console.WriteLine("Traveling Salesman Problem");

var settings = new DifferentialEvolutionSettings
{
    // The function that tells how good each individual (a candidate solution) is
    FitnessFunction = new FitnessFunction(),
    
    // How long the genetic information is
    ChromosomeLength = PhenotypeMapper.RequiredChromosomeLength,
    
    // How many individuals there are in each generation
    PopulationSize = 100
};

var evolution = new DifferentialEvolution(settings);

var bestChromosome = evolution.Optimize(generations: 1000);
var bestIndividual = PhenotypeMapper.FromGenotype(bestChromosome);
var totalDistance = settings.FitnessFunction.Evaluate(bestChromosome);

Console.WriteLine("The best route found:");
Console.WriteLine(bestIndividual);
Console.WriteLine($"Total distance: {totalDistance} km");