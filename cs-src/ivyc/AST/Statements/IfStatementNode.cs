using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class IfStatementNode : StatementNode {
		private IfStatementNode() {
		}

		public ExpressionNode Condition { get; private set; }
		public IReadOnlyList<StatementNode> TrueStatements { get; private set; }
		public IReadOnlyList<StatementNode> ElseStatements { get; private set; }
	}
}
