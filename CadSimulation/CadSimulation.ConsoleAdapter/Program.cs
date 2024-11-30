﻿using CadSimulation.Application;
using CadSimulation.Application.Services;
using CadSimulation.Core;
using CadSimulation.Core.Models;
using Newtonsoft.Json;

var options = ParseCommandLineArguments(args);

Console.WriteLine($"Running configuration: {JsonConvert.SerializeObject(options)}");

var mapperFactory = new ShapeMapperFactory();
var repositoryFactory = new ShapeRepositoryFactory(mapperFactory);
var repository = new PersistenceService(options, repositoryFactory);

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
                shape = new Square(side);
            }
            break;
        case 'r':
            {
                Console.WriteLine("Rectangle.\nValue for height:\t");
                var height = Int32.Parse(Console.ReadLine()!);
                Console.WriteLine("value for width:\t");
                var witdh = Int32.Parse(Console.ReadLine()!);
                shape = new Rectangle(height, witdh);
            }
            break;
        case 't':
            {
                Console.WriteLine("Triangle.\nValue for height:\t");
                var height = Int32.Parse(Console.ReadLine()!);
                Console.WriteLine("value for base:\t");
                var tBase = Int32.Parse(Console.ReadLine()!);
                shape = new Triangle(tBase, height);
            }
            break;
        case 'c':
            Console.WriteLine("Circle. Value for radius:\t");
            var radius = Int32.Parse(Console.ReadLine()!);
            shape = new Circle(radius);
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
            await repository.WriteAsync(shapes);
            continue;
        case 'w':
            shapes = (await repository.ReadAsync()).ToList();
            continue;
    }
    shapes.Add(shape!);

}

static PersistenceServiceOptions ParseCommandLineArguments(string[] args)
{
    var commandLineArguments = new PersistenceServiceOptions();

    for (int i = 0; i < args.Length; i++)
    {
        switch (args[i])
        {
            case "--path":
                if (i + 1 < args.Length)
                    commandLineArguments.FilesystemPath = args[i + 1];
                continue;
            case "--json":
                commandLineArguments.UseJsonFormat = true;
                continue;
            case "--uri":
                if (i + 1 < args.Length)
                    commandLineArguments.ServiceUri = new Uri(args[i + 1]);
                continue;
        }
    }

    return commandLineArguments;
}