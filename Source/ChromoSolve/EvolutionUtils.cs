using System.Diagnostics;

namespace ChromoSolve;

public static class EvolutionUtils
{
    /// <summary>
    /// Scales the provided value to the specified range [min, max].
    /// </summary>
    /// <param name="gene">The value to scale, must be in range [0, 1].</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>The value scaled to the range [min, max].</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is less than 0 or greater than 1.</exception>
    public static double ScaleToRange(double gene, double min, double max)
    {
        EnsureValidRange(gene);
        return min + (max - min) * gene;
    }

    /// <summary>
    /// Scales the provided value to the specified integer range [min, max].
    /// </summary>
    /// <param name="gene">The value to scale, must be in range [0, 1].</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>The value scaled to the range [min, max] and rounded to the nearest integer.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value is less than 0 or greater than 1.</exception>
    public static int ScaleToRange(double gene, int min, int max)
    {
        EnsureValidRange(gene);
        return (int)Math.Round(min + (max - min) * gene);
    }

    /// <summary>
    /// Selects one item from a list based on the gene value.
    /// </summary>
    /// <typeparam name="T">The type of the items in the list.</typeparam>
    /// <param name="gene">The value used to determine the item to choose, must be in range [0, 1].</param>
    /// <param name="items">The list from which to select the item.</param>
    /// <returns>The selected item from the list.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the gene value is less than 0 or greater than 1.</exception>
    /// <exception cref="ArgumentException">Thrown then then list to choose from is empty.</exception>
    /// <remarks>
    /// The gene value is scaled to an index within the bounds of the list and used to select an item.
    /// </remarks>
    public static T ChooseOne<T>(double gene, IList<T> items)
    {
        EnsureValidRange(gene);
        EnsureNotEmpty(items);
        
        var index = ScaleToRange(gene, 0, items.Count - 1);
        return items[index];
    }

    [DebuggerStepThrough]
    private static void EnsureValidRange(double value)
    {
        if (value is < 0 or > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "The value to scale must be between 0 and 1!");
        }
    }

    [DebuggerStepThrough]
    private static void EnsureNotEmpty<T>(IList<T> items)
    {
        if (items.Count == 0)
        {
            throw new ArgumentException("The list to choose from must not be empty!", nameof(items));
        }
    }
}