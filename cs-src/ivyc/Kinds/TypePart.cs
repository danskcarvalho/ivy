using ivyc.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    public class TypePart : IEquatable<TypePart>
    {
        public int? ReferenceId { get; }
        public Symbol Symbol { get; }

        public bool IsReference => ReferenceId.HasValue;
        public bool IsSymbol => Symbol != null;

        public TypePart(int referenceId)
        {
            this.ReferenceId = referenceId;
        }
        public TypePart(Symbol symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));

            this.Symbol = symbol;
        }

        public override int GetHashCode()
        {
            return ReferenceId.HasValue ? ReferenceId.GetHashCode() : Symbol.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TypePart);
        }

        public bool Equals(TypePart other)
        {
            if (other == null)
                return false;

            return other.ReferenceId == this.ReferenceId && other.Symbol == this.Symbol;
        }

        public static bool operator ==(TypePart a, TypePart b)
        {
            if (object.ReferenceEquals(a, b))
                return true;
            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(TypePart a, TypePart b)
        {
            if (object.ReferenceEquals(a, b))
                return false;
            if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
                return true;

            return !a.Equals(b);
        }
    }
}
