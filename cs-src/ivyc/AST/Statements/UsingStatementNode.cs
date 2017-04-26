using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class UsingStatementNode : StatementNode {
		private UsingStatementNode() {
		}

		public PatternNode VarName { get; private set; }
		public ExpressionNode Initialization { get; private set; }
		public IReadOnlyList<StatementNode> Block { get; private set; }
	}
}
