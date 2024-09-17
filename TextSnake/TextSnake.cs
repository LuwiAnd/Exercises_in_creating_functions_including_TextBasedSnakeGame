char boxChar = '#';
char obstacleChar = '#';
char snakeChar = '@';
char appleChar = '+';
char emptyChar = ' ';

int snakeLength = 1;



int[] GenerateSteps2NextObstacle(int numberObstacles, int height, int width, int snakeSize)
{
    int availableSquares = (height - 2) * (width - 2) - snakeSize;

    int[] steps = new int[numberObstacles];

    Random random = new Random();
    for(int i = 0; i < numberObstacles; i++)
    {
        steps[i] = random.Next(1, availableSquares + 1);
        availableSquares--;

        //Console.WriteLine(steps[i]);
    }

    return steps;
}

//GenerateSteps2NextObstacle(5, 7, 7, 1);
//Thread.Sleep(1000);

//int[,] BoxAndSteps2obstacles(int[,] Box, int height, int width, int[] steps)
//int[,] AddObstacles2Box(int[,] Box, int height, int width, int[] steps)
char[,] AddObstacles2Box(char[,] Box, int height, int width, int[] steps)
{
    //int[,] output = new int[steps.Length, 2];

    for(int i = 0; i < steps.Length; i++)
    {
        int currentSteps = steps[i];
        for(int j = 0; j < height; j++)
        {
            for(int k = 0; k < width; k++)
            {
                if (Box[j, k] == emptyChar)
                {
                    currentSteps--;
                }
                if(currentSteps <= 0)
                {
                    Box[j, k] = obstacleChar;
                    break;
                }
            }

            if (currentSteps <= 0)
            {
                break;
            }
        }
    }

    return Box;
}

//int[,] DrawBox(int height, int width, int numberObstacles)
char[,] DrawBox(int height, int width, int numberObstacles)
{
    //https://stackoverflow.com/questions/12567329/multidimensional-array-vs
    //int[][] output = new int[height][width];
    char[,] output = new char[height, width];

    //int[,] obstacles = new int[numberObstacles, 2];
    //Random random = new Random();
    //for(int i = 0; i < numberObstacles; i++)
    //{
    //    for(int j = 1; j <= (height - 2)*(width - 2) - i; j++)
    //    {

    //    }
    //}

    //Console.CursorVisible = false;
    char char2print;

    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (i == 0 || j == 0 || i == (height - 1) || j == (width - 1))
            {
                //char2print = '#';
                char2print = boxChar;
            }
            else
            {
                //char2print = '-';
                char2print = emptyChar;
            }

            //Console.SetCursorPosition(left: j, top: i);
            //Console.Write(char2print);

            output[i, j] = char2print;

            //Thread.Sleep(2);
        }
    }

    return output;
}


void showBox(char[,] box)
{
    for(int i = 0; i < box.GetLength(0); i++)
    {
        for(int j = 0; j < box.GetLength(1); j++)
        {
            //Console.SetCursorPosition(1, 1); // Test.
            Console.SetCursorPosition(left: j + 1, top: i + 10);
            Console.Write(box[i, j]);

            //Thread.Sleep(1);
        }
    }
}

char[,] AddSnake(char[,] box, int[,] snake)
{
    for(int i = 0; i < snake.GetLength(0); i++)
    {
        box[snake[i,0], snake[i,1]] = snakeChar;
    }

    return box;
}



int[,] UpdateSnake(char[,] box, int[,] snake, string direction)
{
    int snakeHeight = snake[snake.GetLength(0) - 1, 0];
    int snakeWidth = snake[snake.GetLength(0) - 1, 1];

    int[,] snakeHead = new [,]{ { snakeHeight, snakeWidth } };

    if(direction == "up")
    {
        snakeHead[0, 0] = snakeHead[0, 0] - 1;
    }
    if (direction == "down")
    {
        snakeHead[0, 0] = snakeHead[0, 0] + 1;
    }
    if (direction == "right")
    {
        snakeHead[0, 1] = snakeHead[0, 1] + 1;
    }
    if (direction == "left")
    {
        snakeHead[0, 1] = snakeHead[0, 1] - 1;
    }








    for (int i = 0; i < snake.GetLength(0); i++)
    {
        

        if(i >= snake.GetLength(0) - 1)
        {
            snake[i, 0] = snakeHead[0, 0];
            snake[i, 1] = snakeHead[0, 1];
        }
        else
        {
            Console.WriteLine(i);
            snake[i, 0] = snake[i + 1, 0];
            snake[i, 1] = snake[i + 1, 1];
        }
    }

    //box = AddSnake(box, snakeHead);
    return snake;
}


