using Aguas.Data.Entities;
using Aguas.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aguas.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Worker");
            await _userHelper.CheckRoleAsync("Client");

            var adminDefault = await _userHelper.GetUserByEmailAsync("defaultadmin@gmail.com");
            if (adminDefault == null)
            {
                adminDefault = AddUser("Default", "Admin", "defaultadmin@gmail.com", 000000000, "123456789");

                var result = await _userHelper.AddUserAsync(adminDefault, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(adminDefault, "Admin");
            }
            var adminIsInRole = await _userHelper.IsUserInRoleAsync(adminDefault, "Admin");
            if (!adminIsInRole)
            {
                await _userHelper.AddUserToRoleAsync(adminDefault, "Admin");
            }


            var workerDefault = await _userHelper.GetUserByEmailAsync("defaultworker@gmail.com");
            if (workerDefault == null)
            {
                workerDefault = AddUser("Default", "Worker", "defaultworker@gmail.com", 111111111, "123456789");

                var result = await _userHelper.AddUserAsync(workerDefault, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await _userHelper.AddUserToRoleAsync(workerDefault, "Worker");
            }
            var workerIsInRole = await _userHelper.IsUserInRoleAsync(workerDefault, "Worker");
            if (!workerIsInRole)
            {
                await _userHelper.AddUserToRoleAsync(workerDefault, "Worker");
            }

            if (!_context.ContractTypes.Any())
            {
                AddContractType("Private");
                AddContractType("Enterprise");
                await _context.SaveChangesAsync();
            }
        }

        public User AddUser(string fn, string ln, string email, int fiscal, string phone)
        {
            var user = new User
            {
                FirstName = fn,
                LastName = ln,
                Email = email,
                UserName = email,
                FiscalNumber = fiscal,
                PhoneNumber = phone,
                WorkerAproved = true,
                AdminAproved = true,
            };

            return user;
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
