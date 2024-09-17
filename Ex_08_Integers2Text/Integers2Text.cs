static string[] Integer2Text(int num)
{
    string numString = num.ToString();
    string[] output = new string[numString.Length];

    string[] digits = new string[] {
        "zero",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
    };

    int digit;
    for(int i = 0; i < numString.Length; i++)
    {
        digit = numString[i] - '0';
        output[i] = digits[digit];
    }

    return output;
}

int userInput;
string[] userString;
while (true)
{
    Console.WriteLine("Write an integer: ");
    if(Int32.TryParse(Console.ReadLine(), out userInput))
    {
        Console.WriteLine("Thanks for writing an integer!");
        userString = Integer2Text(userInput);
        for(int i = 0; i < userString.Length; i++)
        {
            Console.WriteLine(userString[i]);
        }
        Console.WriteLine("The above was the integer you wrote translated into text!");
        Console.WriteLine("------------");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Unfortunately you failed to write an integer. Try again!");
    }
}