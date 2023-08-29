// Algorithms

// Task E1



//Console.WriteLine("How many number in the Fibonacci Squence would you like to claculate?");

//int FibCount = Convert.ToInt32(Console.ReadLine());

//Console.Clear();

//List<int> FibonacciList = new List<int>() {1, 2};

//for (int i = 0; i < FibCount-2; i++)
//{
//    int NextElement = FibonacciList[FibonacciList.Count - 1] + FibonacciList[FibonacciList.Count - 2];
//    FibonacciList.Add(NextElement);
//}

//static void ListPrinter(List<int> ListToPrint)
//{
//    for (int i = 0; i < ListToPrint.Count; i++)
//    {
//        Console.WriteLine(ListToPrint[i]);
//    }
//}

//ListPrinter(FibonacciList);




// Task E2.1

//Console.WriteLine("Enter the number: ");

//int number = Convert.ToInt32(Console.ReadLine());

//Console.Clear();


//static bool PrimeChecker(int NumberToCheck)
//{
//    if (NumberToCheck <= 1)
//    {
//        return false;
//    }
//    else
//    {
//        for (int i = 1; i <= NumberToCheck; i++)
//        {
//            if (NumberToCheck % i == 0 && i != 1 && i != NumberToCheck)
//            {
//                return false;

//            }
//            else
//            {
//                continue;

//            }
//        }
//        return true;
//    }

//}

//if (PrimeChecker(number) == true)
//{
//    Console.WriteLine("{0} is a prime number!", number);
//}
//else
//{
//    Console.WriteLine("{0} is not a prime number!", number);
//}

// Task E2.2


//Console.WriteLine("Enter the number: ");

//int number = Convert.ToInt32(Console.ReadLine());

//Console.Clear();


//static bool PrimeChecker(int NumberToCheck)
//{
//    if (NumberToCheck <= 1)
//    {
//        return false;
//    }
//    else
//    {
//        for (int i = 1; i < NumberToCheck; i++)
//        {
//            if (NumberToCheck % i == 0 && i != 1 && i != NumberToCheck)
//            {
//                return false;

//            }
//            else
//            {
//                continue;

//            }
//        }
//        return true;
//    }

//}

//if (PrimeChecker(number) == true)
//{
//    for (int i = 2; i <= number; i++)
//    {
//        if (PrimeChecker(i) == true)
//        {
//            Console.WriteLine(i);
//        }
//        else
//        {
//            continue;
//        }
//    }

//}
//else
//{
//    Console.WriteLine("It is not a prime number!");
//}



// Task E3

//Console.WriteLine("Enter First Number: ");

//int Number1 = Convert.ToInt32(Console.ReadLine());

//Console.Clear();

//Console.WriteLine("Enter Second Number: ");

//int Number2 = Convert.ToInt32(Console.ReadLine());

//Console.Clear();

//static int GCD(int NumberFirst, int NumberSecond)
//{
//    int MaxNumber = Math.Max(NumberFirst, NumberSecond);
//    int MinNumber = Math.Min(NumberFirst, NumberSecond);

//    int Dividend = MaxNumber;
//    int Divisor = MinNumber;

//    int SubRemainder;

//    while (true)
//    {
//        SubRemainder = Dividend % Divisor;

//        if (SubRemainder == 0)
//        {
//            return Divisor;
//        }
//        else
//        {
//            Dividend = Divisor;
//            Divisor = SubRemainder;
//            continue;
//        }
//    }


//}

//Console.WriteLine("The greates common divisor of {0} and {1} is {2}.", Number1, Number2, GCD(Number1, Number2));