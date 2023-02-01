using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IGetBottleService
{
    public Task<Bottle?> GetBottleAsync(int id, bool includeRelations = true);

}