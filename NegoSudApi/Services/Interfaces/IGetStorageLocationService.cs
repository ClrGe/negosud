using NegoSudApi.Models;

namespace NegoSudApi.Services.Interfaces;

public interface IGetStorageLocationService
{
    public Task<StorageLocation?> GetStorageLocationAsync(int id, bool includeRelations = true);

}