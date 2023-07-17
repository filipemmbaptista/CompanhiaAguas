using Microsoft.AspNetCore.Identity;

namespace Aguas.Data.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        public enum AccountStatus
        {
            Pending,
            Terminated,
            Approved
        };

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FiscalNumber { get; set; }

        public int ContactNumber { get; set; }

        public string ContactEmail { get; set; }

        public string ProfilePicUrl { get; set; }

        public AccountStatus Status { get; set; }

        public string ProfilePicFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ProfilePicUrl))
                {
                    return null;
                }

                return $"https://localhost:44316/{ProfilePicUrl.Substring(1)}";
            }
        }
    }
}
