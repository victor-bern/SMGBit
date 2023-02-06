using Microsoft.AspNetCore.Http;
using SMGBit.Domain.Entities;

namespace SMGBit.Domain.Interfaces
{
    public interface IFileService
    {
        public Task<IList<Travel>> ProcessFileAndReturnTravels(IFormFile? file);
    }
}
