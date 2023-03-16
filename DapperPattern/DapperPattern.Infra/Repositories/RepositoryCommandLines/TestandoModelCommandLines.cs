using DapperPattern.Infra.Models;
using DapperPattern.Infra.Models.Schemes;
using DapperPattern.Infra.Repositories.RepositoryCommandLines.RepositoryBase;

namespace DapperPattern.Infra.Repositories.RepositoryCommandLines;

public class TestandoModelCommandLines : Base
{
    public TestandoModelCommandLines() : base(nameof(Testando), nameof(Model), new Model()) //"Testando", "Model" || null, "Model"
    {
        
    }
}
