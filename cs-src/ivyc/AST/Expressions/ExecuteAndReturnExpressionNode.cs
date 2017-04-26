using System;
namespace ivyc.AST {
	public class ExecuteAndReturnExpressionNode : ExpressionNode {
		private ExecuteAndReturnExpressionNode() {
		}

		public ExpressionNode Execute { get; private set; }
		public ExpressionNode Return { get; private set; }
	}
}
