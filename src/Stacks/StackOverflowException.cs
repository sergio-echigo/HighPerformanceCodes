namespace Stacks;

public class StackOverflowException : Exception
{
    public override string Message { get; }
    public StackOverflowException(string msg = "Stack overflow.")
    {
        this.Message = msg;
    }
}