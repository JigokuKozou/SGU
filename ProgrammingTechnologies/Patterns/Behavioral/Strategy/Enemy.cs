using System;

namespace Strategy
{
    public class Enemy
    {
        private readonly string name;

        private IWeapon weapon;

        public Enemy(string name)
        {
            this.name = name;

            weapon = NoWeapon.Instance;
        }

        public void Take(IWeapon weapon)
        {
            if (weapon is null)
                throw new ArgumentNullException(nameof(weapon));

            this.weapon = weapon;

            Console.WriteLine(name + " взял " + weapon.GetType().Name);
        }

        public void Attack()
        {
            Console.Write(name + " ");

            weapon.Attack();
        }
    }
}
