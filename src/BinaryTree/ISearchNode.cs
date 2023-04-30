namespace BinaryTree;

public interface ISearchNode
{
    /// <summary>
    /// Searches for the right position to the new node to be included and adds it.
    /// </summary>
    public void Add(params double[] value);
    
    /// <summary> 
    /// Rotates the main node to the right. 
    /// </summary>
    public void ManuallyRightRot();

    /// <summary> 
    /// Rotates the main node to the left. 
    /// </summary>
    public void ManuallyLeftRot();

    /// <summary>
    /// Searches for the right node to delete and deletes it.
    /// </summary>
    public void Delete(params double[] value);

    /// <summary>
    /// Prints the whole binary tree. The number inside () represents the level.
    /// </summary>
    public void Print(string msg = "", int l = 0);
}