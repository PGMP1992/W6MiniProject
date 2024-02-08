using System;

public class Class1
{
    public Class1()
    {

        /*
        *LINQ(Language Integrated Query) in C#
        *LINQ is a uniform query language, introduced with .NET 3.5 that we can use to retrieve data from different data sources.
        *These data sources include the collection of objects, relational databases, ADO.NET datasets, XML files, etc.
        *Aggregate functions such as Count, Average, Min, Max, Sum,
        *Where, OrderBy(), OrderByDescending()

        *Think in terms of the loops – you don’t need a loop with LINQ. LINQ looping for you
        *Lambda expression  "=>"

    /*
    List<int> number = new List<int>() { 5, 4, 7, 1, 0 };
    int max = number[0];

    foreach (int i in number)
    {
        if (i > max)
        { max = i; }
    }

    Console.WriteLine("Max Number:" + max);
    */

        Console.WriteLine("Cars!!!");
        List<Car> list_cars = new List<Car>();

        Car car1 = new Car("Volvo", "V90", 2023, 230);
        list_cars.Add(car1);

        list_cars.Add(new Car("SAAB", "9000T", 1983, 200));

        List<Car> extraCars = new List<Car>
        {
            new Car("Opel", "Vectra", 1984, 190),
            new Car("Volvo", "V40", 2020, 220)
        };

        list_cars.AddRange(extraCars);

        list_cars.AddRange(new List<Car>
        {
            new Car("Ford", "Fiesta", 2000, 180),
            new Car("Fiat", "Tempo", 2010, 190)}
        );

        // LINQ Methods
        
        int highestSpeed = list_cars.Max(p => p.Speed);
        double averageSpeed = list_cars.Average(p => p.Speed);
        int sumOfTheSpeed = list_cars.Sum(p => p.Speed);
        int countCars = list_cars.Count();

        // How many Volvo
        
        int countVolvo = list_cars.Where(p => p.Brand.Contains("Volvo")).Count();
                
        Console.WriteLine("My Cars - Unsorted");
        Console.WriteLine("Brand".PadRight(10) + "Model".PadRight(10) +
                          "Year".PadRight(10) + "Speed");
        foreach (Car p in list_cars)
        {
            Console.WriteLine(p.Brand.PadRight(10) + p.Model.PadRight(10) +
                              p.Year.ToString().PadRight(10) + p.Speed);
        }
        Console.WriteLine("------------------");
        
        // Sorted by Volvo 
        Console.WriteLine("My Cars Sorted on Brand");
        List<Car> sortedCars = list_cars.OrderBy(p => p.Brand).ToList();


        Console.WriteLine("Brand".PadRight(10) + "Model".PadRight(10) +
                          "Year".PadRight(10) + "Speed");
        foreach (Car p in sortedCars)
        {
            Console.WriteLine(p.Brand.PadRight(10) + p.Model.PadRight(10) +
                              p.Year.ToString().PadRight(10) + p.Speed);
        }
        
        Console.WriteLine("------------------");
        
        
        // Sorted by year 
        
        Console.WriteLine("My Cars - Filtering Cars from 1980-1990");

        List<Car> filteredCars = list_cars.Where(p => p.Year >= 1980 && p.Year <= 1990).ToList();

        Console.WriteLine("Brand".PadRight(10) + "Model".PadRight(10) +
                          "Year".PadRight(10) + "Speed");
        foreach (Car p in filteredCars)
        {
            Console.WriteLine(p.Brand.PadRight(10) + p.Model.PadRight(10) +
                              p.Year.ToString().PadRight(10) + p.Speed);
        }



        Console.ReadLine();
    }

class Car
{
    public Car(string brand, string model, int year, int speed)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Speed = speed;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Speed { get; set; }
}


}
