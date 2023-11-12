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
           };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            ChoosePlayerSymbols();
            DisplayBoard(board);

            while (!IsGameOver(board))
            {
                PlayerMove(board);
                DisplayBoard(board);
                SwitchPlayer();
            }
        }

        static bool IsGameOver(char[,] board)
        {
            if (CheckForWinner(board))
            {
                Console.WriteLine("Game Over!");
                return true;
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '-')
                    {
                        return false; // Found an empty space, game is not over
                    }
                }
            }
            Console.WriteLine("It's a draw!");
            return true;
        }
        static void DisplayBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(" " + board[i, j] + " ");
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
                Console.Write($"Enter Player {currentPlayer} position (x, y or x y): ");
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
                    board[parsedX, parsedY] = currentPlayer;
                }
                else
                {
                    Console.WriteLine($"Can not set position. [{parsedX}, {parsedY}] is not empty");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static bool CheckForWinner(char[,] board)
        {
            // Check rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] != '-' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    Console.WriteLine($"Player {board[i, 0]} wins!");
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[0, j] != '-' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    Console.WriteLine($"Player {board[0, j]} wins!");
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                Console.WriteLine($"Player {board[0, 0]} wins!");
                return true;
            }

            if (board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                Console.WriteLine($"Player {board[0, 2]} wins!");
                return true;
            }
            return false;
        }
        static void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            Console.WriteLine($"Switching to Player {currentPlayer}'s turn.");
        }
    }
}