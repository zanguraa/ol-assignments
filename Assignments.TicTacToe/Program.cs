namespace Assignments.TicTacToe
{
    internal class Program
    {
        static char[,] board = new char[3, 3];
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            DisplayBoard(board);
            ChoosePlayerSymbols();
        }

        static void DisplayBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(" " + board[i, j] + "-");
                }
                Console.WriteLine();

            }
        }
        static void ChoosePlayerSymbols()
        {
            Console.WriteLine("Player 1, choose 'X' or 'O': ");

            char player1Symbol;
            while (true)
            {
                player1Symbol = char.ToUpper(Console.ReadKey().KeyChar);
                if (player1Symbol == 'X' || player1Symbol == 'O')
                {
                    break;
                }
                Console.WriteLine("\nInvalid choice. Please choose 'X' or 'O': ");
            }

            char player2Symbol = player1Symbol == 'X' ? 'O' : 'X';
            Console.WriteLine($"\nPlayer 1 is '{player1Symbol}' and Player 2 is '{player2Symbol}'. Let's start the game!\n");
        }

    }
}