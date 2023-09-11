using Aguas.Data.Entities;
using System.Collections.Generic;

namespace Aguas.Models
{
    public class DashboardViewModel
    {
        public AdminDashboardViewModel AdminDashboard { get; set; }

        public WorkerDashboardViewModel WorkerDashboard { get; set; }

        public ClientDashboardViewModel ClientDashboard { get; set; }
    }

    public class AdminDashboardViewModel
    {
        public List<User> Workers { get; set; }

        public List<User> Clients { get; set; }

        public User User { get; set; }
    }

    public class WorkerDashboardViewModel
    {
        public List<User> Clients { get; set; }

        public User User { get; set; }
    }

    public class ClientDashboardViewModel { }
}
