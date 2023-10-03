using static System.Net.Mime.MediaTypeNames;

namespace IFEF_2023_HangMan_Project;


class Program
{
    static void Main(string[] args)
    {

            int Lives = 6;
            char[] UsedLetters = new char[] { '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_' };
            char[] Alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string SecretWord = ReadSecretWord();
        //ArrayPrinter(SecretWord);
        // Player 1: Enter the secret word to be guessed by player 2
        HangTheMan(Lives, SecretWord.ToArray(), UsedLetters);                // Screen output for a good start
        while (true)                 // Player 2: Make your guesses
        {
            char Guess = ReadOneChar(UsedLetters);           // Handle input of one char.
            Console.WriteLine("Your guess: {0}", Guess);
            Console.WriteLine(EvaluateTheSituation(Guess, SecretWord.ToArray(), ref Lives, ref UsedLetters, Alphabet)); // Game Logic goes here
            HangTheMan(Lives, SecretWord.ToArray(), UsedLetters);// Screen output goes here
        }
        //QuitOrRestart(); // Ask if want to quit or start new game
    }


    static string ReadSecretWord()
    {
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

    static string EvaluateTheSituation(char Guess, char[] SecretWord, ref int Lives, ref char[] UsedLetters, char[] Alphabet) // Modification of method declaration recommended: Add return value and parameters
                                       // In here, evaluate the char entered: Is it part of the secret word?
                                       // Calculate and return the game status (Hit or missed? Where? List and number of missed chars?...)
    {
        bool Hit = false;
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
                string response = "Hit! There are "+ SecretWord.Count(c => c == Guess) +" "+Guess+"s in the secret word";
                return response;
            }
        }
        Lives = Lives - 1;
        return "Missed!";


    }

    static void QuitOrRestart() // Modification of method declaration recommended: Add return value and parameters
                                // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!
    }

    static void HangTheMan(int AmountLives, char[] SecretWord, char[] UsedLetters) // Modification of method declaration recommended: Add return value and parameters
                             // In here, clear the screen and redraw everything reflecting the actual game status
    {
        Console.Clear();
        string Hangman = "";
        string EncodedWord = CharArrayPrinter(WordEncoder(SecretWord));

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
        """, AmountLives, EncodedWord, CharArrayPrinter(UsedLetters)

        );

        Console.WriteLine(Hangman);
        Console.WriteLine(EncodedWord + "\n\n");

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
}