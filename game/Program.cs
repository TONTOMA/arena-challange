using System;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player()
            {
                Name = "Player",
                Health = 100,
                Weapon = Weapons.Fist,
                Accuracy = 12
            };

            Console.WriteLine("Welcome to Gregs Battle Arena");
            Console.Write("Choose your name: ");
            player.Name = Console.ReadLine();

            Console.WriteLine("Choose Difficulty");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Hard");
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

            bool loop = true;

            while(loop)
            {
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Shop");
                Console.WriteLine("3. View Stats");
                Console.WriteLine("Quit");

                option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        Fight();
                        break;
                    case "2":
                        Shop();
                        break;
                    case "3":
                        PlayerStats(player);
                        break;
                    case "Quit":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect Option!");
                        break;
                }

                Console.Clear();
            }
        }

        static void Fight()
        {

            Console.WriteLine("Under Contruction");
            Wait();

            //Console.WriteLine("You wake up in an arena with a Goblin coming for you. You are equipped with only your fists");
            //Console.WriteLine("{0} vs {1}", player.Name, enemy.Name);

            //Console.Write("You:");
            //PlayerStats(player);
            //Console.Write("Enemy: ");
            //EnemyStats(enemy);

            //while (player.Health > 0 && enemy.Health > 0)
            //{
            //    //Console.Write("Ye hit eachother ||");
            //    //Console.WriteLine(" {0} Health: {1} | {2} Health: {3}", player.Name, player.Health, enemy.Name, enemy.Health);

            //    if (RollDice() <= enemy.Accuracy)
            //    {
            //        player.Health -= enemy.Weapon.Damage;
            //        Console.WriteLine("{0} hits {1} for {2} Damage", enemy.Name, player.Name, enemy.Weapon.Damage);
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0} Missed!", enemy.Name);
            //    }

            //    if (RollDice() <= player.Accuracy)
            //    {
            //        enemy.Health -= player.Weapon.Damage;
            //        Console.WriteLine("{0} hits {1} for {2} Damage", player.Name, enemy.Name, player.Weapon.Damage);
            //    }
            //    else
            //    {
            //        Console.WriteLine("{0} Missed!", player.Name);
            //    }
            //}
            //if (player.Health <= 0)
            //{
            //    Console.WriteLine("You lost!");
            //}
            //else
            //{
            //    Console.WriteLine("You won!");

            //}
            //Console.WriteLine("\n");
            //PlayerStats(player);
            //EnemyStats(enemy);
        }

        static void Shop()
        {
            Console.WriteLine("Under Contruction");
            Wait();
        }

        static void PlayerStats(Player player)
        {
            Console.WriteLine("\nName: {0} | Current Health: {1} | Weapons: {2}", player.Name, player.Health, player.Weapon.Name);
            Wait();
        }

        static void EnemyStats(Enemy enemy)
        {
            Console.WriteLine("\nName: {0} | Current Health: {1} | Weapons: {2}\n", enemy.Name, enemy.Health, enemy.Weapon.Name);
        }

        static int RollDice()
        {
            Random randomiser = new Random();

            return randomiser.Next(0, 13);
        }

        static void Wait(){
            Console.Read();
        }
    }
}

