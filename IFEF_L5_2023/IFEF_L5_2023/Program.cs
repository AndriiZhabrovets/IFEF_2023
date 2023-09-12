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


