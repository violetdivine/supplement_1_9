using System.Runtime.CompilerServices;
using static supplement_1_9.RandomFloatEnumerable;

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
    
    /// <summary>
    /// Test checks if numbers are in valid range 0.0 - 1.0.
    /// Try/Catch is for the exception when necessary.
    /// </summary>
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

    /// <summary>
    /// Test checks if sequence is valid, throws an exception if not.
    /// </summary>
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

    /// <summary>
    /// Checks if quarter objects are equal
    /// </summary>
    [Fact]
    public void ShouldTestIfQuartersAreEqual(){

        var q1 = new Quarter(0.1);
        var q2 = new Quarter(0.2);
        var q3 = new Quarter(0.3);
        var q4 = new Quarter(0.6);

        Assert.True(q1 == q2, "Numbers in the same quarter should be equal.");
        Assert.False(q1 == q3, "Numbers in different quarters should not be equal.");
        Assert.True(q3 == q4, "Numbers in the same quarter should be equal.");

    }

    /// <summary>
    /// Tests operators to ensure they're working correctly.
    /// </summary>
    [Fact]
    public void ShouldTestQuarterComparisons(){

        var q1 = new Quarter(0.1);
        var q2 = new Quarter(0.3);
        var q3 = new Quarter(0.6);
        var q4 = new Quarter(0.9);  
    
        Assert.True(q1 < q2, "q1 should be less than q2");
        Assert.True(q1 < q3, "q3 should be greater than q1");
        Assert.False(q3 < q2, "q2 should not be greater than q3");
        Assert.True(q1 < q4, "q4 should be greater than q1");
        
        Assert.True(q1 <= q2, "q1 should be less than or equal to q2");
        Assert.True(q3 <= q3, "q4 should be greater than or equal to q3");
        Assert.False(q3 <= q2, "q2 should not be greater than or equal to q3");
    }   

    /// <summary>
    /// Makes sure that GetHashCode() produces hash codes for quarters that
    /// are in the same group.
    /// </summary>
    [Fact]
    public void ShouldTestHashCodeConsistency(){

        var q1 = new Quarter(0.1);
        var q2 = new Quarter(0.2);
        var q3 = new Quarter(0.3);
        var q4 = new Quarter(0.6);

        Assert.Equal(q1.GetHashCode(), q2.GetHashCode());
        Assert.NotEqual(q1.GetHashCode(), q3.GetHashCode());
        Assert.Equal(q3.GetHashCode(), q4.GetHashCode());

        
    }

}
