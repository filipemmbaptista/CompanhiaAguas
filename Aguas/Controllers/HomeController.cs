using Aguas.Data.Entities;
using Aguas.Helpers;
using Aguas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aguas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserHelper _userHelper;

        public HomeController(ILogger<HomeController> logger, IUserHelper userHelper)
        {
            _logger = logger;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Dashboard()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            DashboardViewModel dashboard = new DashboardViewModel();

            if (this.User.IsInRole("Admin"))
            {
                dashboard.AdminDashboard = new AdminDashboardViewModel();
                dashboard.AdminDashboard.Clients = new List<User>();
                dashboard.AdminDashboard.Workers = new List<User>();

                foreach (var user in await _userHelper.GetUsers())
                {
                    if (user.WorkerAproved && !user.AdminAproved && await _userHelper.IsUserInRoleAsync(user, "Client"))
                    {
                        dashboard.AdminDashboard.Clients.Add(user);
                    }
                    else if (await _userHelper.IsUserInRoleAsync(user, "Worker"))
                    {
                        dashboard.AdminDashboard.Workers.Add(user);
                    }
                }
            }
            else if (this.User.IsInRole("Worker"))
            {
                dashboard.WorkerDashboard = new WorkerDashboardViewModel();
                dashboard.WorkerDashboard.Clients = new List<User>();

                foreach (var user in await _userHelper.GetUsers())
                {
                    if (!user.WorkerAproved && await _userHelper.IsUserInRoleAsync(user, "Client"))
                    {
                        dashboard.WorkerDashboard.Clients.Add(user);
                    }
                }

            }
            else if (this.User.IsInRole("Client"))
            {

            }

            return View(dashboard);
        }
    }
}
