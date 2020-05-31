using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Exercise2
{
    class Program
    {
        public enum colors
        {
            Red,
            Blue,
            Pink,
            Yellow,
            Black
        }
        public class Car
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public colors Color { get; set; }
            public int Speed { get; private set; } = 0;

            public static Random random;
            public void InitRandom()
            {
                if (random == null)
                {
                    random = new Random();
                }
            }

            public void SpeedUp()
            {
                InitRandom();
                this.Speed += random.Next(5, 20);
            }

            public void SlowDown()
            {
                InitRandom();
                this.Speed -= random.Next(5, 20);
                if (this.Speed < 0)
                {
                    Console.WriteLine($"{this.Name} has stopped.");
                }
            }
        }
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car()
            {
                Id = Guid.NewGuid(),
                Name = "Crashy",
                Color = colors.Red
            });

            cars.Add(new Car()
            {
                Id = Guid.NewGuid(),
                Name = "Trashy",
                Color = colors.Blue
            });

            cars.Add(new Car()
            {
                Id = Guid.NewGuid(),
                Name = "Rushy",
                Color = colors.Black
            });

            while (!cars.Any(c => c.Speed >= 200))
            {
                foreach (Car car in cars)
                {
                    car.SpeedUp();
                    Console.WriteLine($"{car.Name} is speeding up! current speed {car.Speed}!");
                }
                Thread.Sleep(100);
            }
            while (!cars.Any(c => c.Speed <= 0))
            {
                foreach (Car car in cars)
                {
                    car.SlowDown();
                    Console.WriteLine($"{car.Name} is slowing down! current speed {car.Speed}!");
                }
                Thread.Sleep(100);
            }
            Console.WriteLine("{0} {1} has stopped first.", cars.Single(c => c.Speed <= 0).Color, cars.Single(c => c.Speed <= 0).Name);
            Console.ReadKey();
        }
    }
}
