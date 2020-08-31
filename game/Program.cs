using System;
using System.Linq;
using System.Threading;

namespace game
{
    class Program
    {
        // Merge 2 fight functions. 
        // Player accuracy - modifies weapon accuracy.
        // Amour - Percentage reduction on damage taken. 
        // List of weapons before fight, can equip. 

        static Player player;
        static Enemy enemy;

        static void Main(string[] args)
        {
            player = new Player()
            {
                Name = "Player",
                Health = 100,
                Weapon = Weapons.Fist,
                // Accuracy = 6
                // Armour
            };

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
            Console.WriteLine("Weapons");

            for(int i=0; i<Weapons.WeaponList.Count; i++) //// colin will explain
            {
                Console.WriteLine(i+1 + ". " + Weapons.WeaponList.Values.ElementAt(i).Name);  /// colin will explain
            }

            Console.Write("Choose a weapon:");
            int option = Convert.ToInt32(Console.ReadLine());

            player.Weapon = Weapons.WeaponList.Values.ElementAt(option-1);

            ClearConsole();
            int rand = RollDice(Enemies.EnemyList.Count);

            enemy = Enemies.EnemyList.Values.ElementAt(rand);

            PlayerStats();
            Console.WriteLine("\nVS");
            EnemyStats(enemy);

            string currentAttacker;

            if(RollDice() <= 6)
            {
                currentAttacker = "player";

                string msg = String.Format("\n{0} attacks first\n\n", player.Name);
                WriteText(msg, "blue");
                PlayerAttack();

            }
            else
            {
                currentAttacker = "enemy";

                string msg = String.Format("\n{0} attacks first\n\n", enemy.Name);
                WriteText(msg, "blue");
                EnemyAttack();
                
            }

            Console.WriteLine("\n");

            while (player.Health > 0 && enemy.Health > 0)
            { 
                if(currentAttacker == "player")
                {
                    EnemyAttack();
                    currentAttacker = "enemy";
                }
                else if(currentAttacker == "enemy")
                {
                    PlayerAttack();
                    currentAttacker = "player";
                }

                Console.WriteLine("\n");
                Thread.Sleep(800);
            }

            if (player.Health <= 0 && enemy.Health <= 0)
            {
                WriteText("Draw, you are both dead!\n", "blue");
            }
            else if (player.Health <= 0)
            {
                WriteText("You lost!\n", "blue");
            }
            else
            {
                WriteText("You won!\n", "blue");
            }

            PlayerStats();
            EnemyStats(enemy);

            Wait();
        }

        static void PlayerAttack() 
        {
            if (RollDice() <= player.Weapon.Accuracy)
            {
                enemy.Health -= player.Weapon.Damage;
                string msg = String.Format("\n{0} hits {1} for {2} Damage", player.Name, enemy.Name, player.Weapon.Damage);
                WriteText(msg, "green");
            }
            else
            {
                string msg = String.Format("\n{0} Missed!", player.Name);
                WriteText(msg, "red");
            }
        }

        static void EnemyAttack()
        {
            if (RollDice() <= enemy.Weapon.Accuracy)
            {
                player.Health -= enemy.Weapon.Damage;
                string msg = String.Format("\n{0} hits {1} for {2} Damage", enemy.Name, player.Name, enemy.Weapon.Damage);
                WriteText(msg, "red");
            }
            else
            {
                string msg = String.Format("\n{0} Missed!", enemy.Name);
                WriteText(msg, "green");
            }
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