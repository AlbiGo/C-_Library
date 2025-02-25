// See https://aka.ms/new-console-template for more information
using AuditEntry;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


var dbContext = new AuditDbContext();

await dbContext.Users.AddAsync(new User()
{
    Email = "someEmail",
    Name = "SomeName"
});

await dbContext.Users.AddAsync(new User()
{
    Email = "someEmail213",
    Name = "SomeNamadae"
});

await dbContext.Users.AddAsync(new User()
{
    Email = "someE213214mail",
    Name = "SomeNamdade"
});
await dbContext.SaveChangesAsync();

var users = dbContext.Users.ToList();

users.ForEach(x =>
{
    Console.WriteLine(x.Id + "  |   " + x.Email);
});

var user = await dbContext.Users
    .Where(p => p.Id == 1)
    .FirstOrDefaultAsync();

user.Email = "TestAudit";

dbContext.Users.Update(user);
await dbContext.SaveChangesAsync();

var auditEntry = dbContext.AuditEntryProperties
    .Include(p => p.AuditEntry)
    .ToList();
Console.WriteLine("Entity Name" + " |   " + "Property Name" + " |  Old Value " + "   |  " + "New Value" + "     |   Modified");
auditEntry.ForEach(p =>
{
    Console.WriteLine(p.AuditEntry.EntityName + "   |   " + p.PropertyName + "  |   " + p.PropertyOldValue + "  |   " + p.PropertyNewValue + "      |       " + p.Modified);
    Console.WriteLine("--------------------------------------------------------------------------------------------");
});

Console.ReadLine();

