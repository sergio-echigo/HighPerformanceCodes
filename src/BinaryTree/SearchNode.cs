namespace BinaryTree;

// Every element at the left must to be less than its root's value.
// Every element at the right must to be grather or equal than its root's value.
/// Left and right trees are ABB too.

public enum TreeType
{
    BST,
    AVL
}

public class SearchNode : ISearchNode
{
    private double? _value;
    private TreeType _treeType;

    private int _level = 1;

    private SearchNode? _left = null;
    private SearchNode? _right = null;

    public SearchNode? Left => this._left;
    public SearchNode? Right => this._right;

    // Maybe it's a better idea to store in memory the 'Balance Factor' as a property.
    // Well, isn't a problem to iterate over three or four subnodes. I'm not sure at all, but I think that doing this to a lot of them isn't efficient.
    // After all, there's the need to update the property after each insert or delete operation. I'll let this to the future.
    private int _subNodesDepthDiff
    {
        get
        {
            if (this._left is null && this._right is null)
                return 0;
            else
                if (this._left is null)
                return ((this._right!.GetDepthest()._level - this._level));
            else if (this._right is null)
                return (-1) * ((this._left.GetDepthest()._level - this._level));
            else
                return (this._right.GetDepthest()._level - this._level) - (this._left.GetDepthest()._level - this._level);
        }
    }

    private SearchNode? _parent = null;

    private ConsoleColor _color;
    public SearchNode(TreeType treeType, ConsoleColor color)
    {
        this._treeType = treeType;
        this._color = color;
    }

    private SearchNode(double value, SearchNode parent)
    {
        this._value = value;
        this._level = parent._level + 1;

        this._parent = parent;
    }

    private SearchNode(double value, SearchNode? left, SearchNode? right, SearchNode? parent)
    {
        this._value = value;

        this._left = left;
        this._right = right;

        this._parent = parent;
        this._level = parent is null ? 0 : parent._level + 1;
    }

    public void Add(params double[] values)
    {
        foreach (var v in values)
        {
            var added = this.Add(v)._parent;

            if (this._treeType == TreeType.AVL)
            {
                while (added is not null)
                {
                    added.Balance();
                    added = added._parent;
                }
            }
        }
    }

    public void Delete(params double[] values)
    {
        foreach (var v in values)
        {
            this.Delete(v);

            if (this._treeType == TreeType.AVL)
                this.Balance();
        }
    }

    public void Print(string msg = "", int l = 0)
    {
        // If no node was added.
        if (this._value is null)
            return;

        // Changing colors
        if (!string.IsNullOrEmpty(msg))
        {
            Console.ForegroundColor = this._color;

            Console.WriteLine(msg);
            Console.ResetColor();
        }

        if (this._left is not null)
            this._left.Print(l: l + 1);

        // Format: "| this._left (this._left._value) this._value (this._level) this._right (this._right._value) |"
        // Should I consider doing an ASCII formatted art?
        Console.Write($"| {(this._left is null ? string.Empty : (this._left._value + $"({this._left._level})"))} / {this._value}({this._level}) \\ {(this._right is null ? string.Empty : this._right._value + $"({this._right._level})")} |");

        if (this._right is not null)
            this._right.Print(l: l + 1);

        if (!string.IsNullOrEmpty(msg))
            Console.WriteLine("\n");
    }

    public void ManuallyRightRot()
    {
        this.RightRot();
    }

    public void ManuallyLeftRot()
    {
        this.LeftRot();
    }
    
    private void RightRot()
    {
        if (this._left is null)
            throw new Exception("Left subnode is null, but a right rotate was tried to be executed.");
        else if (this._value is null)
            throw new Exception("There's no node inside tree.");

        this.Set((double?)this._left._value, this._left._left, new SearchNode((double)this._value!, this._left._right, this._right, this), this._parent);
        this._right!._parent = this;

        if (this._left is not null)
        {
            this._left._parent = this;
            this._left.LDec();

            if (this._right._right is not null)
                this._right._right.LInc();
        }
    }

