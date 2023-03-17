using DapperPattern.Infra.Models;
using DapperPattern.Infra.Models.Schemes;
using DapperPattern.Infra.Repositories.RepositoryCommandLines.RepositoryBase;

namespace DapperPattern.Infra.Repositories.RepositoryCommandLines;

public class VipUsuarioCommandLines : Base
{
    public VipUsuarioCommandLines() : base(nameof(Vip), nameof(Usuario), new Usuario()) //"Testando", "Model" || null, "Model"
    {
        
    }

    public string getByName => $"SELECT * FROM {_scheme}{_model} WHERE {_columns.ToArray()[1]} = @Nome";
}
