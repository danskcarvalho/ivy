using System;
using System.Collections.Generic;
namespace ivyc.AST {
	public class WhileStatementNode : StatementNode {
		private WhileStatementNode() {
		}

		public string LabelName { get; private set; }
		public ExpressionNode Condition { get; private set; }
		public IReadOnlyList<StatementNode> Block { get; private set; }
	}
}
