namespace Assignments.TicTacToe
{
    internal class Program
    {
        private static char currentPlayer = 'X';
        static char[,] board = new char[,]
           {
               {'-', '-' , '-' },
               {'-', '-' , '-' },
               {'-', '-' , '-' },
               {'-', '-' , '-' },
           };

        static void Main(string[] args)
        {



            Console.WriteLine("Welcome to Tic Tac Toe!");
            ChoosePlayerSymbols();
            DisplayBoard(board);
            PlayerMove(board);
            DisplayBoard(board);
            SwitchPlayer();
            PlayerMove(board);
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
        static void PlayerMove(char[,] board)
        {
            try
            {
                Console.Write("Enter Player1 position (x,y or x y): ");
                var playerInput = Console.ReadLine();
                var inputArray = playerInput.Split(' ');

                if (inputArray.Length != 2 || !int.TryParse(inputArray[0], out var parsedX) || !int.TryParse(inputArray[1], out var parsedY)
                    || parsedX < 0 || parsedX >= board.GetLength(0) || parsedY < 0 || parsedY >= board.GetLength(1))
                {
                    Console.WriteLine("Please enter a valid position within the board range.");
                    return;
                }
                if (board[parsedX, parsedY] == '-')
                {
                    board[parsedX, parsedY] = 'X';
                }
                else
                {
                    Console.WriteLine("The position is already occupied. Please choose an empty position.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            Console.WriteLine($"Switching to Player {currentPlayer}'s turn.");
        }
    }
}