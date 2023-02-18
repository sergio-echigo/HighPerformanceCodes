using Queues;

// Queue
Node<string> queue = new Node<string>();
Console.WriteLine($"Queue is empty: {queue.IsEmpty()}. Count: {queue.Length}\n");

// Adding values to the queue
queue.Enqueue("Hello, world!");
queue.Enqueue("Olá, mundo!");

queue.PrintValues();
Console.WriteLine();

Console.WriteLine($"Queue is empty: {queue.IsEmpty()}. Count: {queue.Length}\n");

// Removing items
while(!queue.IsEmpty())
{
    var i = queue.Dequeue();
    Console.WriteLine($"Just dequeued: \"{i}\"");
}

Console.WriteLine();
Console.WriteLine($"Queue is empty: {queue.IsEmpty()}. Count: {queue.Length}\n");

/* "People queue" */
Node<string> people = new Node<string>();
while (true)
{
    PrintMenu();
    if (int.TryParse(Console.ReadLine(), out var opt))
    {
        Console.WriteLine();

        if (Enum.IsDefined(typeof(Operation), opt))
        {
            switch(opt)
            {
                case 1:
                    Console.Write("Name: ");
                    var name = Console.ReadLine()?.Trim();

                    while (string.IsNullOrEmpty(name))
                    {
                        PrintError("Invalid name!");
                        goto case 1;
                    }

                    people.Enqueue(name);
                    break;

                case 2:
                    if (people.IsEmpty())
                        PrintError("There are no people in the queue!");
                    else
                        Console.WriteLine($"{people.Dequeue()} was called!");
                    
                    break;
                
                case 3:
                    if (!people.IsEmpty())
                        PrintError("There are people in the queue!");
                    else
                        Environment.Exit(0);
                    
                    break;
            }
        }
    }

    Console.WriteLine();
}

void PrintMenu()
{
    Console.WriteLine("1 - Insert people.");
    Console.WriteLine("2 - Call people.");
    Console.WriteLine("3 - Exit if there are no people waiting in the queue.\n");

    Console.Write("$: ");
}

void PrintError(string msg)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n{msg}\n");

    Console.ResetColor();
}