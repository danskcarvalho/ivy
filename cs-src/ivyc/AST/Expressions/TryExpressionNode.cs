using System;
namespace ivyc.AST {
	public enum TryExpressionBehavior {
		Silent,
		Fails		//failure if it throws and exception (only makes sense withou a catch)
	}
	public class TryExpressionNode : ExpressionNode {
		private TryExpressionNode() {
		}

		public ExpressionNode TryExpression { get; private set; }
		public ExpressionNode CatchExpression { get; private set; }
	}
}
