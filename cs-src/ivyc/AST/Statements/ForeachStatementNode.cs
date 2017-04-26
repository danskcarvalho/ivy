using System;
namespace ivyc.AST {
	public class ForeachStatementNode : StatementNode {
		private ForeachStatementNode() {
		}

		public ExpressionNode Sequence { get; private set; }
		public PatternNode VarName { get; private set; }
		public bool IsAwait { get; private set; }

	}
}
