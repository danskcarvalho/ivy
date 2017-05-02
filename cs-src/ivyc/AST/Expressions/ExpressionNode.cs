using System;
using ivyc.Basic;

namespace ivyc.AST {
	public abstract class ExpressionNode : Node {
		protected ExpressionNode(SourceLocation location) : base(location)
		{
		}
	}
}
