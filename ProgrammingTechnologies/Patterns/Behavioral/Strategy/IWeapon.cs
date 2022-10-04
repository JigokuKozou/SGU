using System;

namespace Strategy
{
    public interface IWeapon
    {
        void Attack();
    }

    public class NoWeapon : IWeapon
    {
        protected static NoWeapon instance;

        protected NoWeapon() { }

        public static NoWeapon Instance = instance is null ? instance = new NoWeapon() : instance;

        public void Attack()
        {
            Console.WriteLine("не может аттаковать. Необходимо оружие.");
        }
    }

    public class Crowbar : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("ударил монтировкой");
        }
    }

    public class StunBaton : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("ударил электрошоковой дубинкой");
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
