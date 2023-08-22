// Task D1 (1)
//int counter = 10;
//while (counter <= 20)
//{
//    Console.WriteLine(counter);
//    counter += 1;
//}

//for (int i=10; i <= 20; i++)
//{
//    Console.WriteLine(i);
//}

// Task D1 (2)

//int counter = 2;

//while (counter<=20)
//{
//    Console.WriteLine(counter);
//    counter += 2;
//}

//for (int i = 2; i <= 20; i += 2)
//{
//    Console.WriteLine(i);
//}

// Task D1 (3)

//int counter = -1;

//while (counter >= -10)
//{
//    Console.WriteLine(counter);
//    counter -= 1;
//}

//Console.WriteLine("");

//for (int i = -1; i >= -10; i--)
//{
//    Console.WriteLine(i);
//}

//Task D2

//for (int k = 7; k < 13; k++)
//{
//    Console.WriteLine(2 * k);
//}

//int l = 7;

//while (l < 13)
//{
//    Console.WriteLine(l * 2);
//    l += 1;
//}


// Task D3
//int x = 5;

//while (true)
//{

//    Console.WriteLine(x);
//    if (x < 10)
//    {
//        x++;
//    } else
//    {
//        break;
//    }
//}


// Task D4
//while (true)
//{
//    Console.WriteLine("Enter a positive number: ");

//    string ans = Console.ReadLine();

//    try
//    {
//        int NumAns = Convert.ToInt32(ans);

//        if (NumAns <= 0)
//        {
//            Console.WriteLine("Game Over");
//            break;
//        }
//        else
//        {
//            continue;
//        }
//    } catch
//    {
//        Console.WriteLine("Enter a Number!");
//    }


//}



Random rand = new Random();

static string MathAction ()
{
    Random rand = new Random();
    string[] actions;
    actions = new string[4] { "+", "-", "*", "/" };
    return actions[rand.Next(0,3)];
}

while (true)
{
    int Points = 0;
    int Lifes = 3;
    Console.Clear();
    for (int i = 1; i <= 10; i++)
    {
        int Num1 = rand.Next(1, 11);
        int Num2 = rand.Next(1, 11);
        string Action = MathAction();
        Console.WriteLine("Question {0}\n",i);
        Console.WriteLine("{0}{1}{2}=?\n", Num1,Action,Num2);
        int QAnswer;

        try
        {
            QAnswer = Convert.ToInt32(Console.ReadLine());
        } catch
        {
            Console.WriteLine("Wrong Input!");
            i -= 1;
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
            Console.Clear();
            continue;
        }
        int RAnswer;
        switch (Action)
        { 
            case "-":
                RAnswer = Num1 - Num2;
                break;

            case "*":
                RAnswer = Num1 * Num2;
                break;

            case "/":
                RAnswer = Num1 / Num2;
                break;

            default:
                RAnswer = Num1 + Num2;
                break;
        }

        if (QAnswer == RAnswer)
        {
            if (i == 10)
            {
                Console.Clear();
                Points += 10;
                Console.WriteLine("\nYou won!");
                Console.WriteLine("\nPoints: {0}/100", Points);

                continue;
                
            }
            else
            {
                Console.Clear();
                Points += 10;
                continue;
            }

        }
        else
        {
            if (Lifes == 0)
            {
                Console.Clear();
                Console.WriteLine("\nGame Over!");
                Console.WriteLine("\nPoints: {0}/100", Points);

                break;

            }
            else
            {
                Console.Clear();
                Lifes -= 1;
                Console.WriteLine("\n-1 Life");
                Console.WriteLine("\nLifes left: {0}\n", Lifes);

                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();

                Console.Clear();

                continue;
            }

        }
    }

    Console.WriteLine("\nPress any key to continue:");
    Console.ReadKey();

}



