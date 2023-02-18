using System.Linq.Expressions;

namespace LinkedLists;

public class Node<T>
{
    private T? _value { get; set; } = default(T);
    private Node<T>? _nxt { get; set; } = null;

    public T? this[int i]
    {
        get
        {
            if (this.IsOutsideOfBounds(i))
                throw new OutOfBoundsException("Index out of bounds!");

            return this.GetValueAt(i);
        }

        private set
        {
            if (this.IsOutsideOfBounds(i))
                throw new OutOfBoundsException("Index out of bounds!");

            
        }
    }

    public int Length => this.Count();

    public Node()
    {

    }

    private Node(T? value, Node<T>? nxt)
    {
        _value = value;
        _nxt = nxt;
    }

    /// <summary>
    /// Add a new node into the end of the list.
    /// </summary>
    public void Add(T? value)
    {
        var last = this.GetLast();
        Node<T> n = new(value, null);

        last._nxt = n;
    }

    /// <summary>
    /// Deletes a node in the specified index from the list and resize it.
    /// </summary>
    public void RemoveAt(int index)
    {
        if (this.IsOutsideOfBounds(index))
            throw new OutOfBoundsException("Index out of bounds!");
        
        var toRm = this.GetNodeAt(index)!;

        if (index == 0)
        {
            this._nxt = this._nxt!._nxt;
        }
        else
        {
            var node = this.GetNodeAt(index - 1);
            if (node is not null)
                node!._nxt = node!._nxt!._nxt;
        }

        toRm._value = default(T);
        toRm._nxt = null;
    }

    /// <summary>
    /// Verifies if there is any element in the list.
    /// </summary>
    public bool Any() =>
        this._nxt is not null;

    /// <summary>
    /// Prints all values inside the list.
    /// </summary>
    public void PrintAll()
    {
        var aux = this._nxt;
        for(int i = 0; i < this.Count(); ++i)
        {
            Console.WriteLine(aux!._value);
            aux = aux!._nxt;
        }
    }

    /// <summary>
    /// Gets last node in the Linked list.
    /// </summary>
    private Node<T> GetLast()
    {
        var aux = this;
        while (aux._nxt is not null)
        {
            aux = aux._nxt;
        }

        return aux;
    }

    /// <summary>
    /// Counts how many elements are in the linked list.
    /// </summary>
    private int Count()
    {
        var i = 0;
        for (var n = this; n._nxt is not null; ++i)
            n = n._nxt;

        return i;
    }

    /// <summary>
    /// Verifies if the param `i` is outside the bounds of the list.
    /// </summary>
    private bool IsOutsideOfBounds(int i) =>
        i >= this.Count() || i < 0;

    /// <summary>
    /// Gets node at the specified index.
    /// <summary>
    private Node<T>? GetNodeAt(int i)
    {
        var aux = this._nxt;
        for (int j = 0; j < i; ++j)
            aux = aux!._nxt;

        return aux;
    }

    /// <summary>
    /// Gets node's value at the specified index.
    /// <summary>
    private T? GetValueAt(int i)
    {
        var aux = this;
        T? toReturn = aux._nxt!._value;

        for (int j = 0; j < i; ++j)
        {
            aux = aux._nxt;
            toReturn = aux!._nxt!._value;
        }

        return toReturn;
    }
}