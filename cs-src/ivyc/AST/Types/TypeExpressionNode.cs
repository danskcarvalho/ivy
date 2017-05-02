using System;
using ivyc.Basic;

namespace ivyc.AST {
	public abstract class TypeExpressionNode : Node {
		protected TypeExpressionNode(SourceLocation location) : base(location)
		{
		}
	}
}
