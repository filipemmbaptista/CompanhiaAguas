using Aguas.Data.Entities;

namespace Aguas.Data.Repositories
{
    public class ContractRepository : GenericRepository<Contract>, IContractRepository
    {
        private readonly DataContext _context;

        public ContractRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
