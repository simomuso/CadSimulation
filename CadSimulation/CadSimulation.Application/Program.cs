﻿// See https://aka.ms/new-console-template for more information
using CadSimulation.Application.Models;
using CadSimulation.Application.Repositories;
using Newtonsoft.Json;


var arguments = ParseCommandLineArguments(args);

Console.WriteLine($"Running configuration: {JsonConvert.SerializeObject(arguments)}");

var shapesRepository = new ShapesRepositoryFactory().CreateShapesRepository(arguments.FilesystemPath, arguments.JsonFormatRequired);
var shapes = new List<IShape>();

while (true)
{
    Console.WriteLine(
"\nOptions:\n" +
"   's': insert a square\n" +
"   't': insert a triangle\n" +
"   'c': insert a circle\n" +
"   'r': insert a rectangle\n" +
"   'l': list all inserted shapes\n" +
"   'a': all shapres total area\n" +
"   'k': persist data on filesystem\n" +
"   'w': load data from filesystem\n" +
"   'q': quit");

    var k = Console.ReadKey(true);
    if (k.KeyChar == 'q')
        break;

    IShape? shape = null;
    switch (k.KeyChar)
    {
        case 'l':
            {
                shapes.ForEach(s =>
                {
                    s.descr();
                });
            }
            continue;
        case 's':
            {
                Console.WriteLine("Square. Value for side:\t");
                var side = Int32.Parse(Console.ReadLine()!);
                shape = new Square(side); // Console.WriteLine("Square");
            }
            break;
        case 'r':
            {
                Console.WriteLine("Rectangle.\nValue for height:\t");
                var height = Int32.Parse(Console.ReadLine()!);
                Console.WriteLine("value for width:\t");
                var witdh = Int32.Parse(Console.ReadLine()!);
                shape = new Rectangle(height, witdh); // Console.WriteLine("Rectangle");
            }
            break;
        case 't':
            {
                Console.WriteLine("Triangle.\nValue for height:\t");
                var height = Int32.Parse(Console.ReadLine()!);
                Console.WriteLine("value for base:\t");
                var tBase = Int32.Parse(Console.ReadLine()!);
                shape = new Triangle(tBase, height); // Console.WriteLine("Triangle");
            }
            break;
        case 'c':
            Console.WriteLine("Circle. Value for radius:\t");
            var radius = Int32.Parse(Console.ReadLine()!);
            shape = new Circle(radius); // Console.WriteLine("Circle");
            break;
        case 'a':
            {
                double area = 0;
                foreach (var s in shapes)
                    area += s.area();

                Console.WriteLine("Total area: {0}", area);
            }
            continue;
        case 'k':
            await shapesRepository.SaveAllAsync(shapes);
            continue;
        case 'w':
            shapes = (await shapesRepository.GetAllAsync()).ToList();
            continue;
    }
    shapes.Add(shape!);

}

static CommandLineArguments ParseCommandLineArguments(string[] args)
{
    var commandLineArguments = new CommandLineArguments();

    for (int i = 0; i < args.Length; i++)
    {
        switch (args[i])
        {
            case "--path":
                if (i + 1 < args.Length)
                    commandLineArguments.FilesystemPath = args[i + 1];
                continue;
            case "--json":
                commandLineArguments.JsonFormatRequired = true;
                continue;
        }
    }

    return commandLineArguments;
}