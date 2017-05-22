using ivyc.AST;
using ivyc.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    public abstract class FunctionArgument
    {
        public bool IsLet { get; private set; }
        public bool IsUnstable { get; private set; }
        public RefKind Ref { get; private set; }
    }
    public class IndependentFunctionArgument : FunctionArgument
    {
        public ProperType Type { get; private set; }
    }
    public class DependentConstructedTypeFunctionArgument
    {
        public IReadOnlyList<int> Dependencies { get; }
        /// <summary>
        /// Must be in the order they appear in the type. The indexes of the dependent symbols starts with
        /// Dependencies.Count.
        /// </summary>
        public IReadOnlyList<Symbol> DependentSymbols { get; }

        public int Head { get; }
        public IReadOnlyList<int> Arguments { get; }
    }
    public class DependentFunctionTypeFunctionArgument : ConstructorKindArgument
    {
        public FunctionType Argument { get; }
        public IReadOnlyList<int> Dependencies { get; }
    }
    public class FunctionType : ProperType
    {
        public Kind TypeArguments { get; }
        public IReadOnlyList<FunctionArgument> Arguments { get; }
        public FunctionArgument Result { get; }
    }
}
