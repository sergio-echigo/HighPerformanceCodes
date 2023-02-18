namespace LinkedLists;

public class OutOfBoundsException : Exception
{
    public override string Message { get; }
    public OutOfBoundsException(string msg)
    {
        Message = msg;
    }
}