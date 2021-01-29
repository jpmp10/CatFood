using System;
using System.Collections.Generic;

namespace CatFood.Models
{
    public class Cat
    {

        public Coordinates Position { get; set; }
        public string Direction { get; set; }
        public List<string> MovesList { get; set; }

        public Cat(Coordinates position, string direction, List<string> moves)
        {
            Position = position;
            Direction = direction;
            MovesList = moves;
        }

        public Cat(string[] data)
        {
            try
            {
                Position = GetPosition(data[3]);
                Direction = GetDirection(data[3]);
                MovesList = GetMoves(data);
            }
            catch(Exception ex)
            {
                throw new Exception("Error loading cat from config file :" + ex.Message);
            }
        }

        private Coordinates GetPosition(string dataPosition)
        {
            return new Coordinates(Convert.ToInt32(dataPosition.Split(' ')[0]), Convert.ToInt32(dataPosition.Split(' ')[1]));
        }

        private string GetDirection(string dataPosition)
        {
            return dataPosition.Split(' ')[2];
        }

        private static List<string> GetMoves(string[] movesList)
        {
            List<string> moves = new List<string>();
            for (int i = 4; i < movesList.Length; i++)
            {
                foreach (string c in movesList[i].Split(' '))
                {
                    moves.Add(c);
                }
            }
            return moves;
        }

        public void ChangeDirectionRight()
        {
            switch (Direction)
            {
                case "N":
                    Direction = "E";
                    break;
                case "E":
                    Direction = "S";
                    break;
                case "S":
                    Direction = "W";
                    break;
                case "W":
                    Direction = "N";
                    break;

                default: break;
            }
        }

        public void ChangeDirectionLeft()
        {
            switch (Direction)
            {
                case "N":
                    Direction = "W";
                    break;
                case "E":
                    Direction = "N";
                    break;
                case "S":
                    Direction = "E";
                    break;
                case "W":
                    Direction = "S";
                    break;
                default: break;
            }
        }

        public void MoveCat()
        {
            switch (Direction)
            {
                case "N":
                    Position.X--;
                    break;
                case "E":
                    Position.Y++;
                    break;
                case "S":
                    Position.X++;
                    break;
                case "W":
                    Position.Y--;
                    break;
                default: break;
            }
        }
    }


}
