namespace Queues;

public class EmptyQueueException : Exception
{
    public override string Message { get; }
    public EmptyQueueException(string msg = "Queue is empty!")
    {
        this.Message = msg;
    }
}