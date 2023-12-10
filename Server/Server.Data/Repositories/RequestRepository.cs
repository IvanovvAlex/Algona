namespace Server.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Server.Data.Entities;
    using Server.Data.Interfaces.Repositories;

    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;
        public RequestRepository(AlgonaDbContext context) : base(context) { }
        public override async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await AlgonaDbContext
                .Requests
                .ToListAsync();
        }
        public override async ValueTask<Request?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .Requests
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public override async Task AddAsync(Request entity)
        {
            Request request = new Request()
            {
                Id = entity.Id,
                FromAddress = entity.FromAddress,
                ToAddress = entity.ToAddress,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                NumberOfPallets = entity.NumberOfPallets,
                TotalWeight = entity.TotalWeight,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
            };

            await Context.AddAsync(request);
            await Context.SaveChangesAsync();
        }
        public override async void Remove(Request entity)
        {
            AlgonaDbContext.Remove(entity);
            await AlgonaDbContext.SaveChangesAsync();
        }

    }
}
