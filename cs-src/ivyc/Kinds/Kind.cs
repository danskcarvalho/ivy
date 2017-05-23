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

        public ConstructedClassKind(ClassType classType)
        {
            if (classType == null)
                throw new ArgumentNullException(nameof(classType));

            this.ClassType = classType;
        }
    }

    public abstract class ConstructorKindArgument
    {
    }

    public class IndependentConstructorKindArgument : ConstructorKindArgument
    {
        public Kind Argument { get; }

        public IndependentConstructorKindArgument(Kind argument)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));

            this.Argument = argument;
        }
    }

    public class DependentConstructorKindArgument : ConstructorKindArgument
    {
        public ConstructorKind Argument { get; }
        public IReadOnlyList<int> Dependencies { get; }

        public DependentConstructorKindArgument(ConstructorKind argument, IEnumerable<int> dependencies)
        {
            if (argument == null)
                throw new ArgumentNullException(nameof(argument));
            this.Argument = argument;
            this.Dependencies = dependencies?.ToList().AsReadOnly();

            if (this.Dependencies.Count == 0)
                throw new ArgumentException("must have dependencies");

            if (!IsSorted(this.Dependencies))
                throw new ArgumentException("dependencies must be sorted");

            if (Argument.Arguments.Count <= Dependencies.Count)
                throw new ArgumentException("invalid constructor");

            if (!AllUsed(Argument, Dependencies.Count))
                throw new ArgumentException("invalid constructor");
        }

        private bool AllUsed(ConstructorKind argument, int count)
        {
            throw new NotImplementedException();
        }

        private static bool IsSorted(IReadOnlyList<int> dependencies)
        {
            throw new NotImplementedException();
        }
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
