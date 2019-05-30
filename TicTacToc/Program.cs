using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerHuman gA = new PlayerHuman();
            PlayerComputer gB = new PlayerComputer();
            gA.Name = "User";
            gB.Name = "Computer";
            gA.Symbol = 'O';
            gB.Symbol = 'X';


            char[,] board = new char[3, 3] 
            {
                { '1','2','3'},
                { '4','5','6'},
                { '7','8','9'}
            };
            char[,] boardCopy = board.Clone() as char [,];

            bool gameOver = false;
            bool movePlayerA = true;
            for (int round = 0; round < board.Length; ++round)
            {
                Console.Clear();
                DrawBoard(board);

                if (movePlayerA)
                {
                    Console.WriteLine("Current player: " + gA.Name);
                    gameOver = gA.MakeMove(board, boardCopy);
                    movePlayerA = false;
                }
                else 
                {
                    Console.WriteLine("Current player: " + gB.Name);
                    gameOver = gB.MakeMove(board, boardCopy);
                    movePlayerA = true;

                }
                Console.ReadKey();              
            }
            
        }
        static void DrawBoard(char[,] board) 
        {
            int height = board.GetLength(0);
            int width = board.GetLength(1);
            for (int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                    Console.Write(board[i, j]);
                Console.WriteLine();
            }
                


        }


    }
    interface IMove
    {
        bool MakeMove(char[,] board, char[,] boardCopy);
    }

    abstract class Player 
    {
        public string Name {get; set;}
        public char Symbol {get; set;}
        public bool CheckIfGameOver(char [,] board) 
        {
            int height = board.GetLength(0);
            int width = board.GetLength(0);
            if (width != height)
                throw new Exception("The board is not a kwadrat");
            //sprawdzenie pionowych
            for (int i = 0; i < height; ++i) 
            {
                int SumOfRow = 0;
                for (int j = 0; j < width; ++j)
                {
                        if (board[i, j] == Symbol)
                            ++SumOfRow;
                }
                if (SumOfRow == width)
                    return true;
            }
            //sprawdzenie poziomych
            for (int j = 0; j < width; ++j)
            {
                int SumOfColumn = 0;
                for (int i = 0; i < height; ++i)
                {
                    if (board[i, j] == Symbol)
                        ++SumOfColumn;
                }
                if (SumOfColumn == height)
                    return true;
            }

            //sprawdzenie przekatnych
            int sumOfDiagonalA = 0;
            int sumOfDiagonalB = 0;
            for (int k = 0; k < width; ++k)
            {
                if (board[k, k] == Symbol)
                    ++sumOfDiagonalA;
                if (board[k, width - 1 - k] == Symbol)
                    ++sumOfDiagonalB;
            }
            if (sumOfDiagonalA == width || sumOfDiagonalB == width)
                return true;

            return false;

        }
    }

    class PlayerHuman : Player, IMove 
    {
        public bool MakeMove (char[,] board, char[,] boardCopy)
        {
            return CheckIfGameOver(board);   //to corect
        }
    }

    class PlayerComputer : Player, IMove
    {
        public bool MakeMove (char[,] board, char[,] boardCopy)
        {
            return CheckIfGameOver(board); //to corect
        }
    }



    //
}
