/* 
 * The code in this program is not meant to look good, but rather to 
 * test how to use switch-statements and whether you can return the 
 * input without making a new variable.
 * 
*/

static string AddHyphens(string input)
{
    string output;

    switch (input.Length)
    {
        case 0:
            output = input;
            return output;
            break;
        case 1:
            return input;
            break;
        default:
            output = $"{input[0]}";
            for(int i = 1; i < input.Length; i++)
            {
                output += "-" + input[i].ToString();
            }
            break;
    }

    return output;
}

string userInput;
while (true)
{
    Console.WriteLine("Write a string that you would like to hyphenate.");
    userInput = Console.ReadLine();
    Console.WriteLine(AddHyphens(userInput));
}