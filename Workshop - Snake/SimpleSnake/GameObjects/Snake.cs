using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake : Point
    {
        private const char SnakeSymbol = '\u25CF';

        private readonly Food[] food;
        private readonly Queue<Point> snakeElements;
        private readonly Wall wall;

        private int foodIndex = new Random().Next(0, 3);

        public Snake(Wall wall, int leftX, int topY) 
            : base(leftX, topY)
        {
            this.wall = wall;

            this.snakeElements = new Queue<Point>();

            this.food = new Food[]
            {
                new FoodAsterisk(this.wall),
                new FoodDollar(this.wall),
                new FoodHash(this.wall)
            };

            this.CreateSnake();
            this.food[this.foodIndex].SetRandomPosition(this.snakeElements); 
        }

        public int Length
            => this.snakeElements.Count;

        public bool IsMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElements.Last();

            GetNextDirection(currentSnakeHead, direction);

            if (IsWallPoint())
            {
                return false;
            }

            if (IsPointOfSnake())
            {
                return false;
            }

            Point newHead = CreateNewHead();

            if (this.food[foodIndex].IsFoodPoint(newHead))
            {
                this.Eat(direction, newHead);
            }

            RemoveTail();

            return true;
        }

        private void RemoveTail()
        {
            var tail = this.snakeElements.Dequeue();
            tail.Draw(' ');
        }

        private Point CreateNewHead()
        {
            var newHead = new Point(this.LeftX, this.TopY);
            newHead.Draw(SnakeSymbol);
            this.snakeElements.Enqueue(newHead);
            return newHead;
        }

        private void Eat(Point direction, Point newHead)
        {
            for (int i = 0; i < this.food[foodIndex].FoodPoints; i++)
            {
                this.GetNextDirection(newHead, direction);

                newHead = new Point(this.LeftX, this.TopY);
                newHead.Draw(SnakeSymbol);

                this.snakeElements.Enqueue(newHead);
            }

            this.food[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private bool IsPointOfSnake()
            => this.snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
        

        private bool IsWallPoint()
            =>  this.LeftX == 0 || this.TopY == 0 ||
                this.LeftX == this.wall.LeftX - 1 ||
                this.TopY == this.wall.TopY;

        private void GetNextDirection(Point head, Point direction)
        {
            this.LeftX = head.LeftX + direction.LeftX;
            this.TopY = head.TopY + direction.TopY;
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }
    }
}
