using Bogus;
using PoC.Paginacao.Models;
using System.Linq;

namespace PoC.Paginacao.Context
{
    public class SeedUsers
    {
        private readonly PoCContext _context;

        public SeedUsers(PoCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Users.Any())
                return;

            var userFaker = new Faker<User>()
                            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                            .RuleFor(u => u.LastName, f => f.Person.LastName)
                            .RuleFor(u => u.DateOfBirth, f => f.Person.DateOfBirth)
                            .RuleFor(u => u.Email, f => f.Person.Email.ToLower())
                            .RuleFor(u => u.Username, f => f.Person.UserName.ToLower());
            var users = userFaker.Generate(100000);

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
    }
}
