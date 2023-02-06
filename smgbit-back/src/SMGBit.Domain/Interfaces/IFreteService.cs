using SMGBit.Domain.Entities;

namespace SMGBit.Domain.Interfaces
{
    public interface IFreteService
    {
        public Task<IList<Travel>> ProcessTravelListToAddFreight(List<Travel> travelList);
    }
}
