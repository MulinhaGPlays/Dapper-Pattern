using DapperPattern.Infra.Models.Schemes;
using DapperPattern.Infra.Models;
using DapperPattern.Infra.Repositories.RepositoryCommandLines.RepositoryBase;

namespace DapperPattern.Infra.Repositories.RepositoryCommandLines;

public class AdministradorUsuarioCommandLines : Base
{
    public AdministradorUsuarioCommandLines() : base(nameof(Administrador), nameof(Usuario), new Usuario())
    {

    }
}
