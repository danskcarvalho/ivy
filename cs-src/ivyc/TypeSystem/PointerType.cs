using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.TypeSystem
{
    public class PointerType : ProperType
    {
        public ProperType ElementType { get; private set; }
    }
}
