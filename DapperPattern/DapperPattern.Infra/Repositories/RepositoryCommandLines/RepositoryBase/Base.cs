using DapperPattern.Infra.Models.Interfaces;
using DapperPattern.Infra.Repositories.Interfaces.RepositoryCommandLines;

namespace DapperPattern.Infra.Repositories.RepositoryCommandLines.RepositoryBase
{
    public abstract class Base : ICommandLines
    {
        public readonly string? _scheme;
        public readonly string _model;
        public readonly string _values;
        public readonly string _set;
        public readonly IEnumerable<string> _columns;

        public Base(string? scheme, string modelName, IModel model)
        {
            _scheme = scheme != null ? $"{scheme}." : String.Empty;
            _model = modelName;
            _columns = model.GetType().GetProperties().Select(x => x.Name);
            var columns = _columns!.Skip(1);
            _values = String.Join(", ", columns);
            var interleaved = Interleave(columns, columns.Select(x => $"@{x}"));
            var formats = interleaved.Select((s, i) => i % 2 == 0 ? $"{s} = " : s).ToList();
            var concat = formats.Select((e, i) => i % 2 == 0 && i + 1 < interleaved.Count() ? e + formats[i + 1] : String.Empty);
            _set = String.Join(", ", concat.Where(x => x != String.Empty));
        }

        public string count => $"SELECT COUNT(*) FROM {_scheme}{_model}";
        public string getAll => $"SELECT * FROM {_scheme}{_model}";
        public string getById => $"SELECT * FROM {_scheme}{_model} WHERE {_columns.First()} = @{_columns.First()}";
        public string insertInto => $"INSERT INTO {_scheme}{_model} VALUES ({_values})";
        public string update => $"UPDATE {_scheme}{_model} SET {_set} WHERE {_columns.First()} = @{_columns.First()}";
        public string delete => $"DELETE FROM {_scheme}{_model} WHERE {_columns.First()} = @{_columns.First()}";

        private static IEnumerable<string> Interleave(IEnumerable<string> list1, IEnumerable<string> list2)
        {
            int maxLength = Math.Max(list1.Count(), list2.Count());
            return Enumerable.Range(0, maxLength).SelectMany(i => list1.Skip(i).Take(1).Concat(list2.Skip(i).Take(1)));
        }
    }
}
