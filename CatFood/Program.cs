using System;
using System.IO;
using CatFood.Models;

namespace CatFood
{
    class Program
    {
        public static Game game;

        static void Main(string[] args)
        {
            Console.WriteLine("-> Cat Food Start <-");
            CatFoodStart();
        }

        public static void CatFoodStart()
        {
            string path = "Config/config.txt";

            try
            {
                string[] data = File.ReadAllLines(path);
                Board board = new Board(data);
                Cat cat = new Cat(data);

                game = new Game(board, cat);
                game.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong! " + ex.Message);
            }

        }
    }
}
