void DrawBox(int width, int height)
{
    Console.CursorVisible = false;
    char char2print;
    for(int i = 1; i <= height; i++)
    {
        for(int j = 1; j <= width; j++)
        {
            if(i == 1 || j == 1 || i == height || j == width)
            {
                char2print = '#';
            }
            else
            {
                char2print = '-';
            }

            Console.SetCursorPosition(left: j, top: i);
            Console.Write(char2print);

            Thread.Sleep(100);
        }
    }
}

DrawBox(3, 4);