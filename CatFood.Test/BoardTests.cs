using System;
using System.Collections.Generic;
using CatFood.Models;
using FluentAssertions;
using Xunit;

namespace CatFood.Test
{
    public class BoardTests
    {
        private Board _board;

        [Fact]
        public void Board_HasDog_False()
        {
            //Arrange
            List<Mine> mines = new List<Mine>();

            mines.Add(new Mine { position = new Coordinates(1, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 4) });
            mines.Add(new Mine { position = new Coordinates(3, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 0) });

            _board = new Board(4, 5, mines, new Coordinates(3, 4));
            Coordinates coordinates = new Coordinates(1, 1);

            var ExpectedResult = true;

            //Act
            var result = _board.HasMine(coordinates);

            //Assert
            result.Should().Be(ExpectedResult);

        }

        [Theory]
        [InlineData(1, 2, false)]
        [InlineData(3, 1, true)]
        [InlineData(2, 2, false)]
        public void Board_HasDog_ReturnTrueFalse(int x, int y, bool expectedValue)
        {
            //Arrange
            List<Mine> mines = new List<Mine>();

            mines.Add(new Mine { position = new Coordinates(1, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 4) });
            mines.Add(new Mine { position = new Coordinates(3, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 0) });

            _board = new Board(4, 5, mines, new Coordinates(3, 4));

            Coordinates CatPosition = new Coordinates(x, y);
            //Act
            var result = _board.HasMine(CatPosition);

            result.Should().Be(expectedValue);
        }

        [Fact]
        public void Board_InFoodPosition_False()
        {
            //Arrange
            List<Mine> mines = new List<Mine>();

            mines.Add(new Mine { position = new Coordinates(1, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 4) });
            mines.Add(new Mine { position = new Coordinates(3, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 0) });

            _board = new Board(4, 5, mines, new Coordinates(3, 4));

            Coordinates CatPosition = new Coordinates(2, 3);


            var result = _board.InFoodPosition(CatPosition);

            result.Should().Be(false);

        }

        [Fact]
        public void Board_IsInsideBoard_true()
        {
            //Arrange
            List<Mine> mines = new List<Mine>();

            mines.Add(new Mine { position = new Coordinates(1, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 4) });
            mines.Add(new Mine { position = new Coordinates(3, 1) });
            mines.Add(new Mine { position = new Coordinates(2, 0) });

            _board = new Board(4, 5, mines, new Coordinates(3, 4));

            Coordinates CatPosition = new Coordinates(6, 7);


            var result = _board.InFoodPosition(CatPosition);

            result.Should().Be(false);

        }
    }
}
