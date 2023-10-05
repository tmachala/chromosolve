namespace TravelingSalesman;

/// <summary>
/// Represents a candidate solution of our Traveling Salesman Problem.
/// </summary>
public class Individual
{
    public City[] VisitedCities { get; }

    public Individual(City[] visitedCities)
    {
        VisitedCities = visitedCities;
    }

    public override string ToString()
    {
        return string.Join(" -> ", VisitedCities.Select(c => c.ToString()));
    }
}