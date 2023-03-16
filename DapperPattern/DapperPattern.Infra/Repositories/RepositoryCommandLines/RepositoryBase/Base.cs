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
            _columns = model.GetType().GetProperties().Select(x => x.Name);
            _values = String.Join(',', _columns!);
            var values = _columns.Select(x => $"@{x}");
            _set = String.Join('=', Interleave(_columns, values));
        }

        public string count => $"SELECT COUNT(*) FROM {_scheme}{_model}";

        public string getAll => $"SELECT * FROM {_scheme}{_model}";

        public string getById => $"SELECT * FROM {_scheme}{_model} WHERE {_columns.First()} = @{_columns.First()}";

        public string insertInto => $"INSERT INTO {_scheme}{_model} VALUES ({_values})";

        public string update => $"UPDATE {_scheme}{_model} SET {_set}";

        public string delete => $"DELETE FROM {_scheme}{_model} WHERE {_columns.First()} = @{_columns.First()}";

        static List<string> Interleave(IEnumerable<string> list1, IEnumerable<string> list2)
        {
            int maxLength = Math.Max(list1.Count(), list2.Count());

            return Enumerable.Range(0, maxLength)
                .SelectMany(i => list1.Skip(i).Take(1).Concat(list2.Skip(i).Take(1)))
                .ToList();
        }
    }
}
