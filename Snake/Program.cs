using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        const ConsoleColor Sneak_Color = ConsoleColor.Black;
        const ConsoleColor Background_Color = ConsoleColor.White;
        const ConsoleColor Food_Color = ConsoleColor.Gray;

        public static Coordinate Sneak { get; set; }
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

        static void MoveSneak(int x, int y)
        {
            Random rnd = new Random();
            Coordinate newSneak = new Coordinate()
            {
                X = Sneak.X + x,
                Y = Sneak.Y + y
            };

            Coordinate newFood = new Coordinate()
            {
                X = rnd.Next(0, Console.WindowWidth),
                Y = rnd.Next(0, Console.WindowHeight)
            };

            if (CanMove(newSneak))
            {
                RemoveSneak();
                Console.BackgroundColor = Sneak_Color;
                Console.SetCursorPosition(newSneak.X, newSneak.Y);
                Console.Write(" ");

                Sneak = newSneak;
            }
        }

        static void RemoveFood()
        {
            Console.BackgroundColor = Background_Color;
            Console.SetCursorPosition(Food.X, Food.Y);
            Console.WriteLine(" ");
        }

        static void RemoveSneak ()
        {
            Console.BackgroundColor = Background_Color;
            Console.SetCursorPosition(Sneak.X, Sneak.Y);
            Console.WriteLine(" ");
        }

        static void SetBackgroundColor()
        {
            Console.BackgroundColor = Background_Color;
            Console.Clear();
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

            Sneak = new Coordinate()
            {
                X = 0,
                Y = 0
            };
            MoveSneak(0, 0);
        }
    }

    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
