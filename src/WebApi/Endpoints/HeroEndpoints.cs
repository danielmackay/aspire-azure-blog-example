using MediatR;
using AspireWebApp.Application.UseCases.Heroes.Commands.CreateHero;
using AspireWebApp.Application.UseCases.Heroes.Commands.UpdateHero;
using AspireWebApp.Application.UseCases.Heroes.Queries.GetAllHeroes;
using AspireWebApp.WebApi.Extensions;

namespace AspireWebApp.WebApi.Endpoints;

public static class HeroEndpoints
{
    public static void MapHeroEndpoints(this WebApplication app)
    {
        var group = app.MapApiGroup("heroes");

        group
            .MapGet("/", async (ISender sender, CancellationToken ct) =>
            {
                var results = await sender.Send(new GetAllHeroesQuery(), ct);
                return TypedResults.Ok(results);
            })
            .WithName("GetAllHeroes")
            .ProducesGet<HeroDto[]>();

        group
            .MapPut("/{heroId:guid}", async (
                Guid heroId,
                UpdateHeroCommand command,
                ISender sender,
                CancellationToken ct) =>
            {
                command.HeroId = heroId;
                var result = await sender.Send(command, ct);
                return result.Match(_ => TypedResults.NoContent(), CustomResult.Problem);
            })
            .WithName("UpdateHero")
            .ProducesPut();

        group
            .MapPost("/", async (ISender sender, CreateHeroCommand command, CancellationToken ct) =>
            {
                var result = await sender.Send(command, ct);
                return result.Match(_ => TypedResults.Created(), CustomResult.Problem);
            })
            .WithName("CreateHero")
            .ProducesPost();
    }
}