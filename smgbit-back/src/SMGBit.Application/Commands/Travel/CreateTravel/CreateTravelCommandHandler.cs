using MediatR;
using SMGBit.Domain.Repositories;
using TravelEntity = SMGBit.Domain.Entities.Travel;

namespace SMGBit.Application.Commands.Travel.CreateTravel
{
    public class CreateTravelsCommandHandler : IRequestHandler<CreateTravelsCommand, IList<TravelEntity>>
    {
        private readonly ITravelRepository travelRepository;

        public CreateTravelsCommandHandler(ITravelRepository travelRepository)
        {
            this.travelRepository = travelRepository;
        }

        public async Task<IList<TravelEntity>> Handle(CreateTravelsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await travelRepository.SaveTravels(request.Items);
            }
            catch (Exception ex)
            {
                return request.Items;
            }

        }
    }
}
