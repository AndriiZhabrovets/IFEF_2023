// Task G1

//static void AnswerToEverything()
//{
//    Console.WriteLine("24");
//}

//static int Sum(int NumberA, int NumberB)
//{
//    return NumberA + NumberB;
//}

//static bool IsEven(int NumberToCheck)
//{
//    return NumberToCheck % 2 == 0;
//}

//AnswerToEverything();
//Console.WriteLine(Sum(1, 3));
//Console.WriteLine(IsEven(3));

// Task G2

//Console.WriteLine("Enter the temperature in Fahrenheit or Celsius by typing \"F\" or \"C\" in the end of your input.");

//string InputValue = Console.ReadLine();
//int InputNumber = Convert.ToInt32(InputValue.Substring(0,InputValue.Length-1));
//Console.Clear();


//static string  UnitsFinder(string StringToCheck)
//{
//    if (Convert.ToString(StringToCheck[StringToCheck.Length - 1]) == "F")
//    {
//        return "F";
//    }
//    else if (Convert.ToString(StringToCheck[StringToCheck.Length - 1]) == "C")
//    {
//        return "C";
//    }
//    else
//    {
//        return "Wrong Unit!";
//    }
//}

//static int FahrenheitToCelsius(int Fahrenheit)
//{
//    int Celsius = (Fahrenheit - 32) * 5 / 9;

//    return Celsius;
//}

//static int CelsiustoFahrenheit(int Celsius)
//{
//    int Fahrenheit = Celsius * 9 / 5 + 32;

//    return Fahrenheit;
//}


//if (UnitsFinder(InputValue) == "F")
//{
//    Console.WriteLine("Result: {0} C", FahrenheitToCelsius(InputNumber));
//}
//else if (UnitsFinder(InputValue) == "C")
//{
//    Console.WriteLine("Result: {0} F", CelsiustoFahrenheit(InputNumber));
//}
//else
//{
//    Console.WriteLine("Error!");
//}

// G3

//static bool isPrime(int NumberToCheck)
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
//        }
//        return true;
//    }

//}

//for (int i=2; i<=100; i++)
//{
//    if (isPrime(i) == true)
//    {
//        Console.WriteLine(i);
//    }
//}


// Task G4

static int MyLength(string ToCheck)
{
    int Counter = 0;
    
    for(int i=0; ;i++) { 
        try
        {
            char Check = ToCheck[i];
        }
        catch
        {
            return Counter;
        }

    }
    
}

//Console.WriteLine(MyLength("Hello"));




static int NumberOfChar(string StringToCheck, char CharToCount)
{
    int CharCounter = 0;

    for (int i = 0; i <= MyLength(StringToCheck) - 1; i++)
    {
        if (StringToCheck[i] == CharToCount)
        {
            CharCounter++;
        }
    }
    return CharCounter;
}

//Console.WriteLine(NumberOfChar("Pizza", "z"));





static int[] PositionsOfChar(string StringToCheck, char CharToCount)
{
    int[] CharPositions = new int[NumberOfChar(StringToCheck, CharToCount)];
    int CharCounter = 0;
    for (int i = 0; i <= MyLength(StringToCheck) - 1; i++)
    {
        if (StringToCheck[i] == CharToCount)
        {
            CharPositions[CharCounter] = i;
            CharCounter++;
        }
    }
    return CharPositions;
}




static void IntArrayPrinter(int[] ArrayToPrint)
{
    for (int i = 0; i < ArrayToPrint.Length; i++)
    {
        Console.WriteLine(ArrayToPrint[i]);
    }
}



//IntArrayPrinter(PositionsOfChar("basketball", "b"));


static string[] MySplit(string StringToSplit, char CharToSplitWith)
{
    int NumberOfSplits = NumberOfChar(StringToSplit, CharToSplitWith);
    //Console.WriteLine(NumberOfSplits);
    string[] ResArray = new string[NumberOfSplits + 1];
    int[] SplitPositions = PositionsOfChar(StringToSplit, CharToSplitWith);
    int FromIndex = 0;
    int ToIndex;
    //IntArrayPrinter(SplitPositions);
    //Console.WriteLine(StringToSplit[SplitPositions[1]]);
    for (int i = 0; i <= NumberOfSplits; i++)
    {
        //Console.WriteLine("i = " + i);
        if (i == NumberOfSplits)
        {
            ToIndex = MyLength(StringToSplit);
        }
        else
        {
            ToIndex = SplitPositions[i];
        }
        ResArray[i] = StringToSplit.Substring(FromIndex, ToIndex - FromIndex);

        FromIndex = ToIndex + MyLength(CharToSplitWith);


        //Console.WriteLine(ResArray[i]);
    }

    return ResArray;
}

static void StrArrayPrinter(string[] ArrayToPrint)
{
    for (int i = 0; i < ArrayToPrint.Length; i++)
    {
        Console.WriteLine(ArrayToPrint[i]);
    }
}

StrArrayPrinter(MySplit("A sentence into words", " "));

