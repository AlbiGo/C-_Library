// See https://aka.ms/new-console-template for more information
using AuditEntry;
using EntityFramework.Detach.Repository;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
var _repo = new BaseRepository<User>();

await _repo.Add(new User()
{
    Email = "someEmail",
    Name = "SomeName"
});

await _repo.Add(new User()
{
    Email = "someEmail213",
    Name = "SomeNamadae"
});

await _repo.Add(new User()
{
    Email = "someE213214mail",
    Name = "SomeNamdade"
});

var users = await _repo.CustomQuery()
    .ToListAsync();

users.ForEach(x =>
{
    Console.WriteLine(x.Id + "  |   " + x.Email);
});

Console.WriteLine("------------------------------------------------------------------------------");

var _user = await _repo.CustomQuery()
    .Where(p => p.Email == "someEmail")
    .FirstOrDefaultAsync();

_user.Email = "changedEmail";

_repo.Detach(_user);

await _repo.SaveChanges();

var users2 = await _repo.CustomQuery()
    .ToListAsync();

users2.ForEach(x =>
{
    Console.WriteLine(x.Id + "  |   " + x.Email);
});