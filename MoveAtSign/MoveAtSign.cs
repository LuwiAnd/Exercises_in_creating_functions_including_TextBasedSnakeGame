void DrawBox(int width, int height)
{
    Console.CursorVisible = false;
    char char2print;
    for (int i = 1; i <= height; i++)
    {
        for (int j = 1; j <= width; j++)
        {
            if (i == 1 || j == 1 || i == height || j == width)
            {
                char2print = '#';
            }
            else
            {
                char2print = '-';
            }

            Console.SetCursorPosition(left: j, top: i);
            Console.Write(char2print);

            //Thread.Sleep(2);
        }
    }
}

//DrawBox(3, 4);

void MoveAtSign()
{
    const int boxWidth = 20;
    const int boxHeight = 25;
    DrawBox(boxWidth, boxHeight);

    int x = boxWidth / 2;
    int y = boxHeight / 2;

    int xLast = x;
    int yLast = y;

    ConsoleKeyInfo cki;

    Console.SetCursorPosition(left: x, top: y);
    Console.Write('@');

    do
    {
        while(Console.KeyAvailable == false)
        {
            Thread.Sleep(50);
        }

        cki = Console.ReadKey();
        //Console.WriteLine("You pressed the '{0}' key", cki.Key);

        xLast = x;
        yLast = y;
        if(cki.Key == ConsoleKey.UpArrow)
        {
            y--;
        }
        if(cki.Key == ConsoleKey.LeftArrow)
        {
            x--;
        }
        if(cki.Key == ConsoleKey.DownArrow)
        {
            y++;
        }
        if(cki.Key == ConsoleKey.RightArrow)
        {
            x++;
        }


        Console.SetCursorPosition(left: xLast, top: yLast);
        Console.Write('-');
        Console.SetCursorPosition(left: x, top: y);
        Console.Write('@');
    }
    while (
        1 < x
        &&
        x < boxWidth
        &&
        1 < y
        &&
        y < boxHeight
    );

    Console.SetCursorPosition(1, (boxHeight + 1));
    Console.WriteLine("You went out of bounds and your @ died.");

}

MoveAtSign();