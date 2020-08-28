using System;
using System.Linq;
using System.Threading;

namespace game
{
    class Program
    {
        static Player player;

        static void Main(string[] args)
        {
            player = new Player()
            {
                Name = "Player",
                Health = 100,
                Weapon = Weapons.Fist,
                Accuracy = 6
            };

            // TEST CODE!
            //Fight();
            // END TEST CODE!
           

            Console.WriteLine("Welcome to Gregs Battle Arena");
            Console.Write("Choose your name: ");
            player.Name = Console.ReadLine();

            ClearConsole();

            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Hard");
            Console.Write("Choose Difficulty: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    player.Health = 120;
                    break;
                case "2":
                    player.Health = 100;
                    break;
                case "3":
                    player.Health = 80;
                    break;
                default:
                    Console.WriteLine("Incorrect Option!");
                    break;
            }

            ClearConsole();

            bool loop = true;

            while (loop)
            {
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Shop");
                Console.WriteLine("3. View Stats");
                Console.WriteLine("9. Quit");

                Console.Write("Enter Option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Fight();
                        break;
                    case "2":
                        Shop();
                        break;
                    case "3":
                        PlayerStats();
                        break;
                    case "9":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect Option!");
                        break;
                }
            }
        }

        static void Fight()
        {
            ClearConsole();
            int rand = RollDice(Enemies.EnemyList.Count);

            Enemy enemy = Enemies.EnemyList.Values.ElementAt(rand);

            PlayerStats();
            Console.WriteLine("\nVS");
            EnemyStats(enemy);

            while(player.Health > 0 && enemy.Health > 0)
            {
                if (RollDice() <= enemy.Accuracy)
                {
                    player.Health -= enemy.Weapon.Damage;
                    Console.WriteLine("{0} hits {1} for {2} Damage", enemy.Name, player.Name, enemy.Weapon.Damage);
                }
                else
                {
                    Console.WriteLine("{0} Missed!", enemy.Name);
                }

                if (RollDice() <= player.Accuracy)
                {
                    enemy.Health -= player.Weapon.Damage;
                    Console.WriteLine("{0} hits {1} for {2} Damage", player.Name, enemy.Name, player.Weapon.Damage);
                }
                else
                {
                    string msg = String.Format("{0} Missed!", player.Name);
                    WriteText(msg, "red");
                }

                Console.WriteLine("\n");
                Thread.Sleep(1000);
            }

            if (player.Health <= 0)
            {
                WriteText("You Lost!", "red");
            }
            else
            {
                WriteText("You won!", "blue");
            }

            PlayerStats();
            EnemyStats(enemy);

            Wait();
        }

        static void Shop()
        {
            Console.WriteLine("Under Contruction");
            Wait();
        }

        static void PlayerStats()
        {
            Console.WriteLine("\nName: {0} | Health: {1} | Weapon: {2}", player.Name, player.Health, player.Weapon.Name);
        }

        static void EnemyStats(Enemy enemy)
        {
            Console.WriteLine("\nName: {0} | Health: {1} | Weapon: {2}\n", enemy.Name, enemy.Health, enemy.Weapon.Name);
        }

        static int RollDice()
        {
            Random randomiser = new Random();

            return randomiser.Next(0, 13);
        }

        static int RollDice(int num)
        {
            Random randomiser = new Random();

            return randomiser.Next(0, num);
        }

        static void WriteText(string msg, string colour)
        {
            switch(colour)
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

        static void ClearConsole()
        {
            Console.Clear();
        }

        static void Wait(){
            Console.Read();
        }
    }
}

// Finish colours
// add who hits first, 
// add turns
// add more stats (Initiative?)