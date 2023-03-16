using DapperPattern.Infra.Repositories.RepositoryCommandLines;

namespace DappePattern.Console;

internal class Program
{
    static void Main(string[] args)
    {
        var testando = new TestandoModelCommandLines();

        System.Console.WriteLine(testando.count);
        System.Console.WriteLine(testando.getAll);
        System.Console.WriteLine(testando.getById);
        System.Console.WriteLine(testando.insertInto);
        System.Console.WriteLine(testando.update);
        System.Console.WriteLine(testando.delete);
    }
}