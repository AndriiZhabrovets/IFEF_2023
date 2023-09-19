// Euler's Project

// Task 1

//static List<int> ThreeOrFive(int TopNum)
//{
//    List<int> Res = new List<int>();

//    for (int i = 0; i < TopNum; i++)
//    {
//        if (i % 3 == 0 || i % 5 == 0)
//        {
//            Res.Add(i);
//        }
//    }
//    return Res;
//}
//int Sum = 0;
//foreach (int i in ThreeOrFive(1000)){ Sum += i; }

//Console.WriteLine(Sum);

// Task 2


//int FiboSumm = 0;


//IEnumerable<int> FibonacciGenerator(int TillNum)
//{
//    int PrevElem = 1;
//    int PrevPrevElem = 1;

//    yield return PrevPrevElem;

//    int NextElem = 0;
//    while(NextElem < TillNum)
//    {
//        NextElem = PrevElem + PrevPrevElem;

//        yield return NextElem;

//        PrevPrevElem = PrevElem;

//        PrevElem = NextElem;

//    }
//}

//foreach(int number in FibonacciGenerator(4000000))
//{
//    //Console.WriteLine(number);
//    if(number % 2 == 0)
//    {
//        FiboSumm += number;
//    }
//}



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


////ArrayPrinter(FibonacciArray);
//Console.WriteLine(FiboSumm);


// Task 3

long NumberToFactorize = 600851475143;

static bool PrimeChecker(long NumberToCheck)
{
    if (NumberToCheck <= 1)
    {
        return false;
    }
    else
    {
        for (int i = 1; i <= NumberToCheck; i++)
        {
            if (NumberToCheck % i == 0 && i != 1 && i != NumberToCheck)
            {
                return false;

            }
            else
            {
                continue;

            }
        }
        return true;
    }

}


static int PrimeGenerator(int Element)
{
    int Counter = 0;

    for (int i = 0; ; i++)
    {
        if (PrimeChecker(i) == true)
        {
            if (Counter == Element)
            {
                return i;
            }
            Counter++;
        }
    }
}




//static List<long> Factorizator(long NumberToFactorize)
//{
//    int counter = 0;
//    List<long> Factors = new List<long>();
//    while(PrimeChecker(NumberToFactorize) == false)
//    {
//        if (NumberToFactorize % PrimeGenerator(counter) == 0)
//        {
//            NumberToFactorize = NumberToFactorize / PrimeGenerator(counter);
//            Factors.Add(PrimeGenerator(counter));
//        }
//    }
//    Factors.Add(NumberToFactorize);
//    return Factors;
//}



static long MaxFactor(long NumberToFactorize)
{
    int counter = 0;
    long MaxFact = 0;
    int PrimeDivisor;
    while (PrimeChecker(NumberToFactorize) == false)
    {
        if (NumberToFactorize % PrimeGenerator(counter) == 0)
        {
            PrimeDivisor = PrimeGenerator(counter);
            NumberToFactorize = NumberToFactorize / PrimeDivisor;

            if (MaxFact < PrimeDivisor)
            {
                MaxFact = PrimeDivisor;
            }
        }
    }

    if (MaxFact < NumberToFactorize)
    {
        MaxFact = NumberToFactorize;
    }

    return MaxFact;
}


Console.WriteLine("Biggest factor of {0} is {1}", NumberToFactorize, MaxFactor(NumberToFactorize));