using System.Collections.Generic;

namespace Aguas.Data.Entities
{
    public class Client : User
    {
        public int ClientId { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
