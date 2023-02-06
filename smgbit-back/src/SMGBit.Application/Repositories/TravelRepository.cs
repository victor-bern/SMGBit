using Microsoft.EntityFrameworkCore;
using SMGBit.Domain.Entities;
using SMGBit.Domain.Repositories;
using SMGBit.Infra.Context;

namespace SMGBit.Application.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ApplicationContext _context;

        public TravelRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<IList<Travel>> GetAllTravelsAsync() => await _context.Travels.AsNoTracking().ToListAsync();

        public virtual async Task<IList<Travel>> SaveTravels(IList<Travel> travels)
        {
            await _context.Travels.AddRangeAsync(travels);
            await _context.SaveChangesAsync();
            return travels;
        }
    }
}
