using Aguas.Data.Entities;

namespace Aguas.Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientReporitory
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
