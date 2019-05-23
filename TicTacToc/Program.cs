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

            bool gameOver = false;
            bool movePlayerA = true;
            while (!gameOver)
            {
                Console.Clear();
                DrawBoard(board);
                if (movePlayerA)
                {
                    Console.WriteLine("Current player: " + gA.Name);
                    gameOver = gA.MakeMove(board);
                    movePlayerA = false;
                }
                else 
                {
                    Console.WriteLine("Current player: " + gB.Name);
                    gameOver = gB.MakeMove(board);
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
        bool MakeMove(char[,] board);
    }

    abstract class Player 
    {
        public string Name {get; set;}
        public char Symbol {get; set;}
    }

    class PlayerHuman : Player, IMove 
    {
        public bool MakeMove (char[,] board)
        {
            return false;   //to corect
        }
    }

    class PlayerComputer : Player, IMove
    {
        public bool MakeMove (char[,] board)
        {
            return false;   //to corect
        }
    }



    //
}
