using System;
using System.Collections.Generic;
using CatFood.Models;
using FluentAssertions;
using Xunit;

namespace CatFood.Test
{
    public class CatTests
    {

        private Cat _cat;

        [Fact]
        public void Board_ChangeDirectionLeft_E()
        {
            //Arrange
            List<string> moves = new List<string>();

            moves.AddRange(new String[] { "M", "M", "L", "M", "R", "M" });

            _cat = new Cat(new Coordinates(1, 0), "S", moves);

            //Act
            _cat.ChangeDirectionLeft();

            //Assert
            _cat.Direction.Should().Be("E");

        }

        [Fact]
        public void Board_ChangeDirectionRight_E()
        {
            //Arrange
            List<string> moves = new List<string>();
            moves.AddRange(new String[] { "M", "M", "L", "M", "R", "M" });
            _cat = new Cat(new Coordinates(1, 0), "N", moves);

            //Act
            _cat.ChangeDirectionRight();

            //Assert
            _cat.Direction.Should().Be("E");

        }

        [Fact]
        public void Board_MoveCat_Xequal2()
        {
            //Arrange
            List<string> moves = new List<string>();
            moves.AddRange(new String[] { "M", "M", "L", "M", "R", "M" });
            _cat = new Cat(new Coordinates(1, 0), "S", moves);

            //Act
            _cat.MoveCat();

            //Assert
            _cat.Position.X.Should().Be(2);

        }
    }
}
