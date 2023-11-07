namespace IFEF_2023_HangMan_Project;


class Program
{
    static void Main(string[] args)
    {
        char[] Alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        while (true)
        {
            int Lives = 6;
            char[] UsedLetters = new char[Alphabet.Length];
            for (int i = 0; i < Alphabet.Length; i++)
            {
                UsedLetters[i] = '_';
            }
            string SecretWord = ReadSecretWord(Alphabet);
            char[] EncodedWord = WordEncoder(SecretWord.ToArray());
            bool EndGame = false;
            HangTheMan(Lives, UsedLetters, EncodedWord, EndGame);
            while (true)
            {
                char Guess = ReadOneChar(UsedLetters, Alphabet);
                EvaluateTheSituation(Guess, SecretWord.ToArray(), ref Lives, ref UsedLetters, Alphabet, ref EncodedWord, ref EndGame);
                HangTheMan(Lives, UsedLetters, EncodedWord, EndGame);
                if (EndGame)
                {
                    break;
                }
            }
            if (QuitOrRestart() == 'q')
            {
                Console.Clear();
                break;
            }
        }
    }


    static string ReadSecretWord(char[] WhiteList)
    {
        Console.Clear();
        string IntroMessage = "\n██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗\n██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║\n███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║\n██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║\n██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║\n╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝\n                                                                \n";
        Console.Write(IntroMessage);
        string SecretWord = "";
        bool Error = true;
        while (Error)
        {
            Console.WriteLine("Enter your secret word: ");
            SecretWord = Console.ReadLine().ToUpper();
            Error = false;
            for (int i = 0; i < SecretWord.Length; i++)
            {
                if (!WhiteList.Contains(SecretWord[i]))
                {
                    Console.WriteLine("Wrong Input");
                    Error = true;
                    break;
                }
            }
            Console.Clear();
        }
        return SecretWord;
    }

    static char ReadOneChar(char[] UsedLetters, char[] WhiteList)
    {
        char GuessLetter;
        while (true)
        {
            Console.WriteLine("Enter your guess: ");
            //string UserInput = Console.ReadLine().ToUpper();
            char CharToCheck = Char.ToUpper(Console.ReadKey().KeyChar);
            try
            {
                //char CharToCheck = Convert.ToChar(UserInput);
                if (WhiteList.Contains(CharToCheck) && !UsedLetters.Contains(CharToCheck))
                {
                    GuessLetter = CharToCheck;
                    break;
                }

                Console.WriteLine("Wrong Input!");
                continue;
            }
            catch
            {
                Console.WriteLine("Wrong Input!");
                continue;
            }
        }
        return GuessLetter;
    }

    static void EvaluateTheSituation(char Guess, char[] SecretWord, ref int Lives, ref char[] UsedLetters, char[] Alphabet, ref char[] EncodedWord, ref bool EndGame)
    {
        bool Hit = false;
        int AmountOfCorrect = SecretWord.Count(x => x == Guess);
        int UsedIndex = Array.IndexOf(Alphabet, Guess);

        UsedLetters[UsedIndex] = Alphabet[UsedIndex];


        for (int i = 0; i < SecretWord.Length; i++)
        {
            Console.WriteLine(SecretWord[i]);
            if (SecretWord[i] == Guess)
            {
                Hit = true;
                EncodedWord[i] = SecretWord[i];
            }
        }
        if (!EncodedWord.Contains('_'))
        {
            EndGame = true;
        }
        if (!Hit)
        {
            Lives = Lives - 1;
            if (Lives == 0)
            {
                EndGame = true;
                EncodedWord = SecretWord;
            }
        }
    }

    static char QuitOrRestart()
    {
        while (true)
        {
            Console.WriteLine("Would you like to restart or quite the game (R or Q)?");
            char RestartInput = Console.ReadKey().KeyChar;
            if (RestartInput == 'r' || RestartInput == 'q')
            {
                return RestartInput;
            }
            Console.WriteLine(RestartInput);
            continue;
        }
    }

    static void HangTheMan(int AmountLives, char[] UsedLetters, char[] EncodedWord, bool GameOver)
    {
        Console.Clear();
        string Hangman = "";

        if (AmountLives == 6)
        {

            Hangman = """""""""""
            _____________________
            | .__________))______|
            | | / /      ||
            | |/ /       ||
            | | /        ||
            | |/         || 
            | |          || 
            | |         (  )
            | |        (    )
            | |         \__/
            | |       
            | |         
            | |           
            | |            
            | |           
            | |             
            | |            
            | |             
            """"""""""|_________|"""|
            |"|"""""""––––––––––'"|"|
            | |                   | |
            : :                   : :  
            . .                   . .

            """"""""""";
        }
        else if (AmountLives == 5)
        {
            Hangman = """""""""""
            ___________.._______
            | .__________))______|
            | | / /      ||
            | |/ /       ||
            | | /        ||.-''.
            | |/         |/  _  \
            | |          ||  `/,|
            | |          (\\`_.'
            | |         .-`--'.
            | |         
            | |       
            | |         
            | |           
            | |            
            | |           
            | |             
            | |            
            | |             
            """"""""""|_        |"""|
            |"|"""""""\ \       '"|"|
            | |        \ \        | |
            : :         \ \       : :  
            . .          `'       . .

