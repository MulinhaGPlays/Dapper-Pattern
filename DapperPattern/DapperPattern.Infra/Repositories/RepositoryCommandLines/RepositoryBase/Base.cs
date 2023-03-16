using DapperPattern.Infra.Repositories.Interfaces.RepositoryCommandLines;

namespace DapperPattern.Infra.Repositories.RepositoryCommandLines.RepositoryBase
{
    public class Base<TScheme, TEntity> : ICommandLines
    {
        public string count => $"SELECT COUNT(*) FROM {TScheme}.{TEntity}";

        public string getAll => throw new NotImplementedException();

        public string getById => throw new NotImplementedException();

        public string insertInto => throw new NotImplementedException();

        public string update => throw new NotImplementedException();

        public string delete => throw new NotImplementedException();
    }
}
