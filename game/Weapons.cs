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
        public static Dictionary<string, Weapon> WeaponList = new Dictionary<string, Weapon>();

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
            WeaponList.Add(Fist.Name, Fist);

            Claw = new Weapon()
            {
                Name = "Claw",
                Damage = 15,
                Accuracy = 9
            };
            WeaponList.Add(Claw.Name, Claw);

            Sword = new Weapon()
            {
                Name = "Sword",
                Damage = 30,
                Accuracy = 8
            };
            WeaponList.Add(Sword.Name, Sword);

            Axe = new Weapon()
            {
                Name = "Axe",
                Damage = 50,
                Accuracy = 6
            };
            WeaponList.Add(Axe.Name, Axe);
        }
    }
}
