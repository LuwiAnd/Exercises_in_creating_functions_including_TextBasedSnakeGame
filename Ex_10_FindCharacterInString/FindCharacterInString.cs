int[] FindIndex(string input, char character)
{
    //int[] output;
    List<int> output = new List<int>();
    int j = 0;
    for(int i = 0; i < input.Length; i++)
    {
        if (input[i] == character)
        {
            output.Add(i);
        }
    }

    int[] output2 = output.ToArray();
    return output2;
}

string test = "Hello world!";
int[] answer = FindIndex(test, 'o');
for (int i = 0; i < answer.Length; i++)
{
    Console.WriteLine(answer[i]);
}