using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    public class NamedTypeId : TypeId, IEquatable<NamedTypeId>
    {
        public TypePart TypePart { get; }
        public IReadOnlyList<NamedTypeId> Arguments { get; }

        public NamedTypeId(TypePart part, IEnumerable<NamedTypeId> argument)
        {
            if (part == null)
                throw new ArgumentNullException(nameof(part));
            this.TypePart = part;
            this.Arguments = argument?.ToList().AsReadOnly();
        }

        public override bool Equals(TypeId other)
        {
            return Equals(other as NamedTypeId);
        }

        public bool Equals(NamedTypeId other)
        {
            if (other == null)
                return false;

            return other.TypePart == this.TypePart && CompareArguments(this.Arguments, other.Arguments);
        }

        private bool CompareArguments(IReadOnlyList<NamedTypeId> a1, IReadOnlyList<NamedTypeId> a2)
        {
            if (a1 == null && a2 == null)
                return false;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Count != a2.Count)
                return false;

            for (int i = 0; i < a1.Count; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 31;
            hashCode = (hashCode * 37) ^ TypePart.GetHashCode();
            if(Arguments != null)
            {
                for (int i = 0; i < Arguments.Count; i++)
                    hashCode = (hashCode * 37) ^ Arguments[i].GetHashCode();
            }
            return hashCode;
        }
    }
}
