namespace Stacks;

public class Node<T>
{
    private T? _value { get; set; } = default(T);
    private Node<T>? _nextNode { get; set; } = null;

    private int? _limit;

    public int Length => this.Count();

    public Node(int limit) 
    {
        _limit = limit;
    }
    private Node(T? value, Node<T>? node)
    {
        this._value = value;
        this._nextNode = node;

        this._limit = null;
    }

    /// <summary>
    /// Adds a node in the top of the stack.
    /// </summary>
    public void Push(T? value)
    {
        if (this.IsFull())
            throw new StackOverflowException();

        Node<T> top = new Node<T>(value, this._nextNode);
        this._nextNode = top;
    }

    /// <summary>
    /// Deletes a node from the top of the stack.
    /// </summary>
    public void Pop()
    {
        if (this.IsEmpty())
            throw new StackOverflowException();

        this._nextNode = this._nextNode?._nextNode;
    }

    /// <summary>
    /// Verifies if stack is full.
    /// </summary>
    public bool IsFull() =>
        this.Count() == this._limit;

    /// <summary>
    /// Verifies if stack is empty;
    /// </summary>
    public bool IsEmpty() =>
        this.Count() == 0;

    /// <summary>
    /// Prints all values inside the stack.
    /// </summary>
    public void PrintValues()
    {
        for(var n = this; n._nextNode is not null; n = n._nextNode)
            Console.WriteLine(n._nextNode._value);
    }

    /// <summary>
    /// Get the number of elements in the stack.
    /// </summary>
    private int Count()
    {
        var i = 0;
        for(var n = this; n._nextNode is not null; ++i)
            n = n._nextNode;

        return i;
    }
}