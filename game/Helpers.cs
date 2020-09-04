using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    static class Helpers
    {
        // This is called if you don't pass any value. RollDice()
        public static int RollDice()
        {
            Random randomiser = new Random();

            return randomiser.Next(0, 13);
        }

        // This is called if you pass an integer. E.g. RollDice(5)
        public static int RollDice(int num)
        {
            Random randomiser = new Random();

            return randomiser.Next(0, num);
        }

        public static void WriteText(string msg, string colour)
        {
            switch (colour)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }

            Console.Write(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void Wait()
        {
            Console.Read();
        }
    }
}
