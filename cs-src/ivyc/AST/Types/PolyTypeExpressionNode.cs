using System;
using System.Collections.Generic;
using ivyc.Basic;

namespace ivyc.AST {
	public class PolyTypeExpressionNode : TypeExpressionNode {
		public PolyTypeExpressionNode(SourceLocation location, TypeExpressionNode constructor, IReadOnlyList<TypeExpressionNode> arguments) : base(location)
		{
			Constructor = constructor;
			Arguments = arguments;
		}

		public TypeExpressionNode Constructor { get; private set; }
		public IReadOnlyList<TypeExpressionNode> Arguments { get; private set; }
	}
}
