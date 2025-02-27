namespace supplement_1_9.Tests;

public class UnitTest1
{
    /// <summary>
    /// Test to ensure that the exception stores the error message.
    /// </summary>
    [Fact]
    public void ShouldThrowExpeceptionWhenInvalidSequence()
    {
        var ex = new InvalidSequenceException("Error message - Test");
        Assert.Equal("Error message - Test", ex.Message);
    }
}
