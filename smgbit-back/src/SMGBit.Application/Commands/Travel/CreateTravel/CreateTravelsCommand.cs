using MediatR;
using TravelEntity = SMGBit.Domain.Entities.Travel;

namespace SMGBit.Application.Commands.Travel.CreateTravel
{
    public class CreateTravelsCommand : IRequest<IList<TravelEntity>>
    {
        public IList<TravelEntity> Items { get; set; }
    }
}
