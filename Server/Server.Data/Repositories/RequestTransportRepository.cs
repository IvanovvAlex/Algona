namespace Server.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Server.Data.Entities;
    using Server.Data.Interfaces.Repositories;

    public class RequestTransportRepository : Repository<RequestTransport>, IRequestTransportRepository
    {
        private AlgonaDbContext AlgonaDbContext => (Context as AlgonaDbContext)!;
        public RequestTransportRepository(AlgonaDbContext context) : base(context) { }
        public override async Task<IEnumerable<RequestTransport>> GetAllAsync()
        {
            return await AlgonaDbContext
                .RequestTransport
                .ToListAsync();
        }
        public override async ValueTask<RequestTransport?> GetByIdAsync(string id)
        {
            return await AlgonaDbContext
                .RequestTransport
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public override async Task AddAsync(RequestTransport entity)
        {
            RequestTransport request = new RequestTransport()
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
        public override async void Remove(RequestTransport entity)
        {
            AlgonaDbContext.Remove(entity);
            await AlgonaDbContext.SaveChangesAsync();
        }

    }
}
