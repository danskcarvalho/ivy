using System;
using ivyc.Basic;

namespace ivyc.AST {
	public abstract class KindExpressionNode : Node {
		protected KindExpressionNode(SourceLocation location) : base(location)
		{
		}
	}
}
