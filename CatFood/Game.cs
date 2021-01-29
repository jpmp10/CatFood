using System;
using CatFood.Models;

namespace CatFood
{
    public class Game
    {
        public Board _board;
        public Cat _cat;

        public Game(Board board, Cat cat)
        {
            _board = board;
            _cat = cat;
        }

        public void Run()
        {
            try
            {
                //Verify first position of the cat
                if (!_board.IsInsideBoard(_cat.Position))
                {
                    Console.WriteLine("Cat out of the board grid.");
                    return;
                }
                if (_board.InFoodPosition(_cat.Position))
                {
                    Console.WriteLine("Success!");
                    return;
                }
                if (_board.HasMine(_cat.Position))
                {
                    Console.WriteLine("Dog Hit");
                    return;
                }

                //Start reading cat's moves
                foreach (string move in _cat.MovesList)
                {
                    NextMove(move);
                    Console.WriteLine("Position:" + _cat.Position.X + "," + _cat.Position.Y);
                    if (!_board.IsInsideBoard(_cat.Position))
                    {
                        Console.WriteLine("Cat out of the board grid.");
                        return;
                    }
                    if (_board.InFoodPosition(_cat.Position))
                    {
                        Console.WriteLine("Success!");
                        return;
                    }
                    if (_board.HasMine(_cat.Position))
                    {
                        Console.WriteLine("Dog Hit");
                        return;
                    }
                }
                Console.WriteLine("Still in Danger");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong:" + ex.Message + "StackTrace:" + ex.StackTrace);
                throw new Exception("Something went wrong during the game:" + ex.Message);
            }
        }

        public void NextMove(string move)
        {
            switch (move)
            {
                case "R":
                    _cat.ChangeDirectionRight();
                    break;
                case "L":
                    _cat.ChangeDirectionLeft();
                    break;
                case "M":
                    _cat.MoveCat();
                    break;
                default: break;
            }
        }

    }
}
