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

/// <summary>
/// Manages values between 0.0-1.0, compares them, and checks equality.
/// Overrides appropriate operations and makes sure values are treated equally.
/// </summary>
public class Quarter
{
    public double Value { get; }

    public Quarter(double value)
    {
        if (value < 0.0 || value >= 1.0)
            throw new ArgumentOutOfRangeException(nameof(value), "Value must be in range 0.0-1.0");
        Value = value;
    }

    private int GetQuarter()
    {
        if (Value < 0.25) return 1;
        if (Value < 0.5) return 2;
        if (Value < 0.75) return 3;
        return 4;
    }

    public static bool operator ==(Quarter q1, Quarter q2)
    {
        if (ReferenceEquals(q1, q2)) return true;
        if (q1 is null || q2 is null) return false;
        return q1.GetQuarter() == q2.GetQuarter();
    }

    public static bool operator !=(Quarter q1, Quarter q2) => !(q1 == q2);

    public static bool operator >(Quarter q1, Quarter q2) => q1.GetQuarter() > q2.GetQuarter();
    public static bool operator <(Quarter q1, Quarter q2) => q1.GetQuarter() < q2.GetQuarter();
    public static bool operator >=(Quarter q1, Quarter q2) => q1.GetQuarter() >= q2.GetQuarter();
    public static bool operator <=(Quarter q1, Quarter q2) => q1.GetQuarter() <= q2.GetQuarter();

    public override bool Equals(object obj)
    {
        return obj is Quarter quarter && this.GetQuarter() == quarter.GetQuarter();
    }

    public override int GetHashCode()
    {
        return GetQuarter(); 
    }
}