    private void LeftRot()
    {
        if (this._right is null)
            throw new Exception("Left rightnode is null, but a left rotate was tried to be executed.");
        else if (this._value is null)
            throw new Exception("There's no node inside tree.");

        this.Set((double?)this._right._value, new SearchNode((double)this._value!, this._left, this._right._left, this), this._right._right, this._parent);
        this._left!._parent = this;

        if (this._right is not null)
        {
            this._right._parent = this;
            this._right.LDec();

            if (this._left._left is not null)
                this._left._left.LInc();
        }
    }

    /// <summary> Verifies if a node is a leaf node. </summary>
    private bool IsLeafNode() =>
        this._left is null && this._right is null;

    /// <sumary> Sets all properties to those provided. </summary>
    private void Set(double? value, SearchNode? left, SearchNode? right, SearchNode? parent)
    {
        this._value = value;

        this._left = left;
        this._right = right;

        this._parent = parent;
    }

    private SearchNode Add(double value)
    {
        if (this._value is null)
        {
            this._value = value;
            return this;
        }
        else if (value < this._value)
        {
            if (this._left is not null)
                return this._left.Add(value);
            else
            {
                this._left = new SearchNode(value, this);
                return this._left;
            }
        }
        else
        {
            if (this._right is not null)
                return this._right.Add(value);
            else
            {
                this._right = new SearchNode(value, this);
                return this._right;
            }
        }
    }

    private void Delete(double value)
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
                            this._right!._parent = this._parent; // '!' mark: already checked if "we're" a leaf node.

                            this._parent._left!.LDec(); // '!' mark: already checked if "we're" a leaf node.
                        }
                        else if (this._right is null)
                        {
                            this._parent._left = this._left;
                            this._left._parent = this._parent;

                            this._parent._left.LDec();
                        }
                        else
                        {
                            SearchNode n = this._right;
                            while (n!._left is not null)
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
                            while (n!._left is not null)
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

    /// <summary> Balances (only if unbalanced) a tree. </summary>
    private void Balance()
    {
        var diff = this._subNodesDepthDiff;

        // If it's unbalanced
        if (diff >= 2 || diff <= -2)
        {
            // More elements in the right "side"
            if (diff > 0)
            {
                // '!': There's no way this._right be null and greather than zero if this._subNodesDepthDiff is positive.
                var dif2 = this._right!._subNodesDepthDiff;
                if (this._right!._subNodesDepthDiff < 0)
                    this._right.RightRot();

                this.LeftRot();
            }
            // More elements in the left "side"
            else
            {
                // '!': There's no way this._left be null if this._sunNodesDepthDiff is negative.
                if (this._left!._subNodesDepthDiff > 0)
                    this._left.LeftRot();

                this.RightRot();
            }
        }
    }

    /// <summary> Increments by one a node's level and all its subnodes levels. </summary>
    private void LInc()
    {
        ++this._level;

        this._left?.LInc();
        this._right?.LInc();
    }

    /// <summary> Decrements by one a node's level and all its subnodes levels. </summary>
    private void LDec()
    {
        --this._level;

        this._left?.LDec();
        this._right?.LDec();
    }

    /// <summary> Gets the depthest node. </summary>
    private SearchNode GetDepthest()
    {
        if (this._left is null && this._right is null)
        {
            return this;
        }
        else if (this._left is null)
        {
            // this._right isn't null here.
            return this._right!.GetDepthest();
        }
        else if (this._right is null)
        {
            // this._left isn't null here.
            return this._left.GetDepthest();
        }
        else
        {
            // none of them is null
            var leftDepth = this._left.GetDepthest();
            var rightDepth = this._right.GetDepthest();

            return (leftDepth._level > rightDepth._level ? leftDepth : rightDepth);
        }
    }
}