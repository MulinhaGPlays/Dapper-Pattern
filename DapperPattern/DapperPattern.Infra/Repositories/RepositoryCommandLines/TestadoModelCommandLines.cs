using DapperPattern.Infra.Models.Schemes;
using DapperPattern.Infra.Models;
using DapperPattern.Infra.Repositories.RepositoryCommandLines.RepositoryBase;

namespace DapperPattern.Infra.Repositories.RepositoryCommandLines;

public class TestadoModelCommandLines : Base
{
    public TestadoModelCommandLines() : base(nameof(Testado), nameof(Model), new Model()) //"Testado", "Model" || null, "Model"
    {

    }
}
