using MediatR;
using TravelEntity = SMGBit.Domain.Entities.Travel;

namespace SMGBit.Application.Queries.Travel.GetAllTravels
{
    public class GetAllTravelsQuery : IRequest<IList<TravelEntity>>
    {
    }
}
