using System.Collections.Generic;
using ivyc.Symbols;

namespace ivyc.TypeSystem
{
    public class ArraySpecification
    {
        public ArraySpecification(ulong? elementCount)
        {
            this.ElementCount = elementCount;
        }

        private ulong? ElementCount { get; }

        public static readonly ArraySpecification OneElement = new ArraySpecification(1);
        public static readonly ArraySpecification Flexible = new ArraySpecification(null);
    }

    public class StructField
    {
        public string Name { get; }
        public ProperType Type { get; }
        public ulong? Alignment { get; }
        public ArraySpecification ArraySpecification { get; }
        public Symbol Symbol { get; }
    }

    public class StructType : ProperType
    {
        public TypeId TypeId { get; }
        public IReadOnlyList<StructField> Fields { get; }
        public bool IsPacked { get; }
        public ulong? Alignment { get; }
    }
}