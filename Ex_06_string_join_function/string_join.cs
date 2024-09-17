
/*
 A params parameter must be last of the input parameters.
 */
static string LuwiStringJoin(string sep, params string[] args)
{
    if(args.Length == 0)
    {
        return "";
    }else if(args.Length == 1)
    {
        return args[0];
    }

    string output = "";
    output = output + args[0];
    for(int i = 1; i < args.Length; i++)
    {
        output += sep + args[i];
    }

    return output;
}


Console.WriteLine(LuwiStringJoin("->", "A string"));
Console.WriteLine("---------------------");
Console.WriteLine(LuwiStringJoin("->", new string[0]));
Console.WriteLine("---------------------");
Console.WriteLine(LuwiStringJoin("->", "A string", "one more"));
Console.WriteLine("---------------------");
Console.WriteLine(LuwiStringJoin("->", "A string", "one more", "three"));
Console.WriteLine("---------------------");