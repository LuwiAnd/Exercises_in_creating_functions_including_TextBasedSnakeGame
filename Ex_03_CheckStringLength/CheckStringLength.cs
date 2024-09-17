static bool CheckStringLength(string text, int stringLimit)
{
    bool stringIsTooLong = text.Length > stringLimit;
    return stringIsTooLong;
}

Console.WriteLine(CheckStringLength("Bob", 3));
Console.WriteLine(CheckStringLength(stringLimit: 3, text: "Robert"));