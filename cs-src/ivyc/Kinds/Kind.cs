using ivyc.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    public abstract class Kind
    {
        public static readonly Kind Star = new StarKind(0);
        public static readonly Kind Class = new ClassKind();
    }

    public class StarKind : Kind
    {
        public int Level { get; }

        public StarKind(int level)
        {
            if (level < 0)
                throw new ArgumentOutOfRangeException(nameof(level));
            this.Level = level;
        }
    }

    public class ClassKind : Kind
    {

    }

    public class ConstructedClassKind : Kind
    {
        /// <summary>
        /// This type must have kind class
        /// </summary>
        public ClassType ClassType { get; }
    }

    public abstract class ConstructorKindArgument
    {
    }

    public class IndependentConstructorKindArgument : ConstructorKindArgument
    {
        public Kind Argument { get; }
    }

    public class DependentConstructorKindArgument : ConstructorKindArgument
    {
        public Kind Argument { get; }
        public IReadOnlyList<int> Dependencies { get; }
    }

    public class DependentConstructedTypeConstructorKindArgument : ConstructorKindArgument
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

    public class ConstructorKind : Kind
    {
        public IReadOnlyList<ConstructorKindArgument> Arguments { get; }
        public ConstructorKindArgument Result { get; }
    }
}
