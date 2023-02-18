using Stacks;

// Stack
const int limit = 20;
Node<float> stack = new(limit);

// Adding values
for(int i = 0; i < limit; ++i)
    stack.Push(i);

Console.WriteLine("Stack is empty: " + stack.IsEmpty());
Console.WriteLine("Stack is full: " + stack.IsFull());

stack.PrintValues();

// Removing values
while(!stack.IsEmpty())
    stack.Pop();

Console.WriteLine("Stack is empty: " + stack.IsEmpty());
Console.WriteLine("Stack is full: " + stack.IsFull());

stack.PrintValues();

// Adding one
stack.Push(1);

Console.WriteLine("Stack is empty: " + stack.IsEmpty());
Console.WriteLine("Stack is full: " + stack.IsFull());

/* Decimal to binary example */
int n = 13;
Node<int> s = new(1000);

while(n > 0)
{
    var r = n % 2;
    s.Push(r);

    n = n / 2;  
}

var j = 0;
do
{
    try
    {
        var r = s.Pop();
        Console.Write(r);
    } 
    catch
    {
        break;
    }
} while (true);