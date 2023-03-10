using BinaryTree;

// Search Binary Trees
SearchNode binaryTreeAbb = new SearchNode();

binaryTreeAbb.Add(20);
binaryTreeAbb.Add(50);

binaryTreeAbb.Add(15);
binaryTreeAbb.Add(10);
binaryTreeAbb.Add(18);
binaryTreeAbb.Add(17);
binaryTreeAbb.Add(16);
binaryTreeAbb.Add(14);
binaryTreeAbb.Add(13);

Console.WriteLine("Old: ");
binaryTreeAbb.Print();

Console.WriteLine();
binaryTreeAbb.Delete(15);

Console.WriteLine("New: ");
binaryTreeAbb.Print();