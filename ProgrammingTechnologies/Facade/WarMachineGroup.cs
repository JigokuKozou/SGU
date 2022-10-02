using System.Collections.Generic;

namespace Facade
{
    public class WarMachineGroup
    {
        public WarMachineGroup()
        {
            machines = new List<WarMachine>();
        }

        protected List<WarMachine> machines;

        public bool Add(WarMachine machine)
        {
            bool isNotContain = !machines.Contains(machine);

            if (isNotContain)
            {
                machines.Add(machine);
            }

            return isNotContain;
        }

        public void Attack()
        {
            int countHelicopters = 0;
            int countCars = 0;

            foreach (var machine in machines)
            {
                if (machine is Havoc)
                {
                    countHelicopters++;
                }
                else if (machine is Tigr)
                {
                    countCars++;
                }
            }

            if (countHelicopters < countCars / 2.0)
            {
                CarsAttack();
                HelicoptersAttack();
            }
            else
            {
                HelicoptersAttack();
                CarsAttack();
            }

            void CarsAttack()
            {
                foreach (var machine in machines)
                {
                    if (machine is Tigr)
                    {
                        machine.Attack();
                    }
                }
            }

            void HelicoptersAttack()
            {
                foreach (var machine in machines)
                {
                    if (machine is Havoc)
                    {
                        machine.Attack();
                    }
                }
            }
        }
    }
}
