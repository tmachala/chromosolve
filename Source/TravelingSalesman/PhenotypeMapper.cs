using ChromoSolve;

namespace TravelingSalesman;

public static class PhenotypeMapper
{
    /// <summary>
    /// Each gene represents a city to visit so we'll need as many genes
    /// as there are cities that Bob has to visit.
    /// </summary>
    public static int RequiredChromosomeLength => Enum.GetValues<City>().Length;
    
    /// <summary>
    /// Turns genotype, the genetic information, into a phenotype, a.k.a an Individual.
    /// </summary>
    public static Individual FromGenotype(double[] genotype)
    {
        var remainingCities = Enum.GetValues<City>().ToList();
        var visitedCities = new City[CityCount];

        for (var i = 0; i < visitedCities.Length; i++)
        {
            var gene = genotype[i];
            var cityToVisit = EvolutionUtils.ChooseOne(gene, remainingCities);
            
            visitedCities[i] = cityToVisit;
            remainingCities.Remove(cityToVisit);
        }

        return new Individual(visitedCities);
    }

    private static readonly int CityCount = Enum.GetValues<City>().Length;
}