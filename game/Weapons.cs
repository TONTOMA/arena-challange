using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Accuracy { get; set; }
    }

    public static class Weapons
    {
        public static Dictionary<string, Weapon> List = new Dictionary<string, Weapon>();

        public static Weapon Fist { get; set; }
        public static Weapon Sword { get; set; }
        public static Weapon Axe { get; set; }
        public static Weapon Claw { get; set; }

        static Weapons()
        {
            Fist = new Weapon()
            {
                Name = "Fist",
                Damage = 10,
                Accuracy = 11
            };
            List.Add(Fist.Name, Fist);

            Claw = new Weapon()
            {
                Name = "Claw",
                Damage = 15,
                Accuracy = 9
            };
            List.Add(Claw.Name, Claw);

            Sword = new Weapon()
            {
                Name = "Sword",
                Damage = 30,
                Accuracy = 8
            };
            List.Add(Sword.Name, Sword);

            Axe = new Weapon()
            {
                Name = "Axe",
                Damage = 50,
                Accuracy = 6
            };
            List.Add(Axe.Name, Axe);
        }
    }
}
