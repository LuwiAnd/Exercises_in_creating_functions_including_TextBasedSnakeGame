
/* 
 * This program does not take into account that numbers 11 through 19 are called eleven, twelve, thirteen, ... nineteen, 
 * instead of "tenone", "tentwo", ..., "tennine", which I did not bother to program.
 */


string[] digits = new string[]
{
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

string[] tens = new string[]
{
    "zero",
    "ten",
    "twenty",
    "thirty",
    "fourty",
    "fifty",
    "sixty",
    "seventy",
    "eighty",
    "ninety"
};


//static string threeDigits2string(int x)
string threeDigits2string(ushort x)
{
    string output = "";
    ushort num100 = (ushort)((x - (x % 100)) / 100);
    x = (ushort)(x % 100);
    ushort num10 = (ushort)((x - (x % 10)) / 10);

    if (num100 > 0)
    {
        output += digits[num100] + "hundered";
    }

    if (num10 > 0)
    {
        output += " " + tens[num10];
    }

    output += digits[x % 10];

    return output;
}

Console.WriteLine(threeDigits2string(123));
Console.WriteLine(threeDigits2string(234));

//static string ushort2text(ushort x)
string ushort2text(ushort x)
{
    string output = "";
    ushort thousands = (ushort)((x - (x % 1000)) / 1000);
    x = (ushort)(x % 1000);
    if(thousands > 0)
    {
        output += threeDigits2string(thousands) + "thousand";
    }

    output += " " + threeDigits2string(x);
    return output;
}

Console.WriteLine($"65 535 is the same as {ushort2text(65535)}");