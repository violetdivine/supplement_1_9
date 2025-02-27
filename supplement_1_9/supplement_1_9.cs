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
