using AutoMapper;
using Kf.Service.Inventory.Data.Models.Base;
using Kf.Service.Inventory.Data.Repositories.Base;
using Kf.Service.Inventory.Domain.Models.Base;
using Sieve.Models;

namespace Kf.Service.Inventory.Domain.Services.Base;

public abstract class DataProviderBase<TModel, TEntity, TRepository> : IDataProvider<TModel>
    where TModel : class, IModel
    where TEntity : class, IEntity
    where TRepository : IRepository<TEntity>
{
    protected DataProviderBase(
        IMapper mapper,
        TRepository repository)
    {
        Mapper = mapper;
        Repository = repository;
    }

    protected IMapper Mapper { get; }
    protected TRepository Repository { get; }

    public async Task<IEnumerable<TModel>> Get(
        SieveModel? filter,
        bool withInclude = false,
        CancellationToken cancellationToken = default)
    {
        return Mapper.Map<IEnumerable<TModel>>(await Repository.Get(filter, withInclude, cancellationToken));
    }

    public async Task<TModel> GetOneById(
        Guid id,
        bool withInclude = false,
        CancellationToken cancellationToken = default)
    {
        return Mapper.Map<TModel>(await Repository.GetOneById(id, withInclude, cancellationToken));
    }
}
