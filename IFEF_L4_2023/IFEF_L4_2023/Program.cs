// Task F1


//int[] NatNumbers = new int[20];
//int[] EvenNumbers = new int[20];
//int[] SquareNumbers = new int[20];

//int NatCounter = 0;
//int EvenCounter = 0;
//int SquareCounter = 0;


//for (int i = 0; NatCounter < 20 || EvenCounter < 20 || SquareCounter < 20; i++)
//{
//    Console.WriteLine("Looking at: {0}", i);
//    if (Convert.ToString(i.GetType()) == "System.Int32" && i > 0 && NatCounter < 20)
//    {
//        NatNumbers[NatCounter] = i;
//        NatCounter++;
//    }

//    if (i % 2 == 0 && i != 0)
//    {
//        EvenNumbers[EvenCounter] = i;
//        EvenCounter++;
//    }
//    if (i != 0 && SquareCounter < 20)
//    {
//        SquareNumbers[SquareCounter] = i * i;
//        SquareCounter++;
//    }


//}

//Console.WriteLine("Natural:");
//ArrayPrinter(NatNumbers);
//Console.WriteLine("Even:");
//ArrayPrinter(EvenNumbers);
//Console.WriteLine("Square:");
//ArrayPrinter(SquareNumbers);




//static void ArrayPrinter(int[] ArrayToPrint)
//{
//    for (int i = 0; i < ArrayToPrint.Length; i++)
//    {
//        if (ArrayToPrint[i] != 0)
//        {
//            Console.WriteLine(ArrayToPrint[i]);
//        }
//    }
//}


// Task F2

//int[] FibonacciArray = new int[20];
//FibonacciArray[0] = 1;
//FibonacciArray[1] = 1;
//int FiboCount = 2;




//static void ArrayPrinter(int[] ArrayToPrint)
//{
//    for (int i = 0; i < ArrayToPrint.Length; i++)
//    {
//        if (ArrayToPrint[i] != 0)
//        {
//            Console.WriteLine(ArrayToPrint[i]);
//        }
//    }
//}


//while (FiboCount < 20)
//{
//    Console.WriteLine("Prev Numb: {0}", FibonacciArray[FiboCount - 1]);
//    Console.WriteLine("Prev_prev Numb: {0}", FibonacciArray[FiboCount - 2]);

//    int NextElement = FibonacciArray[FiboCount - 1] + FibonacciArray[FiboCount - 2];
//    Console.WriteLine("Subresult: {0}", NextElement);
//    Console.WriteLine("Counter: {0}", FiboCount);
//    FibonacciArray[FiboCount] = NextElement;
//    FiboCount++;
//}

//ArrayPrinter(FibonacciArray);



//int[] PrimeNumbers = new int[20];
//int PrimeCounter = 0;

//for (int i = 0; PrimeCounter < 20; i++)
//{
//    if (PrimeChecker(i) == true)
//    {
//        PrimeNumbers[PrimeCounter] = i;
//        PrimeCounter++;
//    }
//}

//ArrayPrinter(PrimeNumbers);


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



// Task F3


//Console.WriteLine("Enter the number: ");

//int number = Convert.ToInt32(Console.ReadLine());

//Console.Clear();

//List<int> FibonacciList = new List<int>() {1};


//for (int i = 0; FibonacciList[FibonacciList.Count - 1] < number - 1; i++)
//{
//    if (FibonacciList[FibonacciList.Count - 1] == 1)
//    {
//        int NextElement = FibonacciList[FibonacciList.Count - 1] +  1;
//        FibonacciList.Add(NextElement);
//    }
//    else
//    {
//        int NextElement = FibonacciList[FibonacciList.Count - 1] + FibonacciList[FibonacciList.Count - 2];
//        FibonacciList.Add(NextElement);
//    }
//}

//static void ListPrinter(List<int> ListToPrint)
//{
//    for (int i = 0; i < ListToPrint.Count; i++)
//    {
//        Console.WriteLine(ListToPrint[i]);
//    }
//}

//ListPrinter(FibonacciList);
