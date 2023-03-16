namespace DapperPattern.Infra.Repositories.Interfaces.RepositoryCommandLines;

public interface ICommandLines
{
    string count { get; }
    string getAll { get; }
    string getById { get; }
    string insertInto { get; }
    string update { get; }
    string delete { get; }
}
