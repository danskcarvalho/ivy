using ivyc.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivyc.Kinds
{
    /// <summary>
    /// A constructed type whose kind is class
    /// </summary>
    public class ClassType
    {
        public Symbol Head { get; }
        public IReadOnlyList<Symbol> Arguments { get; }

        public ClassType(Symbol head, IEnumerable<Symbol> arguments)
        {
            if (head == null)
                throw new ArgumentNullException(nameof(head));

            this.Head = head;
            this.Arguments = arguments?.ToList().AsReadOnly();
        }
    }
}
