using SMGBit.Domain.Entities;

namespace SMGBit.Domain.Repositories
{
    public interface ITravelRepository
    {
        Task<IList<Travel>> GetAllTravelsAsync();
        Task<IList<Travel>> SaveTravels(IList<Travel> travels);
    }
}
