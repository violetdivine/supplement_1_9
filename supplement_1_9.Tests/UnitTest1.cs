namespace supplement_1_9.Tests;

public class UnitTest1
{
    [Fact]
    public void ShouldThrowExpeceptionWhenInvalidSequence()
    {
        var ex = new InvalidSequenceException("Error message - Test");
        Assert.Equal("Error message - Test", ex.Message);
    }
}
