using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        const ConsoleColor Snake_Color = ConsoleColor.Black;
        const ConsoleColor Background_Color = ConsoleColor.White;
        const ConsoleColor Food_Color = ConsoleColor.Red;

        public static Coordinate Snake { get; set; }
        public static Coordinate Food { get; set; }

        static void Main(string[] args)
        {
            InitGame();

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveSneak(0, -1);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveSneak(0, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveSneak(-1, 0);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveSneak(1, 0);
                        break;

                    case ConsoleKey.X:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void SetFood (int x, int y)
        {
            Console.BackgroundColor = Food_Color;
            Console.SetCursorPosition(Food.X, Food.Y);
            Console.Write(" ");
        }

        static void MoveSneak(int x, int y)
        {
            Coordinate newSneak = new Coordinate()
            {
                X = Snake.X + x,
                Y = Snake.Y + y
            };

            if (CanMove(newSneak))
            {
                RemoveSnake();
                Console.BackgroundColor = Snake_Color;
                Console.SetCursorPosition(newSneak.X, newSneak.Y);
                Console.Write(" ");

                Snake = newSneak;
            }


            Coordinate checkFood = new Coordinate()
            {
                X = Food.X,
                Y = Food.Y
            };

            if (EatFood(newSneak, checkFood))
            {
                Random rnd = new Random();
                Coordinate newFood = new Coordinate()
                {
                    X = rnd.Next(0, Console.WindowWidth),
                    Y = rnd.Next(0, Console.WindowHeight)
                };

                Food = newFood;
                SetFood(Food.X, Food.Y);
            }
        }

        static void RemoveSnake ()
        {
            Console.BackgroundColor = Background_Color;
            Console.SetCursorPosition(Snake.X, Snake.Y);
            Console.WriteLine(" ");
        }

        static void SetBackgroundColor()
        {
            Console.BackgroundColor = Background_Color;
            Console.Clear();
        }

        static bool EatFood (Coordinate c, Coordinate a)
        {
            if (a.X == c.X && a.Y == c.Y)
                return true;
            return false;
        }

        static bool CanMove (Coordinate c)
        {
            if (c.X < 0 || c.X >= Console.WindowWidth)
                return false;
            if (c.Y < 0 || c.Y >= Console.WindowHeight)
                return false;
            return true;
        }

        static void InitGame()
        {
            SetBackgroundColor();
            Random rnd = new Random();

            Snake = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            Food = new Coordinate()
            {
                X = rnd.Next(1, 5),
                Y = rnd.Next(1, 5)
            };

            SetFood(Food.X, Food.Y);
            MoveSneak(0, 0);
        }
    }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
