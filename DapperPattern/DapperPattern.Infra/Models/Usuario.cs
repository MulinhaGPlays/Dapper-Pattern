using DapperPattern.Infra.Models.Interfaces;

namespace DapperPattern.Infra.Models;

public class Usuario : IModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
    public string Descricao { get; set; } = String.Empty;
    public short Tipo { get; set; }

    public static implicit operator string(Usuario model) => $"Id = {model.Id}, Nome = {model.Nome}, Descrição = {model.Descricao}, Tipo = {model.Tipo}";
}
