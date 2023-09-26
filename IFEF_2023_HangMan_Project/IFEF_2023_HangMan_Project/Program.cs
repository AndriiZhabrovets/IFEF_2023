using System.Net.Sockets;

namespace IFEF_2023_HangMan_Project;


class Program
{
    static void Main(string[] args)
    {
        while (true)                     // The game repeats until finished by player 1
        {
            int Lives = 6;
            char[] SecretWord = ReadSecretWord();
            // Player 1: Enter the secret word to be guessed by player 2
            HangTheMan(Lives);                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                char Guess = ReadOneChar();           // Handle input of one char. 
                EvaluateTheSituation(Guess, SecretWord);  // Game Logic goes here
                HangTheMan();            // Screen output goes here
            }
            QuitOrRestart(); // Ask if want to quit or start new game
        }
    }

    static char[] ReadSecretWord()
    {
        string SecretWord;
        char[] WhiteList = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        while (true) {
            Console.WriteLine("Enter your secret word: ");
            SecretWord = Convert.ToString(Console.Read()).ToUpper();
            bool Error = false;
            for (int i = 0; i < SecretWord.Length; i++)
            {
                if (!WhiteList.Contains(SecretWord[i])) {

                    Error = true;
                    continue;

                }

            }
            if (!Error)
            {
                break;
            }

        }

        char[] SecretArray = SecretWord.ToCharArray();


        return SecretArray;

    }

    static char ReadOneChar() // Modification of method declaration recommended: Add return value and parameters
                              // If there are rules and constraints on allowed secrets (e.g. no digits), make sure the input is allowed
    {
        char GuessLetter;
        while (true)
        {
            Console.WriteLine("Enter you guess: ");

            try
            {
                GuessLetter = Convert.ToChar(Console.ReadLine());
                break;
            }
            catch
            {
                Console.Clear();
                continue;
            }
        }

        return GuessLetter;

    }

    static void EvaluateTheSituation() // Modification of method declaration recommended: Add return value and parameters
                                       // In here, evaluate the char entered: Is it part of the secret word?
                                       // Calculate and return the game status (Hit or missed? Where? List and number of missed chars?...)
    {
        // Variable declarations allowed here
        // NO Console.Write() etc. in here!
    }

    static void QuitOrRestart() // Modification of method declaration recommended: Add return value and parameters
                                // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!
    }

    static void HangTheMan(int AmountLives, string SecretWord) // Modification of method declaration recommended: Add return value and parameters
                             // In here, clear the screen and redraw everything reflecting the actual game status
    {
        Console.Clear();
        string Hangman = "";
        string EncodedWord = WordEncoder(SecretWord);

        if (AmountLives == 6)
        {
            
            Hangman = """
                ____________..________
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
                \"\"\"\"\"\"\"\"\"\"\|_________|\"\"\"|
                |\"|\"\"\"\"\"\"\"––––––––––\'\"|\"|
                | |                   | |
                : :                   : :  
                . .                   . .

                """;
        }
        else if (AmountLives == 5)
        {
            Hangman = """

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
                \""\""\""\""\""|_        |\""\"|
                |\"|"\""\""\""\ \       '"|"|
                | |        \ \        | |
                : :         \ \       : :  
                . .          `'       . .

               """;
        }
        else if (AmountLives == 4)
        {
            Hangman = """
                ______________________
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
                \"\"\"\"\"\"\"\"\"\"\|_________|\"\"\"|
                |\"|\"\"\"\"\"\"\"––––––––––\'\"|\"|
                | |                   | |
                : :                   : :  
                . .                   . .

                """;
        }
        else if (AmountLives == 3)
        {
            Hangman = """
                ______________________
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
                \"\"\"\"\"\"\"\"\"\"\|_________|\"\"\"|
                |\"|\"\"\"\"\"\"\"––––––––––\'\"|\"|
                | |                   | |
                : :                   : :  
                . .                   . .

                """;
        }
        else if (AmountLives == 2)
        {
            Hangman = """
                ______________________
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
                \"\"\"\"\"\"\"\"\"\"\|_________|\"\"\"|
                |\"|\"\"\"\"\"\"\"––––––––––\'\"|\"|
                | |                   | |
                : :                   : :  
                . .                   . .

                """;
        }
        else if (AmountLives == 1)
        {
            Hangman = """
                ______________________
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
                \"\"\"\"\"\"\"\"\"\"\|_________|\"\"\"|
                |\"|\"\"\"\"\"\"\"––––––––––\'\"|\"|
                | |                   | |
                : :                   : :  
                . .                   . .

                """;

        }
        else if (AmountLives == 0)
        {
            Hangman = """
                ______________________
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
                \"\"\"\"\"\"\"\"\"\"\|_________|\"\"\"|
                |\"|\"\"\"\"\"\"\"––––––––––\'\"|\"|
                | |                   | |
                : :                   : :  
                . .                   . .

                """;

        }





        Console.WriteLine("""

        Lives Left: {0}

        Secret word: {1}

        Used letters:
        """, AmountLives, EncodedWord

        );

        Console.WriteLine(Hangman);
        Console.WriteLine(EncodedWord);

    }


    static string[] WordEncoder(string[] WordToEncode)
    {
        string[] EncodedWord = WordToEncode;

        for(int i = 0; i < WordToEncode.Length; i++)
        {
            EncodedWord[i] = "_";
        }
        return EncodedWord;
    }


}