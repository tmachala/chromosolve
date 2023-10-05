using ChromoSolve;

namespace TravelingSalesman;

public class FitnessFunction : IFitnessFunction
{
    public double StopThreshold => double.Epsilon;
    public double Evaluate(double[] chromosome)
    {
        // Use chromosome (the genetic information) to create an individual
        // (a.k.a. phenotype) that represents a candidate solution.
        var individual = PhenotypeMapper.FromGenotype(chromosome);
        
        // Now we need to compute the fitness value - the quality of this
        // candidate solution. The lower the value, the better solution.
        //
        // Theoretically, the best solution would be if Bob, the salesman,
        // didn't need to travel at all (zero kilometers). That's unrealistic
        // so the goal is to arrive at a solution with a shortest distance
        // possible.
        //
        // We don't know how long is the optimal route. If we knew, we wouldn't
        // have a problem to optimize in the first place.
        //
        // That's OK as long as we can compare two individuals to each other.
        // Here it's easy: the longer the distance, the worse the candidate
        // solution is so we can simply return the total distance travelled
        // as the fitness value.

        var visitedCities = individual.VisitedCities;
        var distanceTravelled = 0;

        for (var i = 1; i < visitedCities.Length; i++)
        {
            var from = visitedCities[i - 1];
            var to = visitedCities[i];

            distanceTravelled += WorldMap.GetDistance(from, to);
        }

        return distanceTravelled;
    }
}