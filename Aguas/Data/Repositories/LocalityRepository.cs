using Aguas.Data.Entities;

namespace Aguas.Data.Repositories
{
    public class LocalityRepository : GenericRepository<Locality>, ILocalityRepository
    {
        private readonly DataContext _context;

        public LocalityRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
