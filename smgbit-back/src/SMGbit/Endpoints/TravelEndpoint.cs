using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMGBit.Application.Commands.Travel.CreateTravel;
using SMGBit.Application.Queries.Travel.GetAllTravels;
using SMGBit.Domain.Interfaces;

namespace SMGbit.Api.Endpoints
{
    public static class TravelEndpoint
    {
        public static void RegisterTravelEndpoints(this WebApplication app)
        {
            app.MapGet("travels", GetAllTravels);
            app.MapPost("travels/process_file", ProcessTravelFile);
        }


        public static async Task<IResult> ProcessTravelFile(HttpRequest request, [FromServices] IFileService fileService, [FromServices] IMediator _mediator)
        {
            try
            {
                var file = request.Form.Files[0];
                var travels = await fileService.ProcessFileAndReturnTravels(file);

                var command = new CreateTravelsCommand()
                {
                    Items = travels
                };

                var response = await _mediator.Send(command);
                return response is not null ? TypedResults.Ok(response) : TypedResults.BadRequest();
            }
            catch (Exception)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public static async Task<IResult> GetAllTravels([FromServices] IMediator _mediator)
        {
            var query = new GetAllTravelsQuery();
            var response = await _mediator.Send(query);

            return TypedResults.Ok(response);
        }
    }
}
