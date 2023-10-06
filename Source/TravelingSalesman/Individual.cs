using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
        return string.Join(" → ", VisitedCities.Select(FormatCity));
    }

    private static string FormatCity(City city)
    {
        var fieldInfo = typeof(City).GetField(city.ToString());
        var attr = fieldInfo!.GetCustomAttribute<DisplayAttribute>()!;
        return $"🏠{attr.Name}";
    }
}