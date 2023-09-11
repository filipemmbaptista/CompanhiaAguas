using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aguas.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Fiscal Number")]
        public int FiscalNumber { get; set; }

        [Display(Name = "Worker Aproved")]
        public bool WorkerAproved { get; set; }

        [Display(Name = "Admin Aproved")]
        public bool AdminAproved { get; set; }
    }
}
