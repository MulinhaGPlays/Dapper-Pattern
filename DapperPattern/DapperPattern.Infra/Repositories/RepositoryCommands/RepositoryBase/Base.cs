using Dapper;
using DapperPattern.Infra.Repositories.Interfaces.RepositoryCommandLines;
using DapperPattern.Infra.Repositories.Interfaces.RepositoryCommands;
using System.Data;

namespace DapperPattern.Infra.Repositories.RepositoryCommands.RepositoryBase;

public class Base<TEntity, TCommandLines> : ICommands<TEntity>
    where TEntity : class
    where TCommandLines : ICommandLines
{
    public readonly IDbConnection _connection;
    public readonly ICommandLines CommandLines;

    public Base(IDbConnection connection, TCommandLines commandLines)
    {
        CommandLines = commandLines;
        _connection = connection;
    }

    public int Count() => _connection.QueryFirstOrDefault<int>(CommandLines.count);
    public IEnumerable<TEntity> SelectAll() => _connection.Query<TEntity>(CommandLines.getAll);
    public TEntity? SelectById(int Id) => _connection.Query<TEntity>(CommandLines.getById, new { Id }).FirstOrDefault();
    public void Insert(TEntity model) => _connection.Query<TEntity>(CommandLines.insertInto, model);
    public void Update(TEntity model) => _connection.Query<TEntity>(CommandLines.update, model );
    public void Delete(int Id) => _connection.Query<TEntity>(CommandLines.delete, new { Id });

    public async Task<int> CountAsync() => await _connection.QueryFirstOrDefaultAsync<int>(CommandLines.count);
    public async Task<IEnumerable<TEntity>> SelectAllAsync() => await _connection.QueryAsync<TEntity>(CommandLines.getAll);
    public async Task<TEntity?> SelectByIdAsync(int Id) => (await _connection.QueryAsync<TEntity>(CommandLines.getById, new { Id })).FirstOrDefault();
    public async Task InsertAsync(TEntity model) => await _connection.QueryAsync<TEntity>(CommandLines.insertInto, model);
    public async Task UpdateAsync(TEntity model) => await _connection.QueryAsync<TEntity>(CommandLines.update, model);
    public async Task DeleteAsync(int Id) => await _connection.QueryAsync<TEntity>(CommandLines.delete, new { Id });
}
