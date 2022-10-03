using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Hero
    {
        private readonly string name;

        private IWeapon weapon;

        public Hero(string name) => this.name = name;

        public void Take(IWeapon weapon)
        {
            if (weapon is null)
                throw new ArgumentNullException(nameof(weapon));

            this.weapon = weapon;

            Console.WriteLine(name + " взял " + weapon.GetType().Name);
        }

        public void Attack()
        {
            if (weapon is null)
            {
                Console.WriteLine(name + " не может аттаковать. Необходимо оружие.");
                return;
            }

            Console.Write(name + " ");
            weapon.Attack();
        }
    }
}
