using System;

namespace Strategy
{
    public interface IWeapon
    {
        void Attack();
    }

    public class Crowbar : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("ударил монтировкой");
        }
    }

    public class Pistol : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("выстрелил из пистолета");
        }
    }
}
