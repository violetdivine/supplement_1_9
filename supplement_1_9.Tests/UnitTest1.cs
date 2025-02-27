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
    
    [Fact]
    public void ShouldGenerateCorrectNumbersInRange()
    {
        var generator = new RandomFloatEnumerable();
        var enumerator = generator.GetEnumerator();

        for (int i=0; i < 10; i++){

            enumerator.MoveNext();
            double value = enumerator.Current;
            
            Assert.InRange(value, 0.0, 1.0);
        }
    }

}
