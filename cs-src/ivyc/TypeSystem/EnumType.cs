using System.Collections.Generic;
using ivyc.Symbols;

namespace ivyc.TypeSystem
{
    public class NamedValueField
    {
        public Symbol Symbol { get; }
        public ProperType Type { get; }
    }
    public class NamedValue
    {
        public string Name { get; }
        public ulong TagValue { get; }
        public IReadOnlyList<NamedValueField> Fields { get; }
        public Symbol Symbol { get; }
    }
    public class EnumType : ProperType
    {
        public TypeId TypeId { get; }
        public IReadOnlyList<NamedValue> NamedValues { get; }
        public IReadOnlyCollection<NamedValueTypeConstructor> NamedValueTypeConstructors { get; }
        public ProperType BackingType { get; set; }
        public bool IsAbstract { get; set; }
    }
}