using System;
using ivyc.Basic;

namespace ivyc.AST {
	public class IsOperatorExpressionNode : ExpressionNode {
		public IsOperatorExpressionNode(SourceLocation location, ExpressionNode left, TypeExpressionNode type) : base(location)
		{
			Left = left;
			Type = type;
		}

		public ExpressionNode Left { get; private set; }
		//not supported in prototype
		//public PatternNode Pattern { get; private set; }
		//instead at the moment...
		public TypeExpressionNode Type { get; set; }
	}
}
