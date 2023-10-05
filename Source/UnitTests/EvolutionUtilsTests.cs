// ReSharper disable ConvertToConstant.Local
// ReSharper disable SuggestVarOrType_BuiltInTypes
namespace ChromoSolve.UnitTests;

public class EvolutionUtilsTests
{
    [Theory]
    [InlineData(0, 0, 1, 0)]
    [InlineData(0, 21.5, 30, 21.5)]
    [InlineData(0.5, 0, 10, 5)]
    [InlineData(1, 32.7, 76.2, 76.2)]
    public void ScaleToRange_Double(double gene, double min, double max, double expected)
    {
        var actual = EvolutionUtils.ScaleToRange(gene, min, max);
        Assert.Equal(expected, actual, precision: 7);
    }
    
    [Theory]
    [InlineData(-0.01)]
    [InlineData(1.01)]
    public void ScaleToRange_Double_GivenGeneOutOfRangeThrows(double gene)
    {
        double min = 0;
        double max = 10;
        
        Assert.Throws<ArgumentOutOfRangeException>(() => EvolutionUtils.ScaleToRange(gene, min, max));
    }
    
    [Theory]
    [InlineData(0, 0, 1, 0)]
    [InlineData(0, 21, 30, 21)]
    [InlineData(0.0001, 21, 30, 21)]
    [InlineData(0.5, 0, 10, 5)]
    [InlineData(0.9999, 32, 76, 76)]
    [InlineData(1, 32, 76, 76)]
    public void ScaleToRange_Int(double gene, int min, int max, int expected)
    {
        var actual = EvolutionUtils.ScaleToRange(gene, min, max);
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(-0.01)]
    [InlineData(1.01)]
    public void ScaleToRange_Int_GivenGeneOutOfRangeThrows(double gene)
    {
        int min = 0;
        int max = 0;
        
        Assert.Throws<ArgumentOutOfRangeException>(() => EvolutionUtils.ScaleToRange(gene, min, max));
    }

    [Theory]
    [InlineData(0, "Apple")]
    [InlineData(0.5, "Banana")]
    [InlineData(0.99, "Cherry")]
    [InlineData(1, "Cherry")]
    public void ChooseOne_GivenValidGenePicksItem(double gene, string expected)
    {
        // Arrange
        var items = new[] { "Apple", "Banana", "Cherry" };
        
        // Act
        var actual = EvolutionUtils.ChooseOne(gene, items);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(-0.01)]
    [InlineData(1.01)]
    public void ChooseOne_GivenGeneOutOfRangeThrows(double gene)
    {
        var items = new[] { "Apple", "Banana", "Cherry" };
        Assert.Throws<ArgumentOutOfRangeException>(() => EvolutionUtils.ChooseOne(gene, items));
    }

    [Fact]
    public void ChooseOne_GivenEmptyListThrows()
    {
        var gene = 0.5;
        var items = Array.Empty<int>();
        
        Assert.Throws<ArgumentException>(() => EvolutionUtils.ChooseOne(gene, items));
    }
}