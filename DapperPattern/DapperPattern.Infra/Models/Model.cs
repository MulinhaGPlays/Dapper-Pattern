using DapperPattern.Infra.Models.Interfaces;

namespace DapperPattern.Infra.Models;

public class Model : IModel
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Type { get; set; } = String.Empty;
}
