using System.Data;
using DapperPattern.Infra.Models;
using DapperPattern.Infra.Repositories.RepositoryCommandLines;
using DapperPattern.Infra.Repositories.RepositoryCommands.RepositoryBase;

namespace DapperPattern.Infra.Repositories.RepositoryCommands;

public class AdministradorUsuarioCommands : Base<Usuario, AdministradorUsuarioCommandLines>
{
    private readonly AdministradorUsuarioCommandLines _commandLines;

    public AdministradorUsuarioCommands(IDbConnection connection) : base(connection, new AdministradorUsuarioCommandLines())
    {
        _commandLines = new();
    }
}
