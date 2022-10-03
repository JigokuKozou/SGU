using System;

namespace Facade
{
    public abstract class WarMachine
    {
        public string Name { get; protected set; } = "Военная машина";

        virtual public void Move()
        {
            Console.WriteLine(Name + " движется...");
        }

        virtual public void Attack()
        {
            Console.WriteLine(Name + " атакует...");
        }
    }

    public class Tigr : WarMachine
    {
        public Tigr()
        {
            Name = "Военная машина Тигр";
        }

        public override void Move()
        {
            Console.WriteLine(Name + " едет...");
        }

        public override void Attack()
        {
            Console.WriteLine(Name + " стреляет из лёгкого пулемёта на крыше...");
        }
    }
    
    public class Havoc : WarMachine
    {
        public Havoc()
        {
            Name = "Военный вертолёт Ми-28Н";
        }

        public override void Move()
        {
            Console.WriteLine(Name + " летит...");
        }

        public override void Attack()
        {
            Console.WriteLine(Name + " стреляет из тяжёлого пулемёта на крыльях...");
        }
    }
}
