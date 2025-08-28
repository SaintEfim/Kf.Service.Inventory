using Kf.Service.Inventory.Domain.Models.Base;
using Sieve.Models;

namespace Kf.Service.Inventory.Domain.Services.Base;

public interface IDataProvider<TModel>
    where TModel : class, IModel
{
    Task<IEnumerable<TModel>> Get(
        SieveModel? filter,
        bool withInclude = false,
        CancellationToken cancellationToken = default);

    Task<TModel> GetOneById(
        Guid id,
        bool withInclude = false,
        CancellationToken cancellationToken = default);
}
