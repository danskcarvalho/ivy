using System.Collections.Generic;
using ivyc.Symbols;

namespace ivyc.TypeSystem
{
    public class UnionField
    {
        public string Name { get; }
        public ProperType Type { get; }
        public ulong? Alignment { get; }
        public ArraySpecification ArraySpecification { get; }
        public Symbol Symbol { get; }
    }
    public class UnionType : ProperType
    {
        public TypeId TypeId { get; }
        public IReadOnlyList<StructField> Fields { get; }
        public bool IsPacked { get; }
        public ulong? Alignment { get; }
    }
}