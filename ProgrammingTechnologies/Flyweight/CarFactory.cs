using System;
using System.Collections.Generic;

namespace Flyweight
{
    public enum CarType
    {
        FordMustang,
        SkodaRapid,
    }

    public class CarFactory
    {
        private readonly IDictionary<CarType, ICar> cars = new Dictionary<CarType, ICar>();

        public ICar GetCar(CarType type)
        {
            if (cars.ContainsKey(type)) return cars[type];

            ICar car = CreateCar(type);
            cars.Add(type, car);

            return car;
        }

        private ICar CreateCar(CarType type)
        {
            ICar car;

            switch (type)
            {
                case CarType.FordMustang:
                    car = new FordMustang(); break;
                case CarType.SkodaRapid:
                    car = new SkodaRapid(); break;
                default:
                    throw new ArgumentException("Invalid choise");
            }

            return car;
        }
    }
}
