using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak03
{
    class Zad03
    {
        static void Main(string[] args)
        {
            Engine Engine1 = new Engine()
            {
                Model = "1NZ-FXE I4",
                DistanceTraveled = 69000,
                EnergyPerKM = 70,
                LastChecked = new DateTime(2016, 4, 20),
                Power = 54
            };

            Engine Engine2 = new Engine()
            {
                Model = "R90",
                DistanceTraveled = 420,
                EnergyPerKM = 50,
                LastChecked = new DateTime(2012, 9, 6),
                Power = 68
            };

            Battery Battery1 = new Battery("1.31kWh nickel metal hydride", 1000, 1310, 5);
            Battery Battery2 = new Battery("24kWh lithium ion battery", 2400, 24000, 2);

            Car Car1 = new Car("Toyota Prius", Engine1, Battery1);
            Car Car2 = new Car("Renault Zoe", Engine2, Battery2);

            Console.WriteLine("Energija baterije prije voznje: " + Car2.Battery.StoredEnergy);
            Car2.Drive(35);
            Console.WriteLine("Energija baterije poslije voznje: " + Car2.Battery.StoredEnergy);
        }

        class Battery
        {
            public string Model;
            public double StoredEnergy;
            public double MaximumStoredEnergy;

            public Battery(string model, double storedEnergy, double maximumStoredEnergy, double pricePerWh)
            {
                Model = model;
                StoredEnergy = storedEnergy;
                MaximumStoredEnergy = maximumStoredEnergy;
            }

            public void SpendEnergy(double ammount)
            {
                StoredEnergy -= ammount;
                if (StoredEnergy < 0) 
                {
                    StoredEnergy = 0;
                }
            }

            public void Recharge(double ammount)
            {
                StoredEnergy += ammount;
                if (StoredEnergy > MaximumStoredEnergy)
                {
                    StoredEnergy = MaximumStoredEnergy;
                }
            }

        }

        class Engine
        {
            public string Model;
            public double DistanceTraveled;
            public double EnergyPerKM;
            public DateTime LastChecked;
            public double Power;

            public double Run(double distance)
            {
                DistanceTraveled += distance;
                return distance * EnergyPerKM;
            }

            public bool NeedsRepair()
            {
                if (DistanceTraveled >= 10000 || (DateTime.Now- LastChecked).Days >= 5*365+2)//+2 je za prijestupne godine, 2012 i 2016 u ovom slucaju
                {
                    return true;
                }
                return false;
            }
        }

        enum CarModels { Regular, Super, Extra, Xenon }//Intel bi bio ponosan na zadnji model

        class Car
        {
            public string Name;
            public CarModels Model;
            public Engine Engine;
            public Battery Battery;

            public Car(string name, Engine engine, Battery battery)
            {
                Name = name;
                Engine = engine;
                Battery = battery;

                if (engine.Power < 150)
                {
                    Model = CarModels.Regular;
                }
                else if (engine.Power >= 150 && engine.Power < 200)
                {
                    Model = CarModels.Super;
                }
                else if (engine.Power >= 200 && engine.Power < 300)
                {
                    Model = CarModels.Extra;
                }
                else if (engine.Power >= 300)
                {
                    Model = CarModels.Xenon;
                }
            }
            public void Drive(double distance)
            {
                Battery.SpendEnergy(Engine.Run(distance));
            }
        }
    }
}
