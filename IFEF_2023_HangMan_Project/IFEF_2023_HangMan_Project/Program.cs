using static System.Net.Mime.MediaTypeNames;

namespace IFEF_2023_HangMan_Project;


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {

            int Lives = 6;
            char[] UsedLetters = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            char[] Alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string SecretWord = ReadSecretWord();
            char[] EncodedWord = WordEncoder(SecretWord.ToArray());
            bool EndGame = false;
            //ArrayPrinter(SecretWord);
            // Player 1: Enter the secret word to be guessed by player 2
            HangTheMan(Lives, SecretWord.ToArray(), UsedLetters, EncodedWord);                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                char Guess = ReadOneChar(UsedLetters);           // Handle input of one char.
                Console.WriteLine("Your guess: {0}", Guess);
                EvaluateTheSituation(Guess, SecretWord.ToArray(), ref Lives, ref UsedLetters, Alphabet, ref EncodedWord, ref EndGame); // Game Logic goes here
                HangTheMan(Lives, SecretWord.ToArray(), UsedLetters, EncodedWord);// Screen output goes here
                if (EndGame)
                {
                    break;
                }
            }
            Console.WriteLine("Game Over!");
            if (QuitOrRestart()=='Q')
            {
                Console.Clear();
                Console.WriteLine("Goodbye!");
                break;
            } // Ask if want to quit or start new game
        }

    }


    static string ReadSecretWord()
    {
        Console.Clear();
        string SecretWord = "";
        char[] WhiteList = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
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

        //char[] SecretArray = SecretWord.ToCharArray();

        return SecretWord;

    }

    static char ReadOneChar(char[] UsedLetters) // Modification of method declaration recommended: Add return value and parameters
                              // If there are rules and constraints on allowed secrets (e.g. no digits), make sure the input is allowed
    {
        char GuessLetter;
        char[] WhiteList = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        while (true)
        {
            Console.WriteLine("Enter you guess: ");
            string UserInput = Console.ReadLine().ToUpper();

            if (UsedLetters.Contains(Convert.ToChar(UserInput)))
            {
                Console.Clear();
                continue;
            }

            try
            {
                char CharToCheck = Convert.ToChar(UserInput);
                if (WhiteList.Contains(CharToCheck))
                {
                    GuessLetter = CharToCheck;
                    break;
                }
                Console.Clear();
                continue;
                
            }
            catch
            {
                Console.Clear();
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
        //    Console.WriteLine("Looking at: {0}, comparing to {1}", SecretWord[i], Guess);
            if (SecretWord[i] == Guess)
            {
                Hit = true;
                CorrectIndexes = CountAllElements(SecretWord, Guess).ToArray();
                for (int k = 0; k < AmountOfCorrect; k++)
                {
                    EncodedWord[CorrectIndexes[k]] = SecretWord[CorrectIndexes[k]];
                    
                }
                if (!EncodedWord.Contains('_'))
                {
                    EndGame = true;
                }
                return 0;

                //string response = "Hit! There are "+ SecretWord.Count(c => c == Guess) +" "+Guess+"s in the secret word";
                //return response;
            }
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
            Console.Clear();
            Console.WriteLine("Would you like to restart or quite the game (R or Q)?");
            string RestartInput = Console.ReadLine().ToUpper();
            try
            {
                char CharToCheck = Convert.ToChar(RestartInput);
                if (CharToCheck == 'R' || CharToCheck == 'Q')
                {
                    return CharToCheck;
                }
                Console.Clear();
                continue;

            }
            catch
            {
                Console.Clear();
                continue;
            }
        }

        
    }

    static void HangTheMan(int AmountLives, char[] SecretWord, char[] UsedLetters, char[] EncodedWord) // Modification of method declaration recommended: Add return value and parameters
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