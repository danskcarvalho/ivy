using ivyc.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    /// <summary>
    /// A constructed type whose kind is *
    /// </summary>
    public class ProperConstructedType : ProperType
    {
        public Symbol Head { get; }
        public IReadOnlyList<Symbol> Arguments { get; }
    }
}
