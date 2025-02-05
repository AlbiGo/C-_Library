// See https://aka.ms/new-console-template for more information
using DataManagement.DbContext;
using DataManagement.Entities;
using DataManagement.Repositories.Implementations;
using DataManagement.Repositories.Interfaces;
using System.Data;

Console.WriteLine("Database initialization");
var dbContext = new DatabaseContext();
IBaseRepository<Entity1> baseRepository = new BaseRepository<Entity1>();
IBaseRepository<Entity2> baseRepository2 = new BaseRepository<Entity2>();
IBaseRepository<Entity3> baseRepository3 = new BaseRepository<Entity3>();
IBaseRepository<Entity4> baseRepository4 = new BaseRepository<Entity4>();

await baseRepository2.Add(new Entity2() { Id = 6, Created = DateTime.Now, Desc = "Test" });

await baseRepository.Add(new Entity1() { Id = 1, Created = DateTime.Now, Name = "Test", Entity2ID = 6 });

await baseRepository3.Add(new Entity3() { Id = 1, Entity1ID = 1 });
await baseRepository3.Add(new Entity3() { Id = 2, Entity1ID = 1 });

await baseRepository4.Add(new Entity4() { Id = 1, Entity1ID = 1 });
await baseRepository4.Add(new Entity4() { Id = 2, Entity1ID = 1 });

Console.WriteLine("Before soft deletion");
PrintDB(dbContext);

Console.WriteLine("-----------------------------------------------------------------------------");
var itemToRemove = baseRepository.CustomQueryNT()
    .Where(p => p.Id == 1)
    .FirstOrDefault();

await baseRepository.SoftRemoveRelated(itemToRemove, new string[] { "Entity2", "Entity3s", "Entity4s" });

Console.WriteLine("After soft deletion");
PrintDB(dbContext);
Console.ReadLine();

void PrintDB(DatabaseContext databaseContext)
{
    IBaseRepository<Entity1> baseRepository = new BaseRepository<Entity1>();
    IBaseRepository<Entity2> baseRepository2 = new BaseRepository<Entity2>();
    IBaseRepository<Entity3> baseRepository3 = new BaseRepository<Entity3>();
    IBaseRepository<Entity4> baseRepository4 = new BaseRepository<Entity4>();

    var removedItem = baseRepository.CustomQueryNT()
        .FirstOrDefault();

    var relatedItem = baseRepository2.CustomQueryNT()
        .FirstOrDefault();

    var relatedItems = baseRepository3.CustomQueryNT()
        .ToList();

    var relatedItems2 = baseRepository4.CustomQueryNT()
        .ToList();

    Console.WriteLine($"Entity 1 Deleted : {removedItem.Deleted}");
    Console.WriteLine($"Entity 2 Deleted : {relatedItem.Deleted}");

    relatedItems.ForEach(p =>
    {
        Console.WriteLine($"Entity 3 Deleted : {p.Deleted}");
    });

    relatedItems2.ForEach(p =>
    {
        Console.WriteLine($"Entity 4 Deleted : {p.Deleted}");
    });
}