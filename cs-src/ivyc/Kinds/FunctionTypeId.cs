using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    public enum FunctionCallingConvention 
    {
        IvyCall,
        CCall
    }
    public enum FunctionArgumentRef
    {
        Copy,
        Ref,
        Move
    }
    public class FunctionParameter
    {
        public bool IsLet { get; }
        public bool IsVolatile { get; }
        public FunctionArgumentRef Ref { get; }
        public Type Type { get; }
    }
    public class FunctionTypeId : TypeId
    {
    }
}
