Random random = new Random(12);

int ThrowDice(int sides = 6)
{
    int result = random.Next(sides) + 1;
    return result;
}

for(int i = 0; i < 20; i++)
{
    Console.WriteLine(ThrowDice(2));
}

int ThrowMultipleDices(int n, int sides = 6)
{
    int result = 0;
    for(int i = 1; i <= n; i++)
    {
        result += ThrowDice(sides);
    }
    return result;
}

Console.WriteLine("\n---------------\n");

for (int i = 0; i < 20; i++)
{
    Console.WriteLine(ThrowMultipleDices(2));
}

Console.WriteLine("\n---------------\n");

for (int i = 0; i < 20; i++)
{
    Console.WriteLine(ThrowMultipleDices(2, 2));
}