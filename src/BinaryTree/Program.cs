using BinaryTree;

// Search Binary Trees
SearchNode binaryTreeAbb = new SearchNode(TreeType.BST, ConsoleColor.Green);
binaryTreeAbb.Add(20, 50, 15, 10, 18, 17, 16, 14, 13);

binaryTreeAbb.Print("Basic binary tree, before deleting key 15:");

binaryTreeAbb.Delete(15);
binaryTreeAbb.Print("After removing key 15:");

// New one, and manually balancing it
SearchNode leftRight = new SearchNode(TreeType.BST, ConsoleColor.Red);
leftRight.Add(50, 70, 30, 20, 40, 35, 45);

leftRight.Print("New Binary Tree, not balanced:");

leftRight.Left!.ManuallyLeftRot();
leftRight.Print("Left rotated one, but still not balanced:");

leftRight.ManuallyRightRot();
leftRight.Print("After RightRot, now, full balanced:");

// Another manually balancing case
SearchNode rightLeft = new SearchNode(TreeType.BST, ConsoleColor.Yellow);
rightLeft.Add(50, 70, 90, 60, 55, 65, 20);

rightLeft.Print("Another binary tree, not balanced:");

rightLeft.Right!.ManuallyRightRot();
rightLeft.ManuallyLeftRot();

rightLeft.Print("After performing RightRot and LeftRot, now balanced:");

// Automatically being balanced
SearchNode alwaysBalanced = new SearchNode(TreeType.AVL, ConsoleColor.Cyan);
alwaysBalanced.Add(50, 70, 30, 20, 40, 35, 45);

alwaysBalanced.Print("Already balanced (automatically balanced)");

// Another one being automatically balanced
SearchNode anotherBalanced = new SearchNode(BinaryTree.TreeType.AVL, ConsoleColor.Magenta);
anotherBalanced.Add(13, 10, 15, 16, 5, 11, 4, 8);
anotherBalanced.Add(3);

anotherBalanced.Print("Already balaced too!");