using System.Collections.Immutable;

namespace TravelingSalesman;

public static class WorldMap
{
    /// <summary>
    /// Returns the distance between two cities in kilometers.
    /// </summary>
    public static int GetDistance(City from, City to)
    {
        // The distance from A to B is the same as from B to A
        var key = ToRouteKey(from, to);
        return Distances[key];
    }

    private static string ToRouteKey(City a, City b)
    {
        var orderedCities = new[] { a, b }.OrderBy(c => c).ToArray();
        return $"{orderedCities[0]}-{orderedCities[1]}";
    }

    /// <summary>
    /// The distance between cities in kilometers.
    /// </summary>
    /// <remarks>
    /// Since the distance is the same in both directions, we only need to define each route once.
    /// </remarks>
    private static readonly Dictionary<string, int> Distances = new()
    {
        [ToRouteKey(City.Prague, City.Brno)] = 208,
        [ToRouteKey(City.Prague, City.Ostrava)] = 374,
        [ToRouteKey(City.Prague, City.Liberec)] = 110,
        [ToRouteKey(City.Prague, City.Plzen)] = 91,
        [ToRouteKey(City.Prague, City.CeskeBudejovice)] = 148,
        [ToRouteKey(City.Prague, City.Unetice)] = 14,
        [ToRouteKey(City.Prague, City.Svijany)] = 84,
        [ToRouteKey(City.Prague, City.Zlin)] = 299,
        [ToRouteKey(City.Prague, City.Most)] = 98,
        
        [ToRouteKey(City.Brno, City.Ostrava)] = 171,
        [ToRouteKey(City.Brno, City.Liberec)] = 307,
        [ToRouteKey(City.Brno, City.Plzen)] = 295,
        [ToRouteKey(City.Brno, City.CeskeBudejovice)] = 214,
        [ToRouteKey(City.Brno, City.Unetice)] = 230,
        [ToRouteKey(City.Brno, City.Svijany)] = 280,
        [ToRouteKey(City.Brno, City.Zlin)] = 96,
        [ToRouteKey(City.Brno, City.Most)] = 298,
        
        [ToRouteKey(City.Ostrava, City.Liberec)] = 349,
        [ToRouteKey(City.Ostrava, City.Plzen)] = 464,
        [ToRouteKey(City.Ostrava, City.CeskeBudejovice)] = 384,
        [ToRouteKey(City.Ostrava, City.Unetice)] = 400,
        [ToRouteKey(City.Ostrava, City.Svijany)] = 464,
        [ToRouteKey(City.Ostrava, City.Zlin)] = 126,
        [ToRouteKey(City.Ostrava, City.Most)] = 467,
        
        [ToRouteKey(City.Liberec, City.Plzen)] = 206,
        [ToRouteKey(City.Liberec, City.CeskeBudejovice)] = 250,
        [ToRouteKey(City.Liberec, City.Unetice)] = 120,
        [ToRouteKey(City.Liberec, City.Svijany)] = 29,
        [ToRouteKey(City.Liberec, City.Zlin)] = 402,
        [ToRouteKey(City.Liberec, City.Most)] = 191,
        
        [ToRouteKey(City.Plzen, City.CeskeBudejovice)] = 136,
        [ToRouteKey(City.Plzen, City.Unetice)] = 91,
        [ToRouteKey(City.Plzen, City.Svijany)] = 179,
        [ToRouteKey(City.Plzen, City.Zlin)] = 388,
        [ToRouteKey(City.Plzen, City.Most)] = 101,
        
        [ToRouteKey(City.CeskeBudejovice, City.Unetice)] = 174,
        [ToRouteKey(City.CeskeBudejovice, City.Svijany)] = 224,
        [ToRouteKey(City.CeskeBudejovice, City.Zlin)] = 309,
        [ToRouteKey(City.CeskeBudejovice, City.Most)] = 241,
        
        [ToRouteKey(City.Unetice, City.Svijany)] = 94,
        [ToRouteKey(City.Unetice, City.Zlin)] = 316,
        [ToRouteKey(City.Unetice, City.Most)] = 82,
        
        [ToRouteKey(City.Svijany, City.Zlin)] = 375,
        [ToRouteKey(City.Svijany, City.Most)] = 164,
        
        [ToRouteKey(City.Zlin, City.Most)] = 392
    };
}