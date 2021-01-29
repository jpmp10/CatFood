using System;
using System.Collections.Generic;

namespace CatFood.Models
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public List<Mine> Mines { get; set; }
        public Coordinates FoodPosition { get; set; }


        public Board(int lines, int columns, List<Mine> mines, Coordinates foodPosition)
        {
            Columns = columns;
            Lines = lines;
            Mines = mines;
            FoodPosition = foodPosition;
        }

        public Board(string[] data)
        {
            try
            {
                Columns = Convert.ToInt32(data[0].Split(' ')[0]);
                Lines = Convert.ToInt32(data[0].Split(' ')[1]);
                Mines = GetMines(data[1]);
                FoodPosition = GetFoodPoint(data[2]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading board from config file :" + ex.Message);
            }
        }

        private List<Mine> GetMines(string mines)
        {
            List<Mine> minesList = new List<Mine>();
            foreach (string mine in mines.Split(' '))
            {
                string[] position = mine.Split(',');
                minesList.Add(new Mine
                {
                    position = new Coordinates(Convert.ToInt32(position[0]), Convert.ToInt32(position[1]))
                });
            }
            return minesList;
        }

        private Coordinates GetFoodPoint(string foodPoint)
        {
            return new Coordinates(Convert.ToInt32(foodPoint.Split(' ')[0]), Convert.ToInt32(foodPoint.Split(' ')[1]));
        }

        public bool HasMine(Coordinates xy)
        {
            foreach (Mine mine in Mines)
            {
                if (mine.position.X == xy.X && mine.position.Y == xy.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool InFoodPosition(Coordinates xy)
        {
            return (FoodPosition.X == xy.X && FoodPosition.Y == xy.Y);
        }

        public bool IsInsideBoard(Coordinates xy)
        {
            return !(xy.X < 0 || xy.Y < 0 || xy.X > Columns || xy.Y > Lines);
        }
    }
}
