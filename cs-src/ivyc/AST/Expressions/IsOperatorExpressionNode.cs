using System;
namespace ivyc.AST {
	public class IsOperatorExpressionNode : ExpressionNode {
		private IsOperatorExpressionNode() {
		}

		public ExpressionNode Left { get; private set; }
		public PatternNode Pattern { get; private set; }
	}
}
