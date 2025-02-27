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

        try{

            for (int i=0; i < 10; i++){

                enumerator.MoveNext();
                double value = enumerator.Current;
                
                Assert.InRange(value, 0.0, 1.0);
            }
        }
        catch (InvalidSequenceException){}
    }

    [Fact]
    public void ThrowsExceptionIfNumberIsInvalid(){

        var generator = new RandomFloatEnumerable();
        var enumerator = generator.GetEnumerator();

        int count = 0;

        var throwException = false;
        try{

            while (enumerator.MoveNext()){

                double current = enumerator.Current;

                if(current <= 0.5){
                    
                    count++;
                    if(count == 3){

                        throw new InvalidSequenceException("There are 3 consecutive" + 
                        "numbers that are less than or equal to 0.5");
                    }
                }
                else{

                    count = 0;
                }
            }
        }
        catch (InvalidSequenceException){
            throwException = true;
        }
        Assert.True(throwException, "The exception was not thrown.");
    }

}
