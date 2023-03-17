using Dapper;
using DapperPattern.Infra.Models;
using DapperPattern.Infra.Repositories.RepositoryCommandLines;
using DapperPattern.Infra.Repositories.RepositoryCommands.RepositoryBase;
using System.Data;

namespace DapperPattern.Infra.Repositories.RepositoryCommands;

public class VipUsuarioCommands : Base<Usuario, VipUsuarioCommandLines>
{
    private readonly VipUsuarioCommandLines _commandLines;

    public VipUsuarioCommands(IDbConnection connection) : base(connection, new VipUsuarioCommandLines())
    {
        _commandLines = new();
    }

    public Usuario? GetByName(string name) => _connection.Query<Usuario>(_commandLines.getByName, new { Nome = name }).FirstOrDefault();
}
