static double MeanOfIntegers(int[] numbers)
{
    double sum = 0;
    for(int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }

    double mean = sum / numbers.Length;
    return mean;
}

Console.WriteLine(MeanOfIntegers(new int[] { 1,2,3,4}));
Console.WriteLine(MeanOfIntegers(new int[0]));