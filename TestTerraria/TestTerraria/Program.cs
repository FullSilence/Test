using System;
using System.Collections.Generic;

namespace TestTerraria
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            Chunk chunk = new Chunk(new Point(0, 16), new Point(120, 1));
            chunk.Draw();


            while (true)
            {
                person.HandleKey(Console.ReadKey().Key);

                if (chunk.Collision(person.Location))
                {
                    Program.Exit();
                }


                person.Draw();
            }
        }

        private static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Игр окончена! Намите Enter");

            Console.ReadLine();

            Environment.Exit(0);
        }
    }





    class Chunk
    {
        private Point topLeft;

        private Point bottomRight;


        internal Point TopLeft
        {
            get
            {
                return topLeft;
            }

            set
            {
                topLeft = value;
            }
        }

        internal Point BottomRight
        {
            get
            {
                return bottomRight;
            }

            set
            {
                bottomRight = value;
            }
        }

        public List<Point> pointList = new List<Point>();

        public Chunk()
        {
        }

        public Chunk(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;

            for (int x = topLeft.X; x < bottomRight.X; x++)
            {
                PerlinNoise noise = new PerlinNoise(134243432L);

                pointList.Add(new Point(x, noise.getNoise(x, 28)));
            }
        }

        public void Draw()
        {
            foreach (var point in pointList)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write("#");
            }
        }

        public bool Collision(Point location)
        {
            foreach (var point in pointList)
            {
                if (point.X == location.X && point.Y == location.Y)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
