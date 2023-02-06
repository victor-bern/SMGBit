using MediatR;
using SMGBit.Domain.Repositories;
using TravelEntity = SMGBit.Domain.Entities.Travel;
namespace SMGBit.Application.Queries.Travel.GetAllTravels
{
    public class GetAllTravelsQueryHandler : IRequestHandler<GetAllTravelsQuery, IList<TravelEntity>>
    {
        private readonly ITravelRepository travelRepository;

        public GetAllTravelsQueryHandler(ITravelRepository travelRepository)
        {
            this.travelRepository = travelRepository;
        }

        public async Task<IList<TravelEntity>> Handle(GetAllTravelsQuery request, CancellationToken cancellationToken)
        {
            return await travelRepository.GetAllTravelsAsync();
        }
    }
}
