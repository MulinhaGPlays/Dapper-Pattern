using DapperPattern.Infra.Models;
using DapperPattern.Infra.Repositories.RepositoryCommandLines;
using DapperPattern.Infra.Repositories.RepositoryCommands;
using System.Data.SqlClient;

namespace DappePattern.Console;
public class Program
{
    static void Main(string[] args)
    {
        const string connectionString = @"Data Source=.\WORLDSKILLSP1;Initial Catalog=DapperPattern;Integrated Security=True";
        using var connection = new SqlConnection(connectionString);

        //comandos
        var vip = new VipUsuarioCommands(connection);
        var administrador = new AdministradorUsuarioCommands(connection);

        //linhas de comando
        var administradorCL = new AdministradorUsuarioCommandLines();
        var vipCL = new VipUsuarioCommandLines();

        System.Console.ForegroundColor = ConsoleColor.Green;

        System.Console.WriteLine("Checagem de Linhas de comando: \n");

        System.Console.WriteLine(vipCL.count);
        System.Console.WriteLine(vipCL.delete);
        System.Console.WriteLine(vipCL.getById);
        System.Console.WriteLine(vipCL.getAll);
        System.Console.WriteLine(vipCL.getByName);
        System.Console.WriteLine(vipCL.insertInto);
        System.Console.WriteLine(vipCL.update);

        System.Console.WriteLine("\n==================================");
        System.Console.WriteLine("==================================\n");

        System.Console.WriteLine(administradorCL.update);
        System.Console.WriteLine(administradorCL.count);
        System.Console.WriteLine(administradorCL.getById);
        System.Console.WriteLine(administradorCL.delete);
        System.Console.WriteLine(administradorCL.getAll);
        System.Console.WriteLine(administradorCL.insertInto);

        System.Console.WriteLine("Execução de código: \n");

        var usuario1 = new Usuario() { Nome = "Filaupe", Descricao = "Programador", Tipo = 1 };
        var usuario2 = new Usuario() { Nome = "Pedro", Descricao = "Programador", Tipo = 2 };

        System.Console.WriteLine($"log: O schema Administrador tem atualmente {administrador.Count()} Usuarios");
        System.Console.WriteLine($"log: O schema Vip tem atualmente {vip.Count()} Usuarios");

        //vip.Insert(usuario1);
        //System.Console.WriteLine("log: Usuário inserido no schema Vip");
        //administrador.Insert(usuario2);
        //System.Console.WriteLine("log: Usuário inserido no schema Adminsitrador");
        //usuario1.Id = 1;
        //administrador.UpdateAsync(usuario1).Wait();
        //System.Console.WriteLine("log: Usuário alterado no schema Adminsitrador");
        //administrador.DeleteAsync(1).Wait();
        //System.Console.WriteLine("log: Usuário deletado no schema Adminsitrador");

        System.Console.WriteLine("Usuários VIP:\n");
        vip.SelectAll().ToList().ForEach(x => System.Console.WriteLine((string)x));

        System.Console.WriteLine("Usuários Administradores:\n");
        administrador.SelectAll().ToList().ForEach(x => System.Console.WriteLine((string)x));

        System.Console.WriteLine("Usuários Selecionados:\n");
        var allVips = vip.SelectAll();
        var id = allVips.LastOrDefault()?.Id;
        var usuario = id.HasValue ? vip.SelectById(id.Value) : null;
        var usuarioN = id.HasValue ? vip.GetByName("Filaupe") : null;

        if (usuario != null && usuarioN != null)
        {
            System.Console.WriteLine($"log: Foi selecionado o usuário vip: {(string)usuario}");
            System.Console.WriteLine($"log: Foi selecionado o usuário vip: {(string)usuarioN}");
        }
    }
}