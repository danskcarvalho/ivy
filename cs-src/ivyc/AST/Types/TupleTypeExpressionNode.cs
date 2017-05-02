using System;
using System.Collections.Generic;
using System.Linq;
using ivyc.Basic;

namespace ivyc.AST {
	public class TupleTypeAgumentNode : Node {
		public TupleTypeAgumentNode(SourceLocation location, TypeExpressionNode type) : base(location)
		{
			Type = type;
		}

		public TypeExpressionNode Type { get; private set; }
	}
	public class TupleTypeExpressionNode : TypeExpressionNode {
		public TupleTypeExpressionNode(SourceLocation location, IEnumerable<TupleTypeAgumentNode> arguments) : base(location)
		{
			Arguments = arguments?.ToList().AsReadOnly();
		}

		public IReadOnlyList<TupleTypeAgumentNode> Arguments { get; private set; }
	}
}
