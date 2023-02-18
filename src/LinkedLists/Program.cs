using LinkedLists;

#region Linked lists
// Linked list
Node<int> list = new Node<int>();
list.PrintAll();

// Inserting elements
for(var i = 0; i < 100; ++i)
    list.Add(i);

// Removing and outputing
list.RemoveAt(70);
list.PrintAll();

// Removing all
while(list.Any())
    list.RemoveAt(0);    

// Verifying if there are any element
Console.WriteLine("Any elements in the limit: " + list.Any());
#endregion