Console.WriteLine("Factorial of 5 is " + Factorial(5));
Console.WriteLine("Factorial of 10 is " + Factorial(10));

Console.WriteLine();

Console.WriteLine("Greatest common divisor of 2 and 3 is " + Gcd(2, 3));
Console.WriteLine("Greatest common divisor of 101010 and 2020 is " + Gcd(1010101, 2020));

long Factorial(int x)
{
    if (x == 0)
        return 1;
    else
        return (x * Factorial(x - 1));
}

int Gcd(int x, int y)
{
    if (x > y)
        return Gcd(y, x);
    else
        if (x == 0)
            return y;
        else
            return Gcd(x, y % x);
}