namespace ChromoSolve.UnitTests;

public class EvolutionResultTests
{
    [Fact]
    public void Constructor_SavesAttribs()
    {
        // Arrange
        var individual = new MyIndividual();
        
        // Act;
        var sut = new EvolutionResult<MyIndividual>(2, 3, individual);

        // Assert
        Assert.Equal(2, sut.Generation);
        Assert.Equal(3, sut.Fitness);
        Assert.Same(individual, sut.Individual);
    }

    private class MyIndividual
    {
    };
}