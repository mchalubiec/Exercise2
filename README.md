# Exercise2
## Wskaż błędy w kodzie
class Program
    {
        enum colors
        {
            Red,
            Blue,
            Pink,
            Yellow,
            Black
        }
        public class Car
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }
            public colors Color { get; private set; }
            public int Speed { get; private set; } = 0;

            public void SpeedUp()
            {
                this.Speed += Random().Next(5, 20);
            }

            public void SlowDown()
            {
                this.Speed -= Random().Next(5, 20);
                if (this.Speed < 0)
                {
                    Console.WriteLine("{this.Name} has stopped.");
                }
            }
        }
        static void Main(string[] args)
        {
            new List<Car> cars;
            cars.Add(new Car()
            {
                Id = Guid.NewGuid()
                Name = "Crashy"
                Color = colors.Red
            });

            cars.Add(new Car()
            {
                Id = Guid.NewGuid()
                Name = "Trashy"
                Color = colors.Blue
            });

            cars.Add(new Car()
            {
                Id = Guid.NewGuid()
                Name = "Rushy"
                Color = colors.Black
            });

            while (!cars.Any(c => c.Speed >= 200))
            {
                foreach(Car car in cars)
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
