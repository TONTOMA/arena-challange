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
                Armour = 30
                // Accuracy = 6
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
                ClearConsole();
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
            ChooseWeapon();
    
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

            Main();

        }

        static void PlayerAttack() 
        {
            if (RollDice() <= player.Weapon.Accuracy)
            {
                int netDamage = (int)(player.Weapon.Damage * (1 - (enemy.Armour * 0.7) / 100));
                enemy.Health -= netDamage;  // cast- converts all inside into an integer

                string msg = String.Format("\n{0} hits {1} for {2} Damage", player.Name, enemy.Name, netDamage);

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
                int netDamage = (int)(enemy.Weapon.Damage * (1 - (player.Armour * 0.7) / 100));
                player.Health -= netDamage;  // cast- converts all inside into an integer

                string msg = String.Format("\n{0} hits {1} for {2} Damage", enemy.Name, player.Name, netDamage);
                WriteText(msg, "red");
            }
            else
            {
                string msg = String.Format("\n{0} Missed!", enemy.Name);
                WriteText(msg, "green");
            }
        }

        static void ChooseWeapon()
        {
            Console.WriteLine("Weapons");

            for (int i = 0; i < Weapons.WeaponList.Count; i++) //// colin will explain
            {
                Console.WriteLine(i + 1 + ". " + Weapons.WeaponList.Values.ElementAt(i).Name);  /// colin will explain 
            }

            Console.Write("Choose a weapon: ");
            int option = Convert.ToInt32(Console.ReadLine());

            player.Weapon = Weapons.WeaponList.Values.ElementAt(option - 1);

            ClearConsole();

        }

        static void Equipment()
        {
            bool loop = true;

            while(loop)
            {
                ClearConsole();
                PlayerStats();
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
            Wait();
        }

        static void PlayerStats()
        {
            Console.WriteLine("\nName: {0} | Health: {1} | Armour: {2}\nWeapon: {3} | Damage: {4}\n", player.Name, player.Health, player.Armour, player.Weapon.Name, player.Weapon.Damage);

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
