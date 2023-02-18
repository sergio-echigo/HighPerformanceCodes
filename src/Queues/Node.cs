namespace Queues;

public class Node<T>
{
    private T? _value;
    private Node<T>? _nxt;

    public int Length => this.Count();

    public Node() {  }
    private Node(T? value, Node<T>? next)
    {
        this._value = value;
        this._nxt = next;
    }

    /// <summary>
    /// Adds an element to the end of the queue.
    /// </summary>
    public void Enqueue(T? value)
    {
        if (!this.IsEmpty())
        {
            var last = this.LastNode();
            last._nxt = new Node<T>(value, null);
        
            return;
        }

        this._nxt = new Node<T>(value, null);
    }

    /// <summary>
    /// Deletes an element from the start of the queue.
    /// </summary>
    public T? Dequeue()
    {
        if (this.IsEmpty())
            throw new EmptyQueueException();
        
        var copy = this._nxt!._value;
        
        this._nxt!._value = default(T);
        this._nxt = this._nxt._nxt;

        return copy;
    }

    /// <summary>
    /// Gets the element's value at the start of the queue.
    /// </summary>
    public T? First()
    {
        if (this.IsEmpty())
            throw new EmptyQueueException();
        
        return this._nxt!._value;
    }

    /// <summary>
    /// Gets the element's value at the end of the queue.
    /// </summary>
    public T? Last()
    {
        if (this.IsEmpty())
            throw new EmptyQueueException();
        
        return this._nxt!._value;
    }

    /// <summary>
    /// Verifies if the queue is empty.
    /// </summary>
    public bool IsEmpty() =>
        this._nxt is null;

    /// <summary>
    /// Prints all values from the beginning of the queue.
    /// </summary>
    public void PrintValues()
    {
        var f = this.FirstNode();
        while(f is not null)
        {
            Console.WriteLine(f._value);
            f = f._nxt;
        }
    }

    /// <summary>
    /// Gets the number of elements in the queue.
    /// </summary>
    private int Count()
    {
        int i = 0;
        for(var n = this; n._nxt is not null; n = n._nxt)
            ++i;
        
        return i;
    }

    /// <summary>
    /// Gets the first node in the queue.
    /// </summary>
    private Node<T> FirstNode()
    {
        if (this.IsEmpty())
            throw new EmptyQueueException();
        
        return this._nxt!;
    }

    /// <summary>
    /// Gets the last node in the queue.
    /// </summary>
    private Node<T> LastNode()
    {
        if (this.IsEmpty())
            throw new EmptyQueueException();
        
        var aux = this;
        while (aux._nxt is not null)
            aux = aux._nxt;
        
        return aux;
    }
}