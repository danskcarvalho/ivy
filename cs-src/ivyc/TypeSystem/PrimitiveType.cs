using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.TypeSystem
{
    public class PrimitiveType : ProperType
    {
        public TypeId TypeId { get; }
        public ulong Size { get; }
        public ulong Alignment { get; }
    }
}
