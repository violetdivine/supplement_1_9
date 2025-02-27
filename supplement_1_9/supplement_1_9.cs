using System.Collections;

namespace supplement_1_9;

/// <summary>
/// Throws an exception when an invalid sequence is recognized.
/// </summary>
public class InvalidSequenceException : Exception{
    
    /// <summary>
    /// Initializes InvalidSequenceException() with a error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public InvalidSequenceException(string message) : base(message) {}

}

public class RandomFloatEnumerable : IEnumerable<double>{

    private Random _random = new Random();

    public IEnumerator<double> GetEnumerator(){

        int lowCount = 0;

        while (true){

            double num = _random.NextDouble();
            yield return num;

            if(num <= 0.5){

                lowCount++;
                if (lowCount == 3){
                    throw new InvalidSequenceException("3 consecutive numbers are " +
                    "less than or equal to 0.5.");
                }
            }
            else{
                
                lowCount = 0;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator(){

        return GetEnumerator();
    }
}
