using Aguas.Data.Entities;
using Aguas.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aguas.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.ContractTypes.Any())
            {
                AddContractType("Private");
                AddContractType("Enterprise");
            }
        }

        private void AddContractType(string ctype)
        {
            _context.ContractTypes.Add(new ContractType
            {
                Type = ctype,
            });
        }
    }
}
