using static Dapper.SqlMapper;

namespace DapperPattern.Infra.Repositories.Interfaces.RepositoryCommands;

public interface ICommands<TEntity> where TEntity : class
{
    int Count();
    IEnumerable<TEntity> SelectAll();
    TEntity? SelectById(int Id);
    void Insert(TEntity model);
    void Update(TEntity model);
    void Delete(int Id);

    Task<int> CountAsync();
    Task<IEnumerable<TEntity>> SelectAllAsync();
    Task<TEntity?> SelectByIdAsync(int Id);
    Task InsertAsync(TEntity model);
    Task UpdateAsync(TEntity model);
    Task DeleteAsync(int Id);
}
