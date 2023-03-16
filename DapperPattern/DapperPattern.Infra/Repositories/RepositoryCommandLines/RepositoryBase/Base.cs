using DapperPattern.Infra.Models.Interfaces;
using DapperPattern.Infra.Repositories.Interfaces.RepositoryCommandLines;

namespace DapperPattern.Infra.Repositories.RepositoryCommandLines.RepositoryBase
{
    public abstract class Base : ICommandLines
    {
        private readonly string? _scheme;
        private readonly string _model;
        private readonly string _values;
        private readonly string _set;
        private readonly IEnumerable<string> _columns;

        public Base(string? scheme, string modelName, IModel model)
        {
            _scheme = scheme != null ? $"{scheme}." : String.Empty;
            _model = modelName;
            _values = String.Join(',', _columns!);
            _columns = model.GetType().GetProperties().Select(x => x.Name);
            _set = 
        }

        public string count => $"SELECT COUNT(*) FROM {_scheme}{_model}";

        public string getAll => $"SELECT * FROM {_scheme}{_model}";

        public string getById => $"SELECT * FROM {_scheme}{_model} WHERE {_columns.First()} = @{_columns.First()}";

        public string insertInto => $"INSERT INTO {_scheme}{_model} VALUES ({_values})";

        public string update => $"UPDATE {_scheme}{_model} SET {_set}";

        public string delete => $"DELETE FROM {_scheme}{_model} WHERE {_columns.First()} = @{_columns.First()}";
    }
}
