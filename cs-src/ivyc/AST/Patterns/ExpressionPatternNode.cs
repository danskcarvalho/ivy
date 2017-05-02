using System;
using ivyc.Basic;

namespace ivyc.AST {
	public class ExpressionPatternNode : Node {
		public ExpressionPatternNode(SourceLocation location, ExpressionNode expression) : base(location)
		{
			Expression = expression;
		}

		public ExpressionNode Expression { get; private set; }
	}
}
