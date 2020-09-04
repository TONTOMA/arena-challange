using System;
using System.Linq;
using System.Threading;

namespace game
{
    class Program
    {
        static Character player;
        static Character enemy;

        static void Main(string[] args)
        {
            player = new Character()
            {
                Name = "Player",
                Health = 100,
                Weapon = Weapons.Fist,
                Armour = 30
            };

            Console.WriteLine("Welcome to Gregs Battle Arena");
            Console.Write("Choose your name: ");
            player.Name = Console.ReadLine();

            Helpers.ClearConsole();

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

            Helpers.ClearConsole();

            bool loop = true;

            while (loop)
            {
                Helpers.ClearConsole();
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Equipment");
                //Console.WriteLine("3. Shop");
                Console.WriteLine("4. View Stats");
                Console.WriteLine("9. Quit");

                Console.Write("Enter Option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Fight();
                        break;
                    case "2":
                        Equipment();
                        break;
                    case "3":
                        player.Stats();
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
            ChooseWeapon();
    
            int rand = Helpers.RollDice(Enemies.List.Count);
            enemy = Enemies.List.Values.ElementAt(rand);

            player.Stats();
            Console.WriteLine("\nVS");
            enemy.Stats();

            string currentAttacker;

            if(Helpers.RollDice() <= 6)
            {
                currentAttacker = "player";
                player.Attack(enemy);
            }
            else
            {
                currentAttacker = "enemy";
                enemy.Attack(player);     
            }

            Console.WriteLine("\n");

            while (player.Health > 0 && enemy.Health > 0)
            { 
                if(currentAttacker == "player")
                {
                    enemy.Attack(player);
                    currentAttacker = "enemy";
                }
                else if(currentAttacker == "enemy")
                {
                    player.Attack(enemy);
                    currentAttacker = "player";
                }

                Console.WriteLine("\n");
                Thread.Sleep(800);
            }

            if (player.Health <= 0 && enemy.Health <= 0)
            {
                Helpers.WriteText("Draw, you are both dead!\n", "blue");
            }
            else if (player.Health <= 0)
            {
                Helpers.WriteText("You lost!\n", "blue");
            }
            else
            {
                Helpers.WriteText("You won!\n", "blue");
            }

            player.Stats();
            enemy.Stats();

            Helpers.Wait();       
        }

        static void ChooseWeapon()
        {
            Console.WriteLine("Weapons");

            for (int i = 0; i < Weapons.List.Count; i++) //// colin will explain
            {
                Console.WriteLine(i + 1 + ". " + Weapons.List.Values.ElementAt(i).Name);  /// colin will explain 
            }

            Console.Write("Choose a weapon: ");
            int option = Convert.ToInt32(Console.ReadLine());
            player.Equip(Weapons.List.Values.ElementAt(option - 1));
            
            Helpers.ClearConsole();
        }

        static void Equipment()
        {
            bool loop = true;

            while(loop)
            {
                Helpers.ClearConsole();
                player.Stats();
                Console.WriteLine("\n");
                Console.WriteLine("1. Weapon: {0}", player.Weapon.Name);
                Console.WriteLine("2. Helmet: {0}", "No helmet");
                Console.WriteLine("3. Body Armour: {0}", "No body armour");
                Console.WriteLine("9. Return to Main Menu");

                Console.Write("Enter Option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

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

        static void Shop()
        {
            Console.WriteLine("Under Contruction");
            Helpers.Wait();
        }
    }
}

