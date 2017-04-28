using System;
namespace ivyc.AST {
	public class IsOperatorExpressionNode : ExpressionNode {
		private IsOperatorExpressionNode() {
		}

		public ExpressionNode Left { get; private set; }
		//not supported in prototype
		//public PatternNode Pattern { get; private set; }
		//instead at the moment...
		public TypeExpressionNode Type { get; set; }
	}
}
