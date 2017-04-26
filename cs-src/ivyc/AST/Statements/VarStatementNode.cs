using System;
namespace ivyc.AST {
	public class VarStatementNode : StatementNode {
		private VarStatementNode() {
		}

		public PatternNode VarName { get; private set; }
		public ExpressionNode Initialization { get; private set; }
	}
}
