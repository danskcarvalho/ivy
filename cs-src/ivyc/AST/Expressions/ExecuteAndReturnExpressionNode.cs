using System;
using ivyc.Basic;

namespace ivyc.AST {
	public class ExecuteAndReturnExpressionNode : ExpressionNode {
		public ExecuteAndReturnExpressionNode(SourceLocation location, ExpressionNode execute, ExpressionNode @return) : base(location)
		{
			Execute = execute;
			Return = @return;
		}

		public ExpressionNode Execute { get; private set; }
		public ExpressionNode Return { get; private set; }
	}
}
