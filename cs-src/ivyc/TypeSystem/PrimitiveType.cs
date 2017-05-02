using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.TypeSystem
{
    public class PrimitiveType
    {
        public TypeId TypeId { get; private set; }
        public ulong Size { get; private set; }
        public ulong Alignment { get; private set; }
    }
}
