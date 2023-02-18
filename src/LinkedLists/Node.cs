using System.Linq.Expressions;

namespace LinkedLists;

public class Node<T>
{
    private T? Value { get; set; } = default(T);
    private Node<T>? NxtNode { get; set; } = null;

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
        Value = value;
        NxtNode = nxt;
    }

    /// <summary>
    /// Add a new node into the end of the list.
    /// </summary>
    public void Add(T? value)
    {
        var last = this.GetLast();
        Node<T> n = new(value, null);

        last.NxtNode = n;
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
            this.NxtNode = this.NxtNode!.NxtNode;
        }
        else
        {
            var node = this.GetNodeAt(index - 1);
            if (node is not null)
                node!.NxtNode = node!.NxtNode!.NxtNode;
        }

        toRm.Value = default(T);
        toRm.NxtNode = null;
    }

    /// <summary>
    /// Verifies if there is any element in the list.
    /// </summary>
    public bool Any() =>
        this.NxtNode is not null;

    /// <summary>
    /// Prints all values inside the list.
    /// </summary>
    public void PrintAll()
    {
        var aux = this.NxtNode;
        for(int i = 0; i < this.Count(); ++i)
        {
            Console.WriteLine(aux!.Value);
            aux = aux!.NxtNode;
        }
    }

    /// <summary>
    /// Gets last node in the Linked list.
    /// </summary>
    private Node<T> GetLast()
    {
        var aux = this;
        while (aux.NxtNode is not null)
        {
            aux = aux.NxtNode;
        }

        return aux;
    }

    /// <summary>
    /// Counts how many elements are in the linked list.
    /// </summary>
    private int Count()
    {
        var i = 0;
        for (var n = this; n.NxtNode is not null; ++i)
            n = n.NxtNode;

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
        var aux = this.NxtNode;
        for (int j = 0; j < i; ++j)
            aux = aux!.NxtNode;

        return aux;
    }

    /// <summary>
    /// Gets node's value at the specified index.
    /// <summary>
    private T? GetValueAt(int i)
    {
        var aux = this;
        T? toReturn = aux.NxtNode!.Value;

        for (int j = 0; j < i; ++j)
        {
            aux = aux.NxtNode;
            toReturn = aux!.NxtNode!.Value;
        }

        return toReturn;
    }
}