// See https://aka.ms/new-console-template for more information
using ConsoleAppPostgreORM_Demo.Models;

Console.WriteLine("Hello, World!");

var dbContext = new dvdrentalContext();

foreach (var item in dbContext.Categories)
{
    Console.WriteLine($"{item.Name}");
}