using Aguas.Data.Entities;

namespace Aguas.Data.Repositories
{
    public class MeterRepository : GenericRepository<Meter>, IMeterRepository
    {
        private readonly DataContext _context;

        public MeterRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
