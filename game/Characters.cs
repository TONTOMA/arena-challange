using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Character
    {
        public string Name { set; get; }
        public int Health { set; get; }
        public Weapon Weapon { set; get; }
        //public int Accuracy { set; get; }
    }

    public class Player : Character
    {

    }

    public class Enemy : Character
    {

    }

    public static class Enemies
    {
        public static Dictionary<string, Enemy> EnemyList = new Dictionary<string, Enemy>();

        private static Enemy jimmyTheGoblin;
        private static Enemy joshTheBoss;
        private static Enemy sarahTheDestroyer;
        private static Enemy karenTheEntitled;

        static Enemies()
        {    
            
            jimmyTheGoblin = new Enemy()
            {
                Name = "Jimmy",
                Health = 60,
                Weapon = Weapons.Claw,
                //Accuracy = 5
            };
            EnemyList.Add("Jimmy", jimmyTheGoblin);

            joshTheBoss = new Enemy()
            {
                Name = "Josh",
                Health = 200,
                Weapon = Weapons.Axe,
                //Accuracy = 8
                
            };
            EnemyList.Add("Josh", joshTheBoss);

            sarahTheDestroyer = new Enemy()
            {
                Name = "Sarah",
                Health = 80,
                Weapon = Weapons.Sword,
                //Accuracy = 7
            };
            EnemyList.Add("Sarah", sarahTheDestroyer);

            karenTheEntitled = new Enemy()
            {
                Name = "Karen",
                Health = 80,
                Weapon = Weapons.Claw,
                //Accuracy = 8

            };
            EnemyList.Add("Karen", karenTheEntitled);
        }
    }
}

