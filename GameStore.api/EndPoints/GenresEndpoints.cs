using System;
using GameStore.api.Data;
using GameStore.api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.api.EndPoints;

public static class GenresEndPoints
{
  public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("genres");

    // GET /genres
    group.MapGet("/", async (GameStoreContext dbContext) =>
        await dbContext.Genres
                  .Select(genre => genre.ToDTO())
                  .AsNoTracking()
                  .ToListAsync());
    return group;
  }
}
