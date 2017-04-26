using System;
namespace ivyc.AST {
	public class ConditionalExpressionNode : ExpressionNode {
		private ConditionalExpressionNode() {
		}

		public ExpressionNode Condition { get; private set; }
		public ExpressionNode TrueExpression { get; private set; }
		public ExpressionNode FalseExpression { get; private set; }
	}
}
