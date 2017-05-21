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
    public class FunctionArgument
    {
        public bool IsLet { get; }
        public bool IsVolatile { get; }
        public FunctionArgumentRef Ref { get; }
        public Type Type { get; }

        public FunctionArgument(bool isLet, bool isVolatile, FunctionArgumentRef @ref, Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            IsLet = isLet;
            IsVolatile = isVolatile;
            Ref = @ref;
            Type = type;
        }
    }
    public class FunctionTypeId : TypeId
    {
        public FunctionCallingConvention CallingConvention { get; }
        public IReadOnlyList<Kind> TypeArguments { get; }
        public IReadOnlyList<FunctionArgument> Arguments { get; }
        public FunctionArgument Result { get; }

        public FunctionTypeId(FunctionCallingConvention callingConvention, IEnumerable<Kind> typeArguments,
            IEnumerable<FunctionArgument> arguments, FunctionArgument result)
        {
            if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));
            if (arguments == null) throw new ArgumentNullException(nameof(arguments));
            if (result == null) throw new ArgumentNullException(nameof(result));
            CallingConvention = callingConvention;
            TypeArguments = typeArguments?.ToList().AsReadOnly();
            Arguments = arguments?.ToList().AsReadOnly();
            Result = result;
        }

        public override bool Equals(TypeId other)
        {
            throw new NotImplementedException();
        }
    }
}