bool checkGameOver(char[,] box, int[,] snake)
{
    int snakeLength = snake.GetLength(0);

    int snakeHeadX = snake[snakeLength - 1, 0];
    int snakeHeadY = snake[snakeLength - 1, 1];

    char posChar = box[snakeHeadX, snakeHeadY];

    return posChar == boxChar || posChar == obstacleChar;
}

string changeDirection(string currentDirection)
{
    int maxWaitTime = 500;
    int intervalTime = 50;
    int currentWaitTime = 0;

    ConsoleKeyInfo cki;

    string newDirection = "";
    bool okDirection = false;
    while (!okDirection && currentWaitTime <= maxWaitTime)
    {
        while (Console.KeyAvailable == false && currentWaitTime <= maxWaitTime)
        {
            Thread.Sleep(intervalTime);
            currentWaitTime += intervalTime;
        }

        if (Console.KeyAvailable)
        {
            cki = Console.ReadKey();
            Console.WriteLine("You pressed the '{0}' key", cki.Key);

            if (cki.Key == ConsoleKey.UpArrow)
            {
                newDirection = "up";
            }
            if (cki.Key == ConsoleKey.LeftArrow)
            {
                newDirection = "left";
            }
            if (cki.Key == ConsoleKey.DownArrow)
            {
                newDirection = "down";
            }
            if (cki.Key == ConsoleKey.RightArrow)
            {
                newDirection = "right";
            }
        }
        else if (currentWaitTime > maxWaitTime)
        {
            break;
        }

        if (
            newDirection == "up" && currentDirection != "down"
            ||
            newDirection == "down" && currentDirection != "up"
            ||
            newDirection == "left" && currentDirection != "right"
            ||
            newDirection == "right" && currentDirection != "left"
        )
        {
            okDirection = true;
        }
        else
        {
            newDirection = "";
        }
    }


    //while (Console.KeyAvailable == false && currentWaitTime <= maxWaitTime)
    //{
    //    Thread.Sleep(intervalTime);
    //    currentWaitTime += intervalTime;
    //}

    //if(Console.KeyAvailable == true)
    //{
    //    cki = Console.ReadKey();
    //    Console.WriteLine("You pressed the '{0}' key", cki.Key);

    //    if (cki.Key == ConsoleKey.UpArrow)
    //    {
    //        newDirection = "up";
    //    }
    //    if (cki.Key == ConsoleKey.LeftArrow)
    //    {
    //        newDirection = "left";
    //    }
    //    if (cki.Key == ConsoleKey.DownArrow)
    //    {
    //        newDirection = "down";
    //    }
    //    if (cki.Key == ConsoleKey.RightArrow)
    //    {
    //        newDirection = "right";
    //    }
    //}


    if (newDirection == "")
    {
        newDirection = currentDirection;
    }

    return newDirection;
}

void PlayGame()
{
    int height = 10;
    int width = 50;
    int numberObstacles = 5;

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

    char[,] box = DrawBox(height: height, width: width, numberObstacles: numberObstacles);
    int[] obstacleSpacing = GenerateSteps2NextObstacle(numberObstacles: numberObstacles, height: height, width: width, snakeSize: snakeLength);
    box = AddObstacles2Box(Box: box, height: height, width: width, steps: obstacleSpacing);

    showBox(box);

    //int[,] snake = new int[1, 2] { { height / 2, width / 2 } };
    int[,] snake = new int[3, 2] { 
        { height / 2, width / 2 }, 
        { (height / 2) + 1, width / 2 }, 
        { (height / 2) + 2, width / 2 } 
    };
    string direction;

    char[,] box2 = box.Clone() as char[,];
    //char[,] box2 = AddSnake(box2, snake);
    box2 = AddSnake(box2, snake);

    showBox(box2);

    bool gameOver = false;
    direction = "up";
    int test = 0;
    while (!gameOver)
    {
        snake = UpdateSnake(box, snake, direction);
        gameOver = checkGameOver(box, snake);

        box2 = box.Clone() as char[,];
        box2 = AddSnake(box2, snake);
        showBox(box2);
        direction = changeDirection(direction);
        Console.WriteLine(++test);
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("\nGame Over!");

}

PlayGame();