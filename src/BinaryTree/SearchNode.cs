namespace BinaryTree;

// Every element at the left must to be less than its root's value.
// Every element at the right must to be grather or equal than its root's value.
/// Left and right trees are ABB too.

public class SearchNode
{
    private double? _value;
    private int _level = 1;

    private SearchNode? _left = null;
    private SearchNode? _right = null;

    private SearchNode? _parent = null;

    public SearchNode() { }
    private SearchNode(double value, SearchNode parent)
    {
        this._value = value;
        this._level = parent._level + 1;
        
        this._parent = parent;
    }

    /// <summary>
    /// Searches for the right position to the new node to be included and adds it.
    /// </summary>
    public void Add(double value)
    {
        if (this._value is null)
        {
            this._value = value;
        }
        else if (value < this._value)
        {
            if (this._left is not null)
                this._left.Add(value);
            else
                this._left = new SearchNode(value, this);
        }
        else
        {
            if (this._right is not null)
                this._right.Add(value);
            else
                this._right = new SearchNode(value, this);
        }
    }

    /// <summary>
    /// Searches for the right node to delete and deletes it.
    /// </summary>
    public void Delete(double value)
    {
        // If value to delete is less than actual node's value, searches in the left child node and removes it.
        if (value < this._value)
        {
            if (this._left is not null)
                this._left.Delete(value);
        }
        // If value to delete is grather than actual node's value, searches in the right child node and removes it.
        else if (value > this._value)
        {
            if (this._right is not null)
                this._right.Delete(value);
        }
        // If actual node's value equals to value to delete, deletes it.
        else
        {
            // In case of actual node being leaf node.
            if (this.IsLeafNode())
            {
                if (this._parent is not null)
                    if (value > this._parent._value)
                        this._parent._right = null;
                    else
                        this._parent._left = null;
                else
                    this._value = null;
            }
            else
            {
                // If parent node isn't null ("we are" not in the root node)
                if (this._parent is not null)
                {
                    // We're the left child node from parent.
                    if (this._parent._value > value)
                    {
                        if (this._left is null) 
                        {
                            this._parent._left = this._right;
                            this._parent._left!.LDec(); // '!' mark: already checked if "we're" a leaf node.
                        }
                        else if (this._right is null) 
                        {
                            this._parent._left = this._left;
                            this._parent._left.LDec();
                        }
                        else
                        {
                            SearchNode n = this._right;
                            while(n!._left is not null)
                            {
                                this._left.LInc();
                                n = n._left;
                            }

                            this._parent._left = this._right;
                            this._right.LDec();                         
                            
                            n._left = this._left;
                        }
                    }
                    // We're the right child node from parent.
                    else
                    {
                        if (this._left is null)
                        {
                            this._parent._right = this._right;
                            this._parent._right!.LDec(); // '!' mark: already checked if "we're" a leaf node.
                        }
                        else if (this._right is null)
                        {
                            this._parent._right = this._left;
                            this._parent._right!.LDec();
                        }
                        else
                        {
                            SearchNode n = this._right;
                            while(n!._left is not null)
                            {
                                this._left.LInc();
                                n = n._left;
                            }
                            
                            this._parent._left = this._right;
                            this._right.LDec();

                            n._left = this._left;
                        }
                    }
                }
                else
                {
                    this._value = null;
                }
            }
        }
    }

    /// <summary>
    /// Prints the whole binary tree. The number inside () represents the level.
    /// </summary>
    public void Print()
    {
        if (this._left is not null)
            this._left.Print();
        
        Console.Write($" {this._value}({this._level})");

        if (this._right is not null)
            this._right.Print();
    }

    /// <summary>
    /// Verifies if the node is a leaf node.
    /// </summary>
    public bool IsLeafNode() =>
        this._left is null && this._right is null;

    /// <sumary>
    /// Sets all properties to those provided.
    /// </summary>
    public void Set(double? value, SearchNode? left, SearchNode? right, SearchNode? parent)
    {
        this._value = value;

        this._left = left;
        this._right = right;

        this._parent = parent;
    }

    /// <summary>
    /// Increments by one all subnodes level of the specified node.
    /// </summary>
    private void LInc()
    {
        ++this._level;

        this._left?.LInc();
        this._right?.LInc();
    }

    /// <summary>
    /// Decrements by one all subnodes level of the specified node.
    /// </summary>
    private void LDec()
    {
        --this._level;

        this._left?.LDec();
        this._right?.LDec();
    }
}