            """"""""""";
        }
        else if (AmountLives == 4)
        {
            Hangman = """""""""""
             ___________.._______
            | .__________))______|
            | | / /      ||
            | |/ /       ||
            | | /        ||.-''.
            | |/         |/  _  \
            | |          ||  `/,|
            | |          (\\`_.'
            | |         .-`--'.
            | |          |. .| 
            | |          |   | 
            | |          | . |  
            | |          |   |  
            | |            
            | |           
            | |             
            | |            
            | |             
            """"""""""|_        |"""|
            |"|"""""""\ \       '"|"|
            | |        \ \        | |
            : :         \ \       : :  
            . .          `'       . .
            """"""""""";
        }
        else if (AmountLives == 3)
        {
            Hangman = """""""""""
             ___________.._______
            | .__________))______|
            | | / /      ||
            | |/ /       ||
            | | /        ||.-''.
            | |/         |/  _  \
            | |          ||  `/,|
            | |          (\\`_.'
            | |         .-`--'
            | |        /Y . .| 
            | |       // |   | 
            | |      //  | . |  
            | |     ')   |   |  
            | |            
            | |           
            | |             
            | |            
            | |             
            """"""""""|_        |"""|
            |"|"""""""\ \       '"|"|
            | |        \ \        | |
            : :         \ \       : :  
            . .          `'       . .
            """"""""""";
        }
        else if (AmountLives == 2)
        {
            Hangman = """""""""""
                 ___________.._______
                | .__________))______|
                | | / /      ||
                | |/ /       ||
                | | /        ||.-''.
                | |/         |/  _  \
                | |          ||  `/,|
                | |          (\\`_.'
                | |         .-`--'.
                | |        /Y . . Y\
                | |       // |   | \\
                | |      //  | . |  \\
                | |     ')   |   |   (`
                | |            
                | |           
                | |             
                | |            
                | |             
                """"""""""|_        |"""|
                |"|"""""""\ \       '"|"|
                | |        \ \        | |
                : :         \ \       : :  
                . .          `'       . .
                """"""""""";
        }
        else if (AmountLives == 1)
        {
            Hangman = """""""""""
                 ___________.._______
                | .__________))______|
                | | / /      ||
                | |/ /       ||
                | | /        ||.-''.
                | |/         |/  _  \
                | |          ||  `/,|
                | |          (\\`_.'
                | |         .-`--'.
                | |        /Y . . Y\
                | |       // |   | \\
                | |      //  | . |  \\
                | |     ')   |   |   (`
                | |          ||'  
                | |          ||   
                | |          ||   
                | |          ||   
                | |         / |    
                """"""""""|_`-'     |"""|
                |"|"""""""\ \       '"|"|
                | |        \ \        | |
                : :         \ \       : :  
                . .          `'       . .
                """"""""""";

        }
        else if (AmountLives == 0)
        {
            Hangman = """""""""""
                 ___________.._______
                | .__________))______|
                | | / /      ||
                | |/ /       ||
                | | /        ||.-''.
                | |/         |/  _  \
                | |          ||  `/,|
                | |          (\\`_.'
                | |         .-`--'.
                | |        /Y . . Y\
                | |       // |   | \\
                | |      //  | . |  \\
                | |     ')   |   |   (`
                | |          ||'||
                | |          || ||
                | |          || ||
                | |          || ||
                | |         / | | \
                """"""""""|_`-' `-' |"""|
                |"|"""""""\ \       '"|"|
                | |        \ \        | |
                : :         \ \       : :  
                . .          `'       . .
                """"""""""";

        }





        Console.WriteLine("""

        Lives Left: {0}

        Secret word: {1}

        Used letters: {2}

        Used letters:
        """, AmountLives, CharArrayPrinter(EncodedWord), CharArrayPrinter(UsedLetters)

        );

        Console.WriteLine(Hangman + "\n\n");
        Console.WriteLine(CharArrayPrinter(EncodedWord) + "\n\n");

        if (AmountLives == 0 && GameOver)
        {
            Console.WriteLine("You lost!\n");
        }
        else if (AmountLives != 0 && GameOver)
        {
            Console.WriteLine("You won!\n");
        }

    }


    static char[] WordEncoder(char[] WordToEncode)
    {
        char[] EncodedWord = WordToEncode;

        for (int i = 0; i < WordToEncode.Length; i++)
        {
            EncodedWord[i] = '_';
        }
        return EncodedWord;
    }


    static string CharArrayPrinter(char[] ToPrint)
    {
        string Result = "";
        for (int i = 0; i < ToPrint.Length; i++)
        {
            Result = Result + ToPrint[i];
        }
        return Result;
    }

}