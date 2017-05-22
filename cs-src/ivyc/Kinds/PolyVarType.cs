using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    public class PolyVarType : ProperType
    {
        public Kind TypeArguments { get; }
        public FunctionArgument Result { get; }
    }
}
