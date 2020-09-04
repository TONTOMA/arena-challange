using System;
using System.Collections.Generic;
using System.Text;
// al t + left mouse
namespace game
{
    public class Character
    {
        public string Name { set; get; }
        public int Health { set; get; }
        public int Armour { set; get; }
        public Weapon Weapon { set; get; }

        public void Attack(Character enemy)
        {
            var num = Helpers.RollDice();
                
            if(num <= Weapon.Accuracy)
            {
                int netDamage = (int)(Weapon.Damage * (1 - (enemy.Armour * 0.7) / 100));
                enemy.Health -= netDamage;
                Console.WriteLine("{0} attacks {1} for {2} damage", Name, enemy.Name, netDamage);
            }
            else
            {
                Console.WriteLine("{0} Missed!", Name);
            }
        }

        public void Stats()
        {
            Console.WriteLine("\nName: {0} | Health: {1} | Armour: {2}\nWeapon: {3} | Damage: {4}\n", Name, Health, Armour, Weapon.Name, Weapon.Damage);
        }        
        
        public void Equip(Weapon weapon)
        {
            Weapon = weapon;
        }
    }

    public static class Enemies
    {
        public static Dictionary<string, Character> List = new Dictionary<string, Character>();

        private static Character joshTheBoss;
        private static Character jimmyTheGoblin;
        private static Character sarahTheDestroyer;
        private static Character karenTheEntitled;

        static Enemies()
        {    
            
            jimmyTheGoblin = new Character()
            {
                Name = "Jimmy",
                Health = 60,
                Armour = 20,
                Weapon = Weapons.Claw,
                //Accuracy = 5
            };
            List.Add("Jimmy", jimmyTheGoblin);

            joshTheBoss = new Character()
            {
                Name = "Josh",
                Health = 200,
                Armour = 90,
                Weapon = Weapons.Axe,
                //Accuracy = 8
                
            };
            List.Add("Josh", joshTheBoss);

            sarahTheDestroyer = new Character()
            {
                Name = "Sarah",
                Health = 80,
                Armour = 20,
                Weapon = Weapons.Sword,
                //Accuracy = 7
            };
            List.Add("Sarah", sarahTheDestroyer);

            karenTheEntitled = new Character()
            {
                Name = "Karen",
                Health = 80,
                Armour = 35,
                Weapon = Weapons.Claw,
                //Accuracy = 8

            };
            List.Add("Karen", karenTheEntitled);
        }
    }
}

