using System;
using System.Threading;

namespace TestTerraria
{
    public class Person
    {
        private int x = 1;
        private int y = 16;

        Direction previousDirection;

        public Point Location
        {
            get
            {
                return new Point( x,y );
            }
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                Move(Direction.LEFT);
            else if (key == ConsoleKey.RightArrow)
                Move(Direction.RIGHT);
            else if (key == ConsoleKey.UpArrow)
                Move(Direction.UP);
            else if (key == ConsoleKey.DownArrow)
                Move(Direction.DOWN);
            else if (key == ConsoleKey.Spacebar)
                Jump();
            else if (key == ConsoleKey.Escape)
                Environment.Exit(0);
        }

        private void Jump()
        {
            clear();
            y--;
            Draw();

            Thread.Sleep(10);
            Move(previousDirection);
            Thread.Sleep(10);

            clear();
            y--;
            Draw();

            Thread.Sleep(50);
            Move(previousDirection);
            Thread.Sleep(50);
            clear();
            y++;
            Draw();

            Thread.Sleep(50);
            Move(previousDirection);
            Thread.Sleep(50);
            clear();
            y++;
            Draw();

            Thread.Sleep(10);
            Move(previousDirection);
            Thread.Sleep(10);

            previousDirection = Direction.STOP;
        }

        private void clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        private bool Move(Direction direction)
        {
            previousDirection = direction;

            clear();

            switch (direction)
            {
                case Direction.LEFT:
                    x--;
                    break;
                case Direction.RIGHT:
                    x++;
                    break;
                case Direction.UP:
                    y--;
                    break;
                case Direction.DOWN:
                    y++;
                    break;
                default:
                    return false;
            }            

            return true;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write('*');
        }
    }
}
