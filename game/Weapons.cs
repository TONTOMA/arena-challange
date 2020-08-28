using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
    }

    static class Weapons
    {
        public static Weapon Fist { get; set; }
        public static Weapon Sword { get; set; }
        public static Weapon Axe { get; set; }
        public static Weapon Claw { get; set; }

        static Weapons()
        {
            Fist = new Weapon()
            {
                Name = "Fist",
                Damage = 10
            };

            Claw = new Weapon()
            {
                Name = "Claw",
                Damage = 15
            };

            Sword = new Weapon()
            {
                Name = "Sword",
                Damage = 30
            };

            Axe = new Weapon()
            {
                Name = "Axe",
                Damage = 50
            };
        }
    }
}
