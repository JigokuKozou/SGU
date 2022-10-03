using System;
using System.Drawing;

namespace Flyweight
{
    public interface ICar
    {
        string Engine { get; }

        ConsoleColor Color { get; }

        void SetLocation(int x, int y);
    }

    public abstract class Car : ICar
    {
        public Car()
        {
            Console.WriteLine(ToString() + " создан в памяти");
        }

        public abstract string Engine { get; }

        public abstract ConsoleColor Color { get; }

        public virtual void SetLocation(int x, int y)
        {
            ConsoleColor previous = Console.ForegroundColor;

            Console.ForegroundColor = Color;
            Console.WriteLine($"{ToString()} назначена точка ({x}, {y})");
            Console.ForegroundColor = previous;
        }

        public override string ToString()
        {
            return $"[Двигатель: {Engine}]";
        }
    }

    public class FordMustang : Car
    {
        public override string Engine => "315 DOHC Voodoo V8 5.2 GT350";

        public override ConsoleColor Color => ConsoleColor.Red;

        public override string ToString()
        {
            return "Ford Mustang " + base.ToString();
        }
    }

    public class SkodaRapid : Car
    {
        public override string Engine => "1.6 л, 90 л.с., бензин";

        public override ConsoleColor Color => ConsoleColor.Blue;

        public override string ToString()
        {
            return "Skoda Rapid " + base.ToString();
        }
    }
}

