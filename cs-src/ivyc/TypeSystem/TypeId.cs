using ivyc.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.TypeSystem
{
    public class TypeId
    {
        public Symbol Symbol { get; private set; }
        public IReadOnlyList<TypeId> Parameters { get; private set; }
    }
}
