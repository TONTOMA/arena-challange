using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    class Character
    {
        public string Name { set; get; }
        public int Health { set; get; }
        public Weapon Weapon { set; get; }
        public int Accuracy { set; get; }
    }

    class Player : Character
    {

    }

    class Enemy : Character
    {

    }

    static class Enemies
    {
        public static Enemy JimmyTheGoblin { get; set; }
        public static Enemy JoshTheBoss { get; set; }

        static Enemies()
        {
            // Make into list of 
            JimmyTheGoblin = new Enemy()
            {
                Name = "Jimmy",
                Health = 60,
                Weapon = Weapons.Claw,
                Accuracy = 5
            };

            JoshTheBoss = new Enemy()
            {
                Name = "Josh",
                Health = 200,
                Weapon = Weapons.Axe,
                Accuracy = 8
            };
        }
    }
}

