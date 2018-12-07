using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_homework09
{

    class Car
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public Color Color { get; set; }

        public override string ToString()
        {
            return $"Mark: {Mark}\tModel: {Model}\tColor: {Color.ToString()}\tPrice: ${Price}";
        }
    }
    /// <summary>
    /// Main programm class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car() { Mark = "Audi", Color = Color.Red, Model = "A6", Price = 15_000m },
                new Car() { Mark = "Toyota", Color = Color.Black, Model = "Camry", Price = 14_000m },
                new Car() { Mark = "BMW", Color = Color.Blue, Model = "325ci", Price = 20_000m },
                new Car() { Mark = "Mercedes-Benz", Color = Color.White, Model = "S600", Price = 35_000m },
                new Car() { Mark = "Mazda", Color = Color.Red, Model = "3", Price = 8_000m },
                new Car() { Mark = "Nissan", Color = Color.Blue, Model = "Almera", Price = 11_000m },
                new Car() { Mark = "Daewoo", Color = Color.Green, Model = "Nubira", Price = 4_000m },
                new Car() { Mark = "Toyota", Color = Color.Black, Model = "Avensis", Price = 14_000m }
            };
            Console.WriteLine("\n1. Cars with price more then 10K");
            CarsPriceMore10k(cars).ForEach(c => Console.WriteLine(c));

            Console.WriteLine("\n2. Cars with red color");
            CarsRed(cars).ForEach(c => Console.WriteLine(c));

            Console.WriteLine("\n3. Cars with price 14K and mark Toyota");
            CarsPriceMark(cars,(14_000m,"Toyota")).ForEach(c => Console.WriteLine(c));

            Console.WriteLine($"\n4. Cars total sum:  ${CarsTotalSum(cars)}");

            Console.WriteLine($"\n5. Red Cars quantity:  {CarsRedQty(cars)}");

            Console.WriteLine($"\n6. Cheapest cars:");
            var col = from c in CarsCheap(cars) select new { c.Mark, c.Model };
            foreach (var item in col)
                Console.WriteLine($"Mark: {item.Mark} Model: {item.Model}");

            Console.WriteLine($"\n7. Cars by price range and red, black count:");
            var res = CarsPriceRange(cars, (9_000m, 40_000m));
            res.cars.ForEach(c => Console.WriteLine(c));
            Console.WriteLine($"Counts Red: {res.CountRed} Black: {res.CountBlack}");
            
            Console.WriteLine("\nAny key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Return cars with price more than 10K
        /// </summary>
        /// <param name="cars">
        /// Car collection List(Cars)
        /// </param>
        /// <returns>Returns List(Car)</returns>
        public static List<Car> CarsPriceMore10k(List<Car> cars) => cars.Where(c => c.Price > 10_000m).ToList();

        /// <summary>
        /// Return cars with red color
        /// </summary>
        /// <param name="cars">
        /// Car collection List(Cars)
        /// </param>
        /// <returns>Returns List(Car)</returns>
        public static List<Car> CarsRed(List<Car> cars) =>  cars.Where(c => c.Color == Color.Red).ToList();

        /// <summary>
        /// Return cars by price and mark
        /// </summary>
        /// <param name="cars">
        /// Car collection List(Cars)
        /// </param>
        /// <param name="filter">
        /// tuple (decimal price, string mark)
        /// </param>
        /// <returns>Returns List(Car)</returns>
        public static List<Car> CarsPriceMark(List<Car> cars , (decimal price, string mark) filter)
        {
            return cars.Where(c => c.Price == filter.price).Where(c => c.Mark == filter.mark).ToList();
        }

        /// <summary>
        /// Return red cars quantity
        /// </summary>
        /// <param name="cars">
        /// Car collection List(Cars)
        /// </param>
        /// <returns>Returns int</returns>
        public static decimal CarsTotalSum(List<Car> cars) => cars.Sum(c => c.Price);

        /// <summary>
        /// Return cars total sum
        /// </summary>
        /// <param name="cars">
        /// Car collection List(Cars)
        /// </param>
        /// <returns>Returns decimal</returns>
        public static int CarsRedQty(List<Car> cars) => cars.Count(c => c.Color == Color.Red);

        /// <summary>
        /// Return cheapest cars
        /// </summary>
        /// <param name="cars">
        /// Car collection List(Cars)
        /// </param>
        /// <returns>Returns List(Car)</returns>
        public static List<Car> CarsCheap(List<Car> cars) => cars.Where(c => c.Price < 5_000m).ToList();

        /// <summary>
        /// Return cars by price range
        /// </summary>
        /// <param name="cars">
        /// Car collection List(Cars)
        /// </param>
        /// <param name="filter"> tuple (decimal price from, decimal price to) </param>
        /// <returns> Returns tuple (List(Car), int CountRed, int CountBlack) </returns>
        public static (List<Car> cars, int CountRed, int CountBlack) CarsPriceRange(List<Car> cars, (decimal from, decimal to) filter)
        {
            List<Car> cl = cars.Where(c => c.Price >= filter.from && c.Price <= filter.to).ToList();
            return (cl, cl.Count(c => c.Color == Color.Red), cl.Count(c => c.Color == Color.Black));
        }
    }
}
