// See https://aka.ms/new-console-template for more information

public class Program
{
    // Variables
    static char[,] playField =
    {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static int turns = 0;

    static void Main()
    {
        int player = 2; // player 1 starts
        int input = 0;
        bool inputCorect = true;

        do
        {
            if (player == 2)
            {
                player = 1;
                EnterXorO('O', input);

            }
            else if (player == 1)
            {
                player = 2;
                EnterXorO('X', input);
            }

            SetField();

            // Winning check
            char[] playerChars = { 'X', 'O' };
            foreach (char playerChar in playerChars)
            {
                if((playField[0,0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar)
                    || (playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar)
                    || (playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar)
                    || (playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar)
                    || (playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar)
                    || (playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar)
                    || (playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar)
                    || (playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                {
                    if (playerChar == 'X')
                        Console.WriteLine("\nThe winner is Player 2");
                    else
                        Console.WriteLine("\nThe winner is Player 1");

                    Console.WriteLine("Press any key to reset the game :)");
                    Console.ReadKey();
                    ResetField();

                    break;
                }
                else if (turns == 10)
                {
                    Console.WriteLine("DRAW!");
                    Console.WriteLine("Press any key to reset the game :)");
                    Console.ReadKey();
                    ResetField();
                    break;
                }
            }

            // Checking if field is already taken
            do
            {
                Console.Write("\nPlayer {0}: Choose your field! ", player);
                try
                {
                    input = int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input! Enter a number.");
                }

                if (input == 1 && (playField[0, 0] == '1'))
                    inputCorect = true;
                else if (input == 2 && (playField[0, 1] == '2'))
                    inputCorect = true;
                else if (input == 3 && (playField[0, 2] == '3'))
                    inputCorect = true;
                else if (input == 4 && (playField[1, 0] == '4'))
                    inputCorect = true;
                else if (input == 5 && (playField[1, 1] == '5'))
                    inputCorect = true;
                else if (input == 6 && (playField[1, 2] == '6'))
                    inputCorect = true;
                else if (input == 7 && (playField[2, 0] == '7'))
                    inputCorect = true;
                else if (input == 8 && (playField[2, 1] == '8'))
                    inputCorect = true;
                else if (input == 9 && (playField[2, 2] == '9'))
                    inputCorect = true;
                else
                {
                    Console.WriteLine("\nIncorrect input. Use another field!");
                    inputCorect=false;
                }
            } while (!inputCorect);

        } while (true);
    }

    public static void ResetField()
    {
        char[,] playFieldInitial =
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        playField = playFieldInitial;
        SetField();
        turns = 0;
    }

    // Setting inputs
    public static void SetField()
    {
        Console.Clear();
        // first row of board
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", playField[0, 0], playField[0, 1], playField[0, 2]);
        Console.WriteLine("_____|_____|_____");
        // second row of board
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", playField[1, 0], playField[1, 1], playField[1, 2]);
        Console.WriteLine("_____|_____|_____");
        // third row of board
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
        Console.WriteLine("     |     |     ");
    }

    // Updating fields with a sign
    public static void EnterXorO(char playerSign, int input)
    {
        switch (input)
        { 
            case 1: playField[0, 0] = playerSign; break;
            case 2: playField[0, 1] = playerSign; break;
            case 3: playField[0, 2] = playerSign; break;
            case 4: playField[1, 0] = playerSign; break;
            case 5: playField[1, 1] = playerSign; break;
            case 6: playField[1, 2] = playerSign; break;
            case 7: playField[2, 0] = playerSign; break;
            case 8: playField[2, 1] = playerSign; break;
            case 9: playField[2, 2] = playerSign; break;
        }
    }
}


