using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    class Program
    {
        static void Main(string[] args)
        {
            string PlayerX, PlayerO;       
            char SymbolX = 'x';
            char SymbolO = 'o';
            char[,] board = new char[3, 3] 
            {
                { '1','2','3'},
                { '4','5','6'},
                { '7','8','9'}
            };


            Console.WriteLine("Enter player1 name: ");
            PlayerX = Console.ReadLine();
            Console.WriteLine("Enter play2 name: ");
            PlayerO = Console.ReadLine();

            bool GameOver = false;
            while (!GameOver)
            {
                Console.Clear();
                DrawBoard(board);
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
}
