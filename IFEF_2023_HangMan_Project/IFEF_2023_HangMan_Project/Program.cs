using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace IFEF_2023_HangMan_Project;


class Program
{
    static void Main(string[] args)
    {
        char[] Alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        while (true)
        {
            int Lives = 6;
            char[] UsedLetters = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            
            string SecretWord = ReadSecretWord(Alphabet);
            char[] EncodedWord = WordEncoder(SecretWord.ToArray());
            bool EndGame = false;
            //ArrayPrinter(SecretWord);
            // Player 1: Enter the secret word to be guessed by player 2
            HangTheMan(Lives, SecretWord.ToArray(), UsedLetters, EncodedWord, EndGame);                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                char Guess = ReadOneChar(UsedLetters, Alphabet);           // Handle input of one char.
                EvaluateTheSituation(Guess, SecretWord.ToArray(), ref Lives, ref UsedLetters, Alphabet, ref EncodedWord, ref EndGame); // Game Logic goes here
                HangTheMan(Lives, SecretWord.ToArray(), UsedLetters, EncodedWord, EndGame);// Screen output goes here
                if (EndGame)
                {
                    break;
                }
            }
            Console.WriteLine("Game Over!");
            if (QuitOrRestart()=='q')
            {
                Console.Clear();
                break;
            } // Ask if want to quit or start new game
        }
    }


    static string ReadSecretWord(char[] WhiteList)
    {
        Console.Clear();
        string IntroMessage = "\n██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗\n██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║\n███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║\n██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║\n██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║\n╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝\n                                                                \n";
        Console.Write(IntroMessage);
        string SecretWord = "";
        bool Error = true;
        while (Error) {
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

    static char ReadOneChar(char[] UsedLetters, char[] WhiteList) // Modification of method declaration recommended: Add return value and parameters
                              // If there are rules and constraints on allowed secrets (e.g. no digits), make sure the input is allowed
    {
        char GuessLetter;
        while (true)
        {
            Console.WriteLine("Enter your guess: ");
            string UserInput = Console.ReadLine().ToUpper();
            try
            {
                char CharToCheck = Convert.ToChar(UserInput);
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

    static int EvaluateTheSituation(char Guess, char[] SecretWord, ref int Lives, ref char[] UsedLetters, char[] Alphabet, ref char[] EncodedWord, ref bool EndGame) // Modification of method declaration recommended: Add return value and parameters
                                       // In here, evaluate the char entered: Is it part of the secret word?
                                       // Calculate and return the game status (Hit or missed? Where? List and number of missed chars?...)
    {
        bool Hit = false;
        int[] CorrectIndexes;
        int AmountOfCorrect = SecretWord.Count(x => x == Guess);
        int UsedIndex = Array.IndexOf(Alphabet, Guess);
        //Console.WriteLine("Letter is on the {0} position in the alphabet. Check: {1}", UsedIndex, Alphabet[UsedIndex]);
        UsedLetters[UsedIndex] = Alphabet[UsedIndex];
        //Console.WriteLine("At this position UsedLetters now has {0}", UsedLetters[UsedIndex]);

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
        if (Hit){
            return 0;
        }
        Lives = Lives - 1;
        if(Lives == 0)
        {
            EndGame = true;
            EncodedWord = SecretWord;
        }
        return 0;
    }

    static char QuitOrRestart() // Modification of method declaration recommended: Add return value and parameters
                                // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
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

    static void HangTheMan(int AmountLives, char[] SecretWord, char[] UsedLetters, char[] EncodedWord, bool GameOver) // Modification of method declaration recommended: Add return value and parameters
                             // In here, clear the screen and redraw everything reflecting the actual game status
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

        if(AmountLives == 0 && GameOver)
        {
            Console.WriteLine("You lost!");
        }
        else if(AmountLives != 0 && GameOver)
        {
            Console.WriteLine("You won!");
        }

    }


    static char[] WordEncoder(char[] WordToEncode)
    {
        char[] EncodedWord = WordToEncode;

        for(int i = 0; i < WordToEncode.Length; i++)
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


    static List<int> CountAllElements(char[] ToCount, char Element)
    {
        List<int> Index = new List<int>();
        for(int i = 0; i < ToCount.Length; i++)
        {
            if (ToCount[i] == Element)
            {
                Index.Add(i);
            }
        }
        return Index;
    }
}